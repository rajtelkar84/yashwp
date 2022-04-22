using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class EwmGoodsReceiptAction:BaseAction
    {
        private readonly EwmGoodsReceiptPage _pageInstance;

        public EwmGoodsReceiptAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new EwmGoodsReceiptPage(_driver);
        }
        public void ClickOnPostButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidGoodsPostButton[0].Click();
            }
        }
        public void ClickOnReverseButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidGoodsReverseButton[0].Click();
                WaitForMoment(1);
                _pageInstance.ConfirmationPopUpYes.Click();
            }
        }
        public void VerifyDialogMessage(string message)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                string actualDailogMessage= _pageInstance.AndroidPostDailog[0]?.Text.Trim().ToLower();
                Assert.IsTrue(actualDailogMessage.Contains(message.ToLower()), "Post Goods Receipt is not successfull");
            }
        }
        public void ClickOnDailogOkButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidPostDailogOkButton);
            }
        }
    }
}
