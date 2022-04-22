using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class InboxKpisPage : BasePage
    {
        public InboxKpisPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidKPITemplateName => FindElements(Locators.XPath.ToString() + "://android.widget.EditText[@text='Enter name']");
        public IList<AppiumWebElement> AndroidKPIPropertyTextField => FindElements(Locators.XPath.ToString() + "://android.widget.EditText[@content-desc=' Input Field']");
        public IList<AppiumWebElement> AndroidKPIPropertyDropDown => FindElements(Locators.AccessibilityId.ToString() + ": Dropdown Button");
        public IList<AppiumWebElement> AndroidKPITemplateSave => FindElements(Locators.AccessibilityId.ToString() + ":Create");
        public IList<AppiumWebElement> AndroidKPIEditOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='Edit']");
        public IList<AppiumWebElement> SelectKPIEdit(string kpiName)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.TextView[@text='{kpiName}']/../../../../..//android.widget.ImageView[@content-desc='More']");
        }
    }
}
