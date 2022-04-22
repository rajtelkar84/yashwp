using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class LoginAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly LoginPage _pageInstance;
        public string LoginPageExpectedTitle = "Sign in";

        public LoginAction(WindowsDriver<WindowsElement> session):base(session)
        {
            this._session = session;
            _pageInstance = new LoginPage(_session);
        }
        public void EnterUserName(string userName)
        {
            _pageInstance.UserNameTextField.SendKeys(userName);
        }
        public void ClickOnNextButton()
        {
            _pageInstance.NextButton.Click();
        }
        public void EnterPassword(string password)
        {
            _pageInstance.PasswordTextField.SendKeys(password);
        }
        public void ClickOnSignInButton()
        {
            _pageInstance.SignInButton.Click();           
        }
        public void ClickOnYesButton()
        {
            _pageInstance.StaySignedYes.Click();
            WaitForLoadingToDisappear(LoadingText.Authenticating.ToString());
        }
        public bool IsSignInHeaderPresent()
        {
            try
            {
                int count = _pageInstance.SignInTextCount.Count;
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError($"Not able to find the SignIn Text in the Current WD Instance: {ex.Message} : {ex.StackTrace}");
                throw new Exception($"Not able to find the SignIn Text in the Current WD Instance");
            }
            
        }
        public void VerifyingUserConfirmationMessage(bool isPresent=false)
        {
            IList<WindowsElement> userInfromationPopUp = _pageInstance.HomeConfirmationButton;
            if (isPresent)
            {
                Assert.IsTrue(userInfromationPopUp.Count > 0,"User Confirmation message not present after login/launch of WD");
            }
            else
            {
                Assert.IsFalse(userInfromationPopUp.Count > 0, "User Confirmation message is present, even tough its presence not expected in current page");
            }
        }
    }
}
