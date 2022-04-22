using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class ChildInboxAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ChildInboxPage _pageInstance;
        public string ChildInboxPageExpectedTitle = "Child Inbox";

        public ChildInboxAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ChildInboxPage(_session);
        }
        public void ClickOnChildInboxLabelButton(string childInboxLabelName)
        {
            _pageInstance.ChildInboxLabel(childInboxLabelName).Click();
            WaitForLoadingToDisappear();
        }
        public void ClickOnCreateMasterActionImage()
        {
            _pageInstance.CreateImage.Click();
        }
        public void ClickOnCreateButton()
        {
            _pageInstance.CreateButton.Click();
            WaitForLoadingToDisappear();
        }
        public void ClickOnChildInboxeItem(string parentInbox,string childInboxName)
        {
            IList<WindowsElement> inboxesRefreshButton = _pageInstance.InboxesSearchButton;
            if (inboxesRefreshButton.Count == 0)
            {
                _pageInstance.InboxesToggleButton.Click();
            }
            IList<WindowsElement> childInbox = _pageInstance.ChildInboxItem(childInboxName);
            if(childInbox.Count>0)
            {
                childInbox[0].Click();
            }
            else
            {
                LogInfo($"Child Inbox not configured for this inbox : {parentInbox}");
                Assert.Fail($"Child Inbox not configured for this inbox : {parentInbox}");
            }
            WaitForLoadingToDisappear();
        }
        public void VerifyChildLevelNavigation(string expectedChildInbox)
        {
            string actualChildInbox = _pageInstance.InboxesButton.Text;
            Assert.AreEqual(expectedChildInbox, actualChildInbox, "Child inbox navigation is not successfull");
        }
        public void ClickOnFirstChildInboxeItem(string parentInbox, string childInboxName)
        {
            if (_pageInstance.RelatedItemsText.Count == 0)
            {
                _pageInstance.ToggleIcon.Click();
                LogInfo($" {_pageInstance.RelatedItemsText.Count}: Related Item text is visible now");
            }
            IList<WindowsElement> childInbox = _pageInstance.ChildInboxItem(childInboxName);
            if (childInbox.Count > 0)
            {
                childInbox[0].Click();
            }
            else
            {
                LogInfo($"Child Inbox not configured for this inbox : {parentInbox}");
                Assert.Fail($"Child Inbox not configured for this inbox : {parentInbox}");
            }
            WaitForLoadingToDisappear();
        }
    }
}
