using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    [TestCategory("HomePageTest")]
    public class HomePageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Login to the Android Application;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_247738_LoginToWDAppTest(string emailId, string password)
        {
            try
            {
                IList<IWebElement> loader = _basePageInstance.LoaderImage;

                WaitForLoaderToDisappear(loader);
                (new TouchAction(driver)).Tap(89, 612).Perform();
                WaitForMoment(5);
                new Actions(driver).SendKeys(emailId.Trim()).Perform();
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForMoment(5);
                new Actions(driver).SendKeys(password.Trim()).Perform();
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForMoment(5);
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                WaitForLoaderToDisappear(loader);

                Assert.IsTrue(_basePageInstance.ProfileMenu[0].Displayed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Verifying Logout functionality of Application;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252731_LogoutFromWDAppTest(string emailId, string password)
        {
            try
            {
                IList<IWebElement> loader = _basePageInstance.LoaderImage;

                WaitForLoaderToDisappear(loader);
                _basePageInstance.ProfileMenu[0].Click();
                _basePageInstance.Logout[0].Click();
                _basePageInstance.LogoutOkButton[0].Click();
                WaitForLoaderToDisappear(loader);

                Assert.IsTrue(_basePageInstance.LoaderImageOnLoginPage[0].Displayed);
                Assert.IsTrue(_basePageInstance.LoaderLabel[0].Displayed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("HomePageTest")]
        [Description("Verifying Inbox page navigation from Home Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.LoginDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_InboxPageNavigationFromHomePageTest(string emailId, string password)
        {
            try
            {
                InboxPage inboxesPage = _basePageInstance.NavigateToInboxesTab();
                Assert.IsNotNull(inboxesPage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
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
                FeedbackPage _feedbackPage = _basePageInstance.ClickOnFeedbackIcon();

                _feedbackPage.VerifyTheFieldsOnFeedbackPage();
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
