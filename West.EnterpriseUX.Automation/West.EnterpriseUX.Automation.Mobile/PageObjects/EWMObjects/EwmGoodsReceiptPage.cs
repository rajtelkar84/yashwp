using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class EwmGoodsReceiptPage:BasePage
    {
        public EwmGoodsReceiptPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidGoodsPostButton => FindElements(Locators.AccessibilityId.ToString() + ":GoodsReceiptPostButton");
        public IList<AppiumWebElement> AndroidGoodsReverseButton => FindElements(Locators.AccessibilityId.ToString() + ":GRReversalPostButton");
        public IList<AppiumWebElement> AndroidPostDailogOkButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@content-desc='okButton']");
    }
}
