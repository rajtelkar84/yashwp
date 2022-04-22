using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class FeedbackPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public FeedbackPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> FeedbackTitle => FindElements("AccessibilityId:feedbackTitle");
        public IList<WindowsElement> FeedbackDescription => FindElements("AccessibilityId:feedbackDescription");
        public WindowsElement FeedbackSubmitButton => FindElement("AccessibilityId:SubmitButton");
        public WindowsElement UserConsent => FindElement("AccessibilityId:consentForFeedback");
        public WindowsElement SelectRating(int rating)
        {
            return FindElement($"XPath:(//Group[@AutomationId='StarRating']/Group)[{rating}]");
        }
    }
}
