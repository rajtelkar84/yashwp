
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class EWMHandlingUnitsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public EWMHandlingUnitsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public IList<WindowsElement> BatchActionMoreOptionButton => FindElements("XPath:.//*[@AutomationId='moreActionStack']//*[@ClassName='Image']");
        public WindowsElement DestinationTab => FindElement("XPath:.//*[@Name='Destination' and @AutomationId='PART_Text']");
        public WindowsElement MasterAction => FindElement("XPath:.//*[@Name='Actions']");
        public WindowsElement ExpandArrow => FindElement("XPath:.//*[contains(@Name,'Expand')]");
        public WindowsElement SearchIcon => FindElement("XPath:.//*[@ClassName='PivotItem']//*[@AutomationId='SearchImage']");
        public WindowsElement DestToggle => FindElement("XPath:.//*[contains(@ClassName,'ToggleSwitch')]");
        public WindowsElement PostButtton => FindElement("XPath:.//*[contains(@Name,'Post') and contains(@ClassName,'Button')]");
        public WindowsElement DeleteIcon => FindElement("XPath:.//*[contains(@Name,'Expand')]//*[contains(@ClassName,'Image')]");
        public WindowsElement PrintButton => FindElement("XPath://*[@AutomationId='HUMassPrint']");
        public WindowsElement ClickBackArrow => FindElement("XPath://*[@AutomationId='Back']");
        public IList<WindowsElement> SelectPicker => FindElements("XPath:.//*[contains(@ClassName,'Image')]");
        public WindowsElement SearchTextBox => FindElement("XPath:.//*[contains(@Name,'Search')]");
        public WindowsElement SearchTxtBox => FindElement("XPath:.//*[@Name='Search']");
        public IList<WindowsElement> DetailActionAllRow(int rowNum)
        {
            return FindElements($"XPath://*[@Name=' Row" + rowNum + "']//*[@AutomationId='More']");
        }
        public WindowsElement SelectBatchCheckBox(int CheckboxNum)
        {
            return FindElement($"XPath://*[@Name=' Row" + CheckboxNum + "']//*[contains(@ClassName,'CheckBox')]");
        }
        public WindowsElement SelectMenuOption(String dateText)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + dateText + "')]");
        }
        public WindowsElement BatchAction(String bactText)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + bactText + "')]");
        }
        public IList<WindowsElement> GetColumnText(string Text)
        {
            return FindElements($"XPath://*[@Name='{Text}']");
        }
        public IList<WindowsElement> GetColumnTextValue()
        {
            return FindElements($"XPath://*[@AutomationId='Row1']//*[@ClassName='NamedContainerAutomationPeer']//*[@ClassName='TextBlock']");
        }
        public IList<WindowsElement> PrintHandlingUnitsMasterBtn(string UserName)
        {
            return FindElements($"XPath://Text[contains(@ClassName,'TextBlock') and contains(@Name,'{UserName}')]");
        }
        public WindowsElement SuccessText(string Text)
        {
            return FindElement($"XPath://*[contains(@Name,'Pop-up')]//*[contains(@Name,'{Text}')]");
        }
        public WindowsElement GetText(string Text)
        {
            return FindElement($"XPath://*[contains(@ClassName,'ListViewItem')]//*[contains(@Name,'{Text}')]");
        }
        public WindowsElement ClickOnMasterAction(string Text)
        {
            return FindElement($"XPath://*[@AutomationId='TextBlock' and @Name='{Text}']");
        }

    }
}
