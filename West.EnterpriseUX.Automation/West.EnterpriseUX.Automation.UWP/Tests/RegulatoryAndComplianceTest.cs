using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("RegulatoryAndCompliance")]
    [TestClass]
    public class RegulatoryAndComplianceTest : BaseTest
    {
        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Log in to WD application and Navigate to Regulatory and Compliance page;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_433406.csv", "RequestLOA_433406#csv", DataAccessMethod.Sequential)]
        public void TC_419566_NavigateToRegulatoryAndCompliance()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.MouseHoverPeronaText(persona);
                List<String> rowValues = _inboxAction.GetInboxListNames();

                rowValues.ForEach(value =>
                {
                    NavigateToInboxByInboxSearchOption(function, value);
                    _inboxAction.VerifyInboxPageHeaderText(value);
                });

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Changing the status from New to In Progress for the new LOAs from the Request LOA Inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_419654.csv", "RequestLOA_419654#csv", DataAccessMethod.Sequential)]
        public void TC_419654_ChangeTheStatusOfNewLOAIDsFromNewToInProgress()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify LOA documents Inbox after changing the LOA status from New to In Progress for the new LOAs;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_419656.csv", "RequestLOA_419656#csv", DataAccessMethod.Sequential)]
        public void TC_419656_VerifyLODDocumentsInboxAfterChangingLOAStatusToInProgress()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify LOA PDF Inbox after changing the LOA status from In Progress to Out For Approval;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_419666.csv", "RequestLOA_419666#csv", DataAccessMethod.Sequential)]
        public void TC_419666_VerifyLODPDFInboxAfterChangingLOAStatusToOutForApproval()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOAPDF = this.TestContext.DataRow["inbox_LOAPDF"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string loaPDFTabLabelFirst = this.TestContext.DataRow["loaPDFTabLabelFirst"].ToString();

                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_OutForApproval, loaStatus_OutForApproval);

                NavigateToInboxByInboxSearchOption(function, inbox_LOAPDF);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOAPDF, loaId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the LOA request details are properly imported from the form;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389065.csv", "RequestLOA_389065#csv", DataAccessMethod.Sequential)]
        public void TC_389065_VerifyThatTheLOARequestDetailsAreProperlyImportedFromTheForm()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that Contacts Agency and Item or Products tabs are properly imported from the form;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389067.csv", "RequestLOA_389067#csv", DataAccessMethod.Sequential)]
        public void TC_389067_VerifyThatContactsAgencyAndItemProductsTabsAreProperlyImported()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string formulation = this.TestContext.DataRow["formulation"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string contactsLabel = this.TestContext.DataRow["contactsLabel"].ToString();
                string agencyLabel = this.TestContext.DataRow["agencyLabel"].ToString();
                string itemsLabel = this.TestContext.DataRow["itemsLabel"].ToString();
                string productsLabel = this.TestContext.DataRow["productsLabel"].ToString();
                string itemsOrProductsLabel = itemsLabel + "/" + productsLabel;

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName, formulation, configuration);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, contactsLabel);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId, contactsLabel);
                _requestLOAAction.ClickTabFromEditRequestLOA(agencyLabel);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId, agencyLabel);
                _requestLOAAction.ClickTabFromEditRequestLOA(itemsOrProductsLabel);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId, itemsOrProductsLabel);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that LOA Document is getting generated after switching status from New to InProgress;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389074.csv", "RequestLOA_389074#csv", DataAccessMethod.Sequential)]
        public void TC_389074_VerifyLOADocumentGenerationAfterSwitchingStatusNewToInProgress()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.VerifyDocumentGenerationWhenStatusChange(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, true);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.VerifyDocumentGenerationWhenStatusChange(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the new Product is getting created;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389081.csv", "RequestLOA_389081#csv", DataAccessMethod.Sequential)]
        public void TC_389081_VerifyThatTheNewProductIsCreated()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string alertTitleProductSaved = this.TestContext.DataRow["alertTitleProductSaved"].ToString();
                string alertMesageProductSaved = this.TestContext.DataRow["alertMesageProductSaved"].ToString();

                IDictionary<string, string> newProductValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["formulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["formulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["coatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["washPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["sterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["configuration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["configurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["packingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["status"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["chinaDossierNumber"].ToString()},
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                string newWestItemNumber = _requestLOAAction.GetLatestWestItemCreatedInApplication(inbox);

                string randomString = _requestLOAAction.GenerateRandomString(6);
                newProductValues.Add("title", "ProdName Auto " + randomString);
                newProductValues.Add("specification", "Spec Auto " + randomString);
                newProductValues.Add("index", "Index Auto " + randomString);
                newProductValues.Add("chinaProcesingType", "ChinaProc Auto " + randomString);
                newProductValues.Add("westItemNumber", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.CreateNewProduct(alertTitleProductSaved, alertMesageProductSaved, (Dictionary<string, string>)newProductValues);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, newWestItemNumber, "All", "WestItem");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the LOA Word Documents is possible to update and validate the metadata;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389083.csv", "RequestLOA_389083#csv", DataAccessMethod.Sequential)]
        public void TC_389083_VerifyLOAWordDocumentsIsPossibleToUpdate()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string formulation = this.TestContext.DataRow["formulation"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string configurationType = this.TestContext.DataRow["configurationType"].ToString();
                string editDocumentsMetadataAction = this.TestContext.DataRow["editDocumentsMetadataAction"].ToString();
                string templates = this.TestContext.DataRow["templates"].ToString();
                string agencyEntry = this.TestContext.DataRow["agencyEntry"].ToString();
                string coating = this.TestContext.DataRow["coating"].ToString();
                string washPlant = this.TestContext.DataRow["washPlant"].ToString();
                string sterilePlant = this.TestContext.DataRow["sterilePlant"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName, formulation, configuration);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.ValidateLOADocumentMetadata(inbox_LOADocuments, loaId, editDocumentsMetadataAction, templates, agencyEntry, coating, washPlant, sterilePlant, appTypeOne, itemNoOne, itemDescriptionOne, configurationType);
                _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify LOA PDF Inbox after changing the LOA status from In Progress to Out For Approval;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389088.csv", "RequestLOA_389088#csv", DataAccessMethod.Sequential)]
        public void TC_389088_VerifyPDFDocumentsGenerationWhenChangingLOAStatusToOutForApproval()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOAPDF = this.TestContext.DataRow["inbox_LOAPDF"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string loaPDFTabLabelFirst = this.TestContext.DataRow["loaPDFTabLabelFirst"].ToString();

                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_OutForApproval, loaStatus_OutForApproval);

                NavigateToInboxByInboxSearchOption(function, inbox_LOAPDF);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOAPDF, loaId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox_LOAPDF, "Review Loa PDF");
                _requestLOAAction.ValidatePDFExistance();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Ability to add standard email statements in request that are included in the final email;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389131.csv", "RequestLOA_389131#csv", DataAccessMethod.Sequential)]
        public void TC_389131_VerifyStandardEmailStatementsInRequest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                List<String> emailStatementCheckboxItems = (this.TestContext.DataRow["emailStatementCheckboxItems"].ToString())?.Split(';').ToList();

                string loaId = CreateLOAIDInWestDigitalApplication();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.AddStandardEmailStatement(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress, emailStatementCheckboxItems);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
                _requestLOAAction.GetLOAIDFromRequestLOAPage(loaId);
                _requestLOAAction.ValidateEmailStatementTextboxes(true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Delete LOA PDF functionality;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_402829.csv", "RequestLOA_402829#csv", DataAccessMethod.Sequential)]
        public void TC_402829_VerifyDeleteLOAPDFFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOAPDF = this.TestContext.DataRow["inbox_LOAPDF"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string deletLoaPdfAction = this.TestContext.DataRow["deletLoaPdfAction"].ToString();
                string alertTitleDeleteLOAPDF = this.TestContext.DataRow["alertTitleDeleteLOAPDF"].ToString();
                string alertMesageDeleteLOAPDF = this.TestContext.DataRow["alertMesageDeleteLOAPDF"].ToString();
                string loaPDFTabLabelFirst = this.TestContext.DataRow["loaPDFTabLabelFirst"].ToString();

                string loaId = CreateLOAIDInWestDigitalApplication();
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_OutForApproval, loaStatus_OutForApproval);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOAPDF);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOAPDF, loaId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));
                _requestLOAAction.DeleteLOAFilesFromAction(inbox_LOAPDF, deletLoaPdfAction, alertTitleDeleteLOAPDF, alertMesageDeleteLOAPDF, loaPDFTabLabelFirst);
                _requestLOAAction.ValidateDataNonExistanceInInboxHomepage(loaId, inbox_LOAPDF, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Validate File Name of the generated PDF in LOA PDF page;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_404672.csv", "RequestLOA_404672#csv", DataAccessMethod.Sequential)]
        public void TC_404672_ValidateGeneratedLOAPDFFileName()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOAPDF = this.TestContext.DataRow["inbox_LOAPDF"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string loaPDFTabLabelFirst = this.TestContext.DataRow["loaPDFTabLabelFirst"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName);
                string custCompanyName = String.Concat(_requestLOAAction.GetCustomerCompanyName().ToLower().Trim().Where(c => !Char.IsWhiteSpace(c))).Substring(0, 10);
                string requestDate = (DateTime.ParseExact(_requestLOAAction.GetDateRequested(), "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)).ToString("ddMMMyyyy");

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                string documentId = _requestLOAAction.UpdateLOADocument(inbox_LOADocuments, loaId, editLoaDocumentAction, alertTitleDocumentUpdate, alertMesageDocumentUpdate);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_OutForApproval, loaStatus_OutForApproval);

                NavigateToInboxByInboxSearchOption(function, inbox_LOAPDF);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOAPDF, documentId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));

                _requestLOAAction.ScrollHorizontally_LOAPages(6);
                string expectedPDFFileName = "loa-" + documentId + "-" + custCompanyName + "-" + requestDate + ".pdf";
                string observedPDFFileName = _requestLOAAction.GetRowValues(1)[1];
                Assert.AreEqual(expectedPDFFileName, observedPDFFileName, "The LOA PDF filename, '" + observedPDFFileName + "' is diplayed instead of '"+ expectedPDFFileName + "' in 'LOA PDF' page");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Delete LOA Documents functionality;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_402284.csv", "RequestLOA_402284#csv", DataAccessMethod.Sequential)]
        public void TC_402284_VerifyDeleteLOADocumentsFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string deletLoaDocumentAction = this.TestContext.DataRow["deletLoaDocumentAction"].ToString();
                string alertTitleDeleteLOADocument = this.TestContext.DataRow["alertTitleDeleteLOADocument"].ToString();
                string alertMesageDeleteLOADocument = this.TestContext.DataRow["alertMesageDeleteLOADocument"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication();
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                _requestLOAAction.DeleteLOAFilesFromAction(inbox_LOADocuments, deletLoaDocumentAction, alertTitleDeleteLOADocument, alertMesageDeleteLOADocument, loaDocumentsTabLabelFirst);
                _requestLOAAction.ValidateDataNonExistanceInInboxHomepage(loaId, inbox_LOADocuments, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Validate LOA Document generation with Missing template;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_421943.csv", "RequestLOA_421943#csv", DataAccessMethod.Sequential)]
        public void TC_421943_ValidateLOADocumentGenerationWithMissingTemplate()
        {//475496
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string formulation = this.TestContext.DataRow["formulation"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string alertMessageNoProductAdded = this.TestContext.DataRow["alertMessageNoProductAdded"].ToString();
                string itemNoOne = "555" + _requestLOAAction.GenerateRandomDigits(5);

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName, formulation, configuration);

                NavigateToInboxByInboxSearchOption(function, inbox);                
                _requestLOAAction.ChangeLOAStatusWithMissingTemplate(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress, alertMessageNoProductAdded);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.ValidateMissingProductTemplate(inbox_LOADocuments, loaId, editLoaDocumentAction, itemNoOne);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Deletion of  Missing  product template;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_422012.csv", "RequestLOA_422012#csv", DataAccessMethod.Sequential)]
        public void TC_422012_VerifyDeleteMissingProductTemplate()
        {//464025
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string formulation = this.TestContext.DataRow["formulation"].ToString();
                string configuration = this.TestContext.DataRow["configuration"].ToString();
                string alertMessageNoProductAdded = this.TestContext.DataRow["alertMessageNoProductAdded"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string deletLoaDocumentAction = this.TestContext.DataRow["deletLoaDocumentAction"].ToString();
                string alertTitleDeleteLOADocument = this.TestContext.DataRow["alertTitleDeleteLOADocument"].ToString();
                string alertMesageDeleteLOADocument = this.TestContext.DataRow["alertMesageDeleteLOADocument"].ToString();
                string itemNoOne = "777" + _requestLOAAction.GenerateRandomDigits(5);

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName, formulation, configuration);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatusWithMissingTemplate(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress, alertMessageNoProductAdded);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.ValidateMissingProductTemplate(inbox_LOADocuments, loaId, editLoaDocumentAction, itemNoOne);
                _requestLOAAction.ClickBackButton();
                _requestLOAAction.DeleteLOAFilesFromAction(inbox_LOADocuments, deletLoaDocumentAction, alertTitleDeleteLOADocument, alertMesageDeleteLOADocument, loaDocumentsTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Generate LOA word documents for the templates 3 west items 4HC agency and LOA Formulation Westar RS Jersey Shore Pharma Steam Sterilization;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389141.csv", "RequestLOA_389141#csv", DataAccessMethod.Sequential)]
        public void TC_389141_VerifyLOAWordDocumentGenerationFor3WestItemsNumbers()
        {//There are some mismatches in the count of generated files. Based on the bug464058, I modified the Automation suite
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication("ThreeEntry");

                IDictionary<string, string> fileReferenceAppAgency = new Dictionary<string, string>();
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_CDER"].ToString(), this.TestContext.DataRow["fileRefAppAgency_CDER_Count"].ToString());
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_CBER"].ToString(), this.TestContext.DataRow["fileRefAppAgency_CBER_Count"].ToString());
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_CDRH"].ToString(), this.TestContext.DataRow["fileRefAppAgency_CDRH_Count"].ToString());
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_HC"].ToString(), this.TestContext.DataRow["fileRefAppAgency_HC_Count"].ToString());
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                foreach (var appAgencyValue in fileReferenceAppAgency)
                    _requestLOAAction.ValidateEachAppAgencyLOADocumentsCount(inbox_LOADocuments, appAgencyValue.Key, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))), loaDocumentsTabLabelFirst, Convert.ToInt32(appAgencyValue.Value));

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Generate LOA word documents for the following templates items 0000-0000 2agency Daikyo email and LOA for Contract Lab;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_393706.csv", "RequestLOA_393706#csv", DataAccessMethod.Sequential)]
        public void TC_393706_VerifyLOAWordDocumentGenerationForZeroWestItemsNumbers()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication("ZeroEntry");

                IDictionary<string, string> fileReferenceAppAgency = new Dictionary<string, string>();
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_CDER"].ToString(), this.TestContext.DataRow["fileRefAppAgency_CDER_Count"].ToString());
                fileReferenceAppAgency.Add(loaId + "_" + this.TestContext.DataRow["fileRefAppAgency_HC"].ToString(), this.TestContext.DataRow["fileRefAppAgency_HC_Count"].ToString());

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                foreach (var appAgencyValue in fileReferenceAppAgency)
                    _requestLOAAction.ValidateEachAppAgencyLOADocumentsCount(inbox_LOADocuments, appAgencyValue.Key, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))), loaDocumentsTabLabelFirst, Convert.ToInt32(appAgencyValue.Value));

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Ability to run a request for 3 West item numbers and 4 agencies;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_389077.csv", "RequestLOA_389077#csv", DataAccessMethod.Sequential)]
        public void TC_389077_VerifyLOARequestForThreeWestItemNumbersAndFourAgencies()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string agencyLabel = this.TestContext.DataRow["agencyLabel"].ToString();
                string itemsLabel = this.TestContext.DataRow["itemsLabel"].ToString();
                string productsLabel = this.TestContext.DataRow["productsLabel"].ToString();
                string itemsOrProductsLabel = itemsLabel + "/" + productsLabel;

                string loaId = CreateLOAIDInWestDigitalApplication("ThreeEntry");

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);

                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, agencyLabel);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId, agencyLabel);
                _requestLOAAction.ClickTabFromEditRequestLOA(itemsOrProductsLabel);
                _requestLOAAction.ValidateEditRequestLoaPageElements(loaId, itemsOrProductsLabel);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Agency inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_443476.csv", "RequestLOA_443476#csv", DataAccessMethod.Sequential)]
        public void TC_443476_VerifyAgencyInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string agencyTabLabelFirst = this.TestContext.DataRow["agencyTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleAgencySaved = this.TestContext.DataRow["alertTitleAgencySaved"].ToString();
                string alertMesageAgencySaved = this.TestContext.DataRow["alertMesageAgencySaved"].ToString();
                string updateSelectedAgencyAction = this.TestContext.DataRow["updateSelectedAgencyAction"].ToString();
                string updateAgencyPageTitle = this.TestContext.DataRow["updateAgencyPageTitle"].ToString();
                string newAgencyPageTitle = this.TestContext.DataRow["newAgencyPageTitle"].ToString();
                List<String> agencyNameAbbreviation = (this.TestContext.DataRow["agencyNameAbbreviation"].ToString())?.Split(';').ToList();
                string newAgencyCreationButtonText = this.TestContext.DataRow["newAgencyCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string randomStringOne = _requestLOAAction.GenerateRandomString(5);
                string randomStringTwo = _requestLOAAction.GenerateRandomString(5);
                string randomStringThree = _requestLOAAction.GenerateRandomString(5);

                string agencyName = "Agency Name " + randomStringOne + " " + randomStringTwo + " " + randomStringThree;
                string parentAgency = "Parent Agency " + randomStringOne + " " + randomStringTwo + " " + randomStringThree;
                string agencyAddress = "Address1" + _requestLOAAction.GenerateRandomString(5) + ", Address2" + _requestLOAAction.GenerateRandomString(5) + ", Address3" + _requestLOAAction.GenerateRandomString(5) + ", City" + randomStringOne + ", State" + randomStringTwo + ", Country" + randomStringThree + ", " + _requestLOAAction.GenerateRandomDigits(6);
                string agencyAbbr = "";
                agencyName.Split(' ').ToList().ForEach(i => agencyAbbr += i[0].ToString().ToUpper());
                string agencyAbbreviation = _requestLOAAction.ReverseString(agencyAbbr);

                string updatedAgencyName = "Updated" + agencyName;
                string updatedParentAgency = "Updated" + parentAgency;
                string updatedAgencyAddress = "Updated" + agencyAddress;
                string updatedAgencyAbbreviation = "U" + agencyAbbreviation;

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "agencyName", agencyName},
                    { "parentAgency", parentAgency},
                    { "agencyAddress", agencyAddress},
                    { "agencyAbbreviation", agencyAbbreviation}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "agencyName", updatedAgencyName},
                    { "parentAgency", updatedParentAgency},
                    { "agencyAddress", updatedAgencyAddress},
                    { "agencyAbbreviation", updatedAgencyAbbreviation}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateAgenciesInAgencyInbox(inbox, agencyTabLabelFirst, agencyNameAbbreviation);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newAgencyCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newAgencyCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newAgencyPageTitle, alertTitleAgencySaved, alertMesageAgencySaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, agencyTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, agencyTabLabelFirst, updateSelectedAgencyAction, updateAgencyPageTitle, alertTitleAgencySaved, alertMesageAgencySaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, agencyTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Request LOA for Product are in Ready for Review Status;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_448237.csv", "RequestLOA_448237#csv", DataAccessMethod.Sequential)]
        public void TC_448237_VerifyRequestLOAForProductAreInReadyForReviewStatus()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_Product = this.TestContext.DataRow["inbox_Product"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string alertTitleProductSaved = this.TestContext.DataRow["alertTitleProductSaved"].ToString();
                string alertMesageProductSaved = this.TestContext.DataRow["alertMesageProductSaved"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertMessageNoProductAdded = this.TestContext.DataRow["alertMessageNoProductAdded"].ToString();
                string tabNameLoaProducts = this.TestContext.DataRow["tabNameLoaProducts"].ToString();

                IDictionary<string, string> newProductValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["formulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["formulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["coatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["washPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["sterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["configuration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["configurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["packingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["status"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["chinaDossierNumber"].ToString()},
                };


                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                string newWestItemNumber = _requestLOAAction.GetLatestWestItemCreatedInApplication(inbox_Product);

                string randomString = _requestLOAAction.GenerateRandomString(6);
                newProductValues.Add("title", "ProdName Auto " + randomString);
                newProductValues.Add("specification", "Spec Auto " + randomString);
                newProductValues.Add("index", "Index Auto " + randomString);
                newProductValues.Add("chinaProcesingType", "ChinaProc Auto " + randomString);
                newProductValues.Add("westItemNumber", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                _requestLOAAction.CreateNewProduct(alertTitleProductSaved, alertMesageProductSaved, (Dictionary<string, string>)newProductValues);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_Product, newWestItemNumber, "All", "WestItem");

                string loaId = CreateLOAIDInWestDigitalApplication("ProductEntry", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLoaProductForApprovedUnapprovedWestItem(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress, alertMessageNoProductAdded, tabNameLoaProducts, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Request LOA for Product are in Ready for Review Status then changing to Approved;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_448274.csv", "RequestLOA_448274#csv", DataAccessMethod.Sequential)]
        public void TC_448274_VerifyRequestLOAForProductAreInReadyForReviewStatusThenToApproved()
        {//467689
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_Product = this.TestContext.DataRow["inbox_Product"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string alertTitleProductSaved = this.TestContext.DataRow["alertTitleProductSaved"].ToString();
                string alertMesageProductSaved = this.TestContext.DataRow["alertMesageProductSaved"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertMessageNoProductAdded = this.TestContext.DataRow["alertMessageNoProductAdded"].ToString();
                string tabNameLoaProducts = this.TestContext.DataRow["tabNameLoaProducts"].ToString();
                string targetStatus = this.TestContext.DataRow["targetStatus"].ToString();
                string updateSelectedProductAction = this.TestContext.DataRow["updateSelectedProductAction"].ToString();
                string productTabLabelFirst = this.TestContext.DataRow["productTabLabelFirst"].ToString();
                string searchingItem = this.TestContext.DataRow["searchingItem"].ToString();
                string alertTitleStatusChanged_InProgress = this.TestContext.DataRow["alertTitleStatusChanged_InProgress"].ToString();
                string alertMesageStatusChanged_InProgress = this.TestContext.DataRow["alertMesageStatusChanged_InProgress"].ToString();

                IDictionary<string, string> newProductValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["formulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["formulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["coatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["washPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["sterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["configuration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["configurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["packingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["status"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["chinaDossierNumber"].ToString()},
                };


                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                string newWestItemNumber = _requestLOAAction.GetLatestWestItemCreatedInApplication(inbox_Product);

                string randomString = _requestLOAAction.GenerateRandomString(6);
                newProductValues.Add("title", "ProdName Auto " + randomString);
                newProductValues.Add("specification", "Spec Auto " + randomString);
                newProductValues.Add("index", "Index Auto " + randomString);
                newProductValues.Add("chinaProcesingType", "ChinaProc Auto " + randomString);
                newProductValues.Add("westItemNumber", newWestItemNumber);
                
                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                _requestLOAAction.CreateNewProduct(alertTitleProductSaved, alertMesageProductSaved, (Dictionary<string, string>)newProductValues);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_Product, newWestItemNumber, productTabLabelFirst, searchingItem);
                
                string loaId = CreateLOAIDInWestDigitalApplication("ProductEntry", newWestItemNumber);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLoaProductForApprovedUnapprovedWestItem(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress, alertMessageNoProductAdded, tabNameLoaProducts, true);

                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                _requestLOAAction.ChangeProductStatus(inbox_Product, newWestItemNumber, updateSelectedProductAction, targetStatus, alertTitleProductSaved, alertMesageProductSaved, productTabLabelFirst, searchingItem);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLoaProductForApprovedUnapprovedWestItem(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChanged_InProgress, alertMesageStatusChanged_InProgress, alertMessageNoProductAdded, tabNameLoaProducts, false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Application Type inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_451418.csv", "RequestLOA_451418#csv", DataAccessMethod.Sequential)]
        public void TC_451418_VerifyApplicationTypeInboxAddOrUpdateFunctionality()
        {//468425, 468428, 468431
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string applicationTypeTabLabelFirst = this.TestContext.DataRow["applicationTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleApplicationTypeSaved = this.TestContext.DataRow["alertTitleApplicationTypeSaved"].ToString();
                string alertMesageApplicationTypeSaved = this.TestContext.DataRow["alertMesageApplicationTypeSaved"].ToString();
                string updateSelectedApplicationTypeAction = this.TestContext.DataRow["updateSelectedApplicationTypeAction"].ToString();
                string updateApplicationTypePageTitle = this.TestContext.DataRow["updateApplicationTypePageTitle"].ToString();
                string newApplicationTypePageTitle = this.TestContext.DataRow["newApplicationTypePageTitle"].ToString();
                string newApplicationTypeCreationButtonText = this.TestContext.DataRow["newApplicationTypeCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string applicationTypeName = "ApplicationType " + _requestLOAAction.GenerateRandomString(8);
                string updatedApplicationTypeName = applicationTypeName.Replace("ApplicationType", "UpdatedAppType");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", applicationTypeName}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedApplicationTypeName}
                };
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newApplicationTypeCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newApplicationTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newApplicationTypePageTitle, alertTitleApplicationTypeSaved, alertMesageApplicationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, applicationTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, applicationTypeTabLabelFirst, updateSelectedApplicationTypeAction, updateApplicationTypePageTitle, alertTitleApplicationTypeSaved, alertMesageApplicationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, applicationTypeTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Coating inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452031.csv", "RequestLOA_452031#csv", DataAccessMethod.Sequential)]
        public void TC_452031_VerifyCoatingInboxAddOrUpdateFunctionality()
        {//468425, 468427, 468428, 468429, 468431
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string coatingTabLabelFirst = this.TestContext.DataRow["coatingTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleCoatingSaved = this.TestContext.DataRow["alertTitleCoatingSaved"].ToString();
                string alertMesageCoatingSaved = this.TestContext.DataRow["alertMesageCoatingSaved"].ToString();
                string updateSelectedCoatingAction = this.TestContext.DataRow["updateSelectedCoatingAction"].ToString();
                string updateCoatingPageTitle = this.TestContext.DataRow["updateCoatingPageTitle"].ToString();
                string newCoatingPageTitle = this.TestContext.DataRow["newCoatingPageTitle"].ToString();
                string newCoatingCreationButtonText = this.TestContext.DataRow["newCoatingCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string coatingName = "Coating " + _requestLOAAction.GenerateRandomString(8);
                string updatedCoatingName = "Updated" + coatingName;

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", coatingName}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedCoatingName}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newCoatingCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newCoatingCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newCoatingPageTitle, alertTitleCoatingSaved, alertMesageCoatingSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, coatingTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, coatingTabLabelFirst, updateSelectedCoatingAction, updateCoatingPageTitle, alertTitleCoatingSaved, alertMesageCoatingSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, coatingTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Coating DMF inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452125.csv", "RequestLOA_452125#csv", DataAccessMethod.Sequential)]
        public void TC_452125_VerifyCoatingDMFInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string coatingDmfTabLabelFirst = this.TestContext.DataRow["coatingDmfTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleCoatingDmfSaved = this.TestContext.DataRow["alertTitleCoatingDmfSaved"].ToString();
                string alertMesageCoatingDmfSaved = this.TestContext.DataRow["alertMesageCoatingDmfSaved"].ToString();
                string updateSelectedCoatingDmfAction = this.TestContext.DataRow["updateSelectedCoatingDmfAction"].ToString();
                string updateCoatingDmfPageTitle = this.TestContext.DataRow["updateCoatingDmfPageTitle"].ToString();
                string newCoatingDmfPageTitle = this.TestContext.DataRow["newCoatingPageTitle"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string coatingName = this.TestContext.DataRow["coatingName"].ToString();
                string updatedAgencyName = this.TestContext.DataRow["updateAgencyName"].ToString();
                string updatedCoatingName = this.TestContext.DataRow["updateCoatingName"].ToString();
                string newCoatingDmfCreationButtonText = this.TestContext.DataRow["newCoatingDmfCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string coatingLocation = "CoatingDmf " + _requestLOAAction.GenerateRandomString(8);
                string updatedCoatingLocation = coatingLocation.Replace("CoatingDmf", "UpdatedCtDmf");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "coatingLocation", coatingLocation},
                    { "agencyName", agencyName},
                    { "coatingName", coatingName}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "coatingLocation", updatedCoatingLocation},
                    { "agencyName", updatedAgencyName},
                    { "coatingName", updatedCoatingName}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newCoatingDmfCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newCoatingDmfCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newCoatingDmfPageTitle, alertTitleCoatingDmfSaved, alertMesageCoatingDmfSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, coatingDmfTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, coatingDmfTabLabelFirst, updateSelectedCoatingDmfAction, updateCoatingDmfPageTitle, alertTitleCoatingDmfSaved, alertMesageCoatingDmfSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, coatingDmfTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Configuration inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452527.csv", "RequestLOA_452527#csv", DataAccessMethod.Sequential)]
        public void TC_452527_VerifyConfigurationInboxAddOrUpdateFunctionality()
        {//479111
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string configurationTabLabelFirst = this.TestContext.DataRow["configurationTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleConfigurationSaved = this.TestContext.DataRow["alertTitleConfigurationSaved"].ToString();
                string alertMesageConfigurationSaved = this.TestContext.DataRow["alertMesageConfigurationSaved"].ToString();
                string updateSelectedConfigurationAction = this.TestContext.DataRow["updateSelectedConfigurationAction"].ToString();
                string updateConfigurationPageTitle = this.TestContext.DataRow["updateConfigurationPageTitle"].ToString();
                string newConfigurationPageTitle = this.TestContext.DataRow["newConfigurationPageTitle"].ToString();
                string newConfigurationCreationButtonText = this.TestContext.DataRow["newConfigurationCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string configurationName = "Configuration " + _requestLOAAction.GenerateRandomString(8);
                string updatedConfigurationName = configurationName.Replace("Configuration", "UpdatedConfig");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", configurationName}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedConfigurationName}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newConfigurationCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newConfigurationCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newConfigurationPageTitle, alertTitleConfigurationSaved, alertMesageConfigurationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, configurationTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, configurationTabLabelFirst, updateSelectedConfigurationAction, updateConfigurationPageTitle, alertTitleConfigurationSaved, alertMesageConfigurationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, configurationTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Configuration Type inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452534.csv", "RequestLOA_452534#csv", DataAccessMethod.Sequential)]
        public void TC_452534_VerifyConfigurationTypeInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string configurationTypeTabLabelFirst = this.TestContext.DataRow["configurationTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleConfigurationTypeSaved = this.TestContext.DataRow["alertTitleConfigurationTypeSaved"].ToString();
                string alertMesageConfigurationTypeSaved = this.TestContext.DataRow["alertMesageConfigurationTypeSaved"].ToString();
                string updateSelectedConfigurationTypeAction = this.TestContext.DataRow["updateSelectedConfigurationTypeAction"].ToString();
                string updateConfigurationTypePageTitle = this.TestContext.DataRow["updateConfigurationTypePageTitle"].ToString();
                string newConfigurationTypePageTitle = this.TestContext.DataRow["newConfigurationTypePageTitle"].ToString();
                string newConfigurationTypeCreationButtonText = this.TestContext.DataRow["newConfigurationTypeCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string configurationType = "ConfigurationType " + _requestLOAAction.GenerateRandomString(8);
                string updatedConfigurationType = configurationType.Replace("ConfigurationType", "UpdatedCT");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", configurationType}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedConfigurationType}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newConfigurationTypeCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newConfigurationTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newConfigurationTypePageTitle, alertTitleConfigurationTypeSaved, alertMesageConfigurationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, configurationTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, configurationTypeTabLabelFirst, updateSelectedConfigurationTypeAction, updateConfigurationTypePageTitle, alertTitleConfigurationTypeSaved, alertMesageConfigurationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, configurationTypeTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify DMF inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452686.csv", "RequestLOA_452686#csv", DataAccessMethod.Sequential)]
        public void TC_452686_VerifyDMFInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string dmfTabLabelFirst = this.TestContext.DataRow["dmfTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleDmfSaved = this.TestContext.DataRow["alertTitleDmfSaved"].ToString();
                string alertMesageDmfSaved = this.TestContext.DataRow["alertMesageDmfSaved"].ToString();
                string updateSelectedDmfAction = this.TestContext.DataRow["updateSelectedDmfAction"].ToString();
                string updateDmfPageTitle = this.TestContext.DataRow["updateDmfPageTitle"].ToString();
                string newDmfPageTitle = this.TestContext.DataRow["newDmfPageTitle"].ToString();
                string newDmfCreationButtonText = this.TestContext.DataRow["newDmfCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string updatedAgencyName = this.TestContext.DataRow["updatedAgencyName"].ToString();
                string loaTemplateName = this.TestContext.DataRow["loaTemplateName"].ToString();
                string updatedLoaTemplateName = this.TestContext.DataRow["updatedLoaTemplateName"].ToString();
                string plant = this.TestContext.DataRow["plant"].ToString();
                string updatedPlant = this.TestContext.DataRow["updatedPlant"].ToString();

                string randomText = _requestLOAAction.GenerateRandomString(8);
                string dmfDescription = "Dmf Description " + randomText;
                string dmfNumber = "DMF 9" + _requestLOAAction.GenerateRandomDigits(6);
                string dmfProcessType = "Dmf Process Type " + randomText;
                string dmfTitleText = "Dmf Title Text " + randomText;
                string dmfType = "Type II";
                string dmfDisclaimer = "Dmf Disclaimer " + _requestLOAAction.GenerateRandomString(10) + " " + _requestLOAAction.GenerateRandomString(10) + " " + _requestLOAAction.GenerateRandomString(10) + " " + randomText;
                string updatedDmfDescription = "Updated " + dmfDescription;
                string updatedDmfNumber = dmfNumber.Replace("DMF", "UDMF");
                string updatedDmfProcessType = "Updated " + dmfProcessType;
                string updatedDmfTitleText = "Updated " + dmfTitleText;
                string updatedDmfType = "Type III";
                string updatedDmfDisclaimer = "Updated " + dmfDisclaimer;

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "agencyName", agencyName},
                    { "dmfDescription", dmfDescription},
                    { "dmfNumber", dmfNumber},
                    { "dmfProcessType", dmfProcessType},
                    { "dmfTitleText", dmfTitleText},
                    { "dmfType", dmfType},
                    { "loaTemplateName", loaTemplateName},
                    { "plant", plant},
                    { "dmfDisclaimer", dmfDisclaimer}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "agencyName", updatedAgencyName},
                    { "dmfDescription", updatedDmfDescription},
                    { "dmfNumber", updatedDmfNumber},
                    { "dmfProcessType", updatedDmfProcessType},
                    { "dmfTitleText", updatedDmfTitleText},
                    { "dmfType", updatedDmfType},
                    { "loaTemplateName", loaTemplateName},
                    { "plant", plant},
                    { "dmfDisclaimer", updatedDmfDisclaimer}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newDmfCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newDmfCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newDmfPageTitle, alertTitleDmfSaved, alertMesageDmfSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, dmfTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, dmfTabLabelFirst, updateSelectedDmfAction, updateDmfPageTitle, alertTitleDmfSaved, alertMesageDmfSaved);
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, dmfTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify DMF Number inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452705.csv", "RequestLOA_452705#csv", DataAccessMethod.Sequential)]
        public void TC_452705_VerifyDMFNumberInboxAddOrUpdateFunctionality()
        {//477867, 477771, 479014, 479022
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string dmfNumberTabLabelFirst = this.TestContext.DataRow["dmfNumberTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleDmfNumberSaved = this.TestContext.DataRow["alertTitleDmfNumberSaved"].ToString();
                string alertMesageDmfNumberSaved = this.TestContext.DataRow["alertMesageDmfNumberSaved"].ToString();
                string updateSelectedDmfNumberAction = this.TestContext.DataRow["updateSelectedDmfNumberAction"].ToString();
                string updateDmfNumberPageTitle = this.TestContext.DataRow["updateDmfNumberPageTitle"].ToString();
                string newDmfNumberPageTitle = this.TestContext.DataRow["newDmfNumberPageTitle"].ToString();
                string newDmfNumberCreationButtonText = this.TestContext.DataRow["newDmfNumberCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string dmfNumber = "DMFN 9" + _requestLOAAction.GenerateRandomDigits(6);
                string updatedDmfNumber = dmfNumber.Replace("DMFN", "UDMFN");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", dmfNumber}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedDmfNumber}
                };

                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newDmfNumberCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newDmfNumberCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newDmfNumberPageTitle, alertTitleDmfNumberSaved, alertMesageDmfNumberSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, dmfNumberTabLabelFirst);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, dmfNumberTabLabelFirst, updateSelectedDmfNumberAction, updateDmfNumberPageTitle, alertTitleDmfNumberSaved, alertMesageDmfNumberSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, dmfNumberTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Document Type inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_452767.csv", "RequestLOA_452767#csv", DataAccessMethod.Sequential)]
        public void TC_452767_VerifyDocumentTypeInboxAddOrUpdateFunctionality()
        {//478541, 478908, 478907, 479399
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string documentTypeTabLabelFirst = this.TestContext.DataRow["documentTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleDocumentTypeSaved = this.TestContext.DataRow["alertTitleDocumentTypeSaved"].ToString();
                string alertMesageDocumentTypeSaved = this.TestContext.DataRow["alertMesageDocumentTypeSaved"].ToString();
                string updateSelectedDocumentTypeAction = this.TestContext.DataRow["updateSelectedDocumentTypeAction"].ToString();
                string updateDocumentTypePageTitle = this.TestContext.DataRow["updateDocumentTypePageTitle"].ToString();
                string newDocumentTypePageTitle = this.TestContext.DataRow["newDocumentTypePageTitle"].ToString();
                string newDocumentTypeCreationButtonText = this.TestContext.DataRow["newDocumentTypeCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string documentType = "DocumentType " + _requestLOAAction.GenerateRandomString(8);
                string updatedDocumentType = documentType.Replace("DocumentType", "UpdateDT");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", documentType}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedDocumentType}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newDocumentTypeCreationButtonText);
                
                _requestLOAAction.CreateNewInboxItem(inbox, newDocumentTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newDocumentTypePageTitle, alertTitleDocumentTypeSaved, alertMesageDocumentTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, documentTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, documentTypeTabLabelFirst, updateSelectedDocumentTypeAction, updateDocumentTypePageTitle, alertTitleDocumentTypeSaved, alertMesageDocumentTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, documentTypeTabLabelFirst);
                
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Drug Classification inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_453256.csv", "RequestLOA_453256#csv", DataAccessMethod.Sequential)]
        public void TC_453256_VerifyDrugClassificationInboxAddOrUpdateFunctionality()
        {//479392, 479311, 479306
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string drugClassificationTabLabelFirst = this.TestContext.DataRow["drugClassificationTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleDrugClassificationSaved = this.TestContext.DataRow["alertTitleDrugClassificationSaved"].ToString();
                string alertMesageDrugClassificationSaved = this.TestContext.DataRow["alertMesageDrugClassificationSaved"].ToString();
                string updateSelectedDrugClassificationAction = this.TestContext.DataRow["updateSelectedDrugClassificationAction"].ToString();
                string updateDrugClassificationPageTitle = this.TestContext.DataRow["updateDrugClassificationPageTitle"].ToString();
                string newDrugClassificationPageTitle = this.TestContext.DataRow["newDrugClassificationPageTitle"].ToString();
                string newDrugClassificationCreationButtonText = this.TestContext.DataRow["newDrugClassificationCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string drugClassification = "DrugClassification " + _requestLOAAction.GenerateRandomString(8);
                string updatedDrugClassification = drugClassification.Replace("DrugClassification", "UpdateDC");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", drugClassification}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedDrugClassification}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newDrugClassificationCreationButtonText);
                
                _requestLOAAction.CreateNewInboxItem(inbox, newDrugClassificationCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newDrugClassificationPageTitle, alertTitleDrugClassificationSaved, alertMesageDrugClassificationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, drugClassificationTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, drugClassificationTabLabelFirst, updateSelectedDrugClassificationAction, updateDrugClassificationPageTitle, alertTitleDrugClassificationSaved, alertMesageDrugClassificationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, drugClassificationTabLabelFirst);
                
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Formulation Type inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_453985.csv", "RequestLOA_453985#csv", DataAccessMethod.Sequential)]
        public void TC_453985_VerifyFormulationTypeInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string formulationTypeTabLabelFirst = this.TestContext.DataRow["formulationTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleFormulationTypeSaved = this.TestContext.DataRow["alertTitleFormulationTypeSaved"].ToString();
                string alertMesageFormulationTypeSaved = this.TestContext.DataRow["alertMesageFormulationTypeSaved"].ToString();
                string updateSelectedFormulationTypeAction = this.TestContext.DataRow["updateSelectedFormulationTypeAction"].ToString();
                string updateFormulationTypePageTitle = this.TestContext.DataRow["updateFormulationTypePageTitle"].ToString();
                string newFormulationTypePageTitle = this.TestContext.DataRow["newFormulationTypePageTitle"].ToString();
                string newFormulationTypeCreationButtonText = this.TestContext.DataRow["newFormulationTypeCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string formulationType = "FormulationType " + _requestLOAAction.GenerateRandomString(8);
                string titleEntry = "Title " + _requestLOAAction.GenerateRandomString(8);
                string updatedFormulationType = formulationType.Replace("FormulationType", "UpdateFT");
                string updatedTitleEntry = titleEntry.Replace("Title", "UpdateTtl");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "formulationType", formulationType},
                    { "titleEntry", titleEntry}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "formulationType", updatedFormulationType},
                    { "titleEntry", updatedTitleEntry}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newFormulationTypeCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newFormulationTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newFormulationTypePageTitle, alertTitleFormulationTypeSaved, alertMesageFormulationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, formulationTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, formulationTypeTabLabelFirst, updateSelectedFormulationTypeAction, updateFormulationTypePageTitle, alertTitleFormulationTypeSaved, alertMesageFormulationTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, formulationTypeTabLabelFirst);
            
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Formulation DMF inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RequestLOA_453318.csv", "RequestLOA_453318#csv", DataAccessMethod.Sequential)]
        public void TC_453318_VerifyFormulationDMFInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string formulationDMFTabLabelFirst = this.TestContext.DataRow["formulationDMFTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleFormulationDMFSaved = this.TestContext.DataRow["alertTitleFormulationDMFSaved"].ToString();
                string alertMesageFormulationDMFSaved = this.TestContext.DataRow["alertMesageFormulationDMFSaved"].ToString();
                string updateSelectedFormulationDMFAction = this.TestContext.DataRow["updateSelectedFormulationDMFAction"].ToString();
                string updateFormulationDMFPageTitle = this.TestContext.DataRow["updateFormulationDMFPageTitle"].ToString();
                string newFormulationDMFPageTitle = this.TestContext.DataRow["newFormulationDMFPageTitle"].ToString();
                string newFormulationTypeCreationButtonText = this.TestContext.DataRow["newFormulationTypeCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string formulationName = this.TestContext.DataRow["formulationName"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string updatedFormulationName = this.TestContext.DataRow["updatedFormulationName"].ToString();
                string updatedAgencyName = this.TestContext.DataRow["updatedAgencyName"].ToString();

                string locationName = "LocationName " + _requestLOAAction.GenerateRandomString(8);
                string updatedLocationName = locationName.Replace("LocationName", "UpdateLocN");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "formulationName", formulationName},
                    { "locationName", locationName},
                    { "agencyName", agencyName}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "formulationName", updatedFormulationName},
                    { "locationName", updatedLocationName},
                    { "agencyName", updatedAgencyName}
                };

                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newFormulationTypeCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newFormulationTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newFormulationDMFPageTitle, alertTitleFormulationDMFSaved, alertMesageFormulationDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, formulationDMFTabLabelFirst);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, formulationDMFTabLabelFirst, updateSelectedFormulationDMFAction, updateFormulationDMFPageTitle, alertTitleFormulationDMFSaved, alertMesageFormulationDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, formulationDMFTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Plant inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454356.csv", "RegulatoryAndCompliance_454356#csv", DataAccessMethod.Sequential)]
        public void TC_454356_VerifyPlantInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string plantTabLabelFirst = this.TestContext.DataRow["plantTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitlePlantSaved = this.TestContext.DataRow["alertTitlePlantSaved"].ToString();
                string alertMesagePlantSaved = this.TestContext.DataRow["alertMesagePlantSaved"].ToString();
                string updateSelectedPlantAction = this.TestContext.DataRow["updateSelectedPlantAction"].ToString();
                string updatePlantPageTitle = this.TestContext.DataRow["updatePlantPageTitle"].ToString();
                string newPlantPageTitle = this.TestContext.DataRow["newPlantPageTitle"].ToString();
                string newPlantCreationButtonText = this.TestContext.DataRow["newPlantCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                
                string plantAddress = "PlantAddress " + _requestLOAAction.GenerateRandomString(8);
                string plantTitle = "PlantTitle " + _requestLOAAction.GenerateRandomString(8);
                string plantAbbreviation = "PA" + _requestLOAAction.GenerateRandomString(5).ToUpper();
                string updatedPlantAddress = plantAddress.Replace("PlantAddress", "UpdatedPA");
                string updatedPlantTitle = plantTitle.Replace("PlantTitle", "UpdatedPT");
                string updatedPlantAbbreviation = plantAbbreviation.Replace("PA", "UPA");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "plantAddress", plantAddress},
                    { "plantTitle", plantTitle},
                    { "plantAbbreviation", plantAbbreviation}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "plantAddress", updatedPlantAddress},
                    { "plantTitle", updatedPlantTitle},
                    { "plantAbbreviation", updatedPlantAbbreviation}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newPlantCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newPlantCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newPlantPageTitle, alertTitlePlantSaved, alertMesagePlantSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, plantTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, plantTabLabelFirst, updateSelectedPlantAction, updatePlantPageTitle, alertTitlePlantSaved, alertMesagePlantSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, plantTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify LOA Template inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454019.csv", "RegulatoryAndCompliance_454019#csv", DataAccessMethod.Sequential)]
        public void TC_454019_VerifyLOATemplateInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string lOATemplateTabLabelFirst = this.TestContext.DataRow["lOATemplateTabLabelFirst"].ToString();
                string newLOATemplateButtonText = this.TestContext.DataRow["newLOATemplateButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string loaTemplate = this.TestContext.DataRow["loaTemplate"].ToString();
                string processType = this.TestContext.DataRow["processType"].ToString();
                string isActive = this.TestContext.DataRow["isActive"].ToString();
                string createdOn = this.TestContext.DataRow["createdOn"].ToString();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "loaTemplate", loaTemplate},
                    { "processType", processType},
                    { "isActive", isActive},
                    { "createdOn", createdOn}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);
                Assert.AreEqual(false, _requestLOAAction.VerifyExistanceOfCreateButtonInInboxHomepage(newLOATemplateButtonText), "The 'New LOA Template Creation' button is existing");
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, lOATemplateTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Processing Type inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454509.csv", "RegulatoryAndCompliance_454509#csv", DataAccessMethod.Sequential)]
        public void TC_454509_VerifyProcessingTypeInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string configurationTypeTabLabelFirst = this.TestContext.DataRow["configurationTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleProcessingTypeSaved = this.TestContext.DataRow["alertTitleProcessingTypeSaved"].ToString();
                string alertMesageProcessingTypeSaved = this.TestContext.DataRow["alertMesageProcessingTypeSaved"].ToString();
                string updateSelectedProcessingTypeAction = this.TestContext.DataRow["updateSelectedProcessingTypeAction"].ToString();
                string updateProcessingTypePageTitle = this.TestContext.DataRow["updateProcessingTypePageTitle"].ToString();
                string newProcessingTypePageTitle = this.TestContext.DataRow["newProcessingTypePageTitle"].ToString();
                string newProcessingTypeCreationButtonText = this.TestContext.DataRow["newProcessingTypeCreationButtonText"].ToString();
                List<String> InboxPageTabLabelsExpected = (this.TestContext.DataRow["InboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string configurationType = "ProcessingType " + _requestLOAAction.GenerateRandomString(8);
                string updatedConfigurationType = configurationType.Replace("ProcessingType", "UpdatedPT");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", configurationType}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "inboxItemValue", updatedConfigurationType}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(InboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newProcessingTypeCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newProcessingTypeCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newProcessingTypePageTitle, alertTitleProcessingTypeSaved, alertMesageProcessingTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, configurationTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, configurationTypeTabLabelFirst, updateSelectedProcessingTypeAction, updateProcessingTypePageTitle, alertTitleProcessingTypeSaved, alertMesageProcessingTypeSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, configurationTypeTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Standard Email Statement inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454519.csv", "RegulatoryAndCompliance_454519#csv", DataAccessMethod.Sequential)]
        public void TC_454519_VerifyStandardEmailStatementInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string formulationTypeTabLabelFirst = this.TestContext.DataRow["formulationTypeTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = "Please Enter All required fields";//this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleStandardEmailStatementSaved = this.TestContext.DataRow["alertTitleStandardEmailStatementSaved"].ToString();
                string alertMesageStandardEmailStatementSaved = this.TestContext.DataRow["alertMesageStandardEmailStatementSaved"].ToString();
                string updateSelectedStandardEmailStatementAction = this.TestContext.DataRow["updateSelectedStandardEmailStatementAction"].ToString();
                string updateStandardEmailStatementPageTitle = this.TestContext.DataRow["updateStandardEmailStatementPageTitle"].ToString();
                string newStandardEmailStatementPageTitle = this.TestContext.DataRow["newStandardEmailStatementPageTitle"].ToString();
                string newStandardEmailStatementCreationButtonText = this.TestContext.DataRow["newStandardEmailStatementCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string titleEntry = "Title " + _requestLOAAction.GenerateRandomString(8);
                string standardEmailStatement = "StandardEmailStatement " + _requestLOAAction.GenerateRandomString(8) + "\n" + _requestLOAAction.GenerateRandomString(10) + "\n" + _requestLOAAction.GenerateRandomString(10) + "\n" + _requestLOAAction.GenerateRandomString(10);
                string updatedTitleEntry = titleEntry.Replace("Title", "UpdateTtl");
                string updatedStandardEmailStatement = standardEmailStatement.Replace("StandardEmailStatement", "UpdatedSES");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "titleEntry", titleEntry},
                    { "standardEmailStatement", standardEmailStatement}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "titleEntry", updatedTitleEntry},
                    { "standardEmailStatement", updatedStandardEmailStatement}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newStandardEmailStatementCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newStandardEmailStatementCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newStandardEmailStatementPageTitle, alertTitleStandardEmailStatementSaved, alertMesageStandardEmailStatementSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, formulationTypeTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, formulationTypeTabLabelFirst, updateSelectedStandardEmailStatementAction, updateStandardEmailStatementPageTitle, alertTitleStandardEmailStatementSaved, alertMesageStandardEmailStatementSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, formulationTypeTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the new Product is getting created;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454511.csv", "RegulatoryAndCompliance_454511#csv", DataAccessMethod.Sequential)]
        public void TC_454511_VerifyProductInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string productTabLabelFirst = this.TestContext.DataRow["productTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleProductSaved = this.TestContext.DataRow["alertTitleProductSaved"].ToString();
                string alertMesageProductSaved = this.TestContext.DataRow["alertMesageProductSaved"].ToString();
                string updateSelectedProductAction = this.TestContext.DataRow["updateSelectedProductAction"].ToString();
                string updateProductPageTitle = this.TestContext.DataRow["updateProductPageTitle"].ToString();
                string newProductPageTitle = this.TestContext.DataRow["newProductPageTitle"].ToString();
                string newProductCreationButtonText = this.TestContext.DataRow["newProductCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["formulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["formulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["coatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["washPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["sterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["configuration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["configurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["packingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["status"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["chinaDossierNumber"].ToString()},
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["updatedFormulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["updatedFormulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["updatedCoatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["updatedWashPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["updatedSterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["updatedConfiguration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["updatedConfigurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["updatedPackingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["status"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["updatedChinaDossierNumber"].ToString()},
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                string newWestItemNumber = _requestLOAAction.GetLatestWestItemCreatedInApplication(inbox);

                string randomString = _requestLOAAction.GenerateRandomString(6);
                newInboxItemValues.Add("title", "ProdName Auto " + randomString);
                newInboxItemValues.Add("specification", "Spec Auto " + randomString);
                newInboxItemValues.Add("index", "Index Auto " + randomString);
                newInboxItemValues.Add("chinaProcesingType", "ChinaProc Auto " + randomString);
                newInboxItemValues.Add("westItemNumber", newWestItemNumber);
                updatedInboxItemValues.Add("title", "UpdatedProdName Auto " + randomString);
                updatedInboxItemValues.Add("specification", "UpdatedSpec Auto " + randomString);
                updatedInboxItemValues.Add("index", "UpdatedIndex Auto " + randomString);
                updatedInboxItemValues.Add("chinaProcesingType", "UpdatedChinaProc Auto " + randomString);
                updatedInboxItemValues.Add("westItemNumber", newWestItemNumber);


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newProductCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newProductCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newProductPageTitle, alertTitleProductSaved, alertMesageProductSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, productTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, productTabLabelFirst, updateSelectedProductAction, updateProductPageTitle, alertTitleProductSaved, alertMesageProductSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, productTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify External Request LOA inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454513.csv", "RegulatoryAndCompliance_454513#csv", DataAccessMethod.Sequential)]
        public void TC_454513_VerifyExternalRequestLOAInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string externalRequestLOATabLabelFirst = this.TestContext.DataRow["externalRequestLOATabLabelFirst"].ToString();
                string newExternalRequestLOAButtonText = this.TestContext.DataRow["newExternalRequestLOAButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string siteCoreId = this.TestContext.DataRow["siteCoreId"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string yourTitle = this.TestContext.DataRow["yourTitle"].ToString();
                string addressOne = this.TestContext.DataRow["addressOne"].ToString();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "siteCoreId", siteCoreId},
                    { "firstName", firstName},
                    { "lastName", lastName},
                    { "yourTitle", yourTitle},
                    { "addressOne", addressOne}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);
                Assert.AreEqual(false, _requestLOAAction.VerifyExistanceOfCreateButtonInInboxHomepage(newExternalRequestLOAButtonText), "The 'New External Request LOA Creation' button is existing");
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, externalRequestLOATabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Request Contact inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454515.csv", "RegulatoryAndCompliance_454515#csv", DataAccessMethod.Sequential)]
        public void TC_454515_VerifyRequestContactInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string requestContactTabLabelFirst = this.TestContext.DataRow["requestContactTabLabelFirst"].ToString();
                string newRequestContactButtonText = this.TestContext.DataRow["newRequestContactButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string loaId = this.TestContext.DataRow["loaId"].ToString();
                string contactType = this.TestContext.DataRow["contactType"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string company = this.TestContext.DataRow["company"].ToString();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "loaId", loaId},
                    { "contactType", contactType},
                    { "lastName", lastName},
                    { "firstName", firstName},
                    { "company", company}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);
                Assert.AreEqual(false, _requestLOAAction.VerifyExistanceOfCreateButtonInInboxHomepage(newRequestContactButtonText), "The 'New External Request LOA Creation' button is existing");
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, requestContactTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify External Request LOA inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454517.csv", "RegulatoryAndCompliance_454517#csv", DataAccessMethod.Sequential)]
        public void TC_454517_VerifyRequestItemNumberInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string requestItemNumberTabLabelFirst = this.TestContext.DataRow["requestItemNumberTabLabelFirst"].ToString();
                string newRequestItemNumberButtonText = this.TestContext.DataRow["newRequestItemNumberButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                
                string fullName = this.TestContext.DataRow["fullName"].ToString();
                string createdOn = this.TestContext.DataRow["createdOn"].ToString();
                string loaId = this.TestContext.DataRow["loaId"].ToString();
                string westItemNumber = this.TestContext.DataRow["westItemNumber"].ToString();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "fullName", fullName},
                    { "createdOn", createdOn},
                    { "loaId", loaId},
                    { "westItemNumber", westItemNumber}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);
                Assert.AreEqual(false, _requestLOAAction.VerifyExistanceOfCreateButtonInInboxHomepage(newRequestItemNumberButtonText), "The 'New Request Item Number Creation' button is existing");
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, requestItemNumberTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Formulation inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_455576.csv", "RegulatoryAndCompliance_455576#csv", DataAccessMethod.Sequential)]
        public void TC_455576_VerifyFormulationInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string formulationTabLabelFirst = this.TestContext.DataRow["formulationTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleFormulationSaved = this.TestContext.DataRow["alertTitleFormulationSaved"].ToString();
                string alertMesageFormulationSaved = "Formulation Data is Saved";// this.TestContext.DataRow["alertMesageFormulationSaved"].ToString();
                string updateSelectedFormulationAction = this.TestContext.DataRow["updateSelectedFormulationAction"].ToString();
                string updateFormulationPageTitle = "Update Formulation";//this.TestContext.DataRow["updateFormulationPageTitle"].ToString();
                string newFormulationPageTitle = "Create New Formulation";// this.TestContext.DataRow["newFormulationPageTitle"].ToString();
                string newFormulationCreationButtonText = this.TestContext.DataRow["newFormulationCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string formulationName = "FormulationName " + _requestLOAAction.GenerateRandomString(8);
                string contains2MCBT = "Yes";
                string relatedSubstance = "RelatedSubstance " + _requestLOAAction.GenerateRandomString(8);
                string updatedFormulationName = formulationName.Replace("FormulationName", "UpdatedFN");
                string updatedContains2MCBT = "Related";
                string updatedRelatedSubstance = relatedSubstance.Replace("RelatedSubstance", "UpdatedRS");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "formulationName", formulationName},
                    { "contains2MCBT", contains2MCBT},
                    { "relatedSubstance", relatedSubstance}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "formulationName", updatedFormulationName},
                    { "contains2MCBT", updatedContains2MCBT},
                    { "relatedSubstance", updatedRelatedSubstance}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newFormulationCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newFormulationCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newFormulationPageTitle, alertTitleFormulationSaved, alertMesageFormulationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, formulationTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, formulationTabLabelFirst, updateSelectedFormulationAction, updateFormulationPageTitle, alertTitleFormulationSaved, alertMesageFormulationSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, formulationTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Wash Process DMF inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454600.csv", "RegulatoryAndCompliance_454600#csv", DataAccessMethod.Sequential)]
        public void TC_454600_VerifyWashProcessDMFInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string washProcessDMFTabLabelFirst = this.TestContext.DataRow["washProcessDMFTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleWashProcessDMFSaved = this.TestContext.DataRow["alertTitleWashProcessDMFSaved"].ToString();
                string alertMesageWashProcessDMFSaved = "Wash Process Data is Successfully Saved";// this.TestContext.DataRow["alertMesageWashProcessDMFSaved"].ToString();
                string updateSelectedWashProcessDMFAction = this.TestContext.DataRow["updateSelectedWashProcessDMFAction"].ToString();
                string updateWashProcessDMFPageTitle = this.TestContext.DataRow["updateWashProcessDMFPageTitle"].ToString();
                string newWashProcessDMFPageTitle = this.TestContext.DataRow["newWashProcessDMFPageTitle"].ToString();
                string newWashProcessDMFCreationButtonText = this.TestContext.DataRow["newWashProcessDMFCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string formulationType = this.TestContext.DataRow["formulationType"].ToString();
                string plant = this.TestContext.DataRow["plant"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string loaTemplate = this.TestContext.DataRow["loaTemplate"].ToString();
                string configBerFamily = this.TestContext.DataRow["configBerFamily"].ToString();
                string updatedFormulationType = this.TestContext.DataRow["updatedFormulationType"].ToString();
                string updatedPlant = this.TestContext.DataRow["updatedPlant"].ToString();
                string updatedAgencyName = this.TestContext.DataRow["updatedAgencyName"].ToString();
                string updatedLoaTemplate = this.TestContext.DataRow["updatedLoaTemplate"].ToString();
                string updatedConfigBerFamily = this.TestContext.DataRow["updatedConfigBerFamily"].ToString();

                string title = _requestLOAAction.GenerateRandomDigits(5);
                string amendment = "Amendment " + _requestLOAAction.GenerateRandomString(8);
                string berTable = "BerTable " + _requestLOAAction.GenerateRandomString(8);
                string updatedTitle = _requestLOAAction.GenerateRandomDigits(5);
                string updatedAmendment = amendment.Replace("Amendment", "UpdatedAmn");
                string updatedBerTable = berTable.Replace("BerTable", "UpdatedBTbl");


                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "title", title},
                    { "formulationType", formulationType},
                    { "plant", plant},
                    { "agencyName", agencyName},
                    { "loaTemplate", loaTemplate},
                    { "configBerFamily", configBerFamily},
                    { "amendment", amendment},
                    { "berTable", berTable}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "title", updatedTitle},
                    { "formulationType", updatedFormulationType},
                    { "plant", updatedPlant},
                    { "agencyName", updatedAgencyName},
                    { "loaTemplate", updatedLoaTemplate},
                    { "configBerFamily", updatedConfigBerFamily},
                    { "amendment", updatedAmendment},
                    { "berTable", updatedBerTable}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newWashProcessDMFCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newWashProcessDMFCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newWashProcessDMFPageTitle, alertTitleWashProcessDMFSaved, alertMesageWashProcessDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, washProcessDMFTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, washProcessDMFTabLabelFirst, updateSelectedWashProcessDMFAction, updateWashProcessDMFPageTitle, alertTitleWashProcessDMFSaved, alertMesageWashProcessDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, washProcessDMFTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify China Dossier Number inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_455644.csv", "RegulatoryAndCompliance_455644#csv", DataAccessMethod.Sequential)]
        public void TC_455644_VerifyChinaDossierNumberInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chinaDossierNumberTabLabelFirst = this.TestContext.DataRow["chinaDossierNumberTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleChinaDossierNumberSaved = this.TestContext.DataRow["alertTitleChinaDossierNumberSaved"].ToString();
                string alertMesageChinaDossierNumberSaved = "China Dossier Data is Saved";// this.TestContext.DataRow["alertMesageChinaDossierNumberSaved"].ToString();
                string updateSelectedChinaDossierNumberAction = this.TestContext.DataRow["updateSelectedChinaDossierNumberAction"].ToString();
                string updateChinaDossierNumberPageTitle = "Update China Dossier Number ";// this.TestContext.DataRow["updateChinaDossierNumberPageTitle"].ToString();
                string newChinaDossierNumberPageTitle = "New China Dossier Number";// this.TestContext.DataRow["newChinaDossierNumberPageTitle"].ToString();
                string newChinaDossierNumberCreationButtonText = this.TestContext.DataRow["newChinaDossierNumberCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string plant = this.TestContext.DataRow["plant"].ToString();
                string updatedPlant = this.TestContext.DataRow["updatedPlant"].ToString();

                string chinaDMFSubject = "ChinaDMFSubject " + _requestLOAAction.GenerateRandomString(8);
                string dossierNumberCode = _requestLOAAction.GenerateRandomDigits(5);
                string configurationsField = "ConfigurationsField " + _requestLOAAction.GenerateRandomString(8);
                string specification = "Specification " + _requestLOAAction.GenerateRandomString(8);
                string updatedChinaDMFSubject = "Updated " + chinaDMFSubject;
                string updatedDossierNumberCode = _requestLOAAction.GenerateRandomDigits(5);
                string updatedConfigurationsField = configurationsField.Replace("ConfigurationsField", "UpdatedCnfgFld");
                string updatedSpecification = specification.Replace("Specification", "UpdatedSpec");


                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "chinaDMFSubject", chinaDMFSubject},
                    { "dossierNumberCode", dossierNumberCode},
                    { "configurationsField", configurationsField},
                    { "plant", plant},
                    { "specification", specification}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "chinaDMFSubject", updatedChinaDMFSubject},
                    { "dossierNumberCode", updatedDossierNumberCode},
                    { "configurationsField", updatedConfigurationsField},
                    { "plant", updatedPlant},
                    { "specification", updatedSpecification}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newChinaDossierNumberCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newChinaDossierNumberCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newChinaDossierNumberPageTitle, alertTitleChinaDossierNumberSaved, alertMesageChinaDossierNumberSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, chinaDossierNumberTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, chinaDossierNumberTabLabelFirst, updateSelectedChinaDossierNumberAction, updateChinaDossierNumberPageTitle, alertTitleChinaDossierNumberSaved, alertMesageChinaDossierNumberSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, chinaDossierNumberTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Sterile Process DMF inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_454588.csv", "RegulatoryAndCompliance_454588#csv", DataAccessMethod.Sequential)]
        public void TC_454588_VerifySterileProcessDMFInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string sterileProcessDMFTabLabelFirst = this.TestContext.DataRow["sterileProcessDMFTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitleSterileProcessDMFSaved = this.TestContext.DataRow["alertTitleSterileProcessDMFSaved"].ToString();
                string alertMesageSterileProcessDMFSaved = this.TestContext.DataRow["alertMesageSterileProcessDMFSaved"].ToString();
                string updateSelectedSterileProcessDMFAction = this.TestContext.DataRow["updateSelectedSterileProcessDMFAction"].ToString();
                string updateSterileProcessDMFPageTitle = this.TestContext.DataRow["updateSterileProcessDMFPageTitle"].ToString();
                string newSterileProcessDMFPageTitle = this.TestContext.DataRow["newSterileProcessDMFPageTitle"].ToString();
                string newSterileProcessDMFCreationButtonText = this.TestContext.DataRow["newSterileProcessDMFCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                
                string plant = this.TestContext.DataRow["plant"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string packingOption = this.TestContext.DataRow["packingOption"].ToString();
                string loaTemplate = this.TestContext.DataRow["loaTemplate"].ToString();
                string updatedPlant = this.TestContext.DataRow["updatedPlant"].ToString();
                string updatedAgencyName = this.TestContext.DataRow["updatedAgencyName"].ToString();
                string updatedPackingOption = this.TestContext.DataRow["packingOption"].ToString();
                string updatedLoaTemplate = this.TestContext.DataRow["updatedLoaTemplate"].ToString();

                string title = _requestLOAAction.GenerateRandomDigits(5);
                string amendmentText = "AmendmentText " + _requestLOAAction.GenerateRandomString(8);
                string stmStrlProdDesc = "StmStrlProdDesc " + _requestLOAAction.GenerateRandomString(8);
                string updatedTitle = _requestLOAAction.GenerateRandomDigits(5);
                string updatedAmendmentText = amendmentText.Replace("AmendmentText", "UpdatedAmnTxt");
                string updatedStmStrlProdDesc = "StmStrlProdDesc " + stmStrlProdDesc;


                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "title", title},
                    { "plant", plant},
                    { "agencyName", agencyName},
                    { "packingOption", packingOption},
                    { "loaTemplate", loaTemplate},
                    { "amendmentText", amendmentText},
                    { "stmStrlProdDesc", stmStrlProdDesc}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "title", updatedTitle},
                    { "plant", updatedPlant},
                    { "agencyName", updatedAgencyName},
                    { "packingOption", updatedPackingOption},
                    { "loaTemplate", updatedLoaTemplate},
                    { "amendmentText", updatedAmendmentText},
                    { "stmStrlProdDesc", updatedStmStrlProdDesc}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newSterileProcessDMFCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newSterileProcessDMFCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newSterileProcessDMFPageTitle, alertTitleSterileProcessDMFSaved, alertMesageSterileProcessDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, sterileProcessDMFTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, sterileProcessDMFTabLabelFirst, updateSelectedSterileProcessDMFAction, updateSterileProcessDMFPageTitle, alertTitleSterileProcessDMFSaved, alertMesageSterileProcessDMFSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, sterileProcessDMFTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Pack Option inbox functionalities such as Add or Update;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_493444.csv", "RegulatoryAndCompliance_493444#csv", DataAccessMethod.Sequential)]
        public void TC_493444_VerifyPackOptionInboxAddOrUpdateFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string packOptionTabLabelFirst = this.TestContext.DataRow["packOptionTabLabelFirst"].ToString();
                string alertMesageRequiredFieldValidation = this.TestContext.DataRow["alertMesageRequiredFieldValidation"].ToString();
                string alertTitlePackOptionSaved = this.TestContext.DataRow["alertTitlePackOptionSaved"].ToString();
                string alertMesagePackOptionSaved = this.TestContext.DataRow["alertMesagePackOptionSaved"].ToString();
                string updateSelectedPackOptionAction = this.TestContext.DataRow["updateSelectedPackOptionAction"].ToString();
                string updatePackOptionPageTitle = this.TestContext.DataRow["updatePackOptionPageTitle"].ToString();
                string newPackOptionPageTitle = this.TestContext.DataRow["newPackOptionPageTitle"].ToString();
                string newPackOptionCreationButtonText = this.TestContext.DataRow["newPackOptionCreationButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();

                string packOption = "PackOption " + _requestLOAAction.GenerateRandomString(8);
                string titleEntry = "Title " + _requestLOAAction.GenerateRandomString(8);
                string updatedPackOption = packOption.Replace("PackOption", "UpdatePkOpn");
                string updatedTitleEntry = titleEntry.Replace("Title", "UpdateTtl");

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "packOption", packOption},
                    { "titlePackOption", titleEntry}
                };
                IDictionary<string, string> updatedInboxItemValues = new Dictionary<string, string>() {
                    { "packOption", updatedPackOption},
                    { "titlePackOption", updatedTitleEntry}
                };


                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);

                _requestLOAAction.ValidateEmptyDataValidationMessage(inbox, alertMesageRequiredFieldValidation, newPackOptionCreationButtonText);

                _requestLOAAction.CreateNewInboxItem(inbox, newPackOptionCreationButtonText, (Dictionary<string, string>)newInboxItemValues, newPackOptionPageTitle, alertTitlePackOptionSaved, alertMesagePackOptionSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, packOptionTabLabelFirst);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.UpdateInboxItem(inbox, (Dictionary<string, string>)newInboxItemValues, (Dictionary<string, string>)updatedInboxItemValues, packOptionTabLabelFirst, updateSelectedPackOptionAction, updatePackOptionPageTitle, alertTitlePackOptionSaved, alertMesagePackOptionSaved);
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)updatedInboxItemValues, packOptionTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Request Agency inbox;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_493439.csv", "RegulatoryAndCompliance_493439#csv", DataAccessMethod.Sequential)]
        public void TC_493439_VerifyRequestAgencyInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string requestAgencyTabLabelFirst = this.TestContext.DataRow["requestAgencyTabLabelFirst"].ToString();
                string newRequestAgencyButtonText = this.TestContext.DataRow["newRequestAgencyButtonText"].ToString();
                List<String> inboxPageTabLabelsExpected = (this.TestContext.DataRow["inboxPageTabLabelsExpected"].ToString())?.Split(';').ToList();
                string loaID = this.TestContext.DataRow["loaID"].ToString();
                string agency = this.TestContext.DataRow["agency"].ToString();
                string applicationNo = this.TestContext.DataRow["applicationNo"].ToString();
                string applicationType = this.TestContext.DataRow["applicationType"].ToString();

                IDictionary<string, string> newInboxItemValues = new Dictionary<string, string>() {
                    { "loaID", loaID},
                    { "agency", agency},
                    { "applicationNo", applicationNo},
                    { "applicationType", applicationType}
                };

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateInboxPageTabLabels(inboxPageTabLabelsExpected);
                Assert.AreEqual(false, _requestLOAAction.VerifyExistanceOfCreateButtonInInboxHomepage(newRequestAgencyButtonText), "The 'New Request Agency Creation' button is existing");
                _requestLOAAction.ValidateInboxItemInInboxHomePage(inbox, (Dictionary<string, string>)newInboxItemValues, requestAgencyTabLabelFirst);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify Request LOA for Product are in Ready for Review Status then changing to Approved;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_448204.csv", "RegulatoryAndCompliance_448204#csv", DataAccessMethod.Sequential)]
        public void TC_448204_VerifyOnlyApprovedProductsEnabledForRequestLoa()
        {//Ref: 495217
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_Product = this.TestContext.DataRow["inbox_Product"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string alertTitleProductSaved = this.TestContext.DataRow["alertTitleProductSaved"].ToString();
                string alertMesageProductSaved = this.TestContext.DataRow["alertMesageProductSaved"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertMessageNoProductAdded = this.TestContext.DataRow["alertMessageNoProductAdded"].ToString();
                string tabNameLoaProducts = this.TestContext.DataRow["tabNameLoaProducts"].ToString();
                string targetStatus = this.TestContext.DataRow["targetStatus"].ToString();
                string updateSelectedProductAction = this.TestContext.DataRow["updateSelectedProductAction"].ToString();
                string productTabLabelFirst = this.TestContext.DataRow["productTabLabelFirst"].ToString();
                string searchingItem = this.TestContext.DataRow["searchingItem"].ToString();
                string alertTitleStatusChanged_InProgress = this.TestContext.DataRow["alertTitleStatusChanged_InProgress"].ToString();
                string alertMesageStatusChanged_InProgress = this.TestContext.DataRow["alertMesageStatusChanged_InProgress"].ToString();

                IDictionary<string, string> newProductValues = new Dictionary<string, string>() {
                    { "formulation", this.TestContext.DataRow["formulation"].ToString()},
                    { "formulationType", this.TestContext.DataRow["formulationType"].ToString()},
                    { "coatingValueOne", this.TestContext.DataRow["coatingValueOne"].ToString()},
                    { "coatingValueTwo", this.TestContext.DataRow["coatingValueTwo"].ToString()},
                    { "washPlantValueOne", this.TestContext.DataRow["washPlantValueOne"].ToString()},
                    { "washPlantValueTwo", this.TestContext.DataRow["washPlantValueTwo"].ToString()},
                    { "sterilePlantValueOne", this.TestContext.DataRow["sterilePlantValueOne"].ToString()},
                    { "sterilePlantValueTwo", this.TestContext.DataRow["sterilePlantValueTwo"].ToString()},
                    { "configuration", this.TestContext.DataRow["configuration"].ToString()},
                    { "configurationType", this.TestContext.DataRow["configurationType"].ToString()},
                    { "packingOption", this.TestContext.DataRow["packingOption"].ToString()},
                    { "configBerFamily", this.TestContext.DataRow["configBerFamily"].ToString()},
                    { "templates", this.TestContext.DataRow["templates"].ToString()},
                    { "hcFormulaDmf", this.TestContext.DataRow["hcFormulaDmf"].ToString()},
                    { "hcCoatingDmf", this.TestContext.DataRow["hcCoatingDmf"].ToString()},
                    { "status", this.TestContext.DataRow["targetStatus"].ToString()},
                    { "chinaDossierNumber", this.TestContext.DataRow["chinaDossierNumber"].ToString()},
                };


                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                string newWestItemNumber = _requestLOAAction.GetLatestWestItemCreatedInApplication(inbox_Product);

                string randomString = _requestLOAAction.GenerateRandomString(6);
                newProductValues.Add("title", "ProdName Auto " + randomString);
                newProductValues.Add("specification", "Spec Auto " + randomString);
                newProductValues.Add("index", "Index Auto " + randomString);
                newProductValues.Add("chinaProcesingType", "ChinaProc Auto " + randomString);
                newProductValues.Add("westItemNumber", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox_Product);
                _requestLOAAction.CreateNewProduct(alertTitleProductSaved, alertMesageProductSaved, (Dictionary<string, string>)newProductValues);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_Product, newWestItemNumber, productTabLabelFirst, searchingItem);

                string loaId = CreateLOAIDInWestDigitalApplication("ProductEntry", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLoaProductForApprovedUnapprovedWestItem(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChanged_InProgress, alertMesageStatusChanged_InProgress, alertMessageNoProductAdded, tabNameLoaProducts, false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that Company Name allows special characters and they should retained in the LOA document;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_441165.csv", "RegulatoryAndCompliance_441165#csv", DataAccessMethod.Sequential)]
        public void TC_441165_VerifyCompanyNameAllowsSpecialCharacters()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string contactsLabel = this.TestContext.DataRow["contactsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string custCompany = "CustWest!@#$%^&*()_+,.<>?/`~[]{}=-|";
                string reqCompany = "West!@#$%^&*()_+,.<>?/`~[]{}=-|";


                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "CompanyNameSpecialChar");

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, contactsLabel);
                _requestLOAAction.ValidateCompanyNameFromLoaContactTab(contactsLabel, custCompany, reqCompany);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.ValidateCompanyNameFromLoaDocument(inbox_LOADocuments, loaId, editLoaDocumentAction, custCompany);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that Endotoxin summary should be in LOA document if the product has Wash plant;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_465804.csv", "RegulatoryAndCompliance_465804#csv", DataAccessMethod.Sequential)]
        public void TC_465804_VerifyEndotoxinSummaryShouldBeInLOADocumentIfProductHasWashplant()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string newWestItemNumber = this.TestContext.DataRow["newWestItemNumber"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string endotoxinSummary = "Endotoxin Reduction Validation Results Summary";

                string loaId = CreateLOAIDInWestDigitalApplication("EndotoxinEntry", newWestItemNumber);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                bool flag = false;
                for (int i = 0; i < fileCount; i++)
                {
                    if (_requestLOAAction.ValidateTextExistanceInLoaDocument(i, editLoaDocumentAction, endotoxinSummary))
                    {
                        flag = true;
                        break;
                    }
                    if(i == fileCount-1 && flag == false)
                    {
                        Assert.Fail("The '"+ endotoxinSummary + "' is not found in LOA Document inbox page");
                    }
                }

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that special characters shouldn't be retained in the LOA document file name;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_441161.csv", "RegulatoryAndCompliance_441161#csv", DataAccessMethod.Sequential)]
        public void TC_441161_VerifySpecialCharactersShouldNotRetainedInLOADocumentFileName()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string alertTitleDocumentUpdate = this.TestContext.DataRow["alertTitleDocumentUpdate"].ToString();
                string alertMesageDocumentUpdate = this.TestContext.DataRow["alertMesageDocumentUpdate"].ToString();
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string inbox_LOAPDF = this.TestContext.DataRow["inbox_LOAPDF"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string loaPDFTabLabelFirst = this.TestContext.DataRow["loaPDFTabLabelFirst"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                
                
                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "CompanyNameSpecialChar");

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                for (int i = 0; i < fileCount; i++)
                {
                    string documentName = _requestLOAAction.GetLOADocumentName(inbox_LOADocuments, loaId, i);
                    Assert.AreEqual(_requestLOAAction.isStringHasSpecialChars(documentName), false, "The 'LOA Document' name, "+ documentName + " name has special characters");
                }
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOAPDF);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOAPDF, loaId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));
                
                int pdfFileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOAPDF, loaId, loaPDFTabLabelFirst, String.Concat(inbox_LOAPDF.Where(c => !Char.IsWhiteSpace(c))));
                _requestLOAAction.ScrollHorizontally_LOAPages(8);
                for (int i = 0; i < pdfFileCount; i++)
                {
                    string pdfName = _requestLOAAction.GetLOAPdfName(inbox_LOAPDF, loaId, i);
                    Assert.AreEqual(_requestLOAAction.isStringHasSpecialChars(pdfName), false, "The 'LOA Pdf' name, " + pdfName + " name has special characters");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the requestor contact address should be concatenated in Loa Document;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_441153.csv", "RegulatoryAndCompliance_441153#csv", DataAccessMethod.Sequential)]
        public void TC_441153_VerifyRequestorContactAddressShouldbeConcatenatedInLoaDocument()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string agencyName = this.TestContext.DataRow["agencyName"].ToString();

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, agencyName);
                List<String> LoaItemRowValues = _requestLOAAction.GetRequestorContactDetails();
                string concatenatedAddress = LoaItemRowValues[1] + ", " + LoaItemRowValues[2] + ", " + LoaItemRowValues[3];

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                for (int i = 0; i < fileCount; i++)
                {
                    Assert.AreEqual((_requestLOAAction.ValidateTextExistanceInLoaDocument(i, editLoaDocumentAction, concatenatedAddress)), true, "The '"+ concatenatedAddress + "' is not found in LOA Document inbox page");
                }

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that No Template for LOA Document - NovaPure RU and Agency CDRH;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_472461.csv", "RegulatoryAndCompliance_472461#csv", DataAccessMethod.Sequential)]
        public void TC_472461_VerifyNoTemplateForLOADocumentNovaPureRUAndAgencyCDRH()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string itemsOrProductsLabel = this.TestContext.DataRow["itemsOrProductsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string noTemplateSummary = "There is no template assigned to product "+ itemNoOne + ". Please remove this document during review prior to sending for approval.";

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "NovaPureRU");
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, itemsOrProductsLabel);
                _requestLOAAction.ValidateWestItemNoInLoaItemsOrProductsTab(itemNoOne);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                string documentName = "";
                bool flag = false;
                for (int i = 0; i < fileCount; i++)
                {
                    documentName = "";
                    documentName = _requestLOAAction.GetLOADocumentName(inbox_LOADocuments, loaId, i);
                    if (documentName.Contains("_NoTemplate_"))
                    {
                        flag = true;
                        if(!_requestLOAAction.ValidateTextExistanceInLoaDocument(i, editLoaDocumentAction, noTemplateSummary))
                        {
                            Assert.Fail("The '" + noTemplateSummary + "' is not found in LOA Document");
                        }
                    }
                }
                if (!flag)
                {
                    Assert.Fail("The '_NoTemplate_' text is not found in LOA Document name,'"+ documentName + "'");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify if the product has NovaPure RU, there should be endotoxin in LOA Document;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_478480.csv", "RegulatoryAndCompliance_478480#csv", DataAccessMethod.Sequential)]
        public void TC_478480_VerifyProductHasNovaPureRUEndotoxinShouldBeInDocument()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string itemsOrProductsLabel = this.TestContext.DataRow["itemsOrProductsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string noTemplateSummary = "Endotoxin Reduction Validation Results Summary";

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "NovaPureRUThreeAgency");

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, itemsOrProductsLabel);
                _requestLOAAction.ValidateWestItemNoInLoaItemsOrProductsTab(itemNoOne);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                string documentName = "";
                bool flag = false;
                for (int i = 0; i < fileCount; i++)
                {
                    documentName = "";
                    documentName = _requestLOAAction.GetLOADocumentName(inbox_LOADocuments, loaId, i);
                    if (documentName.Contains("_NovaPure RU_"))
                    {
                        flag = true;
                        if (!_requestLOAAction.ValidateTextExistanceInLoaDocument(i, editLoaDocumentAction, noTemplateSummary))
                        {
                            Assert.Fail("The '" + noTemplateSummary + "' is not found in LOA Document");
                        }
                    }
                }
                if (!flag)
                {
                    Assert.Fail("The '_NovaPure RU_' text is not found in LOA Document name,'" + documentName + "'");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify the status of the fleld, IsDaikyoEmailSent with LOA status change;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_495826.csv", "RegulatoryAndCompliance_495826#csv", DataAccessMethod.Sequential)]
        public void TC_495826_VerifyStatusOfFieldIsDaikyoEmailSentWithLOAStatusChange()
        {//504300,504301,504325
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string itemsOrProductsLabel = this.TestContext.DataRow["itemsOrProductsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                
                string loaStatus_OutForApproval = this.TestContext.DataRow["loaStatus_OutForApproval"].ToString();
                string alertTitleStatusChange_OutForApproval = this.TestContext.DataRow["alertTitleStatusChange_OutForApproval"].ToString();
                string alertMesageStatusChange_OutForApproval = this.TestContext.DataRow["alertMesageStatusChange_OutForApproval"].ToString();
                string requestLOATab_OutForApproval = this.TestContext.DataRow["requestLOATab_OutForApproval"].ToString();
                string loaStatus_Complete = this.TestContext.DataRow["loaStatus_Complete"].ToString();
                string requestLOATab_Complete = this.TestContext.DataRow["requestLOATab_Complete"].ToString();
                string alertTitleStatusChange_Complete = this.TestContext.DataRow["alertTitleStatusChange_Complete"].ToString();
                string alertMesageStatusChange_Complete = this.TestContext.DataRow["alertMesageStatusChange_Complete"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "DaikyoProduct");
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, itemsOrProductsLabel);
                _requestLOAAction.ValidateWestItemNoInLoaItemsOrProductsTab(itemNoOne);

                _requestLOAAction.ValidateIsDaikyoEmailSentStatus("New", false);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);
                
                _requestLOAAction.SearchItemInInboxHomePage(inbox, loaId, requestLOATab_InProgress);
                _requestLOAAction.ValidateIsDaikyoEmailSentStatus(requestLOATab_InProgress, true);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_OutForApproval, alertTitleStatusChange_OutForApproval, alertMesageStatusChange_OutForApproval, requestLOATab_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_OutForApproval, loaStatus_OutForApproval);

                _requestLOAAction.SearchItemInInboxHomePage(inbox, loaId, requestLOATab_OutForApproval);
                _requestLOAAction.ValidateIsDaikyoEmailSentStatus(requestLOATab_OutForApproval, true);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_Complete, alertTitleStatusChange_Complete, alertMesageStatusChange_Complete, requestLOATab_OutForApproval);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_Complete, loaStatus_Complete);

                _requestLOAAction.SearchItemInInboxHomePage(inbox, loaId, requestLOATab_Complete);
                _requestLOAAction.ValidateIsDaikyoEmailSentStatus(requestLOATab_Complete, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify the status of IsDaikyoEmailSent Field for non Daiko products;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_501429.csv", "RegulatoryAndCompliance_501429#csv", DataAccessMethod.Sequential)]
        public void TC_501429_VerifyStatusOfIsDaikyoEmailSentFieldForNonDaikoProducts()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string itemsOrProductsLabel = this.TestContext.DataRow["itemsOrProductsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();


                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "NonDaikyoProduct");
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, itemsOrProductsLabel);
                _requestLOAAction.ValidateWestItemNoInLoaItemsOrProductsTab(itemNoOne);

                _requestLOAAction.ValidateIsDaikyoEmailSentStatus("New", false);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ValidateLOAStatusInRequestLOA(inbox, loaId, requestLOATab_InProgress, loaStatus_InProgress);

                _requestLOAAction.SearchItemInInboxHomePage(inbox, loaId, requestLOATab_InProgress);
                _requestLOAAction.ValidateIsDaikyoEmailSentStatus(requestLOATab_InProgress, false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("LOATest")]
        [Description("Verify that the LOAs with CZ Template should not have Facility row in the LOA word document;;")]
        [Owner("don.mathewexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"RegulatoryAndCompliance_472387.csv", "RegulatoryAndCompliance_472387#csv", DataAccessMethod.Sequential)]
        public void TC_472387_VerifyLOAsWithCZTemplateShouldNotHaveFacilityRowInLOAWordDocument()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string loaStatus_InProgress = this.TestContext.DataRow["loaStatus_InProgress"].ToString();
                string inbox_LOADocuments = this.TestContext.DataRow["inbox_LOADocuments"].ToString();
                string editRequestLoaAction = this.TestContext.DataRow["editRequestLoaAction"].ToString();
                string editLoaDocumentAction = this.TestContext.DataRow["editLoaDocumentAction"].ToString();
                string alertTitleStatusChange_InProgress = this.TestContext.DataRow["alertTitleStatusChange_InProgress"].ToString();
                string alertMesageStatusChange_InProgress = this.TestContext.DataRow["alertMesageStatusChange_InProgress"].ToString();
                string requestLOATab_InProgress = this.TestContext.DataRow["requestLOATab_InProgress"].ToString();
                string itemsOrProductsLabel = this.TestContext.DataRow["itemsOrProductsLabel"].ToString();

                string emailId = this.TestContext.DataRow["emailId"].ToString();
                string itemNoOne = this.TestContext.DataRow["itemNoOne"].ToString();
                string appTypeOne = this.TestContext.DataRow["appTypeOne"].ToString();
                string appAgencyOne = this.TestContext.DataRow["appAgencyOne"].ToString();
                string itemDescriptionOne = this.TestContext.DataRow["itemDescriptionOne"].ToString();
                string loaDocumentsTabLabelFirst = this.TestContext.DataRow["loaDocumentsTabLabelFirst"].ToString();
                string expectedWord = "Facility:";
                string loaTemplate = "CZ_Syringe";

                string loaId = CreateLOAIDInWestDigitalApplication(emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, "CZTemplate");
                
                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.SearchEntryInInboxHomePage(inbox, loaId);
                _requestLOAAction.OpenActionsFromInboxHomePage(inbox, editRequestLoaAction, itemsOrProductsLabel);
                _requestLOAAction.ValidateWestItemNoInLoaItemsOrProductsTab(itemNoOne);

                NavigateToInboxByInboxSearchOption(function, inbox);
                _requestLOAAction.ChangeLOAStatus(inbox, loaId, editRequestLoaAction, loaStatus_InProgress, alertTitleStatusChange_InProgress, alertMesageStatusChange_InProgress);

                NavigateToInboxByInboxSearchOption(function, inbox_LOADocuments);
                _requestLOAAction.SearchItemInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst);
                _requestLOAAction.ScrollHorizontallyTillColumnDisplayed("File Leaf Ref", 50);
                int fileCount = _requestLOAAction.GetFileCountInLOADocumentPage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
                string documentName = "";
                bool flag = false;
                for (int i = 0; i < fileCount; i++)
                {
                    documentName = "";
                    documentName = _requestLOAAction.GetLOADocumentName(loaId, i+1);
                    if (documentName.Contains(loaTemplate))
                    {
                        flag = true;
                        if (_requestLOAAction.ValidateTextExistanceInLoaDocument(i, editLoaDocumentAction, expectedWord))
                            Assert.Fail("The '" + expectedWord + "' is not found in LOA Document");
                        else
                            Assert.AreEqual(expectedWord, expectedWord, "The '" + expectedWord + "' is found in LOA Document");
                    }
                }
                if (!flag)
                {
                    Assert.Fail("The '"+ loaTemplate + "' text is not found in LOA Document name,'" + documentName + "'");
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        public string CreateLOAIDInWestDigitalApplication(string dataContent = "SingleEntry", string westItemNumber = "")
        {
            NavigateToInboxByInboxSearchOption("Regulatory & Compliance", "Request LOA");
            _requestLOAAction.WaitForLoadingToDisappear();
            _inboxAction.VerifyInboxName("Request LOA");
            _inboxAction.VerifyInboxDataAvalability();
            _inboxAction.SortDataBy("LOA ID", SortOrder.Descending);
            _requestLOAAction.SelectTabOfInboxHomePage("All");
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesBeforeLoaCreation = _baseAction.GetFirstRowValues();
            string newLOA = Convert.ToString((int.Parse(rowValuesBeforeLoaCreation[0]) + 1));

            string AccessToken = _requestLOAAction.GenerateAccessToken(clientId, clientSecret);
            var LOAResponse = _requestLOAAction.CreateLOAApiPOST(AccessToken, newLOA, applicationEnvironment.ToLower(), dataContent, westItemNumber);
            WaitForMoment(10);
            _requestLOAAction.ClickRefreshButton();
            _requestLOAAction.SelectTabOfInboxHomePage("All");
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesAfterLoaCreation = _baseAction.GetFirstRowValues();
            Assert.AreEqual(newLOA, rowValuesAfterLoaCreation[0], "The LOA ID, '" + newLOA + "' is not created");
            Assert.AreEqual("New", rowValuesAfterLoaCreation[1], "The LOA ID's status is not 'New'");

            return rowValuesAfterLoaCreation[0];
        }

        public string CreateLOAIDInWestDigitalApplication(string emailId, string itemNoOne, string appTypeOne, string appAgencyOne, string itemDescriptionOne, string attribute, string formulation = "", string configuration = "")
        {
            NavigateToInboxByInboxSearchOption("Regulatory & Compliance", "Request LOA");
            _requestLOAAction.WaitForLoadingToDisappear();
            _inboxAction.VerifyInboxName("Request LOA");
            _inboxAction.VerifyInboxDataAvalability();
            _inboxAction.SortDataBy("LOA ID", SortOrder.Descending);
            _requestLOAAction.SelectTabOfInboxHomePage("All");
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesBeforeLoaCreation = _baseAction.GetFirstRowValues();
            string newLOA = Convert.ToString((int.Parse(rowValuesBeforeLoaCreation[0]) + 1));

            string AccessToken = _requestLOAAction.GenerateAccessToken(clientId, clientSecret);
            var LOAResponse = _requestLOAAction.CreateLOAApiPOST(AccessToken, newLOA, applicationEnvironment.ToLower(), emailId, itemNoOne, appTypeOne, appAgencyOne, itemDescriptionOne, attribute, formulation, configuration);
            WaitForMoment(10);
            _requestLOAAction.ClickRefreshButton();
            _requestLOAAction.SelectTabOfInboxHomePage("All");
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesAfterLoaCreation = _baseAction.GetFirstRowValues();
            Assert.AreEqual(newLOA, rowValuesAfterLoaCreation[0], "The LOA ID, '" + newLOA + "' is not created");
            Assert.AreEqual("New", rowValuesAfterLoaCreation[1], "The LOA ID's status is not 'New'");
            
            return rowValuesAfterLoaCreation[0];
        }
    }
}
