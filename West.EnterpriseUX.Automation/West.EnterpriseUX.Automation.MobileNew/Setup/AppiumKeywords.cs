﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

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

        public void ScrollUp()
        {
            double x = _driver.Manage().Window.Size.Width * 0.5;
            double y1 = _driver.Manage().Window.Size.Height * 0.75;
            double y2 = _driver.Manage().Window.Size.Height * 0.25;

            (new TouchAction(_driver))
                    .Press(x, y1)
                    .Wait(1000)
                    .MoveTo(x, y2)
                    .Release()
                    .Perform();
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
