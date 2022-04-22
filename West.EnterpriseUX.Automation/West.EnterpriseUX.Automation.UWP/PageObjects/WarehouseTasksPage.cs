
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class WarehouseTasksPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public WarehouseTasksPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement cancelTaskBtn => FindElement("XPath://*[@Name='Cancel Task']");
        public WindowsElement confirmTaskBtn => FindElement("XPath://*[@Name='Confirm Task']");
        public IList<WindowsElement> IndexSearchSideFrame(string inboxName)
        {
            return FindElements($"XPath://Text[@Name='{inboxName}']");
        }
        public IList<WindowsElement> DetailActionAllRow(int rowNum)
        {
            return FindElements($"XPath://*[@Name=' Row" + rowNum + "']//*[@AutomationId='More']");
        }
        public WindowsElement SelectMenuOption(String dateText)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + dateText + "')]");
        }
        public IList<WindowsElement> row => FindElements($"XPath://*[@Name=' Row1']//*[@AutomationId='More']");
        public WindowsElement VerticalSmallIncrease => FindElement($"XPath://*[@AutomationId='VerticalSmallIncrease']"); 
        public WindowsElement VerticalScrollBar => FindElement($"XPath://*[@AutomationId='VerticalScrollBar']");
    }
}

