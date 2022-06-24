using AventStack.ExtentReports;
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
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
        public static string batchFile;
        private AppiumOptions appiumOptions;
        public BasePage _basePageInstance;

        public static CommonEnvironment commonEnvironment = new CommonEnvironment();
        public static string workingDirectory;
        public static string projectDirectory;
        public static string projectDirectoryfull;
        public static string JsonFilePath;

        public static string EnvName = Constant.ENV_NAME;
        public static string PlatformName = Constant.DEVICE_OS;
        public static string laptopName = Constant.LAPTOP_NAME;
        public static string EnvName_PlatformName = EnvName + "_" + PlatformName;

        public TestContext TestContext { get; set; }
        [AssemblyInitialize]
        public static void LoadProperties(TestContext context)
        {
            //Environment.SetEnvironmentVariable("ENVNAME", "DVV");
            string value = Environment.GetEnvironmentVariable("ENVNAME");
           
            if(value != null)
            {
                EnvName = value;
            }
            EnvName_PlatformName = EnvName + "_" + PlatformName;

            workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"Environment Name: {EnvName}, EnvName_PlatformName: {EnvName_PlatformName}, PlatformName: {PlatformName}, LaptopName: {laptopName}");

            EnvName = Environment.GetEnvironmentVariable("newEnvName");
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            projectDirectoryfull = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            if (laptopName.ToUpper().Trim().Equals("MACBOOK"))
            {
                configFile = "/configFiles/";
            }
            else
            {
                configFile = @"\configFiles\";
            }
            if (laptopName.ToUpper().Trim().Equals("MACBOOK"))
            {
                batchFile = "/BatchFiles/";
            }
            else
            {
                batchFile = @"\BatchFiles\";
            }

            switch (EnvName_PlatformName.ToUpper())
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

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(JsonFilePath);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            configurationRoot.Bind(commonEnvironment);

            platformName = commonEnvironment.PlatformName;
            deviceName = commonEnvironment.DeviceName;
            appPackage = commonEnvironment.AppPackage;
            appActivity = commonEnvironment.appActivity;
            noReset = Convert.ToBoolean(commonEnvironment.NoReset.ToString());
            bundleId = commonEnvironment.bundleId;
            automationName = commonEnvironment.automationName;
            udid = commonEnvironment.udid;

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
            OpenEmulator();
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

            new Actions(driver).SendKeys(commonEnvironment.TestUser1EmailId).Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(5000);
            new Actions(driver).SendKeys(commonEnvironment.TestUser1Password).Perform();
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

        private void OpenEmulator()
        {
            try
            {
                Console.WriteLine($"Opening Emulator through Batch file...........");
                string emulatorPath = projectDirectoryfull + batchFile + "OpenEmulator.bat";
                Process.Start(emulatorPath);
                Console.WriteLine($"Open Emulator Batch File Path : {emulatorPath}");
                WaitForMoment(1);
                Process[] emulators = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in launching emulator: {ex.Message}");
            }
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

        public static void WaitForMoment(int delay)
        {
            Thread.Sleep(delay * 1000);
        }

        public static void WaitForMoment(double delay)
        {
            Thread.Sleep(Convert.ToInt32(delay * 1000));
        }
    }
}
