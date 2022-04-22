using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class EwmBinToBinMovementAction : BaseAction
    {
        private readonly EwmBinToBinMovementPage _pageInstance;

        public EwmBinToBinMovementAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new EwmBinToBinMovementPage(_driver);
        }
        public void SelectDestinationBin()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidDestinationBin);
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
        public void EnterTransferQuantity(string quantity)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidTransferQunatity[0].Clear();
                _pageInstance.AndroidTransferQunatity[0].SendKeys(quantity);
            }
        }
        public void ClickOnPostButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidPostButton);
            }
        }
        public void ClickOnProceedButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidProceedButton);
            }
        }
        public void ClickOnOKButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                if(_pageInstance.AndroidConfirmationOKButton.Count>0)
                {
                    string dailogMessage = _pageInstance.AndroidOKPopUpMessage[0].Text;
                    ClickOnMobileElement(_pageInstance.AndroidConfirmationOKButton);
                    Assert.Fail($"Bin-To-Bin movement is not successfull due to follwing reason: {dailogMessage}");
                }
                else
                {
                    Console.WriteLine("No Error message in the Bin-To-Bin movement action");
                }
            }
        }
        public void VerifyDialogMessage(string message)
        {
            ClickOnOKButton();
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                string actualDailogMessage = _pageInstance.AndroidPostDailog[0]?.Text.Trim().ToLower();
                Assert.IsTrue(actualDailogMessage.Contains(message.ToLower()), "Post Goods Receipt is not successfull");
            }
        }
    }
}
