using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ProspectsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ProspectsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateProspects => FindElement("XPath:.//*[contains(@Name,'Create Prospect')]");
        public WindowsElement Salutation => FindElement("XPath://*[@AutomationId='AIdProspectSalutationPicker']");
        public WindowsElement SalutationValidation => FindElement("XPath://*[@AutomationId='AIdProspectSalutationPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement FN => FindElement(("XPath://*[@AutomationId='AIdProspectFirstNameEntry']"));
        public WindowsElement LN => FindElement("XPath://*[@AutomationId='AIdProspectLastNameEntry']");
        public WindowsElement CompanyArrow => FindElement("XPath://*[@AutomationId='AIdProspectCompanyNamePicker']/descendant::*[@ClassName='Image']");
        public WindowsElement CompanyNameField => FindElement("XPath://*[@AutomationId='AIdProspectCompanyNamePicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement JobTitle => FindElement("XPath://*[@AutomationId='AIdProspectJobTitleEntry']");
        public WindowsElement JobFunction => FindElement("XPath://*[@AutomationId='AIdProspectjobFunctionPciker']");
        public WindowsElement JobFunctionValidation => FindElement("XPath://*[@AutomationId='AIdProspectjobFunctionPciker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Email => FindElement("XPath://*[@AutomationId='AIdProspectEmailAddressEntry']");
        public WindowsElement ProspectOwner => FindElement("XPath://*[@AutomationId='AIdProspectCountryPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ProspectOwnerArrow => FindElement("XPath://*[@AutomationId='AIdProspectCountryPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement Address1 => FindElement("XPath://*[@AutomationId='AIdProspectAddressStreet1Entry']");
        public WindowsElement Address2 => FindElement("XPath://*[@AutomationId='AIdProspectAddressStreet2Entry']");
        public WindowsElement Address3 => FindElement("XPath://*[@AutomationId='AIdProspectAddressStreet3Entry']");
        public WindowsElement City => FindElement("XPath://*[@AutomationId='AIdProspectCityEntry']");
        public WindowsElement CountryArrow => FindElement("XPath:(//*[@AutomationId='AIdProspectCountryPicker']/descendant::*[contains(@ClassName,'Image')])[3]");
        public WindowsElement CountryNameField => FindElement("XPath:(//*[@AutomationId='AIdProspectCountryPicker']/descendant::*[@ClassName='TextBox'])[2]");
        public WindowsElement StateArrow => FindElement("XPath://*[@AutomationId='AIdProspectStatePicker']/descendant::*[contains(@ClassName,'Image')]");
        public WindowsElement StateNameField => FindElement("XPath://*[@AutomationId='AIdProspectStatePicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ZipCode => FindElement("XPath://*[@AutomationId='AIdProspectZipEntry']");
        public WindowsElement Region => FindElement("XPath://*[@AutomationId='AIdProspectRegionPicker']");
        public WindowsElement RegionValidation => FindElement("XPath://*[@AutomationId='AIdProspectRegionPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneCode => FindElement("XPath://*[@AutomationId='AIdProspectPhoneGenericPicker']");
        public WindowsElement PhoneCodeValidation => FindElement("XPath://*[@AutomationId='AIdProspectPhoneGenericPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PhoneNumber => FindElement("XPath://*[@AutomationId='AIdProspectPhoneEntry']");
        public WindowsElement WebSite => FindElement("XPath://*[@AutomationId='AIdHyperlinkEditorURLEntry']");
        public WindowsElement NewProspectStatus => FindElement("XPath://*[@AutomationId='AIdProspectStatusDefaultEntry']");
        public WindowsElement ProspectStatusPicker => FindElement("XPath://*[@AutomationId='AIdProspectStatusPicker']/descendant::*[@AutomationId='ContentPresenter']");
        public WindowsElement ChannelSource => FindElement("XPath://*[@AutomationId='AIdProspectChannelSourcePicker']");
        public WindowsElement ChannelSourceValidation => FindElement("XPath://*[@AutomationId='AIdProspectChannelSourcePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ChannelSourceDetails => FindElement("XPath://*[@AutomationId='AIdProspectChannelSourceDetailPicker']");
        public WindowsElement ChannelSourceDetailsValidation => FindElement("XPath://*[@AutomationId='AIdProspectChannelSourceDetailPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Comments => FindElement("XPath://*[@AutomationId='AIdProspectCommentsEditor']");
        public WindowsElement CommentsNameField => FindElement("XPath://*[@AutomationId='AIdProspectCommentsEditor']/descendant::*[@ClassName='TextBox']");
        public WindowsElement CreateButton => FindElement("XPath://*[@Name='Create']");
        public WindowsElement SaveAndCloseButton => FindElement("XPath://*[@Name='Save & Close']");
        public WindowsElement EngagedButton => FindElement("XPath:(//*[@Name='Engaged'])[2]");
        public WindowsElement WorkingButton => FindElement("XPath:(//*[@Name='Working'])[2]");
        public WindowsElement UpdateButton => FindElement("XPath://*[@Name='Update']");
        public WindowsElement Status => FindElement("XPath://*[@AutomationId='AIdQualifyPopupStatusPicker']");
        public WindowsElement DisQualifyPicker => FindElement("XPath://*[@AutomationId='AIdQualifyPopupDisqualifyReasonListPicker']");
        public WindowsElement OthersReason => FindElement("XPath://*[@AutomationId='AIdQualifyPopupOtherReasonEntry']");
        public WindowsElement QualifyButton => FindElement("XPath://*[@AutomationId='AIdQualifyPopupQualifyButton']");
        public WindowsElement DisQualifyButton => FindElement("XPath://*[@AutomationId='AIdQualifyPopupQualifyButton']");
        public WindowsElement DisqualifyConfirmationYes => FindElement("XPath:.//*[@Name='Yes']");
        public WindowsElement DisqualifyConfirmationNo => FindElement("XPath:.//*[@Name='No']");
        public WindowsElement EditProspects => FindElement("XPath:.//*[contains(@Name,'Edit Prospect')]");
        public WindowsElement ReOpenProspects => FindElement("XPath:.//*[contains(@Name,'Reopen Prospect')]");
        public WindowsElement ViewProspects => FindElement("XPath:.//*[contains(@Name,'View Prospect')]");
        public WindowsElement CreateLeadProspects => FindElement("XPath:.//*[contains(@Name,'Create Lead')]");
        public WindowsElement CreateContactsProspects => FindElement("XPath:.//*[contains(@Name,'Create Contact')]");
        public WindowsElement ScrollUp => FindElement("XPath://*[@AutomationId='VerticalSmallDecrease']");
        public WindowsElement ScrollDown => FindElement("XPath://Custom//*[@ClassName='RepeatButton' and @AutomationId='VerticalSmallIncrease']");
        public WindowsElement VerticalScroll => FindElement("XPath://*[@AutomationId='VerticalScrollBar']");
        public IList<WindowsElement> SucessMessageCreate => FindElements("XPath:.//*[@Name='Prospect Created Successfully']");
        public IList<WindowsElement> SucessMessageUpdate => FindElements("XPath:.//*[@Name='Updated prospect successfully']");
        public WindowsElement BackButton => FindElement("XPath:.//*[@Name='Back' or @AutomationId='Back']");
        public IList<WindowsElement> DetailActionAllRow => FindElements("XPath://Image[@AutomationId='More']");
        public IList<WindowsElement> HomeImage => FindElements("XPath://*[@AutomationId='wdLogo' or @AutomationId='Home']");
        public WindowsElement CreatedDateAndDays => FindElement("XPath://*[@AutomationId='AIdEntityInsightCreateDateLabel']");
        public WindowsElement DisqualifyReason => FindElement("XPath://*[@AutomationId='AIdProspectDisqualifyReasonEntry']");
        public WindowsElement CopyDetails => FindElement("XPath://*[@AutomationId='AIdProspectCheckBoxEntry']");
        public WindowsElement HorizontalIncreaseButton => FindElement("XPath://*[@AutomationId='HorizontalSmallIncrease']");
        public WindowsElement ProspectConvertedTo => FindElement("XPath://*[@AutomationId='AIdProspectConvertToLabel']");
        public WindowsElement ProspectConvertedDate => FindElement("XPath://*[@AutomationId='AIdProspectConvertedDateLabel']");
        public WindowsElement OptionsValue(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }
        public IList<WindowsElement> ValuebyRowAndColumnInGridRowWise(int rowNumber)
        {
            return FindElements($"XPath://*[@AutomationId=' Row" + rowNumber + "' or @Name=' Row" + rowNumber + "']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public WindowsElement RowWiseConvertedToContact(int rowNumber)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'R" + rowNumber + "C5')]");
        }

    }

}
