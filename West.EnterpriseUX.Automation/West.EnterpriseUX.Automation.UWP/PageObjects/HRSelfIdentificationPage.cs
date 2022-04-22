using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class HRSelfIdentificationPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public HRSelfIdentificationPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement selfIdentificationImage =>  FindElement($"XPath://Text[contains(@Name,'Self Identification')]/following-sibling::Image");
        public WindowsElement selfIdentificationMenuOption => FindElement("XPath://Text[@Name='Self Identification']");
        public WindowsElement appBarSelfIdentification => FindElement("XPath://*[@ClassName='ApplicationBar']/Custom/Text[@Name='Self Identification']");
        public WindowsElement EthnicityTextBox => FindElement("XPath://*[@Name='Ethnicity']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement VeteranStatusTextBox => FindElement("XPath://*[@Name='Veteran Status']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement StatusTextBox => FindElement("XPath://*[@Name='Status']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement OkButton => FindElement("AccessibilityId:okButton");
        public WindowsElement SaveButton=> FindElement("XPath://Button[contains(@Name, 'Save')]");
        public IList<WindowsElement> EthnicityPicker => FindElements("XPath://*[@Name='Ethnicity']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public IList<WindowsElement> RacePicker => FindElements("XPath://*[@Name='Race I identify as']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public IList<WindowsElement> VeteranStatusPicker => FindElements("XPath://*[@Name='Veteran Status']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public IList<WindowsElement> DisabilityStatusPicker => FindElements("XPath://*[@Name='Status']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement SearchInGrid => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SearchButtonInPopUp=> FindElement("XPath://*[@Name='Search']/preceding-sibling::Image");
        public WindowsElement SelectSearchValue(string searchValue)
        {
            return FindElement($"XPath://Text[@Name='{searchValue}']");
        }
        public IList<WindowsElement> protectedVeteranType(string searchValue)
        {
            return FindElements($"XPath://Button[contains(@AutomationId,'{searchValue}')]");
        }
        public IList<WindowsElement> CalendarPopUpDateItems => FindElements("XPath: //Calendar[@AutomationId='CalendarView']/Pane/DataItem");
        public WindowsElement calendarDatePicker => FindElement("XPath: //*[@ClassName='CalendarDatePicker']");

        public WindowsElement SelfIDTextBox(string textboxName)
        {
            return FindElement($"XPath://*[@Name='{textboxName}']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        }
        public WindowsElement AcknowledgementOkButton => FindElement("AccessibilityId:okButton");
        public WindowsElement ResetButton => FindElement("XPath://Button[contains(@Name, 'Reset')]");
        public WindowsElement PopUpDialogMessage => FindElement("AccessibilityId:dialogMessage");
    }
}
