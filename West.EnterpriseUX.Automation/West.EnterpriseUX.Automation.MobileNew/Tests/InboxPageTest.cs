using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class InboxPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Verifying Inbox page navigation from Home Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252675_GoToSpecificInboxTest(string persona, string inbox, string searchRecord)
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
        public void TC_252664_VerifyGlobalSearchTest(string persona, string inbox, string searchRecord)
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

        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Navigate to each of the abstractions in the Inbox Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252670_NavigateToEachOfTheAbstractionsTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();

                DetailsPage detailsPage = inboxPage.NavigateToInboxByGlobalSearch(persona, inbox);
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
                Assert.IsNotNull(detailsPage);
                Assert.IsTrue(detailsPage.DetailsAbstractionTabTitle.Displayed);
                Assert.IsTrue(inboxPage.DetailsAbstractionTab.Selected);

                KpisPage kpisPage = inboxPage.OpenKpisAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
                Assert.IsNotNull(kpisPage);
                Assert.IsTrue(kpisPage.KpisAbstractionTabTitle.Displayed);
                Assert.IsTrue(inboxPage.KpisAbstractionTab.Selected);

                ChartsPage chartsPage = inboxPage.OpenChartsAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
                Assert.IsNotNull(chartsPage);
                Assert.IsTrue(chartsPage.ChartsAbstractionTabTitle.Displayed);
                Assert.IsTrue(inboxPage.ChartsAbstractionTab.Selected);

                StoryboardsPage storyboardsPage = inboxPage.OpenStoryboardsAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
                Assert.IsNotNull(storyboardsPage);
                Assert.IsTrue(storyboardsPage.StoryboardsAbstractionTabTitle.Displayed);
                Assert.IsTrue(inboxPage.StoryboardsAbstractionTab.Selected);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
