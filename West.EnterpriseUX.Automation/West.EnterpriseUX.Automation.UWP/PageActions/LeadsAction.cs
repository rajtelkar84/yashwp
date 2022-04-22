using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class LeadsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly LeadsPage _pageInstance;
        private readonly OpportunityPage _pageInstanceOpportunity;
        private readonly OpportunityAction _opportunityAction;

        public LeadsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new LeadsPage(_session);
            _pageInstanceOpportunity = new OpportunityPage(_session);
            _opportunityAction = new OpportunityAction(_session);
        }

        #region New

        public void SearchInbox(String inbox)
        {
            ClickElement(_pageInstance.Inbox);
            ClearElement(_pageInstance.Inbox);
            EnterText(_pageInstance.Inbox, inbox);
            ClickElement(_pageInstance.InboxSearchButton);
            LogInfo("Searched for " + inbox);
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateLeads()
        {
            ClickElement(_pageInstance.CreateLeads);
            LogInfo("Clicked on Create Lead");
            WaitForLoadingToDisappear();
        }

        public void EnterSalutation(String salutation)
        {
            ClickElement(_pageInstance.Salutation);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(salutation));
            LogInfo("Entered Salutation");
        }

        public void EnterFirstName(String FN)
        {
            ClickElement(_pageInstance.FirstName);
            ClearElement(_pageInstance.FirstName);
            EnterText(_pageInstance.FirstName, FN);
            LogInfo("Entered First Name");
        }

        public void EnterLastName(String LN)
        {
            ClickElement(_pageInstance.LastName);
            ClearElement(_pageInstance.LastName);
            EnterText(_pageInstance.LastName, LN);
            LogInfo("Entered Last Name");
        }

        public void SelectComapany(String companyValue)
        {

            ClickElement(_pageInstance.CompanyArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, companyValue);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Company Name");
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
        }

        public void ClickCreateAccount()
        {
            ClickElement(_pageInstance.CompanyArrow);
            ClickElement(_pageInstance.OptionsValue("Create CRM Account"));
            LogInfo("Clicked on Create Account");
            WaitForLoadingToDisappear();
        }


        public void EnterJobTitle(String JobTitle)
        {
            ClickElement(_pageInstance.JobTitle);
            ClearElement(_pageInstance.JobTitle);
            WaitForMoment(1);
            EnterText(_pageInstance.JobTitle, JobTitle);
            LogInfo("Entered Job Title");
        }

        public void EnterJobFunctionValue(String jobFunction)
        {
            ClickElement(_pageInstance.JobFunction);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(jobFunction));
            LogInfo("Entered Job Function");
        }

        public void EnterEmail(String Email)
        {
            ClickElement(_pageInstance.Email);
            ClearElement(_pageInstance.Email);
            EnterText(_pageInstance.Email, Email);
            LogInfo("Entered Email");
        }

        public void EnterLeadOwner(String leadOwner)
        {
            ClickElement(_pageInstance.LeadOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.LeadOwnerArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, leadOwner);
            ClickElement(_pageInstance.OptionsValue(leadOwner));
            Assert.AreEqual(leadOwner, GetAttribute(_pageInstance.LeadOwner, "Value.Value"));
            LogInfo("Verified Lead Owner  - " + leadOwner);
            LogInfo("Lead Owner Changed to " + leadOwner);
        }

        public void EnterAddress1(String address1)
        {
            ClickElement(_pageInstance.Address1);
            ClearElement(_pageInstance.Address1);
            EnterText(_pageInstance.Address1, address1);
            LogInfo("Entered Address1");
        }

        public void EnterAddress2(String address2)
        {
            ClickElement(_pageInstance.Address2);
            ClearElement(_pageInstance.Address2);
            EnterText(_pageInstance.Address2, address2);
            LogInfo("Entered Address2");
        }

        public void EnterAddress3(String address3)
        {
            ClickElement(_pageInstance.Address3);
            ClearElement(_pageInstance.Address3);
            EnterText(_pageInstance.Address3, address3);
            LogInfo("Entered Address3");
        }

        public void EnterCity(String city)
        {
            ClickElement(_pageInstance.City);
            ClearElement(_pageInstance.City);
            EnterText(_pageInstance.City, city);
            LogInfo("Entered City");
        }

        public void EnterCountry(String country)
        {
            ClickElement(_pageInstance.CountryArrow);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.CountrySearchBox);
            ClearElement(_pageInstance.CountrySearchBox);
            EnterText(_pageInstance.CountrySearchBox, country);
            ClickElement(_pageInstance.OptionsValue(country));
            LogInfo("Entered Country");
            Assert.AreEqual(country, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country  - " + country);
        }

        public void EnterState(String state)
        {
            ClickElement(_pageInstance.StateArrow);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.StateSearchBox);
            ClearElement(_pageInstance.StateSearchBox);
            EnterText(_pageInstance.StateSearchBox, state);
            ClickElement(_pageInstance.OptionsValue(state));
            LogInfo("Entered State");
            Assert.AreEqual(state, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + state);
        }

        public void EnterZipCode(String zipCode)
        {
            ClickElement(_pageInstance.ZipCode);
            ClearElement(_pageInstance.ZipCode);
            EnterText(_pageInstance.ZipCode, zipCode);
            LogInfo("Entered ZipCode");
        }

        public void EnterRegion(String region)
        {
            ClickElement(_pageInstance.Region);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(region));
            LogInfo("Entered Region");
        }

        public void EnterPhoneCode(String phCode)
        {
            ClickElement(_pageInstance.PhoneCode);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(phCode));
            LogInfo("Entered Phone Code");
        }

        public void EnterPhoneNumber(String phNo)
        {
            ClickElement(_pageInstance.PhoneNumber);
            ClearElement(_pageInstance.PhoneNumber);
            EnterText(_pageInstance.PhoneNumber, phNo);
            LogInfo("Entered Phone Number");
        }

        public void EnterWebsite(String webSite)
        {
            ClickElement(_pageInstance.WebSite);
            ClearElement(_pageInstance.WebSite);
            EnterText(_pageInstance.WebSite, webSite);
            LogInfo("Entered WebSite");
        }

        public void EnterChannelSource(String channelSource)
        {
            ClickElement(_pageInstance.ChannelSource);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(channelSource));
            LogInfo("Entered Channel Source");
        }

        public void EnterChannelSourceDetails(String channelSourceDetails)
        {
            ClickElement(_pageInstance.ChannelSourceDetails);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(channelSourceDetails));
            LogInfo("Entered Channel Source Details");
        }

        public void EnterComments(String comments)
        {
            EnterText(_pageInstance.Region, Keys.Tab);
            WaitForMoment(3);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            LogInfo("Entered Comments - " + comments);
        }

        public void ClickOnCreateButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on Create Button");
            WaitForLoadingToDisappear();
            LeadStatus("Assigned");
        }

        public void ClickOnSaveAndCloseButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.SaveAndCloseButton);
            LogInfo("Clicked on Save And Close Button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnEngagedButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.EngagedButton);
            LogInfo("Clicked on Engaged Button");
            WaitForLoadingToDisappear();
            LeadStatus("Engaged");
        }

        public void ClickOnWorkingButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.WorkingButton);
            LogInfo("Clicked on Working Button");
            WaitForLoadingToDisappear();
            LeadStatus("Working");
        }

        public void ClickOnUpdateButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.UpdateButton);
            LogInfo("Clicked on Update Button");
            WaitForLoadingToDisappear();
        }

        public void VerifyQualifyPopupHeader()
        {
            if (Exists(_pageInstance.QualifyHeader))
            {
                ClickElement(_pageInstance.UpdateButton);
                LogInfo("Clicked on Update Button for 2nd time");
            }
        }

        public void EditLead()
        {
            ClickElement(_pageInstance.EditLead);
            LogInfo("Clicked on Edit Lead");
            WaitForLoadingToDisappear();
        }

        public void ClickOnViewLead()
        {
            ClickElement(_pageInstance.ViewLead);
            LogInfo("Clicked on View Lead");
            WaitForLoadingToDisappear();
        }

        public void ReopenLead()
        {
            ClickElement(_pageInstance.ReOpenLead);
            LogInfo("Clicked on Reopen Lead");
            ClickElement(_pageInstance.OptionsValue("Yes"));
            LogInfo("Clicked on Reopen Lead Confirmation as YES");
            WaitForLoadingToDisappear();
        }

        public void ClickBackButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.BackButton);
            try
            {
                if (Exists(_pageInstance.BackButton))
                {
                    ClickElement(_pageInstance.BackButton);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on Back button in first chance");
            }
            WaitForMoment(2);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Back button");
        }

        public void ValidateCreatedLeadsInInboxGrid(String firstName, String lastName, String city, String jobTitle, String jobFun, String leadOwner, String status, String topic, String companyName, String country)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> rowValues = GetFirstRowValues();
            Assert.AreEqual(topic, rowValues[0]);
            Assert.IsTrue(companyName.Equals(rowValues[1], StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(firstName, rowValues[2]);
            Assert.AreEqual(lastName, rowValues[3]);
            Assert.AreEqual(jobTitle, rowValues[4]);
            //Assert.AreEqual(country, rowValues[5]);
            try
            {
                _opportunityAction.ScrollHorizontally(1);
                Assert.AreEqual(status, _opportunityAction.GetCellValueInInbox("R1C7"));
                Assert.AreEqual(leadOwner, _opportunityAction.GetCellValueInInbox("R1C9"));
                LogInfo("Verified Created Lead in Inbox and status is " + status);
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify the values from 6th column, but created lead is displayed in the inbox");
            }
           
        }

        public void QualifyLead()
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Qualify"));
            LogInfo("Selected Close-Qualify");
            ClickElement(_pageInstance.MainContact);
            LogInfo("Clicked on Main Contact Generic Picker");
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Contact in the first row");
            ClickElement(_pageInstance.QualifyButton);
            LogInfo("Clicked on Qualify button");
            WaitForLoadingToDisappear();
            WaitForLoadingToDisappear();
        }

        public void DisqualifyLead(String disQualifyReason, String otherReason)
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Disqualify"));
            ClickElement(_pageInstance.DisQualifyPicker);
            WaitForMoment(1);
            ClickElement(_pageInstance.OptionsValue(disQualifyReason));
            if (disQualifyReason == "Other")
            {
                ClickElement(_pageInstance.OthersReason);
                ClearElement(_pageInstance.OthersReason);
                EnterText(_pageInstance.OthersReason, otherReason);
                LogInfo("Entered other reason");
            }
            ClickElement(_pageInstance.DisQualifyButton);
            WaitForMoment(2);
            ClickElement(_pageInstance.DisqualifyConfirmationYes);
            WaitForLoadingToDisappear();
            LogInfo("Lead is DisQualified");
        }

        public void CreateContact()
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Qualify"));
            LogInfo("Selected Close-Qualify");
            ClickElement(_pageInstance.MainContact);
            LogInfo("Clicked on Main Contact Generic Picker");
            ClickElement(_pageInstance.CreateContact);
            LogInfo("Clicked on Create Contact Button");
        }

        public void SearchCreatedContact(String firstName, String lastName)
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Qualify"));
            LogInfo("Selected Close-Qualify");
            ClickElement(_pageInstance.MainContact);
            LogInfo("Clicked on Main Contact Generic Picker");
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, firstName);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            Assert.AreEqual(firstName + " " + lastName, GetAttribute(_pageInstance.MainContactFields, "Value.Value"));
            LogInfo("Verified Main Contact Fields - " + firstName + " " + lastName);
        }

        public void ClickToggleSwitchs()
        {
            ClickElement(_pageInstance.AllowEmail);
            LogInfo("Clicked on Allow Email Switch");
            ClickElement(_pageInstance.AllowPhoneCalls);
            LogInfo("Clicked on Allow Phone Calls Switch");
            ClickElement(_pageInstance.AllowBulkEmails);
            LogInfo("Clicked on Allow Bulk Emails Switch");
            ClickElement(_pageInstance.AllowMail);
            LogInfo("Clicked on Allow Mail Switch");
        }

        public void NewLeadStatus()
        {
            Assert.AreEqual("New", GetAttribute(_pageInstance.NewLeadStatus, "Value.Value"));
            LogInfo("Verified Lead Status is New");
        }

        public void LeadStatus(String status)
        {
            Assert.AreEqual(status, GetAttribute(_pageInstance.LeadStatusPicker, "Name"));
            LogInfo("Verified Lead Status - " + status);
        }

        public void VerifyDisqualifyReasonField(String disqualifyReason)
        {
            Assert.AreEqual(disqualifyReason, GetAttribute(_pageInstance.DisqualifyReasonField, "Value.Value"));
            LogInfo("Verified Disqualify Reason Field - " + disqualifyReason);
        }

        /// <summary>
        /// To prospects
        /// </summary>
        ///  <param name="salutation"></param>
        /// <param name="firstNameProspect"></param>
        /// <param name="lastNameProspect"></param>
        /// <param name="companyName"></param>
        /// <param name="JobTitle"></param>
        /// <param name="JobFunction"></param>
        /// <param name="email"></param>
        ///  /// <param name="topic"></param>
        public void EnterLeadMandatoryDetails(String salutation, String firstName, string lastName, string companyName, String JobTitle, String JobFunction, String email, String topic)
        {
            EnterTopic(topic);
            EnterSalutation(salutation);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunctionValue(JobFunction);
            EnterEmail(email);
            NewLeadStatus();
        }

        public void EditLeadDetails(String firstName, String lastName)
        {
            EnterFirstName(lastName);
            EnterLastName(firstName);
        }

        public void VerifyLeadMandatoryDetails(String topic, String salutation, String firstName, String lastName, String companyName, String jobTitle, String JobFunction, String email)
        {
            VerifyCreatedDateAndAge(" (1 Day)");
            Assert.AreEqual(topic, GetAttribute(_pageInstance.Topic, "Value.Value"));
            LogInfo("Verified Topic - " + topic);
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationContext, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionContext, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
        }

        public void VerifyLeadPage(String topic, String salutation, String firstName, String lastName, String leadOwn, String companyName, String jobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comments)
        {
            VerifyCreatedDateAndAge(" (1 Day)");
            Assert.AreEqual(topic, GetAttribute(_pageInstance.Topic, "Value.Value"));
            LogInfo("Verified Topic - " + topic);
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationContext, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionContext, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(phonecode, GetAttribute(_pageInstance.PhoneCodeContext, "Name"));
            LogInfo("Verified Phone Code - " + phonecode);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceContext, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsContext, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
            Assert.AreEqual(leadOwn, GetAttribute(_pageInstance.LeadOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner - " + leadOwn);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(add1, GetAttribute(_pageInstance.Address1, "Value.Value"));
            LogInfo("Verified Address1 - " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstance.Address2, "Value.Value"));
            LogInfo("Verified Address2 - " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstance.Address3, "Value.Value"));
            LogInfo("Verified Address3 - " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City - " + cityInfo);
            Assert.AreEqual(countryValue, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country - " + countryValue);
            Assert.AreEqual(stateValue, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + stateValue);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.ZipCode, "Value.Value"));
            LogInfo("Verified Pin Code - " + zip);
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionContent, "Name"));
            LogInfo("Verified Region Value - " + regionvalue);
            /*Assert.AreEqual(comments, GetAttribute(_pageInstance.CommentsNameField, "Value.Value"));
            LogInfo("Verified Comments - " + comments);*/
        }

        public void VerifyViewLeadPage(String topic, String salutation, String firstName, String lastName, String leadOwn, String companyName, String jobTitle, String JobFunction, String email,
           String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
           String channel, String channelDetails, String leadStatus, String comments)
        {
            Assert.IsTrue(GetAttribute(_pageInstance.CreatedDateAndDays, "Name") != null);
            LogInfo("Verified lead Created Date and lead age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            Assert.AreEqual(topic, GetAttribute(_pageInstance.Topic, "Value.Value"));
            LogInfo("Verified Topic - " + topic);
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationContext, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionContext, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(phonecode, GetAttribute(_pageInstance.PhoneCodeContext, "Name"));
            LogInfo("Verified Phone Code - " + phonecode);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceContext, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsContext, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
            Assert.AreEqual(leadOwn, GetAttribute(_pageInstance.LeadOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner - " + leadOwn);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(add1, GetAttribute(_pageInstance.Address1, "Value.Value"));
            LogInfo("Verified Address1 - " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstance.Address2, "Value.Value"));
            LogInfo("Verified Address2 - " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstance.Address3, "Value.Value"));
            LogInfo("Verified Address3 - " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City - " + cityInfo);
            Assert.AreEqual(countryValue, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country - " + countryValue);
            Assert.AreEqual(stateValue, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + stateValue);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.ZipCode, "Value.Value"));
            LogInfo("Verified Pin Code - " + zip);
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionContent, "Name"));
            LogInfo("Verified Region Value - " + regionvalue);
            LeadStatus(leadStatus);
            /*Assert.AreEqual(comments, GetAttribute(_pageInstance.CommentsNameField, "Value.Value"));
            LogInfo("Verified Comments - " + comments);*/
        }

        public void ValidateOpportunityPage(String region, String companyName)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy"), GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            LogInfo("Verified Prospect Created Date and Prospect age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.AccountNameField, "Value.Value").Equals(companyName, StringComparison.CurrentCultureIgnoreCase));
            LogInfo("Verified Account name is auto populated - " + companyName);
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated ");
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated ");
            Assert.AreEqual(region, GetAttribute(_pageInstanceOpportunity.RegionNameField, "Name"));
            LogInfo("Verified Region Value - " + region);
        }

        public void EnterLeadOtherDetails(String leadOwner, String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comment)
        {
            EnterLeadOwner(leadOwner);
            EnterWebsite(website);
            EnterAddress1(add1);
            EnterAddress2(add2);
            EnterAddress3(add3);
            EnterCity(cityInfo);
            EnterCountry(countryValue);
            EnterState(stateValue);
            EnterPhoneCode(phonecode);
            EnterPhoneNumber(phoneNumber);
            EnterZipCode(zip);
            EnterRegion(regionvalue);
            EnterChannelSource(channel);
            EnterChannelSourceDetails(channelDetails);
            EnterComments(comment);
        }

        /// <summary>
        /// </summary>
        /// <param name="salutation"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="companyName"></param>
        /// <param name="JobTitle"></param>
        /// <param name="JobFunction"></param>
        /// <param name="email"></param>
        /// <param name="leadOwner"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="address3"></param>
        /// <param name="cityInfo"></param>
        /// <param name="countryValue"></param>
        /// <param name="stateValue"></param>
        /// <param name="phoneCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="zip"></param>
        /// <param name="website"></param>
        /// <param name="regionvalue"></param>
        /// <param name="channel"></param>
        /// <param name="channelDetails"></param>
        /// <param name="comment"></param>
        /// <param name="topic"></param>
        public void EnterLeadDetails(String salutation, String firstName, String lastName, String leadOwner, String companyName, String JobTitle, String JobFunction, String email, String address1,
            String address2, String address3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comment, String topic)
        {
            EnterTopic(topic);
            EnterSalutation(salutation);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterLeadOwner(leadOwner);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunctionValue(JobFunction);
            EnterEmail(email);
            EnterAddress1(address1);
            EnterAddress2(address2);
            EnterAddress3(address3);
            EnterCity(cityInfo);
            EnterCountry(countryValue);
            EnterState(stateValue);
            EnterPhoneCode(phonecode);
            EnterPhoneNumber(phoneNumber);
            EnterZipCode(zip);
            EnterWebsite(website);
            EnterRegion(regionvalue);
            EnterChannelSource(channel);
            EnterChannelSourceDetails(channelDetails);
            NewLeadStatus();
            EnterComments(comment);
        }

        public void ClickCopyDetails()
        {
            ClickElement(_pageInstance.CopyDetails);
            LogInfo("Clicked on Copy Details");
        }

        public void VerifyFieldsAfterClickingOnCopyDetails(String add1, String add2, String add3, String cityInfo, String country, String state, String zip, String phoneNumber, String website)
        {
            Assert.AreEqual(add1, GetAttribute(_pageInstance.Address1, "Value.Value"));
            LogInfo("Verified Address 1 - " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstance.Address2, "Value.Value"));
            LogInfo("Verified Address 2 - " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstance.Address3, "Value.Value"));
            LogInfo("Verified Address 3 - " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City - " + cityInfo);
            Assert.AreEqual(country, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country  - " + country);
            Assert.AreEqual(state, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + state);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.ZipCode, "Value.Value"));
            LogInfo("Verified Zip - " + zip);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
        }

        public void CreateContactFromLeadInbox()
        {
            ClickElement(_pageInstance.OptionsValue("Create Contact"));
            LogInfo("Clicked Create Contact in Lead Deatailed Action");
            WaitForLoadingToDisappear();
        }

        public void VerifyCompanyNameField(String companyName)
        {
            Assert.AreEqual(companyName, GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            LogInfo("Verified Company name is auto populated - "+companyName);
        }


        public void VerifyMandatoryFieldsMessage()
        {
            ClickElement(_pageInstance.createButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(8);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Topic");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Salutation");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "First Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(5, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(6, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(7, "Email");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {
            ClickElement(_pageInstance.createButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(6);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Salutation");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(5, "Email");
           
        }
        #endregion

        #region Old

        public void ClickOnCompanyInformation()
        {
            ClickElement(_pageInstance.CompanyInformation);
            ClickElement(_pageInstance.CompanyInformation);
            LogInfo("Clicked on company information tab");
            WaitForLoadingToDisappear();
        }

        public void EnterMoreInfo(String MoreInfo)
        {
            ClickElement(_pageInstance.MoreInformation);
            _pageInstance.MoreInformation.SendKeys(Keys.Control + "a");
            WaitForMoment(1);
            _pageInstance.MoreInformation.SendKeys(Keys.Delete);
            WaitForMoment(1);
            EnterText(_pageInstance.MoreInformation, MoreInfo);
            LogInfo("Entered MoreInfo");
        }

        public void EnterTopic(String topic)
        {
            ClickElement(_pageInstance.Topic);
            ClearElement(_pageInstance.Topic);
            EnterText(_pageInstance.Topic, topic);
            LogInfo("Entered Topic");
        }

        public void SelectIntrestedIn(String intrestedIn)
        {
            EnterText(_pageInstance.IntrestedIn, intrestedIn);
            LogInfo("Entered intrested In");
        }

        public void SelectCampaignType(String campaignType)
        {
            EnterText(_pageInstance.CampaignType, campaignType);
            LogInfo("Entered intrested In");
        }

        public void SelectRating(String rating)
        {
            switch (rating)
            {
                case "Cold":
                    ClickElement(_pageInstance.RatingCold);
                    LogInfo("Clicked on rating cold ");
                    break;
                case "Warm":
                    ClickElement(_pageInstance.RatingWarm);
                    LogInfo("Clicked on rating warm ");
                    break;
                case "Hot":
                    ClickElement(_pageInstance.RatingHot);
                    LogInfo("Clicked on rating hot ");
                    break;

            }
        }

        public void ClickOnUpdateLeadsButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.UpdateButton);
            LogInfo("Clicked on update leads");
            WaitForLoadingToDisappear();
        }

        public void EnterLeadInformationFromProspect(string moreInfo = "More info", string topic = "topic", string intrestedIn = "Product Sales",
           string campaignType = "Customer Referral", string rating = "Cold")
        {
            EnterTopic(topic);
            EnterMoreInfo(moreInfo);
            SelectIntrestedIn(intrestedIn);
            SelectCampaignType(campaignType);
            SelectRating(rating);
            WaitForMoment(1);
        }

        public void ValidateLeadsInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.FirstName, "Value.Value"));
            Assert.AreEqual(input[1], GetAttribute(_pageInstance.LastName, "Value.Value"));

            // Assert.AreEqual(input[7], GetAttribute(_pageInstance.Topic, "Value.Value"));
        }

        public void ValidateLeadsInUpdatePageFromProspect(List<String> input)
        {
            String v = GetAttribute(_pageInstance.LeadsSourceContent, "Name");
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.FirstName, "Value.Value"));
            Assert.AreEqual(input[1], GetAttribute(_pageInstance.LastName, "Value.Value"));
            Assert.AreEqual(input[2], GetAttribute(_pageInstance.Email, "Value.Value"));
            Assert.AreEqual("Prospect", GetAttribute(_pageInstance.LeadsSourceContent, "Name"));
        }

        public void VerifyCreatedDateAndAge(String day)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy") + day, GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            LogInfo("Verified Prospect Created Date and Prospect age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
        }


        #endregion
    }

}
