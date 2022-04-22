using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class HRBankPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public HRBankPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement BankTypeCombobox => FindElement("AccessibilityId:BankTypePicker");
        public WindowsElement PayeeNameEdit => FindElement("AccessibilityId:PayeeTextField");
        public WindowsElement IBANEdit => FindElement("AccessibilityId:IbanTextField");
        public WindowsElement BankAccountEdit => FindElement("AccessibilityId:AccountNumberTextField");
        public WindowsElement BankKeyCombobox => FindElement("AccessibilityId:BankKeyPicker Dropdown Button");
        public IList<WindowsElement> BankKeys => FindElements("XPath:.//*[@AutomationId='BankKeyPicker Dropdown']//ListItem");
        public WindowsElement BankAmountEdit => FindElement("XPath://Edit[contains(@Name, 'Enter Share Amount')]");
        public WindowsElement SaveButton => FindElement("AccessibilityId:SaveButton");
        public WindowsElement AcknowledgementOkButton => FindElement("AccessibilityId:Button0");
        public WindowsElement IBANGeneratorImage => FindElement($"AccessibilityId:IbanGenerator");
        public IList<WindowsElement> UpdateImage => FindElements("AccessibilityId:imageActionDetail");
        public WindowsElement UpdateButton => FindElement("Name:Update");
        public WindowsElement SelectBankType(string bankType)
        {
            return FindElement($"XPath://Text[contains(@Name,'{bankType}')]");
        }
        public WindowsElement SelectBankKey(string bankKeyValue)
        {
            return FindElement($"XPath://Text[contains(@Name,'{bankKeyValue}')]");
        }
        public WindowsElement SearchingText(string textValue)
        {
            return FindElement($"XPath://Text[contains(@Name,'{textValue}')]");
        }
        public WindowsElement ResetButton => FindElement("AccessibilityId:ResetButton");
        public WindowsElement CancelButton => FindElement("AccessibilityId:cancelButton");
        public WindowsElement OkButton => FindElement("AccessibilityId:okButton");
        public WindowsElement PopUpDialogMessage => FindElement("AccessibilityId:dialogMessage");

        public WindowsElement RoutingNumberImage => FindElement("XPath://*[@Name='Routing Number']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement SelectBankKeyValue => FindElement("XPath://*[contains(@Name,'Row')]/Group/Text");
        public WindowsElement ConfirmBankAccountEdit => FindElement("XPath: //Text[@Name='Confirm Bank Account']/../../parent::Custom/following-sibling::Custom/Edit");
        public IList<WindowsElement> BankEndNowAction => FindElements("XPath://Text[@Name='End Now']");
        public IList<WindowsElement> BankMoreActionButton(string banktype)
        {
            return FindElements($"XPath://Group[contains(@Name,'{banktype}')]/preceding-sibling::Group[@Name='Detail Action']/Custom/Custom/Image[@AutomationId='More']");
        }
        public WindowsElement BankControlKeyCombobox => FindElement("AccessibilityId:BankControlKeyPicker");
        public WindowsElement BankAccount => FindElement("XPath://Text[@Name='Bank Account']");
        public WindowsElement BankCountryEdit => FindElement("XPath: //Text[@Name='Bank Country']/../../parent::Custom/following-sibling::Custom/Edit");
        public WindowsElement BankSharePercentage=> FindElement("XPath://Edit[contains(@Name, 'Enter Share Percentage')]");
        public WindowsElement IFSCImage => FindElement("XPath://*[@Name='IFSC']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public IList<WindowsElement> CalendarPopUpDateItems => FindElements("XPath: //Calendar[@AutomationId='CalendarView']/Pane/DataItem");
        public WindowsElement calendarDatePicker => FindElement("XPath: //*[@ClassName='CalendarDatePicker']");
        public IList<WindowsElement> BankEditAction => FindElements("XPath://Text[@Name='Edit']");
        public WindowsElement BankDeleteAction => FindElement("XPath://Text[@Name='Delete']");
    }
}
