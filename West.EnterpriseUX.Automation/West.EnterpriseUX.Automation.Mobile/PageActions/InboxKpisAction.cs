using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class InboxKpisAction : BaseAction
    {
        private readonly InboxKpisPage _pageInstance;

        public InboxKpisAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new InboxKpisPage(_driver);
        }
        public void SelectUserCreatedTab()
        {
            _pageInstance.AndroidUserCreatedTab[0].Click();
        }
        public void ClickOnKPIEditOption(string kpiName)
        {
            ClickOnMobileElement(_pageInstance.SelectKPIEdit(kpiName));
            _pageInstance.AndroidKPIEditOption[0].Click();
        }
        public void EnterKPITemplateName(string kpiTemplateName)
        {
            _pageInstance.AndroidKPITemplateName[0].SendKeys(kpiTemplateName);
        }
        public void SelectKPIProperty(string propertyName)
        {
            ClickOnMobileElement(_pageInstance.AndroidKPIPropertyDropDown);
            WaitForMoment(1);
            _pageInstance.AndroidKPIPropertyTextField[0].SendKeys(propertyName);
        }
        public void ClickOnKPITemplateSave()
        {
            ClickOnMobileElement(_pageInstance.AndroidKPITemplateSave);
            WaitForLoadingToDisappear();
        }
    }
}
