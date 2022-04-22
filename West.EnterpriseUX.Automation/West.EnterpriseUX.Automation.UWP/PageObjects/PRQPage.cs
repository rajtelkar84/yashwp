using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class PRQPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public PRQPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement CreatePRQ => FindElement("XPath:.//*[contains(@Name,'Create PRQ')]");
        public WindowsElement EditPRQ => FindElement("XPath:.//*[contains(@Name,'Edit PRQ')]");
        public WindowsElement FirstName => FindElement("XPath:.//*[contains(@Name,'First Name')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement ElementByLabel(string label)
        {           
            return FindElement("XPath:.//*[contains(@Name,'"+label+"')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
        public WindowsElement Sensitivities => FindElement("XPath:.//*[@Name='Sensitivities']/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement ProductInformationTab => FindElement("XPath:.//*[contains(@Name,'Product Information')]");
        public WindowsElement PRQTab => FindElement("XPath:.//*[contains(@Name,'PRQ') and contains(@AutomationId,'dashboardLabel')]");
    
    }
}
