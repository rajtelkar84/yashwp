using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class EwmReturnToSupplierAction : BaseAction
    {
        private readonly EwmReturnToSupplierPage _pageInstance;

        public EwmReturnToSupplierAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new EwmReturnToSupplierPage(_driver);
        }
        public void EnterReturnQuantity(string quantity)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidReturnQunatity[0].SendKeys(quantity);
            }
        }
        public void SelectStockType()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidStockType);
                WaitForMoment(3);
                ClickOnMobileElement(_pageInstance.AndroidSelectFirstRecord);
            }
        }
        public void SelectReasonCode()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidReasonCode);
                WaitForMoment(3);
                ClickOnMobileElement(_pageInstance.AndroidSelectFirstRecord);
            }
        }
        public void ClickOnPostButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidPostButton);
            }
        }
    }
}
