using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

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

        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Favoriting the inboxes in the Persona Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252663_FavoritingTheInboxesInThePersonaPageTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                inboxPage.ScrollToInboxAndClickOnContextMenu(persona, inbox);
                bool isInboxFavorited = inboxPage.ClickOnFavoriteIconInContextMenu();
                
                if (isInboxFavorited)
                {
                    FavoritePage favoritePage = _basePageInstance.NavigateToFavoritePage();
                    WaitForMoment(1);
                    favoritePage.InboxesTab.Click();
                    Assert.IsTrue(favoritePage.CheckForInboxInFavoriteInboxes(inbox)[0].Displayed);
                }
                else
                {
                    Console.WriteLine("Inbox were already in Favorites, Unfavourited successfully");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("InboxPageTest")]
        [Description("Verifying navigation to Child Inbox Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252666_NavigationToChildInboxPageTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                DetailsPage detailsPage = inboxPage.NavigateToInboxByGlobalSearch(persona, inbox);

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                string firstWidgetTextValues = detailsPage.GetFirstWidgetTextValues().Trim().ToLower();
                SemanticPage semanticPage = detailsPage.ClickOnViewDetails();

                WaitForMoment(5);

                _basePageInstance.VerifyCommonElementsDisplayedOrNot();
                semanticPage.VerifyInboxMenuTitle(firstWidgetTextValues);
                semanticPage.VerifyAllTheTabsAreDisplayedOrNot();
                semanticPage.SelectChildInbox("Sales Order Items");

                WaitForMoment(5);

                Assert.AreEqual("Sales Order Items", inboxPage.InboxNameText.Text.Trim());
                Assert.IsTrue(detailsPage.DetailsAbstractionTabTitle.Displayed);
                Assert.IsTrue(inboxPage.OpenKpisAbstraction().KpisAbstractionTabTitle.Selected);
                Assert.IsTrue(inboxPage.OpenChartsAbstraction().ChartsAbstractionTabTitle.Selected);
                Assert.IsTrue(inboxPage.OpenStoryboardsAbstraction().StoryboardsAbstractionTabTitle.Selected);

                detailsPage.DetailsAbstractionTabTitle.Click();
                WaitForMoment(10);
                Assert.IsNotNull(detailsPage.GetFirstWidgetTextValues());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
