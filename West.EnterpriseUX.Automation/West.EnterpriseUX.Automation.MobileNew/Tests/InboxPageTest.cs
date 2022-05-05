using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class InboxPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Go to specific inbox test;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void GoToSpecificInboxTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                inboxPage.NavigateToInbox(persona, inbox);
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Verifying Global Search functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void VerifyGlobalSearchTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                DetailsPage detailsPage = inboxPage.PerformGlobalSearch(persona, inbox, searchRecord);

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                Assert.AreEqual(inbox.Trim().ToLower(), inboxPage.InboxNameText.Text.Trim().ToLower());
                Assert.IsTrue(detailsPage.GetFirstWidgetTextValues().Contains(searchRecord));
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
