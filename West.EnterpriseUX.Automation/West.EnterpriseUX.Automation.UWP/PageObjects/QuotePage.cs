using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class QuotePage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public QuotePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateQuote => FindElement("XPath:.//*[contains(@Name,'Create Quote')]");
        public WindowsElement ViewExchangeRateLink => FindElement("Name:View Exchange Rate");
        public WindowsElement UpdateLink => FindElement("XPath:.//*[contains(@Name,'Update')]");
        public WindowsElement GeneratePDFLink => FindElement("XPath:.//*[contains(@Name,'Generate PDF')]");
        public WindowsElement IssueQuoteLink => FindElement("XPath:.//*[contains(@Name,'Change Status To Issued')]");
        public WindowsElement ApproveQuoteLink => FindElement("XPath:.//*[contains(@Name,'Review Quote')]");
        public WindowsElement IssueQuoteDialog => FindElement("XPath:.//*[contains(@Name,'Quote Issued Successfully')]");
    }
}
