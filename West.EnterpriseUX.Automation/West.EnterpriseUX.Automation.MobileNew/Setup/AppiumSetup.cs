using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
using System.Diagnostics;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class AppiumSetup
    {
        private AppiumLocalService service;
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

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void LoadProperties(TestContext context)
        {
            platformName = context.Properties["PlatformName"].ToString();
            deviceName = context.Properties["DeviceName"].ToString();
            appPackage = context.Properties["AppPackage"].ToString();
            appActivity = context.Properties["AppActivity"].ToString();
            noReset = Convert.ToBoolean(context.Properties["NoReset"].ToString());

            if (extent == null)
            {
                extent = new ExtentReports();
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(@"C:\Users\patilg\OneDrive - West Pharmaceutical Services, Inc\Desktop\ExtentReports\");

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
            AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder()
                 .UsingAnyFreePort()
                 .WithAppiumJS(new System.IO.FileInfo(@"C:\Users\patilg\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"));

            service = appiumServiceBuilder.Build();

            if (!service.IsRunning)
                service.Start();

            if (platformName.ToLower().Equals("android"))
            {
                appiumOptions = new AppiumOptions();

                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, appPackage);
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, appActivity);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);

                driver = new AndroidDriver<IWebElement>(service, appiumOptions);
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
