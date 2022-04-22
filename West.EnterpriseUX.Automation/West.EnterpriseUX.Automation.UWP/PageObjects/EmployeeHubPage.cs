using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class EmployeeHubPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public EmployeeHubPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Dashboard => FindElement("XPath://*[@Name='Dashboard']");
        public WindowsElement EmployeeHubIcon => FindElement("XPath://*[@AutomationId='DashboardEmployeehubIcon']");
        public WindowsElement EmployeeHubTitle => FindElement("XPath://*[@Name='Employee Hub']");
        public WindowsElement EmployeeHubCenter => FindElement("XPath://*[@AutomationId='EmployeeCenter']");
        public WindowsElement EmployeeSearchBox => FindElement("XPath://*[@AutomationId=' Input Field']");
        public WindowsElement MyTeamTab => FindElement("XPath://*[@Name='My Team']");
        public WindowsElement EmployeeDetailsIcon => FindElement("XPath://*[@AutomationId='employeeDetail']");
        public WindowsElement OrgChartIconInEmployeeDetails => FindElement("XPath://*[@AutomationId='orgChart']");
        public WindowsElement DashboardOrgChartIcon => FindElement("XPath://*[@AutomationId='DashboardOrgChartIcon']");
        public WindowsElement OrgChartTitle => FindElement("XPath://*[@Name='Org Chart']");
        public WindowsElement OrganizationChartTitle => FindElement("XPath://*[@Name='Organization Chart']");
        public WindowsElement RefreshIconInEmployeeHub => FindElement("XPath://*[@AutomationId='refreshStatus']");
        public WindowsElement Options(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }

    }
}
