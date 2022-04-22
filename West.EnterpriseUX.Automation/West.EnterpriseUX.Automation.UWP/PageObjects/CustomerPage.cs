using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CustomerPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CustomerPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateCustomer => FindElement("XPath://*[@Name='Create CRM Account']");
        public WindowsElement CompanyName => FindElement("XPath://*[@AutomationId='AIdCustomerAccountNameCustomEntry']");
        public WindowsElement Street1 => FindElement("XPath://*[@AutomationId='AIdCustomerStreetOrHouseNoCustomEntry']");
        public WindowsElement Street2 => FindElement("XPath://*[@AutomationId='AIdCustomerStreet2CustomEntry']");
        public WindowsElement Street3 => FindElement("XPath://*[@AutomationId='AIdCustomerStreet3CustomEntry']");
        public WindowsElement City => FindElement("XPath://*[@AutomationId='AIdCustomerCityCustomEntry']");
        public WindowsElement Country => FindElement("XPath://*[@AutomationId='AIdCustomerCountryGenericPickerControl']/descendant::*[@ClassName='Image']");
        public WindowsElement CountryNameField => FindElement("XPath://*[@AutomationId='AIdCustomerCountryGenericPickerControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement State => FindElement("XPath://*[@AutomationId='AIdProspectStatePicker']/descendant::*[@ClassName='Image']");
        public WindowsElement StateNameField => FindElement("XPath://*[@AutomationId='AIdProspectStatePicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement AccountManager => FindElement("XPath://*[@AutomationId='AIdCustomerAccountManagerCustomComboBox Input Field']");
        public WindowsElement AccountManagerDropDownButton => FindElement("XPath://*[@AutomationId='AIdCustomerAccountManagerCustomComboBox Dropdown Button']");
        public WindowsElement Website => FindElement("XPath://*[@AutomationId='AIdHyperlinkEditorURLEntry']");
        public WindowsElement Email => FindElement("XPath://*[@AutomationId='AIdCustomerEmailCustomEntry']");
        public WindowsElement PhoneCode => FindElement("XPath://*[@AutomationId='AIdContactPhone1Picker']");
        public WindowsElement PhoneCodeContent => FindElement("XPath://*[@AutomationId='AIdContactPhone1Picker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneNumber => FindElement("XPath://*[@AutomationId='AIdContactPhone1Entry']");
        public WindowsElement Zip => FindElement("XPath://*[@AutomationId='AIdProspectZipEntry']");
        public IList<WindowsElement> CreateOrUpdateButton => FindElements("XPath://*[@AutomationId='AIdCustomerCreateOrUpdateButton']");
        public IList<WindowsElement> ChildInboxIcon => FindElements("XPath://*[@AutomationId='ViewSemantic']");
        public IList<WindowsElement> ChildInboxCount => FindElements("XPath://*[@AutomationId='InboxCount']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");

        public IList<WindowsElement> ChildInboxName()
        {
            return FindElements($"XPath://*[@AutomationId='InboxName']");
        }
        public WindowsElement Options(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }


    }
}
