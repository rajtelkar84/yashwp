using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class TimeConfirmationPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public TimeConfirmationPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement OrderNumberField => FindElement("XPath://*[@AutomationId='OrderNumber Input Field' and @Name='OrderNumber Input Field']");
        public WindowsElement OperationNumberField => FindElement("XPath://*[@AutomationId='OperationNumber Input Field' and @Name='OperationNumber Input Field']");
        public IList<WindowsElement> RecentConfirmationButton()
        {
            return FindElements($"XPath://*[(@AutomationId='RecentConfirmationsBtn')]");
        }
        public IList<WindowsElement> NextButton()
        {
            return FindElements($"XPath://*[(@AutomationId='InputPageBtn')]");
        }
        public IList<WindowsElement> RecentConfirmation()
        {
            return FindElements($"XPath://*[(@AutomationId='RecentConfirmationsBtn')]");
        }
        public IList<WindowsElement> GetText => FindElements($"XPath://Custom//*[@ClassName='TextBlock']");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> GetConfirmationDate(string Row)
        {
            return FindElements($"XPath://*[@Name='{Row}']/child::*");
        }
        public IList<WindowsElement> TextBox()
        {
            return FindElements($"XPath://*[@ClassName='TextBox']");
        } 
        public IList<WindowsElement> MultiScan()
        {
            return FindElements($"XPath://*[@ClassName='Image']");
        }
        public IList<WindowsElement> BatchTextBox()
        {
          return FindElements($"XPath://*[@AutomationId='Batch Input Field' and @Name='Batch Input Field']");        
        }
        public IList<WindowsElement> BatchTextBoxEdit()
        {
            return FindElements($"XPath://*[@AutomationId='BatchUWP Input Field']");
        }
        public WindowsElement ConfirmBtn => FindElement("XPath://*[@AutomationId='ConfirmBtn']");
        public WindowsElement CancelBtn => FindElement("XPath://*[@AutomationId='CancelBtn']");
        public WindowsElement FinalConfirmation => FindElement("XPath://*[@AutomationId='FinalConfirmation']");
        public WindowsElement PartialConfirmation => FindElement("XPath://*[@AutomationId='PartialConfirmation']");
        public WindowsElement SplitBatchBtn => FindElement("XPath://*[@AutomationId='SplitBatchPageBtn']");
        public WindowsElement AddBatchBtn => FindElement("XPath://*[@AutomationId='AddBatchBtn']");
        public IList<WindowsElement> ReasonForVariancePick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public IList<WindowsElement> RemoveBatchUWP()
        {
            return FindElements($"XPath://*[@AutomationId='RemoveBatchUWP']");
        }
        public IList<WindowsElement> FillValue(string TextBox)
        {
            return FindElements($"XPath://*[@Name='{TextBox}']");
        }
        public WindowsElement SearchTextBox => FindElement("XPath://*[@Name='Search']");
        public IList<WindowsElement> ReasonForVarianceUWP_Container()
        {
            return FindElements("XPath://*[@AutomationId='ReasonForVarianceUWP_Container']//*[@ClassName='Image']"); 
        }
    public IList<WindowsElement> NoteText()
        {
            return FindElements($"XPath://*[contains(@Name,'Note')]");
        }
        public IList<WindowsElement> TmInputValues()
        {
            return FindElements($"XPath://*[contains(@Name,'KG')]");
        }
        public IList<WindowsElement> NonBatchMaterialID()
        {
            return FindElements($"XPath://*[contains(@Name,'non batch managed material')]");
        }
        public IList<WindowsElement> BatchMaterialID()
        {
            return FindElements($"XPath://*[contains(@Name,'select the batch')]");
        }
        public IList<WindowsElement> VerifyOrderNumberInputField()
        {
            return FindElements($"XPath://*[contains(@AutomationId,'OrderNumber Input Field')]");
        }
        public IList<WindowsElement> OrderNumberPick()
        {
            return FindElements($"XPath://*[@LocalizedControlType='image']");
        }
        public WindowsElement CommentEditor => FindElement("XPath://*[@AutomationId='CommentEditor']");
        public WindowsElement EnterText(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
    }
}
