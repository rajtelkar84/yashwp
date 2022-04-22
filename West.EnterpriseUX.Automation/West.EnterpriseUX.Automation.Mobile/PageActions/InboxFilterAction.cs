using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class InboxFilterAction : BaseAction
    {
        private readonly InboxFilterPage _pageInstance;

        public InboxFilterAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new InboxFilterPage(_driver);
        }

        public void ClickOnAddFilterButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidAddFilterButton);
        }
        public void EnterFilterFieldValue(string value)
        {
            _pageInstance.AndroidFilterFieldText[0].SendKeys(value);
            ClickOnMobileElement(_pageInstance.AndroidFilterFieldText);
            var tt = _pageInstance.SelectFilterOperatorOption(value);
            tt[0].Click();
        }
        public void ClickOnFilterOperatorTextBox()
        {
            ClickOnMobileElement(_pageInstance.AndroidFilterOperatorText);
        }
        public void SelectFilterOperatorText(string value)
        {
            ClickOnMobileElement(_pageInstance.SelectFilterOperatorOption(value));
        }
        public void ClickOnOkButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidOKButton);
        }
        public void ClickOnApplyButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidApplyButton);
        }
        public void ClickOnEnter()
        {
            try
            {
                ((AndroidDriver<AppiumWebElement>)_session).PressKeyCode(new KeyEvent(AndroidKeyCode.Keycode_PAGE_DOWN));
                ((AndroidDriver<AppiumWebElement>)_session).PressKeyCode(new KeyEvent(AndroidKeyCode.Keycode_PAGE_DOWN));
                ((AndroidDriver<AppiumWebElement>)_session).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ApplyFilter(string fieldValue, string operatorValue, string value=null)
        {
            ClickOnAddFilterButton();
            WaitForMoment(2);
            EnterFilterFieldValue(fieldValue);
            WaitForMoment(2);
            ClickOnFilterOperatorTextBox();
            WaitForMoment(2);
            SelectFilterOperatorText(operatorValue);
            WaitForMoment(2);
            ClickOnOkButton();
            WaitForMoment(2);
            ClickOnApplyButton();
            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

    }
}
