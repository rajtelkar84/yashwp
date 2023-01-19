using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class BasePage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
        public InboxPage _inboxPageInstance;
        public FavoritePage _favoritePageInstance;
        public GlobalSearchPage _searchPageInstance;
        public FeedbackPage _feedbackPageInstance;

        public BasePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region BasePage Elements

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoadingIndicator']"), iosLocator: MobileBy.AccessibilityId("LoaderImage"));
        public IList<IWebElement> LoaderImageOnLoginPage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoaderImage']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LoaderLabel => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoaderLabel']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> HamberMenu => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='hamberMenu']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ProfileMenu => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='profileMenu']"), iosLocator: MobileBy.AccessibilityId("profileMenu"));
        public IList<IWebElement> Logout => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Logout']"), iosLocator: MobileBy.AccessibilityId("Logout"));
        public IList<IWebElement> SkipButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='SKIP']"), iosLocator: MobileBy.XPath("//*[@name='Skip']"));
        public IList<IWebElement> LogoutOkButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='okButton']"), iosLocator: MobileBy.AccessibilityId("YES"));
        public IList<IWebElement> AllLoadingTexts => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'Loading') or contains(@text,'Fetching') or contains(@text,'Fetching Modules') or contains(@text,'Preparing') or contains(@text,'Retry') or contains(@text,'Authenticating user') or contains(@text,'Adding') or contains(@text,'Saving') or contains(@text,'Deleting') or contains(@text,'Removing') or contains(@text,'Refreshing') or contains(@text,'Please wait') or contains(@text,'Sharing Insights') or contains(@text,'Fetching')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> UserInfromationPopUp => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='confirmationOptions']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DashboardIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[contains(@resource-id, 'navigation_bar_item_icon_view')])[1]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FavoriteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[contains(@resource-id, 'navigation_bar_item_icon_view')])[2]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SearchIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[contains(@resource-id, 'navigation_bar_item_icon_view')])[4]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InboxesIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[contains(@resource-id, 'navigation_bar_item_icon_view')])[3]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MyTaskIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[contains(@resource-id, 'navigation_bar_item_icon_view')])[5]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MoreOptions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='moreOptions']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> NotificationsOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Notifications']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ReloadOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Reload']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FeedbackIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='feedbackIcon']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SelectOption(string option)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Name' and contains(@text, '" + option + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> BackButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='back']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> PageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='TitleLabel']"), iosLocator: MobileBy.XPath(""));

        public IList<IWebElement> UserName => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@resource-id, 'i0116')]"), iosLocator: MobileBy.AccessibilityId("someone@westpharma.com"));
        public IList<IWebElement> NextButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@resource-id, 'idSIButton9')]"), iosLocator: MobileBy.XPath("(//XCUIElementTypeButton[@name='Next'])[1]"));
        public IList<IWebElement> Password => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@resource-id, 'i0118')]"), iosLocator: MobileBy.XPath("//*[contains(@name, 'Enter the password')]"));
        public IList<IWebElement> SignInButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//android.widget.Button[contains(@text, 'Sign in')]"), iosLocator: MobileBy.AccessibilityId("Sign in"));
        public IList<IWebElement> YesButton => WaitAndFindElements(androidLocator: MobileBy.XPath(""), iosLocator: MobileBy.AccessibilityId("Yes"));
        public IList<IWebElement> AllowButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Allow']"), iosLocator: MobileBy.XPath("//XCUIElementTypeButton[@name='Allow']"));



        

        #endregion

        #region BasePage Actions

        public InboxPage NavigateToInboxesTab()
        {
            try
            {
                if(InboxesIcon.Count > 0)
                {
                    InboxesIcon[0].Click();
                    Thread.Sleep(2000);
                    _inboxPageInstance = new InboxPage(_driver);
                    return _inboxPageInstance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public FavoritePage NavigateToFavoriteTab()
        {
            try
            {
                if (FavoriteIcon.Count > 0)
                {
                    FavoriteIcon[0].Click();
                    WaitForMoment(2);
                    _favoritePageInstance = new FavoritePage(_driver);
                    return _favoritePageInstance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public GlobalSearchPage NavigateToGlobalSearhTab()
        {
            try
            {
                if (SearchIcon.Count > 0)
                {
                    SearchIcon[0].Click();
                    Thread.Sleep(2000);
                    _searchPageInstance = new GlobalSearchPage(_driver);
                    return _searchPageInstance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void ClickOnMoreOptions()
        {
            try
            {
                if (MoreOptions.Count > 0)
                {
                    MoreOptions[0].Click();
                    WaitForMoment(2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("MoreOptions is not displayed.");
            }
        }

        public void VerifyAllOptionsFromMoreOptions()
        {
            Assert.IsTrue(NotificationsOption[0].Displayed);
            Assert.IsTrue(NotificationsOption[0].Text.Trim().Equals("Notifications"));
            Assert.IsTrue(NotificationsOption[0].Enabled);

            Assert.IsTrue(ReloadOption[0].Displayed);
            Assert.IsTrue(ReloadOption[0].Text.Trim().Equals("Reload"));
            Assert.IsTrue(ReloadOption[0].Enabled);

            Assert.IsTrue(FeedbackIcon[0].Displayed);
            Assert.IsTrue(FeedbackIcon[0].Text.Trim().Equals("Feedback"));
            Assert.IsTrue(FeedbackIcon[0].Enabled);
        }

        public void ClickOnOption(string option)
        {
            try
            {
                IList<IWebElement> moreOptionToSelect = SelectOption(option);
                if (moreOptionToSelect.Count > 0)
                {
                    moreOptionToSelect[0].Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public FeedbackPage ClickOnFeedbackIcon()
        {
            try
            {
                if (FeedbackIcon.Count > 0)
                {
                    FeedbackIcon[0].Click();
                    Thread.Sleep(3000);
                    _feedbackPageInstance = new FeedbackPage(_driver);
                    return _feedbackPageInstance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void VerifyCommonElementsDisplayedOrNot()
        {
            try
            {
                Assert.IsTrue(BackButton[0].Displayed);
                Assert.IsTrue(MoreOptions[0].Displayed);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Common elements are not displayed");
            }
        }

        #endregion
    }
}
