using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class BinsProductsPage : BasePage
    {

        protected WindowsDriver<WindowsElement> _session;

        public BinsProductsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public IList<WindowsElement> SelectOverFlowMenuDot => FindElements("XPath://*[@AutomationId='More']");
        public IList<WindowsElement> SelectPicker => FindElements("XPath:.//*[contains(@ClassName,'ScrollViewer')]//*[contains(@ClassName,'Image')]");
        public WindowsElement SearchTextBox => FindElement("XPath:.//*[contains(@Name,'Search')]");

        public WindowsElement ReasonCodePickerBtn => FindElement("XPath:.//*[contains(@ClassName,'TextBox')]/parent::Custom/following-sibling::Image");
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public WindowsElement SelectMenuOption(String dateText)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + dateText + "')]");
        }
        public WindowsElement DestinationPostBtn => FindElement("XPath://*[@AutomationId='DestPostButton']");

        public WindowsElement DestinationToggleBtn => FindElement("XPath://*[@AutomationId='DestinationToggle']");
        public WindowsElement PopUpText => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement PopUpCancelBtn=> FindElement("XPath://*[@AutomationId='cancelButton']");
        public WindowsElement PopUpOkBtn => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement SuccessText=> FindElement("XPath://*[contains(@Name,'Pop-up')]//*[contains(@Name,'Warehouse Order:')]");
        public WindowsElement TransferQualityTxtBox => FindElement("XPath://*[contains(@AutomationId,' Input Field')]");
        public WindowsElement SelectBatchCheckBox(int CheckboxNum)
        {
            return FindElement("XPath:(//*[contains(@ClassName,'CheckBox')])["+ CheckboxNum + "]");
        }
        public WindowsElement BatchBinBinMovementTxt => FindElement("XPath:.//*[contains(@Name,'Bin - Bin Movement')]");
        public WindowsElement SourceToggle=> FindElement("XPath://*[@AutomationId='PART_Text'] and //*[contains(@Name,'Source')]");
        public WindowsElement DestinationToggle => FindElement("XPath://*[@AutomationId='PART_Text'] and //*[contains(@Name,'Destination')]");
    }
}
