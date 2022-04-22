using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class QuotesTest : BaseTest
    {
        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the create new quote functionality of the application by searching the product from category;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_175131.csv", "Quotes_175131#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_175131.csv")]

        public void TC_175131_QuoteCreationProductSearchByCategoryCompleted()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();
                string productLine = this.TestContext.DataRow["productLine"].ToString();
                string flurotecCoating = this.TestContext.DataRow["flurotecCoating"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string finishingLevel = this.TestContext.DataRow["finishingLevel"].ToString();
                string noOfProductsFound = this.TestContext.DataRow["noOfProductsFound"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string incoterms = this.TestContext.DataRow["incoterms"].ToString();
                string minOrderQuantity = this.TestContext.DataRow["minOrderQuantity"].ToString();
                string orderQuantity = this.TestContext.DataRow["orderQuantity"].ToString();
                string productPrice = this.TestContext.DataRow["productPrice"].ToString();
                string productAnnualSalesForecast = this.TestContext.DataRow["productAnnualSalesForecast"].ToString();
                string qlMaterialID = this.TestContext.DataRow["qlMaterialID"].ToString();
                string qlTotAmt;
                string justification = this.TestContext.DataRow["justification"].ToString();

              
                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on the master icon(+ icon)
                _inboxAction.ClickOnCreateMasterAction();
                WaitForMoment(2);
                //Click on Create new quote
                _quoteAction.ClickOnCreateQuote();
                WaitForMoment(5);
                //Validate Create quote page is opened
                Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());
                WaitForMoment(2);
                //Search and select the sold to customer from the picker
                _createQuoteAction.ClickOnSoldToPicker();
                WaitForMoment(5);
                Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());

                _createQuoteAction.SearchSoldTo(soldtoId);
                WaitForMoment(3);
                _createQuoteAction.SelectSoldTo(soldtoId);
                WaitForMoment(1);
                //Search for the product by searching with the product configuration.
                _createQuoteAction.ClickOnCOnfigureProduct();
                WaitForMoment(2);
                //Select the product line
                _createQuoteAction.SelectProductLine(productLine);
                WaitForMoment(2);               
                //select the configuration
                _createQuoteAction.SelectConfiguration(configuration);
                
                WaitForMoment(2);
                //Select the finishing level.
                _createQuoteAction.SelectFinishingLevel(finishingLevel);
                _createQuoteAction.SelectFinishingLevel(finishingLevel);
                WaitForMoment(3);
                //Select the flrotec coating
                _createQuoteAction.SelectFlurotecCoating(flurotecCoating);
                WaitForMoment(2);
                //Verify the no of products found based on the product configuration.
                Assert.IsTrue(_createQuoteAction.VerifyNoOfProductsFound(noOfProductsFound));
                //Click on the proceed button.
                _createQuoteAction.ClickOnProceedBtn();
                WaitForMoment(3);
                //var elements = _session.FindElementsByXPath("//Text[contains(@Name,'Minimum order quantity')]");
                //Update the second page of create quote
                //Enter currency
                _configureProductsAction.SelectfromCurrencyPicker(currency);
                //Enter incoterms
                WaitForMoment(.5);
                _configureProductsAction.SelectIncoterms(incoterms);
                //Validate if minimum order quanity exists and displayed
                WaitForMoment(1);

                //_configureProductsAction.SelectfromCurrencyPicker(currency);
                Assert.IsTrue(_configureProductsAction.VerifyMinimumOrderQuantityDisplayed());
                //Validate the minimum order quantity
                Assert.IsTrue(_configureProductsAction.ValMinimumOrderQuantity(minOrderQuantity));
                WaitForMoment(1);
                //Enter the product quantity
                _configureProductsAction.EnterOrderQuantity(orderQuantity);
                //Enter the product price
                _configureProductsAction.EnterProductPrice(productPrice);
                //Enter product annual sales forecast
                _configureProductsAction.EnterProductAnnualSalesForecast(productAnnualSalesForecast);
                WaitForMoment(1);
                //Validate the approval required level doesnt appear for the product.
                //Assert.IsTrue(_configureProductsAction.VerifyAprovalRequiredNotDisplayed());
                //Click on Add to quote button
                _configureProductsAction.ClickOnAddToQuote();
                //Click on View quote list button
                WaitForMoment(1);
                _configureProductsAction.ClickOnViewQuoteList();
                //Validate the material id
                WaitForMoment(3);
                Assert.IsTrue(_configureProductsAction.VerifyQLMaterialID(qlMaterialID));
                //Validate the product quantity
                Assert.IsTrue(_configureProductsAction.VerifyQlProductQuantity(orderQuantity));
                //Validate the product price
                Assert.IsTrue(_configureProductsAction.VerifyQlProductPrice(productPrice));
                //Validate the total amount
                double totAmt = Convert.ToDouble(productPrice) * Convert.ToDouble(orderQuantity);
                totAmt = Math.Round(totAmt, 2,MidpointRounding.ToEven);
                qlTotAmt = totAmt.ToString();
                Assert.IsTrue(_configureProductsAction.VerifyQlTotaAmount(qlTotAmt));
                //Click on proceed button
                _configureProductsAction.ClickOnProceed();
                WaitForMoment(3);
                //Validate user is navigated to product review page
                Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                //Verify the total amount.
                Assert.IsTrue(_productReviewAction.VerifyTotalAmount(qlTotAmt));
                //Enter the justification
                _productReviewAction.EnterJustification(justification);
                //Click on request quote.
                WaitForMoment(2);
                _productReviewAction.ClickOnRequestQuote();
                WaitForMoment(3);
                //Verify the confirmation pop up is open
                //Assert.IsTrue(_configureProductsAction.VerifyConfirmationPopUpOpen());
                //Click on ok on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(3);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the create new quote functionality of the application by searching the product by id;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179050.csv", "Quotes_179050#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179050.csv")]

        public void TC_179050_QuoteCreationProductSearchByIDCompleted()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();
                string searchbymaterialid = this.TestContext.DataRow["searchByMaterialID"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string incoterms = this.TestContext.DataRow["incoterms"].ToString();
                string minOrderQuantity = this.TestContext.DataRow["minOrderQuantity"].ToString();
                string orderQuantity = this.TestContext.DataRow["orderQuantity"].ToString();
                string productPrice = this.TestContext.DataRow["productPrice"].ToString();
                string productAnnualSalesForecast = this.TestContext.DataRow["productAnnualSalesForecast"].ToString();
                string qlMaterialID = searchbymaterialid;
                string qlTotAmt;
                string justification = this.TestContext.DataRow["justification"].ToString();


                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on the master icon(+ icon)
                _inboxAction.ClickOnCreateMasterAction();
                WaitForMoment(.5);
                //Click on Create new quote
                _quoteAction.ClickOnCreateQuote();
                WaitForMoment(5);
                //Validate Create quote page is opened
                Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());
                WaitForMoment(2);
                //Search and select the sold to customer from the picker
                _createQuoteAction.ClickOnSoldToPicker();
                WaitForMoment(5);
                //Verify sold to popup displayed
                Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());
                //Select sold to
                _createQuoteAction.SearchSoldTo(soldtoId);
                WaitForMoment(3);
                _createQuoteAction.SelectSoldTo(soldtoId);
                WaitForMoment(1);
                //Search for the product by typing the material id.
                _createQuoteAction.SearchByMaterialID(searchbymaterialid);
                WaitForMoment(5);
                _createQuoteAction.ClickOnSearchIcon();
                WaitForMoment(3);

                //Update the second page of create quote
                //Enter currency
                _configureProductsAction.SelectfromCurrencyPicker(currency);
                //Enter incoterms
                WaitForMoment(.5);
                _configureProductsAction.SelectIncoterms(incoterms);
                //Validate if minimum order quanity exists and displayed
                WaitForMoment(1);

                //_configureProductsAction.SelectfromCurrencyPicker(currency);
                Assert.IsTrue(_configureProductsAction.VerifyMinimumOrderQuantityDisplayed());
                //Validate the minimum order quantity
                Assert.IsTrue(_configureProductsAction.ValMinimumOrderQuantity(minOrderQuantity));
                WaitForMoment(1);
                //Enter the product quantity
                _configureProductsAction.EnterOrderQuantity(orderQuantity);
                //Enter the product price
                _configureProductsAction.EnterProductPrice(productPrice);
                //Enter product annual sales forecast
                _configureProductsAction.EnterProductAnnualSalesForecast(productAnnualSalesForecast);
                WaitForMoment(1);
                //Click on Add to quote button
                _configureProductsAction.ClickOnAddToQuote();
                //Click on View quote list button
                WaitForMoment(1);
                _configureProductsAction.ClickOnViewQuoteList();
                //Validate the material id
                WaitForMoment(3);
                Assert.IsTrue(_configureProductsAction.VerifyQLMaterialID(qlMaterialID));
                //Validate the product quantity
                Assert.IsTrue(_configureProductsAction.VerifyQlProductQuantity(orderQuantity));
                //Validate the product price
                Assert.IsTrue(_configureProductsAction.VerifyQlProductPrice(productPrice));
                //Validate the total amount
                double totAmt = Convert.ToDouble(productPrice) * Convert.ToDouble(orderQuantity);
                qlTotAmt = totAmt.ToString();
                Assert.IsTrue(_configureProductsAction.VerifyQlTotaAmount(qlTotAmt));
                //Click on proceed button
                _configureProductsAction.ClickOnProceed();
                WaitForMoment(3);
                //Validate user is navigated to product review page
                Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                //Verify the total amount.
                Assert.IsTrue(_productReviewAction.VerifyTotalAmount(qlTotAmt));
                //Enter the justification
                _productReviewAction.EnterJustification(justification);
                //Click on request quote.
                WaitForMoment(2);
                _productReviewAction.ClickOnRequestQuote();
                WaitForMoment(2);
                //Verify the confirmation pop up is open
                //Assert.IsTrue(_configureProductsAction.VerifyConfirmationPopUpOpen());
                //Click on ok on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(3);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the save as draft functionality of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179052.csv", "Quotes_179052#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179052.csv")]

        public void TC_179052_ProductSearchByCategorySaveAsDraftFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();
                string productLine = this.TestContext.DataRow["productLine"].ToString();
                string flurotecCoating = this.TestContext.DataRow["flurotecCoating"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string finishingLevel = this.TestContext.DataRow["finishingLevel"].ToString();
                string noOfProductsFound = this.TestContext.DataRow["noOfProductsFound"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string incoterms = this.TestContext.DataRow["incoterms"].ToString();
                string orderQuantity = this.TestContext.DataRow["orderQuantity"].ToString();
                string productPrice = this.TestContext.DataRow["productPrice"].ToString();
                string productAnnualSalesForecast = this.TestContext.DataRow["productAnnualSalesForecast"].ToString();
                string qlMaterialID = this.TestContext.DataRow["qlMaterialID"].ToString();
                string qlTotAmt;


                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on the master icon(+ icon)
                _inboxAction.ClickOnCreateMasterAction();
                WaitForMoment(.5);
                //Click on Create new quote
                _quoteAction.ClickOnCreateQuote();
                WaitForMoment(1);
                //Validate Create quote page is opened
                Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());

                WaitForMoment(2);
                //Search and select the sold to customer from the picker
                _createQuoteAction.ClickOnSoldToPicker();
                WaitForMoment(5);
                Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());

                _createQuoteAction.SearchSoldTo(soldtoId);
                WaitForMoment(3);
                _createQuoteAction.SelectSoldTo(soldtoId);
                WaitForMoment(1);
                //Search for the product by searching with the product configuration.
                _createQuoteAction.ClickOnCOnfigureProduct();
                WaitForMoment(2);
                //Select the product line
                _createQuoteAction.SelectProductLine(productLine);
                WaitForMoment(2);
                //Select the flrotec coating
                _createQuoteAction.SelectFlurotecCoating(flurotecCoating);
                WaitForMoment(2);
                //select the configuration
                _createQuoteAction.SelectConfiguration(configuration);
                WaitForMoment(2);
                //Select the finishing level.
                _createQuoteAction.SelectFinishingLevel(finishingLevel);
                _createQuoteAction.SelectFinishingLevel(finishingLevel);
                WaitForMoment(5);
                //Verify the no of products found based on the product configuration.
                Assert.IsTrue(_createQuoteAction.VerifyNoOfProductsFound(noOfProductsFound));
                //Click on the proceed button.
                _createQuoteAction.ClickOnProceedBtn();
                WaitForMoment(3);
                //Update the second page of create quote
                //Enter currency
                _configureProductsAction.SelectfromCurrencyPicker(currency);
                //Enter incoterms
                WaitForMoment(2);
                _configureProductsAction.SelectIncoterms(incoterms);
                //Validate if minimum order quanity exists and displayed
                WaitForMoment(2);
                _configureProductsAction.EnterOrderQuantity(orderQuantity);
                //Enter the product price
                _configureProductsAction.EnterProductPrice(productPrice);
                //Enter product annual sales forecast
                _configureProductsAction.EnterProductAnnualSalesForecast(productAnnualSalesForecast);
                WaitForMoment(1);
                //Validate the approval required level doesnt appear for the product.
                Assert.IsTrue(_configureProductsAction.VerifyAprovalRequiredDisplayed());
                //Click on aprovals required
                _configureProductsAction.ClickOnAprovalRequired();
                WaitForMoment(2);
                //Validate the approval pop up is displayed
                Assert.IsTrue(_configureProductsAction.VerifyApprovalRequiredPopUpIsOpen());
                //CLick on close icon
                _configureProductsAction.CloseTheApprovalPopUp();
                //_configureProductsAction.ClickOnAddToQuote();
                WaitForMoment(1);
                //Click on Add to quote button
                _configureProductsAction.ClickOnAddToQuote();
                //Click on View quote list button
                WaitForMoment(1);
                _configureProductsAction.ClickOnViewQuoteList();
                //Validate the material id
                WaitForMoment(3);
                Assert.IsTrue(_configureProductsAction.VerifyQLMaterialID(qlMaterialID));
                //Validate the product quantity
                Assert.IsTrue(_configureProductsAction.VerifyQlProductQuantity(orderQuantity));
                //Validate the product price
                Assert.IsTrue(_configureProductsAction.VerifyQlProductPrice(productPrice));
                //Validate the total amount
                double totAmt = Convert.ToDouble(productPrice) * Convert.ToDouble(orderQuantity);
                qlTotAmt = totAmt.ToString();
                Assert.IsTrue(_configureProductsAction.VerifyQlTotaAmount(qlTotAmt));
                //Click on proceed button
                _configureProductsAction.ClickOnSaveAsDraft();
                WaitForMoment(2);
                //Verify the confirmation pop up is open
                Assert.IsTrue(_configureProductsAction.VerifyConfirmationPopUpOpen());
                //Click on yes on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                //_baseAction.WaitForLoadingToDisappear();
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(5);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the approvers and notifiers flow of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179053.csv", "Quotes_179053#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179053.csv")]

        public void TC_179053_VerifyApproversRequired()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();
                string searchbymaterialid = this.TestContext.DataRow["searchByMaterialID"].ToString();
                string productLine = this.TestContext.DataRow["productLine"].ToString();
                string flurotecCoating = this.TestContext.DataRow["flurotecCoating"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string finishingLevel = this.TestContext.DataRow["finishingLevel"].ToString();
                string noOfProductsFound = this.TestContext.DataRow["noOfProductsFound"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string incoterms = this.TestContext.DataRow["incoterms"].ToString();
                string orderQuantity = this.TestContext.DataRow["orderQuantity"].ToString();
                string productPrice = this.TestContext.DataRow["productPrice"].ToString();
                string productAnnualSalesForecast = this.TestContext.DataRow["productAnnualSalesForecast"].ToString();
                string qlMaterialID = this.TestContext.DataRow["qlMaterialID"].ToString();
                string qlTotAmt;
                string id = this.TestContext.Properties["TestUser1"].ToString();
                string pwd = this.TestContext.Properties["AutoTestUser1Password"].ToString();
                string profileName = this.TestContext.Properties["approvalRequiredProfile"].ToString();
                string passwordDecrypted = CommonTestSettings.Decrypt(pwd);
                
                loginAsUX1(function, inbox,id, passwordDecrypted, profileName);
                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on the master icon(+ icon)
                _inboxAction.ClickOnCreateMasterAction();
                WaitForMoment(.5);
                //Click on Create new quote
                _quoteAction.ClickOnCreateQuote();
                WaitForMoment(1);
                //Validate Create quote page is opened
                Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());

                WaitForMoment(2);
                //Search and select the sold to customer from the picker
                _createQuoteAction.ClickOnSoldToPicker();
                WaitForMoment(5);
                Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());

                _createQuoteAction.SearchSoldTo(soldtoId);
                WaitForMoment(3);
                _createQuoteAction.SelectSoldTo(soldtoId);
                WaitForMoment(1);

                //Search for the product by typing the material id.
                _createQuoteAction.SearchByMaterialID(searchbymaterialid);
                WaitForMoment(3);
                _createQuoteAction.ClickOnSearchIcon();
                WaitForMoment(3);
                //***Update the second page of create quote***
                //Enter the product quantity
                _configureProductsAction.EnterOrderQuantity(orderQuantity);
                //Enter the product price
                _configureProductsAction.EnterProductPrice(productPrice);
                //Enter product annual sales forecast
                _configureProductsAction.EnterProductAnnualSalesForecast(productAnnualSalesForecast);
                WaitForMoment(1);
                //Validate the approval required level doesnt appear for the product.
                Assert.IsTrue(_configureProductsAction.VerifyAprovalRequiredDisplayed());
                //Click on aprovals required
                _configureProductsAction.ClickOnAprovalRequired();
                WaitForMoment(2);
                //Validate the approval pop up is displayed
                Assert.IsTrue(_configureProductsAction.VerifyApprovalRequiredPopUpIsOpen());
                //Verify the approvers
                //***Verify account manager approval is required***
                _session.Manage().Window.Maximize();
                _configureProductsAction.VerifyAccountManagerApprovalRequired();
                //Verify account manager approval reason
                string[] amApprovalReason = { "Price lower than Account Manager Discount Limit", "Price lower than Sales Director Discount Limit", "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifyAMApprovalReason(amApprovalReason);
                //Verify SD approval is required
                _configureProductsAction.VerifySalesDirectorApprovalRequired();
                //Verify SD approval reason
                string[] sdApprovalReason = { "Price lower than Account Manager Discount Limit", "Price lower than Sales Director Discount Limit", "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifySDApprovalReason(sdApprovalReason);
                //Verify PM approval required
                _configureProductsAction.VerifyProductDirectorApprovalRequired();
                //verify PM approval reason
                string[] pmApprovalReason = { "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifyPMApprovalReason(pmApprovalReason);
                //Verify MUVP approval is required
                _configureProductsAction.VerifyMUVPApprovalRequired();
                //Verify MUVP approval reason
                string[] muvpApprovalReason = { "Price lower than Sales Director Discount Limit", "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifyMUVPApprovalReason(muvpApprovalReason);
                //Click on notifiers link
                _configureProductsAction.ClickOnNotifierslink();
                WaitForMoment(1);
                //***Verify the notifiers
                //Verify pricing manager notification required
                _configureProductsAction.VerifyPricingManagerNotificationRequired();
                //Verify pricing manager notification reason
                string[] prmApprovalReason = { "Price lower than Sales Director Discount Limit", "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifyPricingManagerNotificationReason(prmApprovalReason);
                //verify portfolio strategy notification required
                _configureProductsAction.VerifyPortfolioStrategyNotificationRequired();
                //Verify PS notification reason
                string[] psNotificationReason = { "Price lower than Sales Director Discount Limit", "Price lower than Product Manager Floor Price" };
                _configureProductsAction.VerifyPortfolioStrategyNotificationReason(psNotificationReason);
                //Verify PD notification required
                _configureProductsAction.VerifyProductDirectorNotificationRequired();
                //verify PD notification reason
                string[] pdNotificationReason = { "Price lower than Sales Director Discount Limit" };
                _configureProductsAction.VerifyPDNotificationReason(pdNotificationReason);
                //CLick on close icon
                _configureProductsAction.CloseTheApprovalPopUp();
                //_configureProductsAction.ClickOnAddToQuote();
                WaitForMoment(2);
                //Click on Add to quote button
                _configureProductsAction.ClickOnAddToQuote();
                //Click on View quote list button
                WaitForMoment(1);
                _configureProductsAction.ClickOnViewQuoteList();
                //Validate the material id
                WaitForMoment(3);
                Assert.IsTrue(_configureProductsAction.VerifyQLMaterialID(qlMaterialID));
                //Validate the product quantity
                Assert.IsTrue(_configureProductsAction.VerifyQlProductQuantity(orderQuantity));
                //Validate the product price
                Assert.IsTrue(_configureProductsAction.VerifyQlProductPrice(productPrice));
                //Validate the total amount
                double totAmt = Convert.ToDouble(productPrice) * Convert.ToDouble(orderQuantity);
                qlTotAmt = totAmt.ToString();
                Assert.IsTrue(_configureProductsAction.VerifyQlTotaAmount(qlTotAmt));
                WaitForMoment(2);
                //Click on proceed button
                _configureProductsAction.ClickOnSaveAsDraft();
                WaitForMoment(2);
                //Verify the confirmation pop up is open
                Assert.IsTrue(_configureProductsAction.VerifyConfirmationPopUpOpen());
                //Click on yes on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                //_baseAction.WaitForLoadingToDisappear();
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(5);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the customer material pricing functionality of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179041.csv", "Quotes_179041#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179041.csv")]

        public void TC_179041_CustomerMaterialPrice()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();

                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on the master icon(+ icon)
                _inboxAction.ClickOnCreateMasterAction();
                WaitForMoment(.5);
                //Click on Create new quote
                _quoteAction.ClickOnCreateQuote();
                WaitForMoment(1);
                //Validate Create quote page is opened
                Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());

                WaitForMoment(2);
                //Search and select the sold to customer from the picker
                _createQuoteAction.ClickOnSoldToPicker();
                WaitForMoment(5);
                Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());

                _createQuoteAction.SearchSoldTo(soldtoId);
                WaitForMoment(3);
                _createQuoteAction.SelectSoldTo(soldtoId);
                WaitForMoment(1);
                //Click on the customer material pricing icon
                _createQuoteAction.ClickOnCustomerPricing();
                WaitForMoment(2);
                //Verify the customer material pricing pop up is open
                Assert.IsTrue(_createQuoteAction.VerifyCustomerMaterialPopUpIsOpen());

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the create quoute with approval flow of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179526.csv", "Quotes_179526#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179526.csv")]

        public void TC_179526_QuoteApprovalFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string soldtoId = this.TestContext.DataRow["soldToID"].ToString();
                string searchbymaterialid = this.TestContext.DataRow["searchByMaterialID"].ToString();
                string productLine = this.TestContext.DataRow["productLine"].ToString();
                string flurotecCoating = this.TestContext.DataRow["flurotecCoating"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string finishingLevel = this.TestContext.DataRow["finishingLevel"].ToString();
                string noOfProductsFound = this.TestContext.DataRow["noOfProductsFound"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string incoterms = this.TestContext.DataRow["incoterms"].ToString();
                string orderQuantity = this.TestContext.DataRow["orderQuantity"].ToString();
                string productPrice = this.TestContext.DataRow["productPrice"].ToString();
                string productAnnualSalesForecast = this.TestContext.DataRow["productAnnualSalesForecast"].ToString();
                string qlMaterialID = this.TestContext.DataRow["qlMaterialID"].ToString();
                string justification = "Automation Quote - Approval flow";
                string qlTotAmt;
                //string amLoginID = "UX-Auto-testuser1@westpharma.com";
                //string passwordam = "West0524";
                //string password = "Westpharm@2019";
                //string sdLoginID = "Test_UX1@westpharma.com";
                //string pmLoginId = "Test_UX02@westpharma.com";
                //string muvpLoginID = "Test_UX04@westpharma.com";
                string passwordEncrypted = this.TestContext.Properties["TestUX1Password"].ToString();                
                string sdLoginID = this.TestContext.Properties["sdLoginID"].ToString();
                string pmLoginId = this.TestContext.Properties["pmLoginId"].ToString();
                string muvpLoginID = this.TestContext.Properties["muvpLoginID"].ToString();
                string password = CommonTestSettings.Decrypt(passwordEncrypted);
                string sdPassword = CommonTestSettings.Decrypt(this.TestContext.Properties["AutoTestUser1Password"].ToString());
                try
                {
                    LogoutWD();
                    LaunchApp();
                    WaitForMoment(5);
                    //LoginToWD(amLoginID, passwordam);
                    LoginToWD(sdLoginID, password);
                    //Navigate to the quotes inbox
                    NavigateToInboxByGlobalSearch(function, inbox);
                    //var elements = _session.FindElementsByXPath("//Window[@Name='Pop-up']//*[@AutomationId ='CloseButton']");
                    //elements[0].Click();
                    //Click on the master icon(+ icon)
                    _homeAction.ClickOnRefreshButton();
                    _inboxAction.ClickOnCreateMasterAction();
                    WaitForMoment(.5);
                    //Click on Create new quote
                    _quoteAction.ClickOnCreateQuote();
                    WaitForMoment(1);
                    //Validate Create quote page is opened
                    Assert.IsTrue(_createQuoteAction.VerifyCreateQuotePageDisplayed());

                    WaitForMoment(1);
                    //Search and select the sold to customer from the picker
                    _createQuoteAction.ClickOnSoldToPicker();
                    WaitForMoment(2);
                    Assert.IsTrue(_createQuoteAction.VerifySoldToPopUpDisplayed());

                    _createQuoteAction.SearchSoldTo(soldtoId);
                    WaitForMoment(1);
                    _createQuoteAction.SelectSoldTo(soldtoId);
                    WaitForMoment(1);
                    _createQuoteAction.SearchByMaterialID(searchbymaterialid);
                    WaitForMoment(.5);
                    _createQuoteAction.ClickOnSearchIcon();
                    WaitForMoment(3);
                    //Update the second page of create quote
                    //Enter currency
                    _configureProductsAction.SelectfromCurrencyPicker(currency);
                    //Enter incoterms
                    WaitForMoment(2);
                    _configureProductsAction.SelectIncoterms(incoterms);
                    //Validate if minimum order quanity exists and displayed
                    WaitForMoment(2);
                    _configureProductsAction.EnterOrderQuantity(orderQuantity);
                    //Enter the product price
                    _configureProductsAction.EnterProductPrice(productPrice);
                    //Enter product annual sales forecast
                    _configureProductsAction.EnterProductAnnualSalesForecast(productAnnualSalesForecast);
                    WaitForMoment(1);
                    //Validate the approval required level doesnt appear for the product.
                    Assert.IsTrue(_configureProductsAction.VerifyAprovalRequiredDisplayed());
                    //Click on aprovals required
                    _configureProductsAction.ClickOnAprovalRequired();
                    WaitForMoment(2);
                    //Validate the approval pop up is displayed
                    Assert.IsTrue(_configureProductsAction.VerifyApprovalRequiredPopUpIsOpen());
                    //CLick on close icon
                    _configureProductsAction.CloseTheApprovalPopUp();
                    //_configureProductsAction.ClickOnAddToQuote();
                    WaitForMoment(1);
                    //Click on Add to quote button
                    _configureProductsAction.ClickOnAddToQuote();
                    //Click on View quote list button
                    WaitForMoment(1);
                    _configureProductsAction.ClickOnViewQuoteList();
                    //Validate the material id
                    WaitForMoment(3);
                    Assert.IsTrue(_configureProductsAction.VerifyQLMaterialID(qlMaterialID));
                    //Validate the product quantity
                    Assert.IsTrue(_configureProductsAction.VerifyQlProductQuantity(orderQuantity));
                    //Validate the product price
                    Assert.IsTrue(_configureProductsAction.VerifyQlProductPrice(productPrice));
                    //Validate the total amount
                    double totAmt = Convert.ToDouble(productPrice) * Convert.ToDouble(orderQuantity);
                    qlTotAmt = totAmt.ToString();
                    Assert.IsTrue(_configureProductsAction.VerifyQlTotaAmount(qlTotAmt));
                    //Click on proceed button
                    _configureProductsAction.ClickOnProceed();
                    WaitForMoment(3);
                    //Validate user is navigated to product review page
                    Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                    //Verify the total amount.
                    Assert.IsTrue(_productReviewAction.VerifyTotalAmount(qlTotAmt));
                    //Enter the justification
                    _productReviewAction.EnterJustification(justification);
                    //Click on request quote.
                    WaitForMoment(2);
                    _productReviewAction.ClickOnRequestQuote();
                    WaitForMoment(3);
                    //Verify the confirmation pop up is open
                    //Assert.IsTrue(_configureProductsAction.VerifyConfirmationPopUpOpen());
                    String quoteName = _configureProductsAction.GetQuoteNameFromPopup();
                    //Click on ok on the confirmation pop up
                    _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                    WaitForMoment(3);
                    LogoutWD();
                    LaunchApp();
                    WaitForMoment(5);
                    //LoginToWD(sdLoginID, password);
                    LoginToWD(pmLoginId, password);
                    //Navigate to the quotes inbox
                    NavigateToInboxByGlobalSearch(function, inbox);
                    _homeAction.ClickOnRefreshButton();
                    //Approve quote from sales director
                    ApproveQuote(quoteName);
                    WaitForMoment(1);
                    ////Log out and log in as PM
                    //LogoutWD();
                    //LoginToWD(pmLoginId, password);
                    ////Navigate to the quotes inbox
                    //NavigateToInboxByGlobalSearch(function, inbox);
                    ////Approve quote from PM
                    //ApproveQuote();
                    //WaitForMoment(1);
                    ////Log out and log in as MUVP
                    LogoutWD();
                    LaunchApp();
                    WaitForMoment(5);
                    LoginToWD(muvpLoginID, password);
                    //Navigate to the quotes inbox
                    NavigateToInboxByGlobalSearch(function, inbox);
                    _homeAction.ClickOnRefreshButton();
                    //Approve quote from sales director
                    ApproveQuote(quoteName);
                    WaitForMoment(1);
                }
                finally
                {
                    LogoutWD();
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the issue quote functionality of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179548.csv", "Quotes_179548#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179548.csv")]

        public void TC_179548_ApproveQuote()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //FIlter the dashboard with completed quotes
                //_inboxAction.SelectLabel("Completed");
                ApproveQuote();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the issue quote functionality of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179548.csv", "Quotes_179548#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179548.csv")]

        public void TC_179548_IssueQuote()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //FIlter the dashboard with completed quotes
                Boolean labels = _inboxAction.ClickArrowCheckLabelExist("Completed");
                if (labels.Equals(false))
                {
                    _inboxAction.SelectDetailsMoreOption("Manage Labels");
                    _inboxAction.ClickFromManageLebel("Completed");
                    _inboxAction.ClickOnSaveLabelButton();
                }
                _inboxAction.WaitForLabelLoaded("Completed");
                _inboxAction.WaitForElementToAppear("Completed");
                _inboxAction.SelectLabel("Completed");
                WaitForMoment(3);
                //Select the detail action of the 1st record in the inbox
                if (_inboxAction.CheckActionForFirstRecord())
                {
                    //Select the detail action of the 1st record in the inbox
                    _inboxAction.ClickOnDetailActionForFirstRecord();
                    WaitForMoment(2);
                    //Click on issue quote
                    _quoteAction.ClickOnIssueQuote();
                    WaitForMoment(2);
                    //Verify the quoute is issued
                    _quoteAction.VerifyQuoteIssued();
                    WaitForMoment(1);
                    _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                    WaitForMoment(2);

                }
                else if (_inboxAction.CheckDataNotAvailable())
                {
                    LogInfo("Data does not exist for this user");
                }
                else if (_inboxAction.CheckServerResponceAvailable())
                {
                    LogInfo("Server does not exist for this user");
                }
                else
                {
                    LogInfo("Problem in the page");
                    Assert.Fail();
                }

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("QuotesSmokeTest")]
        [Description("Tests the download PDF functionality of the application;")]
        [Owner("abhipsa.mahapatra@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Quotes_179548.csv", "Quotes_179548#csv", DataAccessMethod.Sequential), DeploymentItem("Quotes_179548.csv")]

        public void TC_179547_GereratePDF()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salesOrg = this.TestContext.DataRow["salesOrg"].ToString();
                string language = this.TestContext.DataRow["language"].ToString();
                string notes = this.TestContext.DataRow["notes"].ToString();
                string folderPath = @"C:\Auto\GeneratedPDF";
                Directory.CreateDirectory(folderPath);
                int pdfCount;

                //Navigate to the quotes inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                //FIlter the dashboard with completed quotes
                Boolean labels = _inboxAction.ClickArrowCheckLabelExist("Completed");
                if (labels.Equals(false))
                {
                    _inboxAction.SelectDetailsMoreOption("Manage Labels");
                    _inboxAction.ClickFromManageLebel("Completed");
                    _inboxAction.ClickOnSaveLabelButton();
                }
                _inboxAction.WaitForLabelLoaded("Completed");
                _inboxAction.WaitForElementToAppear("Completed");
                _inboxAction.SelectLabel("Completed");
                WaitForMoment(3);
                if (_inboxAction.CheckActionForFirstRecord())
                {
                    //Select the detail action of the 1st record in the inbox
                    _inboxAction.ClickOnDetailActionForFirstRecord();
                    WaitForMoment(2);
                    //Click on issue quote
                    _quoteAction.ClickOnGeneratePDF();
                    WaitForMoment(1);
                    //Verify the review page is open
                    Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                    WaitForMoment(1);
                    //Click on generate PDF button
                    _productReviewAction.ClickOnGeneratePDFButton();
                    WaitForMoment(1);
                    //Validate generate PDF dialog is open
                    Assert.IsTrue(_productReviewAction.VerifyGeneratePDFPopupDisplayed());
                    //Select sales org
                    _productReviewAction.SelectSalesOrg(salesOrg);
                    WaitForMoment(1);
                    //Select Language
                    _productReviewAction.SlectLanguage(language);
                    WaitForMoment(1);
                    //Enter the notes for customer
                    _productReviewAction.EnterTheNotesForCustomer(notes);
                    WaitForMoment(1);
                    //Click on Download
                    _productReviewAction.ClickOnDownloadBtn();
                    WaitForMoment(1);
                    //Validate the toast message
                    Assert.IsTrue(_productReviewAction.VerifyDownloadToaster());
                    WaitForMoment(.5);
                    //Enter the folder path in the pop up and wait till the PDF downloads 
                    pdfCount = _baseAction.CountNumFilesInTheFolder(folderPath, ".pdf");
                    _productReviewAction.SelectDownloadFolder(folderPath);
                    WaitForMoment(3);
                    //Verify PDF downloaded
                    Assert.IsTrue(_productReviewAction.VerifyPDFDownloaded(pdfCount, folderPath));

                }
                else if (_inboxAction.CheckDataNotAvailable())
                {
                    LogInfo("Data does not exist for this user");
                }
                else if (_inboxAction.CheckServerResponceAvailable())
                {
                    LogInfo("Server does not exist for this user");
                }
                else
                {
                    LogInfo("Problem in the page");
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #region Common Methods

        /// <summary>
        /// Selects the quote to be approved and approves it.
        /// </summary>        
        public void ApproveQuote()
        {
            //FIlter the dashboard with pending for my approval quotes
            Boolean labels = _inboxAction.ClickArrowCheckLabelExist("Pending for my approval");
            if (labels.Equals(false))
            {
                _inboxAction.SelectDetailsMoreOption("Manage Labels");
                _inboxAction.ClickFromManageLebel("Pending for my approval");
                _inboxAction.ClickOnSaveLabelButton();
            }
            _inboxAction.WaitForLabelLoaded("Pending for my approval");
            _inboxAction.SelectLabel("Pending for my approval");
            _homeAction.ClickOnRefreshButton();
            WaitForMoment(3); 
            if (_inboxAction.CheckActionForFirstRecord())
            {
                //Select the detail action of the 1st record in the inbox
                _inboxAction.ClickOnDetailActionForFirstRecord();
                WaitForMoment(2);
                //Click on issue quote
                _quoteAction.ClickOnApproveQuote();
                WaitForMoment(1);
                //Verify the review page is open
                Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                WaitForMoment(2);
                //Click on generate PDF button
                _productReviewAction.ClickOnApproveQuote();
                WaitForMoment(1);
                _productReviewAction.EnterTheApprovalComments("Approved by Automation");
                //Click on the approve button in the pop up
                _productReviewAction.ClickOnApproveInThePopUp();
                WaitForMoment(1);
                //Click on ok on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(2);
            }
            else if (_inboxAction.CheckDataNotAvailable())
            {
                LogInfo("Data does not exist for this user");
            }

            else if (_inboxAction.CheckServerResponceAvailable())
            {
                LogInfo("Server does not exist for this user");
            }
            else
            {
                LogInfo("Problem in the page");
                Assert.Fail();
            }
        }

        public void ApproveQuote(String QuoteName)
        {
            //FIlter the dashboard with pending for my approval quotes
            Boolean labels = _inboxAction.ClickArrowCheckLabelExist("Pending for my approval");
            if (labels.Equals(false))
            {
                _inboxAction.SelectDetailsMoreOption("Manage Labels");
                _inboxAction.ClickFromManageLebel("Pending for my approval");
                _inboxAction.ClickOnSaveLabelButton();
            }
            _inboxAction.WaitForLabelLoaded("Pending for my approval");
            _inboxAction.SelectLabel("Pending for my approval");
            _homeAction.ClickOnRefreshButton();
            _inboxAction.EnterSearchValue(QuoteName.Trim());
            WaitForMoment(3); if (_inboxAction.CheckActionForFirstRecord())
            {
                //Select the detail action of the 1st record in the inbox
                _inboxAction.ClickOnDetailActionForFirstRecord();
                WaitForMoment(2);
                //Click on issue quote
                _quoteAction.ClickOnApproveQuote();
                WaitForMoment(1);
                //Verify the review page is open
                Assert.IsTrue(_productReviewAction.VerifyProductReviewPageDisplayed());
                WaitForMoment(2);
                //Click on generate PDF button
                _productReviewAction.ClickOnApproveQuote();
                WaitForMoment(1);
                _productReviewAction.EnterTheApprovalComments("Approved by Automation");
                //Click on the approve button in the pop up
                _productReviewAction.ClickOnApproveInThePopUp();
                WaitForMoment(1);
                //Click on ok on the confirmation pop up
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
                WaitForMoment(2);
            }
            else if (_inboxAction.CheckDataNotAvailable())
            {
                LogInfo("Data does not exist for this user");
            }
            else
            {
                LogInfo("Problem in the page");
                Assert.Fail();
            }
        }


        public Boolean loginAsUX1(string function, string inbox, string id,string pwd,string profileName)
        {
            Boolean dataPresent = false;
            string passwordUX1 = pwd;
            string sdLoginID = id;
            Boolean LoggedInUserName;

            _baseAction.WaitForLoadingToDisappear();
            _homeAction.ClickOnProfileImage();
            WaitForMoment(2);
            LoggedInUserName = _homeAction.LoggedinUser(profileName);
            _homeAction.ClickOnHomeActionsButton();
            WaitForMoment(2);
            if (!LoggedInUserName)
            {
                LogoutWD();
                LaunchApp();
                LoginToWD(sdLoginID, passwordUX1);
            }

            return dataPresent;
        }
        #endregion
    }
}
