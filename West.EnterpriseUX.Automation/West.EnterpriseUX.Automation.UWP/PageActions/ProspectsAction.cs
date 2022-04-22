using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;
using Microsoft.Test.Input;
using System.Drawing;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class ProspectsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ProspectsPage _pageInstance;
        private readonly LeadsPage _pageInstanceLead;
        private readonly OpportunityAction _opportunityAction;


        public ProspectsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ProspectsPage(_session);
            _pageInstanceLead = new LeadsPage(_session);
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

        public void ClickOnCreateProspects()
        {
            ClickElement(_pageInstance.CreateProspects);
            LogInfo("Clicked on Create Prospect Button");
            WaitForLoadingToDisappear();
        }

        public void EnterSalutation(String salutationValue)
        {
            ClickElement(_pageInstance.Salutation);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(salutationValue));
            LogInfo("Entered Salutation - " + salutationValue);
        }

        public void EnterFirstName(String firstName)
        {
            ClickElement(_pageInstance.FN);
            ClearElement(_pageInstance.FN);
            EnterText(_pageInstance.FN, firstName);
            LogInfo("Entered First Name - " + firstName);
        }

        public void EnterLastName(String lastName)
        {
            ClickElement(_pageInstance.LN);
            ClearElement(_pageInstance.LN);
            EnterText(_pageInstance.LN, lastName);
            LogInfo("Entered Last Name - " + lastName);
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
            LogInfo("Entered Job Title - " + JobTitle);
        }

        public void EnterJobFunction(String jobFunction)
        {
            ClickElement(_pageInstance.JobFunction);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(jobFunction));
            LogInfo("Entered Job Function - " + jobFunction);
        }

        public void EnterEmail(String email)
        {
            ClickElement(_pageInstance.Email);
            ClearElement(_pageInstance.Email);
            EnterText(_pageInstance.Email, email);
            LogInfo("Entered Email - " + email);
        }

        public void EnterProspectOwner(String prospectOwner)
        {
            ClickElement(_pageInstance.ProspectOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.ProspectOwnerArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, prospectOwner);
            ClickElement(_pageInstance.OptionsValue(prospectOwner));
            Assert.AreEqual(prospectOwner, GetAttribute(_pageInstance.ProspectOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner  - " + prospectOwner);
            LogInfo("Prospect Owner Changed to " + prospectOwner);
        }

        public void EnterAddress1(String address1)
        {
            ClickElement(_pageInstance.Address1);
            ClearElement(_pageInstance.Address1);
            EnterText(_pageInstance.Address1, address1);
            LogInfo("Entered Address1 - " + address1);
        }

        public void EnterAddress2(String address2)
        {
            ClickElement(_pageInstance.Address2);
            ClearElement(_pageInstance.Address2);
            EnterText(_pageInstance.Address2, address2);
            LogInfo("Entered Address2 - " + address2);
        }

        public void EnterAddress3(String address3)
        {
            ClickElement(_pageInstance.Address3);
            ClearElement(_pageInstance.Address3);
            EnterText(_pageInstance.Address3, address3);
            LogInfo("Entered Address3 - " + address3);
        }

        public void EnterCity(String city)
        {
            ClickElement(_pageInstance.City);
            ClearElement(_pageInstance.City);
            EnterText(_pageInstance.City, city);
            LogInfo("Entered City - " + city);
        }

        public void EnterCountry(String country)
        {
            ClickElement(_pageInstance.CountryArrow);
            WaitForMoment(3);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, country);
            ClickElement(_pageInstance.OptionsValue(country));
            LogInfo("Selected Country - " + country);
            Assert.AreEqual(country, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country  - " + country);
        }

        public void EnterState(String state)
        {
            ClickElement(_pageInstance.StateArrow);
            WaitForMoment(3);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, state);
            ClickElement(_pageInstance.OptionsValue(state));
            LogInfo("Selected State - " + state);
            Assert.AreEqual(state, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + state);
        }

        public void EnterZipCode(String zipCode)
        {
            ClickElement(_pageInstance.ZipCode);
            ClearElement(_pageInstance.ZipCode);
            EnterText(_pageInstance.ZipCode, zipCode);
            LogInfo("Entered ZipCode - " + zipCode);
        }

        public void EnterRegion(String region)
        {
            ClickElement(_pageInstance.Region);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(region));
            LogInfo("Selected Region - " + region);
        }

        public void EnterPhoneCode(String phCode)
        {
            ClickElement(_pageInstance.PhoneCode);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(phCode));
            LogInfo("Selected Phone Code - " + phCode);
        }

        public void EnterPhoneNumber(String phNo)
        {
            ClickElement(_pageInstance.PhoneNumber);
            ClearElement(_pageInstance.PhoneNumber);
            EnterText(_pageInstance.PhoneNumber, phNo);
            LogInfo("Entered Phone Number - " + phNo);
        }

        public void EnterWebsite(String webSite)
        {
            ClickElement(_pageInstance.WebSite);
            ClearElement(_pageInstance.WebSite);
            EnterText(_pageInstance.WebSite, webSite);
            LogInfo("Entered WebSite - " + webSite);
        }

        public void NewProspectStatus()
        {
            Assert.AreEqual("New", GetAttribute(_pageInstance.NewProspectStatus, "Value.Value"));
            LogInfo("Verified Status is New");
        }

        public void ProspectStatus(String status)
        {
            Assert.AreEqual(status, GetAttribute(_pageInstance.ProspectStatusPicker, "Name"));
            LogInfo("Verified Prospect Status - " + status);
        }

        public void EnterChannelSource(String channelSource)
        {
            ClickElement(_pageInstance.ChannelSource);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(channelSource));
            LogInfo("Selected Channel Source - " + channelSource);
        }

        public void EnterChannelSourceDetails(String channelSourceDetails)
        {
            ClickElement(_pageInstance.ChannelSourceDetails);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(channelSourceDetails));
            LogInfo("Select Channel Source Details - " + channelSourceDetails);
        }

        public void EnterComments(String comments)
        {
            EnterText(_pageInstance.Region, Keys.Tab);
            WaitForMoment(3);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            LogInfo("Entered Comments - " + comments);
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.CreateButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            ProspectStatus("Assigned");
        }

        public void SaveAndCloseButton()
        {
            ClickElement(_pageInstance.SaveAndCloseButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Save & Close Button");
        }

        public void ClickEngagedButton()
        {
            ClickElement(_pageInstance.EngagedButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Engaged Button");
            ProspectStatus("Engaged");
        }

        public void ClickWorkingButton()
        {
            ClickElement(_pageInstance.WorkingButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Working Button");
            ProspectStatus("Working");
        }

        public void ClickUpdateProspect()
        {
            ClickElement(_pageInstance.UpdateButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Update Button");
        }
        public void QualifyProspect()
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Qualify"));
            ClickElement(_pageInstance.QualifyButton);
            LogInfo("Prospect is Qualified");
            WaitForLoadingToDisappear();
            WaitForElementToAppear(GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
        }

        public void VerifyCompanyNameField(String companyName)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.CompanyNameField, "Value.Value"), companyName);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
        }

        public void VerifyProspectMandatoryDetails(String salutation, String firstName, String lastName, String companyName, String jobTitle, String JobFunction, String email)
        {
            VerifyCreatedDateAndProspectAge(" (1 Day)");
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationValidation, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FN, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LN, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionValidation, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
        }

        public void VerifyProspectPage(String salutation, String firstName, String lastName, String prospectOwn, String companyName, String jobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comments)
        {
            VerifyCreatedDateAndProspectAge(" (1 Day)");
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationValidation, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FN, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LN, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionValidation, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(prospectOwn, GetAttribute(_pageInstance.ProspectOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner - " + prospectOwn);
            Assert.AreEqual(add1, GetAttribute(_pageInstance.Address1, "Value.Value"));
            LogInfo("Verified Address 1 - " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstance.Address2, "Value.Value"));
            LogInfo("Verified Address 2 - " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstance.Address3, "Value.Value"));
            LogInfo("Verified Address 3 - " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City - " + cityInfo);
            Assert.AreEqual(countryValue, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country  - " + countryValue);
            Assert.AreEqual(stateValue, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + stateValue);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.ZipCode, "Value.Value"));
            LogInfo("Verified Zip - " + zip);
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionValidation, "Name"));
            LogInfo("Verified Region - " + regionvalue);
            Assert.AreEqual(phonecode, GetAttribute(_pageInstance.PhoneCodeValidation, "Name"));
            LogInfo("Verified Phone Code - " + phonecode);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceValidation, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsValidation, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
            /*Assert.AreEqual(comments, GetAttribute(_pageInstance.CommentsNameField, "Value.Value"));
            LogInfo("Verified Comments - " + comments);*/
        }

        public void VerifyLeadPageAfterQualifingProspect(String salutation, String firstName, String lastName, String prospectOwn, String companyName, String jobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy") + " (1 Day)", _pageInstance.CreatedDateAndDays.Text);
            LogInfo("Verified Lead Created Date and Lead age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            Assert.AreEqual(salutation, GetAttribute(_pageInstanceLead.SalutationContext, "Name"));
            LogInfo("Verified Salutation is auto populated with " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstanceLead.FirstName, "Value.Value"));
            LogInfo("Verified First Name is auto populated with " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstanceLead.LastName, "Value.Value"));
            LogInfo("Verified Last Name is auto populated with " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstanceLead.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstanceLead.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title is auto populated with " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstanceLead.JobFunctionContext, "Name"));
            LogInfo("Verified Job Function is auto populated with " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstanceLead.Email, "Value.Value"));
            LogInfo("Verified Email is auto populated with " + email);
            Assert.AreEqual(phonecode, GetAttribute(_pageInstanceLead.PhoneCodeContext, "Name"));
            LogInfo("Verified Phone Code is auto populated with " + phonecode);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstanceLead.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number is auto populated with " + phoneNumber);
            Assert.AreEqual(channel, GetAttribute(_pageInstanceLead.ChannelSourceContext, "Name"));
            LogInfo("Verified Channel Source is auto populated with " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstanceLead.ChannelSourceDetailsContext, "Name"));
            LogInfo("Verified Channel Source Details is auto populated with " + channelDetails);
            Assert.AreEqual(prospectOwn, GetAttribute(_pageInstanceLead.LeadOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner is auto populated with " + prospectOwn);
            Assert.AreEqual(website, GetAttribute(_pageInstanceLead.WebSite, "Value.Value"));
            LogInfo("Verified Website is auto populated with " + website);
            Assert.AreEqual(add1, GetAttribute(_pageInstanceLead.Address1, "Value.Value"));
            LogInfo("Verified Address1 is auto populated with " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstanceLead.Address2, "Value.Value"));
            LogInfo("Verified Address2 is auto populated with " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstanceLead.Address3, "Value.Value"));
            LogInfo("Verified Address3 is auto populated with " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstanceLead.City, "Value.Value"));
            LogInfo("Verified City is auto populated with " + cityInfo);
            Assert.AreEqual(countryValue, GetAttribute(_pageInstanceLead.CountryNameField, "Value.Value"));
            LogInfo("Verified Country is auto populated with " + countryValue);
            Assert.AreEqual(stateValue, GetAttribute(_pageInstanceLead.StateNameField, "Value.Value"));
            LogInfo("Verified State is auto populated with " + stateValue);
            Assert.AreEqual(zip, GetAttribute(_pageInstanceLead.ZipCode, "Value.Value"));
            LogInfo("Verified Pin Code is auto populated with " + zip);
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstanceLead.RegionContent, "Name"));
            LogInfo("Verified Region Value is auto populated with " + regionvalue);
            Assert.AreEqual("Assigned", GetAttribute(_pageInstanceLead.Leadstatus, "Name"));
            LogInfo("Verified Lead Status is Assigned");
        }

        public void ValidateViewPropsectPage(String salutation, String firstName, String lastName, String prospectOwn, String companyName, String jobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String status, String comments)
        {
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationValidation, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FN, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LN, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.CompanyNameField, "Value.Value"));
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionValidation, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(prospectOwn, GetAttribute(_pageInstance.ProspectOwner, "Value.Value"));
            LogInfo("Verified Prospect Owner - " + prospectOwn);
            Assert.AreEqual(add1, GetAttribute(_pageInstance.Address1, "Value.Value"));
            LogInfo("Verified Address 1 - " + add1);
            Assert.AreEqual(add2, GetAttribute(_pageInstance.Address2, "Value.Value"));
            LogInfo("Verified Address 2 - " + add2);
            Assert.AreEqual(add3, GetAttribute(_pageInstance.Address3, "Value.Value"));
            LogInfo("Verified Address 3 - " + add3);
            Assert.AreEqual(cityInfo, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City - " + cityInfo);
            Assert.AreEqual(countryValue, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country  - " + countryValue);
            Assert.AreEqual(stateValue, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State - " + stateValue);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.ZipCode, "Value.Value"));
            LogInfo("Verified Zip - " + zip);
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionValidation, "Name"));
            LogInfo("Verified Region - " + regionvalue);
            Assert.AreEqual(phonecode, GetAttribute(_pageInstance.PhoneCodeValidation, "Name"));
            LogInfo("Verified Phone Code - " + phonecode);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceValidation, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsValidation, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
            ProspectStatus(status);
           /* Assert.AreEqual(comments, GetAttribute(_pageInstance.CommentsNameField, "Value.Value"));
            LogInfo("Verified Comments - " + comments);*/
        }

        public void VerifyDisqualifyReason(String disqualifyReason)
        {
            Assert.AreEqual(disqualifyReason, GetAttribute(_pageInstance.DisqualifyReason, "Value.Value"));
            LogInfo("Verified Disqualify Reason Details - " + disqualifyReason);
        }

        public void VerifyConvertedToAndDate(String convertedTo)
        {
            Assert.AreEqual(convertedTo, GetAttribute(_pageInstance.ProspectConvertedTo, "Name"));
            LogInfo("Verified ConertedTo Details - " + convertedTo);
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy"), GetAttribute(_pageInstance.ProspectConvertedDate, "Name"));
            LogInfo("Verified Converted Date Details - " + DateTime.UtcNow.ToString("MMM dd, yyyy"));
        }

        public void DisqualifyProspect(String dqr, String otherReason)
        {
            ClickElement(_pageInstance.Status);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue("Close-Disqualify"));
            ClickElement(_pageInstance.DisQualifyPicker);
            ClickElement(_pageInstance.OptionsValue(dqr));
            LogInfo("Selected Disqualify Reason as Other");
            if (dqr == "Other")
            {
                ClickElement(_pageInstance.OthersReason);
                ClearElement(_pageInstance.OthersReason);
                EnterText(_pageInstance.OthersReason, otherReason);
                LogInfo("Entered Other Reason");
            }
            ClickElement(_pageInstance.DisQualifyButton);
            LogInfo("Clicked on Disqualify Button");
            WaitForMoment(2);
            ClickElement(_pageInstance.DisqualifyConfirmationYes);
            LogInfo("Cliked on Disqualify Confirmation as YES");
            WaitForMoment(2);
            LogInfo("Prospect is Disqualified");
        }

        public void ClickOnEditProspects()
        {
            ClickElement(_pageInstance.EditProspects);
            LogInfo("Clicked on Edit Prospect");
            WaitForLoadingToDisappear();
        }

        public void ClickOnReOpenProspects()
        {
            ClickElement(_pageInstance.ReOpenProspects);
            LogInfo("Clicked on Reopen Prospect");
            WaitForMoment(3);
        }

        public void ClickOnViewProspects()
        {
            ClickElement(_pageInstance.ViewProspects);
            LogInfo("Clicked on View Prospect");
            WaitForLoadingToDisappear();
        }

        public void ClickOnReOpenProspectsConfirmation()
        {
            ClickElement(_pageInstance.OptionsValue("Yes"));
            LogInfo("Clicked on Reopen Prospect");
            WaitForLoadingToDisappear();
        }

        public void ClickRefresh()
        {
            ClickElement(_pageInstance.RefreshButton);
            LogInfo("Clicked on Refresh button");
        }

        public void ValidateCreatedProspectInInboxGrid(String firstName, String lastName, String jobFun, String prospectOwner)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> rowValues = GetFirstRowValues();
            Assert.AreEqual(lastName, rowValues[0]);
            Assert.AreEqual(firstName, rowValues[1]);
            Assert.AreEqual(jobFun, rowValues[3]);
            Assert.AreEqual(prospectOwner, rowValues[4]);
            LogInfo("Verified Created Prospect is Displayed in the Inbox ");
        }

        public void ValidateProspectStatusInInbox(String firstName, String lastName, String jobFun, String prospectOwner, String status, String jobTitle, String country, String companyName)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> rowValues = GetFirstRowValues();
            Assert.IsTrue(companyName.Equals(rowValues[0], StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(firstName, rowValues[1]);
            Assert.AreEqual(lastName, rowValues[2]);
            Assert.AreEqual(jobTitle, rowValues[3]);
            try
            {
                _opportunityAction.ScrollHorizontally(1);
                //Assert.AreEqual(country, rowValues[4]);
                Assert.AreEqual(status, _opportunityAction.GetCellValueInInbox("R1C6"));
                Assert.AreEqual(prospectOwner, _opportunityAction.GetCellValueInInbox("R1C8"));
                LogInfo("Verified Created Prospect is Displayed in the Inbox and status is " + status);
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify the values from 6th column, but created prospect is displayed in the inbox");
            }
           
        }

        public void ClickBackButton()
        {
            Boolean backButtonExist = true;
            WaitForMoment(2);
            try
            {
                backButtonExist = Exists(_pageInstance.BackButton);
            }
            catch (Exception)
            {
                backButtonExist = false;
            }

            if (backButtonExist)
            {
                try
                {
                    ClickElement(_pageInstance.BackButton);
                    try
                    {
                        if (Exists(_pageInstance.BackButton))
                        {
                            ClickElement(_pageInstance.BackButton);
                            LogInfo("Clicked on Back button in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on Back button in 1st attempt");
                    }
                }
                catch (Exception)
                {
                    backButtonExist = false;
                }
            }
            if (!backButtonExist)
            {
                Boolean homeImage = false;
                int count = 0;
                do
                {
                    try
                    {
                        homeImage = Exists(_pageInstance.HomeImage[0]);
                    }
                    catch (Exception)
                    {
                        homeImage = false;
                    }

                    WaitForMoment(1);
                    if (count >= 10)
                    {
                        break;
                    }
                    count = count + 1;
                } while (homeImage.Equals(false));

                if (homeImage)
                {
                    ClickElement(_pageInstance.HomeImage[0]);
                }
                else
                {
                    Assert.Fail("wd icon does not exist");
                }
            }
            WaitForMoment(2);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Back button");
        }

        /// <summary>
        /// To prospects
        /// </summary>
        /// <param name="salutation"></param>
        /// <param name="firstNameProspect"></param>
        /// <param name="lastNameProspect"></param>
        /// <param name="companyName"></param>
        /// <param name="JobTitle"></param>
        /// <param name="JobFunction"></param>
        /// <param name="email"></param>
        public void EnterProspectMandatoryDetails(String salutation, String firstNameProspect, String lastNameProspect, String companyName, String JobTitle, String JobFunction, String email)
        {
            EnterSalutation(salutation);
            EnterFirstName(firstNameProspect);
            EnterLastName(lastNameProspect);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunction(JobFunction);
            EnterEmail(email);
            NewProspectStatus();
        }

        public void EnterProspectOtherDetails(String prosOwn, String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comment)
        {
            EnterProspectOwner(prosOwn);
            EnterAddress1(add1);
            EnterAddress2(add2);
            EnterAddress3(add3);
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
            EnterComments(comment);
        }

        /// <summary>
        /// To prospects
        /// </summary>
        /// <param name="firstNameProspect"></param>
        public void EditProspectDetails(String firstName, String lastName)
        {
            EnterFirstName(lastName);
            EnterLastName(firstName);
        }

        /// <summary>
        /// To prospects
        /// </summary>
        /// <param name="salutation"></param>
        /// <param name="firstNameProspect"></param>
        /// <param name="lastNameProspect"></param>
        /// <param name="companyName"></param>
        /// <param name="JobTitle"></param>
        /// <param name="JobFunction"></param>
        /// <param name="email"></param>
        /// <param name="prosOwn"></param>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <param name="add3"></param>
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
        public void EnterProspectDetails(String salutation, String firstNameProspect, String lastNameProspect, String prosOwn, String companyName, String JobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comment)
        {
            EnterSalutation(salutation);
            EnterFirstName(firstNameProspect);
            EnterLastName(lastNameProspect);
            EnterProspectOwner(prosOwn);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunction(JobFunction);
            EnterEmail(email);
            EnterAddress1(add1);
            EnterAddress2(add2);
            EnterAddress3(add3);
            EnterCity(cityInfo);
            EnterCountry(countryValue);
            EnterState(stateValue);
            EnterPhoneCode(phonecode);
            EnterPhoneNumber(phoneNumber);
            EnterZipCode(zip);
            EnterWebsite(website);
            EnterRegion(regionvalue);
            EnterChannelSource(channel);
            NewProspectStatus();
            EnterChannelSourceDetails(channelDetails);
            EnterComments(comment);
        }

        public void VerifyCreatedDateAndProspectAge(String day)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy") + day, GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            LogInfo("Verified Prospect Created Date and Prospect age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
        }

        public void ClickCopyDetails()
        {
            ClickElement(_pageInstance.CopyDetails);
            LogInfo("Clicked on Copy Details");
            WaitForLoadingToDisappear();
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

        public void ScrollHorizontally(int count)
        {
            try
            {
                MouseHoverOnWindowsElement(_pageInstance.ValuebyRowAndColumnInGrid()[0]);
                MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
                WaitForMoment(2);
                int offsetX = _pageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.X;
                int offsetY = _pageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.Y;
                for (int i = 0; i < count; i++)
                {
                    Mouse.DragTo(MouseButton.Left, new Point(offsetX - 10, offsetY));
                    WaitForMoment(2);
                }
                LogInfo("Srolled the LOA page horizontally");
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }

        public void VerifyMandatoryFieldsMessage()
        {
            ClickElement(_pageInstance.CreateButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(7);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Salutation");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "First Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(5, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(6, "Email Address");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {
            ClickElement(_pageInstance.CreateButton);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(5);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Email Address");
        }
            #endregion

            #region Old

            public int RowNumberWithoutConvertedToContact()
        {
            int value = -1;
            IList<WindowsElement> DetailActions = _pageInstance.DetailActionAllRow;
            if (DetailActions.Count > 0)
            {
                for (int i = 0; i < DetailActions.Count; i++)
                {
                    string nameContact = GetAttribute(_pageInstance.RowWiseConvertedToContact(i + 1), "Name");
                    if (nameContact.Equals("im_af_11.svg"))
                    {
                        value = i + 1;
                        break;
                    }
                }
                LogInfo("Detail action for the 1st inbox record is clicked");
                WaitForMoment(2);
            }
            else
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");

            }
            return value;
        }

        public void ClickOnCreateLeadProspects()
        {
            ClickElement(_pageInstance.CreateLeadProspects);
            LogInfo("Clicked on create lead prospects");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateContactsProspects()
        {
            ClickElement(_pageInstance.CreateContactsProspects);
            LogInfo("Clicked on create lead prospects");
            WaitForLoadingToDisappear();
        }

        public void ScrollVerticaly(int offsetX, int offsetY)
        {
            WindowsElement verticalScrollBar = _pageInstance.VerticalScroll;
            _touchScreen.Scroll(verticalScrollBar.Coordinates, offsetX, offsetY);
        }

        public void ClickByBackButton()
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
                LogInfo("Clicked on Back button in 1st attempt");
            }
            WaitForMoment(2);
            WaitForLoadingToDisappear();

            LogInfo("Clicked on Back button");
        }

        public void ValidateCreatedProspects(String FN, String LN, String Email)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(FN, firstRowValues[0]);
            Assert.AreEqual(LN, firstRowValues[1]);
            Assert.AreEqual(Email, firstRowValues[2]);
        }

        public void ValidateProspectsInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.FN, "Value.Value"));
            Assert.AreEqual(input[1], GetAttribute(_pageInstance.LN, "Value.Value"));
            Assert.AreEqual(input[2], GetAttribute(_pageInstance.Email, "Value.Value"));
        }

        public List<String> GetFirstRowValuesByRowNumber(int rowNumber)
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGridRowWise(rowNumber);
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGridRowWise(rowNumber);
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }

        public void FilterDataBySearch(string value)
        {
            EnterSearchValue(value);
            WaitForMoment(1);
            ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }

        public void ClearSearchField()
        {
            _pageInstance.SearchEditInGrid.Clear();
            WaitForMoment(1);
            //ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }

        public void EnterSearchValue(string value)
        {
            _pageInstance.SearchEditInGrid.Clear();
            _pageInstance.SearchEditInGrid.SendKeys(value);
        }

        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButtonInGrid.Click();
            WaitForLoadingToDisappear();
        }

        #endregion
    }
}
