using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class CSTest : BaseTest
    {
        #region Smoke Tests
        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Customers Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]


        public void TC_498592_VerifyCustomersInbox()
        {
            try
            {
                //string function = this.TestContext.DataRow["function"].ToString();
                //string persona = this.TestContext.DataRow["persona"].ToString();
                //string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                NavigateToInboxByGlobalSearch("Sales", "Customers");
                //_homeAction.ClickOnFunction(function);
                //_homeAction.ClickOnPersona(persona);
                //_inboxAction.ClickInbox(inboxNames);
                _csCustomersAction.VerifyDetailedActionButton(1);
                _csCustomersAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csCustomersAction.CloseExpand();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Materials Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]
        public void TC_498593_VerifyMaterialsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Materials");
                _csMaterialsAction.VerifyDetailedActionButton(1);
                _csMaterialsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csMaterialsAction.CloseExpand();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Customer Material Info Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]
        public void TC_498594_VerifyCustomerMaterialInfoInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Customer Material Info");
                _csCustomerMaterialInfoAction.VerifyDetailedActionButton(1);
                _csCustomerMaterialInfoAction.ClickOnMoreCollaborationBeta();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Samples Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]
        public void TC_498596_VerifySamplesInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Samples");
                _csSamplesAction.VerifyDetailedActionButton(1);
                _csSamplesAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csSamplesAction.CloseExpand();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Quotations Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]
        public void TC_498597_VerifyQuotationsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Quotations");
                _csQuotationsAction.VerifyDetailedActionButton(1);
                _csQuotationsAction.ClickOnMoreCollaborationBeta();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Sales Orders Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_491735_VerifySalesOrdersInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Sales Orders");
                _csSalesOrdersAction.VerifyDetailedActionButton(1);
                _csSalesOrdersAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csSalesOrdersAction.CloseExpand();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Sales Orders Items Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_498600_VerifySalesOrdersItemsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Sales Order Items");
                _csSalesOrderItemsAction.VerifyDetailedActionButton(1);
                _csSalesOrderItemsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csSalesOrderItemsAction.CloseExpand();
                WaitForMoment(0.5);
                
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Returns Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]
        
        public void TC_498601_VerifyReturnsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales","Returns");
                _csReturnsAction.VerifyDetailedActionButton(1);
                _csReturnsAction.ClickOnMoreCollaborationBeta();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Return Items Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_498603_VerifyReturnsItemsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Returns Items");
                _csReturnsItemsAction.VerifyDetailedActionButton(1);
                _csReturnsItemsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csReturnsItemsAction.CloseExpand();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Credit Memo Requests Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_498607_VerifyCreditMemoRequests()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Credit Memo Requests");
                _csCreditMemoRequestsAction.VerifyDetailedActionButton(1);
                _csCreditMemoRequestsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csCreditMemoRequestsAction.CloseExpand();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Credit Memo Requests Items Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_498608_VerifyCreditMemoRequestItemsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Credit Memo Request Items");
                _csCreditMemoRequestItemsAction.VerifyDetailedActionButton(1);
                _csCreditMemoRequestItemsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csCreditMemoRequestItemsAction.CloseExpand();
                WaitForMoment(0.5);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CSTest")]
        [TestCategory("Smoke")]
        [Description("Verify if user is able to view the Debit Memo Requests Inbox Dashboard;;")]
        [Owner("sudeep.sharmaexternal@westpharma.com")]

        public void TC_498609_VerifyDebitMemoRequestsInbox()
        {
            try
            {
                NavigateToInboxByGlobalSearch("Sales", "Debit Memo Request");
                _csDebitMemoRequestsAction.VerifyDetailedActionButton(1);
                _csDebitMemoRequestsAction.ClickOnMoreExpand();
                WaitForMoment(0.5);
                _csDebitMemoRequestsAction.CloseExpand();
                WaitForMoment(0.5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        #endregion
    }
}
