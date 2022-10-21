using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class GlobalSearchPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
        public KpisPage _kpisPageInstance;

        public GlobalSearchPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region GlobalSearchPage Elements

        public IWebElement SearchTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='TitleLabel']"), iosLocator: MobileBy.XPath(""));
        public IWebElement SearchBox => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='SearchEntry']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InboxSearchGridValues => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='inboxtitle']"), iosLocator: MobileBy.XPath(""));

        #endregion GlobalSearchPage Elements

        #region GlobalSearchPage Actions

        public KpisPage SearchEntityInbox(string searchEntity)
        {
            try
            {
                if (SearchBox.Displayed && SearchBox.Enabled)
                {
                    SearchBox.Click();
                    SearchBox.Clear();
                    SearchBox.SendKeys(searchEntity);
                    new Actions(_driver).SendKeys(Keys.Enter).Perform();
                    WaitForMoment(2);

                    IList<IWebElement> inboxSearchGridValues = InboxSearchGridValues;
                    if(inboxSearchGridValues.Count > 0)
                    {
                        foreach(var gridValue in inboxSearchGridValues)
                        {
                            if (gridValue.Text.Equals(searchEntity))
                            {
                                gridValue.Click();
                                _kpisPageInstance = new KpisPage(_driver);
                                break;
                            }
                        }
                        return _kpisPageInstance;
                    }
                    else
                    {
                        Console.WriteLine("Result for search entity " + searchEntity + " not found");
                    }
                }
                else
                {
                    Console.WriteLine("Global Search box is not displayed/enabled");
                    Assert.Fail("Global Search box is not displayed/enabled");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void VerifyPageTitle()
        {
            Assert.IsTrue(SearchTabTitle.Displayed);
            Assert.AreEqual("Search", SearchTabTitle.Text);
        }

        #endregion GlobalSearchPage Actions
    }
}