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
        public void TC_247738_LoginToWDAppTest(string emailId, string password1)
        {
            try
            {
                if (_basePageInstance.ProfileMenu.Count > 0)
                {
                    TC_252731_LogoutFromWDAppTest(emailId, password1);
                }

                IList<IWebElement> loader = _basePageInstance.LoaderImage;
                WaitForLoaderToDisappear(loader);

                if (_basePageInstance.AllowButton.Count > 0)
                {
                    _basePageInstance.AllowButton[0].Click();
                    WaitForMoment(5);
                }

                _basePageInstance.UserName[0].SendKeys(userName);
                _basePageInstance.NextButton[0].Click();
                WaitForMoment(5);
                _basePageInstance.Password[0].SendKeys(password);
                _basePageInstance.SignInButton[0].Click();
                WaitForMoment(5);

                if (MobPlatform.ToLower().Equals("android"))
                {
                    ((AndroidDriver<IWebElement>)driver).PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
                }
                else
                {
                    _basePageInstance.YesButton[0].Click();
                }
                WaitForLoaderToDisappear(loader);

                if (_basePageInstance.SkipButton.Count > 0)
                {
                    _basePageInstance.SkipButton[0].Click();
                    WaitForMoment(5);
                }               

                Assert.IsTrue(_basePageInstance.ProfileMenu.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogError(ex.Message);
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

                Assert.IsTrue(_basePageInstance.UserName.Count > 0);
                Assert.IsTrue(_basePageInstance.NextButton.Count > 0);

                /*
                if (MobPlatform.ToLower().Equals("android"))
                {
                    Assert.IsTrue(_basePageInstance.LoaderImageOnLoginPage[0].Displayed);
                    Assert.IsTrue(_basePageInstance.LoaderLabel[0].Displayed);
                }
                */    
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogError(ex.Message);
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
                
                Assert.IsNotNull(inboxesPage, "Not navigated to Inbox page");
                Assert.IsTrue(inboxesPage.InboxSearchBox.Displayed, "Inbox search box is not displayed");
                Assert.IsTrue(inboxesPage.GlobalSearchIcon.Displayed, "Global Search icon is not displayed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogError(ex.Message);
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

                _feedbackPage.VerifyTheFieldsOnFeedbackPage(MobPlatform);
                _feedbackPage.TitleTextBox.SendKeys("Test feedback title");
                driver.HideKeyboard();
                _feedbackPage.DescriptionTextBox.SendKeys("Test feedback description");
                driver.HideKeyboard();
                _feedbackPage.SelectEmployee("Patil, Girishwar (EXTERNAL)");
                _feedbackPage.SelectConsents();
                _feedbackPage.VerifyAndSubmitTheFeedback();
                _feedbackPage.VerifyFeedbackConfirmation();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogError(ex.Message);
            }
        }
    }
}
