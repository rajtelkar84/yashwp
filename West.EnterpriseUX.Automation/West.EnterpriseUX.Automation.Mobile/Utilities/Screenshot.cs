using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.Mobile.Utilities
{
    public class Screenshot
    {
        public static string screenshotFileName = string.Empty;
        protected Screenshot()
        {

        }
        public static void CaptureScreenShot(AppiumDriver<AppiumWebElement> _session, string testCaseName)
        {
            OpenQA.Selenium.Screenshot Screenshot = _session.GetScreenshot();
            screenshotFileName = string.Format(@"{0}\{1}.png", BaseTest.screenshotsFolderPath, testCaseName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            Screenshot.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
        }
    }
}
