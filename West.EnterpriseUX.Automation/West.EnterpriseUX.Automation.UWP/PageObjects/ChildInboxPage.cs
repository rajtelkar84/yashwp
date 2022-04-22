using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ChildInboxPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ChildInboxPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CreateImage => FindElement("AccessibilityId:MasterAction");
        public WindowsElement CreateButton => FindElement("XPath://*[contains(@Name,'Create')]");
        public WindowsElement ToggleIcon => FindElement("AccessibilityId:PaneTogglePane");
        public IList<WindowsElement> RelatedItemsText => FindElements("XPath://Text[contains(@Name,'Related Items')]");
        public WindowsElement ChildInboxLabel(string childInboxLabelName)
        {
            return FindElement($"XPath:.//Button[contains(@Name,'{childInboxLabelName}')]");
        }
        public IList<WindowsElement> ChildInboxItem(string childInboxName)
        {
            return FindElements($"XPath://*[@AutomationId='InboxName' and contains(@Name,'{childInboxName}')]");
        }
    }
}
