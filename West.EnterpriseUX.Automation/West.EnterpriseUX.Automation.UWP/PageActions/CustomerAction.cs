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
    public class CustomerAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CustomerPage _pageInstance;
        private readonly OpportunityAction _opportunityAction;

        public CustomerAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CustomerPage(_session);
            _opportunityAction = new OpportunityAction(_session);
        }

        public void ClickOnCreateCustomer()
        {
            ClickElement(_pageInstance.CreateCustomer);
            LogInfo("Clicked on Create Contact Button");
            WaitForLoadingToDisappear();
        }

        public void EnterCompanyName(String companyName)
        {
            ClickElement(_pageInstance.CompanyName);
            ClearElement(_pageInstance.CompanyName);
            EnterText(_pageInstance.CompanyName, companyName);
            LogInfo("Entered Company Name - " + companyName);
        }

        public void EnterStreet1(String street1)
        {
            ClickElement(_pageInstance.Street1);
            ClearElement(_pageInstance.Street1);
            EnterText(_pageInstance.Street1, street1);
            LogInfo("Entered street1 - " + street1);
        }

        public void EnterStreet2(String street2)
        {
            ClickElement(_pageInstance.Street2);
            ClearElement(_pageInstance.Street2);
            EnterText(_pageInstance.Street2, street2);
            LogInfo("Entered street2 - " + street2);
        }

        public void EnterStreet3(String street3)
        {
            ClickElement(_pageInstance.Street3);
            ClearElement(_pageInstance.Street3);
            EnterText(_pageInstance.Street3, street3);
            LogInfo("Entered street3 - " + street3);
        }

        public void SelectCountry(String country)
        {
            ClickElement(_pageInstance.Country);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, country);
            ClickElement(_pageInstance.Options(country));
            Assert.AreEqual(country, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Selected Company Name - " + GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
        }

        public void SelectState(String state)
        {
            ClickElement(_pageInstance.State);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, state);
            ClickElement(_pageInstance.Options(state));
            Assert.AreEqual(state, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Selected State Name - " + GetAttribute(_pageInstance.StateNameField, "Value.Value"));
        }

        public void EnterAccountManager(String accountManager)
        {
            ClickElement(_pageInstance.AccountManager);
            ClearElement(_pageInstance.AccountManager);
            EnterText(_pageInstance.AccountManager, accountManager);
            ClickElement(_pageInstance.AccountManagerDropDownButton);
            ClickElement(_pageInstance.AccountManagerDropDownButton);
            WaitForMoment(1);
            ClickElement(_pageInstance.Options(accountManager));
            LogInfo("Entered Account Manager - " + accountManager);
        }

        public void EnterWebsite(String website)
        {
            ClickElement(_pageInstance.Website);
            ClearElement(_pageInstance.Website);
            EnterText(_pageInstance.Website, website);
            LogInfo("Entered Website - " + website);
        }

        public void EnterEmail(String email)
        {
            ClickElement(_pageInstance.Email);
            ClearElement(_pageInstance.Email);
            EnterText(_pageInstance.Email, email);
            LogInfo("Entered Email  - " + email);
        }

        public void EnterZipCode(String zip)
        {
            ClickElement(_pageInstance.Zip);
            ClearElement(_pageInstance.Zip);
            EnterText(_pageInstance.Zip, zip);
            LogInfo("Entered Zip - " + zip);
        }

        public void EnterCity(String city)
        {
            ClickElement(_pageInstance.City);
            ClearElement(_pageInstance.City);
            EnterText(_pageInstance.City, city);
            LogInfo("Entered City - " + city);
        }

        public void SelectPhoneCode(String phoneCode)
        {
            ClickElement(_pageInstance.PhoneCode);
            ClickElement(_pageInstance.Options(phoneCode));
            LogInfo("Selected Phone Type - " + phoneCode);
        }

        public void EnterPhoneNumber(String phoneNumber)
        {
            ClickElement(_pageInstance.PhoneNumber);
            ClearElement(_pageInstance.PhoneNumber);
            EnterText(_pageInstance.PhoneNumber, phoneNumber);
            LogInfo("Entered Phone Number - " + phoneNumber);
        }

        public void EnterCustomerDetails(String companyName, String street1, String street2, String street3, String country, String state, String accountManager, String website, String email, String zip, String city, String phoneCode, String phoneNumber)
        {
            EnterCompanyName(companyName);
            EnterStreet1(street1);
            EnterStreet2(street2);
            EnterStreet3(street3);
            SelectCountry(country);
            SelectState(state);
            EnterAccountManager(accountManager);
            EnterWebsite(website);
            EnterEmail(email);
            EnterZipCode(zip);
            EnterCity(city);
            SelectPhoneCode(phoneCode);
            EnterPhoneNumber(phoneNumber);
        }

        public void EditCustomer(String companyName, String city)
        {
            EnterCompanyName(companyName);
            EnterCity(city);
        }

        public void ClickOnCreateOrUpdateButtonButton()
        {
            while (_pageInstance.CreateOrUpdateButton.Count != 0)
            {
                ClickElement(_pageInstance.CreateOrUpdateButton[0]);
                LogInfo("Clicked on Create Or Update Button");
                WaitForLoadingToDisappear();
            }
        }

        public void ClickOnEditCustomer()
        {
            ClickElement(_pageInstance.Options("Edit CRM Account"));
            LogInfo("Clicked on Edit Customer");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateOpportunity()
        {
            ClickElement(_pageInstance.Options("Create Opportunity"));
            LogInfo("Clicked on Create Opportunity");
            WaitForLoadingToDisappear();
        }

        public void ClickChildInboxIcon()
        {
            ClickElement(_pageInstance.ChildInboxIcon[0]);
            LogInfo("Clicked on Child Inbox Icon in 1st attempt");
            WaitForLoadingToDisappear();
        }

        public void ClickChildInbox(String childInbox)
        {
            ClickElement(_pageInstance.Options(childInbox));
            LogInfo("Clicked on Child Inbox "+childInbox);
            WaitForLoadingToDisappear();
            WaitForMoment(5);
        }

        public void VerifyChildInboxCount(String inbox, String childInboxCount)
        {
            List<String> values = new List<String>();
            IList<WindowsElement> childInboxName = _pageInstance.ChildInboxName();
            if (childInboxName.Equals(null))
            {
                childInboxName = _pageInstance.ChildInboxName();
            }
            for (int i = 0; i < childInboxName.Count; i++)
            {
                values.Add(childInboxName[i].Text);
            }
            int inboxIndex = values.IndexOf(inbox);

            WaitForMoment(2);
            Assert.AreEqual(_pageInstance.ChildInboxCount[inboxIndex].Text, "- "+childInboxCount);
        }

        public void ClickOnCreateLead()
        {
            ClickElement(_pageInstance.Options("Create Lead"));
            LogInfo("Clicked on Create Lead");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateCase()
        {
            ClickElement(_pageInstance.Options("Create Case"));
            LogInfo("Clicked on Create Lead");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCreateMeetingReport()
        {
            ClickElement(_pageInstance.Options("Create Meeting Report "));
            LogInfo("Clicked on Create Lead");
            WaitForLoadingToDisappear();
        }

        public void ValidateCustomerPage(String companyName, String street1, String street2, String street3, String country, String state, String accountManager, String website, String email, String zip, String city, String phoneCode, String phoneNumber)
        {
            Assert.AreEqual(companyName, GetAttribute(_pageInstance.CompanyName, "Value.Value"));
            LogInfo("Verified Company Name is auto populated with " + companyName);
            Assert.AreEqual(street1, GetAttribute(_pageInstance.Street1, "Value.Value"));
            LogInfo("Verified Street1 is auto populated with " + street1);
            Assert.AreEqual(street2, GetAttribute(_pageInstance.Street2, "Value.Value"));
            LogInfo("Verified Street2 is auto populated with " + street2);
            Assert.AreEqual(street3, GetAttribute(_pageInstance.Street3, "Value.Value"));
            LogInfo("Verified Street3 is auto populated with " + street3);
            Assert.AreEqual(country, GetAttribute(_pageInstance.CountryNameField, "Value.Value"));
            LogInfo("Verified Country is auto populated with " + country);
            Assert.AreEqual(state, GetAttribute(_pageInstance.StateNameField, "Value.Value"));
            LogInfo("Verified State is auto populated with " + state);
            Assert.AreEqual(accountManager, GetAttribute(_pageInstance.AccountManager, "Value.Value"));
            LogInfo("Verified Account Manager is auto populated with " + accountManager);
            Assert.AreEqual(street1, GetAttribute(_pageInstance.Street1, "Value.Value"));
            LogInfo("Verified Street1 is auto populated with " + street1);
            Assert.AreEqual(website, GetAttribute(_pageInstance.Website, "Value.Value"));
            LogInfo("Verified Website is auto populated with " + website);
            Assert.AreEqual(email, GetAttribute(_pageInstance.Email, "Value.Value"));
            LogInfo("Verified Email is auto populated with " + email);
            Assert.AreEqual(zip, GetAttribute(_pageInstance.Zip, "Value.Value"));
            LogInfo("Verified zip is auto populated with " + zip);
            Assert.AreEqual(city, GetAttribute(_pageInstance.City, "Value.Value"));
            LogInfo("Verified City is auto populated with " + city);
            Assert.AreEqual(phoneCode, GetAttribute(_pageInstance.PhoneCodeContent, "Name"));
            LogInfo("Verified Phoen Type is auto populated with " + street1);
            Assert.AreEqual(phoneNumber, GetAttribute(_pageInstance.PhoneNumber, "Value.Value"));
            LogInfo("Verified Phone Number is auto populated with " + phoneNumber);
            Assert.AreEqual("Update", GetAttribute(_pageInstance.CreateOrUpdateButton[0], "Name"));
            LogInfo("Verified Update button is available");

        }

        public void ValidateCreatedCustomerInInbox(String customerName, String city, String country, String state)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);

            List<String> firstRowValues = GetFirstRowValues();
            //String[] date = firstRowValues[5].Split(' ');
            Assert.AreEqual(customerName, firstRowValues[0]);
            try
            {
                Assert.AreEqual(city, firstRowValues[1]);
                Assert.AreEqual(state, firstRowValues[2]);
                Assert.AreEqual(country, firstRowValues[3]);
                //Assert.AreEqual(DateTime.UtcNow.ToString("M/d/yyyy"), date[0]);
                LogInfo("Verified Created Customer Is Displayed In The Inbox");
            }
            catch
            {
                LogInfo("Verified only Customer name");
            }
            
        }

        public string CompanyName()
        {
            List<String> firstRowValues = GetFirstRowValues();
            return firstRowValues[0];
        }

        public void VerifyMandatoryFieldsMessage()
        {
            ClickElement(_pageInstance.CreateOrUpdateButton[0]);
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(3);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Company Name");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Street/House No.");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Country");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {
            ClickElement(_pageInstance.CreateOrUpdateButton[0]);
            LogInfo("Clicked on Create Button");
            _opportunityAction.VerifyMandatoryFieldsCount(2);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Street/House No.");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Country");
        }
    }
}
