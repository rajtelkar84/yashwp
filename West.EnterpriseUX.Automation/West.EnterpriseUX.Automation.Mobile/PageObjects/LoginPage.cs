using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
        }

        public IList<AppiumWebElement> IOSConfirmationPopUpCancel => FindElements(Locators.AccessibilityId.ToString() + ":Allow");
        public AppiumWebElement IOSUserNameTextField => FindElement(Locators.AccessibilityId.ToString() + ":someone@westpharma.com");
        public AppiumWebElement IOSDoneButton => FindElement(Locators.Name.ToString() + ":Done");
        public AppiumWebElement IOSNextButton => FindElement(Locators.AccessibilityId.ToString() + ":Next");
        public AppiumWebElement IOSPasswordTextField => FindElement(Locators.XPath.ToString() + "://XCUIElementTypeSecureTextField[contains(@name,'Enter the password for ')]");
        public AppiumWebElement IOSSignInButton => FindElement(Locators.AccessibilityId.ToString() + ":Sign in");
        public AppiumWebElement IOSStaySignedYes => FindElement(Locators.AccessibilityId.ToString() + ":Yes");

        public AppiumWebElement AndroidUserNameTextField => FindElement(Locators.XPath.ToString() + "://*[@resource-id='i0116']");
        public AppiumWebElement AndroidNextButton => FindElement(Locators.XPath.ToString() + ":.//android.widget.Button[@text='Next']");
        public AppiumWebElement AndroidPasswordTextField => FindElement(Locators.XPath.ToString() + "://*[@resource-id='i0118']");
        public AppiumWebElement AndroidSignInButton => FindElement(Locators.XPath.ToString() + ":.//android.widget.Button[@text='Sign in']");
        public AppiumWebElement AndroidStaySignedYes => FindElement(Locators.XPath.ToString() + ":.//android.widget.Button[@text='Yes']");
    }
}
