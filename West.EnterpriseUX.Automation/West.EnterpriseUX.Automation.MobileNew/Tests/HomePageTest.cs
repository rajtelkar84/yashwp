using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class HomePageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("LoginTest")]
        [Description("Login to WD app and Get Dashboard page source test;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void LoginToWDAPPTest(string emailId, string password)
        {
            IList<IWebElement> loader = _basePageInstance.LoaderImage;
            WaitForLoaderToDisappear(loader);

            (new TouchAction(driver)).Tap(284, 441).Perform();

            new Actions(driver).SendKeys(emailId.Trim()).Perform();
            WaitForMoment(5);
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            WaitForMoment(5);
            new Actions(driver).SendKeys(password.Trim()).Perform();
            WaitForMoment(5);
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            WaitForMoment(5);
            new Actions(driver).SendKeys(Keys.Enter).Perform();

            WaitForLoaderToDisappear(loader);

            Console.WriteLine(driver.PageSource);
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Verifying Inbox page navigation from Home Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_InboxPageNavigationFromHomePageTest(string emailId, string password)
        {
            InboxPage inboxesPage = _basePageInstance.NavigateToInboxesTab();
            Assert.IsNotNull(inboxesPage);
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Submitting the feedback from the Application;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252649_SubmitTheFeedbackTest(string emailId, string password)
        {
            try
            {
                //_basePageInstance.ClickOnMoreOptions();
                //_basePageInstance.VerifyAllOptionsFromMoreOptions();
                //FeedbackPage _feedbackPage = _basePageInstance.ClickOnOption("Feedback");

                FeedbackPage _feedbackPage = _basePageInstance.ClickOnFeedbackIcon();
                _feedbackPage.VerifyTheFieldsOnFeedbackPage();
                //_feedbackPage.SelectRating(3);
                _feedbackPage.TitleTextBox.SendKeys("Test feedback title");
                _feedbackPage.DescriptionTextBox.SendKeys("Test feedback description");
                _feedbackPage.SelectEmployee("Patil, Girishwar (EXTERNAL)");
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
