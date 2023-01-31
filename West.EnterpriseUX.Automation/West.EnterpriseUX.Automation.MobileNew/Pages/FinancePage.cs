using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace West.EnterpriseUX.Automation.MobileNew.Pages
{
    public class FinancePage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;

        public FinancePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region FinancePage Elements

        public IList<IWebElement> PersonaName(string personaName)
        {
          //  return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + personaName + "']"), iosLocator: MobileBy.XPath("//*[@label ='" + personaName + "']/parent:: XCUIElementTypeOther/parent:: XCUIElementTypeOther/preceding-sibling:: XCUIElementTypeOther/preceding-sibling:: XCUIElementTypeOther/parent::XCUIElementTypeOther"));
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + personaName + "']"), iosLocator: MobileBy.XPath("//*[@label ='" + personaName + "']"));
        }
        public IList<IWebElement> InboxName(string inboxName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath("//*[@label='" + inboxName + "']"));
        }

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoadingIndicator']"), iosLocator: MobileBy.AccessibilityId("LoaderImage"));

        public IWebElement DetailsButton => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeButton[@name='Details']"));

        public IList<IWebElement> Actions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@name='Actions']"));

        public IList<IWebElement> ViewDetails => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@name='View Details']"));

        public IList<IWebElement> moreOptions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeButton[@name='MoreOptions']"));
        public IList<IWebElement> Sort => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@name='Sort']"));
        public IList<IWebElement> Filter => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@name='Filter']"));
        public IList<IWebElement> InvoiceInboxPageHeadline => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@label='Invoices Inbox']"));
        #endregion

        #region FinancePage Actions

        public void NavigatetoInboxDetailsPage(string Persona, string inboxName)
        { 
            try
            {

                if (PersonaName(Persona).Count > 0)
                {
                    PersonaName(Persona)[0].Click();
                }

                WaitForMoment(2);

                if (InboxName(inboxName).Count > 0)
                {

                    InboxName(inboxName)[0].Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void clickonDetailsTab()
        {
            try
            {

                DetailsButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  (string pageTitle,int ActionButton,int viewDetailsButton,int moreOptionButton,int sortButton,int filterButton) pagedetailscheck(string inboxName)
        {

            string pageTitle = InboxName(inboxName)[0].GetAttribute("label");
            int ActionButton = Actions.Count;
            int viewDetailsButton = ViewDetails.Count;
            int moreOptionButton = moreOptions.Count;
            int sortButton = Sort.Count;
            int filterButton = Filter.Count;
            return (pageTitle,ActionButton,viewDetailsButton,moreOptionButton,sortButton,filterButton);
        }


        #endregion
    }
}
