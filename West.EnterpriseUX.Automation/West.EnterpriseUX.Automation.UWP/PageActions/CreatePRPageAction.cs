using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CreatePRPageAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CreatePRPage _createPRPageinstance;

        public CreatePRPageAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _createPRPageinstance = new CreatePRPage(_session);
        }
        //*******************************Home Actions ************************
        public void ClickOnCreatePR()
        {
            WaitForMoment(0.3);
            _createPRPageinstance.CreatePRHomeButton.Click();
            //  WaitForMoment(0.3);
        }
        public void ClickOnHomeActions(String value)
        {
            WaitForMoment(0.3);
            int size = _createPRPageinstance.ActionsHomeButton(value).Count;
            _createPRPageinstance.ActionsHomeButton(value)[size - 1].Click();
            //  WaitForMoment(0.3);
        }
        public void ClickOnEditRequisition()
        {
            WaitForMoment(0.3);
            _createPRPageinstance.EditRequisition.Click();
            //  WaitForMoment(0.3);
        }

        public void ClickOnCopyandCreateRequisition()
        {
            WaitForMoment(0.3);
            _createPRPageinstance.CopyandCreateRequisition.Click();
            //  WaitForMoment(0.3);
        }


        //***********************************************Create PR Actions**********************************
        public void SelectServicePR()
        {

            _createPRPageinstance.ServiceRequstRadio("YES").Click();
            WaitForMoment(0.10);
        }
        public void AutoConvertPR()
        {

            _createPRPageinstance.ConvertPRtoPORadio("YES").Click();
            WaitForMoment(0.3);
        }

        public void SelectCatBOption()
        {

            _createPRPageinstance.CategoryBRadio("YES").Click();
            WaitForMoment(0.3);
        }

        public void SelectLocation()
        {
            int size = _createPRPageinstance.ListImage.Count;
            _createPRPageinstance.ListImage[size - 1].Click();
            WaitForMoment(0.3);
        }
        public void SearchLocation(String value)
        {
            _createPRPageinstance.LocationSearch.SendKeys(value);
            _createPRPageinstance.LocationSearchResult(value).Click();
            WaitForMoment(0.4);
        }

        public void EnterLocation(String value)
        {
            _createPRPageinstance.LocationTextBox.Click();
            _createPRPageinstance.LocationTextBox.SendKeys(value);
            WaitForMoment(0.4);
        }

        public void EnterItemDescription(String value)
        {
            _createPRPageinstance.ItemDescription.SendKeys(value);

        }



        public void EnterNewItemDescription(String value)
        {
            _createPRPageinstance.ItemDescription.Clear();
            _createPRPageinstance.ItemDescription.SendKeys(value);

        }

        public void UpdateItemDescription(String value)
        {
            _createPRPageinstance.ItemDescription.Clear();
            _createPRPageinstance.ItemDescription.SendKeys(value);

        }

        /* public void UpdateCatBItemDescription(String value)
         {
             _createPRPageinstance.ItemDescription(value).Clear();
             _createPRPageinstance.ItemDescription(value).SendKeys(value);

         }*/
        public void SelectMaterialGroup()
        {
            int size = _createPRPageinstance.MaterialGroupImage.Count;
            _createPRPageinstance.MaterialGroupImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void UpdateMaterialGroup(String value)
        {
            _createPRPageinstance.MaterialGroupSearch.SendKeys(value);
            _createPRPageinstance.updateMaterialGroupSearchResult(value).Click();
           
        }
        public void SearchMaterialGroup()
        {
            _createPRPageinstance.MaterialGroupSearch.SendKeys("Metal Components");
            _createPRPageinstance.MaterialGroupSearchResult.Click();
        }

        public void SearchMaterialGroupForCatB(String value)
        {
            _createPRPageinstance.MaterialGroupSearch.SendKeys(value);
            _createPRPageinstance.MaterialGroupSearchResultCatB(value).Click();
        }


        public void SelectVendor()
        {
            int size = _createPRPageinstance.VendorImage.Count;
            _createPRPageinstance.VendorImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void SearchVendor()
        {
            _createPRPageinstance.VendorSearch.SendKeys("1110107121");
            _createPRPageinstance.VendorSearchResult.Click();
        }

        public void EnterVendor(String value)
        {
            _createPRPageinstance.VendorTextBox.Click();
            _createPRPageinstance.VendorTextBox.Clear();
            _createPRPageinstance.VendorTextBox.SendKeys(value);

        }

        public void EnterExpectedValue()
        {
            WaitForMoment(0.7);
            _createPRPageinstance.ExpectedValue.Click();
            _createPRPageinstance.ExpectedValue.Clear();
            _createPRPageinstance.ExpectedValue.SendKeys("10");

            WaitForMoment(0.3);
        }

        public void UpdateExpectedValue(String value)
        {
            _createPRPageinstance.ExpectedValue.Click();
            _createPRPageinstance.ExpectedValue.Clear();
            _createPRPageinstance.ExpectedValue.SendKeys(value);

            WaitForMoment(0.3);
        }

        public void EnterOverallLimit()
        {
            _createPRPageinstance.OverallLimit.Click();
            _createPRPageinstance.OverallLimit.Clear();
            _createPRPageinstance.OverallLimit.SendKeys("100");
            WaitForMoment(0.3);
        }

        public void UpdateOverallLimit(String value)
        {
            _createPRPageinstance.OverallLimit.Click();
            _createPRPageinstance.OverallLimit.Clear();
            _createPRPageinstance.OverallLimit.SendKeys(value);
            WaitForMoment(0.3);
        }

        public void ClickAddToItemList()
        {
            _createPRPageinstance.AddToItemList.Click();
        }
        public void ClickPurchaseTypeSelection()
        {

            _createPRPageinstance.PurchaseTypeSelection.Click();
            WaitForMoment(0.3);
        }
        public void SelectPurchaseProjectType()
        {

            _createPRPageinstance.ProjectPurchaseType.Click();
            WaitForMoment(0.3);
        }

        public void SelectPurchaseCategoryJType()
        {

            _createPRPageinstance.CategoryJPurchaseType.Click();
            WaitForMoment(0.3);
        }

        public void SelectPurchaseProfitType()
        {

            _createPRPageinstance.ProfitCenterPurchaseType.Click();
            WaitForMoment(0.3);
        }
        public void EnterProfitCenter(String value)
        {

            _createPRPageinstance.ProfitCenterTextBox.Click();
            _createPRPageinstance.ProfitCenterTextBox.Clear();
            _createPRPageinstance.ProfitCenterTextBox.SendKeys(value);
            WaitForMoment(0.3);
        }


        public void SelectProject()
        {
            int size = _createPRPageinstance.ProjectTypeImage.Count;
            _createPRPageinstance.ProjectTypeImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void SearchProject(String value)
        {
            _createPRPageinstance.ProjectTypeSearch.SendKeys(value);
            _createPRPageinstance.ProjectTypeSearchResult(value).Click();
        }

        public void EnterProject(String value)
        {
            _createPRPageinstance.ProjectCodeText.Click();
            _createPRPageinstance.ProjectCodeText.SendKeys(value);
            _createPRPageinstance.GLAccountBlankClick.Click();
        }

        public void EnterProject()
        {
            _createPRPageinstance.ProjectCodeText.Click();
            _createPRPageinstance.ProjectCodeText.SendKeys("C-170803.1.A.2");
            //_createPRPageinstance.ProjectTypeSearchResult(value).Click();
        }

        public void SelectCostCenter()
        {
            int size = _createPRPageinstance.CostCenterImage.Count;
            _createPRPageinstance.CostCenterImage[size - 1].Click();
            WaitForMoment(0.3);
        }
        public void SelectMultipleCostCenterImage()
        {
            int size = _createPRPageinstance.MultipleCostCenterImage.Count;
            _createPRPageinstance.MultipleCostCenterImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void EnterCostCenterforCatJ(String value)
        {
            _createPRPageinstance.CostCenterPurchaseTypeTextBox.Click();
            //_createPRPageinstance.CostCenterPurchaseTypeTextBox.Clear();
            Actions actions = new Actions(_session);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).SendKeys(value).Build().Perform();
           // _createPRPageinstance.CostCenterPurchaseTypeTextBox.SendKeys(value);

            WaitForMoment(0.3);
        }


        public void SearchCostCenter(String value)
        {
            _createPRPageinstance.CostCenterSearch.Click();
            Actions actions = new Actions(_session);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).SendKeys(value).Build().Perform();
            //_createPRPageinstance.CostCenterSearch.SendKeys(value);
            _createPRPageinstance.CostCenterSearchResult(value).Click();
        }






        public void UpdateCostCenter(String value)
        {
            int size = _createPRPageinstance.CostCenterImage.Count;
            _createPRPageinstance.CostCenterImage[size - 1].Click();
            _createPRPageinstance.CostCenterSearch.SendKeys(value);
            _createPRPageinstance.UCostCenterSearchResult(value).Click();
        }


        public void ClickDistributionDropdown()
        {

            _createPRPageinstance.DistributionDropDownButton.Click();
            WaitForMoment(0.3);
        }

        public void SelectDistributionByPercentage()
        {

            _createPRPageinstance.DistributionByPercentageOption.Click();
            WaitForMoment(0.3);
        }

        public void SelectDistributionOnQuantity()
        {

            _createPRPageinstance.DistributionOnQuantityOption.Click();
            WaitForMoment(0.3);
        }
        public void SelectGLAccount()
        {
            int size = _createPRPageinstance.GLAccountImage.Count;
            _createPRPageinstance.GLAccountImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void SearchGLAccount()
        {
            _createPRPageinstance.GLAccountSearch.SendKeys("621500");
            _createPRPageinstance.GLAccountSearchResult.Click();
        }

        public void EnterGLAccount(String value)
        {

            _createPRPageinstance.GLAccountSingleTextBox.Click();
            _createPRPageinstance.GLAccountSingleTextBox.SendKeys(value);
            _createPRPageinstance.GLAccountBlankClick.Click();
            WaitForMoment(0.3);
        }

        public void UpdateGLAccount(String value)
        {

            _createPRPageinstance.GLAccountSingleTextBox.Click();
            _createPRPageinstance.GLAccountSingleTextBox.SendKeys(value);
            _createPRPageinstance.GLAccountBlankClick.Click();
            WaitForMoment(0.3);
        }
        public void ClickCartNext()
        {
            _createPRPageinstance.CartNext.Click();
            WaitForMoment(0.3);
        }

        public void ClickClearCart()
        {
            _createPRPageinstance.ClearCart.Click();
            WaitForMoment(0.3);
        }


        public void ClickTotalAmt()
        {
            {
                _createPRPageinstance.TotalAmt.Click();
                WaitForMoment(0.3);
            }

        }
        public void ClickCreatePR()
        {
            {
                _createPRPageinstance.CreateCartButton.Click();
                WaitForMoment(0.3);
            }

        }

        /*public void ClickCreatePR()
        {
           // int size = _createPRPageinstance.CreateCartButton.Count;
            _createPRPageinstance.CreateCartButton.Click();
            WaitForMoment(3);
        }*/

        public void EnterQuantity()
        {
            _createPRPageinstance.Quantity.Click();
            // _createPRPageinstance.Quantity.Clear();
            Actions actions = new Actions(_session);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).SendKeys("20").Build().Perform();
            // _createPRPageinstance.Quantity.SendKeys("4");
            WaitForMoment(0.3);
        }

        public void UpdateQuantity(String value)
        {

            _createPRPageinstance.Quantity.Click();
            _createPRPageinstance.Quantity.Clear();
            _createPRPageinstance.Quantity.SendKeys(value);
            WaitForMoment(0.3);
        }

        public void SearchUnitOfMeasure()
        {
            int size = _createPRPageinstance.UnitOfMeasureImage.Count;
            _createPRPageinstance.UnitOfMeasureImage[size - 1].Click();
            WaitForMoment(0.3);
        }

        public void SelectUnitOfMeasure()
        {
            _createPRPageinstance.UnitOfMeasureSearch.SendKeys("each");
            _createPRPageinstance.UnitOfMeasureSearchResult.Click();
        }

        public void EnterUnitOfMeasure()
        {
            _createPRPageinstance.UnitOfMeasureTextBox.Click();
            _createPRPageinstance.UnitOfMeasureTextBox.SendKeys("each");

        }

        public void EnterPrice()
        {
            _createPRPageinstance.Price.Click();
            _createPRPageinstance.Price.Clear();
            _createPRPageinstance.Price.SendKeys("1000");
            WaitForMoment(0.3);
        }

        public void UpdatePrice(String value)
        {
            _createPRPageinstance.Price.Click();
            _createPRPageinstance.Price.Clear();
            _createPRPageinstance.Price.SendKeys(value);
            WaitForMoment(0.3);
        }
        public void EnterUnit()
        {
            _createPRPageinstance.Unit.Click();
            _createPRPageinstance.Unit.Clear();
            _createPRPageinstance.Unit.SendKeys("2");
            WaitForMoment(0.3);
        }

        /* public void EnterPercentage(String value)
         {
             _createPRPageinstance.PercentageDetail.Click();
             _createPRPageinstance.PercentageDetail.Clear();
             _createPRPageinstance.Unit.SendKeys(value);
             WaitForMoment(0.3);
         }*/

        public void SelectMultipleCostCenter(String value)
        {
            _createPRPageinstance.MultipleCostCenterDetail(value).Click();
            WaitForMoment(0.3);
        }

        /* public void EnterMultipleGLAccount(String value)
         {

             _createPRPageinstance.GLAccountTextBox.Click();
             _createPRPageinstance.GLAccountTextBox.SendKeys(value);
             _createPRPageinstance.GLAccountBlankClick.Click();
             WaitForMoment(0.3);
         }*/


        public void FillServicePRFormWithCostCenter(String item, String location, String costcenter, String vendor,String glaccount)
        {
            ClickOnCreatePR();
            SelectServicePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            //EnterLocation(location);
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterExpectedValue();
            EnterOverallLimit();
            SelectCostCenter();
            SearchCostCenter(costcenter);
            //SelectGLAccount();
            //SearchGLAccount();
            EnterGLAccount(glaccount);

        }

        public void FillServicePRFormWithProjectCode(String item, String location, String projectcode, String vendor)
        {
            ClickOnCreatePR();
            SelectServicePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            //EnterLocation(location);
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterExpectedValue();
            EnterOverallLimit();
            ClickPurchaseTypeSelection();
            SelectPurchaseProjectType();
            SelectProject();
            SearchProject(projectcode);
            SelectGLAccount();
            SearchGLAccount();

        }


        public void FillServicePRCategoryJForm(String item, String location, String costcenter, String projectcode, String vendor, String glaccount)
        {
            ClickOnCreatePR();
            SelectServicePR();
            AutoConvertPR();
            //SelectLocation();
            //SearchLocation(location);
            EnterLocation(location);
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterExpectedValue();
            EnterOverallLimit();
            ClickPurchaseTypeSelection();
            SelectPurchaseCategoryJType();
            EnterCostCenterforCatJ(costcenter);
            EnterGLAccount(glaccount);
            EnterProject(projectcode);
            //SelectGLAccount();
            //SearchGLAccount();


        }
        public void FillProductPRFormwithCostCenter(String item, String location, String glaccount, String costcenter, String vendor)
        {
            ClickOnCreatePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            // EnterLocation(location); 
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            //EnterVendor(vendor);
            EnterQuantity();
            EnterPrice();
            EnterUnit();
            SearchUnitOfMeasure();
            SelectUnitOfMeasure();
            //EnterUnitOfMeasure();
            SelectCostCenter();
            SearchCostCenter(costcenter);
            //EnterCostCenterforCatJ(costcenter);
            //EnterGLAccount(glaccount);
           SelectGLAccount();
            SearchGLAccount();

        }
        public void FillProductPRFormwithProfitCenter(String item, String location, String glaccount, String profitcenter, String vendor)
        {
            ClickOnCreatePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            // EnterLocation(location); 
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            // EnterVendor(vendor);
            EnterQuantity();
            EnterPrice();
            EnterUnit();
            // SearchUnitOfMeasure();
            //SelectUnitOfMeasure();
            EnterUnitOfMeasure();
            ClickPurchaseTypeSelection();
            SelectPurchaseProfitType();
            EnterProfitCenter(profitcenter);
            EnterGLAccount(glaccount);
            //SelectGLAccount();
            //SearchGLAccount();

        }


        public void FillProductPRFormwithMultipleCostCenter(String item, String location, String vendor)
        {
            ClickOnCreatePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            // EnterLocation(location); 
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterQuantity();
            EnterPrice();
            EnterUnit();
            //SearchUnitOfMeasure();
            //SelectUnitOfMeasure();
            EnterUnitOfMeasure();


            ClickDistributionDropdown();

        }

        public void FillMultipleCCDistributionByPercentageDetails(String percentage, String costcenter, String glaccount)
        {
            for (int i = 0; i < 2; i++)
            {
                String[] percentagebr = percentage.Split('*');
                String[] costcenterbr = costcenter.Split('*');
                String[] glaccountbr = glaccount.Split('*');

                // EnterPercentage(percentagebr[i]);
                _createPRPageinstance.PercentageDetail[i].Click();
                _createPRPageinstance.PercentageDetail[i].Clear();
                _createPRPageinstance.PercentageDetail[i].SendKeys(percentagebr[i]);
                _createPRPageinstance.CostCenterTextBox[i].Click();
                _createPRPageinstance.CostCenterTextBox[i].Clear();
                _createPRPageinstance.CostCenterTextBox[i].SendKeys(costcenterbr[i]);
                _createPRPageinstance.GLAccountTextBox[i].Click();
                _createPRPageinstance.GLAccountTextBox[i].Clear();
                _createPRPageinstance.GLAccountTextBox[i].SendKeys(glaccountbr[i]);
                _createPRPageinstance.GLAccountBlankClick.Click();


            }

        }

        public void UpdatePercentageDetailsinMultipleCC(String updatepercentage, String updatecostcenter, String glaccount)
        {
            String[] updatepercentagebr = updatepercentage.Split('*');
            String[] updatecostcenterbr = updatecostcenter.Split('*');
            String[] glaccountbr = glaccount.Split('*');


            for (int i = 0; i < updatepercentagebr.Length; i++)
            {
                LogInfo($"Index: {i}, Value: {updatepercentagebr[i]}");




                // ClickClearEnterText(_createPRPageinstance.PercentageDetail[i], updatepercentagebr[i]);
                //ClickClearEnterText(_createPRPageinstance.PercentageDetail[i], updatepercentagebr[i]);
                //_createPRPageinstance.PercentageDetail[i].Text = String.Empty();
                //_createPRPageinstance.PercentageDetail[i].Click();

                _createPRPageinstance.GLAccountBlankClick.Click();

            }
        }
        public void UpdateQuantityDetailsinMultipleCC(String updatequantity, String updatecostcenter, String glaccount)
        {
            String[] updatequantitybr = updatequantity.Split('*');
            String[] updatecostcenterbr = updatecostcenter.Split('*');
            String[] glaccountbr = glaccount.Split('*');


            for (int i = 0; i < updatequantitybr.Length; i++)
            {
                LogInfo($"Index: {i}, Value: {updatequantitybr[i]}");



                _createPRPageinstance.QuantityDetail[i].Click();
                _createPRPageinstance.QuantityDetail[i].Clear();
                _createPRPageinstance.QuantityDetail[i].Clear();
                Actions actions = new Actions(_session);
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).SendKeys(updatequantitybr[i]).Build().Perform();

                //_session.Keyboard.PressKey(Keys.A);
                // _createPRPageinstance.PercentageDetail[i].SendKeys(ConsoleKey.A + ConsoleKey.Backspace);
                // String percent = _createPRPageinstance.PercentageDetail[i].Text;
                //String finalpercent = "−" + percent;
                //_createPRPageinstance.PercentageDetail[i].SendKeys(Int.Parse(finalpercent));
                // _createPRPageinstance.PercentageDetail[i].SendKeys(updatepercentagebr[i]);
                //_createPRPageinstance.CostCenterTextBox[i].Click();
                //_createPRPageinstance.CostCenterTextBox[i].Clear();
                //_createPRPageinstance.CostCenterTextBox[i].SendKeys(updatecostcenterbr[i]);
                //_createPRPageinstance.GLAccountTextBox[i].Click();
                //_createPRPageinstance.GLAccountTextBox[i].SendKeys(glaccountbr[i]);




                // }
                //_session.Keyboard.PressKey(Keys.A);
                // _createPRPageinstance.PercentageDetail[i].SendKeys(ConsoleKey.A + ConsoleKey.Backspace);
                // String percent = _createPRPageinstance.PercentageDetail[i].Text;
                //String finalpercent = "−" + percent;
                //_createPRPageinstance.PercentageDetail[i].SendKeys(Int.Parse(finalpercent));
                // _createPRPageinstance.PercentageDetail[i].SendKeys(updatepercentagebr[i]);
                //_createPRPageinstance.CostCenterTextBox[i].Click();
                //_createPRPageinstance.CostCenterTextBox[i].Clear();
                //_createPRPageinstance.CostCenterTextBox[i].SendKeys(updatecostcenterbr[i]);
                //_createPRPageinstance.GLAccountTextBox[i].Click();
                //_createPRPageinstance.GLAccountTextBox[i].SendKeys(glaccountbr[i]);




                // }
                _createPRPageinstance.GLAccountBlankClick.Click();

            }
        }

        public void FillMultipleCCDistributionByQuantityDetails(String quantity, String costcenter, String glaccount)
        {
            for (int i = 0; i < 2; i++)
            {
                String[] quantitybr = quantity.Split('*');
                String[] costcenterbr = costcenter.Split('*');
                String[] glaccountbr = glaccount.Split('*');

                // EnterPercentage(percentagebr[i]);
                _createPRPageinstance.QuantityDetail[i].Click();
                _createPRPageinstance.QuantityDetail[i].SendKeys(quantitybr[i]);
                _createPRPageinstance.CostCenterTextBox[i].Click();
                _createPRPageinstance.CostCenterTextBox[i].SendKeys(costcenterbr[i]);
                //int size = _createPRPageinstance.MultipleCostCenterImage.Count;
                //_createPRPageinstance.MultipleCostCenterImage[size - 1].Click();
                //SelectMultipleCostCenterImage();
                //SelectMultipleCostCenter(costcenterbr[i]);
                _createPRPageinstance.GLAccountTextBox[i].Click();
                _createPRPageinstance.GLAccountTextBox[i].SendKeys(glaccountbr[i]);
                _createPRPageinstance.GLAccountBlankClick.Click();
            }

        }



        public void FillProductPRFormwithProjectCode(String item, String location, String projectcode, String vendor)
        {
            ClickOnCreatePR();
            AutoConvertPR();
            SelectLocation();
            SearchLocation(location);
            //EnterLocation(location);
            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterQuantity();
            EnterPrice();
            EnterUnit();
            //SearchUnitOfMeasure();
            //SelectUnitOfMeasure();
            EnterUnitOfMeasure();
            ClickPurchaseTypeSelection();
            SelectPurchaseProjectType();
            SelectProject();
            SearchProject(projectcode);
            SelectGLAccount();
            SearchGLAccount();

        }

        public void FillCatBPRFormwithCostCenter(String costcenter, String vendor)
        {

            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterExpectedValue();
            EnterOverallLimit();
            SelectCostCenter();
            SearchCostCenter(costcenter);
            SelectGLAccount();
            SearchGLAccount();

        }

        public void FillCatBPRFormwithProjectCode(String vendor, String projectcode)
        {//****String projectcode

            //SelectVendor();
            //SearchVendor();
            EnterVendor(vendor);
            EnterExpectedValue();
            EnterOverallLimit();
            ClickPurchaseTypeSelection();
            SelectPurchaseProjectType();
            //SelectProject();
            // SearchProject(projectcode);
            EnterProject(projectcode);
            SelectGLAccount();
            SearchGLAccount();
            //EnterGLAccount();

        }

        public void FillForMultipleLine(String item, String vendor)
        {
            //String[] itembr = item.Split('*');

            EnterItemDescription(item);
            SelectMaterialGroup();
            SearchMaterialGroup();
            //SelectVendor();
            //SearchVendor();
            //EnterVendor(vendor);
            EnterQuantity();
            EnterPrice();
            EnterUnit();
            SearchUnitOfMeasure();
            SelectUnitOfMeasure();
            ClickDistributionDropdown();
        }

        public void ActionAfterFormFilling()
        {
            ClickAddToItemList();
            ClickCartNext();
            ClickTotalAmt();
            ClickCreatePR();
            ClickOnApproverCmtSubmitButton();
            ClickOnFinalOK();
        }
        public void ActionAfterFormFillingwithAttachment()
        {
            ClickAddToItemList();
            ClickCartNext();
            ClickOnAddAttachment();
            EnterFileName();
            ClickOpenFile();
            ClickTotalAmt();
            ClickCreatePR();
            ClickOnApproverCmtSubmitButton();
            ClickOnFinalOK();
        }

        public void ActionAfterFormFillingwithMultipleAttachments(String filenames)
        {
            ClickAddToItemList();
            ClickCartNext();
            ClickOnAddAttachment();
            EnterMultipleFileNames(filenames);
            ClickOpenFile();
            ClickTotalAmt();
            ClickCreatePR();
            ClickOnApproverCmtSubmitButton();
            ClickOnFinalOK();
        }

        public void ClickOnAddAttachment()
        {
            _createPRPageinstance.AddAttachmentButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnSecondAddAttachment()
        {
            _createPRPageinstance.SecondAddAttachmentButton.Click();
            WaitForMoment(0.3);
        }

        public void EnterFileName()
        {
            _createPRPageinstance.FileName.Click();
            _createPRPageinstance.FileName.SendKeys("C:\\Users\\parigis\\source\\repos\\EnterpriseUX.Automation\\West.EnterpriseUX.Automation\\West.EnterpriseUX.Automation.UWP\\TestData\\DVV\\DOA NEW.xlsx");
            _createPRPageinstance.FileNameText.Click();
            WaitForMoment(0.3);
        }

        public void EnterMultipleFileNames(String value)
        {
            _createPRPageinstance.FileName.Click();
            _createPRPageinstance.FileName.SendKeys(value);
            _createPRPageinstance.FileNameText.Click();
            WaitForMoment(0.3);
        }

        public void ClickOpenFile()
        {
            _createPRPageinstance.FileOpenButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnCartDeleteButton()
        {
            int size = _createPRPageinstance.CartDeleteButton.Count;
            _createPRPageinstance.CartDeleteButton[size - 1].Click();
            WaitForMoment(0.3);
        }
        public void ClickOnCartEditButton()
        {
            int size = _createPRPageinstance.CartEditButton.Count;
            _createPRPageinstance.CartEditButton[size - 2].Click();
            WaitForMoment(0.3);
        }
        public void ClickOnCartMultipleEditButton(String value)
        {
            int size = _createPRPageinstance.CartMultipleLineEditButton(value).Count;
            _createPRPageinstance.CartMultipleLineEditButton(value)[size - 2].Click();
            WaitForMoment(0.3);
        }

        public void ClickOnCartEditButtonForUpdatedItem(String value)
        {
            int size = _createPRPageinstance.UCartEditButton(value).Count;
            _createPRPageinstance.UCartEditButton(value)[size - 2].Click();
            WaitForMoment(0.3);
        }

        public void ClickOnUpdateButton()
        {

            _createPRPageinstance.UpdateItemButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnCancelButton()
        {

            _createPRPageinstance.CancelButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnClearCartCancelButton()
        {

            _createPRPageinstance.ClearCartCancelButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnClearCartOKButton()
        {

            _createPRPageinstance.ClearCartOKButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnCartOkButton()
        {

            _createPRPageinstance.OkCartButton.Click();
            WaitForMoment(0.3);
        }

        public void ClickOnApproverCmtSubmitButton()
        {

            _createPRPageinstance.ApproverCommentSubmitButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnFinalOK()
        {

            _createPRPageinstance.FinalOK.Click();
            WaitForMoment(0.3);
        }

        public void ClickSaveAsTemplate()
        {

            _createPRPageinstance.SaveAsTemplateButton.Click();
            WaitForMoment(0.3);
        }
        public void EnterTemplateName()
        {

            _createPRPageinstance.TemplateName.SendKeys("Template 1z");
            WaitForMoment(0.3);
        }

        public void SaveTemplateFinal()
        {

            _createPRPageinstance.TemplateSaveButton.Click();
            WaitForMoment(0.10);
        }
        public void ClickCatBMaterialChkCancel()
        {

            _createPRPageinstance.CatBMaterialChkCancelButton.Click();
            WaitForMoment(0.3);
        }

        public void EnterCatBMaterialGroup(String catbmaterialgrpid)
        {
            String[] catbmaterialgrpidbr = catbmaterialgrpid.Split('*');
            //bool catboption = _createPRPageinstance.CategoryBRadio("NO").

            for (int i = 0; i < catbmaterialgrpidbr.Length; i++)
            {

                if (_createPRPageinstance.CategoryBRadio("NO").Selected == true)
                {
                    SelectMaterialGroup();
                    SearchMaterialGroupForCatB(catbmaterialgrpidbr[i]);
                    ClickCatBMaterialChkCancel();
                    continue;
                }
                else
                {

                    SelectMaterialGroup();
                    SearchMaterialGroupForCatB(catbmaterialgrpidbr[i]);
                    EnterExpectedValue();

                }

            }

        }

        public void VerifyFormDetailsAfterCancelReset(String fulllocation,String fullcostcenter,String fullglaccount)
        {


            String verlocation = _createPRPageinstance.LocationTextBox.Text;
            LogInfo(verlocation);
            Assert.AreEqual(fulllocation, verlocation);

            _createPRPageinstance.CostCenterSingleTextBox.Click();
            String vercostcenter = _createPRPageinstance.CostCenterSingleTextBox.Text;
            LogInfo(vercostcenter);
            Assert.AreEqual(fullcostcenter, vercostcenter);

            _createPRPageinstance.GLAccountSingleTextBox.Click();
            String verglaccount = _createPRPageinstance.GLAccountSingleTextBox.Text;
            LogInfo(verglaccount);
            Assert.AreEqual(fullglaccount, verglaccount);

           
           //_createPRPageinstance.ItemDescription.Click();
            //String veritemdesc = _createPRPageinstance.ItemDescription.Text;
            //LogInfo(veritemdesc);
            // Assert.IsNull(veritemdesc);

            String dummy = String.Empty;

            _createPRPageinstance.ItemDescription.Click();
            String veritemdesc = _createPRPageinstance.ItemDescription.Text;
            Assert.AreEqual(dummy, veritemdesc);

        }

        public void VerifyFormDetailsAfterOKReset(String fulllocation, String fullcostcenter, String fullglaccount)
        {


            String dummy = String.Empty;

            String verlocation = _createPRPageinstance.LocationTextBox.Text;
            LogInfo(verlocation);
            Assert.AreEqual(dummy, verlocation);

            _createPRPageinstance.CostCenterSingleTextBox.Click();
            String vercostcenter = _createPRPageinstance.CostCenterSingleTextBox.Text;
            LogInfo(vercostcenter);
            Assert.AreEqual(dummy, vercostcenter);

            _createPRPageinstance.GLAccountSingleTextBox.Click();
            String verglaccount = _createPRPageinstance.GLAccountSingleTextBox.Text;
            LogInfo(verglaccount);
            Assert.AreEqual(dummy, verglaccount);


            _createPRPageinstance.ItemDescription.Click();
             String veritemdesc = _createPRPageinstance.ItemDescription.Text; 
            Assert.AreEqual(dummy,veritemdesc);


        }

    }
}

