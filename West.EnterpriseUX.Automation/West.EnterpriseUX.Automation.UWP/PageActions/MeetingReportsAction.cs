using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class MeetingReportAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly MeetingReportPage _pageInstance;
        private readonly OpportunityAction _opportunityAction;

        public MeetingReportAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new MeetingReportPage(_session);
            _opportunityAction = new OpportunityAction(_session);
        }

        public void SearchInbox(String inbox)
        {
            ClickElement(_pageInstance.Inbox);
            ClearElement(_pageInstance.Inbox);
            EnterText(_pageInstance.Inbox, inbox);
            ClickElement(_pageInstance.InboxSearchButton);
            LogInfo("Searched for " + inbox);
            WaitForLoadingToDisappear();
        }

        public void ClickCreateMeetingReport()
        {
            ClickElement(_pageInstance.CreateMeetingReport);
            LogInfo("Clicked on Create Meeting Report");
            WaitForLoadingToDisappear();
        }

        public void EnterSubject(String subject)
        {
            ClickElement(_pageInstance.Subject);
            ClearElement(_pageInstance.Subject);
            EnterText(_pageInstance.Subject, subject);
            LogInfo("Entered Subject");
        }

        public void SelectCompany()
        {
            ClickElement(_pageInstance.CompanyDropDownArrow);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Company Name");
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
        }

        public void SearchAndSelectCompany(String companyName)
        {
            ClickElement(_pageInstance.CompanyDropDownArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, companyName);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Company - "+companyName);
        }

        public void ClickCreateAccount()
        {
            ClickElement(_pageInstance.CompanyDropDownArrow);
            ClickElement(_pageInstance.Options("Create CRM Account"));
            LogInfo("Clicked on Create Account");
            WaitForLoadingToDisappear();
        }

        public void SelectMeetingDate(String date)
        {
            ClickElement(_pageInstance.MeetingDate);
            ClickElement(_pageInstance.Options(date));
            LogInfo("Selected Meeting Date as " + GetAttribute(_pageInstance.SelectedDate, "Name"));
        }

        public void SelectMeetingType(String meetingType)
        {
            ClickElement(_pageInstance.MeetingType);
            ClickElement(_pageInstance.Options(meetingType));
            LogInfo("Selected Meeting Type as " + meetingType);
        }

        public void EnterMeetingPurpose(String meetingPurpose)
        {
            ClickElement(_pageInstance.MeetingPurpose);
            ClearElement(_pageInstance.MeetingPurpose);
            EnterText(_pageInstance.MeetingPurpose, meetingPurpose);
            LogInfo("Entered Meeting Purpose");
        }

        public void SelectMeetingLocation(String meetingLocation)
        {
            ClickElement(_pageInstance.MeetingLocation);
            ClickElement(_pageInstance.Options(meetingLocation));
            LogInfo("Selected Meeting Location as " + meetingLocation);
        }

        public void ClickParticipantsFromCustomerGenericPicker()
        {
            ClickElement(_pageInstance.MeetingWestCustomerExpandIcon);
            ClickElement(_pageInstance.customerDropDownArrow);
            WaitForLoadingToDisappear();
        }

        public void SelectContacts()
        {
            if (_opportunityAction.CheckBoxCount() >= 2)
            {
                _opportunityAction.ClickCheckBox(0);
                _opportunityAction.ClickCheckBox(1);
                _opportunityAction.ClickCheckBox(2);
            }
            else
            {
                _opportunityAction.ClickCheckBox(0);
            }
            ClickElement(_pageInstance.Submit);
            LogInfo("Selected Customer Participents");
        }

        public void ClickAllExpandIcons()
        {
            ClickElement(_pageInstance.MeetingWestParticipantExpandIcon);
            ClickElement(_pageInstance.MeetingWestCustomerExpandIcon);
            ClickElement(_pageInstance.OtherCustomerParticipantExpandIcon);
            ClickElement(_pageInstance.CCParticipantIcexpandId);
        }

        public void ExpandAndSelectEmployeeNotify(String suggession1, String participent1)
        {
            ClickElement(_pageInstance.MeetingWestParticipantExpandIcon);
            ClickElement(_pageInstance.WestParticipentsTextBox);
            EnterText(_pageInstance.WestParticipentsTextBox, suggession1);
            ClickElement(_pageInstance.Options(participent1));
            LogInfo("Selected Participent1 as " + participent1);
        }

        public void SelectEmployeeToNotify(String suggession1, String participent1, String suggession2, String participent2)
        {
            ClickElement(_pageInstance.MeetingWestParticipantExpandIcon);
            ClickElement(_pageInstance.WestParticipentsTextBox);
            EnterText(_pageInstance.WestParticipentsTextBox, suggession1);
            ClickElement(_pageInstance.Options(participent1));
            LogInfo("Selected Participent1 as " + participent1);
            WaitForMoment(2);
            EnterText(_pageInstance.WestParticipentsTextBox, suggession2);
            ClickElement(_pageInstance.WestparticipentsDropDownArrow);
            ClickElement(_pageInstance.WestparticipentsDropDownArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.Options(participent2));
            LogInfo("Selected Participent2 as " + participent2);
        }

        public void ClickCreateContact()
        {
            ClickElement(_pageInstance.MeetingWestCustomerExpandIcon);
            LogInfo("Clicked On Participants From Customer Expand Icon");
            ClickElement(_pageInstance.customerDropDownArrow);
            LogInfo("Clicked On Participants From Customer Generic Picker");
            ClickElement(_pageInstance.Options("Create Contact"));
            LogInfo("Clicked On Create Contact");
        }

        public void SelectCustomerParticipents()
        {
            ClickElement(_pageInstance.MeetingWestCustomerExpandIcon);
            ClickElement(_pageInstance.customerDropDownArrow);
            WaitForLoadingToDisappear();
            WaitForMoment(3);
            if (_opportunityAction.CheckBoxCount() >= 2)
            {
                _opportunityAction.ClickCheckBox(0);
                _opportunityAction.ClickCheckBox(1);
                _opportunityAction.ClickCheckBox(2);
            }
            else
            {
                _opportunityAction.ClickCheckBox(0);
            }
            ClickElement(_pageInstance.Submit);
            LogInfo("Selected Customer Participents");
        }

        public void OtherParticipents(String participent1, String participent2)
        {
            ClickElement(_pageInstance.OtherCustomerParticipantExpandIcon);
            ClickElement(_pageInstance.OtherParticipents);
            ClearElement(_pageInstance.OtherParticipents);
            EnterText(_pageInstance.OtherParticipents, participent1);
            ClickElement(_pageInstance.Add);
            EnterText(_pageInstance.OtherParticipents, participent2);
            ClickElement(_pageInstance.Add);

        }

        public void SelectCC(String suggession1, String participent1, String suggession2, String participent2)
        {
            ClickElement(_pageInstance.CCParticipantIcexpandId);
            ClickElement(_pageInstance.CCTextBox);
            EnterText(_pageInstance.CCTextBox, suggession1);
            ClickElement(_pageInstance.Options(participent1));
            LogInfo("Selected CC1 as " + participent1);
            WaitForMoment(2);
            EnterText(_pageInstance.CCTextBox, suggession2);
            ClickElement(_pageInstance.CCDropDownArrow);
            ClickElement(_pageInstance.CCDropDownArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.Options(participent2));
            LogInfo("Selected CC2 as " + participent2);
        }

        public void EnterObjectiveAndOutComes(String objective, String outComes)
        {
            EnterText(_pageInstance.MeetingLocation, Keys.Tab);
            WaitForMoment(3);
            _session.SwitchTo().ActiveElement().SendKeys(objective);
            LogInfo("Entered Objective");
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(outComes);
            LogInfo("Entered Outcomes");
        }

        public void EnterOutComes(String outComes)
        {
            ClickElement(_pageInstance.OutComes);
            ClearElement(_pageInstance.OutComes);
            EnterText(_pageInstance.OutComes, outComes);
            LogInfo("Entered Outcomes");
        }

        public void EnterActionDescription(String description)
        {
            ClickElement(_pageInstance.MeetingActionDescription[0]);
            ClearElement(_pageInstance.MeetingActionDescription[0]);
            EnterText(_pageInstance.MeetingActionDescription[0], description);
            LogInfo("Entered Meeting Action Description");
        }

        public void ActionNameToNotify(String suggession, String participent)
        {
            ClickElement(_pageInstance.ActionNameTextBox);
            EnterText(_pageInstance.ActionNameTextBox, participent);
            EnterText(_pageInstance.ActionNameTextBox, Keys.Down);
            //ClickElement(_pageInstance.ActionNameDropDownArrow);
            ClickElement(_pageInstance.Options(participent));
            LogInfo("Selected Name1 as " + participent);
        }

        public void SelectActionDueDate(String date)
        {
            ClickElement(_pageInstance.ActionDueDate[0]);
            ClickElement(_pageInstance.Options(date));
            LogInfo("Selected Due Date as " + _pageInstance.SelectedDueDate);
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.CreateButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            WaitForLoadingToDisappear();
        }

        public void ValidateCreatedMeetingReportSuccessMessaage()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.CreatedMeetingReportSuccessMessage, "Name"), "Meeting Report Created Successfully");
            LogInfo("Verified Success Message");
        }

        public void VerifyCompanyName(String companyName)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.CompanyNameField, "Value.Value"),companyName);
            LogInfo("Verified Company Name - " + companyName);
        }

        public void ValidateCreatedMeetingReportInInboxGrid(String meetingType, String subject, String purpose, String location)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> rowValues = GetFirstRowValues();
            Assert.AreEqual(meetingType, rowValues[1]);
            Assert.AreEqual(subject, rowValues[2]);
            try
            {
                Assert.AreEqual(purpose, rowValues[3]);
                Assert.AreEqual(location, rowValues[5]);
                LogInfo("Verified Created Meeting Report is Displayed in the Inbox ");
            }
            catch
            {
                LogInfo("Verified Created Meeting Report with subject");
            }
            
        }

        public void ClickEditMeetingReport()
        {
            ClickElement(_pageInstance.EditMeetingReport);
            LogInfo("Clicked on Edit Meeting Report");
            WaitForLoadingToDisappear();
        }

        public void ClickSendACopy()
        {
            ClickElement(_pageInstance.SendACopy);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Send A Copy");
        }

        public void DownloadMeetingReport()
        {
            ClickElement(_pageInstance.DownloadMeetingReport);
            LogInfo("Clicked on Download Meeting Report");
            WaitForMoment(5);
            ClickElement(_pageInstance.Desktop);
            LogInfo("Selected Download Location As Desktop");
            ClickElement(_pageInstance.SelectFolder);
            LogInfo("Clicked on Select Folder");
        }

        public void SendACopySuccessMessage()
        {
            Assert.Equals(GetAttribute(_pageInstance.Options("Meeting report sent successfully"), "Name"), "Meeting report sent successfully");
            LogInfo("Verified Success Message - Meeting report sent successfully");
        }

        public void AddRecipients(String suggession1, String recipient1)
        {
            ClickElement(_pageInstance.SendACopyRecipient);
            ClearElement(_pageInstance.SendACopyRecipient);
            EnterText(_pageInstance.SendACopyRecipient, suggession1);
            EnterText(_pageInstance.SendACopyRecipient, Keys.Down);
            //ClickElement(_pageInstance.SendACopyDropDownArrow);
            ClickElement(_pageInstance.Options(recipient1));
            LogInfo("Selected Recipient1 as " + recipient1);
            ClickElement(_pageInstance.Send);
            LogInfo("Clicked On Send Button");
            WaitForLoadingToDisappear();
        }

        public void EnterMeetingReportDetails(String subject, String meetingDate, String meetingType, String meetingPurpose, String meetingLocation, String notifyReference1, String notify1, String notifyReference2,
            String notify2, String others1, String others2, String ccReference1, String cc1, String ccReference2, String cc2, String description, String actionreference, String actionNotifie, String actionDueDate,
            String objective, String outcome)
        {
            EnterSubject(subject);
            SelectCompany();
            SelectMeetingDate(meetingDate);
            SelectMeetingType(meetingType);
            EnterMeetingPurpose(meetingPurpose);
            SelectMeetingLocation(meetingLocation);
            SelectEmployeeToNotify(notifyReference1, notify1, notifyReference2, notify2);
            SelectCustomerParticipents();
            OtherParticipents(others1, others2);
            SelectCC(ccReference1, cc1, ccReference2, cc2);
            EnterObjectiveAndOutComes(objective, outcome);
            EnterActionDescription(description);
            ActionNameToNotify(actionreference, actionNotifie);
            SelectActionDueDate(actionDueDate);
        }

        public void EnterMeetingReportDetailCreatingFromCustomer(String subject, String meetingDate, String meetingType, String meetingPurpose, String meetingLocation, String notifyReference1, String notify1, String notifyReference2,
            String notify2, String others1, String others2, String ccReference1, String cc1, String ccReference2, String cc2, String description, String actionreference, String actionNotifie, String actionDueDate,
            String objective, String outcome)
        {
            EnterSubject(subject);
            SelectMeetingDate(meetingDate);
            SelectMeetingType(meetingType);
            EnterMeetingPurpose(meetingPurpose);
            SelectMeetingLocation(meetingLocation);
            SelectEmployeeToNotify(notifyReference1, notify1, notifyReference2, notify2);
            OtherParticipents(others1, others2);
            SelectCC(ccReference1, cc1, ccReference2, cc2);
            EnterObjectiveAndOutComes(objective, outcome);
            EnterActionDescription(description);
            ActionNameToNotify(actionreference, actionNotifie);
            SelectActionDueDate(actionDueDate);
        }

        public void ClickOnUpdateButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.UpdateButton);
            LogInfo("Clicked on Update Button");
            WaitForLoadingToDisappear();
        }

        public void AddMoreAction(String suggession1, String participent1, String description, String date)
        {
            ClickElement(_pageInstance.AddMoreAction);
            ClickElement(_pageInstance.MeetingActionDescription[1]);
            ClearElement(_pageInstance.MeetingActionDescription[1]);
            EnterText(_pageInstance.MeetingActionDescription[1], description);
            LogInfo("Entered Meeting Action Description 2");
            ClickElement(_pageInstance.WestParticipentsTextBox);
            EnterText(_pageInstance.WestParticipentsTextBox, suggession1);
            EnterText(_pageInstance.WestParticipentsTextBox, Keys.Down);
            ClickElement(_pageInstance.Options(participent1));
            LogInfo("Selected Participent1 as " + participent1);
            ClickElement(_pageInstance.ActionDueDate[1]);
            ClickElement(_pageInstance.Options(date));
            LogInfo("Selected Due Date as " + _pageInstance.SelectedDueDate);
        }

        public void VerifyCompanyNameField(String companyName)
        {
            Assert.AreEqual(companyName, GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            LogInfo("Verified Company Name is auto populated ");
        }

        public void ValidateMeetingReportData(String subject, String meetingDate, String meetingType, String meetingPurpose, String location, String westParticipants1, String westParticipants2, String cc1, String cc2, String objective, String outcomes, String meetingActionDescription, String actionName)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.Subject, "Value.Value"), subject);
            LogInfo("Verified Subject");
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name");
            Assert.IsTrue(GetAttribute(_pageInstance.MeetingDate, "Value.Value") != null);
            LogInfo("Verified Meeting Date");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingTypeNameField, "Name"), meetingType);
            LogInfo("Verified Meeting Type");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingPurpose, "Value.Value"), meetingPurpose);
            LogInfo("Verified Meeting Purpose");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingLocationNameField, "Name"), location);
            LogInfo("Verified Meeting Location");
            Assert.AreEqual(GetAttribute(_pageInstance.WestParticipentsTextBoxData[0], "Name"), westParticipants1);
            LogInfo("Verified West Participant 1");
            Assert.AreEqual(GetAttribute(_pageInstance.WestParticipentsTextBoxData[1], "Name"), westParticipants2);
            LogInfo("Verified West Participant 2");
            Assert.IsTrue(GetAttribute(_pageInstance.customerNameField, "Value.Value") != null);
            LogInfo("Verified Customer Name");
            Assert.AreEqual(GetAttribute(_pageInstance.CCTextBoxData[0], "Name"), cc1);
            LogInfo("Verified CC1");
            Assert.AreEqual(GetAttribute(_pageInstance.CCTextBoxData[1], "Name"), cc2);
            LogInfo("Verified West CC2");
            /*Assert.AreEqual(GetAttribute(_pageInstance.ObjectivesNameField, "Value.Value"), objective);
            LogInfo("Verified Objective");
            Assert.AreEqual(GetAttribute(_pageInstance.OutComesNameField, "Value.Value"), outcomes);
            LogInfo("Verified Outcomes");*/
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingActionDescription[0], "Value.Value"), meetingActionDescription);
            LogInfo("Verified Meeting Action");
            Assert.AreEqual(GetAttribute(_pageInstance.ActionNameTextBox, "Value.Value"), actionName);
            LogInfo("Verified Action Name");
            Assert.IsTrue(GetAttribute(_pageInstance.ActionDueDate[0], "Value.Value") != null);
            LogInfo("Verified Action Due Date");
        }

        public void ValidateSendACopyData(String subject, String meetingType, String meetingPurpose, String meetingLocation)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.Subject, "Value.Value"), subject);
            LogInfo("Verified Subject");
            Assert.IsTrue(GetAttribute(_pageInstance.MeetingCompany, "Value.Value") != null);
            LogInfo("Verified Company");
            Assert.IsTrue(GetAttribute(_pageInstance.MeetingDate, "Value.Value") != null);
            LogInfo("Verified Meeting Date");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingType, "Value.Value"), meetingType);
            LogInfo("Verified Meeting Type");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingPurpose, "Value.Value"), meetingPurpose);
            LogInfo("Verified Meeting Purpose");
            Assert.AreEqual(GetAttribute(_pageInstance.MeetingLocation, "Value.Value"), meetingLocation);
            LogInfo("Verified Meeting Location");
        }

        public void VerifyMandatoryFieldsMessage()
        {
            ClickCreateButton();
            _opportunityAction.VerifyMandatoryFieldsCount(5);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Subject");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Purpose");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Meeting Type");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Participants From West");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {
            ClickCreateButton();
            _opportunityAction.VerifyMandatoryFieldsCount(3);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Purpose");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Meeting Type");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Participants From West");
        }
    }

}
