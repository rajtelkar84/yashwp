using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class EwmReturnToSupplierPage : BasePage
    {
        public EwmReturnToSupplierPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }

        public IList<AppiumWebElement> AndroidReturnQunatity => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Return Quantity')]/..//android.widget.EditText");
        public IList<AppiumWebElement> AndroidSelectFirstRecord => FindElements(Locators.XPath.ToString() + ":(//android.view.ViewGroup/android.widget.TextView)[2]");
        public IList<AppiumWebElement> AndroidStockType => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Stock Type')]/..//android.view.ViewGroup/android.widget.TextView");
        public IList<AppiumWebElement> AndroidReasonCode => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Reason Code')]/..//android.view.ViewGroup/android.widget.TextView");
        public IList<AppiumWebElement> AndroidPostButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[contains(@text,'POST')]");
    }
}
