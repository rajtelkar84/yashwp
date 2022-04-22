using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
   public class LabelPrintingPage: BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public LabelPrintingPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> GetPageTitle => FindElements("AccessibilityId:PageTitleLabel");
        public WindowsElement WeighmentOrderField => FindElement("XPath://*[@AutomationId='OrderNumber Input Field' and @Name='OrderNumber Input Field']");
        public WindowsElement PrinterSearchField => FindElement("XPath://*[@AutomationId='PrinterSearch Input Field' and @Name='PrinterSearch Input Field']");
        public IList<WindowsElement> OrderField => FindElements("XPath://*[@ClassName='TextBox' and @AutomationId ='OrderNuber Input Field']");
        public WindowsElement MaterialField => FindElement("XPath://*[@AutomationId='MaterialNumber']");
        public WindowsElement NoOfLabelField => FindElement("XPath://*[@Name=' Input Field']");
        public WindowsElement WorkCenterInputField => FindElement("XPath://*[@ClassName='TextBox' and @AutomationId='WorkCenter Input Field']");
        public WindowsElement WorkCenterDropdown => FindElement("XPath://*[@ClassName='Button' and @AutomationId='WorkCenter Dropdown Button']");
        public WindowsElement BatchDropdown => FindElement("XPath://*[@ClassName='Button' and @AutomationId='Batch Dropdown Button']");
        public WindowsElement PrinterDropdown => FindElement("XPath://*[@ClassName='Button' and @AutomationId='PrinterSearchText Dropdown Button']");
        public WindowsElement SuccessPopUpOK => FindElement("XPath://*[@ClassName='Button' and @AutomationId='okButton']");
        public IList<WindowsElement> PrintPriewButton()
        {
            return FindElements($"XPath://*[contains(@Name,'Print Preview')]");
        }
        public IList<WindowsElement> PrintButton()
        {
            return FindElements($"XPath://*[(@AutomationId='PrintBtn')]");
        }
        public IList<WindowsElement> NextPageBtn => FindElements("XPath://*[@AutomationId='NextPageBtn']");
        public IList <WindowsElement> PreviousPageBtn => FindElements("XPath://*[@AutomationId='PreviousPageBtn']");
        public IList <WindowsElement> ZoomInBtn => FindElements("XPath://*[@AutomationId='ZoomInBtn']");
        public IList <WindowsElement> ZoomOutBtn => FindElements("XPath://*[@AutomationId='ZoomOutBtn']");
        public IList<WindowsElement> PopUp()
        {
            return FindElements($"XPath://*[contains(@Name,'Label printed Succesfully')]");
        }
        public IList<WindowsElement> ErrorPopUp()
        {
            return FindElements($"XPath://*[contains(@ClassName,'TextBlock')]");
        }
        public IList<WindowsElement> ErrorField(string value)
        {
            return FindElements($"XPath://*[contains(@Name,'{value}')]");
        }
        public IList<WindowsElement> LabelPrintingOptions => FindElements($"XPath://Custom//*[@ClassName='TextBlock']");
        public IList<WindowsElement> LabelOption(string Label)
        {
            return FindElements($"XPath://Custom//*[@ClassName='RadioButton' and @Name='{Label}']");          
        }     
        public IList<WindowsElement> ScrollUp()
        {
            return FindElements($"XPath://*[@AutomationId='VerticalSmallDecrease']");
        }
        public IList<WindowsElement> ScrollDown()
        {
            return FindElements($"XPath://Custom//*[@ClassName='RepeatButton' and @AutomationId='VerticalSmallIncrease']");           
        }
        public IList<WindowsElement> ClickDetails()
        {
            return FindElements($"XPath://*[@AutomationId='More']");
        }
        public IList<WindowsElement> OrderNumberPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> ReasonForVarianceUWP_Container()
        {
            return FindElements("XPath:.//*[contains(@ClassName,'ScrollViewer')]//*[contains(@ClassName,'Image')]");
        }
   }
}


