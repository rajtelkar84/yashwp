using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class HomePageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Get Dashboard page source test;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void PageSourceTest(string emailId, string password, string inbox)
        {
            Console.WriteLine(emailId + " : " + password);
            Console.WriteLine(driver.PageSource);
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Verifying Inbox page navigation from Home Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_InboxPageNavigationFromHomePageTest(string emailId, string password, string inbox)
        {
            Console.WriteLine(emailId + " : " + password + " : " + inbox);
            _basePageInstance.NavigateToInboxPage();
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Submitting the feedback from the Application;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252649_SubmitTheFeedbackTest(string emailId, string password, string inbox)
        {
            try
            {
                _basePageInstance.ClickOnMoreOptions();
                _basePageInstance.VerifyAllOptionsFromMoreOptions();
                FeedbackPage _feedbackPage = _basePageInstance.ClickOnOption("Feedback");
                _feedbackPage.VerifyTheFieldsOnFeedbackPage();
                _feedbackPage.SelectRating(3);
                _feedbackPage.TitleTextBox.SendKeys("Test feedback title");
                _feedbackPage.DescriptionTextBox.SendKeys("Test feedback description");
                //_feedbackPage.SelectEmployee("Patil, Girishwar (EXTERNAL)");
                _feedbackPage.SelectConsents();
                _feedbackPage.VerifyAndSubmitTheFeedback();
                _feedbackPage.VerifyFeedbackConfirmation();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
