using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
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
using West.EnterpriseUX.Automation.MobileNew.Utilities;

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
        private static string bundleId;
        private static string automationName;
        private static string udid;
        public static string configFile;
        private AppiumOptions appiumOptions;
        public BasePage _basePageInstance;

        public static CommonEnvironment commonEnvironment;
        public static string workingDirectory;
        public static string projectDirectory;
        public static string projectDirectoryfull;
        public static string JsonFilePath;

        public static string EnvName = "UAT";
        public static string PlatformName = "ANDROID";
        public static string laptopName = "Windows";
        public static string EnvName_PlatformName = EnvName + "_" + PlatformName;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void LoadProperties(TestContext context)
        {
             workingDirectory = Environment.CurrentDirectory;
             projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
             projectDirectoryfull = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            if(laptopName.ToUpper().Trim().Equals("MACBOOK"))
            {
                configFile = "/configFiles/";
            }
            else
            {
                configFile = @"\configFiles\";
            }

            switch(EnvName_PlatformName.ToUpper())
            {
                case "DEV_ANDROID":
                    JsonFilePath = projectDirectoryfull + configFile + "Android_DEV_Environment.json";
                    break;
                case "DVV_ANDROID":
                    JsonFilePath = projectDirectoryfull + configFile+ "Android_DVV_Environment.json";
                    break;
                case "UAT_ANDROID":
                    JsonFilePath = projectDirectoryfull + configFile + "Android_Quality_Environment.json";
                    break;
                case "DEV_IOS":
                    JsonFilePath = projectDirectoryfull + configFile + "IOS_DEV_Environment.json";
                    break;
                case "DVV_IOS":
                    JsonFilePath = projectDirectoryfull + configFile + "IOS_DVV_Environment.json";
                    break;
                case "UAT_IOS":
                    JsonFilePath = projectDirectoryfull + configFile + "IOS_Quality_Environment.json";
                    break;
                default:
                    Console.WriteLine($"Either PlatformName{PlatformName} or EnvName {EnvName} is not set properly");
                    break;
            }

            //dvvJsonFilePath = projectDirectoryfull + "/configFiles/"+"Android_DVV_Environment.json";

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            
            //configurationBuilder.AddJsonFile("/Users/csadmin/Desktop/WestPharmaMobileAutomation/EnterpriseUX.MobileAutomation/West.EnterpriseUX.Automation/MobileAutomationCrossPlatform/configFiles/Android_DVV_Environment.json");
            
            configurationBuilder.AddJsonFile(JsonFilePath);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            commonEnvironment = new CommonEnvironment();
            configurationRoot.Bind(commonEnvironment);

            platformName = commonEnvironment.PlatformName ;
            deviceName = commonEnvironment.DeviceName;
            appPackage = commonEnvironment.AppPackage;
            appActivity = commonEnvironment.appActivity;
            noReset = Convert.ToBoolean(commonEnvironment.NoReset.ToString());
            bundleId = commonEnvironment.bundleId;
            automationName = commonEnvironment.automationName;
            udid = commonEnvironment.udid;

            /*
            platformName = context.Properties["PlatformName"].ToString();
            deviceName = context.Properties["DeviceName"].ToString();
            appPackage = context.Properties["AppPackage"].ToString();
            appActivity = context.Properties["AppActivity"].ToString();
            noReset = Convert.ToBoolean(context.Properties["NoReset"].ToString());
            */

            if (extent == null)
            {
                extent = ExtentManager.GetInstance();
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

            if (laptopName.ToUpper().Trim().Equals("MACBOOK"))
            {
                string abc = Environment.GetEnvironmentVariable("ANDROID_HOME");
                Console.WriteLine(abc);

                Environment.SetEnvironmentVariable("ANDROID_HOME", "/Users/csadmin/Library/Android/sdk");
                Environment.SetEnvironmentVariable("JAVA_HOME", "/Library/Java/JavaVirtualMachines/openlogic-openjdk-8.jdk/Contents/Home");

                abc = Environment.GetEnvironmentVariable("ANDROID_HOME");
                Console.WriteLine(abc);
            }

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
                appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, bundleId);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, automationName);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, udid);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);
                Console.WriteLine("Create iOS capabilities.");

                driver = new IOSDriver<IWebElement>(_appiumLocalService, appiumOptions);
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

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
