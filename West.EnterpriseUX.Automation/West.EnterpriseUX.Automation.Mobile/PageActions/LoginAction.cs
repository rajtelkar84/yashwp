using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class LoginAction : BaseAction
    {
        private readonly LoginPage _pageInstance;

        public LoginAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new LoginPage(_driver);
        }

        public void HandleConfirmationPopUp()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> confirmationPopUpCancel = _pageInstance.IOSConfirmationPopUpCancel;
                if (confirmationPopUpCancel.Count > 0)
                {
                    confirmationPopUpCancel[0].Click();
                }
            }
        }

        public void EnterUserName(string userName)
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSUserNameTextField.Click();
                _pageInstance.IOSUserNameTextField.SendKeys(userName);
            }
            else
            {
                _pageInstance.AndroidUserNameTextField.SendKeys(userName);
            }
        }
        public void ClickOnDoneButton()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSDoneButton.Click();
            }
        }

        public void ClickOnNextButton()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSNextButton.Click();
            }
            else
            {
                _pageInstance.AndroidNextButton.Click();
            }

        }
        public void EnterPassword(string password)
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSPasswordTextField.Click();
                _pageInstance.IOSPasswordTextField.SendKeys(password);
            }
            else
            {
                _pageInstance.AndroidPasswordTextField.SendKeys(password);
            }
        }
        public void ClickOnSignInButton()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSSignInButton.Click();
            }
            else
            {
                _pageInstance.AndroidSignInButton.Click();
            }
        }
        public void ClickOnLogOutButton()
        {
            _pageInstance.IOSSignInButton.Click();
        }
        public void ClickOnYesButton()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSStaySignedYes.Click();
            }
            else
            {
                _pageInstance.AndroidStaySignedYes.Click();
            }
        }
        public void HandleUserConfirmation()
        {
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                _pageInstance.IOSStaySignedYes.Click();
            }
            else
            {
                _pageInstance.ConfirmationMessage[0].Click();
            }
        }
        public bool VerifySignInPage()
        {
            bool isPresent = false;
            if (MobilePlatform.IOS.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> confirmationPopUpCancel = _pageInstance.IOSConfirmationPopUpCancel;
                if (confirmationPopUpCancel.Count > 0)
                {
                    isPresent = true;
                }
                else
                {
                    isPresent = false;
                }
            }
            else
            {
                WaitForLoadingToDisappear();
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                IList<AppiumWebElement> hamberMenuOption = _pageInstance.AndroidHamberMenu;
                if (hamberMenuOption.Count > 0)
                {
                    isPresent = false;
                }
                else
                {
                    isPresent = true;
                }
            }
            return isPresent;
        }
        public void LoginToWD()
        {
            if (_loginAction.VerifySignInPage())
            {
                _loginAction.HandleConfirmationPopUp();
                WaitForMoment(2.5);
                _loginAction.EnterUserName(userName);
                WaitForMoment(2.1);
                _loginAction.ClickOnDoneButton();
                WaitForMoment(2.1);
                _loginAction.ClickOnNextButton();
                WaitForMoment(2.1);
                _loginAction.EnterPassword(password);
                WaitForMoment(2.1);
                _loginAction.ClickOnDoneButton();
                WaitForMoment(2.1);
                _loginAction.ClickOnSignInButton();
                WaitForMoment(2.1);
                _loginAction.ClickOnYesButton();
                WaitForMoment(2.1);
                _pageInstance.WaitForAndroidLoginLoaderToDisappear();
                _pageInstance.WaitForAndroidLoginLoaderToDisappear();
                HandleUserConfirmations();
            }
            else
            {
               LogInfo("Application is already logged in.");
            }
        }
        public void LogoutFromWD()
        {
            if (!_loginAction.VerifySignInPage())
            {
                WaitForMoment(4);
                _homeAction.ClickOnLogoutOptions();
                WaitForMoment(4);
            }
        }
        public void HandleUserConfirmations()
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> userInfromationPopUp;
                IList<AppiumWebElement> startUpModules;

                do
                {
                    userInfromationPopUp = _pageInstance.ConfirmationMessage;
                    if (userInfromationPopUp.Count > 0)
                    {
                        userInfromationPopUp[0].Click();
                        userInfromationPopUp = _pageInstance.ConfirmationMessage;
                    }
                    startUpModules = _pageInstance.StartUpModules;
                    if (startUpModules.Count > 0)
                    {
                        startUpModules[0].Click();
                        startUpModules = _pageInstance.StartUpModules;
                    }
                } while (userInfromationPopUp.Count > 0 || startUpModules.Count > 0);

            }
            else
            {
                int count = 0;
                do
                {
                    IList<AppiumWebElement> userInfromationPopUp = _pageInstance.IOSUserConfirmation;
                    if (userInfromationPopUp.Count > 0)
                    {
                        userInfromationPopUp[0].Click();
                    }
                    IList<AppiumWebElement> startUpModules = _pageInstance.IOSOkButton;
                    if (startUpModules.Count > 0)
                    {
                        startUpModules[0].Click();
                    }
                    IList<AppiumWebElement> skipButton = _pageInstance.IOSSkipButton;
                    if (skipButton.Count > 0)
                    {
                        skipButton[0].Click();
                    }
                    count++;
                } while (count < 2);
            }

        }
    }
}
