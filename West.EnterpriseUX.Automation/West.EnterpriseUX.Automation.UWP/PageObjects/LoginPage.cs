using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class LoginPage: BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public LoginPage(WindowsDriver<WindowsElement> session):base(session)
        {
            this._session = session;
        }

        public WindowsElement UserNameTextField => FindElement("Name:someone@westpharma.com");
        public WindowsElement NextButton => FindElement("Name:Next");
        public WindowsElement PasswordTextField => FindElement("AccessibilityId:i0118");
        public WindowsElement SignInButton => FindElement("Name:Sign in");
        public WindowsElement StaySignedYes => FindElement("AccessibilityId:idSIButton9");
        public IList<WindowsElement> SignInTextCount => FindElements("XPath:.//*[contains(@Name,'Sign in')]");
    }
}
