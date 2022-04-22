using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CreatePRPage : BasePage


    {
        protected WindowsDriver<WindowsElement> _session;

        public CreatePRPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        //*****************************Create Purchase Requisition Home Windows Elements*****************************
        public WindowsElement CreatePRHomeButton => FindElement($"XPath://Text[contains(@Name,'Create Purchase Requisitions')]");

        public IList<WindowsElement> ActionsHomeButton(string rowname)

        { return FindElements($"XPath://Group[contains(@Name,'{rowname}')]/Group[@Name='Detail Action']/Custom/Custom/Image"); }

        //public IList<WindowsElement> ItemDetailSelection => FindElements($"XPath://Text[@Name='Detail Action']");

        public WindowsElement EditRequisition => FindElement($"XPath://Text[contains(@Name,'Edit Requisition')]");

        public WindowsElement CopyandCreateRequisition => FindElement($"XPath://Text[contains(@Name,'Copy and Create Requisition')]");

        //*****************************Create Purchase Requisition Page Windows Elements ***********************

        public WindowsElement ServiceRequstRadio(string RadioValue)
        {
            return FindElement($"XPath://Text[@Name='Is this a request for service?']/../following-sibling::Custom/RadioButton[@Name='{RadioValue}']");
        }
        public WindowsElement ConvertPRtoPORadio(string RadioValue)
        {
            return FindElement($"XPath://Text[@Name='Auto convert PR Item  to PO?']/../following-sibling::Custom/RadioButton[@Name='{RadioValue}']");
        }
        public WindowsElement CategoryBRadio(string RadioValue)
        {
            return FindElement($"XPath://Text[@Name='Is this a Blanket Utilities Requisition?']/../following-sibling::Custom/RadioButton[@Name='{RadioValue}']");
        }

        public IList<WindowsElement> ListImage => FindElements($"XPath://Text[@Name='Location']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");

        /*public WindowsElement LocationTextBox(string location)
        { return FindElement($"XPath://Text[@Name='Location']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit"); }
        */
        public WindowsElement LocationTextBox => FindElement($"XPath://Text[@Name='Location']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement LocationSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");
        public WindowsElement LocationSearchResult(string location)

        { return FindElement($"XPath://Text[contains(@Name,'{location}')]"); }
        public WindowsElement ItemDescription => FindElement($"XPath://Edit[contains(@Name,'Enter item description')]");
        public IList<WindowsElement> MaterialGroupImage => FindElements($"XPath://Text[@Name='Material Group']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement MaterialGroupSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");
        public WindowsElement MaterialGroupSearchResult => FindElement($"XPath://Text[contains(@Name,'Metal Components')]");

        public WindowsElement updateMaterialGroupSearchResult(string updatematerialgroup) 
        
        { return FindElement($"XPath://Text[contains(@Name,'{updatematerialgroup}')]");}

        //public WindowsElement MaterialGroupSearchResultCatB => FindElement($"XPath://Text[contains(@Name,'3610')]");

        public WindowsElement MaterialGroupSearchResultCatB(string catbmaterialgrpid)

        { return FindElement($"XPath://Text[contains(@Name,'{catbmaterialgrpid}')]"); }
        public IList<WindowsElement> VendorImage => FindElements($"XPath://Text[@Name='Vendor']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Custom/Image");

        public WindowsElement VendorSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");
        public WindowsElement VendorSearchResult => FindElement($"XPath://Text[contains(@Name,'1110107121')]");

        public WindowsElement VendorTextBox => FindElement($"XPath://Text[@Name='Vendor']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Edit");


        public WindowsElement ExpectedValue => FindElement($"XPath://Text[@Name='Expected value']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Edit/Pane");
        public WindowsElement OverallLimit => FindElement($"XPath://Text[@Name='Overall Limit']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Edit/Pane");

        public WindowsElement PurchaseTypeSelection => FindElement($"XPath://Text[@Name='Select your Purchase type']/../parent::Custom/parent::Custom/following-sibling::Custom/Edit/Button/Image");
        public WindowsElement ProjectPurchaseType => FindElement($"XPath://Text[contains(@Name,'Project (P)')]");

        public WindowsElement ProfitCenterPurchaseType => FindElement($"XPath://Text[contains(@Name,'Profit Center (V)')]");

        //  public WindowsElement CategoryJPurchaseType => FindElement($"XPath://Text[contains(@Name,'Cost Center and Project (J)')]");

        public WindowsElement CategoryJPurchaseType => FindElement("AccessibilityId:Cost Center and Project (J)");



        public WindowsElement ProfitCenterTextBox => FindElement($"XPath://Text[@Name='Profit Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Edit");

        public IList<WindowsElement> CostCenterImage => FindElements($"XPath://Text[@Name='Cost Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Custom/Image");

        public WindowsElement CostCenterPurchaseTypeTextBox => FindElement($"XPath://Text[@Name='Cost Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");

        public IList<WindowsElement> MultipleCostCenterImage => FindElements($"XPath://Text[@Name='Cost Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement CostCenterSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");

        public WindowsElement CostCenterSearchResult(string costcenter)
        {
            return FindElement($"XPath://Text[contains(@Name,'{costcenter}')]");
        }

        public WindowsElement UCostCenterSearchResult(string updatecostcenter)
        {
            return FindElement($"XPath://Text[contains(@Name,'{updatecostcenter}')]");
        }

        public IList<WindowsElement> ProjectTypeImage => FindElements($"XPath://Text[@Name='Project Code']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");

        public WindowsElement ProjectCodeText => FindElement($"XPath://Text[@Name='Project Code']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement ProjectTypeSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");
        //change Project Code **
        public WindowsElement ProjectTypeSearchResult(string projectcode)
        { return FindElement($"XPath://Text[contains(@Name,'{projectcode}')]"); }

        //public WindowsElement ProjectTypeSearchResult => FindElement($"XPath://Text[contains(@Name,'C-180654.1.2')]");

        public IList<WindowsElement> GLAccountImage => FindElements($"XPath://Text[@Name='G/L Account']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");

        public WindowsElement GLAccountSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");

        public WindowsElement GLAccountSearchResult => FindElement($"XPath://Text[contains(@Name,'621500')]");
        public IList<WindowsElement> GLAccountTextBox => FindElements($"XPath://Text[@Name='G/L Account']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement GLAccountSingleTextBox => FindElement($"XPath://Text[@Name='G/L Account']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");

        //public WindowsElement GLAccountBlankClick => FindElement($"XPath://Text[contains(@Name,'G/L Account')]");

        public WindowsElement GLAccountBlankClick => FindElement($"XPath://Text[contains(@Name,'G/L Account')]");

        // public WindowsElement GLAccountBlankClick => FindElement($"XPath://Text[contains(@Name,'G/L Account')]");

        public WindowsElement AddToItemList => FindElement($"XPath://Button[contains(@Name,'Add to Item List')]");

        public WindowsElement CartNext => FindElement($"XPath://Button[contains(@Name,'Next')]");

        public WindowsElement ClearCart => FindElement($"XPath://Button[contains(@Name,'Clear cart')]");

       

        public WindowsElement TotalAmt => FindElement($"XPath://Text[contains(@Name,'Total Price')]");
        public WindowsElement CreateCartButton => FindElement("AccessibilityId:createPrSubmitButton");
        //public WindowsElement CreateCartButton => FindElement($"XPath://Button[contains(@Name,'Create')]");
        public WindowsElement Quantity => FindElement($"XPath://Text[@Name='Quantity']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Edit/Pane");

        // public WindowsElement Quantity => FindElement($"XPath://Text[@Name='Quantity']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Pane");

        public WindowsElement UnitOfMeasureTextBox => FindElement($"XPath://Text[@Name='Quantity']/../parent::Custom/parent::Custom/following-sibling::Custom/Text");

        public IList<WindowsElement> UnitOfMeasureImage => FindElements($"XPath://Text[@Name='Quantity']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Custom/Image");
        public WindowsElement UnitOfMeasureSearch => FindElement($"XPath://Edit[contains(@Name,'Search')]");
        public WindowsElement UnitOfMeasureSearchResult => FindElement($"XPath://Text[contains(@Name,'each')]");

        public WindowsElement Price => FindElement($"XPath://Text[@Name='Price']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Edit/Pane");
        //public WindowsElement Price => FindElement($"XPath://Text[@Name='Price']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Pane");

        public WindowsElement Unit => FindElement($"XPath://Text[@Name='Unit']/../parent::Custom/parent::Custom/following-sibling::Custom/Edit/Pane");
        //public WindowsElement Unit => FindElement($"XPath://Text[@Name='Unit']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Pane");

        public WindowsElement AddAttachmentButton => FindElement($"XPath://Button[contains(@Name,'+  Add Attachment')]");
        public WindowsElement SecondAddAttachmentButton => FindElement($"XPath://Text[contains(@Name,'+  Add Attachment')]");
        public WindowsElement FileName => FindElement($"XPath://Edit[contains(@Name,'File name')]");

        public WindowsElement FileNameText => FindElement($"XPath://Text[contains(@Name,'File name')]");
        public WindowsElement FileOpenButton => FindElement("AccessibilityId:1");

        //public IList<WindowsElement> CartDeleteButton => FindElements($"XPath://Text[@Name='Mobile Phones']/following-sibling::Custom/Image");

        public IList<WindowsElement> CartDeleteButton => FindElements($"XPath://Text[@Name='Vendor']/preceding-sibling::Custom/Custom/Image");

        public IList<WindowsElement> CartEditButton => FindElements($"XPath://Text[@Name='Vendor']/preceding-sibling::Custom/Custom/Image");

        public IList<WindowsElement> CartMultipleLineEditButton(string itemdesc)

        { return FindElements($"XPath://Text[@Name='{itemdesc}']/following-sibling::Custom/Image"); }

        /* public  IList<WindowsElement> CartMultipleLineEditButton(string editbuttonnum)

         {return FindElements($"XPath://Custom[@AutomationId='{editbuttonnum}']/Custom/Custom/Image");}*/
        public IList<WindowsElement> UCartEditButton(string updateitemdesc)
        {
            return FindElements($"XPath://Text[@Name='{updateitemdesc}']/following-sibling::Custom/Image");
        }
        /* public IList<WindowsElement> CartEditButton(string itemdesc)
         {
             return FindElements($"XPath://Text[@Name='{itemdesc}']/following-sibling::Custom/Image");
         }*/
        /* public IList<WindowsElement> CartDeleteButton(string itemdesc)
         {
             return FindElements($"XPath://Text[@Name='{itemdesc}']/following-sibling::Custom/Image");
         }*/
        public WindowsElement OkCartButton => FindElement("AccessibilityId:okButton");

        public WindowsElement UpdateItemButton => FindElement($"XPath://Button[contains(@Name,'Update')]");

        public WindowsElement CancelButton => FindElement($"XPath://Button[contains(@Name,'Cancel')]");
        public WindowsElement ClearCartCancelButton => FindElement("AccessibilityId:cancelButton");

        public WindowsElement ClearCartOKButton => FindElement("AccessibilityId:okButton");
      
        public WindowsElement CatBMaterialChkCancelButton => FindElement("AccessibilityId:cancelButton");
        public WindowsElement ApproverCommentSubmitButton => FindElement("AccessibilityId:approverCommentSubmitButton");

        public WindowsElement FinalOK => FindElement("AccessibilityId:okButton");

        public WindowsElement SaveAsTemplateButton => FindElement($"XPath://Button[contains(@Name,'Save as template')]");
        public WindowsElement TemplateName => FindElement($"XPath://Text[@Name='Template Name']/following-sibling::Edit");
        public WindowsElement TemplateSaveButton => FindElement($"XPath://Button[contains(@Name,'SAVE')]");

        public WindowsElement DistributionDropDownButton => FindElement($"XPath://Text[@Name='Distribution']/../parent::Custom/parent::Custom/following-sibling::Custom/Edit/Button/Image");
        public WindowsElement DistributionByPercentageOption => FindElement($"XPath://Text[contains(@Name,'Distribution by Percentage')]");
        public WindowsElement DistributionOnQuantityOption => FindElement($"XPath://Text[contains(@Name,'Distribution on Quantity Basis')]");

        public IList<WindowsElement> PercentageDetail => FindElements($"XPath://Text[@Name='Percentage']/../parent::Custom/parent::Custom/following-sibling::Custom/Edit/Pane");

        public IList<WindowsElement> QuantityDetail => FindElements($"XPath://Text[@Name='Quantity']/../parent::Custom/parent::Custom/following-sibling::Custom/Edit/Pane");
        public IList<WindowsElement> CostCenterTextBox => FindElements($"XPath://Text[@Name='Cost Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");

        public WindowsElement CostCenterSingleTextBox => FindElement($"XPath://Text[@Name='Cost Center']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Edit");

        public WindowsElement MultipleCostCenterDetail(string mcccode)
        { return FindElement($"XPath://Text[contains(@Name,'{mcccode}')]"); }


        // public IList<WindowsElement> GLAccountTextBox => FindElements($"XPath://Text[@Name='G/L Account']/../parent::Custom/parent::Custom/following-sibling::Custom/Custom/Custom/Edit");
        public WindowsElement MultipleCCGLAccount(string mccglcode)
        { return FindElement($"XPath://Text[contains(@Name,'{mccglcode}')]"); }

        //public WindowsElement MultipleCostCenterDetail => FindElement($"XPath://Text[contains(@Name,'Distribution by Percentage')]");

        public WindowsElement ADDDistributionButton => FindElement("AccessibilityId:addDistributionForMultipleCostCenterButton");

        // public IList<WindowsElement>> EditButtonMultipleItem => (IList<WindowsElement>)VendorReferenceforEdit.FindElements($"XPath://Text[@Name='Vendor']/preceding-sibling::Custom/Custom/Image");

        //public IList<WindowsElement> VendorReferenceforEdit => FindElements($"XPath://Text[@Name='Items List']/following-sibling::Custom/Custom/Custom/Custom/Custom/Custom/Pane/Custom/Custom/Custom/Text[@Name='Vendor']");

        //public IList<IList<WindowsElement>> EditImageListSelection => VendorReferenceforEdit.

        // public IList<WindowsElement> CartEditButton => FindElements($"XPath:(//Text[@Name='Vendor']/preceding-sibling::Custom/Custom/Image)[2]");





    }
}

