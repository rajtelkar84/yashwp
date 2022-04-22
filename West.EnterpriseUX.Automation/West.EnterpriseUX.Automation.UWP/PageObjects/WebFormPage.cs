using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class WebFormPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public WebFormPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement CreateWebForm => FindElement("XPath:.//*[contains(@Name,'Create Webform')]");
        public WindowsElement EditWebForm => FindElement("XPath:.//*[contains(@Name,'Edit Webform')]");
        public WindowsElement Name => FindElement("XPath:.//*[contains(@Name,'Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement WebForm => FindElement("XPath:.//*[contains(@Name,'Web form')]/../../../following-sibling::*/*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Reference => FindElement("XPath:.//*[contains(@Name,'Reference')]/../../../following-sibling::*/*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Input Field')]");
        public WindowsElement StartDate => FindElement("XPath:.//*[contains(@ClassName,'CalendarDatePicker')]//*[contains(@ClassName,'TextBlock')]");
        public WindowsElement StartTime => FindElement("XPath:.//*[contains(@Name,'Start time')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement CreateWebFormButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateWebFormButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            //return FindElement($"XPath://*[contains(@AutomationId,'{rowAndColumnInGrid}')] | //*[contains(@Name,'Row1')]//*[@ClassName='']");
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public WindowsElement CreateWebFormTab => FindElement("XPath:.//*[contains(@Name,'Web Form') and contains(@AutomationId,'dashboardLabel')]");
    }
}
