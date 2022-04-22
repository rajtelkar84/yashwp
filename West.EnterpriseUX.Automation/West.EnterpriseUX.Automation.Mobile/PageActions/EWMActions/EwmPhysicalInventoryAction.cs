using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class EwmPhysicalInventoryAction : BaseAction
    {
        private readonly EwmPhysicalInventoryPage _pageInstance;

        public EwmPhysicalInventoryAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new EwmPhysicalInventoryPage(_driver);
        }
        public void ClickOnProceedButton()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                ClickOnMobileElement(_pageInstance.AndroidProceedButton);
                WaitForLoaderToVanish();
            }
        }
        public void SelectBinsCheckbox(int rowNumber=0)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> binsCheckboxes = _pageInstance.AndroidBinsCheckboxOptions;

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
                Assert.IsTrue(actualDailogMessage.Contains(message.ToLower()), "Physical Inventory generating Document Id is not successfull");
            }
        }
    }
}
