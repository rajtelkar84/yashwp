using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class WebinarPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public WebinarPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateWebinar => FindElement("XPath:.//*[contains(@Name,'Create Webinar')]");
        public WindowsElement EditWebinar => FindElement("XPath:.//*[contains(@Name,'Edit Webinar')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Reference => FindElement("XPath:.//*[contains(@Name,'Reference')]/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Link')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement ProspectDropdown => FindElement("XPath:.//*[contains(@Name,'Link ')] /../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement FirstName => FindElement("XPath:.//*[contains(@Name,'First Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement LastName => FindElement("XPath:.//*[contains(@Name,'Last Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Email => FindElement("XPath:.//*[contains(@Name,'Email')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Country => FindElement("XPath:.//*[contains(@Name,'Country')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Comments => FindElement("XPath:.//*[contains(@Name,'Comments')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement PhoneCode => FindElement("XPath:.//*[contains(@AutomationId,'CompanyPicker')]");
        public WindowsElement PhoneNumber => FindElement("XPath:.//*[contains(@AutomationId,'PhoneNumberEntry')]");
        public WindowsElement createButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateWebinarButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public WindowsElement WebinarTab => FindElement("XPath:.//*[contains(@Name,'Webinar') and contains(@AutomationId,'dashboardLabel')]");

        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
    }
}
