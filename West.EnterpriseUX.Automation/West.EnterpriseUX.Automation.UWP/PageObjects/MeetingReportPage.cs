using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class MeetingReportPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public MeetingReportPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateMeetingReport => FindElement("XPath:.//*[contains(@Name,'Create Meeting Report')]");
        public WindowsElement Subject => FindElement("XPath://*[@AutomationId='MeetingSubject']");
        public WindowsElement CompanyDropDownArrow => FindElement("XPath://*[@AutomationId='AICompanyName']/descendant::*[@ClassName='Image']");
        public WindowsElement CompanyNameField => FindElement("XPath://*[@AutomationId='AICompanyName']/descendant::*[@ClassName='TextBox']");
        public WindowsElement MeetingDate => FindElement("XPath://*[@AutomationId='MeetingDate']");
        public WindowsElement SelectedDate => FindElement("XPath:(//*[@AutomationId='DateText'])[1]");
        public WindowsElement CalanderPrevious => FindElement("XPath:.//*[@AutomationId='PreviousButton']");
        public WindowsElement CalanderNext => FindElement("XPath:.//*[@AutomationId='NextButton']");
        public WindowsElement MeetingType => FindElement("XPath://*[@AutomationId='MeetingType']");
        public WindowsElement MeetingTypeNameField => FindElement("XPath://*[@AutomationId='MeetingType']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement MeetingPurpose => FindElement("XPath://*[@AutomationId='MeetingPurpose']");
        public WindowsElement MeetingLocation => FindElement("XPath://*[@AutomationId='MeetingLocation']");
        public WindowsElement MeetingLocationNameField => FindElement("XPath://*[@AutomationId='MeetingLocation']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement MeetingWestParticipantExpandIcon => FindElement("XPath://*[@AutomationId='MeetingWestParticipantExpandIcon']");
        public WindowsElement WestParticipentsTextBox => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Input Field'])[2]");
        public IList<WindowsElement> WestParticipentsTextBoxData => FindElements("XPath://*[@AutomationId='WestParticipantListComboBox Input Field']/descendant::*[@AutomationId='TokenTextBlock']");
        public WindowsElement WestparticipentsDropDownArrow => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Dropdown Button'])[2]");
        public WindowsElement WestParticipentsClearButton => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Input Clear Button'])[2]");
        public WindowsElement MeetingWestCustomerExpandIcon => FindElement("XPath://*[@AutomationId='MeetingWestCustomerExpandIcon']");
        public WindowsElement customerDropDownArrow => FindElement("XPath://*[@AutomationId='OtherCustomerParticipantControl']/descendant::*[@ClassName='Image']");
        public WindowsElement customerNameField => FindElement("XPath://*[@AutomationId='OtherCustomerParticipantControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement SelectAnItemSecondRow => FindElement("XPath://*[@Name=' Row2']");
        public WindowsElement Submit => FindElement("XPath://*[@Name='Submit']");
        public WindowsElement OtherCustomerParticipantExpandIcon => FindElement("XPath://*[@AutomationId='OtherCustomerParticipantExpandIcon']");
        public WindowsElement OtherParticipents => FindElement("XPath://*[@AutomationId='MeetingWestCustomerEntry']");
        public WindowsElement Add => FindElement("XPath://*[@AutomationId='MeetingAddCustomerButton']");
        public WindowsElement CCParticipantIcexpandId => FindElement("XPath://*[@AutomationId='CCParticipantIcexpandId']");
        public WindowsElement CCTextBox => FindElement("XPath://*[@AutomationId='CCCustomerListComboBox Input Field']");
        public WindowsElement CCDropDownArrow => FindElement("XPath://*[@AutomationId='CCCustomerListComboBox Dropdown Button']");
        public WindowsElement CCClearButton => FindElement("XPath://*[@AutomationId='CCCustomerListComboBox Input Clear Button']");
        public IList<WindowsElement> CCTextBoxData => FindElements("XPath://*[@AutomationId='CCCustomerListComboBox Input Field']/descendant::*[@AutomationId='TokenTextBlock']");
        public WindowsElement Objectives => FindElement("XPath://*[@AutomationId='MeetingObjective']");
        public WindowsElement ObjectivesNameField => FindElement("XPath://*[@AutomationId='MeetingObjective']/descendant::*[@ClassName='TextBox']");
        public WindowsElement OutComes => FindElement("XPath://*[@AutomationId='AIdContactAdditionalInformationEditor']");
        public WindowsElement OutComesNameField => FindElement("XPath://*[@AutomationId='AIdContactAdditionalInformationEditor']/descendant::*[@ClassName='TextBox']");
        public IList<WindowsElement> MeetingActionDescription => FindElements("XPath://*[@AutomationId='MeetingActionDescription']");
        public WindowsElement ActionNameTextBox => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Input Field'])[1]");
        public WindowsElement ActionNameDropDownArrow => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Dropdown Button'])[1]");
        public WindowsElement ActionNameClearButton => FindElement("XPath:(//*[@AutomationId='WestParticipantListComboBox Input Clear Button'])[1]");
        public IList<WindowsElement> ActionDueDate => FindElements("XPath://*[@AutomationId='MeetingActionDate']");
        public WindowsElement SelectedDueDate => FindElement("XPath:(//*[@AutomationId='DateText'])[2]");
        public WindowsElement CreateButton => FindElement("XPath:.//Button[contains(@Name,'Create')]");
        public WindowsElement EditMeetingReport => FindElement("XPath://*[@Name='Edit Meeting Report']");
        public WindowsElement SendACopy => FindElement("XPath://*[@Name='Send A Copy']");
        public WindowsElement SendACopyRecipient => FindElement("XPath://*[@AutomationId='AISendCopyList Input Field']/descendant::*[@AutomationId='ContentElement']");
        public WindowsElement SendACopyDropDownArrow => FindElement("XPath://*[@AutomationId='AISendCopyList Dropdown Button']");
        public WindowsElement UpdateButton => FindElement("XPath:.//*[@Name='Update']");
        public WindowsElement Send => FindElement("XPath:.//*[@Name='Send']");
        public WindowsElement DownloadMeetingReport => FindElement("XPath:.//*[@Name='Download Meeting Report']");
        public WindowsElement Desktop => FindElement("XPath:.//*[@Name='Desktop']");
        public WindowsElement SelectFolder => FindElement("XPath:.//*[@Name='Select Folder']");
        public WindowsElement CreatedMeetingReportSuccessMessage => FindElement("XPath:.//*[@Name='Meeting Report Created Successfully']");
        public WindowsElement AddMoreAction => FindElement("XPath://*[@AutomationId='MeetingActionAddLabel']");
        public WindowsElement MeetingCompany => FindElement("XPath://*[@AutomationId='MeetingCompany']");
        public WindowsElement WestParticipantListDropdown => FindElement("XPath://*[@AutomationId='WestParticipantListComboBox Dropdown']");
        public WindowsElement MandatoryFieldsMessageCloseButton => FindElement("XPath://*[@AutomationId='AIdQualifyPopupCloseSvgImageExtension']");
        public IList<WindowsElement> Name(String Value)
        {
            return FindElements($"XPath://*[@Name='{Value}']");
        }
        public WindowsElement Options(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }
       

    }
}
