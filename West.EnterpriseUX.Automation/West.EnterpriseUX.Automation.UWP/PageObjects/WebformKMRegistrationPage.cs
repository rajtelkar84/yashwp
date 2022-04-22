using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class WebformKMRegistrationPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public WebformKMRegistrationPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateWebFormKMRegistration => FindElement("XPath:.//*[contains(@Name,'Create KM Webform Registration')]");
        public WindowsElement EditWebformKMRegistration => FindElement("XPath:.//*[contains(@Name,'Edit KM Registration Webform')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Reference => FindElement("XPath:.//*[contains(@Name,'Reference')]/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Link')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement ProspectDropdown => FindElement("XPath:.//*[contains(@Name,'Link ')] /../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement FirstName => FindElement("XPath:.//*[contains(@Name,'First Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement LastName => FindElement("XPath:.//*[contains(@Name,'Last name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Email => FindElement("XPath:.//*[contains(@Name,'E-mail')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Country => FindElement("XPath:.//*[contains(@Name,'Country')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement CompanyName => FindElement("XPath:.//*[contains(@Name,'Company Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement City => FindElement("XPath:.//*[contains(@Name,'City')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement State => FindElement("XPath:.//*[contains(@Name,'State')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement createButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateWebFormButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public WindowsElement KMRegistrationTab => FindElement("XPath:.//*[contains(@Name,'KM Registration') and contains(@AutomationId,'dashboardLabel')]");

        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
    }
}
