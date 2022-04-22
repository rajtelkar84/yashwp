using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InboxStoryboardsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public InboxStoryboardsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateStoryboardButton => FindElement("XPath://*[@Name='Create storyboard']");
        public WindowsElement StoryboardTitleTextbox => FindElement("XPath://*[@Name='Title']/following-sibling::*//Edit");
        public WindowsElement SaveStoryboardButton => FindElement("XPath://*[@Name='Save']");
        public WindowsElement ImportChartButton => FindElement("XPath://Button[@Name='Import']");
        public IList<WindowsElement> ImportableCharts => FindElements("AccessibilityId:Import");
        public IList<WindowsElement> ImportableKPIs => FindElements("AccessibilityId:Import");
        public IList<WindowsElement> Storyboards => FindElements("XPath://*[@AutomationId='EditStoryBoardStack']/parent::Custom/parent::Custom");
        public IList<WindowsElement> StoryboardDelete => FindElements("Name:Delete");
        public WindowsElement EditStoryboardButton => FindElement("XPath://*[@Name='Edit']");
        public IList<WindowsElement> StoryboardItemsRemoveButton => FindElements("AccessibilityId:Remove");
        public IList<WindowsElement> CreateStoryboardbutton => FindElements("XPath://*[@Name='Create storyboard']");
        public WindowsElement SelectStoryboardType(string storyboardType)
        {
            return FindElement($"XPath://Text[@Name='{storyboardType}']");
        }
        public IList<WindowsElement> GetStoryboardByName(string storyboardName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{storyboardName}') and @AutomationId='StoryBoardTitle']");
        }
        public IList<WindowsElement> SelectReportToImport => FindElements("AccessibilityId:ReportSelectionImage");
        //public IList<WindowsElement> SelectReportToImport => FindElements("XPath://*[@AutomationId='ReportSelectionImage']/parent::Custom//Custom[@AutomationId='ReportSelection']");
    }
}
