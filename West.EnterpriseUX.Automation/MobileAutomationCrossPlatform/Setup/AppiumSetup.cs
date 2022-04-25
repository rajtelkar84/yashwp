using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.configFiles;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class AppiumSetup
    {
        static AppiumLocalService service;
        
        protected AppiumDriver<IWebElement> driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        private static string platformName;
        private static string deviceName;
        private static string appPackage;
        private static string appActivity;
        private static Boolean noReset;
        private AppiumOptions appiumOptions;
        public BasePage _basePageInstance;

        public static Android_DVV_Environment android_DVV_Environment;
        public static string workingDirectory;
        public static string projectDirectory;
        public static string projectDirectoryfull;
        public static string dvvJsonFilePath;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void LoadProperties(TestContext context)
        {
             workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            // This will get the current PROJECT bin directory (ie ../bin/)
             projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // This will get the current PROJECT directory
             projectDirectoryfull = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

             dvvJsonFilePath = projectDirectoryfull + "/configFiles/"+"Android_DVV_Environment.json";

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
           // configurationBuilder.AddJsonFile("/Users/csadmin/Desktop/WestPharmaMobileAutomation/EnterpriseUX.MobileAutomation/West.EnterpriseUX.Automation/MobileAutomationCrossPlatform/configFiles/Android_DVV_Environment.json");
            configurationBuilder.AddJsonFile(dvvJsonFilePath);
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            android_DVV_Environment = new Android_DVV_Environment();
            configurationRoot.Bind(android_DVV_Environment);

            platformName = android_DVV_Environment.PlatformName ;
            deviceName = android_DVV_Environment.DeviceName;
            appPackage = android_DVV_Environment.AppPackage;
            appActivity = android_DVV_Environment.appActivity;
            noReset = Convert.ToBoolean(android_DVV_Environment.NoReset.ToString());

            /*
            platformName = context.Properties["PlatformName"].ToString();
            deviceName = context.Properties["DeviceName"].ToString();
            appPackage = context.Properties["AppPackage"].ToString();
            appActivity = context.Properties["AppActivity"].ToString();
            noReset = Convert.ToBoolean(context.Properties["NoReset"].ToString());
            */

            if (extent == null)
            {
                extent = new ExtentReports();
                // ExtentHtmlReporter reporter = new ExtentHtmlReporter(@"C:\Users\patilg\OneDrive - West Pharmaceutical Services, Inc\Desktop\ExtentReports\");
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(projectDirectoryfull+ "/ExtentReports/");
                extent.AttachReporter(reporter);
            }
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            extent.Flush();
        }

        [TestInitialize]
        public void StartAppiumServerAndInvokeDriver()
        {
            test = extent.CreateTest(TestContext.TestName);

            string abc = Environment.GetEnvironmentVariable("ANDROID_HOME");

            Console.WriteLine(abc);

            Environment.SetEnvironmentVariable("ANDROID_HOME", "/Users/csadmin/Library/Android/sdk");


            Environment.SetEnvironmentVariable("JAVA_HOME", "/Library/Java/JavaVirtualMachines/openlogic-openjdk-8.jdk/Contents/Home");

            abc = Environment.GetEnvironmentVariable("ANDROID_HOME");

            Console.WriteLine(abc);


            LaunchApp();

            _basePageInstance = new BasePage(driver);

            LoginToWDApp();
        }

        [TestCleanup]
        public void StopAppiumServerAndQuitDriver()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                test.Log(Status.Pass, "Test Method Name " + TestContext.TestName + " : " + TestContext.CurrentTestOutcome + " - snapshot below");
            }
            else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                test.Log(Status.Fail, "Test Method Name " + TestContext.TestName + " : " + TestContext.CurrentTestOutcome + " - snapshot below");
            }
            else
            {
                test.Log(Status.Skip, "Test Method Name " + TestContext.TestName + " : " + TestContext.CurrentTestOutcome + " - snapshot below");
            }

            Screenshot screenshot = driver.GetScreenshot();
            test.AddScreenCaptureFromBase64String(screenshot.AsBase64EncodedString, title: TestContext.TestName);

            //LogoutFromWDApp();
            driver?.Quit();
            service?.Dispose();
        }

        private void LaunchApp()
        {
          /*  
            AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder()
                 .UsingAnyFreePort()
                 .WithAppiumJS(new System.IO.FileInfo("/Applications/Appium Server GUI.app/Contents/Resources/app/node_modules/appium/lib/main.js"));

            */
            // .WithAppiumJS(new System.IO.FileInfo(@"C:\Users\patilg\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"));
            //.WithAppiumJS(new System.IO.FileInfo(@"/usr/local/lib/node_modules/appium/main.js"));


            //  service = appiumServiceBuilder.Build();

            AppiumLocalService _appiumLocalService;
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            Console.WriteLine("Appium Service Started: " + _appiumLocalService.IsRunning);
            var abv = _appiumLocalService.IsRunning;


/*
            if (!service.IsRunning)
                service.Start();
*/

            if (platformName.ToLower().Equals("android"))
            {
                appiumOptions = new AppiumOptions();

                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);

                // driver = new AndroidDriver<IWebElement>(service, appiumOptions);
                driver = new AndroidDriver<IWebElement>(_appiumLocalService, appiumOptions);
            }
            else
            {
                Console.WriteLine("Create iOS capabilities.");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        private void LoginToWDApp()
        {
            IList<IWebElement> loader = _basePageInstance.LoaderImage;
            WaitForLoaderToDisappear(loader);

            (new TouchAction(driver)).Tap(284, 441).Perform();

            new Actions(driver).SendKeys("PRAPPP1@WESTPHARMA.COM").Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys("Testing$2020").Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys(Keys.Enter).Perform();

            WaitForLoaderToDisappear(loader);
        }

        private void LogoutFromWDApp()
        {
            IList<IWebElement> loader = _basePageInstance.LoaderImage;
            WaitForLoaderToDisappear(loader);

            _basePageInstance.HamberMenu[0].Click();
            _basePageInstance.Logout[0].Click();
            _basePageInstance.LogoutOkButton[0].Click();

            WaitForLoaderToDisappear(loader);
        }

        public void WaitForLoaderToDisappear(IList<IWebElement> loader, string locatorName = "all")
        {
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<IWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            Thread.Sleep(1000);
            IList<IWebElement> AllLoadingTexts = _basePageInstance.AllLoadingTexts;
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    if (locatorName.Equals("all"))
                    {
                        loadingElement = AllLoadingTexts;

                        IList<IWebElement> userInfromationPopUp = _basePageInstance.UserInfromationPopUp;
                        if (userInfromationPopUp?.Count > 0)
                        {
                            userInfromationPopUp[0].Click();
                        }
                    }
                    else
                    {
                        loadingElement = loader;
                    }
                    if (loadingElement?.Count > 0)
                    {
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(1000);

                    timeTaken = stopwatch.Elapsed;

                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
        }
    }
}
