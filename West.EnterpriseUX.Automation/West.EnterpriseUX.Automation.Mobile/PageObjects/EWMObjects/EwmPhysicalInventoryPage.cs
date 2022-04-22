using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class EwmPhysicalInventoryPage : BasePage
    {
        public EwmPhysicalInventoryPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidProceedButton => FindElements(Locators.AccessibilityId.ToString() + ":PIBindisplayProceedButon");
        public IList<AppiumWebElement> AndroidBinsCheckboxOptions => FindElements(Locators.XPath.ToString() + "://android.widget.CompoundButton[@content-desc='PIProductViewIsCheckedCheckBox']");
        public IList<AppiumWebElement> AndroidPostButton => FindElements(Locators.AccessibilityId.ToString() + ":PIBinProductPostButton");
    }
}
