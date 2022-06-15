using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class BasePage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
        public InboxPage _inboxPageInstance;
        public FavoritePage _favoritePageInstance;
        public FeedbackPage _feedbackPageInstance;

        public BasePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region BasePage Elements

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoaderImage']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> HamberMenu => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='hamberMenu']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> Logout => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Logout']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LogoutOkButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='okButton']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> AllLoadingTexts => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'Loading') or contains(@text,'Fetching') or contains(@text,'Fetching Modules') or contains(@text,'Preparing') or contains(@text,'Retry') or contains(@text,'Authenticating user') or contains(@text,'Adding') or contains(@text,'Saving') or contains(@text,'Deleting') or contains(@text,'Removing') or contains(@text,'Refreshing') or contains(@text,'Please wait') or contains(@text,'Sharing Insights') or contains(@text,'Fetching')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> UserInfromationPopUp => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='confirmationOptions']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DashboardIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/navigation_bar_item_icon_view'])[1]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FavoriteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/navigation_bar_item_icon_view'])[2]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InsightsIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/navigation_bar_item_icon_view'])[3]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InboxesIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/navigation_bar_item_icon_view'])[4]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MyTaskIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/navigation_bar_item_icon_view'])[5]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MoreOptions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='moreOptions']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> NotificationsOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Notifications']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ReloadOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Reload']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FeedbackOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Feedback']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SelectOption(string option)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + option + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> BackButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='back']"), iosLocator: MobileBy.XPath(""));
        #endregion

        #region BasePage Actions

        public InboxPage NavigateToInboxPage()
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

        public FavoritePage NavigateToFavoritePage()
        {
            try
            {
                if (FavoriteIcon.Count > 0)
                {
                    FavoriteIcon[0].Click();
                    Thread.Sleep(2000);
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

        public void ClickOnMoreOptions()
        {
            try
            {
                if (MoreOptions.Count > 0)
                {
                    MoreOptions[0].Click();
                    Thread.Sleep(1000);
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

            Assert.IsTrue(FeedbackOption[0].Displayed);
            Assert.IsTrue(FeedbackOption[0].Text.Trim().Equals("Feedback"));
            Assert.IsTrue(FeedbackOption[0].Enabled);
        }

        public FeedbackPage ClickOnOption(string option)
        {
            try
            {
                if (SelectOption(option).Count > 0)
                {
                    SelectOption(option)[0].Click();
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
