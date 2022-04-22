using OpenQA.Selenium.Appium.Windows;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class QuoteAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly QuotePage _pageInstance;

        public QuoteAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new QuotePage(_session);
        }
        public void ClickOnCreateQuote()
        {
            ClickElement(_pageInstance.CreateQuote);
            LogInfo("Clicked on create quote");
            WaitForLoadingToDisappear();
        }
        public void ClickOnUpdateQuote()
        {
            _pageInstance.UpdateLink.Click();
            LogInfo("Clicked on Update link");
            WaitForLoadingToDisappear();
        }
        public void ClickOnApproveQuote()
        {
            _pageInstance.ApproveQuoteLink.Click();
            LogInfo("Clicked on Approve quote");
            WaitForLoadingToDisappear();
        }
        public void ClickOnGeneratePDF()
        {
            _pageInstance.GeneratePDFLink.Click();
            LogInfo("Clicked on Generate PDF");
            WaitForLoadingToDisappear();
        }
        public void ClickOnIssueQuote()
        {
            _pageInstance.IssueQuoteLink.Click();
            LogInfo("Clicked on Issue quote");
            //WaitForLoadingToDisappear();
        }
        public bool VerifyQuoteIssued()
        {
            bool quoteIssued = Exists(_pageInstance.IssueQuoteDialog);
            LogInfo("Quote issued successfully" + quoteIssued);
            return quoteIssued;
        }
               
    }
}
