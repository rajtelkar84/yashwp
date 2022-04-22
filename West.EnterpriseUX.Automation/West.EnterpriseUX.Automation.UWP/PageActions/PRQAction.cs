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
    public class PRQAction:BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly PRQPage _pageInstance;

        public PRQAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new PRQPage(_session);
        }

        public void ClickOnPRQ()
        {
            ClickElement(_pageInstance.CreatePRQ);
            LogInfo("Clicked on create PRQ");
            WaitForLoadingToDisappear();
        }

        public void ClickEditPRQ()
        {
            ClickElement(_pageInstance.EditPRQ);
            LogInfo("Clicked on edit PRQ");
            WaitForLoadingToDisappear();
        }

        public void EnterFirstName(String firstName)
        {
            ClickClearEnterText(_pageInstance.FirstName,firstName);
            LogInfo("Entered First Name");
        }

        public void EnterDataByLabel(String firstName,string label)
        {
            ClickClearEnterText(_pageInstance.ElementByLabel(label), firstName);
            LogInfo("Entered "+label);
        }

        public void EnterSensitivities(string sensitivities)
        {
            ClickClearEnterText(_pageInstance.Sensitivities,sensitivities);
            LogInfo("Entered sensitivities" );
        }

        public void ClickOnProductInformationTab()
        {
            ClickElement(_pageInstance.ProductInformationTab);
            LogInfo("Clicked on Product information tab");
            WaitForLoadingToDisappear();
        }
        public void ClickOnPRQTab()
        {
            ClickElement(_pageInstance.PRQTab);
            LogInfo("Clicked on PRQ tab");
            WaitForLoadingToDisappear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="region"></param>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public void EnterPersonalInformation(string companyName="companyName", string firstName = "FirstName", 
            string lastName = "Last Name",string address1 ="address1", string address2 = "address2",
            string city = "New York",string region="New york region",string country = "USA",string zip="560078",
            string email="veeresh@westpharma.com",string phone="9060666615")
        {
            EnterDataByLabel(companyName, "Company Name");
            EnterDataByLabel(firstName, "First Name");
            EnterDataByLabel(lastName, "Last Name");
            EnterDataByLabel(address1, "Address Line 1");
            EnterDataByLabel(address2, "Address Line 2");
            EnterDataByLabel(city, "City");
            EnterDataByLabel(region, "Region");
            EnterDataByLabel(country, "Country");
            EnterDataByLabel(zip, "Zip Code");
            EnterDataByLabel(email, "Email");
            EnterDataByLabel(phone, "Phone");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="chemicalDescription"></param>
        /// <param name="ChemicalName"></param>
        /// <param name="category"></param>
        /// <param name="excipient"></param>
        /// <param name="pH"></param>
        /// <param name="storageCondition"></param>
        /// <param name="sensitivities"></param>
        /// <param name="comments"></param>
        public void EnterProductInformation(String productName ="ProductName", string chemicalDescription="Chemical Destribution",
          string ChemicalName="ChemicalName",string category = "catagory",string excipient ="excipient",string pH="6",
          string storageCondition="storage condition",string sensitivities= "Sensitivities",string comments="comment")
        {
            EnterDataByLabel(productName, "Generic Product Name");
            EnterDataByLabel(chemicalDescription, "Chemical Description");
            EnterDataByLabel(ChemicalName, "Chemical Name of");
            EnterDataByLabel(category, "Therapeutic Category");
            EnterDataByLabel(excipient, "Excipients Used");
            EnterDataByLabel(pH, "pH of a Solution");
            EnterDataByLabel(storageCondition, "Storage Conditions");
            EnterSensitivities(sensitivities);
            EnterDataByLabel(comments, "Sensitivities Comments");
        }

        public void ValidateCreatedPRQInInboxGrid(String subject, String status, String type,string regarding)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(subject, firstRowValues[0]);
            Assert.AreEqual(status, firstRowValues[1]);
            Assert.AreEqual(type, firstRowValues[2]);
            Assert.AreEqual(regarding, firstRowValues[4]);
            LogInfo("Verified PRQ");
        }

        public void ValidatePRQInUpdatePage(List<String> firstRowValue)
        {
            Assert.AreEqual(firstRowValue[0], GetAttribute(_pageInstance.ElementByLabel("Company Name"), "Value.Value"));
            //Assert.AreEqual(firstRowValue[4], GetAttribute(_pageInstance.Link, "Value.Value"));
        }
    }
}
