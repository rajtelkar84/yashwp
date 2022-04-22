using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class LeadsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public LeadsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateLeads => FindElement("XPath:.//*[contains(@Name,'Create Lead')]");
        public WindowsElement Salutation => FindElement("XPath://*[@AutomationId='AIdLeadSalutationPicker']");
        public WindowsElement SalutationContext => FindElement("XPath://*[@AutomationId='AIdLeadSalutationPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement FirstName => FindElement(("XPath://*[@AutomationId='AIdLeadFirstNameEntry']"));
        public WindowsElement LastName => FindElement("XPath://*[@AutomationId='AIdLeadLastNameEntry']");
        public WindowsElement CompanyArrow => FindElement("XPath://*[@AutomationId='AIdLeadCompanyNameTextPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement CompanyNameField => FindElement("XPath://*[@AutomationId='AIdLeadCompanyNameTextPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement JobTitle => FindElement("XPath://*[@AutomationId='AIdLeadJobTitleEntry']");
        public WindowsElement JobFunction => FindElement("XPath://*[@AutomationId='AIdLeadJobFunctionPicker']");
        public WindowsElement JobFunctionContext => FindElement("XPath://*[@AutomationId='AIdLeadJobFunctionPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Email => FindElement("XPath://*[@AutomationId='AIdLeadEmailAddressEntry']");
        public WindowsElement LeadOwner => FindElement("XPath://*[@AutomationId='AIdLeadLeadOwnerComboBox']/descendant::*[@ClassName='TextBox']");
        public WindowsElement LeadOwnerArrow => FindElement("XPath://*[@AutomationId='AIdLeadLeadOwnerComboBox']/descendant::*[@ClassName='Image']");
        public WindowsElement Address1 => FindElement("XPath://*[@AutomationId='AIdLeadCompanyAddressLine1TextEntry']");
        public WindowsElement Address2 => FindElement("XPath://*[@AutomationId='AIdLeadCompanyAddressLine2TextEntry']");
        public WindowsElement Address3 => FindElement("XPath://*[@AutomationId='AIdLeadCompanyAddressLine3TextEntry']");
        public WindowsElement City => FindElement("XPath://*[@AutomationId='AIdLeadCityEntry']");
        public WindowsElement CountryArrow => FindElement("XPath://*[@AutomationId='AIdLeadCountryPicker']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement CountryNameField => FindElement("XPath://*[@AutomationId='AIdLeadCountryPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement CountrySearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement StateArrow => FindElement("XPath://*[@AutomationId='AIdLeadStateOrProvincePicker']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement StateNameField => FindElement("XPath://*[@AutomationId='AIdLeadStateOrProvincePicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement StateSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement ZipCode => FindElement("XPath://*[@AutomationId='AIdLeadPostalCodeEntry']");
        public WindowsElement Region => FindElement("XPath://*[@AutomationId='AIdLeadRegionPciker']");
        public WindowsElement RegionContent => FindElement("XPath://*[@AutomationId='AIdLeadRegionPciker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Leadstatus => FindElement("XPath://*[@AutomationId='AIdLeadStatusPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneCode => FindElement("XPath://*[@AutomationId='AIdLeadPhoneNumberPicker']");
        public WindowsElement PhoneCodeContext => FindElement("XPath://*[@AutomationId='AIdLeadPhoneNumberPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneNumber => FindElement("XPath://*[@AutomationId='AIdLeadSPhoneNumberEntry']");
        public WindowsElement WebSite => FindElement("XPath://*[@AutomationId='AIdHyperlinkEditorURLEntry']");
        public WindowsElement ChannelSource => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourcePicker']");
        public WindowsElement ChannelSourceContext => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourcePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ChannelSourceDetails => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourceDetailPicker']");
        public WindowsElement ChannelSourceDetailsContext => FindElement("XPath://*[@AutomationId='AIdLeadChannelSourceDetailPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Comments => FindElement("XPath://*[@AutomationId='AIdLeadAdditionalInformationEditor']");
        public WindowsElement CommentsNameField => FindElement("XPath://*[@AutomationId='AIdLeadAdditionalInformationEditor']/descendant::*[@ClassName='TextBox']");
        public WindowsElement AllowEmail => FindElement("XPath://*[@AutomationId='AIdLeadAllowEmailSwitch']");
        public WindowsElement AllowPhoneCalls => FindElement("XPath://*[@AutomationId='AIdLeadAllowPhoneCallSwtich']");
        public WindowsElement AllowBulkEmails => FindElement("XPath://*[@AutomationId='AIdLeadAllowBulkMailSwtich']");
        public WindowsElement AllowMail => FindElement("XPath://*[@AutomationId='AIdLeadAllowMailSwitch']");
        public WindowsElement createButton => FindElement("XPath://*[@AutomationId='AIdLeadCreateOrUpdateButton']");
        public WindowsElement SaveAndCloseButton => FindElement("XPath:.//Button[contains(@Name,'Save & Close')]");
        public WindowsElement EngagedButton => FindElement("XPath:.//Button[contains(@Name,'Engaged')]");
        public WindowsElement WorkingButton => FindElement("XPath:.//Button[contains(@Name,'Working')]");
        public WindowsElement UpdateButton => FindElement("XPath:.//*[@Name='Update']");
        public WindowsElement QualifyHeader => FindElement("XPath://*[@AutomationId='AIdQualifyLeadHeaderLabel']");
        public WindowsElement Status => FindElement("XPath://*[@AutomationId='AIdQualifyLeadStatusCustomPicker']");
        public WindowsElement DropDown => FindElement("XPath://*[@Name='Dropdown']/descendant::*[@ClassName='Image']");
        public WindowsElement MainContact => FindElement("XPath://*[@AutomationId='AIdQualifyLeadMainContactGenericPickerControl']/descendant::*[@ClassName='Image']");
        public WindowsElement MainContactFields => FindElement("XPath://*[@AutomationId='AIdQualifyLeadMainContactGenericPickerControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement CreateContact => FindElement("XPath://*[@Name='Create Contact']");
        public WindowsElement DisQualifyPicker => FindElement("XPath://*[@AutomationId='AIdQualifyLeadPrimaryDisqualifyReasonActionFieldControl']");
        public WindowsElement OthersReason => FindElement("XPath://*[@AutomationId='AIdQualifyLeadShowDisQualifyReasonCustomEntry']");
        public WindowsElement QualifyButton => FindElement("XPath:.//*[@Name='Qualify']");
        public WindowsElement DisQualifyButton => FindElement("XPath:.//*[@Name='Disqualify']");
        public WindowsElement DisqualifyConfirmationYes => FindElement("XPath:.//*[@Name='Yes']");
        public WindowsElement DisqualifyConfirmationNo => FindElement("XPath:.//*[@Name='No']");
        public WindowsElement ReOpenLead => FindElement("XPath:.//*[contains(@Name,'Reopen Lead')]");
        public WindowsElement ViewLead => FindElement("XPath:.//*[contains(@Name,'View Lead')]");
        public WindowsElement EditLead => FindElement("XPath:.//*[contains(@Name,'Edit Lead')]");
        public WindowsElement CompanyInformation => FindElement("XPath:.//*[contains(@Name,'Company Information')]");
        public WindowsElement LeadsSourceContent => FindElement("XPath:.//*[contains(@AutomationId,'LeadSourcePicker')]/*[contains(@AutomationId,'ContentPresenter')]");
        public WindowsElement Topic => FindElement("XPath://*[@AutomationId='AIdLeadTopicEntry']");
        public WindowsElement MoreInformation => FindElement("XPath:.//*[contains(@Name,'More Infomation')]/../../../following-sibling::*");
        public WindowsElement IntrestedIn => FindElement("XPath:.//*[contains(@AutomationId,'InterestedInPicker')]");
        public WindowsElement IntrestedInSelectedText => FindElement("XPath:.//*[contains(@AutomationId,'InterestedInPicker')]/*[contains(@AutomationId,'ContentPresenter')]");
        public WindowsElement CampaignType => FindElement("XPath:.//*[contains(@AutomationId,'CampaignPicker')]");
        public WindowsElement CampaignTypeSelectedText => FindElement("XPath:.//*[contains(@AutomationId,'CampaignPicker')]/*[contains(@AutomationId,'ContentPresenter')]");
        public WindowsElement RatingCold => FindElement("XPath:.//*[contains(@Name,'Cold')]");
        public WindowsElement RatingWarm => FindElement("XPath:.//*[contains(@Name,'Warm')]");
        public WindowsElement RatingHot => FindElement("XPath:.//*[contains(@Name,'Hot')]");
        public WindowsElement BackButton => FindElement("XPath:.//*[@Name='Back' or @AutomationId='Back']");
        public WindowsElement NewLeadStatus => FindElement("XPath://*[@AutomationId='AIdLeadStatusFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement LeadStatusPicker => FindElement("XPath://*[@AutomationId='AIdLeadStatusPicker']/descendant::*[@AutomationId='ContentPresenter']");
        public WindowsElement CreatedDateAndDays => FindElement("XPath://*[@AutomationId='AIdEntityInsightCreateDateLabel']");
        public WindowsElement DisqualifyReasonField => FindElement("XPath://*[@AutomationId='AIdLeadDisqualifyReasonEntry']");
        public WindowsElement CopyDetails => FindElement("XPath://*[@AutomationId='AIdLeadCheckBoxEntry']");
        public WindowsElement ValuebyRowAndColumnInGrid(string rowAndColumnInGrid)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'{rowAndColumnInGrid}')]");
        }
        public WindowsElement OptionsValue(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }
    }
}
