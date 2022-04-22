using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidGlobalSearchImage => FindElements(Locators.AccessibilityId.ToString() + ":SearchIcon");
        public IList<AppiumWebElement> AndroidEnterInboxNameTextField => FindElements(Locators.AccessibilityId.ToString() + ":InboxPicker Input Field");
        public IList<AppiumWebElement> AndroidSearchForRecordsTextField => FindElements(Locators.XPath.ToString() + "://android.widget.EditText[contains(@text,'Search for records')]");
        public IList<AppiumWebElement> AndroidGlobalSearchButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@text='SEARCH']");
        public IList<AppiumWebElement> AndroidGetInboxName => FindElements(Locators.AccessibilityId.ToString() + ":InboxName");
        public IList<AppiumWebElement> AndroidInboxNameDropDown => FindElements(Locators.XPath.ToString() + "://*[@content-desc='InboxPicker Dropdown Button']");
        public IList<AppiumWebElement> AndroidInboxListView => FindElements(Locators.XPath.ToString() + ":(//android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.ImageView)[4]");
        public IList<AppiumWebElement> AndroidInboxSearchTextfield => FindElements(Locators.AccessibilityId.ToString() + ":searchEntry");
        public IList<AppiumWebElement> AndroidInboxSearchButton => FindElements(Locators.AccessibilityId.ToString() + ":SearchButton");
        public IList<AppiumWebElement> SelectInbox(string inboxName)
        {
            return FindElements(Locators.Name.ToString() + $":{inboxName}");
        }
        public IList<AppiumWebElement> SelectInboxFromInboxList(string inboxName)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.TextView[@content-desc='InboxName' and @text='{inboxName}']");
        }

        public IList<AppiumWebElement> IOSInboxListView => FindElements(Locators.XPath.ToString() + ":(//XCUIElementTypeTabBar/XCUIElementTypeButton)[4]");
        public IList<AppiumWebElement> IOSGlobalSearchImage => FindElements(Locators.AccessibilityId.ToString() + ":SearchIcon");
        public IList<AppiumWebElement> IOSInboxSearchTextfield => FindElements(Locators.AccessibilityId.ToString() + ":searchEntry");
        public IList<AppiumWebElement> IOSEnterInboxNameTextField => FindElements(Locators.AccessibilityId.ToString() + ":InboxPicker Input Field");
        public IList<AppiumWebElement> IOSSelectInboxFromAutoPopulatedList(string inboxName)
        {
            return FindElements(Locators.XPath.ToString() + $"://*[contains(@name,'{inboxName}')]");
        }
        public IList<AppiumWebElement> IOSInboxSearchButton => FindElements(Locators.XPath.ToString() + "://XCUIElementTypeButton[@name='Search']");
    }
}
