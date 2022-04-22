using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ConfigureProductsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ConfigureProductsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CurrencyPicker => FindElement("XPath:.//ComboBox[contains(@AutomationId,'CurrencyPicker')]");
        public WindowsElement CurrencyPickerSelected => FindElement("XPath:.//ComboBox[contains(@AutomationId,'CurrencyPicker')]//Text");
        public IList<WindowsElement> CurrencyPickerlist(string currency)
        {
            return FindElements("XPath://ComboBox[@AutomationId='CurrencyPicker']/ListItem[@Name='" + currency + "'][@ClassName='ComboBoxItem']");
        }
        public IList<WindowsElement> CurrencyPickerlist()
        {
            return FindElements("XPath://ComboBox[@AutomationId='CurrencyPicker']/ListItem[contains(@Name,'(')]");
        }
        public WindowsElement ExchangeRateEntry => FindElement("AccessibilityId:ExchangeRateEntry");
        public WindowsElement IncotermPicker => FindElement("XPath:.//ComboBox[contains(@AutomationId,'intercomPicker')]");
        public WindowsElement IncotermPickerSelected => FindElement("XPath:.//ComboBox[contains(@AutomationId,'intercomPicker')]//Text");
        public IList<WindowsElement> IncotermPickerlist(string incoterm)
        {
            return FindElements("XPath://*[contains(@Name,'" + incoterm + "')]");
        }
        public WindowsElement AnnualSalesForecast => FindElement("XPath://Custom[@AutomationId='AnnualSalesForecast']//Edit[@ClassName='TextBox']");

        public WindowsElement TargetPrice => FindElement("XPath://Text[@AutomationId='TargetPrice']");
        public WindowsElement StandardPrice => FindElement("XPath:Text[@AutomationId='StandardPrice']");

        public WindowsElement Quanitity => FindElement("XPath://*[contains(@AutomationId,'ProductQuantityEntry')]//*[contains(@Name,'Input Field')]");

        public WindowsElement ProductPrice => FindElement("XPath://Custom[@AutomationId='ProductPriceEntry']//*[contains(@Name,'Input Field')]");
      
        public WindowsElement ProductAnnualSalesForecast => FindElement("XPath://Custom[@AutomationId='ProductAnnualSalesForecastAmountEntry']//Edit[contains(@AutomationId,'Input Field')]");
        public WindowsElement ApprovalsRequiredLbl => FindElement("Name:Approvals Required");

        //search product by category Minimum order quantity
        public WindowsElement MinimumOrderQuantityLbl => FindElement("XPath://*[contains(@Name,'Min Order Quantity') or contains(@Name,'MOQ')]");
        public WindowsElement MinimumOrderQuantityLbVal => FindElement("XPath://*[contains(@AutomationId,'MinorderQuantity')]");
        
        public WindowsElement AddToQuoteBtn => FindElement("XPath://Button[@Name='Add To Quote']");
        public WindowsElement PopupCloseeBtn => FindElement("XPath://*[@Name='Approval List']/..//Image[@AutomationId='CloseButton']");
        public WindowsElement UpdateQuoteBtn => FindElement("XPath://Button[@Name='Update Quote']");
        public WindowsElement AddProductsBtn => FindElement("XPath://Button[contains(@Name, 'Add Products')]");
        public WindowsElement Resetbtn => FindElement("XPath://Button[@Name='Reset']");
        public WindowsElement ViewQuoteListbtn => FindElement("XPath://Button[@Name='View Quote List']");
        public WindowsElement QuoteListLbl => FindElement("XPath://Text[@Name='Quote List']");
        public WindowsElement QLMaterialID(string materialID)
        {
            return FindElement("XPath://*[contains(@Name,'" + materialID + "')]");
        }
        public WindowsElement GlobalMaterialID => FindElement("XPath://Text[contains(@AutomationId, 'GlobalMaterialId')]");
        public WindowsElement QLPricePerProduct => FindElement("AccessibilityId:PricePerProduct");
        public WindowsElement QLQuantity => FindElement("XPath://*[contains(@AutomationId, 'QuantityText')]");
        public WindowsElement QLEditProduct => FindElement("AccessibilityId:EditCartButton");
        public WindowsElement QLDeleteProduct => FindElement("AccessibilityId:DeleteButton");
        public WindowsElement TotalAmt => FindElement("XPath://*[contains(@Name,'Total Amount')]/following-sibling::*");
        public WindowsElement SaveAsDraftbtn => FindElement("XPath://Button[@Name='Save as Draft']");
        public WindowsElement Proceedbtn => FindElement("XPath://Button[@AutomationId='ProceedFromCartButton' or @Name='Proceed']");

        //Approval required pop up
        public WindowsElement ApprovalListPopUpHeader => FindElement("XPath://Window[@Name='Pop-up']//*[contains(@Name,'Approval List')]");
        public WindowsElement Approverslink => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='Approvers']");
        public WindowsElement Notifierslink => FindElement("XPath://Window[@Name='Pop-up']//*[@AutomationId='Notifiers']");
        public IList<WindowsElement> ApproverNames => FindElements("XPath://Window[@Name='Pop-up']//Text[@AutomationId='ApproverName']");
        public IList<WindowsElement> DesignationNames => FindElements("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName']");
        public WindowsElement AccountManagerApproval => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Account Manager']");
        public WindowsElement SalesDirectorApproval => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Sales Director']");
        public WindowsElement ProductDirectorApproval => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Product Director']");
        public WindowsElement ProductDirectorNotification => FindElement("XPath:(//Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Product Director'])[2]");
        public WindowsElement MUVPApproval => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='MU VP']");
        public WindowsElement PopupDown => FindElement("XPath://Window[@Name='Pop-up']//*[@Name='Vertical Small Increase']");
        public WindowsElement ScrollBar => FindElement("XPath://Window[@Name='Pop-up']//*[@Name='Vertical']");
        public WindowsElement PricingManagerNotification => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Pricing Manager']");
        public WindowsElement PortfolioStrategyNotification => FindElement("XPath://Window[@Name='Pop-up']//Text[@AutomationId='DesignationName'][@Name='Portfolio Strategy']");
        public IList<WindowsElement> ApprovalReasons => FindElements("AccessibilityId:RuleDescription");
        public WindowsElement ApprovalListPopUpCloseIcon => FindElement("XPath://Window[@Name='Pop-up']//*[@AutomationId ='CloseButton']");
        public WindowsElement ApprovalListPopUpCloseIcon1 => FindElement("XPath://Window[@Name='Pop-up']//*[contains(@Name,'Approval List')]/ancestor::Custom/Custom");
        //Save as draft pop up
        public WindowsElement ConfirmationPopUpHdr => FindElement("XPath://Text[@AutomationId='dialogTitle'][@Name='Confirmation']");
        public WindowsElement PopUpYesBtn => FindElement("AccessibilityId:okButton");
        public WindowsElement PopUpNoBtn => FindElement("AccessibilityId:cancelButton");
    }
}
