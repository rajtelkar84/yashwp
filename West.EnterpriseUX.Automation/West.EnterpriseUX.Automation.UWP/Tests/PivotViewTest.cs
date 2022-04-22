using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("PivotViewTest")]
    [TestClass]
    public class PivotViewTest : BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Create Pivot Functionality;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_139188_VerifyCreatePivotFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickOnPivotGlobalTab();
                _pivotViewAction.ClickPivotCreateButton();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Pivot View Create UI Screen;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_449100_TestCaseToVerifyThePivotViewCreateUIScreen()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyContentsOnPivotPage();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Create Pivot Functionality;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_478601_VerifyCreatePivotFromGlobalSection()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyGlobalPivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickOnPivotGlobalTab();
                _pivotViewAction.ClickPivotCreateButton();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Create Pivot Functionality;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_473807_CreatePivotViewFromCreatedByMe()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickPivotCreateButton();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Test to verify Search functionality in Pivot;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotViewSearch_454555.csv", "PivotViewSearch_454555#csv", DataAccessMethod.Sequential)]
        public void TC_454555_VerifySearchFunctionalityInPivot()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();
                string containsValue = this.TestContext.DataRow["contains"].ToString();
                string startsWithValue = this.TestContext.DataRow["startsWith"].ToString();
                string endsWithValue = this.TestContext.DataRow["endsWith"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyGlobalPivotTabTitle();
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.ClickOnPivotGlobalTab();
                _pivotViewAction.ClickPivotCreateButton();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.SearchAndVerifyPivotWithContains(containsValue);
                _pivotViewAction.SearchAndVerifyPivotWithStartsWith(startsWithValue);
                _pivotViewAction.SearchAndVerifyPivotWithEndsWith(endsWithValue);
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Edit Pivot Functionality;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_451577.csv", "PivotView_451577#csv", DataAccessMethod.Sequential)]
        public void TC_451577_TestCaseToVerifyPivotEditInCreatedByMe()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();
                string updatedmeasure = this.TestContext.DataRow["updatedmeasure"].ToString();
                string updateddimension = this.TestContext.DataRow["updateddimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Pivot" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickOnAddPivotImage();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickEditButtonOnPivot();
                _pivotViewAction.ClearPivotDimension();
                _pivotViewAction.SelectPivotDimensions(updateddimension);
                _pivotViewAction.ClearPivotMeasure();
                _pivotViewAction.SelectPivotMeasures(updatedmeasure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Test to validate the mandatory fields in Pivot;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_454549_ValidateMandatoryFieldsInPivot()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.ClickOnPivotGlobalTab();
                _pivotViewAction.ClickPivotCreateButton();
                _pivotViewAction.ValidatePivotMandatoryFields(pivotTitle, measure);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Test to validate Aggregate type button in Pivot;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotViewSearch_454555.csv", "PivotViewSearch_454555#csv", DataAccessMethod.Sequential)]
        public void TC_486860_ValidateAggregateTypeButtonInPivot()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();
                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyGlobalPivotTabTitle();
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.ClickOnPivotGlobalTab();
                _pivotViewAction.ClickPivotCreateButton();
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ValidateAggregateTypeButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Delete Pivot Functionality;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_451577.csv", "PivotView_451577#csv", DataAccessMethod.Sequential)]
        public void TC_451606_TestCaseToVerifyPivotDelete()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Pivot" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickOnAddPivotImage();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("PivotViewTest")]
        [Description("Tests the Create Pivot from Shared with me Section;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PivotView_139188.csv", "PivotView_139188#csv", DataAccessMethod.Sequential)]
        public void TC_508256_VerifyCreatePivotFromSharedWithMeSection()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string pivotTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                pivotTitle = $"Title" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Pivot View");
                _pivotViewAction.VerifyGlobalPivotTabTitle();
                _pivotViewAction.VerifyCreatedByMePivotTabTitle();
                _pivotViewAction.VerifySharedWithMePivotTabTitle();
                _pivotViewAction.ClickOnPivotCreatedByMeTab();
                _pivotViewAction.DeleteUserCreatedPivot();
                _pivotViewAction.ClickOnPivotSharedWithMeTab();
                _pivotViewAction.ClickPivotCreateButton();
                _inboxAction.EnterLabelName(pivotTitle);
                _pivotViewAction.EnterPivotDescription(description);
                _pivotViewAction.SelectPivotDimensions(dimension);
                _pivotViewAction.SelectPivotMeasures(measure);
                _pivotViewAction.ClickOnPivotGenerateButton();
                _pivotViewAction.ClickOnPivotSaveButton();
                _pivotViewAction.VerifyPivotPresentOnCretedByMeTab(pivotTitle);
                _pivotViewAction.ClickDeleteButtonOnPivot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion
    }
}
