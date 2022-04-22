using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class InboxDetailsPage : BasePage
    {
        public InboxDetailsPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidContextMenuOption => FindElements(Locators.XPath.ToString() + "://android.widget.ImageButton[@content-desc='moreOptions']");
        public IList<AppiumWebElement> AndroidFilterOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='Filter']");
        public IList<AppiumWebElement> AndroidSaveButton => FindElements(Locators.AccessibilityId.ToString() + ":Save");
        public IList<AppiumWebElement> AndroidLabelSavePopUp => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='Label Name']");
        public IList<AppiumWebElement> AndroidDashboardLabelEdit => FindElements(Locators.XPath.ToString() + ":(//android.widget.EditText)[1]");
        public IList<AppiumWebElement> AndroidDashboardLabelSaveButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@text='SAVE']");
        public IList<AppiumWebElement> AndroidSearchOption => FindElements(Locators.XPath.ToString() + "://android.widget.ImageView[@content-desc='RefreshData']//preceding-sibling::android.widget.ImageView");
        public IList<AppiumWebElement> AndroidSearchTextBox => FindElements(Locators.AccessibilityId.ToString() + ":searchEntry");
        public IList<AppiumWebElement> AndroidSearchButton => FindElements(Locators.AccessibilityId.ToString() + ":SearchButton");
        public IList<AppiumWebElement> AndroidContextButton => FindElements(Locators.AccessibilityId.ToString() + ":DetailAction");
        public IList<AppiumWebElement> SelectDataByRowNumber(int rowNumber)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.ListView[@content-desc='ExpandableListViewID']/android.widget.LinearLayout[{rowNumber}]");
        }
        public IList<AppiumWebElement> SelectActionOption(string actionText)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.TextView[contains(@text,'{actionText}')]");
        }
    }
}
