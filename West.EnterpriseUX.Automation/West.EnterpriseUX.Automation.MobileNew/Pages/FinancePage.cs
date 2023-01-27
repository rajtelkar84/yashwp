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
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath("//*[@Label='" + inboxName + "']"));
        }

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoadingIndicator']"), iosLocator: MobileBy.AccessibilityId("LoaderImage"));

        public IWebElement DetailsButton => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeButton[@name='Details']"));

        public IList<IWebElement> Actions => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath("//XCUIElementTypeStaticText[@name='Actions']"));

        #endregion

        #region FinancePage Actions

        public void NavigatetoInboxDetailsPage(string Persona, string inboxName)
        { 

            AppiumSetup setup = new AppiumSetup();

            try
            {
                setup.WaitForLoaderToDisappear(LoaderImage);

                if (PersonaName(Persona).Count > 0)
                {
                    PersonaName(Persona)[0].Click();
                }

                WaitForMoment(2);

                InboxName(inboxName)[0].Click();

                setup.WaitForLoaderToDisappear(LoaderImage);


               




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       

        #endregion
    }
}
