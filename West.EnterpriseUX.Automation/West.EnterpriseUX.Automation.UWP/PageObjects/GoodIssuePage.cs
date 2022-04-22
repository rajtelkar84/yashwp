using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
   public class GoodIssuePage :BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public GoodIssuePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement OrderNumberField => FindElement("XPath://*[@AutomationId='OrderNumber Input Field' and @Name='OrderNumber Input Field']");
        public WindowsElement RemoveBatchUWP => FindElement("XPath://*[@AutomationId='RemoveBatchUWP']");
        public IList<WindowsElement> MaterialPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> InputTextBox(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> BatchTextBoxEdit()
        {
            return FindElements($"XPath://*[@AutomationId='BatchUWP Input Field']");
        } 
        public IList<WindowsElement> DeleteMaterialItem()
        {
            return FindElements($"XPath://*[@AutomationId='DeleteMaterialItem']");
        }
        public IList<WindowsElement> GetDate(string Text)
        {
            return FindElements($"XPath://*[@AutomationId='{Text}']");
        }
        public IList<WindowsElement> TextBox()
        {
            return FindElements($"XPath://*[@ClassName='TextBox']");
        }
        public WindowsElement AddBatchUWP => FindElement("XPath://*[@AutomationId='AddBatchUWP']");
        public IList<WindowsElement> FetchList()
        {
            return FindElements($"XPath://*[@ClassName='ListBoxItem']");
        }
        public IList<WindowsElement> GridColumnCheckBox()
        {
            return FindElements($"XPath://CheckBox[@ClassName='CheckBox']");
        }
        public WindowsElement Post => FindElement("XPath://*[@Name='Post']");
        public IList<WindowsElement> OrderNumberPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");

    }
}