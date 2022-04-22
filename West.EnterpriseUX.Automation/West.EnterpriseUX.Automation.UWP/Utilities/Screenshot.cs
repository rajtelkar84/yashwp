using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Drawing.Imaging;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public class Screenshot
    {
        public static string screenshotFileName = string.Empty;
        protected Screenshot()
        {

        }
        public static void CaptureScreenShot(WindowsDriver<WindowsElement> _session, string testCaseName)
        {
            OpenQA.Selenium.Screenshot Screenshot = _session.GetScreenshot();
            screenshotFileName = string.Format(@"{0}\{1}.png", BaseTest.screenshotsFolderPath, testCaseName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            Screenshot.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
        }
    }
}
