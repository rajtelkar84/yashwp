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
    public class ContactsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ContactsPage _pageInstance;
        private readonly OpportunityPage _pageInstanceOpportunity;
        private readonly LeadsPage _pageInstanceLead;
        private readonly OpportunityAction _opportunityAction;

        public ContactsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ContactsPage(_session);
            _pageInstanceOpportunity = new OpportunityPage(_session);
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

        public void ClickOnCreateContacts()
        {
            ClickElement(_pageInstance.CreateContacts);
            LogInfo("Clicked on Create Contact Button");
            WaitForLoadingToDisappear();
        }

        public void EnterSalutation(String salutationValue)
        {
            ClickElement(_pageInstance.Salutation);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(salutationValue));
            LogInfo("Entered Salutation - " + salutationValue);
        }

        public void EnterFirstName(String FN)
        {
            ClickElement(_pageInstance.FirstName);
            ClearElement(_pageInstance.FirstName);
            EnterText(_pageInstance.FirstName, FN);
            LogInfo("Entered First Name - " + FN);
        }

        public void EnterLastName(String LN)
        {
            ClickElement(_pageInstance.LastName);
            ClearElement(_pageInstance.LastName);
            EnterText(_pageInstance.LastName, LN);
            LogInfo("Entered Last Name - " + LN);
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

        public void EnterEmail(String Email)
        {
            ClickElement(_pageInstance.Email);
            ClearElement(_pageInstance.Email);
            EnterText(_pageInstance.Email, Email);
            LogInfo("Entered Email - " + Email);
        }
        public void EnterContactOwner(String contactOwner)
        {
            ClickElement(_pageInstance.ContactOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.ContactOwnerArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, contactOwner);
            ClickElement(_pageInstance.OptionsValue(contactOwner));
            Assert.AreEqual(contactOwner, GetAttribute(_pageInstance.ContactOwner, "Value.Value"));
            LogInfo("Verified Contact Owner  - " + contactOwner);
            LogInfo("Contact Owner Changed to " + contactOwner);
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
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, country);
            ClickElement(_pageInstance.OptionsValue(country));
            Assert.IsTrue(GetAttribute(_pageInstance.CountryNameField, "Value.Value") != null);
            LogInfo("Selected Company Name - " + GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
        }

        public void EnterState(String state)
        {
            ClickElement(_pageInstance.StateArrow);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, state);
            ClickElement(_pageInstance.OptionsValue(state));
            Assert.IsTrue(GetAttribute(_pageInstance.StateNameField, "Value.Value") != null);
            LogInfo("Selected Company Name - " + GetAttribute(_pageInstance.StateNameField, "Value.Value"));
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
            LogInfo("Entered Region - " + region);
        }

        public void EnterPhoneCode1(String phCode)
        {
            ClickElement(_pageInstance.PhoneCode1);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(phCode));
            LogInfo("Entered Phone Code 1 - " + phCode);
        }

        public void EnterPhoneNumber1(String phNo)
        {
            ClickElement(_pageInstance.PhoneNumber1);
            ClearElement(_pageInstance.PhoneNumber1);
            EnterText(_pageInstance.PhoneNumber1, phNo);
            LogInfo("Entered Phone Number 1 - " + phNo);
        }

        public void EnterPhoneCode2(String phCode)
        {
            ClickElement(_pageInstance.PhoneCode2);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(phCode));
            LogInfo("Entered Phone Code 2 - " + phCode);
        }

        public void EnterPhoneNumber2(String phNo)
        {
            ClickElement(_pageInstance.PhoneNumber2);
            ClearElement(_pageInstance.PhoneNumber2);
            EnterText(_pageInstance.PhoneNumber2, phNo);
            LogInfo("Entered Phone Number 2 - " + phNo);
        }

        public void EnterWebsite(String webSite)
        {
            ClickElement(_pageInstance.WebSite);
            ClearElement(_pageInstance.WebSite);
            EnterText(_pageInstance.WebSite, webSite);
            LogInfo("Entered WebSite - " + webSite);
        }

        public void EnterChannelSource(String channelSource)
        {
            ClickElement(_pageInstance.ChannelSource);
            WaitForMoment(2);
            ClickElement(_pageInstance.OptionsValue(channelSource));
            LogInfo("Entered Channel Source - " + channelSource);
        }

        public void EnterChannelSourceDetails(String channelSourceDetails)
        {
            ClickElement(_pageInstance.ChannelSourceDetails);
            WaitForMoment(1);
            ClickElement(_pageInstance.OptionsValue(channelSourceDetails));
            LogInfo("Entered Channel Source Details - " + channelSourceDetails);
        }

        public void EnterComments(String comments)
        {
            EnterText(_pageInstance.ChannelSourceDetails, Keys.Tab);
            WaitForMoment(3);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            LogInfo("Entered Comments - " + comments);
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

        public void Translate(String transValue)
        {
            ClickElement(_pageInstance.TranslateTo);
            ClickElement(_pageInstance.OptionsValue(transValue));
            LogInfo("Selcted Translate To Picker");
        }

        public void EnterSalutation_T(String salutationValue)
        {
            ClickElement(_pageInstance.Salutation_T);
            ClearElement(_pageInstance.Salutation_T);
            EnterText(_pageInstance.Salutation_T, salutationValue);
            LogInfo("Entered Translate Salutation");
        }

        public void EnterFirstName_T(String FN)
        {
            ClickElement(_pageInstance.FN_T);
            ClearElement(_pageInstance.FN_T);
            EnterText(_pageInstance.FN_T, FN);
            LogInfo("Entered Translate First Name");
        }

        public void EnterLastName_T(String LN)
        {
            ClickElement(_pageInstance.LN_T);
            ClearElement(_pageInstance.LN_T);
            EnterText(_pageInstance.LN_T, LN);
            LogInfo("Entered Translate Last Name");
        }

        public void EnterComapanyName_T(String company)
        {
            ClickElement(_pageInstance.CompanyName_T);
            ClearElement(_pageInstance.CompanyName_T);
            EnterText(_pageInstance.CompanyName_T, company);
            LogInfo("Entered Translate Company Name");
        }



        public void EnterJobTitle_T(String JobTitle)
        {
            ClickElement(_pageInstance.JobeTitle_T);
            ClearElement(_pageInstance.JobeTitle_T);
            EnterText(_pageInstance.JobeTitle_T, JobTitle);
            LogInfo("Entered Translate Job Title");
        }

        public void EnterJobFunction_T(String jobFunction)
        {
            ClickElement(_pageInstance.JobFunction_T);
            ClearElement(_pageInstance.JobFunction_T);
            EnterText(_pageInstance.JobFunction_T, jobFunction);
            LogInfo("Entered Translate Job Function");
        }

        public void EnterEmail_T(String Email)
        {
            ClickElement(_pageInstance.Email_T);
            ClearElement(_pageInstance.Email_T);
            EnterText(_pageInstance.Email_T, Email);
            LogInfo("Entered Translate Email");
        }

        public void EnterWebsite_T(String webSite)
        {
            ClickElement(_pageInstance.Website_T);
            ClearElement(_pageInstance.Website_T);
            EnterText(_pageInstance.Website_T, webSite);
            LogInfo("Entered Translate WebSite");
        }

        public void EnterAddress1_T(String address1)
        {
            ClickElement(_pageInstance.Add1_T);
            ClearElement(_pageInstance.Add1_T);
            EnterText(_pageInstance.Add1_T, address1);
            LogInfo("Entered Translate Address1");
        }
        public void EnterAddress2_T(String address2)
        {
            ClickElement(_pageInstance.Add2_T);
            ClearElement(_pageInstance.Add2_T);
            EnterText(_pageInstance.Add2_T, address2);
            LogInfo("Entered Translate Address2");
        }

        public void EnterAddress3_T(String address3)
        {
            ClickElement(_pageInstance.Add3_T);
            ClearElement(_pageInstance.Add3_T);
            EnterText(_pageInstance.Add3_T, address3);
            LogInfo("Entered Translate Address3");
        }

        public void EnterCity_T(String city)
        {
            ClickElement(_pageInstance.City_T);
            ClearElement(_pageInstance.City_T);
            EnterText(_pageInstance.City_T, city);
            LogInfo("Entered Translate City");
        }

        public void EnterCountry_T(String country)
        {
            ClickElement(_pageInstance.Country_T);
            ClearElement(_pageInstance.Country_T);
            EnterText(_pageInstance.Country_T, country);
            LogInfo("Entered Translate Country");
        }

        public void EnterState_T(String state)
        {
            ClickElement(_pageInstance.StateOrProvince_T);
            ClearElement(_pageInstance.StateOrProvince_T);
            EnterText(_pageInstance.StateOrProvince_T, state);
            LogInfo("Entered Translate State");
        }

        public void EnterZipCode_T(String zipCode)
        {
            ClickElement(_pageInstance.Zip_T);
            ClearElement(_pageInstance.Zip_T);
            EnterText(_pageInstance.Zip_T, zipCode);
            LogInfo("Entered Translate ZipCode");
        }

        public void EnterPhoneNumber1_T(String phNo)
        {
            ClickElement(_pageInstance.Phone1_T);
            ClearElement(_pageInstance.Phone1_T);
            EnterText(_pageInstance.Phone1_T, phNo);
            LogInfo("Entered Translate Phone 1");
        }

        public void EnterPhoneNumber2_T(String phNo)
        {
            ClickElement(_pageInstance.Phone2_T);
            ClearElement(_pageInstance.Phone2_T);
            EnterText(_pageInstance.Phone2_T, phNo);
            LogInfo("Entered Translate Phone 2");
        }

        public void ClickOnCreateContactsButton()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on Create Button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnEditContacts()
        {
            ClickElement(_pageInstance.EditContacts);
            LogInfo("Clicked on Edit Contact");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateOpportunity()
        {
            ClickElement(_pageInstance.OptionsValue("Create Opportunity "));
            LogInfo("Clicked on Create Opportunity");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateLead()
        {
            ClickElement(_pageInstance.OptionsValue("Create Lead "));
            LogInfo("Clicked on Create Lead");
            WaitForLoadingToDisappear();
        }

        public void ClickOnDeactivateContact()
        {
            ClickElement(_pageInstance.OptionsValue("Deactivate Contact "));
            LogInfo("Clicked on Deactivate Contact");
            WaitForLoadingToDisappear();
            WaitForLoadingToDisappear();
        }

        public void ClickOnYes()
        {
            try
            {
                WaitForMoment(3);
                ClickElement(_pageInstance.ConfirmationYesButton);
                LogInfo("Clicked on Yes");
                WaitForLoadingToDisappear();
            }
            catch (Exception)
            {
                LogInfo("Error in clicking Yes");
            }

        }

        public void ClickCopyDetails()
        {
            ClickElement(_pageInstance.CopyDetails);
            LogInfo("Clicked on Copy Details");
        }

        public void VerifyFieldsAfterClickingOnCopyDetails(String add1, String add2, String add3, String cityInfo, String country, String state, String zip, String phoneNumber1, String website)
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
            Assert.AreEqual(phoneNumber1, GetAttribute(_pageInstance.PhoneNumber1, "Value.Value"));
            LogInfo("Verified Phone Number - " + phoneNumber1);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
        }


        public void ValidateOpportunityPage(String region)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy"), GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            LogInfo("Verified Opportunity Create Date - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Account name is auto populated ");
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated ");
            Assert.IsTrue(GetAttribute(_pageInstanceOpportunity.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated ");
            Assert.AreEqual(region, GetAttribute(_pageInstanceOpportunity.RegionNameField, "Name"));
            LogInfo("Verified Region Value - " + region);
        }

        public void VerifyLeadPage(String day, String salutation, String firstName, String lastName, String prospectOwn, String companyName, String jobTitle, String JobFunction, String email,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode, String phoneNumber, String zip, String website, String regionvalue,
            String channel, String channelDetails)
        {
            Assert.AreEqual(DateTime.UtcNow.ToString("MMM dd, yyyy") + day, GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            LogInfo("Verified Lead Created Date and Lead age - " + GetAttribute(_pageInstance.CreatedDateAndDays, "Name"));
            Assert.IsTrue(Exists(_pageInstanceLead.Topic));
            LogInfo("Verified Topic field is present");
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
            Assert.IsTrue(GetAttribute(_pageInstanceLead.PhoneCodeContext, "Name") != null);
            LogInfo("Verified Phone Code is autopopulated with - " + GetAttribute(_pageInstanceLead.PhoneCodeContext, "Name"));
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
            Assert.AreEqual("New", GetAttribute(_pageInstanceLead.NewLeadStatus, "Value.Value"));
            LogInfo("Verified Lead Status is New");
        }

        public void ValidateCreatedContactInInbox(String firstName, String lastName, String email, String address1, String city, String jobTitle, String jobFunction, String contactOwner)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(firstName, firstRowValues[0]);
            Assert.AreEqual(lastName, firstRowValues[1]);
            Assert.AreEqual(jobTitle, firstRowValues[2]);
            Assert.AreEqual(jobFunction, firstRowValues[3]);
            try
            {
                _opportunityAction.ScrollHorizontally(1);
                Assert.AreEqual(email, _opportunityAction.GetCellValueInInbox("R1C5"));
                //Assert.AreEqual(companyName, _opportunityAction.GetCellValueInInbox("R1C6"));
                Assert.AreEqual(address1, _opportunityAction.GetCellValueInInbox("R1C7"));
                Assert.AreEqual(city, _opportunityAction.GetCellValueInInbox("R1C8"));
                Assert.AreEqual(contactOwner, _opportunityAction.GetCellValueInInbox("R1C9"));
                LogInfo("Verified Create Contact Is Displayed In The Inbox");
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify the values from 5th column, but created contact is displayed in the inbox");
            }
        }

        public void VerifyContactPage(String salutation, String firstName, String lastName, String companyName, String jobTitle, String JobFunction, String email, String contOwn, String add1, String add2,
            String add3, String cityInfo, String countryValue, String stateValue, String phonecode1, String phoneNumber1, String phonecode2, String phoneNumber2, String zip, String website, String regionvalue,
            String channel, String channelDetails, String comment)
        {
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationField, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionField, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(phonecode1, GetAttribute(_pageInstance.PhoneCode1Field, "Name"));
            LogInfo("Verified Phone Code 1 - " + phonecode1);
            Assert.AreEqual(phoneNumber1, GetAttribute(_pageInstance.PhoneNumber1, "Value.Value"));
            LogInfo("Verified Phone Number 1- " + phoneNumber1);
            Assert.AreEqual(phonecode2, GetAttribute(_pageInstance.PhoneCode2Field, "Name"));
            LogInfo("Verified Phone Code 2 - " + phonecode2);
            Assert.AreEqual(phoneNumber2, GetAttribute(_pageInstance.PhoneNumber2, "Value.Value"));
            LogInfo("Verified Phone Number 2- " + phoneNumber2);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(contOwn, GetAttribute(_pageInstance.ContactOwner, "Value.Value"));
            LogInfo("Verified Contact Owner - " + contOwn);
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
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionNameField, "Name"));
            LogInfo("Verified Region Value - " + regionvalue);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceNameField, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsNameField, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
            /*Assert.AreEqual(comment, GetAttribute(_pageInstance.CommentsNameField, "Value.Value"));
            LogInfo("Verified Comments - " + comment);*/
        }

        public void VerifyContactPageCreatedFromLeadInbox(String salutation, String firstName, String lastName, String companyName, String jobTitle, String JobFunction, String email, String contOwn, String add1, String add2,
           String add3, String cityInfo, String countryValue, String stateValue, String phoneNumber1, String zip, String website, String regionvalue, String channel, String channelDetails)
        {
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationField, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(JobFunction, GetAttribute(_pageInstance.JobFunctionField, "Name"));
            LogInfo("Verified Job Function - " + JobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
            Assert.AreEqual(phoneNumber1, GetAttribute(_pageInstance.PhoneNumber1, "Value.Value"));
            LogInfo("Verified Phone Number 1- " + phoneNumber1);
            Assert.AreEqual(website, GetAttribute(_pageInstance.WebSite, "Value.Value"));
            LogInfo("Verified Website - " + website);
            Assert.AreEqual(contOwn, GetAttribute(_pageInstance.ContactOwner, "Value.Value"));
            LogInfo("Verified Contact Owner - " + contOwn);
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
            Assert.AreEqual(regionvalue, GetAttribute(_pageInstance.RegionNameField, "Name"));
            LogInfo("Verified Region Value - " + regionvalue);
            Assert.AreEqual(channel, GetAttribute(_pageInstance.ChannelSourceNameField, "Name"));
            LogInfo("Verified Channel Source - " + channel);
            Assert.AreEqual(channelDetails, GetAttribute(_pageInstance.ChannelSourceDetailsNameField, "Name"));
            LogInfo("Verified Channel Source Details - " + channelDetails);
        }


        public void VerifyContactMandatoryFields(String salutation, String firstName, String lastName, String jobTitle, String jobFunction, String email)
        {
            Assert.AreEqual(salutation, GetAttribute(_pageInstance.SalutationField, "Name"));
            LogInfo("Verified Salutation - " + salutation);
            Assert.AreEqual(firstName, GetAttribute(_pageInstance.FirstName, "Value.Value"));
            LogInfo("Verified First Name - " + firstName);
            Assert.AreEqual(lastName, GetAttribute(_pageInstance.LastName, "Value.Value"));
            LogInfo("Verified Last Name - " + lastName);
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
            Assert.AreEqual(jobTitle, GetAttribute(_pageInstance.JobTitle, "Value.Value"));
            LogInfo("Verified Job Title - " + jobTitle);
            Assert.AreEqual(jobFunction, GetAttribute(_pageInstance.JobFunctionField, "Name"));
            LogInfo("Verified Job Function - " + jobFunction);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email - " + email);
        }

        public void VerifyCompanyNameField()
        {
            Assert.IsTrue(GetAttribute(_pageInstance.CompanyNameField, "Value.Value") != null);
            LogInfo("Verified Company name is auto populated ");
        }

        public void VerifyCompanyNameFieldWithName(String companyName)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.CompanyNameField, "Value.Value"), companyName);
            LogInfo("Verified Company name is auto populated - "+ companyName);
        }

        public void VerifyInboxName(String inboxName)
        {
            Assert.AreEqual(inboxName, GetAttribute(_pageInstance.InboxName, "Name"));
            LogInfo("Verified application is in " + inboxName + " inbox");
        }

        public void ClickOnRefreshData()
        {
            ClickElement(_pageInstance.RefreshData);
            IList<WindowsElement> DetailActions = _pageInstance.DetailAction;
            try
            {
                if (!Exists(_pageInstance.DetailAction[0]))
                {
                    ClickElement(_pageInstance.RefreshData);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on Refresh Data in first chance");
            }
            WaitForLoadingToDisappear();

            LogInfo("Clicked on Refresh Data");
        }


        /// <summary>
        /// To contacts
        /// </summary>
        /// <param name="salutation"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="account"></param>
        /// <param name="companyName"></param>
        /// <param name="JobTitle"></param>
        /// <param name="JobFunction"></param>
        /// <param name="email"></param>
        public void EnterContactMandatoryDetails(String salutation, String firstName, String lastName, String account, String companyName, String JobTitle, String JobFunction, String email)
        {
            EnterSalutation(salutation);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunction(JobFunction);
            EnterEmail(email);
        }

        public void EnterContactMandatoryDetailsFromOtherInbox(String salutation, String firstName, String lastName, String JobTitle, String JobFunction, String email, String contactOwn, String add1, String cityInfo)
        {
            EnterSalutation(salutation);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterJobTitle(JobTitle);
            EnterJobFunction(JobFunction);
            EnterEmail(email);
            EnterContactOwner(contactOwn);
            EnterAddress1(add1);
            EnterCity(cityInfo);
        }

        /// <summary>
        /// To contacts
        /// </summary>
        /// <param name="firstNameProspect"></param>
        public void EditContactDetails(String firstName, String lastName)
        {
            EnterFirstName(lastName);
            EnterLastName(firstName);
        }

        /// <summary>
        /// To contacts
        /// </summary>
        /// <param name="salutation"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="account"></param>
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
        public void EnterContactDetails(String salutation, String firstName, String lastName, String companyName, String JobTitle, String JobFunction, String email, String contOwn, String account,
            String add1, String add2, String add3, String cityInfo, String countryValue, String stateValue, String phonecode1, String phoneNumber1, String phonecode2, String phoneNumber2, String zip,
            String website, String regionvalue, String channel, String channelDetails, String comment)
        {
            EnterSalutation(salutation);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            SelectComapany(companyName);
            EnterJobTitle(JobTitle);
            EnterJobFunction(JobFunction);
            EnterEmail(email);
            EnterContactOwner(contOwn);
            EnterAddress1(add1);
            EnterAddress2(add2);
            EnterAddress3(add3);
            EnterCity(cityInfo);
            EnterCountry(countryValue);
            EnterState(stateValue);
            EnterPhoneCode1(phonecode1);
            EnterPhoneNumber1(phoneNumber1);
            EnterPhoneCode2(phonecode2);
            EnterPhoneNumber2(phoneNumber2);
            EnterZipCode(zip);
            EnterWebsite(website);
            EnterRegion(regionvalue);
            EnterChannelSource(channel);
            EnterChannelSourceDetails(channelDetails);
            EnterComments(comment);
        }

        /// <summary>
        /// To contacts
        /// </summary>
        /// <param name="sal"></param>
        /// <param name="fn"></param>
        /// <param name="ln"></param>
        /// <param name="website"></param>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <param name="add3"></param>
        /// <param name="companyName"></param>
        /// <param name="jobTitle"></param>
        /// <param name="jobFunction"></param>
        /// <param name="email"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="ph1"></param>
        /// <param name="ph2"></param>
        public void EnterTranslateContactDetails(String value, String sal, String fn, String ln, String website, String add1, String add2, String add3, String companyName, String jobTitle,
            String jobFunction, String email, string city, String country, String state, String zip, String ph1, String ph2)
        {
            Translate(value);
            EnterSalutation_T(sal);
            EnterFirstName_T(fn);
            EnterLastName_T(ln);
            EnterWebsite_T(website);
            EnterAddress1_T(add1);
            EnterAddress2_T(add2);
            EnterAddress3_T(add3);
            EnterComapanyName_T(companyName);
            EnterJobTitle_T(jobTitle);
            EnterJobFunction_T(jobFunction);
            EnterEmail_T(email);
            EnterCity_T(city);
            EnterCountry_T(country);
            EnterState_T(state);
            EnterZipCode_T(zip);
            EnterPhoneNumber1_T(ph1);
            EnterPhoneNumber2_T(ph2);
        }

        public void VerifyMandatoryFieldsMessage()
        {
            ClickOnCreateContactsButton();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(7);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Salutation");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "First Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(5, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(6, "Email");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {
            ClickOnCreateContactsButton();
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(5);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Last Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Job Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Job Function");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Email");
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
        public void ClickOnContactInformation()
        {
            ClickElement(_pageInstance.ContactInformation);
            LogInfo("Clicked on contact information tab");
            WaitForLoadingToDisappear();
        }

        public void EnterCompanyPhoneCode(String phoneCode)
        {
            EnterText(_pageInstance.CompanyPhoneCode, phoneCode);
            LogInfo("Entered phone code");
        }
        public void EnterCompanyPhoneNumber(String phoneNumber)
        {
            ClickElement(_pageInstance.CompanyPhoneNumber);
            ClearElement(_pageInstance.CompanyPhoneNumber);
            WaitForMoment(1);
            EnterText(_pageInstance.CompanyPhoneNumber, phoneNumber);
            LogInfo("Entered Company phone number");
        }

        public void EnterCompanyWebsite(String companyWebsite)
        {
            ClickElement(_pageInstance.CompanyWebsite);
            ClearElement(_pageInstance.CompanyWebsite);
            WaitForMoment(1);
            EnterText(_pageInstance.CompanyWebsite, companyWebsite);
            LogInfo("Entered Company website");
        }

        public void EnterCompanyAddressLine1(String address1)
        {
            ClickElement(_pageInstance.CompanyAddressL1);
            ClearElement(_pageInstance.CompanyAddressL1);
            WaitForMoment(1);
            EnterText(_pageInstance.CompanyAddressL1, address1);
            LogInfo("Entered Company address line 1");
        }

        public void EnterCompanyAddressLine2(String address2)
        {
            ClickElement(_pageInstance.CompanyAddress2);
            ClearElement(_pageInstance.CompanyAddress2);
            WaitForMoment(1);
            EnterText(_pageInstance.CompanyAddress2, address2);
            LogInfo("Entered Company address line 2");
        }

        public void EnterCompanyAddressLine3(String address3)
        {
            ClickElement(_pageInstance.CompanyAddress3);
            ClearElement(_pageInstance.CompanyAddress3);
            WaitForMoment(1);
            EnterText(_pageInstance.CompanyAddress3, address3);
            LogInfo("Entered Company address line 3");
        }

        public void EnterPostalZip(String zipCode)
        {
            ClickElement(_pageInstance.ZipCode);
            ClearElement(_pageInstance.ZipCode);
            WaitForMoment(1);
            EnterText(_pageInstance.ZipCode, zipCode);
            LogInfo("Entered zip code");
        }

        public void SelectCountry(String country)
        {
            EnterText(_pageInstance.Country, country);
            LogInfo("Selected country");
            WaitForMoment(2);
        }

        public void SelectState(String state)
        {
            EnterText(_pageInstance.State, state);
            LogInfo("Selected state");
        }

        public void ClickOnUpdateButton()
        {
            ClickElement(_pageInstance.UpdateButton);
            LogInfo("Clicked on update contacts");
            WaitForLoadingToDisappear();
        }



        /// <summary>
        /// To company Information
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="phoneCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="website"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="address3"></param>
        /// <param name="city"></param>
        /// <param name="postalZip"></param>
        /// /// <param name="country"></param>
        /// /// <param name="region"></param>

        public void EnterCompanyInformation(String accountName = "merck", String phoneCode = "US(+1)", string phoneNumber = "9060666615", string website = "www.veeresh.com"
            , string address1 = "Address1", string address2 = "Address2", string address3 = "address3", string city = "New York", string postalZip = "10001",
            string country = "USA", string region = "New York")
        {
            WaitForMoment(2);
            //EnterAccountName(accountName);
            EnterCompanyPhoneCode(phoneCode);
            EnterCompanyPhoneNumber(phoneNumber);
            EnterCompanyWebsite(website);
            EnterCompanyAddressLine1(address1);
            EnterCompanyAddressLine2(address2);
            EnterCompanyAddressLine3(address3);
            EnterCity(city);
            EnterPostalZip(postalZip);
            SelectCountry(country);
            SelectState(region);
        }

        public void ValidateCreatedContactInInboxGrid(String firstName, String lastName, String email, String phoneNumber, String companyName, string companyPhoneNumber, string companyWebsite)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(firstName, firstRowValues[0]);
            Assert.AreEqual(lastName, firstRowValues[1]);
            Assert.AreEqual(email, firstRowValues[2]);
            phoneNumber = phoneNumber.Substring(phoneNumber.IndexOf('('));
            companyPhoneNumber = companyPhoneNumber.Substring(companyPhoneNumber.IndexOf('('));
            Assert.AreEqual(phoneNumber, firstRowValues[3]);
            Assert.AreEqual(companyName, firstRowValues[4]);
            Assert.AreEqual(companyPhoneNumber, firstRowValues[5]);
            Assert.AreEqual(companyWebsite, firstRowValues[6]);
            //Assert.AreEqual(companyPhoneNumber, GetAttribute(_pageInstance.ValuebyRowAndColumnInGrid("R1C5"), "Name"));
            //Assert.AreEqual(companyPhoneNumber, GetAttribute(_pageInstance.ValuebyRowAndColumnInGrid("R1C5"), "Name"));
            LogInfo("Verified created contacts in inbox grid");
        }

        public void ValidateContactInformationInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.FirstName, "Value.Value"));
            Assert.AreEqual(input[1], GetAttribute(_pageInstance.LastName, "Value.Value"));
            Assert.AreEqual(input[2], GetAttribute(_pageInstance.Email, "Value.Value"));
            String[] splitContact = input[3].Split(')');
            string phoneCodeRuntime = GetAttribute(_pageInstance.ContactPhoneCodeSelected, "Name");
            int indexRuntime = phoneCodeRuntime.IndexOf('(');
            Assert.AreEqual(splitContact[0] + ")", phoneCodeRuntime.Substring(indexRuntime));
            Assert.AreEqual(splitContact[1], GetAttribute(_pageInstance.ContactPhoneNumber, "Value.Value").Replace("-", ""));
            // Assert.AreEqual(input[7], GetAttribute(_pageInstance.Topic, "Value.Value"));
        }

        public void ValidateContactInformationInUpdatePageFromProspect(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.FirstName, "Value.Value"));
            Assert.AreEqual(input[1], GetAttribute(_pageInstance.LastName, "Value.Value"));
            Assert.AreEqual(input[2], GetAttribute(_pageInstance.Email, "Value.Value"));

        }

        public void ValidateCompanyInformationInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[4], GetAttribute(_pageInstance.AccountNameSelected, "Name"));
            Assert.AreEqual(input[6], GetAttribute(_pageInstance.CompanyWebsite, "Value.Value"));
            String[] splitContact = input[5].Split(')');
            string phoneCodeRuntime = GetAttribute(_pageInstance.CompanyPhoneCodeSelected, "Name");
            int indexRuntime = phoneCodeRuntime.IndexOf('(');
            Assert.AreEqual(splitContact[0] + ")", phoneCodeRuntime.Substring(indexRuntime));
            Assert.AreEqual(splitContact[1], GetAttribute(_pageInstance.CompanyPhoneNumber, "Value.Value").Replace("-", ""));// Assert.AreEqual(input[7], GetAttribute(_pageInstance.Topic, "Value.Value"));
        }

        #endregion

    }
}
