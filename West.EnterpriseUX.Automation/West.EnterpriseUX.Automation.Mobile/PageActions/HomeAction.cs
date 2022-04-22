using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.PageObjects;

namespace West.EnterpriseUX.Automation.Mobile.PageActions
{
    public class HomeAction : BaseAction
    {
        private readonly HomePage _pageInstance;

        public HomeAction(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            _pageInstance = new HomePage(_driver);
        }

        public void ClickOnProfileOptions()
        {
            _pageInstance.AndroidProfile.Click();
        }

        public void ClickOnLogoutOptions()
        {
            _pageInstance.AndroidHamberMenu[0].Click();
            WaitForMoment(2);
            _pageInstance.AndroidLogout.Click();
            WaitForMoment(2);
            _pageInstance.ConfirmationPopUpYes.Click();
        }
        public void ClickOnInbox(string inboxName)
        {
            IList<AppiumWebElement> inbox = _pageInstance.SelectInbox(inboxName);
            if (inbox.Count > 0)
            {
                inbox[0].Click();
            }
        }
        public void ClickOnHomeButton()
        {
            _pageInstance.AndroidHome.Click();
        }
        public void NavigateToInboxByGlobalSearch(string inboxName)
        {
            ClickOnMobileElement(_pageInstance.AndroidGlobalSearchImage);
            WaitForMoment(2);
            ClickOnMobileElement(_pageInstance.AndroidInboxNameDropDown[0]);
            WaitForMoment(1);
            _pageInstance.AndroidEnterInboxNameTextField[0].SendKeys(inboxName);
            WaitForMoment(2);
            ClickOnMobileElement(_pageInstance.AndroidInboxNameDropDown[0]);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidEnterInboxNameTextField);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidSearchForRecordsTextField);
            WaitForMoment(1);
            ClickOnMobileElement(_pageInstance.AndroidGlobalSearchButton);
            WaitForLoadingToDisappear();
        }
        public void NavigateToInboxBySearch(string inboxName)
        {
            if (MobilePlatform.Android.ToString().Equals(MobPlatform))
            {
                IList<AppiumWebElement> inboxListViewOption = _pageInstance.AndroidInboxListView;
                if (inboxListViewOption.Count > 0)
                {
                    ClickOnMobileElement(inboxListViewOption[0]);
                }
                WaitForMoment(1);
                IList<AppiumWebElement> inboxSearchTextField = _pageInstance.AndroidInboxSearchTextfield;
                if (inboxSearchTextField.Count > 0)
                {
                    inboxSearchTextField[0].SendKeys(inboxName);
                }
                WaitForMoment(1);
                IList<AppiumWebElement> inboxSearchButton = _pageInstance.AndroidInboxSearchButton;
                if (inboxSearchButton.Count > 0)
                {
                    ClickOnMobileElement(inboxSearchButton[0]);
                }
               
                WaitForMoment(1);
                IList<AppiumWebElement> searchedInbox = _pageInstance.SelectInboxFromInboxList(inboxName);
                if (searchedInbox.Count > 0)
                {
                    ClickOnMobileElement(searchedInbox[0]);
                }
            }
            else
            {
                IList<AppiumWebElement> inboxListViewOption = _pageInstance.IOSInboxListView;
                if (inboxListViewOption.Count > 0)
                {
                    ClickOnMobileElement(inboxListViewOption[0]);
                }
                WaitForMoment(1.5);
                IList<AppiumWebElement> inboxGlobalSearchIcon = _pageInstance.IOSGlobalSearchImage;
                if (inboxGlobalSearchIcon.Count > 0)
                {
                    ClickOnMobileElement(inboxGlobalSearchIcon[0]);
                }
                WaitForMoment(1.5);
                IList<AppiumWebElement> inboxSearchTextField = _pageInstance.IOSEnterInboxNameTextField;
                if (inboxSearchTextField.Count > 0)
                {
                    inboxSearchTextField[0].SendKeys(inboxName);
                }
                WaitForMoment(1.5);
                IList<AppiumWebElement> searchedInbox = _pageInstance.IOSSelectInboxFromAutoPopulatedList(inboxName);
                if (searchedInbox.Count > 0)
                {
                    ClickOnMobileElement(searchedInbox[0]);
                }
                WaitForMoment(1.5);
                ClickOnMobileElement(_pageInstance.IOSInboxSearchButton);
            }
            WaitForLoadingToDisappear();
        }
        public string GetInboxName()
        {
            return _pageInstance.AndroidGetInboxName[0].Text;
        }
    }
}
