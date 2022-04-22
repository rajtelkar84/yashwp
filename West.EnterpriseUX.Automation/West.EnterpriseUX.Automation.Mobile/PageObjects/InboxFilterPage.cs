using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class InboxFilterPage : BasePage
    {
        public InboxFilterPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidAddFilterButton => FindElements(Locators.AccessibilityId.ToString() + ":AddNewFilter");
        public IList<AppiumWebElement> AndroidFilterFieldText => FindElements(Locators.AccessibilityId.ToString() + ":FilterFieldPicker Input Field");
        public IList<AppiumWebElement> AndroidFilterOperatorText => FindElements(Locators.XPath.ToString() + "://android.view.ViewGroup[@content-desc='FilterOperatorPicker_Container']/android.widget.Button");
        public IList<AppiumWebElement> AndroidOKButton => FindElements(Locators.Id.ToString() + ":android:id/button1");
        public IList<AppiumWebElement> AndroidApplyButton => FindElements(Locators.AccessibilityId.ToString() + ":ApplyFilter");
        public IList<AppiumWebElement> SelectFilterOperatorOption(string option)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.EditText[@text='{option}']");
        }
    }
}
