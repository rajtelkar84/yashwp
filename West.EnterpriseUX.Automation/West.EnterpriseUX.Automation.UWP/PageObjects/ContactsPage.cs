using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ContactsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ContactsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateContacts => FindElement("XPath:.//*[contains(@Name,'Create Contact')]");
        public WindowsElement Salutation => FindElement("XPath://*[@AutomationId='AIdSalutationPicker']");
        public WindowsElement SalutationField => FindElement("XPath://*[@AutomationId='AIdSalutationPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement FirstName => FindElement("XPath://*[@AutomationId='AIdContactFirstNameEntry']");
        public WindowsElement LastName => FindElement("XPath://*[@AutomationId='AIdContactLastName_LabelEntry']");
        public WindowsElement CompanyArrow => FindElement("XPath://*[@AutomationId='AIdContactProfilePage_AccountPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement CompanyNameField => FindElement("XPath://*[@AutomationId='AIdContactProfilePage_AccountPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement JobTitle => FindElement("XPath://*[@AutomationId='AIdContactJobTitleEntry']");
        public WindowsElement JobFunction => FindElement("XPath://*[@AutomationId='AIdContactJobFunctionPickerf']");
        public WindowsElement JobFunctionField => FindElement("XPath://*[@AutomationId='AIdContactJobFunctionPickerf']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Email => FindElement("XPath://*[@AutomationId='AIdContactEmailAddressEntry']");
        public WindowsElement ContactOwner => FindElement("XPath://*[@AutomationId='AIdContactContactOwnerComboBox']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ContactOwnerArrow => FindElement("XPath://*[@AutomationId='AIdContactContactOwnerComboBox']/descendant::*[@ClassName='Image']");
        public WindowsElement ContactOwnerClearButton => FindElement("XPath://*[@AutomationId='AIdContactContactOwnerComboBox Input Clear Button']");
        public WindowsElement AccountArrow => FindElement("XPath://*[@AutomationId='AIdContactProfilePage_AccountPicker']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement Address1 => FindElement("XPath://*[@AutomationId='AIdContactAddressStreet1Entry']");
        public WindowsElement Address2 => FindElement("XPath://*[@AutomationId='AIdContactAddressStreet2Entry']");
        public WindowsElement Address3 => FindElement("XPath://*[@AutomationId='AIdContactAddressStreet3Entry']");
        public WindowsElement City => FindElement("XPath://*[@AutomationId='AIdContactCityEntry']");
        public WindowsElement CountryArrow => FindElement("XPath://*[@AutomationId='AIdContactCountryPicker']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement CountryNameField => FindElement("XPath://*[@AutomationId='AIdContactCountryPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement StateArrow => FindElement("XPath://*[@AutomationId='AIdContactStateOrProvinceEntry']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement StateNameField => FindElement("XPath://*[@AutomationId='AIdContactStateOrProvinceEntry']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ZipCode => FindElement("XPath://*[@AutomationId='AIdContactPostalCodeEntry']");
        public WindowsElement Region => FindElement("XPath://*[@AutomationId='AIdContactRegionPicker']");
        public WindowsElement RegionNameField => FindElement("XPath://*[@AutomationId='AIdContactRegionPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneCode1 => FindElement("XPath://*[@AutomationId='AIdContactPhone1Picker']");
        public WindowsElement PhoneCode1Field => FindElement("XPath://*[@AutomationId='AIdContactPhone1Picker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneNumber1 => FindElement("XPath://*[@AutomationId='AIdContactPhone1Entry']");
        public WindowsElement PhoneCode2 => FindElement("XPath://*[@AutomationId='AIdContactPhone2Picker']");
        public WindowsElement PhoneCode2Field => FindElement("XPath://*[@AutomationId='AIdContactPhone2Picker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneNumber2 => FindElement("XPath://*[@AutomationId='AIdContactPhone2Entry']");
        public WindowsElement WebSite => FindElement("XPath://*[@AutomationId='AIdHyperlinkEditorURLEntry']");
        public WindowsElement ChannelSource => FindElement("XPath://*[@AutomationId='AIdContactChannelSourcePicker']");
        public WindowsElement ChannelSourceNameField => FindElement("XPath://*[@AutomationId='AIdContactChannelSourcePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ChannelSourceDetails => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourceDetailPicker']");
        public WindowsElement ChannelSourceDetailsNameField => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourceDetailPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Comments => FindElement("XPath://*[@AutomationId='AIdContactAdditionalInformationEditor']");
        public WindowsElement CommentsNameField => FindElement("XPath://*[@AutomationId='AIdContactAdditionalInformationEditor']/descendant::*[@ClassName='TextBox']");
        public WindowsElement AllowEmail => FindElement("XPath://*[@AutomationId='AIdContactAllowEmailSwitch']");
        public WindowsElement AllowPhoneCalls => FindElement("XPath://*[@AutomationId='AIdContactAllowPhoneCallsSwtich']");
        public WindowsElement AllowBulkEmails => FindElement("XPath://*[@AutomationId='AIdContactAllowBulkEmailSwtich']");
        public WindowsElement AllowMail => FindElement("XPath://*[@AutomationId='AIdContactAllowMailSwitch']");
        public WindowsElement TranslateTo => FindElement("XPath://*[@AutomationId='AIdContactTranslateToPicker']");
        public WindowsElement Salutation_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationSalutationEntry']");
        public WindowsElement FN_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationFirstNameEntry']");
        public WindowsElement LN_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationLastNameEntry']");
        public WindowsElement Website_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationWebsiteEntry']");
        public WindowsElement Add1_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationAddressStreet1Entry']");
        public WindowsElement Add2_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationAddressStreet2Entry']");
        public WindowsElement Add3_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationAddressStreet3Entry']");
        public WindowsElement CompanyName_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationCompanyNameTextEntry']");
        public WindowsElement JobeTitle_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationJobTitleEntry']");
        public WindowsElement JobFunction_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationJobFunctionEntry']");
        public WindowsElement Email_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationEmailAddressEntry']");
        public WindowsElement City_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationCityEntry']");
        public WindowsElement Country_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationCountryEntry']");
        public WindowsElement StateOrProvince_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationStateEntry']");
        public WindowsElement Zip_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationPostalCodeEntry']");
        public WindowsElement Phone1_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationPhone1Entry']");
        public WindowsElement Phone2_T => FindElement("XPath://*[@AutomationId='AIdContactTranslationPhone2Entry']");
        public WindowsElement createButton => FindElement("XPath://*[@AutomationId='AIdSaveButtonText']");
        public WindowsElement EditContacts => FindElement("XPath:.//*[contains(@Name,'Edit Contact')]");
        public WindowsElement BackButton => FindElement("XPath:.//*[@Name='Back' or @AutomationId='Back']");
        public WindowsElement UpdateButton => FindElement("XPath:.//*[@Name='Update']");
        public WindowsElement RefreshData => FindElement("XPath:(//*[@AutomationId='RefreshData'])[2]");
        public IList<WindowsElement> DetailAction => FindElements("XPath://*[@Name=' Row1']//Image[@AutomationId='More']");
        public WindowsElement CreatedDateAndDays => FindElement("XPath://*[@AutomationId='AIdEntityInsightCreateDateLabel']");
        public WindowsElement InboxName => FindElement("XPath://*[@AutomationId='InboxName']");
        public WindowsElement CopyDetails => FindElement("XPath://*[@AutomationId='AIdCompanyCheckBoxEntry']");
        public WindowsElement OptionsValue(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }

        #region Old
        public WindowsElement ContactPhoneCodeSelected => FindElement("XPath:.//*[contains(@AutomationId,'CompanyPicker')]/*[@ClassName='ComboBoxItem']");
        public WindowsElement ContactPhoneNumber => FindElement("XPath:.//*[contains(@AutomationId,'PhoneNumberEntry')]");
        public WindowsElement CompanyInformation => FindElement("XPath:.//*[contains(@Name,'Company Information')]");
        public WindowsElement ContactInformation => FindElement("XPath:.//*[contains(@Name,'Contact Information')]");
        public WindowsElement AccountNameSelected => FindElement("XPath:.//*[contains(@Name,'Account Name')]/../../../following-sibling::*//*[contains(@AutomationId,'CompanyPicker')]//*[@ClassName='ComboBoxItem']");
        public WindowsElement CompanyPhoneCode => FindElement("XPath:.//*[contains(@AutomationId,'CountryCodePicker')]");
        public WindowsElement CompanyPhoneCodeSelected => FindElement("XPath:.//*[contains(@AutomationId,'CountryCodePicker')]/*[@ClassName='ComboBoxItem']");
        public WindowsElement CompanyPhoneNumber => FindElement("XPath:.//*[contains(@AutomationId,'CompanyPhoneNumberEntry')]");
        public WindowsElement CompanyWebsite => FindElement("XPath:.//*[contains(@Name,'Company Website')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement CompanyAddressL1 => FindElement("XPath:.//*[contains(@Name,'Company Address Line 1')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement CompanyAddress2 => FindElement("XPath:.//*[contains(@Name,'Company Address Line 2')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement CompanyAddress3 => FindElement("XPath:.//*[contains(@Name,'Address Line 3')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement Country => FindElement("XPath:.//*[contains(@AutomationId,'CountryPicker')]");
        public WindowsElement State => FindElement("XPath:.//*[contains(@AutomationId,'StatePicker')]");

        #endregion

    }
}
