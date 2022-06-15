using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class DetailsPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("DetailsPageTest")]
        [Description("Verifying the Page Scrolling functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252677_PageScrollingFunctionalityTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                DetailsPage detailsPage = inboxPage.PerformGlobalSearch(persona, inbox, searchRecord);

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                bool isPageScrolledTillTheEndOfDetailsPage = detailsPage.VerifyScrollingFunctionalityOnDetailsPage();
                Assert.IsTrue(isPageScrolledTillTheEndOfDetailsPage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsPageTest")]
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

        [TestMethod]
        [TestCategory("DetailsPageTest")]
        [Description("Verifying navigation to Inbox Semantic Page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252668_NavigationToInboxSemanticPageTest(string persona, string inbox, string searchRecord)
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
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsPageTest")]
        [Description("Verifying the navigation of dashboard labels in the inbox page;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.InboxDataObject), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252671_NavigationToDashboardLabelsTest(string persona, string inbox, string searchRecord)
        {
            try
            {
                InboxPage inboxPage = _basePageInstance.NavigateToInboxPage();
                DetailsPage detailsPage = inboxPage.NavigateToInboxByGlobalSearch(persona, inbox);

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                inboxPage.ClickOnManageLabelsOption();
                ISet<string> allLables = inboxPage.GetAllLabels();
                _basePageInstance.BackButton[0].Click();
                detailsPage.NavigateToAllLables(allLables);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
