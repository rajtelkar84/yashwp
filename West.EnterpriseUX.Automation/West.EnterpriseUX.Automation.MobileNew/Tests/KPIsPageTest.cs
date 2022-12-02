using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.MobileNew
{
    [TestClass]
    [TestCategory("KPIsPageTest")]
    public class KPIsPageTest : AppiumSetup
    {
        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying Zoom In functionality for KPI;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252691), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252691_VerifyZoomInFunctionalityForKPITest(string persona, string inbox, string kpiName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);

                KpisPage kpisPage = inboxesTab.OpenKpisAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToZoom(kpiName);
                kpisPage.VerifyKpiPageTitle(kpiName);
                _basePageInstance.BackButton[0].Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying KPI Refresh functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252691), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252689_VerifyKPIRefreshFunctionalityTest(string persona, string inbox, string kpiName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);

                KpisPage kpisPage = inboxesTab.OpenKpisAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToRefresh(kpiName);

                Assert.IsTrue(_basePageInstance.LoaderImageOnLoginPage[0].Displayed);
                Assert.IsTrue(_basePageInstance.LoaderLabel[0].Displayed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying Favoriting of KPI functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252691), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252692_VerifyFavoritingOfKPIFunctionalityTest(string persona, string inbox, string kpiName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                FavoritePage favoritePage1 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage1.UnfavoriteAllKPIsAndCharts();

                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);

                KpisPage kpisPage = inboxesTab.OpenKpisAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToFavorite(kpiName);
                _basePageInstance.BackButton[0].Click();
                WaitForMoment(2);

                FavoritePage favoritePage2 = _basePageInstance.NavigateToFavoriteTab();
                favoritePage2.KPIsAndChartsTab.Click();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                Assert.IsTrue(favoritePage2.CheckForKPIsAndChartsInFavorite(kpiName)[0].Displayed);
                favoritePage2.UnfavoriteAllKPIsAndCharts();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Applying the micro filter on the KPI;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252691), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252732_ApplyMicroFilterOnKPITest(string persona, string inbox, string kpiName, string filterField1, string operator1, string filterValue1, string filterField2, string operator2, string filterValue2)
        {
            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForMoment(20);

                KpisPage kpisPage = inboxesTab.OpenKpisAbstraction();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToApplyFilterOn(kpiName);

                FilterPage filterPage = kpisPage.SelectMicroFilterOption("More");
                filterPage.ClickOnAddFilter();
                filterPage.SelectFilterFieldValue(filterField1.Trim(), 1);
                filterPage.SelectOperatorValue(operator1.Trim(), 1);
                filterPage.EnterFilterValue(filterValue1.Trim(), 1);
                filterPage.ClickOnApplyFilter();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                Assert.IsTrue(kpisPage.AppliedMicroFilterText[0].Displayed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Configuring the user created KPI;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252734), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252734_ConfiguringTheUserCreatedKPITest(string persona, string inbox, string kpiName, string propertyValue1, string propertyValue2, string filterField1, string operator1, string filterValue1)
        {
            KpisPage kpisPage = null;

            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber;
                kpiTemplateName = $"TestValue" + uniqueNumber;

                FilterPage filterPage = inboxesTab.ClickOnFilterOption();
                filterPage.ClickOnAddFilter();
                filterPage.SelectFilterFieldValue(filterField1.Trim(), 1);
                filterPage.SelectOperatorValue(operator1.Trim(), 1);
                filterPage.EnterFilterValue(filterValue1.Trim(), 1);
                filterPage.ClickOnApplyFilter();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                detailsPage.ClickOnCreateLabelButton();
                detailsPage.EnterLabelName(labelName);
                detailsPage.SaveButton[0].Click();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage = inboxesTab.OpenKpisAbstraction();
                kpisPage.SelectUserCreatedTab();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToEdit(labelName);
                kpisPage.ConfigureKPIWithValue("Field", kpiTemplateName, propertyValue1);
                LogInfo($"Configuring the KPI: {labelName} is successfull");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                try
                {
                    kpisPage.DeleteAllUserCreatedKPIs();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying KPI Delete functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252734), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252733_VerifyKPIDeleteFunctionalityTest(string persona, string inbox, string kpiName, string propertyValue1, string propertyValue2, string filterField1, string operator1, string filterValue1)
        {
            KpisPage kpisPage = null;

            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber;
                kpiTemplateName = $"TestValue" + uniqueNumber;

                FilterPage filterPage = inboxesTab.ClickOnFilterOption();
                filterPage.ClickOnAddFilter();
                filterPage.SelectFilterFieldValue(filterField1.Trim(), 1);
                filterPage.SelectOperatorValue(operator1.Trim(), 1);
                filterPage.EnterFilterValue(filterValue1.Trim(), 1);
                filterPage.ClickOnApplyFilter();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                detailsPage.ClickOnCreateLabelButton();
                detailsPage.EnterLabelName(labelName);
                detailsPage.SaveButton[0].Click();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage = inboxesTab.OpenKpisAbstraction();
                kpisPage.SelectUserCreatedTab();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToDelete(labelName);
                kpisPage.VerifyKPIPresent(labelName);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsPageTest")]
        [Description("Verifying KPI Edit functionality;")]
        [Owner("Girishwar.PatilEXTERNAL@westpharma.com")]
        [DynamicData(nameof(DataTransfer.KPIs_252734), typeof(DataTransfer), DynamicDataSourceType.Method)]
        public void TC_252690_VerifyKPIEditFunctionalityTest(string persona, string inbox, string kpiName, string propertyValue1, string propertyValue2, string filterField1, string operator1, string filterValue1)
        {
            KpisPage kpisPage = null;
            FavoritePage favoritePage = null;

            try
            {
                InboxPage inboxesTab = _basePageInstance.NavigateToInboxesTab();
                DetailsPage detailsPage = (DetailsPage)inboxesTab.SearchInboxAndSelectAbstraction(inbox, "Details");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber;
                kpiTemplateName = $"TestValue" + uniqueNumber;

                FilterPage filterPage = inboxesTab.ClickOnFilterOption();
                filterPage.ClickOnAddFilter();
                filterPage.SelectFilterFieldValue(filterField1.Trim(), 1);
                filterPage.SelectOperatorValue(operator1.Trim(), 1);
                filterPage.EnterFilterValue(filterValue1.Trim(), 1);
                filterPage.ClickOnApplyFilter();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                detailsPage.ClickOnCreateLabelButton();
                detailsPage.EnterLabelName(labelName);
                detailsPage.SaveButton[0].Click();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage = inboxesTab.OpenKpisAbstraction();
                kpisPage.SelectUserCreatedTab();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToEdit(labelName);
                kpisPage.ConfigureKPIWithValue("Field", kpiTemplateName, propertyValue1);
                LogInfo($"Configuring the KPI: {labelName} is successfull");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToFavorite(labelName);
                kpisPage.SelectKPIToEdit(labelName);
                kpisPage.ConfigureKPIWithValue("Field", $"Updated_" + kpiTemplateName, propertyValue2);
                LogInfo($"Updating the KPI: {labelName} is successfull");
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                _basePageInstance.BackButton[0].Click();
                WaitForMoment(2);

                favoritePage = _basePageInstance.NavigateToFavoriteTab();
                favoritePage.KPIsAndChartsTab.Click();
                WaitForLoaderToDisappear(_basePageInstance.LoaderImage);

                kpisPage.SelectKPIToZoom(labelName);
                kpisPage.VerifyKPIName($"Updated_" + kpiTemplateName);
                _basePageInstance.BackButton[0].Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                favoritePage.UnfavoriteAllKPIsAndCharts();
            }
        }



    }
}
