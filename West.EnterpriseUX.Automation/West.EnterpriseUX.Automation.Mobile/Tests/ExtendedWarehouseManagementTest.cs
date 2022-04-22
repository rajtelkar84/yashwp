using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.Tests
{
    [TestClass]
    public class ExtendedWarehouseManagementTest : BaseTest
    {
        [TestMethod]
        [TestCategory("EWMTest")]
        public void GoodsReceiptTest()
        {
            string salesDocumentId = "510000000917";
            string actionName = "Goods Receipt";
            string expectedMessage = "Goods receipt posted";
            string expectedInboxName = "Inbound Deliveries";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SearchTheRecordById(salesDocumentId);
                WaitForMoment(2);
                GoodsReceiptAction(actionName, expectedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    GoodsReceiptReversalAction(actionName+ " Reversal");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }
        }
        [TestMethod]
        [TestCategory("EWMTest")]
        public void GoodsReceiptReversalTest()
        {
            string salesDocumentId = "410000000950";
            string actionName = "Goods Receipt Reversal";
            string expectedMessage = $"Goods Receipt {salesDocumentId} reversed sucessfully";
            string expectedInboxName = "Inbound Deliveries";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SearchTheRecordById(salesDocumentId);
                WaitForMoment(2);
                GoodsReceiptReversalAction(actionName);
                WaitForMoment(6);
                _ewmGoodsReceiptAction.VerifyDialogMessage(expectedMessage);
                WaitForMoment(2);
                _ewmGoodsReceiptAction.ClickOnDailogOkButton();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    GoodsReceiptAction("Goods Receipt");
                    WaitForMoment(5);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }
        }
        [TestMethod]
        [TestCategory("EWMTest")]
        public void GoodsReturnToSupplierTest()
        {
            string actionName = "Return to Supplier";
            string expectedInboxName = "Inbound Deliveries";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(expectedInboxName);
                WaitForMoment(2);
                _inboxDetailsAction.SelectGridRow(1);
                WaitForMoment(2);
                _inboxDetailsAction.ClickOnRowContextOption();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxDetailsAction.SelectAction(actionName);
                WaitForMoment(2);
                _ewmReturnToSupplierAction.EnterReturnQuantity("2");
                WaitForMoment(2);
                _ewmReturnToSupplierAction.SelectStockType();
                WaitForMoment(2);
                _ewmReturnToSupplierAction.SelectReasonCode();
                WaitForMoment(2);
                _ewmReturnToSupplierAction.ClickOnPostButton();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("EWMTest")]
        public void BinToBinMovementTest()
        {
            string actionName = "Bin - Bin Movement";
            string inboxName = "Bin/Products";
            string expectedMessage = "successful";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(inboxName);
                WaitForMoment(4);
                _inboxDetailsAction.SelectGridRow(1);
                WaitForMoment(2);
                _inboxDetailsAction.ClickOnRowContextOption();
                WaitForMoment(2);
                _inboxKpiAction.VerticalSwipeUp();
                WaitForMoment(2);
                _inboxDetailsAction.SelectAction(actionName);
                WaitForMoment(2);
                _ewmBinToBinMovementAction.SelectDestinationBin();
                WaitForMoment(2);
                _ewmBinToBinMovementAction.SelectReasonCode();
                WaitForMoment(2);
                _ewmBinToBinMovementAction.EnterTransferQuantity("1.0");
                WaitForMoment(2);
                _ewmBinToBinMovementAction.ClickOnPostButton();
                WaitForMoment(2);
                _ewmBinToBinMovementAction.ClickOnProceedButton();
                WaitForMoment(2);
                _ewmBinToBinMovementAction.VerifyDialogMessage(expectedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("EWMTest")]
        public void PhysicalInventoryTest()
        {
            string masterActionName = "Create Physical Inventory Document";
            string inboxName = "Physical Inventory";
            string expectedMessage = "PI Document Number";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(inboxName);
                WaitForMoment(4);
                _inboxDetailsAction.ClickOnContextOptions();
                WaitForMoment(2);
                _inboxDetailsAction.SelectAction(masterActionName);
                WaitForMoment(2);
                _ewmPhysicalInventoryAction.ClickOnProceedButton();
                WaitForMoment(2);
                _ewmPhysicalInventoryAction.SelectBinsCheckbox(1);
                WaitForMoment(2);
                _ewmPhysicalInventoryAction.ClickOnPostButton();
                _ewmPhysicalInventoryAction.VerifyDialogMessage(expectedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("EWMTest")]
        public void InboudDeliveryCreationTest()
        {
            string masterActionName = "Inbound Delivery Creation";
            string inboxName = "Inbound Deliveries";
            string PO = "4500573888";
            string expectedMessage = "Delivery Number";

            try
            {
                _homeAction.NavigateToInboxByGlobalSearch(inboxName);
                WaitForMoment(4);
                _inboxDetailsAction.ClickOnContextOptions();
                WaitForMoment(2);
                _inboxDetailsAction.SelectAction(masterActionName);
                WaitForMoment(2);
                _ewmInboundDeliveryAction.EnterPurchaseOrder(PO);
                WaitForMoment(2);
                _ewmInboundDeliveryAction.ClickOnProceedButton();
                WaitForMoment(2);
                _ewmInboundDeliveryAction.EnterQunatity("1");
                WaitForMoment(2);
                _ewmInboundDeliveryAction.ClickOnPrepareBatchesButton();
                WaitForMoment(2);
                _ewmInboundDeliveryAction.ClickOnSaveButton();
                WaitForMoment(2);
                _ewmInboundDeliveryAction.SelectDeliveryCheckbox();
                WaitForMoment(2);
                _ewmInboundDeliveryAction.ClickOnPostButton();
                WaitForMoment(2);
                _ewmInboundDeliveryAction.VerifyDialogMessage(expectedMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Assert.Fail(ex.Message);
            }
        }

        #region CommonMethods
        public void GoodsReceiptAction(string actionName, string expectedMessage= "Goods receipt posted")
        {
            _inboxDetailsAction.SelectGridRow(1);
            WaitForMoment(2);
            _inboxDetailsAction.ClickOnRowContextOption();
            WaitForMoment(2);
            _inboxDetailsAction.SelectAction(actionName);
            WaitForMoment(2);
            _ewmGoodsReceiptAction.ClickOnPostButton();
            WaitForMoment(2);
            _ewmGoodsReceiptAction.VerifyDialogMessage(expectedMessage);
        }
        public void GoodsReceiptReversalAction(string actionName)
        {
            _inboxDetailsAction.SelectGridRow(1);
            WaitForMoment(2);
            _inboxDetailsAction.ClickOnRowContextOption();
            WaitForMoment(2);
            _inboxKpiAction.VerticalSwipeUp();
            WaitForMoment(2);
            _inboxDetailsAction.SelectAction(actionName);
            WaitForMoment(2);
            _ewmGoodsReceiptAction.ClickOnReverseButton();
            WaitForMoment(6);
        }
        #endregion
    }
}
