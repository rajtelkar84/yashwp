using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("MyPRTest")]
    [TestClass]
    public class MyPRTest : BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_283792_CreateServicePRTest1()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillServicePRFormWithCostCenter(itemdesc, location,costcenter, vendor,glaccount);
                _createPRPageAction.ActionAfterFormFilling();
               

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]


        public void TC_285843_CreatePRWithAttachment()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                WaitForMoment(0.8);
                _createPRPageAction.ActionAfterFormFillingwithAttachment();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_281068_DeletePRItem()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartDeleteButton();
                _createPRPageAction.ClickOnCartOkButton();
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartDeleteButton();
                _createPRPageAction.ClickOnCartOkButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_286360.csv", "CreatePurchaseRequisition_286360#csv", DataAccessMethod.Sequential)]
        public void TC_286360_EditMultipleLineItemPR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string editbuttonnum = this.TestContext.DataRow["editbuttonnum"].ToString();
             


                NavigateToInboxByGlobalSearch(function, inbox);
                String[] itemdescbr = itemdesc.Split('*');
                String[] editbuttonnumbr = editbuttonnum.Split('*');


                _createPRPageAction.FillProductPRFormwithCostCenter(itemdescbr[0], location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                WaitForMoment(0.4);
                _createPRPageAction.EnterItemDescription(itemdescbr[1]);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroup();
                //SelectVendor();
                //SearchVendor();
                //EnterVendor(vendor);
                _createPRPageAction.EnterQuantity();
                _createPRPageAction.EnterPrice();
                _createPRPageAction.EnterUnit();
                _createPRPageAction.SearchUnitOfMeasure();
                _createPRPageAction.SelectUnitOfMeasure();
                //EnterUnitOfMeasure();
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartMultipleEditButton(itemdescbr[0]);
                //_createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ActionAfterFormFilling();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        //working

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_324887.csv", "CreatePurchaseRequisition_324887#csv", DataAccessMethod.Sequential)]
        public void TC_324887_EditMultipleItemswithAttachment()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString(); 
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string editbuttonnum = this.TestContext.DataRow["editbuttonnum"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatematerialgroup = this.TestContext.DataRow["update-materialgroup"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                String[] itemdescbr = itemdesc.Split('*');
                String[] editbuttonnumbr = editbuttonnum.Split('*');
                String[] updateitembr = updateitem.Split('*');

                _createPRPageAction.FillProductPRFormwithCostCenter(itemdescbr[0], location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                WaitForMoment(0.4);
                _createPRPageAction.EnterItemDescription(itemdescbr[1]);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroup();
                //SelectVendor();
                //SearchVendor();
                //EnterVendor(vendor);
                _createPRPageAction.EnterQuantity();
                _createPRPageAction.EnterPrice();
                _createPRPageAction.EnterUnit();
                WaitForMoment(0.4);
                _createPRPageAction.SearchUnitOfMeasure();
                _createPRPageAction.SelectUnitOfMeasure();
                //EnterUnitOfMeasure();
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartMultipleEditButton(itemdescbr[0]);
                //_createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitembr[0]);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ClickOnCartMultipleEditButton(itemdescbr[1]);
                //_createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitembr[1]);
                _createPRPageAction.SearchMaterialGroup();
                _createPRPageAction.UpdateMaterialGroup(updatematerialgroup);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ActionAfterFormFillingwithAttachment();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_295760.csv", "CreatePurchaseRequisition_295760#csv", DataAccessMethod.Sequential)]
        public void TC_295760_EditPRwithMultipleAttachments()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string filenames = this.TestContext.DataRow["filenames"].ToString();
                string editbuttonnum = this.TestContext.DataRow["editbuttonnum"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatematerialgroup = this.TestContext.DataRow["update-materialgroup"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                String[] itemdescbr = itemdesc.Split('*');
                String[] editbuttonnumbr = editbuttonnum.Split('*');
                String[] updateitembr = updateitem.Split('*');
                String[] filenamesbr = filenames.Split('*');

                _createPRPageAction.FillProductPRFormwithCostCenter(itemdescbr[0], location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickCartNext();
                _createPRPageAction.ClickOnAddAttachment();
                WaitForMoment(0.4);
                for (int i = 0; i < filenamesbr.Length; i++)
                {
                    _createPRPageAction.EnterMultipleFileNames(filenamesbr[i]);
                    _createPRPageAction.ClickOpenFile();
                    while (i != filenamesbr.Length)
                    {

                        _createPRPageAction.ClickOnSecondAddAttachment();
                    }

                }

                _createPRPageAction.ClickTotalAmt();
                _createPRPageAction.ClickCreatePR();
                _createPRPageAction.ClickOnApproverCmtSubmitButton();
                _createPRPageAction.ClickOnFinalOK();
                //_createPRPageAction.ActionAfterFormFillingwithMultipleAttachments(filenamesbr[i]);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_292920.csv", "CreatePurchaseRequisition_292920#csv", DataAccessMethod.Sequential)]
        public void TC_292920_EditPRwithoutVendor()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string rowname = this.TestContext.DataRow["rowname"].ToString();
                string updateexpectedvalue = this.TestContext.DataRow["update-expectedvalue"].ToString();
                string updateoverallimit = this.TestContext.DataRow["update-overallimit"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();
                _createPRPageAction.SelectServicePR();
                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroup();
                _createPRPageAction.EnterExpectedValue();
                _createPRPageAction.EnterOverallLimit();
                _createPRPageAction.SelectCostCenter();
                _createPRPageAction.SearchCostCenter(costcenter);
                _createPRPageAction.EnterGLAccount(glaccount);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ActionAfterFormFilling();
                WaitForMoment(0.17);
                _createPRPageAction.ClickOnHomeActions(rowname);
                _createPRPageAction.ClickOnEditRequisition();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.UpdateExpectedValue(updateexpectedvalue);
                _createPRPageAction.UpdateOverallLimit(updateoverallimit);
                _createPRPageAction.ClickOnUpdateButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_281160_EditPR_CancelAndUpdate()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string updatequantity = this.TestContext.DataRow["updatequantity"].ToString();
                string updateprice = this.TestContext.DataRow["updateprice"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.ClickOnCancelButton();
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateQuantity(updatequantity);
                _createPRPageAction.UpdatePrice(updateprice);
                _createPRPageAction.ClickOnUpdateButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_289759.csv", "CreatePurchaseRequisition_289759#csv", DataAccessMethod.Sequential)]
        public void TC_289759_EditPRFromMyPRHome()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string rowname = this.TestContext.DataRow["rowname"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnHomeActions(rowname);
                _createPRPageAction.ClickOnEditRequisition();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.ClickOnUpdateButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_324897.csv", "CreatePurchaseRequisition_324897#csv", DataAccessMethod.Sequential)]
        public void TC_324897_EditCopiedPRFromPRHome()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatecostcenter = this.TestContext.DataRow["update-costcenter"].ToString();
                string updateglaccount = this.TestContext.DataRow["update-glaccount"].ToString();
                string updatepercentage = this.TestContext.DataRow["updatepercentage"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string rowname = this.TestContext.DataRow["rowname"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnHomeActions(rowname);
                _createPRPageAction.ClickOnCopyandCreateRequisition();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.UpdatePercentageDetailsinMultipleCC(updatepercentage, updatecostcenter, glaccount);
                //_createPRPageAction.UpdateGLAccount(updateglaccount);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ActionAfterFormFilling();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_281857_CreateRPMultipleLineItem()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillServicePRFormWithCostCenter(itemdesc, location, costcenter, vendor,glaccount);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.FillServicePRFormWithCostCenter(itemdesc, location, costcenter, vendor,glaccount);
                _createPRPageAction.ClickAddToItemList();

                _createPRPageAction.EnterNewItemDescription(newitemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroup();
                _createPRPageAction.EnterExpectedValue();
                _createPRPageAction.EnterOverallLimit();
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.EnterNewItemDescription(newitemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroup();
                _createPRPageAction.EnterExpectedValue();
                _createPRPageAction.EnterOverallLimit();
                _createPRPageAction.ClickAddToItemList();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_284743_CreateServiceProjectTypePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string projectcode = this.TestContext.DataRow["projectcode"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillServicePRFormWithProjectCode(itemdesc, location, projectcode, vendor);
                _createPRPageAction.ActionAfterFormFilling();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444313.csv", "CreatePurchaseRequisition_444313#csv", DataAccessMethod.Sequential)]
        public void TC_444313_CreateMaterialProfitCenterTypePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string projectcode = this.TestContext.DataRow["projectcode"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string profitcenter = this.TestContext.DataRow["profitcenter"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithProfitCenter(itemdesc, location, glaccount, profitcenter, vendor);
                _createPRPageAction.ActionAfterFormFilling();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_329025.csv", "CreatePurchaseRequisition_329025#csv", DataAccessMethod.Sequential)]
        public void TC_329025_CreateCategoryJServicePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string projectcode = this.TestContext.DataRow["projectcode"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillServicePRCategoryJForm(itemdesc, location, costcenter, projectcode, vendor, glaccount);
                _createPRPageAction.ActionAfterFormFilling();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_329026.csv", "CreatePurchaseRequisition_329026#csv", DataAccessMethod.Sequential)]
        public void TC_329026_EditCategoryJServicePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string projectcode = this.TestContext.DataRow["projectcode"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string profitcenter = this.TestContext.DataRow["profitcenter"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillServicePRCategoryJForm(itemdesc, location, costcenter, projectcode, vendor, glaccount);
                _createPRPageAction.ActionAfterFormFilling();
                _createPRPageAction.ClickOnEditRequisition();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.ClickPurchaseTypeSelection();
                _createPRPageAction.SelectPurchaseProfitType();
                _createPRPageAction.EnterProfitCenter(profitcenter);
                _createPRPageAction.EnterGLAccount(glaccount);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ClickCartNext();
                _createPRPageAction.ClickTotalAmt();
                _createPRPageAction.ClickCreatePR();
                _createPRPageAction.ClickOnApproverCmtSubmitButton();
                _createPRPageAction.ClickOnFinalOK();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }



        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_342803_CreateTemplateForServicePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();
                _createPRPageAction.SelectServicePR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.ClickSaveAsTemplate();
                _createPRPageAction.EnterTemplateName();
                _createPRPageAction.SaveTemplateFinal();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisitionCatB_422558.csv", "CreatePurchaseRequisitionCatB_422558#csv", DataAccessMethod.Sequential)]
        public void TC_422558_CreateCategoryBPurchaseRequisition()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();

                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.FillCatBPRFormwithCostCenter(costcenter, vendor);
                _createPRPageAction.ActionAfterFormFilling();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisitionCatB_425306.csv", "CreatePurchaseRequisitionCatB_425306#csv", DataAccessMethod.Sequential)]
        public void TC_425306_CreateCategoryBPRwithAttachment()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();

                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.FillCatBPRFormwithCostCenter(costcenter, vendor);
                _createPRPageAction.ActionAfterFormFillingwithAttachment();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisitionCatB_429368.csv", "CreatePurchaseRequisitionCatB_429368#csv", DataAccessMethod.Sequential)]
        public void TC_429368_ChkCategoryBMaterialGroups()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();

                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.EnterCatBMaterialGroup(catbmaterialgrpid);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterCatBMaterialGroup(catbmaterialgrpid);


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisitionCatB_422558.csv", "CreatePurchaseRequisitionCatB_422558#csv", DataAccessMethod.Sequential)]
        public void TC_428672_CreateCategoryBProjectTypePR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string projectcode = this.TestContext.DataRow["projectcode"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();

                _createPRPageAction.AutoConvertPR();
                //_createPRPageAction.SelectLocation();
                // _createPRPageAction.SearchLocation(location);
                _createPRPageAction.EnterLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                //_createPRPageAction.FillCatBPRFormwithProjectCode(projectcode);
                _createPRPageAction.FillCatBPRFormwithProjectCode(vendor, projectcode);
                _createPRPageAction.ActionAfterFormFilling();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisitionCatB_422558.csv", "CreatePurchaseRequisitionCatB_422558#csv", DataAccessMethod.Sequential)]
        public void TC_425303_DeleteCategoryBPR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();

                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.FillCatBPRFormwithCostCenter(costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartDeleteButton();
                _createPRPageAction.ClickOnCartOkButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_425304.csv", "CreatePurchaseRequisition_425304#csv", DataAccessMethod.Sequential)]
        public void TC_425304_CreateMultipleLineItemCatBPR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updateexpectedvalue = this.TestContext.DataRow["update-expectedvalue"].ToString();
                string updateoverallimit = this.TestContext.DataRow["update-overallimit"].ToString();
                string updatecostcenter = this.TestContext.DataRow["update-costcenter"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();
                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.FillCatBPRFormwithCostCenter(costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.EnterNewItemDescription(newitemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.UpdateExpectedValue(updateexpectedvalue);
                _createPRPageAction.UpdateOverallLimit(updateoverallimit);
                _createPRPageAction.UpdateCostCenter(updatecostcenter);
                _createPRPageAction.ClickAddToItemList();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_425304.csv", "CreatePurchaseRequisition_425304#csv", DataAccessMethod.Sequential)]
        public void TC_425307_EditCategoryBPR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string catbmaterialgrpid = this.TestContext.DataRow["catbmaterialgrpid"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updateexpectedvalue = this.TestContext.DataRow["update-expectedvalue"].ToString();
                string updateoverallimit = this.TestContext.DataRow["update-overallimit"].ToString();
                string updatecostcenter = this.TestContext.DataRow["update-costcenter"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.ClickOnCreatePR();
                _createPRPageAction.AutoConvertPR();
                _createPRPageAction.SelectLocation();
                _createPRPageAction.SearchLocation(location);
                _createPRPageAction.SelectCatBOption();
                _createPRPageAction.EnterItemDescription(itemdesc);
                _createPRPageAction.SelectMaterialGroup();
                _createPRPageAction.SearchMaterialGroupForCatB(catbmaterialgrpid);
                _createPRPageAction.FillCatBPRFormwithCostCenter(costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.UpdateExpectedValue(updateexpectedvalue);
                _createPRPageAction.UpdateOverallLimit(updateoverallimit);
                _createPRPageAction.ClickOnUpdateButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]
        public void TC_342784_CreateTemplateForMaterialPR()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickSaveAsTemplate();
                _createPRPageAction.EnterTemplateName();
                _createPRPageAction.SaveTemplateFinal();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444307.csv", "CreatePurchaseRequisition_444307#csv", DataAccessMethod.Sequential)]
        public void TC_444307_MultipleCostCenterDistributionByPercentage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string percentage = this.TestContext.DataRow["percentage"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                //string number = this.TestContext.DataRow["number"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithMultipleCostCenter(itemdesc, location, vendor);
                _createPRPageAction.SelectDistributionByPercentage();
                _createPRPageAction.FillMultipleCCDistributionByPercentageDetails(percentage, costcenter, glaccount);
                _createPRPageAction.ActionAfterFormFilling();



            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444304.csv", "CreatePurchaseRequisition_444304#csv", DataAccessMethod.Sequential)]
        public void TC_444304_MultipleCostCenterDistributionOnQuantity()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string quantity = this.TestContext.DataRow["quantity"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                //string number = this.TestContext.DataRow["number"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithMultipleCostCenter(itemdesc, location, vendor);
                _createPRPageAction.SelectDistributionOnQuantity();
                _createPRPageAction.FillMultipleCCDistributionByQuantityDetails(quantity, costcenter, glaccount);
                _createPRPageAction.ActionAfterFormFilling();



            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444291.csv", "CreatePurchaseRequisition_444291#csv", DataAccessMethod.Sequential)]
        public void TC_444291_MultipleCostCenterMultipleLineItems()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string itemdesc2 = this.TestContext.DataRow["itemdesc2"].ToString();
                string itemdesc3 = this.TestContext.DataRow["itemdesc3"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string percentage = this.TestContext.DataRow["percentage"].ToString();
                string quantity = this.TestContext.DataRow["quantity"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string costcenter2 = this.TestContext.DataRow["costcenter2"].ToString();
                string costcenter3 = this.TestContext.DataRow["costcenter3"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string glaccount2 = this.TestContext.DataRow["glaccount2"].ToString();
                string glaccount3 = this.TestContext.DataRow["glaccount3"].ToString();
                //string number = this.TestContext.DataRow["number"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.FillForMultipleLine(itemdesc2, vendor);
                _createPRPageAction.SelectDistributionByPercentage();
                _createPRPageAction.FillMultipleCCDistributionByPercentageDetails(percentage, costcenter2, glaccount2);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.FillForMultipleLine(itemdesc3, vendor);
                _createPRPageAction.SelectDistributionOnQuantity();
                _createPRPageAction.FillMultipleCCDistributionByQuantityDetails(quantity, costcenter3, glaccount3);
                _createPRPageAction.ActionAfterFormFillingwithAttachment();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }



        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444310.csv", "CreatePurchaseRequisition_444310#csv", DataAccessMethod.Sequential)]
        public void TC_444310_EditMultipleCostCenterDistributionByPercentage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string percentage = this.TestContext.DataRow["percentage"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatepercentage = this.TestContext.DataRow["update-percentage"].ToString();
                string updatecostcenter = this.TestContext.DataRow["update-costcenter"].ToString();


                LogInfo(updatepercentage);

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithMultipleCostCenter(itemdesc, location, vendor);
                _createPRPageAction.SelectDistributionByPercentage();
                _createPRPageAction.FillMultipleCCDistributionByPercentageDetails(percentage, costcenter, glaccount);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                _createPRPageAction.SelectDistributionByPercentage();
                _createPRPageAction.UpdatePercentageDetailsinMultipleCC(updatepercentage, costcenter, glaccount);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ActionAfterFormFilling();



            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_444311.csv", "CreatePurchaseRequisition_444311#csv", DataAccessMethod.Sequential)]
        public void TC_444311_EditMultipleCostCenterDistributionOnQuantity()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string quantity = this.TestContext.DataRow["quantity"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatequantity = this.TestContext.DataRow["update-quantity"].ToString();
                string updatecostcenter = this.TestContext.DataRow["update-costcenter"].ToString();


                LogInfo(updatequantity);

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithMultipleCostCenter(itemdesc, location, vendor);
                _createPRPageAction.SelectDistributionOnQuantity();
                _createPRPageAction.FillMultipleCCDistributionByQuantityDetails(quantity, costcenter, glaccount);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickOnCartEditButton();
                _createPRPageAction.UpdateItemDescription(updateitem);
                //_createPRPageAction.SelectDistributionByPercentage();
                _createPRPageAction.UpdateQuantityDetailsinMultipleCC(updatequantity, costcenter, glaccount);
                _createPRPageAction.ClickOnUpdateButton();
                _createPRPageAction.ActionAfterFormFilling();



            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }




        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_283792.csv", "CreatePurchaseRequisition_283792#csv", DataAccessMethod.Sequential)]


        public void TC_444241_C1LevelApproverAsRequisitioner()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string C1userName = this.TestContext.Properties["C1userName"].ToString();
                string A1userName = this.TestContext.Properties["A1userName"].ToString();
                string P1userName = this.TestContext.Properties["P1userName"].ToString();
                string password = this.TestContext.Properties["P1A1C1password"].ToString();
                //Requestor is the creator
                //C1 is the requisitioner 
                //cost center INSC012 
                //P1 1st approver
                //A1 2n approver
                //C1 Final Approver

                LogoutWD();
                LaunchApp();
                LoginToWD(C1userName, password);

                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount, costcenter, vendor);
                WaitForMoment(0.8);
                _createPRPageAction.ActionAfterFormFillingwithAttachment();
                LogoutWD();
                LaunchApp();
                LoginToWD(P1userName, password);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_428674.csv", "CreatePurchaseRequisition_428674#csv", DataAccessMethod.Sequential)]
        public void TC_428674_CreateEXTONLabPRIndirect()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string newitemdesc = this.TestContext.DataRow["newitemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string filenames = this.TestContext.DataRow["filenames"].ToString();
                string editbuttonnum = this.TestContext.DataRow["editbuttonnum"].ToString();
                string updateitem = this.TestContext.DataRow["update-item"].ToString();
                string updatematerialgroup = this.TestContext.DataRow["update-materialgroup"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                String[] itemdescbr = itemdesc.Split('*');
                
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdescbr[0], location, glaccount, costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ActionAfterFormFillingwithAttachment();
                WaitForMoment(0.4);
                
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("MyPRTest")]
        [Description("Tests the Purchase Requisition WorkFlows")]
        [Owner("Sushma.ParigiEXTERNAL@wstpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreatePurchaseRequisition_329044.csv", "CreatePurchaseRequisition_329044#csv", DataAccessMethod.Sequential)]
        public void TC_329044_ClearCartForSingleItem()
        {
            try
            {

                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string itemdesc = this.TestContext.DataRow["itemdesc"].ToString();
                string location = this.TestContext.DataRow["location"].ToString();
                string costcenter = this.TestContext.DataRow["costcenter"].ToString();
                string vendor = this.TestContext.DataRow["vendor"].ToString();
                string glaccount = this.TestContext.DataRow["glaccount"].ToString();
                string fulllocation = this.TestContext.DataRow["fulllocation"].ToString();
                string fullcostcenter = this.TestContext.DataRow["fullcostcenter"].ToString();
                string fullglaccount = this.TestContext.DataRow["fullglaccount"].ToString();


                NavigateToInboxByGlobalSearch(function, inbox);
                _createPRPageAction.FillProductPRFormwithCostCenter(itemdesc, location, glaccount,costcenter, vendor);
                _createPRPageAction.ClickAddToItemList();
                _createPRPageAction.ClickClearCart();
                _createPRPageAction.ClickOnClearCartCancelButton();
                _createPRPageAction.VerifyFormDetailsAfterCancelReset(fulllocation,fullcostcenter,fullglaccount);
                _createPRPageAction.ClickClearCart();
                _createPRPageAction.ClickOnClearCartOKButton();
                _createPRPageAction.VerifyFormDetailsAfterOKReset(fulllocation, fullcostcenter, fullglaccount);
                

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
