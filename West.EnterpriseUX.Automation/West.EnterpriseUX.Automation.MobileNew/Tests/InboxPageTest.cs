using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class InboxPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Go to specific inbox test")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void GoToSpecificInboxTest(string persona, string inbox)
        {
            InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
            inboxPage.NavigateToInbox(persona, inbox);
            WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
        }
    }
}
