using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew.Setup
{
    public class AppiumKeywords
    {
        private AppiumDriver<IWebElement> _driver;
        private DefaultWait<AppiumDriver<IWebElement>> _wait;

        public AppiumKeywords(AppiumDriver<IWebElement> driver)
        {
            this._driver = driver;
        }

        public void ClickOnElement(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        public IWebElement WaitAndFindElement(By androidLocator, By iosLocator)
        {
            WaitForMomentAndIgnoreException();

            if (_driver.PlatformName.Equals("Android"))
            {
                return _driver.FindElement(androidLocator);
            }
            return _driver.FindElement(iosLocator);
        }

        public IList<IWebElement> WaitAndFindElements(By androidLocator, By iosLocator)
        {
            WaitForMomentAndIgnoreException();

            if (_driver.PlatformName.Equals("Android"))
            {
                return _driver.FindElements(androidLocator);
            }
            return _driver.FindElements(iosLocator);
        }

        private void WaitForMomentAndIgnoreException()
        {
            _wait = new DefaultWait<AppiumDriver<IWebElement>>(_driver);
            _wait.Timeout = TimeSpan.FromSeconds(30);
            _wait.IgnoreExceptionTypes(typeof(Exception));
        }

        public void Scroll()
        {
            (new TouchAction(_driver))
                    .Press(480, 900)
                    .Wait(1000)
                    .MoveTo(480, 400)
                    .Release()
                    .Perform();
        }
    }
}
