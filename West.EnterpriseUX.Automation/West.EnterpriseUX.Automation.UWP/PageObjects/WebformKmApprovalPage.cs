using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class WebformKmApprovalPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public WebformKmApprovalPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateWebFormKmApproval => FindElement("XPath:.//*[contains(@Name,'Create KM Approval Webform')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement Reference => FindElement("XPath:.//*[contains(@Name,'Reference')]/../../../following-sibling::*/*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Link => FindElement("XPath:.//*[contains(@Name,'Link')]/../../../following-sibling::*//*[contains(@Name,'Input Field')]");
        public WindowsElement ApprovalStatus => FindElement("XPath:.//*[contains(@Name,'Approval Status')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement ApprovalEmail => FindElement("XPath:.//*[contains(@Name,'Approver Email')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement Comments => FindElement("XPath:.//*[contains(@Name,'Comments')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement CreateWebFormKmButton => FindElement("XPath:.//*[contains(@ClassName,'Button') and contains(@Name,'Create')]");
        public WindowsElement KMApprovalTab => FindElement("XPath:.//*[contains(@Name,'KM Approval') and contains(@AutomationId,'dashboardLabel')]");
        public WindowsElement EditKMApproval => FindElement("XPath:.//*[contains(@Name,'Edit KM Approval Webform')]");
    }
}
