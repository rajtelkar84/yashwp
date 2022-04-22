using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
    public class ConfigureProductsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ConfigureProductsPage _pageInstance;
        //string soldToDetails;
        public ConfigureProductsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ConfigureProductsPage(_session);
        }

        


        //}

        public void SelectfromCurrencyPicker(string currency)
        {
            WaitForElementToAppear("USD ( United States Dollar )");
            _pageInstance.CurrencyPicker.SendKeys(currency);
        }
      

        public void SelectIncoterms(string incoterm)
        {
            _pageInstance.IncotermPicker.SendKeys(incoterm);
        }

        public bool VerifyTargetPrice(string targetprice)
        {
            string actTargetprice = _pageInstance.TargetPrice.GetAttribute("Name");
            bool verifyTargetPrice = actTargetprice.Contains(targetprice);
            LogInfo("Target price matches the expected value " + targetprice + "- " + verifyTargetPrice);
            return verifyTargetPrice;
        }
        public bool VerifyStandardPrice(string standardprice)
        {
            string actStandardPrice = _pageInstance.StandardPrice.GetAttribute("Name");
            bool verifyStandardPrice = actStandardPrice.Contains(standardprice);
            LogInfo("Standard price matches the expected value " + standardprice + " -" + verifyStandardPrice);
            return verifyStandardPrice;
        }
        public bool VerifyMinimumOrderQuantityDisplayed()
        {
            bool verifyMinimumOrderQuantityDisplayed = Exists(_pageInstance.MinimumOrderQuantityLbl);
            LogInfo("Minimum order quantity lebel is drisplayed: " + verifyMinimumOrderQuantityDisplayed);         
            return verifyMinimumOrderQuantityDisplayed;
        }
        public string GetMinimumOrderQuantity()
        {
            //string[] separator = new string[] { "Minimum order quantity is " };
            string minOrderQuantity = _pageInstance.MinimumOrderQuantityLbl.GetAttribute("Name");
            LogInfo("Minimum order quantity displayed in the app is: " + minOrderQuantity);
            return minOrderQuantity;
        }
        public bool ValMinimumOrderQuantity(string minOrderQuantity)
        {
            string actMinimumOrderQuantity = _pageInstance.MinimumOrderQuantityLbVal.GetAttribute("Name");
            bool valMinimumOrderQuantity = actMinimumOrderQuantity.Contains(minOrderQuantity);
            LogInfo("Minimum order quantity displayed in the app matches the expected value " + valMinimumOrderQuantity);           
            return valMinimumOrderQuantity;
        }
        public void EnterOrderQuantity(string orderQuantity)
        {
            ClickElement(_pageInstance.Quanitity);
            ClearElement(_pageInstance.Quanitity);
            WaitForMoment(1);
            EnterText(_pageInstance.Quanitity, orderQuantity);
            LogInfo("Order quantity entered is - " + orderQuantity);
        }
        public void EnterProductPrice(string productPrice)
        {
            ClickElement(_pageInstance.ProductPrice);
            WaitForMoment(.5);
            EnterText(_pageInstance.ProductPrice, Keys.Control + "a" + Keys.Delete);
            ClearElement(_pageInstance.ProductPrice);
            EnterText(_pageInstance.ProductPrice, productPrice);
            LogInfo("Productprice entered is - " + productPrice);
        }
        public void EnterProductAnnualSalesForecast(string productAnnualSalesForecast)
        {
            ClickElement(_pageInstance.ProductAnnualSalesForecast);
            WaitForMoment(1);
            EnterText(_pageInstance.ProductAnnualSalesForecast, productAnnualSalesForecast);
            LogInfo("Annual sales forecast entered for this product is - " + productAnnualSalesForecast);
        }
        public bool VerifyAprovalRequiredDisplayed()
        {
            bool aprovalRequiredDisplayed = Exists(_pageInstance.ApprovalsRequiredLbl);
            LogInfo("Approval required label is displayed on screen : " + aprovalRequiredDisplayed);
            return aprovalRequiredDisplayed;
        }
        public void ClickOnAprovalRequired()
        {
            _pageInstance.ApprovalsRequiredLbl.Click();
            WaitForLoadingToDisappear();
            LogInfo("Approval required lable is clicked");
        }
        public bool VerifyApprovalRequiredPopUpIsOpen()
        {
            WaitForMoment(3);
            bool verifyApprovalRequiredPopUpIsOpen = _pageInstance.ApprovalListPopUpHeader.Displayed;
            LogInfo("Approver/Notifier list pop up is open - " + verifyApprovalRequiredPopUpIsOpen);
            return verifyApprovalRequiredPopUpIsOpen;
        }
        public void ClickOnApproverslink()
        {
            _pageInstance.Approverslink.Click();
            LogInfo("Approvers link is clicked");
        }
        public void ClickOnNotifierslink()
        {
            _pageInstance.Notifierslink.Click();
            LogInfo("Notifiers link is clicked");
        }
        public bool VerifyMUVPApprovalRequired()
        {
            bool verifyMUVPApprovalRequired = _pageInstance.MUVPApproval.Displayed;
            LogInfo("MUVP approval required - " + verifyMUVPApprovalRequired);
            return verifyMUVPApprovalRequired;
        }
        public bool VerifyAccountManagerApprovalRequired()
        {
            bool verifyAccountManagerApprovalRequired = _pageInstance.AccountManagerApproval.Displayed;
            LogInfo("Account manager approval is required - " + verifyAccountManagerApprovalRequired);
            return verifyAccountManagerApprovalRequired;
        }
        public bool VerifySalesDirectorApprovalRequired()
        {
            bool verifySalesDirectorApprovalRequired = _pageInstance.SalesDirectorApproval.Displayed;
            LogInfo("Sales director approval is required - " + verifySalesDirectorApprovalRequired);
            return verifySalesDirectorApprovalRequired;
        }
        public bool VerifyProductDirectorApprovalRequired()
        {
            bool verifyProductDirectorApprovalRequired = _pageInstance.ProductDirectorApproval.Displayed;
            LogInfo("Product director approval is required - " + verifyProductDirectorApprovalRequired);
            return verifyProductDirectorApprovalRequired;
        }
        public bool VerifySalesDirectorNotificationRequired()
        {
            bool verifySalesDirectorNotificationRequired = _pageInstance.SalesDirectorApproval.Displayed;
            LogInfo("Sales director Notification is required - " + verifySalesDirectorNotificationRequired);
            return verifySalesDirectorNotificationRequired;
        }
        public bool VerifyProductDirectorNotificationRequired()
        {
            //var elements = _session.FindElementsByXPath("(//Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Product Director'])[2]");
            bool verifyProductDirectorApprovalRequired = _pageInstance.ProductDirectorNotification.Displayed;
            //_pageInstance.ProductDirectorNotification
            LogInfo("Product director notification is required - " + verifyProductDirectorApprovalRequired);
            return verifyProductDirectorApprovalRequired;
        }
        public bool VerifyPricingManagerNotificationRequired()
        {
            bool verifyPricingManagerNotificationRequired = _pageInstance.PricingManagerNotification.Displayed;
            LogInfo("Pricing Manager notification is required - " + verifyPricingManagerNotificationRequired);
            return verifyPricingManagerNotificationRequired;
        }
        public bool VerifyPortfolioStrategyNotificationRequired()
        {
            bool verifyPortfolioStrategyNotificationRequired = _pageInstance.PortfolioStrategyNotification.Displayed;
            LogInfo("Portfolio Strategy notification is required - " + verifyPortfolioStrategyNotificationRequired);
            return verifyPortfolioStrategyNotificationRequired;
        }
        public bool VerifyMUVPNotificationRequired()
        {
            bool verifyMUVPNotificationRequired = _pageInstance.MUVPApproval.Displayed;
            LogInfo("MUVP Notification is required - " + verifyMUVPNotificationRequired);
            return verifyMUVPNotificationRequired;
        }
        public void VerifyAMApprovalReason(string[] amApprovalReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if (designationNames[i].GetAttribute("Name").Contains("Account Manager"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < amApprovalReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(amApprovalReason[j]))
                        {
                            LogInfo("Account Manager Aproval reason contains - " + amApprovalReason[j]);
                        }
                        else
                        {
                            LogInfo("Account Manager Aproval reason does not contain - " + amApprovalReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifySDApprovalReason(string[] sdApprovalReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if (designationNames[i].GetAttribute("Name").Contains("Sales Director"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < sdApprovalReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(sdApprovalReason[j]))
                        {
                            LogInfo("Sales Director Aproval reason contains - " + sdApprovalReason[j]);
                        }
                        else
                        {
                            LogInfo("Sales Director Aproval reason does not contain - " + sdApprovalReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifyPMApprovalReason(string[] pmApprovalReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if (designationNames[i].GetAttribute("Name").Contains("Product Director"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < pmApprovalReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(pmApprovalReason[j]))
                        {
                            LogInfo("Product Director Aproval reason contains - " + pmApprovalReason[j]);
                        }
                        else
                        {
                            LogInfo("Product Director Aproval reason does not contain - " + pmApprovalReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifyMUVPApprovalReason(string[] muvpApprovalReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                //IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
                if (designationNames[i].GetAttribute("Name").Contains("MU VP"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < muvpApprovalReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(muvpApprovalReason[j]))
                        {
                            LogInfo("MUVP Aproval reason contains - " + muvpApprovalReason[j]);
                        }
                        else
                        {
                            LogInfo("MUVP Aproval reason does not contain - " + muvpApprovalReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifyPDNotificationReason(string[] pdNotificationReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if ((designationNames[i].GetAttribute("Name").Contains("Product Director")) && (designationNames[i].Displayed))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < pdNotificationReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(pdNotificationReason[j]))
                        {
                            LogInfo("Product Director Notification reason contains - " + pdNotificationReason[j]);

                        }
                        else
                        {
                            LogInfo("Product Director Notification reason does not contain - " + pdNotificationReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifyPricingManagerNotificationReason(string[] prmNotificationReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if (designationNames[i].GetAttribute("Name").Contains("Pricing Manager"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < prmNotificationReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(prmNotificationReason[j]))
                        {
                            LogInfo("Pricing Manager Notification reason contains - " + prmNotificationReason[j]);
                            //break;
                        }
                        else
                        {
                            LogInfo("Pricing Manager Notification reason does not contain - " + prmNotificationReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void VerifyPortfolioStrategyNotificationReason(string[] psNotificationReason)
        {
            IList<WindowsElement> approvalReasons = _pageInstance.ApprovalReasons;
            IList<WindowsElement> designationNames = _pageInstance.DesignationNames;
            for (int i = 0; i < approvalReasons.Count; i++)
            {
                if (designationNames[i].GetAttribute("Name").Contains("Portfolio Strategy"))
                {
                    string approvalReasonText = approvalReasons[i].GetAttribute("Name");
                    for (int j = 0; j < psNotificationReason.Length; j++)
                    {
                        if (approvalReasonText.Contains(psNotificationReason[j]))
                        {
                            LogInfo("Portfolio Strategy Notification reason contains - " + psNotificationReason[j]);
                            //break;
                        }
                        else
                        {
                            LogInfo("Portfolio Strategy Notification reason does not contain - " + psNotificationReason[j]);
                        }
                    }
                    break;
                }
            }
        }
        public void CloseTheApprovalPopUp()
        {
            WaitForMoment(3);
            _pageInstance.PopupCloseeBtn.Click();
            LogInfo("Approval popup closed");
            WaitForMoment(3);
        }

        public void ClickOnAddToQuote()
        {
            ClickElement(_pageInstance.AddToQuoteBtn);
            LogInfo("Add to quote button is clicked");
        }
        public void ClickOnAddProducts()
        {
            _pageInstance.AddProductsBtn.Click();
            LogInfo("Add products button is clicked");
        }
        public void ClickOnViewQuoteList()
        {
            _pageInstance.ViewQuoteListbtn.Click();
            LogInfo("View quote list button is clicked");
        }
        public bool VerifyQuoteListPopUpDisplayed()
        {
            bool verifyQuoteListPopUpDisplayed = _pageInstance.QuoteListLbl.Displayed;
            LogInfo("Quotelist window is open: " + verifyQuoteListPopUpDisplayed);
            return verifyQuoteListPopUpDisplayed;
        }
        public bool VerifyQLMaterialID(string qlMaterialID)
        {
            try
            {
                WaitForLoadingToDisappear();
                bool verifyQLMaterialID = Exists(_pageInstance.GlobalMaterialID);
                String runtimeGMID = _pageInstance.GlobalMaterialID.GetAttribute("Name");
                if (qlMaterialID.Equals(runtimeGMID))
                {
                    LogInfo("Quotelist material id matches with the expected " + qlMaterialID + ": " + verifyQLMaterialID);
                    return true;
                }
                else
                {
                    
                    return false;
                }

                
            }
            catch (Exception )
            {
                return false;
            }
        }
        public bool VerifyQlProductQuantity(string prodQuantity)
        {
            try
            {
                string qlProductQuantity = _pageInstance.QLQuantity.GetAttribute("Name");
                bool verifyQlProductQuantity = qlProductQuantity.Contains(prodQuantity);
                LogInfo("Quotelist product quantity matches with the expected " + prodQuantity + ": " + verifyQlProductQuantity);
                if (verifyQlProductQuantity)
                {
                    LogInfo("Verified QL Product Quantity");
                }
                else
                {
                    LogInfo("Problem in verifing QL Product Quantity Quotelist product quantity matches with the expected " + prodQuantity + ": " + verifyQlProductQuantity);
                }
                return verifyQlProductQuantity;
            }
            catch (Exception e)
            {
                LogInfo("Problem in verifing QL Product Quantity" + e);
                return false;
            }
        }
        public bool VerifyQlProductPrice(string prodPrice)
        {
            try
            {
                string qlPricePerProduct = _pageInstance.QLPricePerProduct.GetAttribute("Name");
                bool verifyQlProductPrice = qlPricePerProduct.Contains(prodPrice);
                LogInfo("Quotelist product price matches with the expected " + prodPrice + ": " + verifyQlProductPrice);
                if (verifyQlProductPrice)
                {
                    LogInfo("Verified QL product price ");
                }
                else
                {
                    LogInfo("Problem in verifing QL Product price Quotelist product price matches with the expected " + prodPrice + ": " + verifyQlProductPrice);
                }
                return verifyQlProductPrice;
            }
            catch (Exception e)
            {
                LogInfo("Problem in verifing QL Product price" + e);
                return false;
            }
        }
        public bool VerifyQlTotaAmount(string qlTotAmt)
        {
            try
            {
                string qlTotalAmt = _pageInstance.TotalAmt.GetAttribute("Name");
                string qlNewTotalAmt = qlTotalAmt.Replace(",", "");
                bool verifyQlTotaAmount = qlNewTotalAmt.Contains(qlTotAmt);
                LogInfo("Quotelist total amount matches with the expected " + qlTotAmt + ": " + verifyQlTotaAmount);
                if (verifyQlTotaAmount)
                {
                    LogInfo("Verified QL Total amount");
                }
                else
                {
                    LogInfo("Quotelist total amount matches with the expected " + qlTotAmt + ": " + verifyQlTotaAmount);
                }
                return verifyQlTotaAmount;
            }
            catch (Exception)
            {
                LogInfo("Problem in verifing QL Total amount");
                return false;
            }
        }
        public void ClickOnEditProduct()
        {
            _pageInstance.QLEditProduct.Click();
            LogInfo("Edit product is clicked from the quote cart");
        }
        public void ClickOnDeleteProduct()
        {
            _pageInstance.QLDeleteProduct.Click();
            LogInfo("Delete product is clicked from the quote cart");
        }
        public void ClickOnSaveAsDraft()
        {
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SaveAsDraftbtn);
            LogInfo("Save as draft button is clicked");
        }
        public void ClickOnProceed()
        {
            ClickElement(_pageInstance.Proceedbtn);
            WaitForLoadingToDisappear();
            LogInfo("Proceed button is clicked");
        }
        public bool VerifyConfirmationPopUpOpen()
        {
            bool verifyConfirmationPopUpOpen = Exists(_pageInstance.ConfirmationPopUpHdr);
            LogInfo("Confirmation pop up is displayed - " + verifyConfirmationPopUpOpen);
            return verifyConfirmationPopUpOpen;

        }
        public string GetQuoteNameFromPopup()
        {
            String createdQuote = GetAttribute(_pageInstance.ConfirmationPopupText, "Name");
            LogInfo("Got Quote name from popup");          
            return WordInBetween(createdQuote, "Your Quote", "- ");
        }
        public void ClickOnYesOnConfirmationPopUp()
        {
            ClickElement(_pageInstance.ConfirmationOkButtonQ);
            LogInfo("Confirmation is accepted");
        }
        public void ClickOnNoOnCOnfirmationPopUp()
        {
            _pageInstance.PopUpNoBtn.Click();
        }
    }
}
