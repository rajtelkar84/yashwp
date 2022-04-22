using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class InboxChartPage : BasePage
    {
        public InboxChartPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidAddChartImage => FindElements(Locators.AccessibilityId.ToString() + ":addChartImage");
        public IList<AppiumWebElement> AndroidMyChartsTab => FindElements(Locators.XPath.ToString() + "://android.view.View[@content-desc='My Charts']");
        public IList<AppiumWebElement> AndroidChartNameTextfield => FindElements(Locators.AccessibilityId.ToString() + ":ChartName");
        public IList<AppiumWebElement> AndroidMesaureDropdown => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Measures')]/../../../..//android.widget.ImageView[@content-desc=' Dropdown Button']");
        public IList<AppiumWebElement> AndroidMesaureTextfield => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Measures')]/../../../..//android.widget.EditText[@content-desc=' Input Field']");
        public IList<AppiumWebElement> AndroidDimensionDropdown => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Dimensions')]/../../../..//android.widget.ImageView[@content-desc=' Dropdown Button']");
        public IList<AppiumWebElement> AndroidDimensionTextfield => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Dimensions')]/../../../..//android.widget.EditText[@content-desc=' Input Field']");
        public IList<AppiumWebElement> AndroidShowPreviewButton => FindElements(Locators.AccessibilityId.ToString() + ":ShowPreview");
        public IList<AppiumWebElement> AndroidCreateChartButton => FindElements(Locators.AccessibilityId.ToString() + ":Create");
      
    }
}
