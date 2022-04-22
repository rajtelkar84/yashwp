using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CreateQuoteAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CreateQuotePage _pageInstance;
        //string soldToDetails;
        public CreateQuoteAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CreateQuotePage(_session);
        }
        public void ClickOnSoldToPicker()
        {
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SoldtoPicker);
            LogInfo("Clicked on Soldto picker");
            WaitForLoadingToDisappear();
        }
        public void SearchSoldTo(string soldtoID)
        {
            try
            {
                WaitForMoment(5);
                ClickElement(_pageInstance.SoldToSearch);
            }
            catch (Exception)
            {
                WaitForMoment(5);
                ClickElement(_pageInstance.SoldToSearch);
            }
            
            WaitForMoment(4);
            SplitAndEnterText(_pageInstance.SoldToSearch, soldtoID);
            WaitForLoadingToDisappear();
        }
        public void SelectSoldTo(string soldToDetails)
        {
            ClickElement(_pageInstance.SoldtoItem(soldToDetails));
            LogInfo("The sold to " + soldToDetails + " has been selected");
        }
        public void SearchByMaterialID(string materialID)
        {

            int count = _pageInstance.SearchArrowButton.Count;
            ClickElement(_pageInstance.SearchArrowButton[count-1]);
            ClickElement(_pageInstance.SearchArrowButton[count - 1]);
            WaitForMoment(2);
            WaitForLoadingToDisappear();
            SplitAndEnterText(_pageInstance.SearchTextboxInPicker, materialID);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SearchByMaterialIdListPicker(materialID));
            ClickElement(_pageInstance.SubmitInPicker);
           
            WaitForLoadingToDisappear();
            WaitForMoment(6);
            LogInfo("The material id searched is - " + materialID);

        }
        public void ClickOnSearchIcon()
        {
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SearchIcon);
            WaitForLoadingToDisappear();
            try
            {
                if (Exists(_pageInstance.SearchIcon)) { ClickElement(_pageInstance.SearchIcon); }
            }
            catch (Exception)
            {
                LogInfo("Clicked search button second time" );
            }
        }
        public bool VerifyCreateQuotePageDisplayed()
        {
            bool createQuoteDisplayed = Exists(_pageInstance.CreateQuote);
            LogInfo("Create quote page is displayed - "+ createQuoteDisplayed);
            return createQuoteDisplayed;
        }
        public bool VerifySoldToPopUpDisplayed()
        {
            bool soldtoDisplayed = Exists(_pageInstance.SoldToElement);
            LogInfo("Sold to pop up is displayed - "+ soldtoDisplayed);
            return soldtoDisplayed;
        }
        public void ClickOnCOnfigureProduct()
        {
            ClickElement(_pageInstance.ConfigureProductSegment);
        }
        public void SelectProductLine(string productLine)
        {
            ClickElement(_pageInstance.ProductLine(productLine));
            LogInfo("Product line selected is - " + productLine);
        }
        public void SelectFlurotecCoating(string flurotecCoating)
        {
            ClickElement(_pageInstance.FlurotecCoating(flurotecCoating));
            WaitForLoadingToDisappear();
            LogInfo("Flurotec coating selected is - "+ flurotecCoating);
        }
        public void SelectConfiguration(string configuration)
        {
            ClickElement(_pageInstance.Configuration(configuration));
            WaitForLoadingToDisappear();
            LogInfo("Configuration selected is - " + configuration);
        }
        public void SelectFinishingLevel(string finishingLevel)
        {
            LogInfo("FInishing level selected is - "+finishingLevel);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.FinishingLevel(finishingLevel));
        }
        public bool VerifyNoOfProductsFound(string noOfProducts)
        {
            try
            {
                string NoOfProductsFound = _pageInstance.ProductsFoundLbl.GetAttribute("Name");
                bool productFound = NoOfProductsFound.Contains(noOfProducts);
                if (productFound)
                {
                    LogInfo("No of products found with the search category is - " + noOfProducts);
                }
                else
                {
                    LogInfo("No of products found with the search category is not" + noOfProducts);
                    
                }

                return productFound;
            }
            catch (Exception )
            {
                
                return false;
            }
        }
        public void ClickOnProceedBtn()
        {
            ClickElement(_pageInstance.Proceedbtn);
            WaitForLoadingToDisappear();
            LogInfo("Proceed button is clicked");
        }
        public void ClickOnResetBtn()
        {
            _pageInstance.Resetbtn.Click();
        }
        public void ClickOnCustomerPricing()
        {
            _pageInstance.CustomerPricing.Click();
            LogInfo("Customer material pricing icon is clicked");
        }
        public bool VerifyCustomerMaterialPopUpIsOpen()
        {
            bool customerMaterialPopUpIsOpen = Exists(_pageInstance.CustomerPricingHeader);
            if (customerMaterialPopUpIsOpen)
            {
                LogInfo("Customer material pricing pop up is open - " + customerMaterialPopUpIsOpen);
            }
            else
            {
                LogInfo("Customer material pricing pop up is not displayed");
            }
            return customerMaterialPopUpIsOpen;
        }
    }
}
