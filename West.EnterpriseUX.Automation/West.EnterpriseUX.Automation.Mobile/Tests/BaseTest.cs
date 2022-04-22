using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using BrowserStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using West.EnterpriseUX.Automation.Mobile.PageActions;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile
{
    [TestClass]
    public class BaseTest : Logger
    {

        protected static AppiumDriver<AppiumWebElement> _session;
        protected static AppiumDriver<AppiumWebElement> _session1;
        protected static string MobPlatform;
        protected static Helper _helper = new Helper();
        protected static AppiumOptions desiredCapabilities;
        protected static AppiumLocalService appiumLocalService;
        protected static IOSDriver<IOSElement> iOSDriver = null;
        protected static AndroidDriver<AndroidElement> androidDriver = null;
        public static string platformName = string.Empty;
        public static string platformVersion = string.Empty;
        public static string deviceName = string.Empty;
        public static string newCommandTimeout = string.Empty;
        public static string appPackage = string.Empty;
        public static string appActivity = string.Empty;
        public static string udid = string.Empty;
        public static string bundleId = string.Empty;
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
        public Stopwatch testTimer;
        public static string testResultsLogFileName = "TestResult_" + $"{DateTime.Now:dd_MM_yyyy}" + ".csv";

        #region Actions Page Variables
        protected static LoginAction _loginAction;
        protected static HomeAction _homeAction;
        protected static InboxDetailsAction _inboxDetailsAction;
        protected static InboxFilterAction _inboxFilterAction;
        protected static InboxKpisAction _inboxKpiAction;
        protected static InboxChartAction _inboxChartAction;
        protected static InboxStoryboardAction _inboxStoryboardAction;
        protected static EwmGoodsReceiptAction _ewmGoodsReceiptAction;
        protected static EwmReturnToSupplierAction _ewmReturnToSupplierAction;
        protected static EwmBinToBinMovementAction _ewmBinToBinMovementAction;
        protected static EwmPhysicalInventoryAction _ewmPhysicalInventoryAction;
        protected static EwmInboundDeliveryAction _ewmInboundDeliveryAction;
        #endregion

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void LaunchUWPApp(TestContext context)
        {
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

                //Creating the TestResults CSV File if not present
                _helper.CheckFileExists(Path.Combine(logsFolderPath, testResultsLogFileName));

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
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
            finally
            {
                LogInfo("Assembly Initialize finished");
            }
        }

        [TestInitialize]
        public void TestSetUp()
        {
            try
            {
                testTimer = new Stopwatch();
                testTimer.Start();

                LogInfo("Test Initialize Started");
                LogInfo($"{TestContext.TestName} Started");

                //Load the Desired Capbilities and Launch the Application
                LaunchApp(MobPlatform, DeviceType.RealDevice.ToString(), TestContext, cloudAutomation);

                #region Actions Action Objects
                _loginAction = new LoginAction(_session);
                _homeAction = new HomeAction(_session);
                _inboxDetailsAction = new InboxDetailsAction(_session);
                _inboxFilterAction = new InboxFilterAction(_session);
                _inboxKpiAction = new InboxKpisAction(_session);
                _inboxChartAction = new InboxChartAction(_session);
                _inboxStoryboardAction = new InboxStoryboardAction(_session);
                _ewmGoodsReceiptAction = new EwmGoodsReceiptAction(_session);
                _ewmReturnToSupplierAction = new EwmReturnToSupplierAction(_session);
                _ewmBinToBinMovementAction = new EwmBinToBinMovementAction(_session);
                _ewmPhysicalInventoryAction = new EwmPhysicalInventoryAction(_session);
                _ewmInboundDeliveryAction = new EwmInboundDeliveryAction(_session);
                #endregion

                _loginAction.LoginToWD();
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
        public void TestCleanUp()
        {
            try
            {
                LogInfo("Test Cleanup Started");

                //Saving the TestResults to ResultTable
                ResultTable resultsTable = SaveTestResults(TestContext);

                //Logging TestResults to TestResults.CSV
                WriteTestResultToCSV(resultsTable);

                _session.Quit();

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
        [AssemblyCleanup]
        public static void CleanupApp()
        {
            try
            {
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

        #region Launching Android and IOS App

        public static void LaunchApp(string environment, string deviceType, TestContext context, bool browserStackCloud = false)
        {
            if (browserStackCloud)
            {
                LogInfo("Started to load the Browser Stack Desired Capabilities");
                LoadBrowserStackDesiredCapabilities(context);
                LogInfo("Finished loading of Browser Stack Desired Capabilities");

                LogInfo("Started Local tunnelling");
                browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                        new KeyValuePair<string, string>("key", browserstackPassword)
                    };
                browserStackLocal.start(bsLocalArgs);

                if (MobPlatform.ToLower().Equals(MobileDevicePlatform.IOS.ToString().ToLower()))
                {
                    LogInfo("Started WD IOS App");
                    _session = new IOSDriver<AppiumWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), desiredCapabilities);
                }
                else
                {
                    LogInfo("Started WD Android App");
                    _session = new AndroidDriver<AppiumWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), desiredCapabilities);
                }
            }
            else
            {
                if (environment.ToLower().Equals("ios"))
                {
                    if (deviceType.ToLower().Equals("simulator"))
                    {
                        LoadIOSSimulatorDC();
                    }
                    else if (deviceType.ToLower().Equals("realdevice"))
                    {
                        LoadIphoneDC();
                    }
                    else
                    {
                        Console.WriteLine("Device type mentioned for ios platform not found.");
                        throw new Exception("Device type mentioned for ios platform not found.");
                    }
                    _session = new IOSDriver<AppiumWebElement>(new Uri(CommonTestSettings.AppiumServerUrl), desiredCapabilities);
                }
                else if (environment.ToLower().Equals("android"))
                {
                    if (deviceType.ToLower().Equals("emulator"))
                    {
                        LoadAndroidEmulatorDC();
                    }
                    else if (deviceType.ToLower().Equals("realdevice"))
                    {
                        LoadAndroidDC();
                    }
                    else
                    {
                        Console.WriteLine("Device type mentioned for android platform not found.");
                        throw new Exception("Device type mentioned for android platform not found.");
                    }
                    _session = new AndroidDriver<AppiumWebElement>(new Uri(CommonTestSettings.AppiumServerUrl), desiredCapabilities);
                }
                else
                {
                    Console.WriteLine("Environment mentioned not found.");
                    throw new Exception("Environment mentioned not found.");
                }
            }

            Assert.IsNotNull(_session, "Error in launching the WD App");

            _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            WaitForMoment(5.5);
        }

        #endregion

        #region Starting Appium Server

        public static void StartingAppiumServer()
        {
            AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder()
                .UsingAnyFreePort()
                .WithAppiumJS(new System.IO.FileInfo(@"C:\Program Files\Appium\resources\app\node_modules\appium\build\lib\main.js"));

            appiumLocalService = appiumServiceBuilder.Build();
            if (!appiumLocalService.IsRunning)
                appiumLocalService.Start();
        }

        #endregion

        #region Load DesiredCapabilities

        public static void LoadBrowserStackDesiredCapabilities(TestContext context)
        {
            try
            {
                if (cloudAutomation && MobPlatform.ToLower().Equals(MobileDevicePlatform.IOS.ToString().ToLower()))
                {
                    //Initializing the IOS DC for Browser Stack
                    localTunneling = context.Properties["LocalTunneling"].ToString();
                    automationName = context.Properties["AutomationName"].ToString();
                    projectName = context.Properties["Project"].ToString();
                    buildName = context.Properties["Build"].ToString();
                    testName = context.Properties["TestName"].ToString();
                    platformVersion = context.Properties["PlatformVersion"].ToString();
                    deviceName = context.Properties["DeviceName"].ToString();
                    newCommandTimeout = context.Properties["NewCommandTimeout"].ToString();

                    desiredCapabilities = new AppiumOptions();
                    desiredCapabilities.AddAdditionalCapability("browserstack.user", browserstackUserName);
                    desiredCapabilities.AddAdditionalCapability("browserstack.key", browserstackPassword);
                    desiredCapabilities.AddAdditionalCapability("app", appURL);
                    desiredCapabilities.AddAdditionalCapability("device", deviceName);
                    desiredCapabilities.AddAdditionalCapability("os_version", platformVersion);
                    desiredCapabilities.AddAdditionalCapability("browserstack.local", localTunneling);
                    desiredCapabilities.PlatformName = "iOS";
                    desiredCapabilities.AddAdditionalCapability("project", projectName);
                    desiredCapabilities.AddAdditionalCapability("build", buildName);
                    desiredCapabilities.AddAdditionalCapability("name", testName);
                    desiredCapabilities.AddAdditionalCapability("automationName", automationName);
                    desiredCapabilities.AddAdditionalCapability("browserstack.idleTimeout", 120);
                    desiredCapabilities.AddAdditionalCapability("browserstack.acceptInsecureCerts", "true");
                }
                else
                {
                    //Initializing the Android DC for Browser Stack
                    localTunneling = context.Properties["LocalTunneling"].ToString();
                    automationName = context.Properties["AutomationName"].ToString();
                    projectName = context.Properties["Project"].ToString();
                    buildName = context.Properties["Build"].ToString();
                    testName = context.Properties["TestName"].ToString();
                    platformVersion = context.Properties["PlatformVersion"].ToString();
                    deviceName = context.Properties["DeviceName"].ToString();
                    newCommandTimeout = context.Properties["NewCommandTimeout"].ToString();

                    desiredCapabilities = new AppiumOptions();
                    desiredCapabilities.AddAdditionalCapability("browserstack.user", browserstackUserName);
                    desiredCapabilities.AddAdditionalCapability("browserstack.key", browserstackPassword);
                    desiredCapabilities.AddAdditionalCapability("app", appURL);
                    desiredCapabilities.AddAdditionalCapability("device", deviceName);
                    desiredCapabilities.AddAdditionalCapability("os_version", platformVersion);
                    desiredCapabilities.AddAdditionalCapability("browserstack.local", localTunneling);
                    desiredCapabilities.PlatformName = "Android";
                    desiredCapabilities.AddAdditionalCapability("project", projectName);
                    desiredCapabilities.AddAdditionalCapability("build", buildName);
                    desiredCapabilities.AddAdditionalCapability("name", testName);
                    desiredCapabilities.AddAdditionalCapability("automationName", automationName);
                }
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }

        #region Emulator & Simulators
        public static void LoadAndroidEmulatorDC()
        {
            desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeout);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
        }
        public static void LoadIOSSimulatorDC()
        {
            desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeout);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.Udid, udid);
            desiredCapabilities.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, bundleId);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, automationName);
        }
        #endregion

        #region Real Device
        public static void LoadAndroidDC()
        {
            desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeout);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            desiredCapabilities.AddAdditionalCapability("noReset", "true");
        }
        public static void LoadIphoneDC()
        {
            desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeout);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.Udid, udid);
            desiredCapabilities.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, bundleId);
            desiredCapabilities.AddAdditionalCapability(IOSMobileCapabilityType.AppName, appName);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, automationName);
        }
        #endregion

        #region Load Pipeline Variables
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
        #endregion
        #endregion

        #region Waiters
        public static void WaitForMoment(int delay)
        {
            //Thread.Sleep(delay * 1000);
        }
        public static void WaitForMoment(double delay)
        {
            Thread.Sleep(Convert.ToInt32(delay * 1000));
        }
        #endregion

        #region Parsing Test Results
        public void CaptureLogs(Exception ex)
        {
            testErrorMessage = OptimiseErrorDescription(ex.Message);
            LogError($"{ex.Message} : {ex.StackTrace}");
            CaptureScreenShot(_session, TestContext.TestName);
            TestContext.AddResultFile(screenshotFileName);
        }
        public ResultTable SaveTestResults(TestContext testContext)
        {
            // Getting the TC Description
            object testDescriptionObj = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            string testDescription = testDescriptionObj?.GetType().GetProperty("Description").GetValue(testDescriptionObj, null).ToString();

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                       testTimer.Elapsed.Hours, testTimer.Elapsed.Minutes, testTimer.Elapsed.Seconds);

            // Writing Test Result Data To CSV File
            string currentDataRow = TestContext.DataRow?.Table.Rows.IndexOf(TestContext.DataRow).ToString();

            return new ResultTable(
                        testDescription + testContext.TestName + " (DataRow " + currentDataRow + ")",
                        testContext.CurrentTestOutcome.ToString(),
                        elapsedTime,
                        Regex.Replace(testErrorMessage, @"\r\n?|\n|,", String.Empty),
                        screenshotFileName
                        );
        }
        public string OptimiseErrorDescription(string actualMessage)
        {
            string errorMessage = string.Empty;

            if (actualMessage.ToLower().Contains("application window got closed"))
            {
                errorMessage = "Description: Application has got closed for one of the user action.";
            }
            else if (actualMessage.ToLower().Contains("elements not found with the xpath"))
            {
                errorMessage = "Description: FindByXPath method can’t find the element in the current Page using the following XPath. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("elements not found with the accessibilityid"))
            {
                errorMessage = "Description: FindByAutomationId method can’t find the element in the current Page using the following Id. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("assert.fail failed"))
            {
                errorMessage = "Description: TestCase got failed because with one of the test assertion step. " + actualMessage;
            }
            else if (actualMessage.ToLower().Contains("assert.istrue failed"))
            {
                errorMessage = "Description: TestCase got failed because with one of the test assertion step. " + actualMessage;
            }
            else
            {
                errorMessage = "Failure might be of sporadic one. " + actualMessage;
            }
            return errorMessage;
        }
        #endregion

        #region Reading UserName and Password from Runsetting Variables
        public static void ReadUserEmailIDandPassword(TestContext context)
        {
            LogInfo("Reading of the UserEmailID and Password fields Started");

            if (string.IsNullOrEmpty(userName) | string.IsNullOrEmpty(password))
            {
                userName = context.Properties["TestUser1EmailId"].ToString();
                string encryptedPassword = context.Properties["TestUser1Password"].ToString();
                password = CommonTestSettings.Decrypt(encryptedPassword);
            }

            LogInfo("Reading of the UserEmailID and Password fields finished");
        }
        #endregion
    }
}
