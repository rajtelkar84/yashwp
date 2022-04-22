using OpenQA.Selenium.Appium.Windows;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class FeedbackAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly FeedbackPage _pageInstance;

        public FeedbackAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new FeedbackPage(_session);
        }
        public void ClickOnFeedbackIcon()
        {
            _pageInstance.FeedbackImage.Click();
        }
        public void SelectRating(int rating)
        {
            WindowsElement ratingElement=_pageInstance.SelectRating(rating);
            MouseClickOnWindowsElement(ratingElement);
        }
        public void EnterFeedbackTitle(string title)
        {
            _pageInstance.FeedbackTitle[0].SendKeys(title);
        }
        public void EnterFeedbackDetails(string description)
        {
            _pageInstance.FeedbackDescription[0].SendKeys(description);
        }
        public void SelectUserConsent()
        {
            _pageInstance.UserConsent.Click();
        }
        public void ClickOnSubmitButton()
        {
            _pageInstance.FeedbackSubmitButton.Click();
        }
        public void ClickOnOkButton()
        {
            _pageInstance.ConfirmationOkButton.Click();
            WaitForMoment(0.5);
            WaitForLoadingToDisappear();
        }
    }
}
