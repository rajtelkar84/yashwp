using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CRMCommonPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CRMCommonPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement createButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public WindowsElement BackButton => FindElement("XPath:.//*[@Name='Back' or @AutomationId='Back']");

        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }

        public IList<WindowsElement> ValuebyRowAndColumnInGridRowWise(int rowNumber)
        {
            return FindElements($"XPath://*[@AutomationId=' Row" + rowNumber + "' or @Name=' Row" + rowNumber + "']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
    }
}
