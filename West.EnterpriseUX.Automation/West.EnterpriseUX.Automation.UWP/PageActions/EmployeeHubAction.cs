using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class EmployeeHubAction : BaseAction
    {

        private readonly WindowsDriver<WindowsElement> _session;
        private readonly EmployeeHubPage _pageInstance;

        public EmployeeHubAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new EmployeeHubPage(_session);
        }

        public void ClickOnDashboard()
        {
            ClickElement(_pageInstance.Dashboard);
            LogInfo("Clicked on Dashboard");
        }

        public void ClickOnEmployeeHubIcon()
        {
            ClickElement(_pageInstance.EmployeeHubIcon);
            LogInfo("Clicked on Employee Hub Icon");
        }

        public void ClickOnEmployeeHubOnHeader()
        {
            ClickElement(_pageInstance.EmployeeHubCenter);
            LogInfo("Clicked on Employee Hub On Header");
        }

        public void VerifyEmployeeHubTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.EmployeeHubTitle, "Name"), "Employee Hub");
            LogInfo("Verified Employee Hub Title");
        }

        public void EnterEmployeeNameInGrid(string employeeName)
        {
            ClickElement(_pageInstance.EmployeeSearchBox);
            ClearElement(_pageInstance.EmployeeSearchBox);
            EnterText(_pageInstance.EmployeeSearchBox, employeeName);
            ClickElement(_pageInstance.Options(employeeName));
        }

        public void VerifyEmployeeName(string employeeName)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.Options(employeeName), "Name"), employeeName);
            LogInfo("Verified Employee Name");
        }

        public void ClickOnMyTeamTab()
        {
            ClickElement(_pageInstance.MyTeamTab);
            LogInfo("Clicked on My Team Tab");
        }

        public void ClickOnEmployeeDetailsIcon()
        {
            ClickElement(_pageInstance.EmployeeDetailsIcon);
            LogInfo("Clicked on Employee Details Icon");
        }

        public void ClickOnOrgChartIconOnDashboard()
        {
            ClickElement(_pageInstance.DashboardOrgChartIcon);
            LogInfo("Clicked on Employee Details Icon");
        }

        public void VerifyOrgChartTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.OrgChartTitle, "Name"), "Org Chart");
            LogInfo("Verified Org Chart Title");
        }

        public void VerifyOrganizationChartTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.OrganizationChartTitle, "Name"), "Organization Chart");
            LogInfo("Verified Organization Chart Title");
        }

        public void ClickOnOrgChartIconInEmployeeDetails()
        {
            ClickElement(_pageInstance.OrgChartIconInEmployeeDetails);
            LogInfo("Clicked on Org Chart Icon in Employee Details");
        }

        public void ClickOnOrgChartTabInEmployeeDetails()
        {
            ClickElement(_pageInstance.OrgChartTitle);
            LogInfo("Clicked on Org Chart Tab in Employee Details");
        }

        public void ClickOnRefreshIconInEmployeeHub()
        {
            ClickElement(_pageInstance.RefreshIconInEmployeeHub);
            LogInfo("Clicked on Refresh Icon In Employee Hub");

        }

    }

}
