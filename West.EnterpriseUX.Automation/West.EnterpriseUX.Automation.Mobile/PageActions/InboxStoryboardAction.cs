using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class InboxStoryboardAction : BaseAction
    {
        private readonly InboxStoryboardPage _pageInstance;

        public InboxStoryboardAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new InboxStoryboardPage(_driver);
        }

        public void ClickOnCreateStoryboard()
        {
            ClickOnMobileElement(_pageInstance.AndroidCreateStoryboard);
        }
        public void EnterStoryboardName(string storyboardName)
        {
            _pageInstance.AndroidStoryboardNameTextfield[0].SendKeys(storyboardName);
        }
        public void ClickOnImportCharts()
        {
            ClickOnMobileElement(_pageInstance.AndroidImportChartOption);
        }
        public void ClickOnImportKPIs()
        {
            ClickOnMobileElement(_pageInstance.AndroidImportKPIOption);
            WaitForLoadingToDisappear();
        }
        public void ClickOnCreateChart()
        {
            ClickOnMobileElement(_pageInstance.AndroidCreateChartOption);
        }
        public void ClickOnCreateKPI()
        {
            ClickOnMobileElement(_pageInstance.AndroidCreateKPIOption);
        }
        public void SelectTemplatesCheckboxes()
        {
            IList<AppiumWebElement> allTemplates = _pageInstance.AndroidChartsKPIsImportCheckboxes;
            if(allTemplates.Count>0)
            {
                WaitForMoment(1);
                ClickOnMobileElement(allTemplates);
            }
        }
        public void ClickOnImportButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidImportButton);
        }
        public void ClickOnSaveStoryboard()
        {
            ClickOnMobileElement(_pageInstance.AndroidStoryboardSaveButton);
            WaitForLoadingToDisappear();
        }
    }
}
