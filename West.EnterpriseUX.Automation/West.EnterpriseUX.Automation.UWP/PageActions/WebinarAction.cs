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
    public class WebinarAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly WebinarPage _pageInstance;
        public WebinarAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new WebinarPage(_session);
        }
        public void ClickOnCreateWebinar()
        {
            ClickElement(_pageInstance.CreateWebinar);
            LogInfo("Clicked on create webinar");
            WaitForLoadingToDisappear();
        }
        public void EnterSubject(String subject)
        {
            ClickClearEnterText(_pageInstance.Subject, subject);
            LogInfo("Entered subject");
        }

        public void SelectReference(String reference)
        {
            EnterText(_pageInstance.Reference, reference);
            LogInfo("Selected reference ");
        }
        public string SelectLinkReference()
        {
            String selectedValue = SelectFirstValueInDropDown(_pageInstance.Link, "Value.Value");
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
        public void EnterComments(String comment)
        {
            ClickClearEnterText(_pageInstance.Comments, comment);
            LogInfo("Entered Comment");
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
        public string EnterWebinar(String subject = "Subject", String reference = "Contact", string firstName = "FirstName",
            string lastName = "LastName", string email = "veeresh@westpharma.com", String country = "USA", string phoneCode = "US",
            string phoneNumber = "9060666615", string comment = "Comment")
        {
            SelectReference(reference);
            String selectedLink = SelectLinkReference();
            EnterSubject(subject);
            EnterEmail(email);
            EnterFirstName(firstName);
            EnteLastName(lastName);
            EnterCountry(country);
            EnterPhoneCode(phoneCode);
            EnterPhoneNumber(phoneNumber);
            EnterComments(comment);
            return selectedLink;
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on create button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnWebinarTab()
        {
            ClickElement(_pageInstance.WebinarTab);
            LogInfo("Clicked on Webinar Tab");
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

        public void ClickOnEditWebinar()
        {
            ClickElement(_pageInstance.EditWebinar);
            LogInfo("Clicked on edit Webinar");
            WaitForLoadingToDisappear();
        }

        public void ValidateWebinarInUpdatePage(List<String> input)
        {

            Assert.AreEqual(input[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            Assert.AreEqual(input[4], GetAttribute(_pageInstance.ProspectDropdown, "Value.Value"));
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateWebinarButton);
            LogInfo("Clicked on update web inar button");
            WaitForLoadingToDisappear();
        }
    }
}
