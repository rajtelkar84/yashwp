using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.Tests
{
    [TestClass]
    public class SmokeTest : BaseTest
    {
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Login functionality;;")]
        public void CheckingLoginFunctionTest()
        {
            try
            {
                //_loginAction.LoginToWD();
                // WaitForMoment(5);
                // _loginAction.LogoutFromWD();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Inbox Navigation scenario;;")]
        public void NavigatingToInboxTest()
        {
            try
            {
                string expectedInboxName = "Sales Orders";
                string actaulInboxName = string.Empty;

                _homeAction.NavigateToInboxBySearch(expectedInboxName);
                WaitForMoment(1);
                actaulInboxName = _homeAction.GetInboxName();

                Assert.AreEqual(expectedInboxName, actaulInboxName, $"Navigated Inbox name : {actaulInboxName} is not matching with the expected inbox name{expectedInboxName}");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verifies Dashboard Creation functionality;;")]
        public void CreateDashboardLabelTest()
        {
            try
            {
                string expectedInboxName = "Sales Orders";
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();
                string labelName = string.Empty;

                labelName = $"AndroidLabel" + uniqueIdentifier;

                _homeAction.NavigateToInboxBySearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SelectAbstraction(WDAbstractions.DETAILS.ToString());
                WaitForMoment(10);
                _inboxDetailsAction.CreateDashboardLabel(labelName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verifies Configure KPI functionality;;")]
        public void ConfigureKPITest()
        {
            try
            {
                string expectedInboxName = "Sales Orders";
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();
                string propertyValue = "Count (Count_)";
                string templateName = string.Empty;
                string labelName = string.Empty;

                labelName = "AndroidLabel" + uniqueIdentifier;
                templateName = "AndroidTV" + uniqueIdentifier;

                _homeAction.NavigateToInboxBySearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SelectAbstraction(WDAbstractions.DETAILS.ToString());
                WaitForMoment(2);
                _inboxDetailsAction.CreateDashboardLabel(labelName);
                WaitForMoment(2);
                _inboxDetailsAction.SelectAbstraction(WDAbstractions.KPIS.ToString());
                WaitForMoment(10);
                _inboxKpiAction.SelectUserCreatedTab();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxKpiAction.ClickOnKPIEditOption(labelName);
                WaitForMoment(2);
                _inboxKpiAction.EnterKPITemplateName(templateName);
                WaitForMoment(2);
                _inboxKpiAction.SelectKPIProperty(propertyValue);
                WaitForMoment(2);
                _inboxKpiAction.ClickOnKPITemplateSave();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verifies Creating Chart functionality;;")]
        public void CreateChartTest()
        {
            try
            {
                string expectedInboxName = "Sales Orders";
                string ChartName = "AndroidChart" + _helper.GenerateUniqueRandomNumber();
                string measureValue = "Count";
                string dimensionValue = "Overall Processing Status";

                _homeAction.NavigateToInboxBySearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SelectAbstraction(WDAbstractions.CHARTS.ToString());
                WaitForMoment(2);
                _inboxChartAction.ClickOnUserCreatedChartsTab();
                WaitForMoment(2);
                _inboxChartAction.ClickOnCreateChartImage();
                WaitForMoment(2);
                _inboxChartAction.EnterChartName(ChartName);
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxChartAction.SelectMeasuresValue(measureValue);
                WaitForMoment(2);
                _inboxChartAction.SelectDimensionsValue(dimensionValue);
                WaitForMoment(2);
                _inboxChartAction.ClickOnSaveChart();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verifies Creating Storyboard functionality;;")]
        public void CreateStoryboardTest()
        {
            try
            {
                string expectedInboxName = "Sales Orders";
                string storyboardName = "AndroidStoryboard"+ _helper.GenerateUniqueRandomNumber();

                _homeAction.NavigateToInboxBySearch(expectedInboxName);
                WaitForMoment(10);
                _inboxDetailsAction.SelectAbstraction(WDAbstractions.STORYBOARDS.ToString());
                WaitForMoment(10);
                _inboxStoryboardAction.ClickOnCreateStoryboard();
                WaitForMoment(2);
                _inboxStoryboardAction.EnterStoryboardName(storyboardName);
                WaitForMoment(2);
                _inboxStoryboardAction.ClickOnImportKPIs();
                WaitForMoment(2);
                _inboxStoryboardAction.SelectTemplatesCheckboxes();
                WaitForMoment(2);
                _inboxStoryboardAction.ClickOnImportButton();
                WaitForMoment(2);
                _inboxStoryboardAction.ClickOnSaveStoryboard();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region Common Methods
       
        #endregion
    }
}
