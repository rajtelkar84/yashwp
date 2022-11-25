using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class SemanticPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public SemanticPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region SemanticPage Elements
        public IList<IWebElement> InboxMenuTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='inboxMenuTitle']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> OverviewTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='OVERVIEW']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CollaborationTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='COLLABORATION']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> _360ViewTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='360º VIEW']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> RelatedItemsTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='RELATED ITEMS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ListOfChildInbox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='InboxName']/ancestor::android.widget.ListView/descendant::android.widget.TextView[@content-desc='InboxName']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> HomeButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Home']"), iosLocator: MobileBy.XPath(""));
        
        //*[@content-desc='InboxName']/ancestor::android.widget.ListView/child::*
        //*[@content-desc="InboxName"]/ancestor::android.widget.ListView/descendant::android.widget.TextView[@content-desc="InboxName"]
        #endregion SemanticPage Elements

        #region SemanticPage Actions

        public void VerifyAllTheTabsAreDisplayedOrNot()
        {
            try
            {
                Assert.IsTrue(OverviewTab[0].Displayed);
                Assert.IsTrue(OverviewTab[0].Enabled);
                Assert.IsTrue(CollaborationTab[0].Displayed);
                Assert.IsTrue(CollaborationTab[0].Enabled);
                Assert.IsTrue(_360ViewTab[0].Displayed);
                Assert.IsTrue(_360ViewTab[0].Enabled);
                Assert.IsTrue(RelatedItemsTab[0].Displayed);
                Assert.IsTrue(RelatedItemsTab[0].Enabled);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("All the tabs on Semantic Page are not diaplyed/enabled");
            }
        }

        public void VerifyInboxMenuTitle(string firstWidgetAllTextsFromDetailsPage)
        {
            try
            {
                if (InboxMenuTitle.Count > 0)
                {
                    if (InboxMenuTitle[0].Text.Contains(","))
                    {
                        string[] inboxMenuTitleTexts = InboxMenuTitle[0].Text.Split(',');

                        foreach (string text in inboxMenuTitleTexts)
                        {
                            Assert.IsTrue(firstWidgetAllTextsFromDetailsPage.Contains(text.Trim().ToLower()));
                        }
                    }
                    else
                        Assert.IsTrue(firstWidgetAllTextsFromDetailsPage.Contains(InboxMenuTitle[0].Text.Trim().ToLower()));
                }
                else
                    Console.WriteLine("Inbox menu title is not displayed on Semantic Page");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Inbox menu title is incorrect on Semantic Page");
            }
        }

        public void SelectChildInbox(string childInbox)
        {
            try
            {
                if(RelatedItemsTab.Count > 0)
                {
                    RelatedItemsTab[0].Click();
                    WaitForMoment(2);

                    if(ListOfChildInbox.Count > 0)
                    {
                        foreach (IWebElement element in ListOfChildInbox)
                        {
                            string inboxText = element.Text;

                            if (element.Text.Trim().Contains(childInbox))
                            {
                                element.Click();
                                break;
                            }
                        }
                    }
                    else
                        Console.WriteLine("No child inbox is present in Related Items tab ");
                }
                else
                    Console.WriteLine("Related Items tab is not displayed on Semantic Page");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Not able to select child inbox " + childInbox + " from Semantic Page");
            }
        }

        public void ClickOnHomeButton()
        {
            try
            {
                if (HomeButton.Count > 0 && HomeButton[0].Displayed && HomeButton[0].Enabled)
                {
                    HomeButton[0].Click();
                    WaitForMoment(2);
                }
                else
                {
                    Console.WriteLine("Home button is not present on Child Inbox page.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail("Home button is not present on Child Inbox page.");
            }
        }

        #endregion SemanticPage Actions
    }
}
