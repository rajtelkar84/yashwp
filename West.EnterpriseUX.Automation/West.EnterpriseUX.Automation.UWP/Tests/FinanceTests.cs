using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class FinanceTests : BaseTest
    {
        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under profitability( revised) persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",@"Finance_493163.csv","Finance_493163#csv", DataAccessMethod.Sequential)]
        public void TC_493163_profitability_revised_Test()
        {
            try
            {
                string function = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string persona3 = this.TestContext.DataRow["persona3"].ToString();
                string persona4 = this.TestContext.DataRow["persona4"].ToString();
                string persona5 = this.TestContext.DataRow["persona5"].ToString();
                string persona6 = this.TestContext.DataRow["persona6"].ToString();

                _homeAction.ClickOnFunction(function);
                WaitForMoment(2);
                //check for Market Unit
                string persona1ActualValue =_financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check for HVP Type
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);
                //check for Product Family(New)
                string persona3ActualValue = _financeAction.getSubPersonaText(persona3);
                Assert.AreEqual(persona3, persona3ActualValue);
                //check for Strategic Family(New)
                string persona4ActualValue = _financeAction.getSubPersonaText(persona4);
                Assert.AreEqual(persona4, persona4ActualValue);
                //check for Geography(New)
                string persona5ActualValue = _financeAction.getSubPersonaText(persona5);
                Assert.AreEqual(persona5, persona5ActualValue);
                //check for Profitability Items
                string persona6ActualValue = _financeAction.getSubPersonaText(persona6);
                Assert.AreEqual(persona6, persona6ActualValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under profitability persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493179.csv", "Finance_493179#csv", DataAccessMethod.Sequential)]
        public void TC_493179_profitability_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string persona3 = this.TestContext.DataRow["persona3"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Profitability Inbox
                _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check for Product Family
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check for Strategic Platform
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);
                //check for Geography
                string persona3ActualValue = _financeAction.getSubPersonaText(persona3);
                Assert.AreEqual(persona3, persona3ActualValue);
                
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under profitability persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493181.csv", "Finance_493181#csv", DataAccessMethod.Sequential)]
        public void TC_493181_AccountsRecievable_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string persona3 = this.TestContext.DataRow["persona3"].ToString();
                string persona4 = this.TestContext.DataRow["persona4"].ToString();
                string persona5 = this.TestContext.DataRow["persona5"].ToString();
                string persona6 = this.TestContext.DataRow["persona6"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Recivable Inbox
                _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check for Customer Balance
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check for Customer Banks
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);
                //check for Invoices
                string persona3ActualValue = _financeAction.getSubPersonaText(persona3);
                Assert.AreEqual(persona3, persona3ActualValue);
                //check for Invoices Items
                string persona4ActualValue = _financeAction.getSubPersonaText(persona4);
                Assert.AreEqual(persona4, persona4ActualValue);
                //check for Customer balace Items
                string persona5ActualValue = _financeAction.getSubPersonaText(persona5);
                Assert.AreEqual(persona5, persona5ActualValue);
                //check for Financial Documents
                string persona6ActualValue = _financeAction.getSubPersonaText(persona6);
                Assert.AreEqual(persona6, persona6ActualValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under Accounts Payable persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493184.csv", "Finance_493184#csv", DataAccessMethod.Sequential)]
        public void TC_493184_AccountsPayable_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string persona3 = this.TestContext.DataRow["persona3"].ToString();
                string persona4 = this.TestContext.DataRow["persona4"].ToString();
                string persona5 = this.TestContext.DataRow["persona5"].ToString();
                string persona6 = this.TestContext.DataRow["persona6"].ToString();
                string persona7 = this.TestContext.DataRow["persona7"].ToString();
                string persona8 = this.TestContext.DataRow["persona8"].ToString();
                string persona9 = this.TestContext.DataRow["persona9"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
                _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check for Vendor Balance
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check for Vendor Banks
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);
                //check for Invoices Inbox
                string persona3ActualValue = _financeAction.getSubPersonaText(persona3);
                Assert.AreEqual(persona3, persona3ActualValue);
                //check for OCR Vendor Invoices
                string persona4ActualValue = _financeAction.getSubPersonaText(persona4);
                Assert.AreEqual(persona4, persona4ActualValue);
                //check for Financial Documents
                //string persona5ActualValue = _financeAction.getSubPersonaText(persona5);
                //Assert.AreEqual(persona5, persona5ActualValue);
                //check for Invoice Header Report
                string persona6ActualValue = _financeAction.getSubPersonaText(persona6);
                Assert.AreEqual(persona6, persona6ActualValue);
                //check for Posted Invoice Items
                string persona7ActualValue = _financeAction.getSubPersonaText(persona7);
                Assert.AreEqual(persona7, persona7ActualValue);
                //check for Parked Invoice Items
                string persona8ActualValue = _financeAction.getSubPersonaText(persona8);
                Assert.AreEqual(persona8, persona8ActualValue);

                //check for vendor balance Items
                _homeAction.ClickOnInboxesItem("Vendor Balance Items (Accounts Payable)");
                string persona9ActualValue = _financeAction.getSubPersonaText(persona9);
                Assert.AreEqual(persona9, persona9ActualValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under Asset accounting persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493191.csv", "Finance_493191#csv", DataAccessMethod.Sequential)]
        public void TC_493191_AssetAccounting_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();               

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
                _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check for Vendor Balance
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under General Ledger persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493199.csv", "Finance_493199#csv", DataAccessMethod.Sequential)]
        public void TC_493199_AssetAccounting_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string persona3 = this.TestContext.DataRow["persona3"].ToString();
                string persona4 = this.TestContext.DataRow["persona4"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
                _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check for General Ledger
                _homeAction.ClickOnInboxesItem(persona1+" ("+inbox+")");
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check for Journal entries
                _homeAction.ClickOnInboxesItem(persona2 + " (" + inbox + ")");
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);
                //check for Expenses
                /*
                _homeAction.ClickOnInboxesItem(persona3 + " (" + inbox + ")");
                string persona3ActualValue = _financeAction.getSubPersonaText(persona3);
                Assert.AreEqual(persona3, persona3ActualValue);
                */
                //check for Actual Vs Planned Expenses
              /*  _homeAction.ClickOnInboxesItem(persona4 + " (" + inbox + ")");
                string persona4ActualValue = _financeAction.getSubPersonaText(persona4);
                Assert.AreEqual(persona4, persona4ActualValue);
              */


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under Projects persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493202.csv", "Finance_493202#csv", DataAccessMethod.Sequential)]
        public void TC_493202_Projects_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
               // _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check forPER
                _homeAction.ClickOnInboxesItem(persona1 + " (" + inbox + ")");
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
               
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under Treasury persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493206.csv", "Finance_493206#csv", DataAccessMethod.Sequential)]
        public void TC_493206_Treasury_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
                // _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check forPER
                _homeAction.ClickOnInboxesItem(persona1 + " (" + inbox + ")");
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify In Finance under Cost Accounting persona all the sub personas are Visible and clickable")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493212.csv", "Finance_493212#csv", DataAccessMethod.Sequential)]
        public void TC_493212_CostAccounting_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();

                _homeAction.ClickOnFunction("Finance");
                //Go to Acoounts Payable Inbox
                // _inboxAction.ClickInbox(inbox);
                WaitForMoment(2);
                //check forPER
                _homeAction.ClickOnInboxesItem(persona1 + " (" + inbox + ")");
                string persona1ActualValue = _financeAction.getSubPersonaText(persona1);
                Assert.AreEqual(persona1, persona1ActualValue);
                //check forPER
                _homeAction.ClickOnInboxesItem(persona2 + " (" + inbox + ")");
                string persona2ActualValue = _financeAction.getSubPersonaText(persona2);
                Assert.AreEqual(persona2, persona2ActualValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify Details Section of project expenditure request (PER)")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493297.csv", "Finance_493297#csv", DataAccessMethod.Sequential)]
        public void TC_493297_DetailsSectionPER_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string SearchtextExpected = this.TestContext.DataRow["SearchtextExpected"].ToString();
                string FilterTextExpected = this.TestContext.DataRow["FilterTextExpected"].ToString();
                string SortTextExpected = this.TestContext.DataRow["SortTextExpected"].ToString();
                string MoreTextExpected = this.TestContext.DataRow["MoreTextExpected"].ToString();
                string InsightTextExpected = this.TestContext.DataRow["InsightTextExpected"].ToString();
                string CreateProposalTextExpected = this.TestContext.DataRow["CreateProposalTextExpected"].ToString();

                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                //check for search 
                String Searchtext = _financeAction.CheckForSearchBox();
                Assert.AreEqual(SearchtextExpected, Searchtext);
                // check for filter
                String FilterText = _financeAction.checkForFilter();
                Assert.AreEqual(FilterTextExpected, FilterText);
                // check for refresh
                _financeAction.checkForRefreshButton();
                // check for sorrt button
                String SortText=_financeAction.checkForSort();
                Assert.AreEqual(SortTextExpected, SortText);
                // check for more button
                String MoreText = _financeAction.checkForMore();
                Assert.AreEqual(MoreTextExpected, MoreText);
                // check for insights
                String InsightText = _financeAction.checkForInsights();
                Assert.AreEqual(InsightTextExpected, InsightText);
                //check for create proposal button
                String CreateProposalText = _financeAction.checkForCreateProposalButton();
                Assert.AreEqual(CreateProposalTextExpected, CreateProposalText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify KPIs Section on PER Screen")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493299.csv", "Finance_493299#csv", DataAccessMethod.Sequential)]
        public void TC_493299_KPISectionSectionPER_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string GlobalPERByBucketExpected = this.TestContext.DataRow["GlobalPERByBucketExpected"].ToString();
                string GlobalPERByStatusExpected = this.TestContext.DataRow["GlobalPERByStatusExpected"].ToString();
                string CreatedByMeExpcted = this.TestContext.DataRow["CreatedByMeExpcted"].ToString();
                string sharedWithMeExpected = this.TestContext.DataRow["sharedWithMeExpected"].ToString();
                string ManageKPIsExpected = this.TestContext.DataRow["ManageKPIsExpected"].ToString();
                
                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                _financeAction.KPIstest();
                //check for global
                var checkforGlobalTab = _financeAction.CheckGlobalPERKAPIs();
                Assert.AreEqual(GlobalPERByBucketExpected, checkforGlobalTab.perByBucket);
                Assert.AreEqual(GlobalPERByStatusExpected,checkforGlobalTab.perBystatus);
                // check for creted by me
                var checforCreateByMe = _financeAction.CheckCreatedBymePERKPIs();
                Assert.AreEqual(CreatedByMeExpcted, checforCreateByMe);
                // check for shared with me
                var sharedwithMe = _financeAction.SharedWithmePERKPIs();
                Assert.AreEqual(sharedWithMeExpected, sharedwithMe);
                // check for search button and manage KPIs
                var manageKPIs = _financeAction.SearchAndManagePERKPIs();
                Assert.AreEqual(ManageKPIsExpected, manageKPIs);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify Charts section under PER screen")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493304.csv", "Finance_493304#csv", DataAccessMethod.Sequential)]
        public void TC_493304_ChartSectionPER_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string ChartsGlobalCreatedByPortFolio = this.TestContext.DataRow["ChartsGlobalCreatedByPortFolio"].ToString();
                string ChartCreatedByMe = this.TestContext.DataRow["ChartCreatedByMe"].ToString();
                string ChartsSharedWithMe = this.TestContext.DataRow["ChartsSharedWithMe"].ToString();

                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var charTest = _financeAction.ChartPERTest();
                Assert.AreEqual(ChartsGlobalCreatedByPortFolio, charTest.PERsByPortFolio);
                Assert.AreEqual(ChartCreatedByMe, charTest.CreatedByme);
                Assert.AreEqual(ChartsSharedWithMe, charTest.SharedWithMe);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify StoryBoards section under PER Screen")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493307.csv", "Finance_493307#csv", DataAccessMethod.Sequential)]
        public void TC_493307_StoryBoardPER_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string CreatestoryBoard = this.TestContext.DataRow["CreatestoryBoard"].ToString();
                

                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var charTest = _financeAction.storyBoard();
                Assert.AreEqual(CreatestoryBoard, charTest);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify Search functionality on PER screen works with  contains option")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493307.csv", "Finance_493307#csv", DataAccessMethod.Sequential)]
        public void TC_493351_PERSearchContains_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();

                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var PERID = _financeAction.getFirstPERID();
                var searchContains = _financeAction.TakeSearchText();
                Assert.AreEqual("Contains", searchContains);
                var recordCount = _financeAction.searchRecord(PERID);
                StringAssert.Contains("All(1)",recordCount);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify user is able to navigate to create proposal screen")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_493307.csv", "Finance_493307#csv", DataAccessMethod.Sequential)]
        public void TC_493380_CreateProposalScreenValidate_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string CreatestoryBoard = this.TestContext.DataRow["CreatestoryBoard"].ToString();


                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var genralInfoTab = _financeAction.validatePERScreen();
                Assert.AreEqual("General Info", genralInfoTab);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }



        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify 'Review and post invoice' screen is visible")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_510722.csv", "Finance_510722#csv", DataAccessMethod.Sequential)]
        public void TC_510722_AccountPayableReviewandPostInvoice_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string ReviewAndPostInvoice = this.TestContext.DataRow["ReviewAndPostInvoice"].ToString();


                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var reviewAndPostInvoiceText = _financeAction.reviewAndPostScreenValidation();
                Assert.AreEqual(ReviewAndPostInvoice, reviewAndPostInvoiceText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("FinanceTest")]
        [Description("Verify for any document id all option are available in invoice inbox")]
        [Owner("rajkumar.telkarexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_510723.csv", "Finance_510723#csv", DataAccessMethod.Sequential)]
        public void TC_510723_AccountPayableDocumentIdAllAction_Test()
        {
            try
            {
                string inbox = this.TestContext.DataRow["Module"].ToString();
                string PER = this.TestContext.DataRow["PER"].ToString();
                string Expand = this.TestContext.DataRow["Expand"].ToString();
                string CollaborationBeta = this.TestContext.DataRow["Collaboration(Beta)"].ToString();
                string DisplayInvoice = this.TestContext.DataRow["DisplayInvoice"].ToString();
                string PostInvoice = this.TestContext.DataRow["PostInvoice"].ToString();
                string MarkasStatement = this.TestContext.DataRow["MarkasStatement"].ToString();
                string Markasreviewed = this.TestContext.DataRow["Markasreviewed"].ToString();
                string DeleteInvoice = this.TestContext.DataRow["DeleteInvoice"].ToString();
                string MarkAsDuplicate = this.TestContext.DataRow["MarkAsDuplicate"].ToString();

                _homeAction.ClickOnFunction("Finance");
                WaitForMoment(2);
                //check for PER Projects Project Expenditure Requests
                _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                // check for chart Test
                var allaction = _financeAction.DocumentAllAction();
                Assert.AreEqual(Expand, allaction.ExpandOptio);
                Assert.AreEqual(CollaborationBeta, allaction.CollarationBetaOption);
                Assert.AreEqual(DisplayInvoice, allaction.DisplayInvoiceOption);
                Assert.AreEqual(PostInvoice, allaction.PostInvoiceeOption);
                Assert.AreEqual(MarkasStatement, allaction.MarkasStatementOption);
                Assert.AreEqual(Markasreviewed, allaction.MarkasReviewedOption);
                Assert.AreEqual(DeleteInvoice, allaction.DeleteInvoiceOption);
                Assert.AreEqual(MarkAsDuplicate, allaction.MarkasDuplicateeOption);


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

            [TestMethod]
            [TestCategory("FinanceTest")]
            [Description("Verify for any document id all option are available in invoice inbox")]
            [Owner("rajkumar.telkarexternal@westpharma.com")]
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Finance_510724.csv", "Finance_510724#csv", DataAccessMethod.Sequential)]
            public void TC_510724_JournalEntryParkJournalEntryButton_Test()
            {
                try
                {
                    string inbox = this.TestContext.DataRow["Module"].ToString();
                    string PER = this.TestContext.DataRow["PERSONA"].ToString();
                    string ParkJournalEntry = this.TestContext.DataRow["ParkJournalEntry"].ToString();                    

                    _homeAction.ClickOnFunction("Finance");
                    WaitForMoment(2);
                    //check for PER Projects Project Expenditure Requests
                    _homeAction.ClickOnInboxesItem(PER + " (" + inbox + ")");
                    // check for chart Test
                    var journalEntrytext = _financeAction.ParkJornalEntryButton();
                    Assert.AreEqual(ParkJournalEntry, journalEntrytext);                   
                }
                catch (Exception ex)
                {
                    CaptureLogs(ex);
                    Assert.Fail(ex.Message);
                }
            }
    }
}

