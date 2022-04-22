using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class BaseAction : BaseTest
    {
        public static AppiumDriver<AppiumWebElement> _driver;
        readonly TouchAction touchAction;
        private readonly BasePage _pageInstance;

        public BaseAction(AppiumDriver<AppiumWebElement> driver)
        {
            _pageInstance = new BasePage(_driver);
            _driver = driver;
            touchAction = new TouchAction(_driver);
        }

        public void HorizontalSwipeLeft()
        {
            int height = _driver.Manage().Window.Size.Height;
            int width = _driver.Manage().Window.Size.Width;
            int y = (int)(height * 0.20);
            int startx = (int)(width * 0.85);
            int endx = (int)(width * 0.01);
            touchAction.Press(startx, y).Wait(1000).MoveTo(endx, y).Release().Perform();
        }
        public void HorizontalSwipeRight()
        {
            int height = _driver.Manage().Window.Size.Height;
            int width = _driver.Manage().Window.Size.Width;
            int y = (int)(height * 0.20);
            int startx = (int)(width * 0.01);
            int endx = (int)(width * 0.85);
            touchAction.Press(startx, y).Wait(500).MoveTo(endx, y).Release().Perform();
        }
        public void VerticalSwipeUp()
        {
            int height = _driver.Manage().Window.Size.Height;
            int width = _driver.Manage().Window.Size.Width;
            int x = width / 2;
            int starty = (int)(height * 0.850);
            int endy = (int)(height * 0.30);
            touchAction.Press(x, starty).Wait(500).MoveTo(x, endy).Release().Perform();
        }
        public void VerticalSwipeDown()
        {
            int height = _driver.Manage().Window.Size.Height;
            int width = _driver.Manage().Window.Size.Width;
            int x = width / 2;
            int starty = (int)(height * 0.30);
            int endy = (int)(height * 0.70);
            touchAction.Press(x, starty).Wait(1000).MoveTo(x, endy).Release().Perform();
        }
        public void ClickOnMobileElement(IList<AppiumWebElement> elements)
        {
            if(elements.Count>0)
            {
                elements[0].Click();
            }
            else
            {
                Console.WriteLine("List contains no elements to perform the click operation");
            }
        }
        public void ClickOnMobileElement(AppiumWebElement element)
        {
            if (element!=null)
            {
                element.Click();
            }
            else
            {
                Console.WriteLine("Element to perform the click operation is null");
            }
        }
        public void WaitForLoaderToVanish()
        {
            try
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                while (_pageInstance.AndroidLoaderText?.Count>0)
                {
                    WaitForMoment(2);
                }
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message+ ex.StackTrace);
            }
        }
        public void WaitForLoadingToDisappear(string loadingText = null)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.WaitForAndroidLoaderToDisappear();
            }
            else
            {
                _pageInstance.WaitForIOSLoaderToDisappear();
            }
                
        }
        public void WaitForProgressBarToDisappear(string loadingText = null)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.WaitForAndroidProgressBarToDisappear();
            }
            else
            {
                _pageInstance.WaitForIOSLoaderToDisappear();
            }

        }

    }
}
