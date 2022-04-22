
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class PhysicalInevntoryPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public PhysicalInevntoryPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement PopUpYesBtn => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement PopUpOkBtn => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement PopUpNoBtn => FindElement("XPath://*[@AutomationId='cancelButton']");
        public WindowsElement PopUpDialogMessage => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement PopUpDialogTitle => FindElement("XPath://*[@AutomationId='dialogTitle']");
        public WindowsElement countButton => FindElement("XPath://*[@AutomationId='PIDocPageCountButton']");
        public WindowsElement postButton => FindElement("XPath://*[@AutomationId='PIDocPagePostButton']");
        public IList<WindowsElement> poupText => FindElements("XPath://*[@Name='Count cannot be performed on empty bin']");
        public IList<WindowsElement> ActualQualityTxt => FindElements("XPath://*[@AutomationId=' Input Field']");
        public IList<WindowsElement> ActualContent => FindElements("XPath://*[@AutomationId='ContentElement']");
        public IList<WindowsElement> PIListViewCheckBox => FindElements("XPath://*[@AutomationId='PIListViewCheckBox']");
        public WindowsElement ListView => FindElement("XPath://*[@ClassName='ListView']");
        public WindowsElement activePIDocumentsDashLabel => FindElement("XPath://*[contains(@Name,'Active PI Document')]");
        public WindowsElement countedPIDocumentDashLabel => FindElement("XPath://*[contains(@Name,'Counted PI Document')]");
        public WindowsElement PIDocPagePostButton => FindElement("XPath://*[contains(@AutomationId,'PIDocPagePostButton')]");
        public WindowsElement PIDocPageCountButton => FindElement("XPath://*[contains(@AutomationId,'PIDocPageCountButton')]");
        public WindowsElement allDashboardLabel => FindElement("XPath://*[contains(@Name,'All')]");
        public WindowsElement ClickOnBatchAction(string Text)
        {
            return FindElement($"XPath://*[@ClassName='TextBlock' and @Name='{Text}']");
        }
        public WindowsElement GetColumnText(int rowNum, int columnNum)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'R" + rowNum + "C" + columnNum + " ')]//*[@ClassName='TextBlock']");
        }
        //public WindowsElement PopUpDialogTitle => FindElement("XPath://*[@AutomationId='dialogTitle']");
        //public WindowsElement ClickOnBatchAction(string Text)
        //{
        //    return FindElement($"XPath://*[@ClassName='TextBlock' and @Name='{Text}']");
        //}
        //public WindowsElement GetColumnText(int rowNum, int columnNum)
        //{
        //    return FindElement($"XPath://*[contains(@AutomationId,'R" + rowNum + "C" + columnNum + " ')]//*[@ClassName='TextBlock']");
        //}

    }
}
