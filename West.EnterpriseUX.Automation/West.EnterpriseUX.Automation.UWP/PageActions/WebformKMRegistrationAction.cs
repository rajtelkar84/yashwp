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
    public class WebformKMRegistrationAction :BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly WebformKMRegistrationPage _pageInstance;
        public WebformKMRegistrationAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new WebformKMRegistrationPage(_session);
        }
        public void ClickOnWebFormKMRegistration()
        {
            ClickElement(_pageInstance.CreateWebFormKMRegistration);
            LogInfo("Clicked on create web form km registration");
            WaitForLoadingToDisappear();
        }
        public void EnterSubject(String subject)
        {
            ClickClearEnterText(_pageInstance.Subject,subject);
            LogInfo("Entered subject");
        }

        public void SelectReference(String reference)
        {
            EnterText(_pageInstance.Reference, reference);
            LogInfo("Selected reference ");
        }
        public string SelectLinkReference()
        {
            string selectedValue = string.Empty;
            ClearElement(_pageInstance.Link);
            ClickElement(_pageInstance.Link);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Return);
            WaitForMoment(.25);
            selectedValue = GetAttribute(_pageInstance.Link, "Value.Value");
            LogInfo("Selected related link");
            return selectedValue;
        }

        public string Selectlink()
        {
           return SelectFirstValueInDropDown(_pageInstance.Link, "Value.Value");
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

        public void EnterCountry(String country)
        {
            ClickClearEnterText(_pageInstance.Country, country);
            LogInfo("Entered country");
        }
        public void EnterCompanyName(String companyName)
        {
            ClickClearEnterText(_pageInstance.CompanyName, companyName);
            LogInfo("Entered companyName");
        }

        public void EnterCity(String city)
        {
            ClickClearEnterText(_pageInstance.City, city);
            LogInfo("Entered city");
        }
        public void EnterState(String state)
        {
            ClickClearEnterText(_pageInstance.State, state);
            LogInfo("Entered state");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="reference"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="country"></param>
        /// <param name="companyName"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string EnterWebformKMRegistration(String subject = "Subject", String reference = "Contact", string firstName = "FirstName",
            string lastName = "LastName", string email = "veeresh@westpharma.com", String country = "USA", string companyName = "Company Name",
            string city = "New York", string state = "New York")
        {

            EnterSubject(subject);
            SelectReference(reference);
            String selectedLink =SelectLinkReference();
            EnterFirstName(firstName);
            EnteLastName(lastName);
            EnterEmail(email);
            EnterCountry(country);
            EnterCompanyName(companyName);
            EnterCity(city);
            EnterState(state);
            return selectedLink;
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on create button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnKMRegistrationTab()
        {
            ClickElement(_pageInstance.KMRegistrationTab);
            LogInfo("Clicked on create Create KM Registration Tab");
            WaitForLoadingToDisappear();
        }

        public void ValidateCreatedContactInInboxGrid(String subject, String status, String type, String regarding)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(subject, firstRowValues[0]);
            Assert.AreEqual(status, firstRowValues[1]);
            Assert.AreEqual(type, firstRowValues[2]);
            Assert.AreEqual(regarding, firstRowValues[4]);
            LogInfo("Verified created web form in inbox grid");
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

        public void ClickOnEditKMRegistration()
        {
            ClickElement(_pageInstance.EditWebformKMRegistration);
            LogInfo("Clicked on edit Webform KM Registration");
            WaitForLoadingToDisappear();
        }

        public void ValidateCampaignResponseInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            Assert.AreEqual(input[4], GetAttribute(_pageInstance.ProspectDropdown, "Value.Value"));
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateWebFormButton);
            LogInfo("Clicked on update web form button");
            WaitForLoadingToDisappear();
        }
    }
}
