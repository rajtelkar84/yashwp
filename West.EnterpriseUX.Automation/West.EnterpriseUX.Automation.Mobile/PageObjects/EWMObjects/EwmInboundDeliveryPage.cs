using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class EwmInboundDeliveryPage : BasePage
    {
        public EwmInboundDeliveryPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }
        public IList<AppiumWebElement> AndroidPurchaseOrderTextbox => FindElements(Locators.AccessibilityId.ToString() + ":InboundDCPurchaseOrderPicker Input Field");
        public IList<AppiumWebElement> AndroidProceedButton => FindElements(Locators.AccessibilityId.ToString() + ":InboundDCProceed ");
        public IList<AppiumWebElement> AndroidPrepareBatchesButton => FindElements(Locators.AccessibilityId.ToString() + ":InboundDCSplitBatchCommand");
        public IList<AppiumWebElement> AndroidQuantityTextbox => FindElements(Locators.AccessibilityId.ToString() + ":InboundDCQuantDist");
        public IList<AppiumWebElement> AndroidSaveButton => FindElements(Locators.AccessibilityId.ToString() + ":InboundDCSave");
        public IList<AppiumWebElement> AndroidDeliveryCheckbox => FindElements(Locators.XPath.ToString() + "://android.widget.CompoundButton[@content-desc='InboundDCCheckBox']");
        public IList<AppiumWebElement> AndroidPostButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@text='POST']");
        public IList<AppiumWebElement> AndroidDatePopUpButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@content-desc='okButton']");
    }
}
