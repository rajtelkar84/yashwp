using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class InboxDetailsAction : BaseAction
    {
        private readonly InboxDetailsPage _pageInstance;

        public InboxDetailsAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new InboxDetailsPage(_driver);
        }

        public void ClickOnContextOptions()
        {
            ClickOnMobileElement(_pageInstance.AndroidContextMenuOption);
        }
        public void ClickOnFilterOption()
        {
            ClickOnMobileElement(_pageInstance.AndroidFilterOption);
        }
        public void ClickOnDashboardSaveButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidSaveButton);
        }
        public void ClickDashboardLabelName()
        {
            ClickOnMobileElement(_pageInstance.AndroidLabelSavePopUp);
        }
        public void EnterDashboardLabelName(string dashboardLabelName)
        {
            _pageInstance.AndroidDashboardLabelEdit[0].SendKeys(dashboardLabelName);
        }
        public void ClickOnPopUpDashboardSaveButton()
        {
            ClickOnMobileElement(_pageInstance.AndroidDashboardLabelSaveButton);
        }
        public void SelectAbstraction(string abstractionName)
        {
            ClickOnMobileElement(_pageInstance.SelectAbstraction(abstractionName));
            WaitForLoadingToDisappear();
        }
        public void SaveDashboardLabel(string labelName)
        {
            _inboxDetailsAction.ClickOnDashboardSaveButton();
            WaitForMoment(2);
            _inboxDetailsAction.ClickDashboardLabelName();
            WaitForMoment(2);
            _inboxDetailsAction.EnterDashboardLabelName(labelName);
            WaitForMoment(2);
            _inboxDetailsAction.ClickOnPopUpDashboardSaveButton();
        }
        public void CreateDashboardLabel(string labelName)
        {
            _inboxDetailsAction.ClickOnContextOptions();
            WaitForMoment(2);
            _inboxDetailsAction.ClickOnFilterOption();
            WaitForMoment(2);
            _inboxFilterAction.ApplyFilter("Created On", "Rolling Date");
            WaitForMoment(2);
            _inboxDetailsAction.SaveDashboardLabel(labelName);
            WaitForMoment(2);
            WaitForProgressBarToDisappear();
        }
        public void SearchTheRecordById(string salesDocumentId)
        {
            ClickOnMobileElement(_pageInstance.AndroidSearchOption);
            WaitForMoment(2);
            _pageInstance.AndroidSearchTextBox[0].SendKeys(salesDocumentId);
            WaitForMoment(2);
            ClickOnMobileElement(_pageInstance.AndroidSearchButton);
            WaitForMoment(4);
        }
        public void SelectGridRow(int rowNo=1)
        {
            ClickOnMobileElement(_pageInstance.SelectDataByRowNumber(rowNo));
        }
        public void ClickOnRowContextOption()
        {
            ClickOnMobileElement(_pageInstance.AndroidContextButton);
        }
        public void SelectAction(string actionText)
        {
            ClickOnMobileElement(_pageInstance.SelectActionOption(actionText));
            WaitForLoaderToVanish();
        }
    }
}
