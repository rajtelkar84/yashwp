using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ReportPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public ReportPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> OrderNumberPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> Button()
        {
            return FindElements($"XPath://*[@ClassName='Button']");
        }
        public IList<WindowsElement> ReprintTab( )
        {
            return FindElements($"XPath://CheckBox[@ClassName='CheckBox']/following-sibling::*");
        }
    }
}
