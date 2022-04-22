using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class EwmBinToBinMovementPage : BasePage
    {
        public EwmBinToBinMovementPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }

        public IList<AppiumWebElement> AndroidTransferQunatity => FindElements(Locators.AccessibilityId.ToString() + ":DestinationBinQuantity");
        public IList<AppiumWebElement> AndroidSelectFirstRecord => FindElements(Locators.XPath.ToString() + ":(//android.view.ViewGroup/android.widget.TextView)[2]");
        public IList<AppiumWebElement> AndroidDestinationBin => FindElements(Locators.AccessibilityId.ToString() + ":DestinationStorageBin");
        public IList<AppiumWebElement> AndroidReasonCode => FindElements(Locators.AccessibilityId.ToString() + ":DestinationReason");
        public IList<AppiumWebElement> AndroidPostButton => FindElements(Locators.AccessibilityId.ToString() + ":DestPostButton");
        public IList<AppiumWebElement> AndroidProceedButton => FindElements(Locators.XPath.ToString() + "://android.widget.Button[@resource-id='android:id/button1' and @text='PROCEED']");
       
    }
}
