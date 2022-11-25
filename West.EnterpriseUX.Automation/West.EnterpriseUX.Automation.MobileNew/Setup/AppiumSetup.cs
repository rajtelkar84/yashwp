using AventStack.ExtentReports;
using BrowserStack;
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

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class AppiumSetup : Logger
    {
        static AppiumLocalService service;

        protected static AppiumDriver<IWebElement> driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        //private static string platformName;
        //private static string deviceName;
        private static string appPackage;
        private static string appActivity;
        private static Boolean noReset;
        private static string bundleId;
        //private static string automationName;
        private static string udid;
        public static string configFile;
        public static string batchFile;
        public static AppiumOptions appiumOptions;
        public BasePage _basePageInstance;
        public static Helper _helper = new Helper();

        public static CommonEnvironment commonEnvironment = new CommonEnvironment();
        public static string workingDirectory;
        public static string projectDirectory;
        public static string projectDirectoryfull;
        public static string JsonFilePath;

        public static string EnvName = Constant.ENV_NAME;
        public static string PlatformName = Constant.DEVICE_OS;
        public static string laptopName = Constant.LAPTOP_NAME;
        public static string EnvName_PlatformName = EnvName + "_" + PlatformName;

        public static string platformName = string.Empty;
        public static string platformVersion = string.Empty;
        public static string deviceName = string.Empty;
        public static string newCommandTimeout = string.Empty;
        //public static string appPackage = string.Empty;
        //public static string appActivity = string.Empty;
        //public static string udid = string.Empty;
        //public static string bundleId = string.Empty;
        public static string appName = string.Empty;
        public static string automationName = string.Empty;
        public static bool cloudAutomation = false;
        public static string browserstackUserName = string.Empty;
        public static string browserstackPassword = string.Empty;
        public static string localTunneling = string.Empty;
        public static string projectName = string.Empty;
        public static string buildName = string.Empty;
        public static string testName = string.Empty;
        public static string appURL = string.Empty;
        public static Local browserStackLocal = null;
        public static string logsFolderPath = string.Empty;
        public static string screenshotsFolderPath = string.Empty;
        public static string buildsPath = string.Empty;
        public static string testErrorMessage = string.Empty;
        public static string userName = string.Empty;
        public static string password = string.Empty;
        protected static string MobPlatform;

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
            //automationName = commonEnvironment.automationName;
            udid = commonEnvironment.udid;

            //------------------- Browserstack setting POC -------------------//

            try
            {
                cloudAutomation = bool.Parse(context.Properties["CloudAutomation"].ToString());
                MobPlatform = context.Properties["PlatformName"].ToString();

                logsFolderPath = context.Properties["LogFolderPath"].ToString();
                screenshotsFolderPath = context.Properties["ScreenshotFolderPath"].ToString();
                buildsPath = context.Properties["BuildsPath"].ToString();

                //Create Logs, Screenshots, Builds Folder if not present
                _helper.CreateFolder(logsFolderPath);
                _helper.CreateFolder(screenshotsFolderPath);
                _helper.CreateFolder(buildsPath);

                //Reads the UserName and Password
                ReadUserEmailIDandPassword(context);

                //Reading the Pipeline Variables
                LoadPipelineVariables();

                //Verifying the Pipeline Variables validation
                if (cloudAutomation && string.IsNullOrEmpty(browserstackUserName))
                {
                    LogInfo("Reading of the RunSetting Variables Started");

                    browserstackUserName = context.Properties["BrowserstackUserName"].ToString();
                    browserstackPassword = context.Properties["BrowserstackPassword"].ToString();

                    LogInfo("Browserstack UserName : " + browserstackUserName);
                }
                if (cloudAutomation && string.IsNullOrEmpty(appURL))
                {
                    appURL = context.Properties["AppURL"].ToString();

                    LogInfo("Browserstack appURL : " + appURL);
                    LogInfo("Reading of the RunSetting Variables finished");
                }

                if (extent == null)
                {
                    extent = ExtentManager.GetInstance();
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Assembly Initialize finished");
            }

            //------------------- Browserstack setting POC -------------------//
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            try
            {
                extent.Flush();

                LogInfo("Assembly Cleanup Started");

                //Stop the BrowserStack Local binary
                if (browserStackLocal != null)
                {
                    browserStackLocal.stop();
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Assembly Cleanup finished");
            }
        }

        [TestInitialize]
        public void StartAppiumServerAndInvokeDriver()
        {
            try
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

                //OpenEmulator();
                //LaunchApp();
                LaunchApp(MobPlatform, DeviceType.RealDevice.ToString(), TestContext, cloudAutomation);
                _basePageInstance = new BasePage(driver);
                LoginToWDApp();
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Test Initialize finished");
            }
        }

        [TestCleanup]
        public void StopAppiumServerAndQuitDriver()
        {
            try
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

                //Stop the BrowserStack Local binary
                if (browserStackLocal != null)
                {
                    browserStackLocal.stop();
                }

                LogInfo($"Test : {TestContext.TestName} finished");
                LogInfo("Test Cleanup finished");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }

        private void LaunchApp()
        {
            AppiumLocalService _appiumLocalService;
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();

            Console.WriteLine("Appium Service Started: " + _appiumLocalService.IsRunning);
            var abv = _appiumLocalService.IsRunning;

            if (platformName.ToLower().Equals("android"))
            {
                /*
                appiumOptions = new AppiumOptions();

                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);

                driver = new AndroidDriver<IWebElement>(_appiumLocalService, appiumOptions);
                */

                // ------------------------- Browserstack POC -------------------------

                // To start browserstack local tunneling
                Local browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("key", "MGfnZCgjRHYj5sJa1CHd")
                };

                foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
                {
                    if (myProc.ProcessName == "BrowserStackLocal")
                    {
                        myProc.Kill();
                    }
                }

                browserStackLocal.start(bsLocalArgs);

                appiumOptions = new AppiumOptions();

                appiumOptions.AddAdditionalCapability("browserstack.user", "girishwarpatilex_nub4P7");
                appiumOptions.AddAdditionalCapability("browserstack.key", "MGfnZCgjRHYj5sJa1CHd");
                appiumOptions.AddAdditionalCapability("app", "bs://080fbeaee5d30f303c736c8b80ac00d5247bde34");
                appiumOptions.AddAdditionalCapability("os_version", "11.0");
                appiumOptions.AddAdditionalCapability("device", "Samsung Galaxy M52");
                appiumOptions.AddAdditionalCapability("browserstack.local", "true");
                appiumOptions.PlatformName = "Android";
                appiumOptions.AddAdditionalCapability("project", "WD2.0");
                appiumOptions.AddAdditionalCapability("build", "com.westpharma.uxframework.dev");
                appiumOptions.AddAdditionalCapability("name", "West Digital 2.0");

                driver = new AndroidDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);
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

                driver = new IOSDriver<IWebElement>(_appiumLocalService, appiumOptions);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void LaunchApp(string environment, string deviceType, TestContext context, bool browserStackCloud = false)
        {
            if (browserStackCloud)
            {
                LogInfo("Started to load the Browser Stack Desired Capabilities");
                LoadBrowserStackappiumOptions(context);
                LogInfo("Finished loading of Browser Stack Desired Capabilities");

                LogInfo("Started Local tunnelling");
                browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                        new KeyValuePair<string, string>("key", browserstackPassword)
                    };

                foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
                {
                    if (myProc.ProcessName == "BrowserStackLocal")
                    {
                        myProc.Kill();
                    }
                }

                browserStackLocal.start(bsLocalArgs);

                if (MobPlatform.ToLower().Equals(MobileDevicePlatform.IOS.ToString().ToLower()))
                {
                    LogInfo("Started WD IOS App");
                    driver = new IOSDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);
                }
                else
                {
                    LogInfo("Started WD Android App");
                    driver = new AndroidDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            else
            {
                /*  
                AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder()
                 .UsingAnyFreePort()
                 .WithAppiumJS(new System.IO.FileInfo("/Applications/Appium Server GUI.app/Contents/Resources/app/node_modules/appium/lib/main.js"));
                 .WithAppiumJS(new System.IO.FileInfo(@"C:\Users\patilg\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"));
                 .WithAppiumJS(new System.IO.FileInfo(@"/usr/local/lib/node_modules/appium/main.js"));

                service = appiumServiceBuilder.Build();

                if (!service.IsRunning)
                    service.Start();
                */

                AppiumLocalService _appiumLocalService;
                _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                _appiumLocalService.Start();

                Console.WriteLine("Appium Service Started: " + _appiumLocalService.IsRunning);
                var abv = _appiumLocalService.IsRunning;

                noReset = bool.Parse(context.Properties["NoReset"].ToString());

                if (platformName.ToLower().Equals("android"))
                {
                    appiumOptions = new AppiumOptions();

                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                    appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
                    appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);

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

                    driver = new IOSDriver<IWebElement>(_appiumLocalService, appiumOptions);
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
        }

        public void LoginToWDApp()
        {
            try
            {
                IList<IWebElement> loader = _basePageInstance.LoaderImage;

                WaitForLoaderToDisappear(loader);
                (new TouchAction(driver)).Tap(89, 612).Perform();
                WaitForMoment(5);
                new Actions(driver).SendKeys(userName).Perform();
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForMoment(5);
                new Actions(driver).SendKeys(password).Perform();
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForLoaderToDisappear(loader);

                if(_basePageInstance.SkipButton.Count > 0)
                {
                    _basePageInstance.SkipButton[0].Click();
                    WaitForMoment(5);
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }

        private void LogoutFromWDApp()
        {
            try
            {
                IList<IWebElement> loader = _basePageInstance.LoaderImage;

                WaitForLoaderToDisappear(loader);

                _basePageInstance.ProfileMenu[0].Click();
                _basePageInstance.Logout[0].Click();
                _basePageInstance.LogoutOkButton[0].Click();

                WaitForLoaderToDisappear(loader);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }

        private void OpenEmulator()
        {
            try
            {
                LogInfo($"Opening Emulator through Batch file...........");

                string emulatorPath = projectDirectoryfull + batchFile + "OpenEmulator.bat";
                Process.Start(emulatorPath);

                LogInfo($"Open Emulator Batch File Path : {emulatorPath}");
                WaitForMoment(1);
                Process[] emulators = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                LogError($"Error in launching emulator: {ex.Message}");
            }
        }
        public void WaitForLoaderToDisappear(IList<IWebElement> loader, string locatorName = "all")
        {
            int timeout = 30;
            Stopwatch stopwatch = new Stopwatch();
            IList<IWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
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
                    WaitForMoment(1);

                    timeTaken = stopwatch.Elapsed;

                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} {ex.StackTrace}");
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

        public static void ReadUserEmailIDandPassword(TestContext context)
        {
            LogInfo("Reading of the UserEmailID and Password fields Started");

            if (string.IsNullOrEmpty(userName) | string.IsNullOrEmpty(password))
            {
                userName = context.Properties["TestUser4EmailId"].ToString();
                string encryptedPassword = context.Properties["TestUser4Password"].ToString();
                password = CommonTestSettings.Decrypt(encryptedPassword);
            }

            LogInfo("Reading of the UserEmailID and Password fields finished");
        }

        public static void LoadPipelineVariables()
        {
            try
            {
                LogInfo("Reading of the Pipleline Variables Started");

                browserstackUserName = Environment.GetEnvironmentVariable("BrowserstackUserName");
                browserstackPassword = Environment.GetEnvironmentVariable("BrowserstackPassword");
                appURL = Environment.GetEnvironmentVariable("AppURL");

                LogInfo("Browserstack UserName : " + browserstackUserName);
                LogInfo("Browserstack appURL : " + appURL);
                LogInfo("Reading of the Pipleline Variables finished");
            }
            catch (Exception ex)
            {
                LogError($"Issue in reading the Azure Pipeline Variables: {ex.Message} : {ex.StackTrace}");
            }
        }

        public static void LoadBrowserStackappiumOptions(TestContext context)
        {
            try
            {
                if (cloudAutomation && MobPlatform.ToLower().Equals(MobileDevicePlatform.IOS.ToString().ToLower()))
                {
                    //Initializing the IOS DC for Browser Stack
                    localTunneling = context.Properties["LocalTunneling"].ToString();
                    projectName = context.Properties["Project"].ToString();
                    buildName = context.Properties["Build"].ToString();
                    testName = context.Properties["TestName"].ToString();
                    platformVersion = context.Properties["PlatformVersion"].ToString();
                    deviceName = context.Properties["DeviceName"].ToString();
                    newCommandTimeout = context.Properties["NewCommandTimeout"].ToString();
                    //automationName = context.Properties["AutomationName"].ToString();

                    appiumOptions = new AppiumOptions();

                    appiumOptions.AddAdditionalCapability("browserstack.user", browserstackUserName);
                    appiumOptions.AddAdditionalCapability("browserstack.key", browserstackPassword);
                    appiumOptions.AddAdditionalCapability("app", appURL);
                    appiumOptions.AddAdditionalCapability("device", deviceName);
                    appiumOptions.AddAdditionalCapability("os_version", platformVersion);
                    appiumOptions.AddAdditionalCapability("browserstack.local", localTunneling);
                    appiumOptions.PlatformName = "iOS";
                    appiumOptions.AddAdditionalCapability("project", projectName);
                    appiumOptions.AddAdditionalCapability("build", buildName);
                    appiumOptions.AddAdditionalCapability("name", testName);
                    appiumOptions.AddAdditionalCapability("browserstack.idleTimeout", 120);
                    appiumOptions.AddAdditionalCapability("browserstack.acceptInsecureCerts", "true");
                    //appiumOptions.AddAdditionalCapability("automationName", automationName);
                }
                else
                {
                    //Initializing the Android DC for Browser Stack
                    localTunneling = context.Properties["LocalTunneling"].ToString();
                    projectName = context.Properties["Project"].ToString();
                    buildName = context.Properties["Build"].ToString();
                    testName = context.Properties["TestName"].ToString();
                    platformVersion = context.Properties["PlatformVersion"].ToString();
                    deviceName = context.Properties["DeviceName"].ToString();
                    newCommandTimeout = context.Properties["NewCommandTimeout"].ToString();
                    //automationName = context.Properties["AutomationName"].ToString();

                    appiumOptions = new AppiumOptions();

                    appiumOptions.AddAdditionalCapability("browserstack.user", browserstackUserName);
                    appiumOptions.AddAdditionalCapability("browserstack.key", browserstackPassword);
                    appiumOptions.AddAdditionalCapability("app", appURL);
                    appiumOptions.AddAdditionalCapability("device", deviceName);
                    appiumOptions.AddAdditionalCapability("os_version", platformVersion);
                    appiumOptions.AddAdditionalCapability("browserstack.local", localTunneling);
                    appiumOptions.PlatformName = "Android";
                    appiumOptions.AddAdditionalCapability("project", projectName);
                    appiumOptions.AddAdditionalCapability("build", buildName);
                    appiumOptions.AddAdditionalCapability("name", testName);
                    //appiumOptions.AddAdditionalCapability("automationName", automationName);
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
    }
}
