using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class InboxChartAction : BaseAction
    {
        private readonly InboxChartPage _pageInstance;

        public InboxChartAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new InboxChartPage(_driver);
        }

        public void ClickOnCreateChartImage()
        {
            ClickOnMobileElement(_pageInstance.AndroidAddChartImage);
        }
        public void ClickOnUserCreatedChartsTab()
        {
            ClickOnMobileElement(_pageInstance.AndroidUserCreatedTab[0]);
        }
        public void EnterChartName(string chartName)
        {
            _pageInstance.AndroidChartNameTextfield[0].SendKeys(chartName);
        }
        public void SelectMeasuresValue(string measureValue)
        {

            ClickOnMobileElement(_pageInstance.AndroidMesaureDropdown);
            WaitForMoment(1);
            _pageInstance.AndroidMesaureTextfield[0].SendKeys(measureValue);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidMesaureTextfield);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidShowPreviewButton);
        }
        public void SelectDimensionsValue(string dimensionsValue)
        {
            ClickOnMobileElement(_pageInstance.AndroidDimensionDropdown);
            WaitForMoment(1);
            _pageInstance.AndroidDimensionTextfield[0].SendKeys(dimensionsValue);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidDimensionTextfield);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidShowPreviewButton);
        }
        public void ClickOnSaveChart()
        {
            ClickOnMobileElement(_pageInstance.AndroidCreateChartButton);
            WaitForLoadingToDisappear();
        }
    }
}
