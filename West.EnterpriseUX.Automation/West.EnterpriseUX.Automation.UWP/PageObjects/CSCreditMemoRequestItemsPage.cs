using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CSCreditMemoRequestItemsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public CSCreditMemoRequestItemsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> DetailActionRowAll(int rowNum)
        {
            return FindElements($"XPath://*[@AutomationId=' R" + rowNum + "C0 Detail Action']//*[@AutomationId='More']");
        }
        public WindowsElement SelectOptioninMenu(string OptionText)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + OptionText + "')]");
        }
        public WindowsElement MoreExpand => FindElement("Name:Expand");
        public WindowsElement CloseExpand => FindElement("AccessibilityId:CloseIcon");
        public WindowsElement MoreCollaborationBeta => FindElement("Name:Collaboration(Beta)");
        public WindowsElement ViewDetailsbutton => FindElement("AccessibilityId:ViewSemantic");
    }
}
