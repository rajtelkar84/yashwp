using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    public class ChartsPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("ChartsPageTest")]
        [Description("Verifying Zoom In functionality for Chart;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.Charts_252697), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252697_VerifyZoomInFunctionalityForChartTest(string persona, string inbox, string chartName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);
                ChartsPage chartsPage = inboxesTab.OpenChartsAbstraction();

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                chartName = chartsPage.SelectChartToFavorite();
                chartsPage.SelectChartToZoom(chartName);
                chartsPage.VerifyChartPageTitle(chartName);
                _basePageInstance.BackButton[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _basePageInstance.BackButton[0].Click();
                FavoritePage favoritePage1 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage1.UnfavoriteAllKPIsAndCharts();
            }
        }

        [TestMethod]
        [TestCategory("ChartsPageTest")]
        [Description("Verifying Chart Refresh functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.Charts_252697), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252694_VerifyChartRefreshFunctionalityTest(string persona, string inbox, string chartName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);
                ChartsPage chartsPage = inboxesTab.OpenChartsAbstraction();

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                chartName = chartsPage.SelectChartToFavorite();
                chartsPage.SelectChartToRefresh(chartName);

                Assert.IsTrue(_basePageInstance.LoaderImageOnLoginPage[0].Displayed);
                Assert.IsTrue(_basePageInstance.LoaderLabel[0].Displayed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _basePageInstance.BackButton[0].Click();
                FavoritePage favoritePage1 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage1.UnfavoriteAllKPIsAndCharts();
            }
        }

        [TestMethod]
        [TestCategory("ChartsPageTest")]
        [Description("Verifying Favoriting of Charts functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.Charts_252697), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252698_VerifyFavoritingOfChartsFunctionalityTest(string persona, string inbox, string chartName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                FavoritePage favoritePage1 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage1.UnfavoriteAllKPIsAndCharts();

                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);
                ChartsPage chartsPage = inboxesTab.OpenChartsAbstraction();

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                chartName = chartsPage.SelectChartToFavorite();
                _basePageInstance.BackButton[0].Click();
                WaitForMoment(2);

                FavoritePage favoritePage2 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage2.KPIsAndChartsTab.Click();

                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                Assert.IsTrue(favoritePage2.CheckForKPIsAndChartsInFavorite(chartName)[0].Displayed);
                favoritePage2.UnfavoriteAllKPIsAndCharts();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }


    }
}
