using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class HRAddressPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public HRAddressPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement AddressTypeCombobox => FindElement("AccessibilityId:AddressTypePicker");
        public WindowsElement CareOfEdit => FindElement("AccessibilityId:CareOfEntry");
        public IList<WindowsElement> AddressFirstLine => FindElements("AccessibilityId:AddressLine1Entry");
        public IList<WindowsElement> AddressSecondLine => FindElements("AccessibilityId:AddressLine2Entry");
        public WindowsElement CityEdit => FindElement("AccessibilityId:CityEntry");
        public WindowsElement PinCodeEdit => FindElement("AccessibilityId:PinCodeEntry");
        public WindowsElement StreetEdit => FindElement("AccessibilityId:Address1Entry");
        public IList<WindowsElement> TelephoneEdit => FindElements("AccessibilityId:MobileNumberEntry");
        public WindowsElement SaveButton => FindElement("AccessibilityId:SaveButton");
        public WindowsElement AcknowledgementOkButton => FindElement("AccessibilityId:okButton");
        public WindowsElement MyAddressHeader => FindElement($"XPath://Text[contains(@Name,'My Address')]");
        public IList<WindowsElement> UpdateImage => FindElements("AccessibilityId:imageActionDetail");
        public WindowsElement UpdateButton => FindElement("Name:Update");
        public IList<WindowsElement> AddressRegionsCombobox => FindElements("AccessibilityId:StateComboBox Dropdown Button");
        public IList<WindowsElement> AddressRegions => FindElements("XPath:.//*[@AutomationId='StateComboBox Dropdown']//ListItem");
        public WindowsElement SearchingText(string textValue)
        {
            return FindElement($"XPath://Text[contains(@Name,'{textValue}')]");
        }
        public WindowsElement SelectAddressRegion(string regionValue)
        {
            return FindElement($"XPath://Text[contains(@Name,'{regionValue}')]");
        }
        public IList<WindowsElement> RegionImage => FindElements("XPath://*[@Name='Region']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement SearchInGrid => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SearchButtonInSelectRegion => FindElement("XPath://*[@Name='Search']/preceding-sibling::Image");
        public WindowsElement PopUpDialogMessage => FindElement("AccessibilityId:dialogMessage");
        public WindowsElement AddressTypePicker => FindElement("AccessibilityId:AddressTypePicker");
        public WindowsElement SelectAddressType(string addressType)
        {
            return FindElement($"XPath://Text[contains(@Name,'{addressType}')]");
        }
        public WindowsElement ResetButton => FindElement("AccessibilityId:ResetButton");
        public WindowsElement RegionEditTextBox => FindElement("XPath: //Text[@Name='Region']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public IList<WindowsElement> DistanceInKMEdit => FindElements("AccessibilityId:DistanceInKmEntry");

        public IList<WindowsElement> AddressDetailAction_More => FindElements("XPath://Group[@Name='Detail Action']/Custom/Custom/Image[@AutomationId='More']");
        public IList<WindowsElement> EndNowAction => FindElements("XPath://Text[@Name='End Now']");

        public WindowsElement CountyImage => FindElement("XPath://*[@Name='County']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement SelectCountyValue => FindElement("XPath://*[contains(@Name,'Row')]/Group/Text");
        public IList<WindowsElement> CalendarPopUpDateItems => FindElements("XPath: //Calendar[@AutomationId='CalendarView']/Pane/DataItem");
        public WindowsElement calendarDatePicker => FindElement("XPath: //*[@ClassName='CalendarDatePicker']");
        public WindowsElement AddressDeleteButton(string address)
        {
            return FindElement($"XPath://Text[contains(@Name,'{address}')]/../parent::Custom/following-sibling::Custom");
        }
        public WindowsElement Address => FindElement("XPath://Text[@Name='Address']");
    }
}
