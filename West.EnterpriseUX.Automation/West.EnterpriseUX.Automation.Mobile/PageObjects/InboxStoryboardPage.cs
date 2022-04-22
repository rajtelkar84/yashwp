using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class InboxStoryboardPage : BasePage
    {
        public InboxStoryboardPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidCreateStoryboard => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Create storyboard')]");
        public IList<AppiumWebElement> AndroidStoryboardNameTextfield => FindElements(Locators.AccessibilityId.ToString() + ":StoryNameEntryAndroid");
        public IList<AppiumWebElement> AndroidImportChartOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Import Chart')]");
        public IList<AppiumWebElement> AndroidImportKPIOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Import KPI')]");
        public IList<AppiumWebElement> AndroidCreateChartOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='Chart']");
        public IList<AppiumWebElement> AndroidCreateKPIOption => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='KPIs']");
        public IList<AppiumWebElement> AndroidChartsKPIsImportCheckboxes => FindElements(Locators.XPath.ToString() + "://android.widget.ImageView[@content-desc='Import']");
        public IList<AppiumWebElement> AndroidImportButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@text='IMPORT']");
        public IList<AppiumWebElement> AndroidStoryboardSaveButton => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[@text='Save']");
    }
}
