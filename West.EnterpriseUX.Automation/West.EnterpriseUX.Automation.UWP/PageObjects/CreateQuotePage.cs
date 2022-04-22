using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CreateQuotePage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CreateQuotePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        //public WindowsElement CreateQuoteElement => FindElement("Name:Create Quote");
        public WindowsElement CreateQuote => FindElement("XPath:.//*[contains(@Name,'Create Quote')]");
        public WindowsElement SoldtoPicker => FindElement("AccessibilityId:SoldToTextBox");
        public WindowsElement SoldToElement => FindElement("Name:Select Sold To");

        public WindowsElement SoldToSearch => FindElement("XPath://*[@Name='Pop-up']//*[@Name=' Input Field']");
        //FindElement("XPath://*[contains(@Name,'Search by Customer ID')]/preceding-sibling::Edit");
        public WindowsElement ConfigureProductSegment => FindElement("Name:Configure Product");
        //public WindowsElement SearchByCatergoryId => FindElement("Name:Search By Category");
        public WindowsElement SoldtoItem(string soldToDetails)
        {
            return FindElement("Name:" + soldToDetails);
        }
        public WindowsElement SearchByMaterialId => FindElement("XPath://*[@AutomationId='MultiPanelScrollViewer']//*[@AutomationId='ContentElement']");
        public IList<WindowsElement> SearchArrowButton => FindElements("XPath://*[@Name=' Input Field']/following-sibling::Custom//Image");
        public WindowsElement SearchTextboxInPicker => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SearchByMaterialIdListPicker(string searchedMId)
        {
            return FindElement("XPath://Text[contains(@Name,'" + searchedMId + "')]");
        }
        public WindowsElement SubmitInPicker => FindElement("XPath://Button[@Name='Submit']");
        public IList<WindowsElement> tockenClose => FindElements("XPath://*[contains(@Name,'Token Close')]");
        
        public IList<WindowsElement> SearchByMaterialIdList(string searchedMId)
        {
            return FindElements("XPath://*[@Name='"+searchedMId+ "' and @ClassName='ListBoxItem']");
        }

        public IList<WindowsElement> dropdownButton => FindElements("XPath://*[contains(@Name,'Dropdown') or contains(@AutomationId,'Dropdown Button')]");

        public WindowsElement SearchedMaterialId(string searchedMId)
        {
            return FindElement("XPath://*[@Name=' Input Field']/Pane/Text[contains(@Name,'" + searchedMId + "')]");
        }
        public WindowsElement SearchIcon => FindElement("XPath://*[@Name=' Input Field']/ancestor::Custom/Image[@AutomationId='SearchImage' or @ClassName='Image']");


        //search product by category

        public WindowsElement ProductLine(string productLine)
        {
            return FindElement("Name:" + productLine);
        }

        public WindowsElement FlurotecCoating(string flurotecCoating)
        {
            return FindElement("Name:" + flurotecCoating);
        }
        public WindowsElement Configuration(string configuration)
        {
            return FindElement("Name:" + configuration);
        }
        public WindowsElement FinishingLevel(string finishingLevel)
        {
            return FindElement("Name:" + finishingLevel);
        }
        public WindowsElement ProductsFoundLbl => FindElement("XPath:.//*[contains(@Name,'products found')]|//*[contains(@Name,'product found')]");
        public WindowsElement Proceedbtn => FindElement("XPath://Button[@Name='Proceed']");
        public WindowsElement Resetbtn => FindElement("XPath://Button[@Name='Reset']");
        public WindowsElement CustomerPricing => FindElement("AccessibilityId:CustomerMaterialPricing_Container");
        public WindowsElement CustomerPricingHeader => FindElement("XPath://*[contains(@Name,'Customer Material List')]");
    }
}
