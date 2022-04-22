using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class ContactUSAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ContactUSPage _pageInstance;
        public ContactUSAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ContactUSPage(_session);
        }
        public void ClickOnCreateContactUs()
        {
            WaitForMoment(1);
            ClickElement(_pageInstance.CreateContactUs);
            LogInfo("Clicked on create contact us");
            WaitForLoadingToDisappear();
        }
        public void EnterSubject(String subject)
        {
            ClickClearEnterText(_pageInstance.Subject, subject);
            LogInfo("Entered subject");
        }

        public void SelectReference(String reference)
        {
            EnterText(_pageInstance.Entity, reference);
            LogInfo("Selected reference ");
        }
        public string SelectLinkReference()
        {
            WaitForMoment(2);
            String selectedValue = SelectFirstValueInDropDown(_pageInstance.Link, "Value.Value");
            LogInfo("Selected related link");
            return selectedValue;
        }

        public string Selectlink()
        {
            return SelectFirstValueInDropDown(_pageInstance.Link, "Value.Value");
        }

        public void EnterStartTime(String startTime)
        {
            ClickClearEnterText(_pageInstance.StartTime, startTime);
            LogInfo("Entered startTime");
        }
        public void EnterFirstName(String firstName)
        {
            ClickClearEnterText(_pageInstance.FirstName, firstName);
            LogInfo("Entered FirstName");
        }

        public void EnteLastName(String lastName)
        {
            ClickClearEnterText(_pageInstance.LastName, lastName);
            LogInfo("Entered LastName");
        }

        public void EnterEmail(String email)
        {
            ClickClearEnterText(_pageInstance.Email, email);
            LogInfo("Entered Email");
        }
        public void EnterCompanyName(String companyName)
        {
            ClickClearEnterText(_pageInstance.CompanyName, companyName);
            LogInfo("Entered company name");
        }
        public void EnterTitle(String title)
        {
            ClickClearEnterText(_pageInstance.Title, title);
            LogInfo("Entered title");
        }

        public void EnterStreet(String street)
        {
            ClickClearEnterText(_pageInstance.Street, street);
            LogInfo("Entered street");
        }
        public void EnterZipCode(String zip)
        {
            ClickClearEnterText(_pageInstance.Zip, zip);
            LogInfo("Entered zip code");
        }

        public void EnterCity(String city)
        {
            ClickClearEnterText(_pageInstance.City, city);
            LogInfo("Entered city");
        }

        public void EnterCountry(String country)
        {
            EnterText(_pageInstance.Country, country);
            LogInfo("Entered country");
        }
        public void EnterState(String state)
        {
            EnterText(_pageInstance.State, state);
            LogInfo("Entered state");
        }

        public void EnterMessage(String message)
        {
            ClickClearEnterText(_pageInstance.Message, message);
            LogInfo("Entered message");
        }
        public void EnterCustomerIntrest(String customerIntrest)
        {
            ClickClearEnterText(_pageInstance.CustomerIntrest, customerIntrest);
            LogInfo("Entered customer Intrest");
        }

        public void EnterPhoneCode(String phoneCode)
        {
            EnterText(_pageInstance.PhoneCode, phoneCode);
            LogInfo("Entered phone code");
        }
        public void EnterPhoneNumber(String phoneNumber)
        {
            ClickClearEnterText(_pageInstance.PhoneNumber, phoneNumber);
            LogInfo("Entered Company phone number");
        }

        public void ClickContactUSEnterValues()
        {
            ClickElement(_pageInstance.ContactDetailsTabEnterValues);
            ClickElement(_pageInstance.ContactDetailsTabEnterValues);
            LogInfo("Clicked on the contact details tab to enter values ");
        }


        /// </summary>
        /// <param name="subject"></param>
        /// <param name="reference"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="country"></param>
        /// <param name="phoneCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string EnterContactUs(String subject = "Subject", String reference = "Contact", string startTime = "12:00 AM", string firstName = "FirstName",
            string lastName = "LastName", string email = "veeresh@westpharma.com", string title = "Title", string companyName = "CompanyName", string street = "Street",
            string city = "New York", string zip = "560078", String country = "USA", string state = "New York", string message = "Message", string customerIntrest = "Customer intrest",
            string phoneCode = "US", string phoneNumber = "9060666615")
        {
            EnterSubject(subject);
            SelectReference(reference);
            String selectedLink = SelectLinkReference();
            EnterStartTime(startTime);
            ClickContactUSEnterValues();
            EnterFirstName(firstName);
            EnteLastName(lastName);
            EnterEmail(email);
            EnterTitle(title);
            EnterCompanyName(companyName);
            EnterStreet(street);
            EnterCity(city);
            EnterZipCode(zip);
            EnterCountry(country);
            EnterState(state);
            EnterMessage(message);
            EnterCustomerIntrest(customerIntrest);
            EnterPhoneCode(phoneCode);
            EnterPhoneNumber(phoneNumber);
            return selectedLink;
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on create button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnContactUsTab()
        {
            ClickElement(_pageInstance.ContactUsTab);
            LogInfo("Clicked on Contact us tab");
            WaitForLoadingToDisappear();
        }

        public void ValidateCreatedWebinarInInboxGrid(String subject, String status, String type, String regarding)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(subject, firstRowValues[0]);
            Assert.AreEqual(status, firstRowValues[1]);
            Assert.AreEqual(type, firstRowValues[2]);
            Assert.AreEqual(regarding, firstRowValues[4]);
            LogInfo("Verified edit Webinar");
        }

        public List<String> GetFirstRowValues()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }

        public void ClickOnEditContactUs()
        {
            ClickElement(_pageInstance.EditContactUs);
            LogInfo("Clicked on edit Contact Us");
            WaitForLoadingToDisappear();
        }

        public void ValidateContactUsInUpdatePage(List<String> firstRowValue)
        {
            Assert.AreEqual(firstRowValue[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            Assert.AreEqual(firstRowValue[4], GetAttribute(_pageInstance.ProspectDropdown, "Value.Value"));
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateWebinarButton);
            LogInfo("Clicked on update web inar button");
            WaitForLoadingToDisappear();
        }
    }
}
