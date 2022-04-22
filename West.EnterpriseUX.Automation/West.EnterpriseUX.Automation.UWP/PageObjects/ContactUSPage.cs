using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ContactUSPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ContactUSPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateContactUs => FindElement("XPath:.//*[contains(@Name,'Create Contact Us')]");
        public WindowsElement EditContactUs => FindElement("XPath:.//*[contains(@Name,'Edit Contact Us')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Entity => FindElement("XPath:.//*[contains(@Name,'Entity')]/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Link')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement ProspectDropdown => FindElement("XPath:.//*[contains(@Name,'Link ')] /../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement StartTime => FindElement("XPath:.//*[contains(@Name,'Start Time')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement FirstName => FindElement("XPath:.//*[contains(@Name,'First Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement LastName => FindElement("XPath:.//*[contains(@Name,'Last Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Title => FindElement("XPath:.//*[contains(@Name,'Title')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Email => FindElement("XPath:.//*[contains(@Name,'Email')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Comments => FindElement("XPath:.//*[contains(@Name,'Comments')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement PhoneCode => FindElement("XPath:.//*[contains(@AutomationId,'CountryCodePicker')]");
        public WindowsElement PhoneNumber => FindElement("XPath:.//*[contains(@AutomationId,'CompanyPhoneNumberEntry')]");
        public WindowsElement CompanyName => FindElement("XPath:.//*[contains(@Name,'Company Name')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Street => FindElement("XPath:.//*[contains(@Name,'Street')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement City => FindElement("XPath:.//*[contains(@Name,'City')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Zip => FindElement("XPath:.//*[contains(@Name,'Zip Code')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Country => FindElement("XPath:.//*[contains(@AutomationId,'CountryPicker')]");
        public WindowsElement State => FindElement("XPath:.//*[contains(@AutomationId,'StatePicker')]");
        public WindowsElement Message => FindElement("XPath:.//*[contains(@Name,'Message')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement CustomerIntrest => FindElement("XPath:.//*[contains(@Name,'Customer Interest')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement createButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateWebinarButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public WindowsElement ContactUsTab => FindElement("XPath:.//*[contains(@Name,'Contact Us') and contains(@AutomationId,'dashboardLabel')]");
        public WindowsElement ContactUsTabEnterValues => FindElement("XPath:.//*[@Name='Contact Us' and contains(@AutomationId,'Contact Us')]");
        public WindowsElement ContactDetailsTabEnterValues => FindElement("XPath:.//*[contains(@Name,'Contact Details')]");
        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
    }
}
