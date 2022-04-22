using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InventoryDashboardPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public InventoryDashboardPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> PlantPicker()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public WindowsElement SelectTimeInterval(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        }
    }
}
