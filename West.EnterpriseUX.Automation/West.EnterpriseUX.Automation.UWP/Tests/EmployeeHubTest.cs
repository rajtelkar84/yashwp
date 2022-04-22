using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("EmployeeHub")]
    [TestClass]
    public class EmployeeHubTest : BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Navigation from Dashboard to Employee Hub;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438191.csv", "EmployeeHub_438191#csv", DataAccessMethod.Sequential)]
        public void TC_438191_NavigationfromDashboardToEmployeeHub()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();             
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            
        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Navigation from Dashboard to Employee Hub Center;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438191.csv", "EmployeeHub_438191#csv", DataAccessMethod.Sequential)]
        public void TC_438215_NavigationfromDashboardToEmployeeHubCenter()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubOnHeader();
                _employeeHubAction.VerifyEmployeeHubTitle();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Employee Search and Navigating to the Employee Details Page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438220.csv", "EmployeeHub_438220#csv", DataAccessMethod.Sequential)]
        public void TC_438220_VerifyEmployeeSearchAndNavigatingToTheEmployeeDetailsPage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string employeename = this.TestContext.DataRow["employeename"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();
                _employeeHubAction.EnterEmployeeNameInGrid(employeename);
                _employeeHubAction.VerifyEmployeeName(employeename);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Functionality of Clicking On Employee Details Icon Should Navigate To Employee Details Page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438224.csv", "EmployeeHub_438224#csv", DataAccessMethod.Sequential)]
        public void TC_438224_VerifyClickingOnEmployeeDetailsIconShouldNavigateToEmployeeDetailsPage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string employeename = this.TestContext.DataRow["employeename"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();
                _employeeHubAction.ClickOnMyTeamTab();
                _employeeHubAction.ClickOnEmployeeDetailsIcon();
                _employeeHubAction.VerifyEmployeeName(employeename);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Navigation from Org Chart icon on Dashboard to Org Chart page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438224.csv", "EmployeeHub_438224#csv", DataAccessMethod.Sequential)]
        public void TC_438232_VerifyNavigationFromOrgChartIconOnDashboardToOrgChartPage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string employeename = this.TestContext.DataRow["employeename"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnOrgChartIconOnDashboard();
                _employeeHubAction.VerifyOrganizationChartTitle();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Functionality of Clicking On Org Chart Icon In Employee Details Should Navigate To Org Chart Page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438224.csv", "EmployeeHub_438224#csv", DataAccessMethod.Sequential)]
        public void TC_448225_VerifyClickingOnOrgChartIconInEmployeeDetailsShouldNavigateToOrgChartPage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string employeename = this.TestContext.DataRow["employeename"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();
                _employeeHubAction.ClickOnMyTeamTab();
                _employeeHubAction.VerifyEmployeeName(employeename);
                _employeeHubAction.ClickOnOrgChartIconInEmployeeDetails();
                _employeeHubAction.VerifyOrgChartTitle();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests the Functionality In Employee Details Page Try To Switch To Org Chart Tab;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438224.csv", "EmployeeHub_438224#csv", DataAccessMethod.Sequential)]
        public void TC_438246_VerifyInEmployeeDetailsPageTryToSwitchToOrgChartTab()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string employeename = this.TestContext.DataRow["employeename"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();
                _employeeHubAction.ClickOnMyTeamTab();
                _employeeHubAction.ClickOnEmployeeDetailsIcon();
                _employeeHubAction.VerifyEmployeeName(employeename);
                _employeeHubAction.ClickOnOrgChartTabInEmployeeDetails();
                _employeeHubAction.VerifyOrgChartTitle();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("EmployeeHubTest")]
        [Description("Tests The Refresh Icon In Employee Hub;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EmployeeHub_438224.csv", "EmployeeHub_438224#csv", DataAccessMethod.Sequential)]
        public void TC_438249_VerifyingTheRefreshIconInEmployeeHub()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();

                _homeAction.ClickOnFunction(function);
                _employeeHubAction.ClickOnDashboard();
                _employeeHubAction.ClickOnEmployeeHubIcon();
                _employeeHubAction.VerifyEmployeeHubTitle();
                _employeeHubAction.ClickOnMyTeamTab();
                _employeeHubAction.ClickOnRefreshIconInEmployeeHub();
                _baseAction.WaitForLoadingToDisappear();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        #endregion
    }
}
