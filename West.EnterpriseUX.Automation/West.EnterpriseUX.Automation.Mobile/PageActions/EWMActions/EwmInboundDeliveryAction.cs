using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class EwmInboundDeliveryAction : BaseAction
    {
        private readonly EwmInboundDeliveryPage _pageInstance;

        public EwmInboundDeliveryAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new EwmInboundDeliveryPage(_driver);
        }
        public void EnterPurchaseOrder(string purchaseOrderNumber)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidPurchaseOrderTextbox[0].SendKeys(purchaseOrderNumber);
                WaitForLoaderToVanish();
            }
        }
        public void EnterQunatity(string quantity)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _pageInstance.AndroidQuantityTextbox[0].Clear();
                _pageInstance.AndroidQuantityTextbox[0].SendKeys(quantity);
                WaitForLoaderToVanish();
            }
        }
        public void ClickOnProceedButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidProceedButton);
                WaitForLoaderToVanish();
            }
        }
        public void ClickOnPrepareBatchesButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidPrepareBatchesButton);
                WaitForLoaderToVanish();
            }
        }
        public void ClickOnSaveButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                HandleEnteringDatePopUp();
                ClickOnMobileElement(_pageInstance.AndroidSaveButton);
                WaitForLoaderToVanish();
            }
        }
        public void SelectDeliveryCheckbox(int rowNumber=0)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> binsCheckboxes = _pageInstance.AndroidDeliveryCheckbox;

                if(binsCheckboxes.Count>0)
                {
                    ClickOnMobileElement(binsCheckboxes[rowNumber]);
                }
                else
                {
                    Console.WriteLine("No Bin Option are available for posting the Document Id");
                }
            }
        }
        public void ClickOnPostButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidPostButton);
                WaitForLoaderToVanish();
                _pageInstance.ConfirmationPopUpYes.Click();
            }
        }
        public void ClickOnOKButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                if (_pageInstance.AndroidConfirmationOKButton.Count > 0)
                {
                    string dailogMessage = _pageInstance.AndroidOKPopUpMessage[0].Text;
                    ClickOnMobileElement(_pageInstance.AndroidConfirmationOKButton);
                    Assert.Fail($"Physical Inventory is not successfull due to follwing reason: {dailogMessage}");
                }
                else
                {
                    Console.WriteLine("No Error message in the Physical Inventory action");
                }
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }
        public void VerifyDialogMessage(string message)
        {
            ClickOnOKButton();
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                string actualDailogMessage = _pageInstance.AndroidPostDailog[0]?.Text.Trim().ToLower();
                Assert.IsTrue(actualDailogMessage.Contains(message.ToLower()), "Inbound Delivery Creating Document Id is not successfull");
            }
        }
        public void HandleEnteringDatePopUp()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> datePopUp = _pageInstance.AndroidDatePopUpButton;
                if(datePopUp.Count>0)
                {
                    ClickOnMobileElement(datePopUp);
                }
            }
        }
    }
}
