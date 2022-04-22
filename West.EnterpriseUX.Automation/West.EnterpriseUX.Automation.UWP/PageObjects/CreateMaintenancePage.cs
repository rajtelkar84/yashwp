using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CreateMaintenancePage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public CreateMaintenancePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> GetFieldText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> ReferenceNumber()
        {
            return FindElements($"XPath://CheckBox[@ClassName='CheckBox']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public WindowsElement OrderNumberPick(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'Image')]");
        }
        public WindowsElement EnterText(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
        public WindowsElement DialogPopUp()
        {
            return FindElement("XPath:.//*[@AutomationId='dialogMessage']");
        }
        public IList<WindowsElement> OrderNumberPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
    }
}
