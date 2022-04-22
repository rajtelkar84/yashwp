using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class EWMTest : BaseTest
    {

        #region Regression

        #region Internal Persona

        #region HU
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Bin Product _Bin To Bin Movement Detailed Action Test;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_250152.csv", "EWM_250152#csv", DataAccessMethod.Sequential)]
        public void TC_250152_BinToBinMovementDetailedActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string storageBinValue = this.TestContext.DataRow["Storage Bin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["Reason Code"].ToString();

                _homeAction.ClickOnFunction(function);   //Go to Warehouse Function 
                _inboxAction.ClickInbox(inboxNames);    //Go to Bin/Products Inbox
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, "Bin - Bin Movement");   //Click on Bin - Bin Movement Detailed Action menu.
                _binsProductsAction.VerifyPostButtonIfMandatoryFieldsEmpty();        //Post Button should be disabled if mandatory fields Empty
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);   //Click on Reason Code picker and select Values.
                _binsProductsAction.VerifyPostButtonIfQualityIsZero();   //Post Button should be disabled if Transfer Quality Empty
                _binsProductsAction.VerifyPopUP(storageBinValue);       //Verify Pop up Text
                _binsProductsAction.ClickPostAndProceedButton();    //Click on Post->Proceed button
                _binsProductsAction.VerifyTheSuccessText();   //Verify The Success Text
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Bin Product _EWM : Bin to Bin Batch Action Test;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_475458.csv", "EWM_475458#csv", DataAccessMethod.Sequential)]
        public void TC_475458_BinToBinMovementBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string storageBinValue = this.TestContext.DataRow["Storage Bin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["Reason Code"].ToString();

                _homeAction.ClickOnFunction(function);       //Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);        //Go to Bin/Products Inbox
                _binsProductsAction.SelectBatchCheckbox(1);      //Select checkbox to perform batch action
                _binsProductsAction.SelectBatchCheckbox(5);
                _binsProductsAction.ClickOnBatchBintoBinAction();       //Click on Bin to Bin Movement batch action
                _binsProductsAction.VerifyPostButtonIfMandatoryFieldsEmpty();      //Post Button should be disabled if mandatory fields Empty
                _binsProductsAction.SelectValueFromPicker(storageBinValue);        //Click on Destination Bin picker and select Values.
                _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);      //Click on Reason Code picker and select Values.
                _binsProductsAction.ClickPostButton();          //Click on Destination Post Button
                _binsProductsAction.VerifyTheSuccessText();     //Verify The Success Text
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Handling Unit_Pallet Movement Detailed Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_471118.csv", "EWM_471118#csv", DataAccessMethod.Sequential)]
        public void TC_471118_InternalHUPalletMovementDetailedActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["detailedAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["dest_StorageBin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();
                string handlingUnitNo = this.TestContext.DataRow["handlingUnitNo"].ToString();

                LogInfo("*********************Internal -> Handling Unit ->Pallet Movement Detail Action *******************");
                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);       //Go to Internal Persona ->Handling Units Inbox
                _eWMHandlingUnitsAction.SearchTheText(handlingUnitNo);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, pallentMovement);    /* Click on Palllet Movement Detailed Action.*/
                _eWMHandlingUnitsAction.VerificationofPostButton();     //Verificatio of Post Button
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                //  _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue); //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.VerificationOfToggleDefultState();   //Toggle should be in off state by default
                _eWMHandlingUnitsAction.ClickOnToggleBtn();
                _eWMHandlingUnitsAction.ClickPostButton();
                _eWMHandlingUnitsAction.VerfiySuccessText("Warehouse Order:"); //Verify the Success Text
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Handling Unit_Pallet Movement Batch Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_498844.csv", "EWM_498844#csv", DataAccessMethod.Sequential)]
        public void TC_498844_InternalHUPalletMovementBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["Persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["BatchAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["storageBin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();
                string handlingUnitNo = this.TestContext.DataRow["handlingUnitNo"].ToString();

                LogInfo("*********************Internal -> Handling Unit ->Pallet Movement Batch Action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Internal Persona ->Handling Units Inbox
                _eWMHandlingUnitsAction.SearchTheText(handlingUnitNo);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);           //Select checkbox to perform batch action
                _eWMHandlingUnitsAction.ClickOnBatchAction(pallentMovement); //Select Pallet Movement Batch Action
                _eWMHandlingUnitsAction.VerificationofPostButton();           //Verification of Post Buttton
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                // _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue); 
                _eWMHandlingUnitsAction.VerificationOfToggleDefultState();   //Toggle should be in off state by default
                _eWMHandlingUnitsAction.ClickOnToggleBtn();
                _eWMHandlingUnitsAction.ClickPostButton();
                _eWMHandlingUnitsAction.VerfiySuccessText("Warehouse Order:");      //Verify the Success Text 
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Physical Inventory

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Print Document Detailed action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_266113.csv", "EWM_266113#csv", DataAccessMethod.Sequential)]
        public void TC_266113_PhysicalInventoryPrintDocumentActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string printDocument = this.TestContext.DataRow["detailedAction"].ToString();
                string documentNumber = this.TestContext.DataRow["documentNumber"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Print Document Detailed action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();                 //Filter Physical Inventory staTus Active entry
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, printDocument); //Select the Print Document Detailed Action
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                _eWMHandlingUnitsAction.ClickDetialedActionMenuButton(1);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, printDocument);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean SuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Printed Successfully.").Contains("PI Document Number : ");//Verify of delete document success text
                Assert.IsTrue(SuccessText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Print Document batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330415.csv", "EWM_330415#csv", DataAccessMethod.Sequential)]
        public void TC_330415_PhysicalInventoryPrintDocumentBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string printDocument = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Print Document Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();                 //Filter Physical Inventory status Active entry
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);
                string documentNumber = _physicalInventoryAction.ReadColumText(1, 2);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                // _eWMHandlingUnitsAction.SelectBatchCheckbox(2); //Select the Print Document Batch Action
                _eWMHandlingUnitsAction.ClickOnBatchAction(printDocument);
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                string docNumber = _physicalInventoryAction.ReadColumText(1, 2);
                Assert.AreEqual(documentNumber, docNumber, "No Button is not working as expected");
                _eWMHandlingUnitsAction.ClickOnBatchAction(printDocument);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean successText = _eWMHandlingUnitsAction.VerfiySuccessText("Printed Successfully.").Contains("PI Document Number : " + documentNumber);//Verify of delete document success text
                Assert.IsTrue(successText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Delete Document batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330418.csv", "EWM_330418#csv", DataAccessMethod.Sequential)]
        public void TC_330418_PhysicalInventoryDeleteDocumentBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string deleteDocument = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Delete Document Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();                 //Filter Physical Inventory staTus Active entry
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);
                string documentNumber = _physicalInventoryAction.ReadColumText(1, 2);
                string docNumber = _physicalInventoryAction.ReadColumText(2, 2);
                if (documentNumber.Equals(docNumber))
                {
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                }
                else
                {
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                }
                _eWMHandlingUnitsAction.ClickOnBatchActionMoreButton();
                _physicalInventoryAction.ClickBatchAction(deleteDocument); //Select the records which Document Number are same and perform delete document Batch Action 
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                _eWMHandlingUnitsAction.ClickOnBatchActionMoreButton();
                _physicalInventoryAction.ClickBatchAction(deleteDocument);
                _physicalInventoryAction.ClickBatchAction(deleteDocument);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean deleteText = _eWMHandlingUnitsAction.VerfiySuccessText("Items in it are deleted").Contains("PI Document Number : " + documentNumber);//Verify of delete document success text
                Assert.IsTrue(deleteText);

                WaitForMoment(3);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                string docNum1 = _physicalInventoryAction.ReadColumText(1, 2);
                string docNum2 = _physicalInventoryAction.ReadColumText(2, 2);
                if (!(docNum1.Equals(docNum2)))
                {
                    _eWMHandlingUnitsAction.ClickOnBatchActionMoreButton();
                    _physicalInventoryAction.ClickBatchAction(deleteDocument); //Select the records which Document Number are different and perform delete document Batch Action
                    Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                    Assert.AreEqual("Action for multiple documents " + documentNumber + ", " + docNumber + " could not be processed! Please try identical document number.", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                    _physicalInventoryAction.ClickOnOkButton();
                }
                else
                {
                    LogInfo("Select the record which have different document number");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Delete Document Detailed action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_280551.csv", "EWM_280551#csv", DataAccessMethod.Sequential)]
        public void TC_280551_PhysicalInventoryDeleteDocumentDetailedActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string deleteDocument = this.TestContext.DataRow["action"].ToString();
                string documentNumber = this.TestContext.DataRow["documentNumber"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();


                LogInfo("*********************Internal -> Physical Inventory->Delete Document Detailed action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();                 //Filter Physical Inventory staTus Active entry
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, deleteDocument); //Select the Delete Document Detailed Action
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                _eWMHandlingUnitsAction.ClickDetialedActionMenuButton(1);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, deleteDocument);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean deleteText = _eWMHandlingUnitsAction.VerfiySuccessText("is deleted").Contains("PI Document Number : ");//Verify of delete document success text
                Assert.IsTrue(deleteText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Post Count Batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330419.csv", "EWM_330419#csv", DataAccessMethod.Sequential)]
        public void TC_330419_PhysicalInventoryPostCountBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string postCount = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Post Count Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue); //Filter Physical Inventory status is Counted entry
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                //_eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                _physicalInventoryAction.ClickBatchAction(postCount); //Select the Post Count Batch Action 
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                _physicalInventoryAction.ClickBatchAction(postCount);
                _physicalInventoryAction.ClickBatchAction(postCount);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean postConutText = _eWMHandlingUnitsAction.VerfiySuccessText("Item in this document is posted").Contains("PI Document Number :");//Verify of post count success text
                Assert.IsTrue(postConutText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Recount Batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330416.csv", "EWM_330416#csv", DataAccessMethod.Sequential)]
        public void TC_330416_PhysicalInventoryRecountBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string postCount = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Recount Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);   //Filter Physical Inventory status is Counted entry
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                string documentNumber = _physicalInventoryAction.ReadColumText(1, 2);
                _physicalInventoryAction.ClickBatchAction(postCount); //Select the Recount Batch Action 
                Assert.AreEqual("New document will be generated to perform count", _physicalInventoryAction.VerifyPopUpDialogTitle());  //Verify Popup Dialog Title Text
                Assert.AreEqual("Are you sure you want to continue?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("NO", _physicalInventoryAction.VerifyNoButton());   //Verify No Button on Popup
                string docNumber = _physicalInventoryAction.ReadColumText(1, 2);
                Assert.AreEqual(documentNumber, docNumber, "No Button is not working as expected");
                _physicalInventoryAction.ClickBatchAction(postCount);
                _physicalInventoryAction.ClickBatchAction(postCount);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean postConutText = _eWMHandlingUnitsAction.VerfiySuccessText("is created.").Contains("PI Document Number : ");//Verify of post count success text
                Assert.IsTrue(postConutText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Recount Batch action with differnt Document Number;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330417.csv", "EWM_330417#csv", DataAccessMethod.Sequential)]
        public void TC_330417_PhysicalInventoryRecountBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string postCount = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Recount Batch action with Different Document No *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);   //Filter Physical Inventory status is Counted entry
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1); //Select Checkbox record with diffirent document no.
                _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                string documentNumber = _physicalInventoryAction.ReadColumText(1, 2);
                string docNumber = _physicalInventoryAction.ReadColumText(2, 2);
                if (!(documentNumber.Equals(docNumber)))
                {
                    _physicalInventoryAction.ClickBatchAction(postCount); //Select the Recount Batch Action 
                    Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                    Assert.AreEqual("Action for multiple documents " + documentNumber + ", " + docNumber + " could not be processed! Please try identical document number.", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                    _physicalInventoryAction.ClickOnOkButton();
                }
                else
                {
                    LogInfo("Select the record which have different document number");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Print Document batch action with different Document Number;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_c.csv", "EWM_326171#csv", DataAccessMethod.Sequential)]
        public void TC_326171_PhysicalInventoryPrintDocumentBatchActionDifferentDocNumberTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string printDocument = this.TestContext.DataRow["action"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Print Document Batch action->with Different document number *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _inboxAction.ClickOnFilterActionsButton();                 //Filter Physical Inventory status Active entry
                _inboxFilterAction.Filter(filterField, operatorValue, filterValue);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1); //Select Checkbox record with diffirent document no.
                _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                string documentNumber = _physicalInventoryAction.ReadColumText(1, 2);
                string docNumber = _physicalInventoryAction.ReadColumText(2, 2);
                if (!(documentNumber.Equals(docNumber)))
                {
                    _physicalInventoryAction.ClickBatchAction(printDocument); //Select the Print Document Batch Action 
                    Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                    Assert.AreEqual("Action for multiple documents " + documentNumber + ", " + docNumber + " could not be processed! Please try identical document number.", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                    _physicalInventoryAction.ClickOnOkButton();
                }
                else
                {
                    LogInfo("Select the record which have different document number");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Perform Count Batch Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_330421.csv", "EWM_330421#csv", DataAccessMethod.Sequential)]
        public void TC_330421_PhysicalInventory_PerformCountBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string performCount = this.TestContext.DataRow["action"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Perform Count Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _physicalInventoryAction.ActivePIDocuments();             //Select Physical Inventory status Active order
                string docNum1 = _physicalInventoryAction.ReadColumText(1, 2);
                string docNum2 = _physicalInventoryAction.ReadColumText(2, 2);
                if (docNum1.Equals(docNum2))
                {
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1); //Select Checkbox for perform batch action
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                }
                else _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                _physicalInventoryAction.ClickBatchAction(performCount); //Select the perform count Batch Action
                if (_physicalInventoryAction.popText() == 1)
                {
                    WaitForMoment(2);
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                    docNum1 = _physicalInventoryAction.ReadColumText(2, 2);
                    _physicalInventoryAction.ClickBatchAction(performCount);
                }
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPagePostButton()); //Verify Post button should be disabled 
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPageCountButton());//Verify Count button should be disabled 
                _physicalInventoryAction.PIListViewCheckBox();                             //Select zero indictor checkbox 
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPagePostButton()); //Verify Post button should be disabled 
                _physicalInventoryAction.ClickOnCountButton();                            //Click on count button
                Boolean conutSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Document counted successfully").Contains("successfully");//Verification of success text post click on count button
                Assert.IsTrue(conutSuccessText, "Success Text is not receive post click on Count Button");
                _physicalInventoryAction.ClickOnPostButton();
                WaitForMoment(3);
                Assert.AreEqual("Are you sure you want to post counted items?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                WaitForMoment(2);
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                Boolean postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("PI Document Number").Contains("PI Document Number : " + docNum1 + " Item in this document");//Verification of success text post click on post button
                Assert.IsTrue(postSuccessText, "Success Text is not received post click on Post Button");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Perform Count detail Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_268145.csv", "EWM_268145#csv", DataAccessMethod.Sequential)]
        public void TC_268145_PhysicalInventory_PerformCountDetailActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string performCount = this.TestContext.DataRow["action"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Perform Count detail action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _physicalInventoryAction.ActivePIDocuments();
                string docNum1 = _physicalInventoryAction.ReadColumText(1, 2);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, performCount); //Select a order and Perform Count Detailed Action
                if (_physicalInventoryAction.popText() == 1)
                {
                    docNum1 = _physicalInventoryAction.ReadColumText(2, 2);
                    _eWMHandlingUnitsAction.VerifyDetialedAction(2, performCount);
                    _eWMHandlingUnitsAction.VerifyDetialedAction(2, performCount);
                }
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPagePostButton());//Verify Post button should be disabled 
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPageCountButton());//Verify Count button should be disabled 
                _physicalInventoryAction.PIListViewCheckBox();                            //Select zero indictor checkbox 
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPagePostButton());//Verify Post button should be disabled 
                _physicalInventoryAction.ClickOnCountButton();                            //Click on count button
                Boolean conutSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Document counted successfully").Contains("successfully");//Verification of success text post click on count button
                Assert.IsTrue(conutSuccessText, "Success Text is not receive post click on Count Button");
                _physicalInventoryAction.ClickOnPostButton();
                Boolean postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("PI Document ").Contains("PI Document Number : " + docNum1 + " Item in this document");//Verification of success text post click on post button
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Change Count detail Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_267875.csv", "EWM_267875#csv", DataAccessMethod.Sequential)]
        public void TC_267875_PhysicalInventory_ChangeCountDetailActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string performCount = this.TestContext.DataRow["action"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Change Count detail action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _physicalInventoryAction.CountedPIDocuments();
                string docNum1 = _physicalInventoryAction.ReadColumText(1, 2); //Read document number
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, performCount); //Select the Change Count Detailed Action
                if (_physicalInventoryAction.popText() == 1)
                {
                    docNum1 = _physicalInventoryAction.ReadColumText(2, 2);
                    _eWMHandlingUnitsAction.VerifyDetialedAction(2, performCount);
                }
                _physicalInventoryAction.EnterValueInActualQualityTextBox("2"); //Enter value in Actual quality
                _physicalInventoryAction.ClickOnCountButton();
                Boolean conutSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Document counted successfully").Contains("successfully");//Verification of success text post click on count button
                Assert.IsTrue(conutSuccessText, "Success Text is not receive post click on Count Button");
                _physicalInventoryAction.ClickOnPostButton();
                //Assert.AreEqual("Are you sure you want to post counted items ?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                //Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                WaitForMoment(1);
                bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("PI Document Number:").Contains("PI Document Number: " + docNum1);//Verification of success text post click on post button
                Assert.IsTrue(postSuccessText, "Success Text is not receive post click on Post Button");
                _physicalInventoryAction.All();
                _eWMHandlingUnitsAction.SearchTheText(docNum1);
                string piStatus = _physicalInventoryAction.ReadColumText(1, 4);
                Console.WriteLine(piStatus);
                Assert.AreEqual("Posted", piStatus, "Physical Inventory status is not updated properly"); // Verify physical inventory status should be posted
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Physical Inventory_Change Count Batch Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_347702.csv", "EWM_347702#csv", DataAccessMethod.Sequential)]
        public void TC_347702_PhysicalInventory_ChangeCountBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string performCount = this.TestContext.DataRow["action"].ToString();

                LogInfo("*********************Internal -> Physical Inventory->Change Count Batch action *******************");
                _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);                     //Go to Physical Inventory Persona Inbox
                _physicalInventoryAction.CountedPIDocuments();            //Select Physical Inventory status Counted order
                string docNum1 = _physicalInventoryAction.ReadColumText(1, 2);
                string docNum2 = _physicalInventoryAction.ReadColumText(2, 2);
                if (docNum1.Equals(docNum2))
                {
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1); //Select Checkbox for change count batch action
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                }
                else _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                _physicalInventoryAction.ClickBatchAction(performCount);//Select Checkbox for change count batch action
                if (_physicalInventoryAction.popText() == 1)
                {
                    WaitForMoment(2);
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(1);
                    _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                    docNum1 = _physicalInventoryAction.ReadColumText(2, 2);
                    _physicalInventoryAction.ClickBatchAction(performCount);
                }
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPagePostButton());//Verify Post button should be disabled 
                Assert.AreEqual("False", _physicalInventoryAction.PIDocPageCountButton());//Verify Count button should be disabled 
                _physicalInventoryAction.EnterValueInActualQualityTextBox("4"); //Enter value in Actual quality
                _physicalInventoryAction.ClickOnCountButton();
                Boolean conutSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Document counted successfully").Contains("successfully");//Verification of success text post click on count button
                Assert.IsTrue(conutSuccessText, "Success Text is not receive post click on Count Button");
                _physicalInventoryAction.ClickOnPostButton();
                Assert.AreEqual("Are you sure you want to post counted items?", _physicalInventoryAction.VerifyPopUpText());  //Verify Popup Text
                Assert.AreEqual("YES", _physicalInventoryAction.VerifyYesButton()); // Verify Yes Button on Popup
                WaitForMoment(1);
                bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("PI Document Number:").Contains("PI Document Number: " + docNum1);//Verification of success text post click on post button
                Assert.IsTrue(postSuccessText, "Success Text is not receive post click on Post Button");
                _physicalInventoryAction.All();
                _eWMHandlingUnitsAction.SearchTheText(docNum1);
                string piStatus = _physicalInventoryAction.ReadColumText(1, 4);
                Console.WriteLine(piStatus);
                Assert.AreEqual("Posted", piStatus, "Physical Inventory status is not updated properly"); // Verify physical inventory status should be posted
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Warehouse Tasks

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Warehouse Tasks_Confirm/Cancel Task Detail Action_Cancel Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_513940.csv", "EWM_513940#csv", DataAccessMethod.Sequential)]
        public void TC_513940_WarehouseTasks_ConfirmOrCancelTaskDetailAction_CancelTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona = this.TestContext.DataRow["persona"].ToString();
            string inboxNames1 = this.TestContext.DataRow["inboxNames1"].ToString();
            string inboxNames2 = this.TestContext.DataRow["inboxNames2"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
         
            LogInfo("*********************Internal -> Warehouse Tasks->Confirm/Cancel Task detail action_Cancel Task*******************");
            _homeAction.ClickOnFunction(function);   // Go to Warehouse Function and Internal Persona
            _warehouseTasksAction.MouseHoverToElement(inboxNames1);
            _warehouseTasksAction.ClickOnVerticalSmallIncrease();
            _inboxAction.ClickInbox(inboxNames2);                    //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 2); //Read order Id
            _eWMHandlingUnitsAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _baseAction.WaitForLoadingToDisappear();
            _warehouseTasksAction.ClickOnCancelTaskBtn();                 //click on Cancel button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Successfully").Contains("Task Cancelled Successfully ");//Verify Cancel task success text
            Assert.IsTrue(postSuccessText, "Cancel Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Cancel task");  //Verify the order id and record should be remove from grid
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Warehouse Tasks_Confirm/Cancel Task Detail Action_Confirm Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_513943.csv", "EWM_513943#csv", DataAccessMethod.Sequential)]
        public void TC_513943_WarehouseTasks_ConfirmOrCancelTaskDetailAction_ConfirmTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona = this.TestContext.DataRow["persona"].ToString();
            string inboxNames1 = this.TestContext.DataRow["inboxNames1"].ToString();
            string inboxNames2 = this.TestContext.DataRow["inboxNames2"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
            
            LogInfo("*********************Internal -> Warehouse Tasks->Confirm/Cancel Task detail action_Confirm Task*******************");
            _homeAction.ClickOnFunction(function);   // Go to Warehouse Function and Internal Persona
            _warehouseTasksAction.MouseHoverToElement(inboxNames1);
            _warehouseTasksAction.ClickOnVerticalSmallIncrease();
            _inboxAction.ClickInbox(inboxNames2);                      //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 3); //Read order Id
            string taskId = _physicalInventoryAction.ReadColumText(1, 2);
            _eWMHandlingUnitsAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _baseAction.WaitForLoadingToDisappear();
            _warehouseTasksAction.ClickOnConfirmTaskBtn();                 //Click on Confirm button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Task:").Contains("Task:" + taskId + "	Warehouse Order:WSC1");//Verify Confirm task success text
            Assert.IsTrue(postSuccessText, "Confirm Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Confirm task");  //Verify the order id and record should be remove from grid
        }
        #endregion
        #endregion

        #region Inbound Persona

        #region HU
        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Inbound_Handling Unit_Pallet Movement Master Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_269175.csv", "EWM_269175#csv", DataAccessMethod.Sequential)]
        public void TC_269175_InboundHUPalletMovementMasterActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string internalPersona = this.TestContext.DataRow["internalPersona"].ToString();
                string inboundPersona = this.TestContext.DataRow["inboundPersona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["masterAction"].ToString();
                string handlingUnitNo = this.TestContext.DataRow["handlingUnitNo"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();
                string storageBinValue = this.TestContext.DataRow["storageBin"].ToString();

                LogInfo("*********************Inbound -> Handling Unit ->Pallet Movement Master Action *******************");
                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _homeAction.ClickOnPersona(internalPersona);
                _homeAction.ClickOnPersona(inboundPersona);  //Go to Inbound Persona 
                _inboxAction.ClickInbox(inboxNames);         //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.ClickOnMasterAction(pallentMovement);  //Select Pallet Movement Master Action
                _eWMHandlingUnitsAction.SelectValueFromPicker(4, handlingUnitNo); //Select handling Unit on Source Tab
                _eWMHandlingUnitsAction.VerificationofPostButton();
                _eWMHandlingUnitsAction.ClickOnDestinationTab();              //Click on Destination Tab
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);   //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.VerificationOfToggleDefultState();   //Toggle should be in off state by default
                _eWMHandlingUnitsAction.ClickOnToggleBtn();
                _eWMHandlingUnitsAction.ClickPostButton();
                _eWMHandlingUnitsAction.VerfiySuccessText("Warehouse Order:"); //Verify the Success Text
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Inboundl_Handling Unit_Pallet Movement Detail Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_498879.csv", "EWM_498879#csv", DataAccessMethod.Sequential)]
        public void TC_498879_InboundHUPalletMovementDetailActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string internalPersona = this.TestContext.DataRow["internalPersona"].ToString();
                string inboundPersona = this.TestContext.DataRow["inboundPersona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["detailAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["storageBin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();
                string handlingUnitNo = this.TestContext.DataRow["handlingUnitNo"].ToString();

                LogInfo("*********************Inbound -> Handling Unit ->Pallet Movement Detail Action *******************");
                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _homeAction.ClickOnPersona(internalPersona);
                _homeAction.ClickOnPersona(inboundPersona);  //Go to Inbound Persona 
                _inboxAction.ClickInbox(inboxNames);         //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.SearchTheText(handlingUnitNo);
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, pallentMovement);  //Click on Pallet Movement Detailed Action.
                _eWMHandlingUnitsAction.ClickDetialedAction(pallentMovement);
                _eWMHandlingUnitsAction.VerificationofPostButton();              //Verify Post Button
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                //_binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);   //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.VerificationOfToggleDefultState();   //Toggle should be in off state by default
                _eWMHandlingUnitsAction.ClickOnToggleBtn();
                _eWMHandlingUnitsAction.ClickPostButton();
                _eWMHandlingUnitsAction.VerfiySuccessText("Warehouse Order:");//Verify The Succcess Text

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Inboundl_Handling Unit_Pallet Movement Batch Action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_499845.csv", "EWM_499845#csv", DataAccessMethod.Sequential)]
        public void TC_499845_InboundHUPalletMovementBatchActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string internalPersona = this.TestContext.DataRow["internalPersona"].ToString();
                string inboundPersona = this.TestContext.DataRow["inboundPersona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["batchAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["storageBin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();
                string handlingUnitNo = this.TestContext.DataRow["handlingUnitNo"].ToString();

                LogInfo("*********************Inbound -> Handling Unit ->Pallet Movement Batch Action *******************");
                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _homeAction.ClickOnPersona(internalPersona);
                _homeAction.ClickOnPersona(inboundPersona);  //Go to Inbound Persona 
                _inboxAction.ClickInbox(inboxNames);         //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.SearchTheText(handlingUnitNo);
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);          //Select checkbox to perform batch action
                _eWMHandlingUnitsAction.ClickOnBatchActionMoreButton();  //Click on Pallet Movement Batch Action.
                _eWMHandlingUnitsAction.SelectAction(pallentMovement);
                _eWMHandlingUnitsAction.VerificationofPostButton();       //Verify Post Button
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                // _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);   //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.VerificationOfToggleDefultState();   //Toggle should be in off state by default
                _eWMHandlingUnitsAction.ClickOnToggleBtn();
                _eWMHandlingUnitsAction.ClickPostButton();
                _eWMHandlingUnitsAction.VerfiySuccessText("Warehouse Order:");//Verify The Succcess Text
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Warehouse Tasks

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Inbound_Warehouse Tasks_Confirm/Cancel Task Detail Action_Cancel Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_512031.csv", "EWM_512031#csv", DataAccessMethod.Sequential)]
        public void TC_512031_WarehouseTasks_ConfirmOrCancelTaskDetailAction_CancelTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona1 = this.TestContext.DataRow["persona1"].ToString();
            string persona2 = this.TestContext.DataRow["persona2"].ToString();
            string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
            LogInfo("*********************Inbound -> Warehouse Tasks->Confirm/Cancel Task detail action_Cancel Task*******************");
            _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
            _homeAction.ClickOnPersona(persona1);                   //Go to Inbound Persona
            _homeAction.ClickOnPersona(persona2);
            _inboxAction.ClickInbox(inboxNames);                    //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 2); //Read order Id
            _eWMHandlingUnitsAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _warehouseTasksAction.ClickOnCancelTaskBtn();                 //click on Cancel button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Successfully").Contains("Task Cancelled Successfully ");//Verify Cancel task success text
            Assert.IsTrue(postSuccessText, "Cancel Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Cancel task");  //Verify the order id and record should be remove from grid
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Inbound Persona")]
        [TestCategory("EWM")]
        [Description("Inbound_Warehouse Tasks_Confirm/Cancel Task Detail Action_Confirm Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_512051.csv", "EWM_512051#csv", DataAccessMethod.Sequential)]
        public void TC_512051_WarehouseTasks_ConfirmOrCancelTaskDetailAction_ConfirmTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona1 = this.TestContext.DataRow["persona1"].ToString();
            string persona2 = this.TestContext.DataRow["persona2"].ToString();
            string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
            LogInfo("*********************Inbound -> Warehouse Tasks->Confirm/Cancel Task detail action_Confirm Task*******************");
            _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
            _homeAction.ClickOnPersona(persona1);                   //Go to Inbound Persona
            _homeAction.ClickOnPersona(persona2);
            _inboxAction.ClickInbox(inboxNames);                    //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 2); //Read order Id
            string taskId = _physicalInventoryAction.ReadColumText(1, 1);
            _eWMHandlingUnitsAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _warehouseTasksAction.ClickOnConfirmTaskBtn();                 //Click on Confirm button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Task:").Contains("Task:" + taskId + "	Warehouse Order:WSC1");//Verify Confirm task success text
            Assert.IsTrue(postSuccessText, "Confirm Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Confirm task");  //Verify the order id and record should be remove from grid
        }
        #endregion

        #endregion

        #region OutBound persona

        #region Warehouse Tasks

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Outbound Persona")]
        [TestCategory("EWM")]
        [Description("Outbound_Warehouse Tasks_Confirm/Cancel Task Detail Action_Cancel Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_512151.csv", "EWM_512151#csv", DataAccessMethod.Sequential)]
        public void TC_512151_WarehouseTasks_ConfirmOrCancelTaskDetailAction_CancelTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona1 = this.TestContext.DataRow["persona1"].ToString();
            string persona2 = this.TestContext.DataRow["persona2"].ToString();
            string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
            LogInfo("*********************Outbound -> Warehouse Tasks->Confirm/Cancel Task detail action_Cancel Task*******************");
            _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
            _homeAction.ClickOnPersona(persona1);                   //Go to Outbound Persona
            _homeAction.ClickOnPersona(persona2);
            _inboxAction.ClickInbox(inboxNames);                    //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 2); //Read order Id
            _warehouseTasksAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _warehouseTasksAction.ClickOnCancelTaskBtn();                 //click on Cancel button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Successfully").Contains("Task Cancelled Successfully ");//Verify Cancel task success text
            Assert.IsTrue(postSuccessText, "Cancel Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Cancel task");  //Verify the order id and record should be remove from grid
        }

        [TestMethod]
        [TestCategory("Regression Tescase")]
        [TestCategory("Outbound Persona")]
        [TestCategory("EWM")]
        [Description("Outbound_Warehouse Tasks_Confirm/Cancel Task Detail Action_Confirm Task;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_512152.csv", "EWM_512152#csv", DataAccessMethod.Sequential)]
        public void TC_512152_WarehouseTasks_ConfirmOrCancelTaskDetailAction_ConfirmTaskTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string persona1 = this.TestContext.DataRow["persona1"].ToString();
            string persona2 = this.TestContext.DataRow["persona2"].ToString();
            string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
            string action = this.TestContext.DataRow["action"].ToString();
            LogInfo("*********************Outbound -> Warehouse Tasks->Confirm/Cancel Task detail action_Confirm Task*******************");
            _homeAction.ClickOnFunction(function);                  // Go to Warehouse Function
            _homeAction.ClickOnPersona(persona1);                   //Go to Outbound Persona
            _homeAction.ClickOnPersona(persona2);
            _inboxAction.ClickInbox(inboxNames);                    //Go to Warehouse tasks inbox
            string orderId = _physicalInventoryAction.ReadColumText(1, 3); //Read order Id
            string taskId = _physicalInventoryAction.ReadColumText(1, 2);
            _warehouseTasksAction.VerifyDetialedAction(1, action);      //Perform Confirm/Cancel Task detail action
            _warehouseTasksAction.ClickOnConfirmTaskBtn();                 //Click on Confirm button 
            bool postSuccessText = _eWMHandlingUnitsAction.VerfiySuccessText("Task:").Contains("Task:" + taskId + "	Warehouse Order:WSC1");//Verify Confirm task success text
            Assert.IsTrue(postSuccessText, "Confirm Task order is not working");
            _eWMHandlingUnitsAction.SearchTheText(orderId);
            _warehouseTasksAction.VerificationOfRecord("Confirm task");  //Verify the order id and record should be remove from grid
        }
        #endregion
        #endregion

        #endregion
        #region Sanity Testcases

        [TestMethod]
        [TestCategory("Sanity Testcase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("EWM Sanity_Internal_Handling Unit: Verification of Pickers in Handling Units_Pallet Movement detailed & batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_491438.csv", "EWM_491438#csv", DataAccessMethod.Sequential)]
        public void TC_491438_PickersInHandlingUnitPalletMovementActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string pallentMovement = this.TestContext.DataRow["detailedAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["dest_StorageBin"].ToString();
                string reasonCodeValue = this.TestContext.DataRow["reasonCode"].ToString();

                _homeAction.ClickOnFunction(function);  //Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);     //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, pallentMovement);    /* Click on Palllet Movement Detailed Action.*/
                _binsProductsAction.SelectValueFromPicker(storageBinValue);     //Click on Destination Bin picker and select Values.
                _binsProductsAction.SelectValueFromReasonCodePicker(reasonCodeValue);        //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.ClickOnBackButton();
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);     //Select checkbox to perform batch action
                _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                _eWMHandlingUnitsAction.ClickOnBatchAction(pallentMovement);     //Click on Palllet Movement batch action
                _eWMHandlingUnitsAction.SelectValueFromPicker(4, storageBinValue);      //Click on Destination Bin picker and select Values.
                _eWMHandlingUnitsAction.SelectValueFromPicker(6, reasonCodeValue);        //Click on Reason Code picker and select Values.
                _eWMHandlingUnitsAction.ClickOnBackButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Sanity Testcase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("EWM Sanity_Internal_Handling Unit: Verification of Pickers in Handling Units_Repck Product detailed & batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_493287.csv", "EWM_493287#csv", DataAccessMethod.Sequential)]
        public void TC_493287_PickersInHandlingUnitRepackProductActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string repackProcuct = this.TestContext.DataRow["detailedAction"].ToString();
                string packingMaterialCodeValue = this.TestContext.DataRow["packingMaterialCode"].ToString();

                _homeAction.ClickOnFunction(function);     // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);     //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, repackProcuct);      /*Click on Repack Product Detailed Action.*/
                _eWMHandlingUnitsAction.SelectValueFromPicker(6, packingMaterialCodeValue);      //Click on Packing Material picker and select Values.
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Sanity Testcase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("EWM Sanity_Internal_Handling Unit: Verification of Pickers in Handling Units_Repck Handling Units detailed & batch action;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_493282.csv", "EWM_493282#csv", DataAccessMethod.Sequential)]
        public void TC_493282_PickersInHandlingUnitRepackHandlingUnitsActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string repackHandlingUnits = this.TestContext.DataRow["detailedAction"].ToString();
                string storageBinValue = this.TestContext.DataRow["dest_StorageBin"].ToString();
                string packingMaterialCodeValue = this.TestContext.DataRow["packingMaterialCode"].ToString();
                string destinationHandlingUnitCodeValue = this.TestContext.DataRow["destinationHandlingUnitCode"].ToString();


                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);        //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.VerifyDetialedAction(1, repackHandlingUnits);       /*Click on Repack Handling Units Detailed Action.*/
                _eWMHandlingUnitsAction.SelectValueFromPicker(4, destinationHandlingUnitCodeValue);      //Click on destination Handling Unit picker and select Values.
                _eWMHandlingUnitsAction.SelectValueFromPicker(6, packingMaterialCodeValue);     //Click on Packing Material picker and select Values.
                _eWMHandlingUnitsAction.SelectValueFromPicker(9, storageBinValue);      //Click on Storage Bin picker and select Values.
                _eWMHandlingUnitsAction.ClickOnBackButton();
                _eWMHandlingUnitsAction.SelectBatchCheckbox(1);          //Select checkbox to perform batch action
                _eWMHandlingUnitsAction.SelectBatchCheckbox(2);
                _eWMHandlingUnitsAction.ClickOnBatchAction(repackHandlingUnits);         //Click on Repack Handling Units batch action
                _eWMHandlingUnitsAction.SelectValueFromPicker(4, destinationHandlingUnitCodeValue);     //Click on destination Handling Unit picker and select Values.
                _eWMHandlingUnitsAction.SelectValueFromPicker(6, packingMaterialCodeValue);     //Click on Packing Material picker and select Values.
                _eWMHandlingUnitsAction.SelectValueFromPicker(9, storageBinValue);       //Click on Storage Bin picker and select Values.

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Sanity Testcase")]
        [TestCategory("Internal Persona")]
        [TestCategory("EWM")]
        [Description("Internal_Handling Unit_Print Handling Units Master Action: Verification of Pickers;Details validation after click on down/Expand arrow;Delete selected handling unit;Verification of Print Button and success text;;")]
        [Owner("priyanka.KadlagEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EWM_494755.csv", "EWM_494755#csv", DataAccessMethod.Sequential)]
        public void TC_494755_PickersInPrintHandlingUnitsMasterActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string handlingUniNo = this.TestContext.DataRow["handlingUnitNo"].ToString();
                string masterAction = this.TestContext.DataRow["masterAction"].ToString();
                string materialDescription = this.TestContext.DataRow["materialDescription"].ToString();
                string materialNumber = this.TestContext.DataRow["materialNumber"].ToString();
                string quality = this.TestContext.DataRow["quality"].ToString();
                string UoM = this.TestContext.DataRow["UoM"].ToString();
                string successText = this.TestContext.DataRow["successText"].ToString();

                _homeAction.ClickOnFunction(function);      // Go to Warehouse Function
                _inboxAction.ClickInbox(inboxNames);        //Go to Handling Units Inbox
                _eWMHandlingUnitsAction.ClickOnPrintHandlingUnitsMasterBtn(masterAction);  //Select 'Print Handling units' Master Action
                _eWMHandlingUnitsAction.VerificationofPrintButton();  //Verify the Print Button should be disabled until fill mandatory fields
                _eWMHandlingUnitsAction.SelectValueFromPicker(4, handlingUniNo); //Click on Handling Unit picker and select Values.
                _eWMHandlingUnitsAction.ClickOnExpandArrow();   //Click on Handling Unit picker and select Values.
                _eWMHandlingUnitsAction.VerificationOfHandlingUnitDetails(materialDescription); //Verify Material decription,MaterialNumber,Quality after click on expand arrow
                _eWMHandlingUnitsAction.VerificationOfHandlingUnitDetails(materialNumber);
                _eWMHandlingUnitsAction.VerificationOfHandlingUnitDetails(quality + " " + UoM);
                _eWMHandlingUnitsAction.ClickOnDeleteIcon();        //Click on Delete Icon
                _eWMHandlingUnitsAction.VerificationofPrintButton();//Verify the Print Button should be disabled until fill mandatory fields
                _eWMHandlingUnitsAction.SelectValueFromPicker(5, handlingUniNo);
                _eWMHandlingUnitsAction.ClickOnPrintButton();            //Click on print button
                _eWMHandlingUnitsAction.VerfiySuccessText(successText);   //Verify success text
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
