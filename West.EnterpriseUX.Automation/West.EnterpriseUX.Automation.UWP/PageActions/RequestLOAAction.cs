using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using Microsoft.Test.Input;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using SeleniumExtras.PageObjects;
using System.Net.Http.Formatting;
using West.EnterpriseUX.Automation.UWP.Utilities;
using System.Text.RegularExpressions;
using System.Threading;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class RequestLOAAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly RequestLOAPage _requestLoaPageInstance;
        protected static InboxAction _inboxAction;
        protected WebDriverWait wait;
        IDictionary<string, string> apiInput;
        HashSet<string> hashSetExpectedFirstRowContacts;
        HashSet<string> hashSetExpectedSecondRowContacts;

        List<LoaAgencyTableInfo> LoaAgencyExpectedRowList = new List<LoaAgencyTableInfo>();
        List<LoaItemTableInfo> LoaItemExpectedRowList = new List<LoaItemTableInfo>();
        List<LoaProductTableInfo> LoaProductExpectedRowList = new List<LoaProductTableInfo>();

        public RequestLOAAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _requestLoaPageInstance = new RequestLOAPage(_session);
            _inboxAction = new InboxAction(_session);
        }

        #region ElementSpecificActions

        public void ClickOnOptionsOfActionDots(string actionValue)
        {
            ClickElement(_requestLoaPageInstance.DetailActionOptionButton(actionValue));
            LogInfo("Clicked on '" + actionValue + "' from the three dots");
            WaitForMoment(5);
        }
        public void GetLOAIDFromRequestLOAPage(string loaId)
        {
            Assert.AreEqual(loaId, GetAttribute(_requestLoaPageInstance.LOAIDTextBox, "Value.Value"));
            LogInfo("Validated LOA ID, '" + loaId + "' in the LOA Request tab");
        }
        public void ValidateAgencyAbbrUpdateAgencyPage(string agencyAbbreviation)
        {
            Assert.AreEqual(agencyAbbreviation, GetAttribute(_requestLoaPageInstance.AgencyAbbreviationEntryTextbox, "Value.Value"));
            LogInfo("Validated Agency Abbreviation, '" + agencyAbbreviation + "' in 'Update Selected Agency' page");
        }
        public void ValidatePageTitleAddOrUpdateInboxPage(string expectedPageTitleAddOrUpdateInboxItem)
        {
            Assert.AreEqual(expectedPageTitleAddOrUpdateInboxItem, _requestLoaPageInstance.PageTitleAddOrUpdateInboxItem.Text, "The page title, '" + expectedPageTitleAddOrUpdateInboxItem + "' is not diplayed in the 'Add or Update' inbox page");
            LogInfo("Validated  page title, '" + expectedPageTitleAddOrUpdateInboxItem + "' in the 'Add or Update' inbox page");
        }
        public void SelectStatusDropDownValue(string dropDownItemName)
        {
            ClickElement(_requestLoaPageInstance.DropDownBox);
            LogInfo("Clicked on 'Status' DropDown Box");
            WaitForMoment(0.5);
            ClickElement(_requestLoaPageInstance.DropDownBoxListItem(dropDownItemName));
            LogInfo("Choosed the 'status' as '" + dropDownItemName + "' from the dropdown list");
        }
        public void SelectTabOfInboxHomePage(string tabName)
        {
            ClickElement(_requestLoaPageInstance.TabNameFromInboxHomePage(tabName));
            LogInfo("Clicked on the '" + tabName + "' in the 'Request LOA' page");
            WaitForLoadingToDisappear();
        }
        public string GetTabLabelOfInboxHomePage(string tabName)
        {
            LogInfo("Read the tab label, '" + tabName + "' from the inbox home page");
            return _requestLoaPageInstance.TabNameFromInboxHomePage(tabName).Text;
        }
        public void ClickRefreshButton()
        {
            ClickElement(_requestLoaPageInstance.RefreshButton);
            LogInfo("Clicked on the 'Refresh' button");
            WaitForLoadingToDisappear();
        }
        public void ClickSaveButton()
        {
            ClickElement(_requestLoaPageInstance.SaveButton);
            LogInfo("Clicked on the 'Save' button after changing the status to 'In Progress'");
            WaitForElementToAppear("OK");
        }
        public void ClickBackButton()
        {
            ClickElement(_requestLoaPageInstance.BackButton);
            LogInfo("Clicked on the 'Back' button in the left top of the page");
        }
        public void ClickCancelButton()
        {
            ClickElement(_requestLoaPageInstance.LoaDocumentCancelButton);
            LogInfo("Clicked on the 'Cancel' button from the 'Loa Documents Meatadata' page");
        }
        public void ClickVerticalIncreaseIcon(int noOfClicks=2)
        {
            for(int i = 0; i<noOfClicks; i++) { 
                ClickElement(_requestLoaPageInstance.VerticalSmallIncreaseIcon);
            }
            LogInfo("Clicked on the 'VerticalIncrease' Icon for '"+ noOfClicks + "' from the 'Agency' inbox homepage");
        }
        public void ScrollHorizontallyTillColumnDisplayed(string columnHeader, int noOfClicks = 20)
        {
            MouseHoverOnWindowsElement(_requestLoaPageInstance.ValuebyRowAndColumnInGrid()[0]);
            MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
            ClickElement(_requestLoaPageInstance.HorizontalSmallIncreaseIcon);
            for (int i = 0; i < noOfClicks; i++)
            {
                ClickElement(_requestLoaPageInstance.HorizontalSmallIncreaseIcon);
                try 
                {
                    if (VerifyLOADocumentInboxColumnHeaderVisible(columnHeader))
                    {
                        break;
                    }
                }
                catch(Exception) 
                {
                    LogInfo(columnHeader + " is not displayed in the screen");
                }
            }
            LogInfo("Clicked on the 'VerticalIncrease' Icon for '" + noOfClicks + "' from the 'Agency' inbox homepage");
        }
        public void ClickAlertWindowOKButton(string alertTitle, string alertMesage, string alertButtonText = "OK")
        {
            WaitForElementToAppear(alertButtonText);
            if (!string.IsNullOrEmpty(alertTitle))
                Assert.AreEqual(alertTitle, _requestLoaPageInstance.AlertWindowDialogTitle.Text.Trim(), "Alert window dialogue title is not expected, '" + _requestLoaPageInstance.AlertWindowDialogTitle.Text + "'");
            Assert.AreEqual(alertMesage, _requestLoaPageInstance.AlertWindowDialogMessage.Text.Trim(), "Alert window dialogue message is not expected, '" + _requestLoaPageInstance.AlertWindowDialogMessage.Text + "'");
            ClickElement(_requestLoaPageInstance.AlertWindowOKButton);
            LogInfo("Clicked on the '"+ alertButtonText + "' button and validated the alert message '"+ alertMesage + "' in the alert window");
        }
        public void ClickLOADocumentUpdateButton()
        {
            ClickElement(_requestLoaPageInstance.ReviewLOADocumentUpdateButton);
            LogInfo("Clicked on the 'Update' button");
            WaitForElementToAppear("OK");
        }
        public void ClickTabFromEditRequestLOA(string tabName)
        {
            ClickElement(_requestLoaPageInstance.TabFromEditRequestLOA(tabName));
            LogInfo("Clicked on the tab, '" + tabName + "' from the 'EditRequestLOA' page");
        }
        public void ClickNewProductCreationButton()
        {
            ClickElement(_requestLoaPageInstance.NewProductCreationButton);
            LogInfo("Clicked on the 'New Product Creation' button from 'Product' inbox page");
            WaitForElementToAppear("New Product Creation");
            Assert.AreEqual(_requestLoaPageInstance.NewProductCreationPageTitleLabel.Text, "New Product Creation", "The header text, 'New Product Creation' is not diplayed in 'New Product Creation' page");
        }
        public void ClickNewProductSaveButton()
        {
            ClickElement(_requestLoaPageInstance.NewProductSaveButton);
            LogInfo("Clicked on the 'Save' button after entering all details in 'New Product Creation' page");
            WaitForElementToAppear("OK");
        }
        public void SelectDropDownValue(WindowsElement dropDownWindowElement, string dropDownValue)
        {
            ClickElement(dropDownWindowElement);
            LogInfo("Clicked on DropDown Box");
            WaitForMoment(0.5);
            ClickElement(_requestLoaPageInstance.DropDownBoxListItem(dropDownValue));
            LogInfo("Choosed the value as '" + dropDownValue + "'");
        }
        public void ClickEmailStatementsCheckboxes(List<String> checkboxNames)
        {
            checkboxNames.ForEach(value =>
            {
                _requestLoaPageInstance.EmailStatementCheckbox(value).Click();
                LogInfo("Clicked the value '" + value + "' from 'Standard Email Statement' checkboxes");
            });
        }
        public void ToggleInboxesVisibility(bool hideInboxRegion)
        {
            IList<WindowsElement> inboxesRefreshButton = _requestLoaPageInstance.InboxesSearchButton;
            if (hideInboxRegion)
            {
                if (inboxesRefreshButton.Count > 0)
                {
                    _requestLoaPageInstance.InboxesToggleButton.Click();
                    LogInfo("Hid the Inbox region");
                }
                else
                    LogInfo("The Inbox region is already in hidden status");
            }
            else
            {
                if (inboxesRefreshButton.Count == 0)
                {
                    _requestLoaPageInstance.InboxesToggleButton.Click();
                    LogInfo("Unhid the Inbox region");
                }
                else
                    LogInfo("The Inbox region is already in unhidden status");
            }
        }
        public void SelectContainsMCBTDropDownValue(string dropDownItemName)
        {
            ClickElement(_requestLoaPageInstance.Contains2MCBTPickerDropdown);
            LogInfo("Clicked on 'Contains2MCBT' DropDown Box");
            WaitForMoment(0.5);
            ClickElement(_requestLoaPageInstance.DropDownBoxListItem(dropDownItemName));
            LogInfo("Choosed the 'Contains2MCBT' as '" + dropDownItemName + "' from the dropdown list");
        }

        //Coating DMF Inbox
        public void ValidateCoatingLocationUpdateCoatingDmfPage(string coatingLocation)
        {
            Assert.AreEqual(coatingLocation, GetAttribute(_requestLoaPageInstance.NewCoatingLocationTextbox, "Value.Value"));
            LogInfo("Validated Coating Name, '" + coatingLocation + "' in 'Update Selected Coating' page");
        }
        public static void ClearTextboxValues(WindowsElement windowElement)
        {
            ClickElement(windowElement);
            windowElement.SendKeys(Keys.Control + "a");
            windowElement.SendKeys(Keys.Delete);
        }

        //DMF Inbox
        public void ValidateDmfNumberUpdateDmfPage(string dmfNumber)
        {
            Assert.AreEqual(dmfNumber, GetAttribute(_requestLoaPageInstance.NewDmfNumberEntryTextbox, "Value.Value"));
            LogInfo("Validated DMF Number, '" + dmfNumber + "' in 'Update Selected DMF' page");
        }

        //Plant
        public void ValidatePlantAddressUpdatePlantPage(string plantAddress)
        {
            Assert.AreEqual(plantAddress, GetAttribute(_requestLoaPageInstance.NewPlantAddressEntry, "Value.Value"));
            LogInfo("Validated Plant Address, '" + plantAddress + "' in 'Update Plant' page");
        }

        //Product
        public void ValidateWestItemNumberInUpdateProductPage(string westItemNumber)
        {
            Assert.AreEqual(westItemNumber, GetAttribute(_requestLoaPageInstance.WestItemNumberTextbox, "Value.Value"));
            LogInfo("Validated Plant Address, '" + westItemNumber + "' in 'Update Plant' page");
        }

        //Standard Email Statement
        public void ValidateTitleUpdateStandardEmailStatementPage(string title)
        {
            Assert.AreEqual(title, GetAttribute(_requestLoaPageInstance.NewStandardEmailsTitleEntry, "Value.Value"));
            LogInfo("Validated Title, '" + title + "' in 'Update Standard Email Statement' page");
        }


        //Generic Method
        public void ClickNewInboxItemCreationButton(string inbox, string newItemCreationButtonName)
        {
            ClickElement(_requestLoaPageInstance.NewInboxItemCreationButton(newItemCreationButtonName));
            LogInfo("Clicked on the 'New "+ inbox + " Creation' button from the '"+ inbox + "' inbox home page");
        }
        public void ClickNewInboxItemSaveButton(string inbox)
        {
            ClickElement(_requestLoaPageInstance.NewInboxItemSaveButton);
            LogInfo("Clicked on the 'Save' button from the 'New "+ inbox + " Creation' page");
        }
        public void ValidateInboxItemInUpdateInboxItemsPage(string inbox, string inboxItemValue)
        {
            Assert.AreEqual(inboxItemValue, GetAttribute(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), "Value.Value"));
            LogInfo("Validated "+ inbox + " Name, '" + inboxItemValue + "' in 'Update " + inbox + "' page");
        }
        public string GetIsDykoEmailSentValue(string requestLOATabName)
        {
            string isDykoEmailSentValue;
            if (requestLOATabName == "New")
                isDykoEmailSentValue = GetAttribute(_requestLoaPageInstance.IsDykoEmailSentNew, "Name");
            else if (requestLOATabName == "In Progress")
                isDykoEmailSentValue = GetAttribute(_requestLoaPageInstance.IsDykoEmailSentInProgress, "Name");
            else if (requestLOATabName == "Out for Approval")
                isDykoEmailSentValue = GetAttribute(_requestLoaPageInstance.IsDykoEmailSentOutForApproval, "Name");
            else
                isDykoEmailSentValue = GetAttribute(_requestLoaPageInstance.IsDykoEmailSentNew, "Name");

            LogInfo("Get the 'Name' field value, '" + isDykoEmailSentValue + "' in the '"+ requestLOATabName + "' tab of 'Request LOA' page");
            return isDykoEmailSentValue;
        }

        #endregion



        #region Methods

        public void SearchEntryInInboxHomePage(string inbox, string searchItemId, string tabNameInInboxHomePage = "New", string searchingItem = "LOA")
        {
            _inboxAction.VerifyInboxName(inbox);
            _inboxAction.VerifyInboxDataAvalability();
            SelectTabOfInboxHomePage(tabNameInInboxHomePage);
            _inboxAction.VerifyInboxDataAvalability();
            _inboxAction.EnterSearchValueInGrid(searchItemId);
            _inboxAction.ClickOnSearchButton();
            WaitForMoment(3);
            if (searchingItem == "LOA")
                Assert.AreEqual(searchItemId, GetFirstRowValues()[0], "The LOA ID, '" + searchItemId + "' is not diplayed in 'Request LOA' inbox page");
            else if (searchingItem == "WestItem")
                Assert.AreEqual(searchItemId, GetFirstRowValues()[0], "The West Item Number, '" + searchItemId + "' is not diplayed in 'Product' inbox page");
            else if (searchingItem == "LOADocuments")
            {
                string searchItem;
                if (searchItemId.Contains("_")) 
                { 
                    searchItem = searchItemId.Split('_')[0];
                    Assert.AreEqual(searchItem, GetRowValues(1)[2], "The LOA ID, '" + searchItem + "' is not diplayed in 'LOA Documents' page");
                }
                else
                Assert.AreEqual(searchItemId, GetRowValues(1)[2], "The LOA ID, '" + searchItemId + "' is not diplayed in 'LOA Documents' page");
            }
            else if (searchingItem == "LOAPDF")
                Assert.AreEqual(String.IsNullOrEmpty(GetRowValues(1)[5]), false, "The LOA ID, '" + searchItemId + "' is not diplayed in 'LOA PDF' page");
            else if (searchingItem == "Agency")
                Assert.AreEqual(searchItemId, GetFirstRowValues()[0], "The Agency, '" + searchItemId + "' is not diplayed in 'Agency' inbox page");
            else
                Assert.AreEqual(true, true, "No data available to verify for the inbox '"+ inbox +"'");

            LogInfo("Searched the value '" + searchItemId + "' in the '" + inbox + "' inbox home page successfully");
        }
        public void SearchItemInInboxHomePage(string inbox, string searchItemId, string tabNameInInboxHomePage)
        {
            _inboxAction.VerifyInboxName(inbox);
            _requestLoaPageInstance.SearchEditInGrid.Clear();
            WaitForMoment(3);
            SelectTabOfInboxHomePage(tabNameInInboxHomePage);
            _inboxAction.EnterSearchValueInGrid(searchItemId);
            _inboxAction.ClickOnSearchButton();
            WaitForMoment(3);
            _inboxAction.VerifyInboxDataAvalability();
            LogInfo("Searched the value '" + searchItemId + "' in the '" + inbox + "' inbox home page");
        }
        public void ChangeLOAStatus(string inbox, string loaId, string editRequestLoaAction, string loaStatus_Target, string alertTitleStatusChange, string alertMesageStatusChange, string requestLOATab = "New")
        {
            SearchEntryInInboxHomePage(inbox, loaId, requestLOATab);
            OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
            GetLOAIDFromRequestLOAPage(loaId);
            SelectStatusDropDownValue(loaStatus_Target);
            ClickSaveButton();
            ClickAlertWindowOKButton(alertTitleStatusChange, alertMesageStatusChange);
            LogInfo("Changed the LOA status to '" + loaStatus_Target + "' in the '" + inbox + "' inbox page");
        }
        public void ChangeLOAStatusWithMissingTemplate(string inbox, string loaId, string editRequestLoaAction, string loaStatus_Target, string alertTitleStatusChange, string alertMesageStatusChange, string alertMessageNoProductAdded, string requestLOATab = "New")
        {
            SearchEntryInInboxHomePage(inbox, loaId, requestLOATab);
            OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
            WaitForMoment(3);
            ClickAlertWindowOKButton("", alertMessageNoProductAdded);
            GetLOAIDFromRequestLOAPage(loaId);
            SelectStatusDropDownValue(loaStatus_Target);
            ClickSaveButton();
            ClickAlertWindowOKButton(alertTitleStatusChange, alertMesageStatusChange);
            ClickBackButton();
            LogInfo("Changed the LOA status of missing template to '" + loaStatus_Target + "' in the '" + inbox + "' inbox page");
        }
        public void AddStandardEmailStatement(string inbox, string loaId, string editRequestLoaAction, string loaStatus_Target, string alertTitleStatusChange, string alertMesageStatusChange, List<String> emailStatementCheckboxItems, string requestLOATab = "New")
        {
            SearchEntryInInboxHomePage(inbox, loaId, requestLOATab);
            OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
            GetLOAIDFromRequestLOAPage(loaId);
            SelectStatusDropDownValue(loaStatus_Target);
            ValidateEmailStatementTextboxes();
            ClickEmailStatementsCheckboxes(emailStatementCheckboxItems);
            ValidateEmailStatementTextboxes(true);
            ClickSaveButton();
            ClickAlertWindowOKButton(alertTitleStatusChange, alertMesageStatusChange);
            LogInfo("Added standard email statements, in the '" + inbox + "' inbox page");
        }
        public void ValidateEmailStatementTextboxes(bool isEmailStatementsChoosed = false)
        {
            string emailText = _requestLoaPageInstance.EmailStatementTextbox.Text;
            if (isEmailStatementsChoosed)
                Assert.AreEqual(String.IsNullOrEmpty(emailText), false, "The 'Standard Email Statement' textbox is empty in 'Loa Request' page");
            else
                Assert.AreEqual(String.IsNullOrEmpty(emailText), true, "The 'Standard Email Statement' textbox is not empty in 'Loa Request' page");
            LogInfo("Validated standard email statements, when 'isEmailStatementsChoosed' is '"+ isEmailStatementsChoosed + "'");
        }
        public void ValidateLOAStatusInRequestLOA(string inbox, string loaId, string requestLOATab, string loaStatus)
        {
            _inboxAction.VerifyInboxName(inbox);
            ClickRefreshButton();
            _inboxAction.VerifyInboxDataAvalability();
            SelectTabOfInboxHomePage(requestLOATab);
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesAfterChangingLoaStatus = GetFirstRowValues();
            Assert.AreEqual(loaId, rowValuesAfterChangingLoaStatus[0], "The LOA ID, '" + loaId + "' is not created");
            Assert.AreEqual(loaStatus, rowValuesAfterChangingLoaStatus[1], "The LOA ID's status is not '" + loaStatus + "'");
            LogInfo("Validated the status of the LOA, '" + loaId + "' as '"+ loaStatus + "' in the '"+ inbox + "' inbox page");
        }
        public string UpdateLOADocument(string inbox_LOADocuments, string loaId, string editLoaDocumentAction, string alertTitleDocumentUpdate, string alertMesageDocumentUpdate, string loaUpdateStrength = "simple", string loaDocumentsTabLabelFirst = "This Month Documents")
        {
            string documentId = "";

            SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
            List<String> rowValuesLOADocumentsPage = GetFirstRowValues();
            if (loaUpdateStrength == "simple")
                documentId = rowValuesLOADocumentsPage[0];
            OpenActionsFromInboxHomePage(inbox_LOADocuments, editLoaDocumentAction);
            ClickLOADocumentUpdateButton();
            ClickAlertWindowOKButton(alertTitleDocumentUpdate, alertMesageDocumentUpdate);
            LogInfo("Updated the LOA Document of the LOA, '" + loaId + " in the '" + inbox_LOADocuments + "' inbox page");
            return documentId;
        }
        public string GetLOADocumentName(string inbox_LOADocuments, string loaId, int rowNumber, string loaDocumentsTabLabelFirst = "This Month Documents")
        {
            string documentName = "";
            List<String> rowValuesLOADocumentsPage = GetRowValues(rowNumber+1);
            documentName = rowValuesLOADocumentsPage[3];
            LogInfo("Get the LOA Document Name, of the LOA, '" + loaId + " in the '" + inbox_LOADocuments + "' inbox page");
            return documentName;
        }
        public string GetLOADocumentName(string loaId, int rowNumber)
        {
            string documentName = _requestLoaPageInstance.WordDocColumnValue(rowNumber.ToString()).Text;
            LogInfo("Get the LOA Document Name, of the LOA, '" + loaId + " in the LOA Document inbox");
            return documentName;
        }
        public string GetLOAPdfName(string inbox_LOAPdfs, string loaId, int rowNumber, string loaPdfsTabLabelFirst = "This Month Pdfs")
        {
            string pdfName = "";
            List<String> rowValuesLOAPdfPage = GetRowValues(rowNumber + 1);
            pdfName = rowValuesLOAPdfPage[3];
            LogInfo("Get the LOA Pdf Name, of the LOA, '" + loaId + " in the '" + inbox_LOAPdfs + "' inbox page");
            return pdfName;
        }
        public void ValidateMissingProductTemplate(string inbox_LOADocuments, string loaId, string editLoaDocumentAction, string westItemNo, string loaDocumentsTabLabelFirst = "This Month Documents")
        {
            SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
            ScrollHorizontally_LOAPages(4);
            List<String> rowValuesLOADocumentsPage = GetRowValues(1);
            OpenActionsFromInboxHomePage(inbox_LOADocuments, editLoaDocumentAction);
            string expectedMissingProductTemplateText = "Missing product lookup record in LOA ID "+ loaId + ". Please add product lookup record for item number "+ westItemNo + " and regenerate documents.";
            string observedMissingProductTemplateText = _requestLoaPageInstance.ReviewLOADocMissingProduct.Text.Trim();
            Assert.AreEqual(String.Concat(expectedMissingProductTemplateText.Where(c => !Char.IsWhiteSpace(c))), String.Concat(observedMissingProductTemplateText.Where(c => !Char.IsWhiteSpace(c))), "The missing product template, '"+ observedMissingProductTemplateText + "' is not present in the 'Review Loa Document' page");
            Assert.AreEqual(string.IsNullOrEmpty(rowValuesLOADocumentsPage[7]), true, "The 'Template' attribute is not empty in the 'Review Loa Document' page");

            LogInfo("Validate the Missing Product Template in the '" + inbox_LOADocuments + "' inbox page");
        }
        public void ValidateLOADocumentMetadata(string inbox_LOADocuments, string loaId, string editDocumentsMetadataAction, string templates, string agencyEntry, string coating, string washPlant, string sterilePlant, string appTypeOne, string itemNoOne, string itemDescriptionOne, string configurationType, string loaDocumentsTabLabelFirst = "This Month Documents")
        {
            string lOADocumentName = loaId + "_" + agencyEntry + "_" + appTypeOne + "_" + apiInput["AppNo1"] + "_" + itemNoOne + "_" + templates + "_AN_" + apiInput["CustomerCompanyName"] + ".docx";
            string companyAddres = apiInput["CustomerAddress1"] + "," + apiInput["CustomerAddress2"] + "," + apiInput["CustomerAddress3"] + "," + apiInput["CustomerCity"] + "," + apiInput["CustomerState"] + "," + apiInput["CustomerCountry"] + "," + apiInput["CustomerPostalCode"];
            string referenceInformation = apiInput["Formulation"] + ";" + apiInput["Configuration"] + ";Option 2";

            SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
            OpenActionsFromInboxHomePage(inbox_LOADocuments, editDocumentsMetadataAction);

            Assert.AreEqual(_requestLoaPageInstance.LoaDocumentHeaderTextLabel.Text, "Loa Documents", "The header text, 'Loa Documents' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.LoaDocumentNameTextbox.Text, lOADocumentName, "The 'Name' field value, '" + lOADocumentName + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.LoaTemplateTextbox.Text, templates, "The 'Templates' field value, '" + templates + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.AgencyEntryTextbox.Text, agencyEntry, "The 'AgencyEntry' field value, '" + agencyEntry + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.LoaIdEntryTextbox.Text, loaId, "The 'Loa Id' field value, '" + loaId + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.WestItemNoTextbox.Text, itemNoOne, "The 'West Item No' field value, '" + itemNoOne + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.DrugEntryTextbox.Text, apiInput["DrugProductName"], "The 'Drug' field value, '" + apiInput["DrugProductName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.CompanyNameEntryTextbox.Text, apiInput["CustomerCompanyName"], "The 'Company Name' field value, '" + apiInput["CustomerCompanyName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.CoatingsTextbox.Text, coating, "The 'Coatings' field value, '" + coating + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.FormulationEntryTextbox.Text, apiInput["Formulation"], "The 'Formulation' field value, '" + apiInput["Formulation"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.CityEntryTextbox.Text, apiInput["CustomerCity"], "The 'City' field value, '" + apiInput["CustomerCity"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.StateEntryTextbox.Text, apiInput["CustomerState"], "The 'State' field value, '" + apiInput["CustomerState"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.PostalCodeEntryTextbox.Text, apiInput["CustomerPostalCode"], "The 'Postal Code' field value, '" + apiInput["CustomerPostalCode"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.ApplicationTypeTextbox.Text, appTypeOne, "The 'Application Type' field value, '" + appTypeOne + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.CountryEntryTextbox.Text, apiInput["CustomerCountry"], "The 'Country' field value, '" + apiInput["CustomerCountry"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.AddressEntryTextbox.Text, apiInput["CustomerAddress1"], "The 'Address' field value, '" + apiInput["CustomerAddress1"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.Address2EntryTextbox.Text, apiInput["CustomerAddress2"], "The 'Address 2' field value, '" + apiInput["CustomerAddress2"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.Address3EntryTextbox.Text, apiInput["CustomerAddress3"], "The 'Address 3' field value, '" + apiInput["CustomerAddress3"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.FirstNameEntryTextbox.Text, apiInput["CustomerFirstName"], "The 'First Name' field value, '" + apiInput["CustomerFirstName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.LastNameEntryTextbox.Text, apiInput["CustomerLastName"], "The 'Last Name' field value, '" + apiInput["CustomerLastName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.ContactsTitleEntryTextbox.Text, apiInput["CustomerTitle"], "The 'Contacts Title' field value, '" + apiInput["CustomerTitle"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorFirstNameEntryTextbox.Text, apiInput["FirstName"], "The 'Requestor First Name' field value, '" + apiInput["FirstName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorLastNameEntryTextbox.Text, apiInput["LastName"], "The 'Requestor Last Name' field value, '" + apiInput["LastName"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorContactsTitleEntryTextbox.Text, apiInput["YourTitle"], "The 'Requestor Contacts Title' field value, '" + apiInput["YourTitle"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorAddress1EntryTextbox.Text, apiInput["Address1"], "The 'Requestor Address 1' field value, '" + apiInput["Address1"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorAddress2EntryTextbox.Text, apiInput["Address2"], "The 'Requestor Address 2' field value, '" + apiInput["Address2"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorAddress3EntryTextbox.Text, apiInput["Address3"], "The 'Requestor Address 3' field value, '" + apiInput["Address3"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorCityEntryTextbox.Text, apiInput["City"], "The 'Requestor City' field value, '" + apiInput["City"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorStateEntryTextbox.Text, apiInput["State"], "The 'Requestor State' field value, '" + apiInput["State"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorPostalCodeEntryTextbox.Text, apiInput["PostalCode"], "The 'Requestor Postal Code' field value, '" + apiInput["PostalCode"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorCountryEntryTextbox.Text, apiInput["Country"], "The 'Requestor Country' field value, '" + apiInput["Country"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.RequestorCompanyEntryTextbox.Text, apiInput["Company"], "The 'Requestor Company' field value, '" + apiInput["Company"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual((Regex.Replace(_requestLoaPageInstance.FileNameDatePickerControlTextbox.Text.ToString(), @"[^0-9a-zA-Z:,]+", "")), (Regex.Replace(apiInput["DateRequested_Format"], @"[^0-9a-zA-Z:,]+", "")), "The 'File Name Date' field value, '" + apiInput["DateRequested_Format"] + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.WashPlantTextbox.Text, washPlant, "The 'Wash Plant' field value, '" + washPlant + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.SterilePlantTextbox.Text, sterilePlant, "The 'Sterile Plant' field value, '" + sterilePlant + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.CompanyAddressEntryTextbox.Text, companyAddres, "The 'Company Address' field value, '" + companyAddres + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.ItemDescriptionEntryTextbox.Text.ToString().Replace(" ", ""), itemDescriptionOne.Replace(" ", ""), "The 'Item Description' field value, '" + itemDescriptionOne + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.ReferenceInformationEntryTextbox.Text, referenceInformation, "The 'Reference Information' field value, '" + referenceInformation + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.ConfigurationTypeEntryTextbox.Text, configurationType, "The 'Configuration Type' field value, '" + configurationType + "' is not diplayed in 'LOA Documents' metadata page");
            Assert.AreEqual(_requestLoaPageInstance.LoaReferenceInformationEntryTextbox.Text, referenceInformation, "The 'Loa Reference Information' field value, '" + referenceInformation + "' is not diplayed in 'LOA Documents' metadata page");

            LogInfo("Validate LOA Document Metadata in the '" + inbox_LOADocuments + "' inbox page");

            ClickCancelButton();

        }
        public void OpenActionsFromInboxHomePage(string inbox, string actionsItem, string tabName = "Loa Request")
        {
            _inboxAction.ClickOnDetailActionForFirstRecord();
            ClickOnOptionsOfActionDots(actionsItem);
            if (inbox == "Request LOA")
                ClickTabFromEditRequestLOA(tabName);
            else if (inbox == "LOA PDF" && actionsItem == "Delete Loa Pdf")
                WaitForElementToAppear("YES");
            else if (inbox == "LOA Documents" && actionsItem == "Delete LOA Word Document")
                WaitForElementToAppear("YES");
            else
                WaitForLoadingToDisappear();
            LogInfo("Clicked on the '"+ actionsItem + "' from the '"+ inbox + "' inbox home page");
        }
        public void DeleteLOAFilesFromAction(string inbox, string deletLoaFileAction, string alertTitleDeleteLOAFile, string alertMesageDeleteLOAFile, string loaInboxTabLebel)
        {
            string loaFileCount;
            string tabLabel = GetTabLabelOfInboxHomePage(loaInboxTabLebel).ToString().Trim();
            if (tabLabel.Contains("("))
                loaFileCount = tabLabel.Substring(tabLabel.IndexOf("(") + 1).Substring(0, tabLabel.Substring(tabLabel.IndexOf("(") + 1).IndexOf(")"));
            else
                loaFileCount = "0";
            int pdfCount = Convert.ToInt32(loaFileCount);
            for (int i = 0; i < pdfCount; i++)
            {
                OpenActionsFromInboxHomePage(inbox, deletLoaFileAction);
                ClickAlertWindowOKButton(alertTitleDeleteLOAFile, alertMesageDeleteLOAFile, "YES");
                WaitForLoadingToDisappear();
                WaitForMoment(2);
            }
            LogInfo("Deleted the LOA files from the '" + inbox + "' inbox page");
        }
        public void ScrollHorizontally()
        {
            try
            {
                MouseHoverOnWindowsElement(_requestLoaPageInstance.ValuebyRowAndColumnInGrid()[0]);
                MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
                WaitForMoment(2);
                int offsetX = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.X;
                int offsetY = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.Y;
                Mouse.DragTo(MouseButton.Left, new Point(offsetX - 100, offsetY)); 
                LogInfo("Srolled the page horizontally");
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }
        public void ScrollHorizontallyRequestLOAInboxPage()
        {
            try
            {
                MouseHoverOnWindowsElement(_requestLoaPageInstance.FirstRowDetailAction);
                MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
                WaitForMoment(2);
                int offsetX = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.X;
                int offsetY = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.Y;
                Mouse.DragTo(MouseButton.Left, new Point(offsetX - 100, offsetY));
                LogInfo("Srolled the page horizontally");
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }
        public void ScrollHorizontally_LOAPages(int count)
        {
            try
            {
                MouseHoverOnWindowsElement(_requestLoaPageInstance.ValuebyRowAndColumnInGrid()[0]);
                MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
                WaitForMoment(2);
                int offsetX = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.X;
                int offsetY = _requestLoaPageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.Y;
                for (int i = 0; i < count; i++)
                {
                    Mouse.DragTo(MouseButton.Left, new Point(offsetX - 10, offsetY));
                    WaitForMoment(2);
                }
                LogInfo("Srolled the LOA page horizontally");
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }
        public void ValidateEditRequestLoaPageElements(string loaId, string tabName = "Loa Request")
        {
            if (tabName == "Loa Request")
            {
                Assert.AreEqual(_requestLoaPageInstance.LoaRequestHeaderText.Text.ToString(), tabName, "The header text, '" + tabName + "' is not diplayed in 'LOA Request' page");
                Assert.AreEqual(loaId, GetAttribute(_requestLoaPageInstance.LOAIDTextBox, "Value.Value"), "The 'LOA ID', '" + loaId + "' is not diplayed in 'LOA Request' page");
                Assert.AreEqual("New", _requestLoaPageInstance.DropDownBox.Text, "The 'Status', 'New' is not diplayed in 'LOA Request' page");
                Assert.AreEqual((Regex.Replace(_requestLoaPageInstance.DateRequestedTextbox.Text.ToString(), @"[^0-9a-zA-Z:,]+", "")), (Regex.Replace(apiInput["DateRequested_Format"], @"[^0-9a-zA-Z:,]+", "")), "The 'Date Requested', '" + apiInput["DateRequested_Format"] + "' is not diplayed in 'LOA Request' page");
                Assert.AreEqual((Regex.Replace(_requestLoaPageInstance.DateRequiredTextbox.Text.ToString(), @"[^0-9a-zA-Z:,]+", "")), (Regex.Replace(apiInput["DateRequired_Format"], @"[^0-9a-zA-Z:,]+", "")), "The 'Date Required', '" + apiInput["DateRequired_Format"] + "' is not diplayed in 'LOA Request' page");
                Assert.AreEqual(_requestLoaPageInstance.DrugTextbox.Text, apiInput["DrugProductName"], "The 'Drug', '" + apiInput["DrugProductName"] + "' is not diplayed in 'LOA Requet' page");
                Assert.AreEqual(_requestLoaPageInstance.ContractLabTestTextbox.Text, apiInput["ContractLabTest"], "The 'ContractLabTest', '" + apiInput["ContractLabTest"] + "' is not diplayed in 'LOA Request' page");
                Assert.AreEqual(_requestLoaPageInstance.CustomerInstructionTextbox.Text, apiInput["Instruct"], "The 'Customer Instructions', '" + apiInput["Instruct"] + "' is not diplayed in 'LOA Request' page");
            }
            else if (tabName == "Loa Contact")
            {
                HashSet<string> hashSetActualFirstRowContacts = new HashSet<string>();
                HashSet<string> hashSetActualSecondRowContacts = new HashSet<string>();

                GetRowValues(1, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
                {
                    if (!hashSetActualFirstRowContacts.Contains(value))
                        hashSetActualFirstRowContacts.Add(value);
                });
                GetRowValues(2, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
                {
                    if (!hashSetActualSecondRowContacts.Contains(value))
                        hashSetActualSecondRowContacts.Add(value);
                });

                ScrollHorizontally();
                GetRowValues(1, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
                {
                    if (!hashSetActualFirstRowContacts.Contains(value))
                        hashSetActualFirstRowContacts.Add(value);
                });
                GetRowValues(2, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
                {
                    if (!hashSetActualSecondRowContacts.Contains(value))
                        hashSetActualSecondRowContacts.Add(value);
                });

                Assert.AreEqual(_requestLoaPageInstance.LoaContactHeaderText.Text.ToString().Contains(tabName), true, "The header text, '" + _requestLoaPageInstance.LoaContactHeaderText.Text.ToString() + "' is not diplayed in 'Contacts' page");
                Assert.AreEqual(hashSetExpectedFirstRowContacts.SetEquals(hashSetActualFirstRowContacts), true, "The LOA Contacts details in the first row is not diplayed correctly in 'Contacts' page");
                Assert.AreEqual(hashSetExpectedSecondRowContacts.SetEquals(hashSetActualSecondRowContacts), true, "The LOA Contacts details in the second row is not diplayed correctly in 'Contacts' page");
            }
            else if (tabName == "Loa Agency")
            {
                List<LoaAgencyTableInfo> LoaAgencyRowList = new List<LoaAgencyTableInfo>();
                string tabNameWithoutSpace = String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)));

                int rowCount = _requestLoaPageInstance.GetRowsInEditRequestLoaGrid(tabNameWithoutSpace).Count;
                for (int i = 1; i < rowCount; i++)
                {
                    List<String> LoaAgencyRowValues = GetRowValues(i, tabNameWithoutSpace);
                    LoaAgencyRowList.Add(new LoaAgencyTableInfo
                    {
                        AgencyName = LoaAgencyRowValues[0],
                        ApplicationType = LoaAgencyRowValues[1],
                        ApplicationNumber = LoaAgencyRowValues[2],
                        ApplicationOtherName = LoaAgencyRowValues[3]
                    });
                }

                Assert.AreEqual(_requestLoaPageInstance.LoaAgencyHeaderText.Text.ToString().Trim().Equals(tabName.Trim()), true, "The header text, '" + _requestLoaPageInstance.LoaAgencyHeaderText.Text.ToString() + "' is not diplayed in 'Agency' page");
                Assert.AreEqual(AreEqualLoaAgency(LoaAgencyRowList, LoaAgencyExpectedRowList), true, "The LOA Contacts details in the first row is not diplayed correctly in 'Loa Agency' page");
            }
            else
            {
                List<LoaItemTableInfo> LoaItemRowList = new List<LoaItemTableInfo>();
                List<LoaProductTableInfo> LoaProductRowList = new List<LoaProductTableInfo>();
                string tabNameItem = "LoaItem";
                string tabNameProduct = "LoaProduct";

                int rowCountItem = _requestLoaPageInstance.GetRowsInEditRequestLoaGrid(tabNameItem).Count;
                for (int i = 1; i < rowCountItem; i++)
                {
                    List<String> LoaItemRowValues = GetRowValues(i, tabNameItem);
                    LoaItemRowList.Add(new LoaItemTableInfo
                    {
                        WestItemNo = LoaItemRowValues[0],
                        Description = LoaItemRowValues[1],
                        ItemStatus = LoaItemRowValues[2],
                        ControlledDrawing = LoaItemRowValues[3],
                        ControlledDrawingNo = LoaItemRowValues[4],
                        Submitted = LoaItemRowValues[5],
                        Emailed = LoaItemRowValues[6]
                    });
                }


                int rowCountProduct = _requestLoaPageInstance.GetRowsInEditRequestLoaGrid(tabNameProduct).Count;
                for (int i = 1; i < rowCountProduct; i++)
                {
                    List<String> LoaProductRowValues = GetRowValues(i, tabNameProduct);
                    LoaProductRowList.Add(new LoaProductTableInfo
                    {
                        WestItemNo = LoaProductRowValues[0],
                        Formulation = LoaProductRowValues[1],
                        Configuration = LoaProductRowValues[2],
                        IsDaikyo = LoaProductRowValues[3]
                    });
                }

                Assert.AreEqual(AreEqualLoaItem(LoaItemRowList, LoaItemExpectedRowList), true, "The LOA Contacts details in the first row is not diplayed correctly in 'Loa Agency' page");
                Assert.AreEqual(AreEqualLoaProduct(LoaProductRowList, LoaProductExpectedRowList), true, "The LOA Contacts details in the first row is not diplayed correctly in 'Loa Agency' page");
            }
            LogInfo("Validated the '" + tabName + "' of the LOA, '" + loaId + "'");
        }
        public void ValidateWestItemNoInLoaItemsOrProductsTab(string itemNoOne)
        {
            string tabNameItem = "LoaItem";
            string tabNameProduct = "LoaProduct";

            string LoaItemRowValue = GetRowValues(1, tabNameItem)[0];
            string LoaProductRowValue = GetRowValues(1, tabNameProduct)[0];

            Assert.AreEqual(LoaItemRowValue, itemNoOne, "The WestItemNumber '"+ LoaItemRowValue + "' is diplayed correctly in 'Loa Items' page");
            Assert.AreEqual(LoaProductRowValue, itemNoOne, "The WestItemNumber '"+ LoaProductRowValue + "' is diplayed correctly in 'Loa Products' page");
            ClickBackButton();
        }
        private object AreEqualLoaAgency(List<LoaAgencyTableInfo> loaAgencyRows, List<LoaAgencyTableInfo> loaAgencyExpectedRows)
        {
            bool areEqual = true;
            foreach(var expectedRow in loaAgencyExpectedRows)
            {
                var actualRow = loaAgencyRows.FirstOrDefault(r => r.AgencyName == expectedRow.AgencyName);                
                if(!AreEqualLoaAgency(actualRow, expectedRow))
                    areEqual = false;
            }
            LogInfo("Executed 'AreEqualLoaAgency' successfully");
            return areEqual;
        }
        private bool AreEqualLoaAgency(LoaAgencyTableInfo actualRow, LoaAgencyTableInfo expectedRow)
        {
            LogInfo("Valuating 'AreEqualLoaAgency' successfully");
            return (actualRow != null && expectedRow != null 
                && actualRow.ApplicationNumber == expectedRow.ApplicationNumber
                && actualRow.ApplicationOtherName == expectedRow.ApplicationOtherName
                && actualRow.ApplicationType == expectedRow.ApplicationType
            );
        }
        private object AreEqualLoaItem(List<LoaItemTableInfo> loaItemRows, List<LoaItemTableInfo> loaItemExpectedRows)
        {
            bool areEqual = true;
            foreach (var expectedRow in loaItemExpectedRows)
            {
                var actualRow = loaItemRows.FirstOrDefault(r => r.WestItemNo == expectedRow.WestItemNo);
                if (!AreEqualLoaItem(actualRow, expectedRow))
                    areEqual = false;
            }
            LogInfo("Executed 'AreEqualLoaItem' successfully");
            return areEqual;
        }
        private bool AreEqualLoaItem(LoaItemTableInfo actualRow, LoaItemTableInfo expectedRow)
        {
            LogInfo("Valuating 'AreEqualLoaItem' successfully");
            return (actualRow != null && expectedRow != null
                && actualRow.Description == expectedRow.Description
                && actualRow.ItemStatus == expectedRow.ItemStatus
                && actualRow.ControlledDrawing == expectedRow.ControlledDrawing
            );
        }
        private object AreEqualLoaProduct(List<LoaProductTableInfo> loaProductRows, List<LoaProductTableInfo> loaProductExpectedRows)
        {
            bool areEqual = true;
            foreach (var expectedRow in loaProductExpectedRows)
            {
                var actualRow = loaProductRows.FirstOrDefault(r => r.WestItemNo == expectedRow.WestItemNo);
                if (!AreEqualLoaProduct(actualRow, expectedRow))
                    areEqual = false;
            }
            LogInfo("Executed 'AreEqualLoaProduct' successfully");
            return areEqual;
        }
        private bool AreEqualLoaProduct(LoaProductTableInfo actualRow, LoaProductTableInfo expectedRow)
        {
            LogInfo("Valuating 'AreEqualLoaProduct' successfully");
            return (actualRow != null && expectedRow != null
                && actualRow.Formulation == expectedRow.Formulation
                && actualRow.Configuration == expectedRow.Configuration
                && actualRow.IsDaikyo == expectedRow.IsDaikyo
            );
        }
        public List<String> GetRowValues(int rowNumber, string tabName)
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _requestLoaPageInstance.ValuebyRowAndColumnInEditRequestLoaGrid(Convert.ToString(rowNumber), tabName);
            if (rowValues.Equals(null))
            {
                rowValues = _requestLoaPageInstance.ValuebyRowAndColumnInEditRequestLoaGrid(Convert.ToString(rowNumber), tabName);
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }
            LogInfo("Read the row details of the row, '" + rowNumber + "' from the tab '" + tabName + "'");
            return values;
        }
        public bool VerifyDataNonAvailabilityInInboxHomepage()
        {
            try
            {
                if (_requestLoaPageInstance.EmptyDataScreenText.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public bool VerifyDataAvailabilityInLoaProductTable()
        {
            try
            {
                if (_requestLoaPageInstance.EmptyDataScreenImage.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public bool VerifyLOADocumentInboxColumnHeaderVisible(string columnHeader)
        {
            try
            {
                if (_requestLoaPageInstance.WordDocColumnHeader(columnHeader).Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public void ValidateDataNonExistanceInInboxHomepage(string loaId, string inbox, bool dataNonAvailability)
        {
            bool dataNonAvailabilitPageGrid = VerifyDataNonAvailabilityInInboxHomepage();
            Assert.AreEqual(dataNonAvailability, dataNonAvailabilitPageGrid, "The LOA ID, '" + loaId + "' is diplayed in '" + inbox + "' page");
        }
        public void VerifyDocumentGenerationWhenStatusChange(string inbox_LOADocuments, string loaId, string tabLebel, bool dataNonAvailability)
        {
            if (dataNonAvailability)
            {
                _inboxAction.VerifyInboxName(inbox_LOADocuments);
                _inboxAction.VerifyInboxDataAvalability();
                _inboxAction.EnterSearchValueInGrid(loaId);
                _inboxAction.ClickOnSearchButton();
            }
            else
                SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, tabLebel, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
            bool dataNonAvailabilityLOADocuments = VerifyDataNonAvailabilityInInboxHomepage();
            Assert.AreEqual(dataNonAvailability, dataNonAvailabilityLOADocuments, "The LOA ID, '" + loaId + "' is diplayed in 'LOA Documents' page");
            LogInfo("Verify the Documents in the '" + inbox_LOADocuments + "' inbox page");
        }
        public string GetLatestWestItemCreatedInApplication(string inbox)
        {
            _inboxAction.VerifyInboxName(inbox);
            _inboxAction.VerifyInboxDataAvalability();
            _inboxAction.SortDataBy("West Item No", SortOrder.Descending);
            SelectTabOfInboxHomePage("All");
            _inboxAction.VerifyInboxDataAvalability();
            List<String> rowValuesBeforeLoaCreation = GetFirstRowValues();
            LogInfo("Getting the latest West Item created in the '" + inbox + "' inbox page");
            return Convert.ToString((int.Parse(rowValuesBeforeLoaCreation[0]) + 1));
        }
        public void CreateNewProduct(string alertTitleProductSaved, string alertMesageProductSaved, Dictionary<string, string> newProductValues)
        {
            ClickNewProductCreationButton();
            FurnishDetailsInNewProductCreationPage(newProductValues);
            ClickNewProductSaveButton();
            ClickAlertWindowOKButton(alertTitleProductSaved, alertMesageProductSaved);
            ClickRefreshButton();
            LogInfo("Created the New Product");
        }
        private void FurnishDetailsInNewProductCreationPage(Dictionary<string, string> newProductValues, bool isUpdate = false)
        {
            try
            {
                if (isUpdate)
                {
                    IList<WindowsElement> multipanelDropdownCloseIconList = _requestLoaPageInstance.ProductInboxMultipanelDropdowns;
                    for (int i = 0; i < multipanelDropdownCloseIconList.Count; i++)
                    {
                        ClickElement(multipanelDropdownCloseIconList[i]);
                    }
                }
                ClickClearEnterText(_requestLoaPageInstance.TitleTextbox, newProductValues["title"]);
                ClickClearEnterText(_requestLoaPageInstance.WestItemNumberTextbox, newProductValues["westItemNumber"]);
                ClickClearEnterText(_requestLoaPageInstance.FormulationDropDownBox, newProductValues["formulation"]);
                ClickClearEnterText(_requestLoaPageInstance.FormulationTypeDropDownBox, newProductValues["formulationType"]);
                ClickClearEnterText(_requestLoaPageInstance.CoatingDropDownBox, newProductValues["coatingValueOne"]);
                EnterText(_requestLoaPageInstance.CoatingDropDownBox, newProductValues["coatingValueTwo"]);
                ClickClearEnterText(_requestLoaPageInstance.WashPlantDropDownBox, newProductValues["washPlantValueOne"]);
                EnterText(_requestLoaPageInstance.WashPlantDropDownBox, newProductValues["washPlantValueTwo"]);
                ClickClearEnterText(_requestLoaPageInstance.SterilePlantDropDownBox, newProductValues["sterilePlantValueOne"]);
                EnterText(_requestLoaPageInstance.SterilePlantDropDownBox, newProductValues["sterilePlantValueTwo"]);
                ClickClearEnterText(_requestLoaPageInstance.ConfigurationDropDownBox, newProductValues["configuration"]);
                ClickClearEnterText(_requestLoaPageInstance.ConfigurationTypeDropDownBox, newProductValues["configurationType"]);
                ClickClearEnterText(_requestLoaPageInstance.PackingOptionDropDownBox, newProductValues["packingOption"]);
                ClickClearEnterText(_requestLoaPageInstance.SpecificationTextbox, newProductValues["specification"]);
                ClickClearEnterText(_requestLoaPageInstance.ConfigBerFamilyDropDownBox, newProductValues["configBerFamily"]);
                ClickClearEnterText(_requestLoaPageInstance.TemplatesDropDownBox, newProductValues["templates"]);
                ClickClearEnterText(_requestLoaPageInstance.IndexTextbox, newProductValues["index"]);
                SelectDropDownValue(_requestLoaPageInstance.HcFormulaDmfDropDownBox, newProductValues["hcFormulaDmf"]);
                SelectDropDownValue(_requestLoaPageInstance.HcCoatingDmfDropDownBox, newProductValues["hcCoatingDmf"]);
                SelectDropDownValue(_requestLoaPageInstance.StatusDropDownBox, newProductValues["status"]);
                ClickClearEnterText(_requestLoaPageInstance.ChinaDossierNumberDropDownBox, newProductValues["chinaDossierNumber"]);
                ClickClearEnterText(_requestLoaPageInstance.ChinaProcesingTypeTextbox, newProductValues["chinaProcesingType"]);
                WaitForMoment(1);
                LogInfo("Furnishing the details in the New Product Creation page");
            }
            catch (Exception ex)
            {
                LogError($"Error in FurnishDetailsInNewProductCreationPage method: {ex.Message}");
            }
        }
        public void ValidatePDFExistance()
        {
            WaitForMoment(4);
            Assert.AreEqual(Exists(_requestLoaPageInstance.LoaPDFImage), true, "The PDF is not opened");
            ClickBackButton();
            LogInfo("Validating the PDF file existance");
        }
        public string GetCustomerCompanyName()
        {
            return apiInput["CustomerCompanyName"];
        }
        public string GetDateRequested()
        {
            return apiInput["DateRequested"];
        }
        public List<String> GetRequestorContactDetails()
        {
            List<String> values = new List<String>();
            values.Add(apiInput["CustomerCompanyName"]);
            values.Add(apiInput["CustomerAddress1"]);
            values.Add(apiInput["CustomerAddress2"]);
            values.Add(apiInput["CustomerAddress3"]);
            values.Add(apiInput["CustomerCity"]);
            values.Add(apiInput["CustomerState"]);
            values.Add(apiInput["CustomerPostalCode"]);
            values.Add(apiInput["CustomerCountry"]);

            return values;
        }
        public void ValidateEachAppAgencyLOADocumentsCount(string inbox, string loaIdWithAppAgency, string searchingItem, string tabNameInInboxHomePage, int expectedFileCount)
        {
            string loaFileCount;

            SearchEntryInInboxHomePage(inbox, loaIdWithAppAgency, tabNameInInboxHomePage, searchingItem);

            string tabLabel = GetTabLabelOfInboxHomePage(tabNameInInboxHomePage).ToString().Trim();
            if (tabLabel.Contains("("))
                loaFileCount = tabLabel.Substring(tabLabel.IndexOf("(") + 1).Substring(0, tabLabel.Substring(tabLabel.IndexOf("(") + 1).IndexOf(")"));
            else
                loaFileCount = "0";
            int observedFileCount = Convert.ToInt32(loaFileCount);

            Assert.AreEqual(expectedFileCount, observedFileCount, "The number of, '"+ loaIdWithAppAgency.Split('_')[1] + "' files are "+ observedFileCount + " are not matching");
            LogInfo("Validated the number of, '" + loaIdWithAppAgency.Split('_')[1] + "' files are " + observedFileCount + " are matching");
        }
        public int GetFileCountInLOADocumentPage(string inbox, string loaId, string tabNameInInboxHomePage, string searchingItem)
        {
            string loaFileCount;

            SearchItemInInboxHomePage(inbox, loaId, tabNameInInboxHomePage);
            WaitForMoment(3);
            string tabLabel = GetTabLabelOfInboxHomePage(tabNameInInboxHomePage).ToString().Trim();
            if (tabLabel.Contains("("))
                loaFileCount = tabLabel.Substring(tabLabel.IndexOf("(") + 1).Substring(0, tabLabel.Substring(tabLabel.IndexOf("(") + 1).IndexOf(")"));
            else
                loaFileCount = "0";
            LogInfo("Calculated the Loa file count as, '" + loaFileCount +"' for the LOA ID '" + loaId + "' for the inbox "+inbox+"'");
            int observedFileCount = Convert.ToInt32(loaFileCount);
            return observedFileCount;
        }
        public void LoaAgencyTableList(string agencyName, string applType, string appNumber, string appOtherType)
        {
            LoaAgencyExpectedRowList.Add(new LoaAgencyTableInfo
            {
                AgencyName = agencyName,
                ApplicationType = applType,
                ApplicationNumber = appNumber,
                ApplicationOtherName = appOtherType
            });
        }
        public void LoaItemTableList(string westItemNo, string description, string itemStatus, string controlledDrawing, string controlledDrawingNo, string submitted, string emailed)
        {
            LoaItemExpectedRowList.Add(new LoaItemTableInfo
            {
                WestItemNo = westItemNo,
                Description = description,
                ItemStatus = itemStatus,
                ControlledDrawing = controlledDrawing,
                ControlledDrawingNo = controlledDrawingNo,
                Submitted = submitted,
                Emailed = emailed
            });
        }
        public void LoaProductTableList(string westItemNo, string formulation, string configuration, string isDaikyo)
        {
            LoaProductExpectedRowList.Add(new LoaProductTableInfo
            {
                WestItemNo = westItemNo,
                Formulation = formulation,
                Configuration = configuration,
                IsDaikyo = isDaikyo
            });
        }
        public bool VerifyExistanceOfCreateButtonInInboxHomepage(string newItemCreationButtonName)
        {
            try
            {
                if (_requestLoaPageInstance.NewInboxItemCreationButton(newItemCreationButtonName).Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public void ValidateAgenciesInAgencyInbox(string inbox, string tabNameInAgencyInboxPage, List<String> expectedAgencies)
        {
            foreach (var agencyAbbr in expectedAgencies)
            {
                SearchEntryInInboxHomePage(inbox, agencyAbbr, tabNameInAgencyInboxPage, String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c))));
            }
            _requestLoaPageInstance.SearchEditInGrid.Clear();
            ClickRefreshButton();
            LogInfo("Validated the Agencies in the, '" + inbox + " inbox page");
        }
        public void ValidateEmptyDataValidationMessage(string inbox, string alertMessage, string newInboxItemCreationButtonText)
        {
            switch (inbox)
            {
                case "Agency":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Application Type":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Coating":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Coating DMF":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Configuration":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Configuration Type":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "DMF":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "DMF Number":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Document Type":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Drug Classification":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Formulation Type":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Formulation DMF":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForLoadingToDisappear("Loading");
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                case "Plant":
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
                default:
                    ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
                    WaitForMoment(2);
                    ClickNewInboxItemSaveButton(inbox);
                    ClickAlertWindowOKButton("", alertMessage);
                    ClickBackButton();
                    break;
            }
            LogInfo("Validated alert messages when trying to creae New entry in the '"+ inbox + "' inbox with empty data");
        }
        public void ValidateLoaProductForApprovedUnapprovedWestItem(string inbox, string loaId, string editRequestLoaAction, string loaStatus_Target, string alertTitleStatusChange, string alertMesageStatusChange, string alertMessageNoProductAdded, string tabNameLoaProducts, bool dataNonAvailability, string requestLOATab = "New")
        {
            SearchEntryInInboxHomePage(inbox, loaId, requestLOATab);
            OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
            WaitForMoment(3);
            if(dataNonAvailability)
                ClickAlertWindowOKButton("", alertMessageNoProductAdded);
            GetLOAIDFromRequestLOAPage(loaId);
            SelectStatusDropDownValue(loaStatus_Target);
            ClickSaveButton();
            ClickAlertWindowOKButton(alertTitleStatusChange, alertMesageStatusChange);
            WaitForMoment(2);
            if (!dataNonAvailability) 
            { 
                SelectTabOfInboxHomePage("In Progress");
                _inboxAction.VerifyInboxDataAvalability();
                OpenActionsFromInboxHomePage(inbox, editRequestLoaAction);
                GetLOAIDFromRequestLOAPage(loaId);
            }
            ClickTabFromEditRequestLOA(tabNameLoaProducts);
            ValidateDataNonExistanceInLoaProductsTab(dataNonAvailability);
            ClickBackButton();
            LogInfo("Validate Loa Product table data for the WestItems with the status 'Ready for Review'");
        }
        public void ValidateDataNonExistanceInLoaProductsTab(bool dataNonAvailability)
        {
            bool dataNonAvailabilitPageGrid = VerifyDataAvailabilityInLoaProductTable();
            Assert.AreEqual(dataNonAvailability, dataNonAvailabilitPageGrid, "The Loa Product table is not empty");
        }
        public void ChangeProductStatus(string inbox, string westItemNumber, string updateSelectedProductAction, string targetStatus, string alertTitleProductSaved, string alertMesageProductSaved, string productTabLabelFirst, string searchingItem)
        {
            SearchEntryInInboxHomePage(inbox, westItemNumber, productTabLabelFirst, searchingItem);
            OpenActionsFromInboxHomePage(inbox, updateSelectedProductAction);
            SelectDropDownValue(_requestLoaPageInstance.StatusDropDownBox, targetStatus);
            ClickNewProductSaveButton();
            ClickAlertWindowOKButton(alertTitleProductSaved, alertMesageProductSaved);
            ClickRefreshButton();
            LogInfo("Updated the Product status to '"+ targetStatus + "'");
        }
        public void ValidateInboxPageTabLabels(List<String> expectedInboxPageTabLabels)
        {
            List<String> observedInboxPageTabLabels = new List<String>();
            IList<WindowsElement> values = _requestLoaPageInstance.InboxPageTabLabels;
            string titleText;
            for (int i = 0; i < values.Count; i++)
            {
                titleText = values[i].Text.Trim();
                if (titleText.Contains("("))
                    observedInboxPageTabLabels.Add(titleText.Substring(0, titleText.IndexOf("(")).Trim());
                else
                    observedInboxPageTabLabels.Add(titleText.Trim());
                titleText = string.Empty;
            }
            Assert.AreEqual(Enumerable.SequenceEqual(expectedInboxPageTabLabels.OrderBy(e => e), observedInboxPageTabLabels.OrderBy(e => e)), true, "The tab labels are not dispalyed");
            LogInfo("The tab labels are properly dispalyed");
        }
        public void CreateNewInboxItem(string inbox, string newInboxItemCreationButtonText, Dictionary<string, string> inboxItemValues, string newInboxItemPageTitle, string alertTitleInboxItemSaved, string alertMesageInboxItemSaved)
        {
            string createdInboxItemValue;
            ClickNewInboxItemCreationButton(inbox, newInboxItemCreationButtonText);
            ValidatePageTitleAddOrUpdateInboxPage(newInboxItemPageTitle);
            if (inbox == "Agency")
            {
                string agencyName = inboxItemValues["agencyName"];
                string parentAgency = inboxItemValues["parentAgency"];
                string agencyAddress = inboxItemValues["agencyAddress"];
                string agencyAbbreviation = inboxItemValues["agencyAbbreviation"];
                createdInboxItemValue = agencyName;

                ClickClearEnterText(_requestLoaPageInstance.AgencyNameEntryTextbox, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.AgencyAbbreviationEntryTextbox, agencyAbbreviation);
                ClickClearEnterText(_requestLoaPageInstance.ParentAgencyEntryTextbox, parentAgency);
                ClickClearEnterText(_requestLoaPageInstance.AgencyAddressEntryTextbox, agencyAddress);
            }
            else if (inbox == "Formulation Type")
            {
                string formulationType = inboxItemValues["formulationType"];
                string titleEntry = inboxItemValues["titleEntry"];
                createdInboxItemValue = formulationType;

                ClickClearEnterText(_requestLoaPageInstance.TitleEntryTextbox, titleEntry);
                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), formulationType);
            }
            else if (inbox == "Formulation DMF")
            {
                string formulationName = inboxItemValues["formulationName"];
                string locationName = inboxItemValues["locationName"];
                string agencyName = inboxItemValues["agencyName"];
                createdInboxItemValue = formulationName;

                ClickClearEnterText(_requestLoaPageInstance.FormulationNameDropdown, formulationName);
                ClickClearEnterText(_requestLoaPageInstance.FormulationAgencyNameDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.FormulationLocationNameEntryTextbox, locationName);
            }
            else if (inbox == "Coating DMF")
            {
                string coatingLocation = inboxItemValues["coatingLocation"];
                string agencyName = inboxItemValues["agencyName"];
                string coatingName = inboxItemValues["coatingName"];
                createdInboxItemValue = coatingName;

                ClickClearEnterText(_requestLoaPageInstance.NewCoatingLocationTextbox, coatingLocation);
                ClickClearEnterText(_requestLoaPageInstance.NewAgencyNameDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.NewCoatingNameDropdown, coatingName);
            }
            else if (inbox == "DMF")
            {
                string agencyName = inboxItemValues["agencyName"];
                string dmfDescription = inboxItemValues["dmfDescription"];
                string dmfNumber = inboxItemValues["dmfNumber"];
                string dmfProcessType = inboxItemValues["dmfProcessType"];
                string dmfTitleText = inboxItemValues["dmfTitleText"];
                string dmfType = inboxItemValues["dmfType"];
                string loaTemplateName = inboxItemValues["loaTemplateName"];
                string plant = inboxItemValues["plant"];
                string dmfDisclaimer = inboxItemValues["dmfDisclaimer"];
                createdInboxItemValue = dmfNumber;

                ClickClearEnterText(_requestLoaPageInstance.AgencyNameDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfNumberEntryTextbox, dmfNumber);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfDescriptionEntryTextbox, dmfDescription);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfProcessTypeEntryTextbox, dmfProcessType);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfTitleTextEntryTextbox, dmfTitleText);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfTypeEntryTextbox, dmfType);
                ClickClearEnterText(_requestLoaPageInstance.LoaTemplateDropdown, loaTemplateName);
                ClickClearEnterText(_requestLoaPageInstance.PlantDropdown, plant);
                ClickClearEnterText(_requestLoaPageInstance.NewDisclaimerEditorTextbox, dmfDisclaimer);
            }
            else if (inbox == "Plant")
            {
                string plantAddress = inboxItemValues["plantAddress"];
                string plantTitle = inboxItemValues["plantTitle"];
                string plantAbbreviation = inboxItemValues["plantAbbreviation"];
                createdInboxItemValue = plantAddress;

                ClickClearEnterText(_requestLoaPageInstance.NewPlantAddressEntry, plantAddress);
                ClickClearEnterText(_requestLoaPageInstance.NewPlantTitleEntry, plantTitle);
                ClickClearEnterText(_requestLoaPageInstance.NewPlantAbbreviationEntry, plantAbbreviation);
            }
            else if (inbox == "Standard Email Statement")
            {
                string titleEntry = inboxItemValues["titleEntry"];
                string standardEmailStatement = inboxItemValues["standardEmailStatement"];
                createdInboxItemValue = standardEmailStatement;

                ClickClearEnterText(_requestLoaPageInstance.NewStandardEmailsTitleEntry, titleEntry);
                //ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), standardEmailStatement);
                ClickClearEnterText(_requestLoaPageInstance.NewStandardEmailStatementEntry, standardEmailStatement);
            }
            else if (inbox == "Product")
            {
                string westItemNumber = inboxItemValues["westItemNumber"];
                createdInboxItemValue = westItemNumber;

                FurnishDetailsInNewProductCreationPage(inboxItemValues);
            }
            else if (inbox == "Formulation")
            {
                string formulationName = inboxItemValues["formulationName"];
                string contains2MCBT = inboxItemValues["contains2MCBT"];
                string relatedSubstance = inboxItemValues["relatedSubstance"];
                createdInboxItemValue = formulationName;

                ClickClearEnterText(_requestLoaPageInstance.FormulationEntryTextbox, formulationName);
                SelectContainsMCBTDropDownValue(contains2MCBT);
                ClickClearEnterText(_requestLoaPageInstance.RelatedSubstanceEntryTextbox, relatedSubstance);
            }
            else if (inbox == "Wash Process DMF")
            {
                string title = inboxItemValues["title"];
                string formulationType = inboxItemValues["formulationType"];
                string plant = inboxItemValues["plant"];
                string agencyName = inboxItemValues["agencyName"];
                string loaTemplate = inboxItemValues["loaTemplate"];
                string configBerFamily = inboxItemValues["configBerFamily"];
                string amendment = inboxItemValues["amendment"];
                string berTable = inboxItemValues["berTable"];
                createdInboxItemValue = plant;

                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessTitleEntryTextbox, title);
                ClickClearEnterText(_requestLoaPageInstance.NewWashFormualtionTypeDropdown, formulationType);
                ClickClearEnterText(_requestLoaPageInstance.NewWashPlantDropdown, plant);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfLoaAgencyDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfLoaTemplateDropdown, loaTemplate);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessConfigBerFamilyDropdown, configBerFamily);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfAmendmentTextbox, amendment);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfBerTableTextbox, berTable);
            }
            else if (inbox == "Steril Process DMF")
            {
                string title = inboxItemValues["title"];
                string plant = inboxItemValues["plant"];
                string agencyName = inboxItemValues["agencyName"];
                string packingOption = inboxItemValues["packingOption"];
                string loaTemplate = inboxItemValues["loaTemplate"];
                string amendmentText = inboxItemValues["amendmentText"];
                string stmStrlProdDesc = inboxItemValues["stmStrlProdDesc"];
                createdInboxItemValue = plant;

                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessTitleEntryTextbox, title);
                ClickClearEnterText(_requestLoaPageInstance.NewSterilePlantDropdown, plant);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessDmfLoaAgencyDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessPackOptionDropdown, packingOption);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileLoaTemplateDropdown, loaTemplate);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessAmendmentTextbox, amendmentText);
                ClickClearEnterText(_requestLoaPageInstance.NewStmStrlProdDescEntryTextbox, stmStrlProdDesc);
            }
            else if (inbox == "China Dossier Number")
            {
                string chinaDMFSubject = inboxItemValues["chinaDMFSubject"];
                string dossierNumberCode = inboxItemValues["dossierNumberCode"];
                string configurationsField = inboxItemValues["configurationsField"];
                string plant = inboxItemValues["plant"];
                string specification = inboxItemValues["specification"];
                createdInboxItemValue = chinaDMFSubject;

                ClickClearEnterText(_requestLoaPageInstance.DmfSubjectEntryTextbox, chinaDMFSubject);
                ClickClearEnterText(_requestLoaPageInstance.ChinaDossierNumberCodeEntryTextbox, dossierNumberCode);
                ClickClearEnterText(_requestLoaPageInstance.ConfigarationFieldEntryTextbox, configurationsField);
                ClickClearEnterText(_requestLoaPageInstance.ChinaDossierPlantDropdown, plant);
                ClickClearEnterText(_requestLoaPageInstance.SpecificationEntryTextbox, specification);
            }
            else if (inbox == "Pack Option")
            {
                string packOption = inboxItemValues["packOption"];
                string titlePackOption = inboxItemValues["titlePackOption"];
                createdInboxItemValue = packOption;

                ClickClearEnterText(_requestLoaPageInstance.TitlePackOptionTextbox, titlePackOption);
                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), packOption);
            }
            else
            {
                string inboxItemValue = inboxItemValues["inboxItemValue"];
                createdInboxItemValue = inboxItemValue;

                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), inboxItemValue);
            }
            ClickNewInboxItemSaveButton(inbox);
            ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
            LogInfo("Created new '"+ inbox + "', '" + createdInboxItemValue + "'");
        }
        public void ValidateInboxItemInInboxHomePage(string inbox, Dictionary<string, string> inboxItemValues, string tabNameInInboxHomePage)
        {
            string inboxItemValue;
            ToggleInboxesVisibility(true);
            switch (inbox)
            {
                case "Agency":
                    string agencyName = inboxItemValues["agencyName"];
                    string parentAgency = inboxItemValues["parentAgency"];
                    string agencyAddress = inboxItemValues["agencyAddress"];
                    string agencyAbbreviation = inboxItemValues["agencyAbbreviation"];

                    SearchEntryInInboxHomePage(inbox, agencyAbbreviation, tabNameInInboxHomePage, String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c))));
                    List<String> rowValuesAgencyPage = GetRowValues(1);

                    Assert.AreEqual(agencyAbbreviation, rowValuesAgencyPage[0], "The Agency Abbreviation, '" + agencyAbbreviation + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agencyName, rowValuesAgencyPage[1], "The Agency Name, '" + agencyName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(parentAgency, rowValuesAgencyPage[4], "The Parent Agency, '" + parentAgency + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agencyAddress, rowValuesAgencyPage[2], "The Agency Addres, '" + agencyAddress + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "Application Type":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesApplicationTypeHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesApplicationTypeHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "Coating":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesCoatingHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesCoatingHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "Coating DMF":
                    string coatingLocation = inboxItemValues["coatingLocation"];
                    string agencyNameCoatingDMF = inboxItemValues["agencyName"];
                    string coatingName = inboxItemValues["coatingName"];

                    SearchItemInInboxHomePage(inbox, coatingLocation, tabNameInInboxHomePage);
                    List<String> rowValuesCoatingDmfPage = GetRowValues(1);

                    Assert.AreEqual(coatingName, rowValuesCoatingDmfPage[0], "The Coating , '" + coatingName + "' is not displayed in 'Coating Dmf' inbox page");
                    Assert.AreEqual(agencyNameCoatingDMF, rowValuesCoatingDmfPage[1], "The Agency, '" + agencyNameCoatingDMF + "' is not displayed in 'Coating Dmf' inbox page");
                    Assert.AreEqual(coatingLocation, rowValuesCoatingDmfPage[2], "The Coating Location, '" + coatingLocation + "' is not displayed in 'Coating Dmf' inbox page");
                    break;
                case "Configuration":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesConfigurationHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesConfigurationHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "Configuration Type":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesConfigurationTypeHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesConfigurationTypeHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "DMF":
                    string loaTemplateName = inboxItemValues["loaTemplateName"];
                    string agencyNameDMF = inboxItemValues["agencyName"];
                    string dmfNumber = inboxItemValues["dmfNumber"];
                    string dmfType = inboxItemValues["dmfType"];

                    SearchItemInInboxHomePage(inbox, dmfNumber, tabNameInInboxHomePage);
                    List<String> rowValuesDmfPage = GetRowValues(1);

                    Assert.AreEqual(loaTemplateName, rowValuesDmfPage[0], "The LOA Template, '" + loaTemplateName + "' is not displayed in 'Dmf' inbox page");
                    Assert.AreEqual(agencyNameDMF, rowValuesDmfPage[1], "The Agency, '" + agencyNameDMF + "' is not displayed in 'Dmf' inbox page");
                    Assert.AreEqual(dmfNumber, rowValuesDmfPage[2], "The DMF Number value, '" + dmfNumber + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(dmfType, rowValuesDmfPage[4], "The DMF Type, '" + dmfType + "' is not displayed in 'Dmf' inbox page");
                    break;
                case "DMF Number":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesDMFNumberHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesDMFNumberHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "Document Type":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesDocumentTypeHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesDocumentTypeHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Document Type', '" + inboxItemValue + "' got created in the '" + inbox + "'");
                    break;
                case "Drug Classification":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesDrugClassificationHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesDrugClassificationHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Drug Classification', '" + inboxItemValue + "' got created in the '" + inbox + "'");
                    break;
                case "Formulation Type":
                    string formulationType = inboxItemValues["formulationType"];
                    string titleEntry = inboxItemValues["titleEntry"];

                    SearchItemInInboxHomePage(inbox, formulationType, tabNameInInboxHomePage);
                    List<String> rowValuesFormulationTypeHomePage = GetRowValues(1);

                    Assert.AreEqual(titleEntry, rowValuesFormulationTypeHomePage[0], "The Title, '" + titleEntry + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(formulationType, rowValuesFormulationTypeHomePage[1], "The Formulation Type, '" + formulationType + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Formulation Type', '" + formulationType + "' got created in the '" + inbox + "'");
                    break;
                case "Formulation DMF":
                    string formulationName = inboxItemValues["formulationName"];
                    string locationName = inboxItemValues["locationName"];
                    string agencyNameFormulationDMF = inboxItemValues["agencyName"];

                    SearchItemInInboxHomePage(inbox, locationName, tabNameInInboxHomePage);
                    List<String> rowValuesFormulationDMFHomePage = GetRowValues(1);

                    Assert.AreEqual(formulationName, rowValuesFormulationDMFHomePage[0], "The Formulation Name, '" + formulationName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agencyNameFormulationDMF, rowValuesFormulationDMFHomePage[1], "The Agency Name, '" + agencyNameFormulationDMF + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(locationName, rowValuesFormulationDMFHomePage[2], "The Location Name, '" + locationName + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Formulation Name', '" + formulationName + "' got created in the '" + inbox + "'");
                    break;
                case "Plant":
                    string plantAddress = inboxItemValues["plantAddress"];
                    string plantAbbreviation = inboxItemValues["plantAbbreviation"];

                    SearchItemInInboxHomePage(inbox, plantAddress, tabNameInInboxHomePage);
                    List<String> rowValuesPlantHomePage = GetRowValues(1);
                    Assert.AreEqual(plantAddress, rowValuesPlantHomePage[0], "The Plant Address, '" + plantAddress + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(plantAbbreviation, rowValuesPlantHomePage[1], "The Plant Abbreviation, '" + plantAbbreviation + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Plant Address', '" + plantAddress + "' got created in the '" + inbox + "'");
                    break;
                case "LOA Template":
                    string loaTemplate = inboxItemValues["loaTemplate"];
                    string processType = inboxItemValues["processType"];
                    string isActive = inboxItemValues["isActive"];
                    string createdOn = inboxItemValues["createdOn"];

                    SearchItemInInboxHomePage(inbox, loaTemplate, tabNameInInboxHomePage);
                    List<String> rowValuesLOATemplateHomePage = GetRowValues(1);
                    Assert.AreEqual(loaTemplate, rowValuesLOATemplateHomePage[0], "The LOA Template, '" + loaTemplate + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(processType, rowValuesLOATemplateHomePage[1], "The Process Type, '" + processType + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(isActive, rowValuesLOATemplateHomePage[2], "The value of isActive, '" + isActive + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(createdOn, rowValuesLOATemplateHomePage[3], "The LOA Template created on, '" + createdOn + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the 'LOA Template', '" + loaTemplate + "' is present in the '" + inbox + "'");
                    break;
                case "Processing Type":
                    inboxItemValue = inboxItemValues["inboxItemValue"];

                    SearchItemInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage);
                    List<String> rowValuesProcessingTypeHomePage = GetRowValues(1);

                    Assert.AreEqual(inboxItemValue, rowValuesProcessingTypeHomePage[0], "The " + inbox + " value, '" + inboxItemValue + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Processing Type', '" + inboxItemValue + "' got created in the '" + inbox + "'");
                    break;
                case "Standard Email Statement":
                    string title = inboxItemValues["titleEntry"];
                    string standardEmailStatement = inboxItemValues["standardEmailStatement"];

                    SearchItemInInboxHomePage(inbox, title, tabNameInInboxHomePage);
                    List<String> rowValuesStandardEmailStatementHomePage = GetRowValues(1);
                    
                    Assert.AreEqual(title, rowValuesStandardEmailStatementHomePage[0], "The Title, '" + title + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(RemoveSpecialChars(standardEmailStatement), RemoveSpecialChars(rowValuesStandardEmailStatementHomePage[1]), "The Standard Email Statement, '" + standardEmailStatement + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Standard Email Statement', '" + standardEmailStatement + "' got created in the '" + inbox + "'");
                    break;
                case "Product":
                    string westItemNumber = inboxItemValues["westItemNumber"];
                    string sterilePlantValueOne = inboxItemValues["sterilePlantValueOne"];
                    string sterilePlantValueTwo = inboxItemValues["sterilePlantValueTwo"];
                    string washPlantValueOne = inboxItemValues["washPlantValueOne"];
                    string washPlantValueTwo = inboxItemValues["washPlantValueTwo"];

                    SearchItemInInboxHomePage(inbox, westItemNumber, tabNameInInboxHomePage);
                    List<String> rowValuesProductPage = GetRowValues(1);
                    
                    Assert.AreEqual(westItemNumber, rowValuesProductPage[0], "The West Item Number, '" + westItemNumber + "' is not displayed in '" + inbox + "' inbox page");
                    Assert.AreEqual(sterilePlantValueOne + ";" + sterilePlantValueTwo, rowValuesProductPage[1], "The Sterile Plant value One, '" + sterilePlantValueOne + "' is not displayed in '" + inbox + "' inbox page");
                    Assert.AreEqual(washPlantValueOne + ";" + washPlantValueTwo, rowValuesProductPage[2], "The Wash Plant value One, '" + washPlantValueOne + "' is not displayed in '" + inbox + "' inbox home page");
                    break;
                case "External Request Loa":
                    string siteCoreId = inboxItemValues["siteCoreId"];
                    string firstName = inboxItemValues["firstName"];
                    string lastName = inboxItemValues["lastName"];
                    string yourTitle = inboxItemValues["yourTitle"];
                    string addressOne = inboxItemValues["addressOne"];

                    SearchItemInInboxHomePage(inbox, siteCoreId, tabNameInInboxHomePage);
                    List<String> rowValuesExternalRequestLoaHomePage = GetRowValues(1);

                    Assert.AreEqual(siteCoreId, rowValuesExternalRequestLoaHomePage[1], "The Site Core Id, '" + siteCoreId + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(firstName, rowValuesExternalRequestLoaHomePage[2], "The First Name, '" + firstName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(lastName, rowValuesExternalRequestLoaHomePage[3], "The Last Name, '" + lastName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(yourTitle, rowValuesExternalRequestLoaHomePage[4], "The value of Your Title, '" + yourTitle + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(addressOne, rowValuesExternalRequestLoaHomePage[5], "The Addres1, '" + addressOne + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the 'Site Core Id', '" + siteCoreId + "' is present in the '" + inbox + "'");
                    break;
                case "Request Contact":
                    string loaId = inboxItemValues["loaId"];
                    string contactType = inboxItemValues["contactType"];
                    string lstName = inboxItemValues["lastName"];
                    string fstName = inboxItemValues["firstName"];
                    string company = inboxItemValues["company"];

                    SearchItemInInboxHomePage(inbox, loaId, tabNameInInboxHomePage);
                    List<String> rowValuesRequestContactHomePage = GetRowValues(1);

                    Assert.AreEqual(loaId, rowValuesRequestContactHomePage[0], "The LOA Id, '" + loaId + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(contactType, rowValuesRequestContactHomePage[1], "The Contact Type, '" + contactType + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(lstName, rowValuesRequestContactHomePage[2], "The Last Name, '" + lstName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(fstName, rowValuesRequestContactHomePage[3], "The First Name, '" + fstName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(company, rowValuesRequestContactHomePage[4], "The Company, '" + company + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the 'LOA Id', '" + loaId + "' is present in the '" + inbox + "'");
                    break;
                case "Request Item Number":
                    string fullName = inboxItemValues["fullName"];
                    string createdOn_RequestItem = inboxItemValues["createdOn"];
                    string loaId_RequestItem = inboxItemValues["loaId"];
                    string westItemNumber_RequestItem = inboxItemValues["westItemNumber"];

                    SearchItemInInboxHomePage(inbox, loaId_RequestItem, tabNameInInboxHomePage);
                    List<String> rowValuesRequestItemNumberHomePage = GetRowValues(1);

                    Assert.AreEqual(fullName, rowValuesRequestItemNumberHomePage[0], "The Full Name, '" + fullName + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(createdOn_RequestItem, rowValuesRequestItemNumberHomePage[1], "The Created On date, '" + createdOn_RequestItem + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(loaId_RequestItem, rowValuesRequestItemNumberHomePage[2], "The LOA Id, '" + loaId_RequestItem + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(westItemNumber_RequestItem, rowValuesRequestItemNumberHomePage[3], "The Contact Type, '" + westItemNumber_RequestItem + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the 'LOA Id', '" + loaId_RequestItem + "' is present in the '" + inbox + "'");
                    break;
                case "Formulation":
                    string formulation_Name = inboxItemValues["formulationName"];
                    string contains2MCBT = inboxItemValues["contains2MCBT"];
                    string relatedSubstance = inboxItemValues["relatedSubstance"];

                    SearchItemInInboxHomePage(inbox, formulation_Name, tabNameInInboxHomePage);
                    List<String> rowValuesFormulationHomePage = GetRowValues(1);

                    Assert.AreEqual(formulation_Name, rowValuesFormulationHomePage[0], "The Formulation Name, '" + formulation_Name + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(contains2MCBT, rowValuesFormulationHomePage[1], "The contains2MCBT, '" + contains2MCBT + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(relatedSubstance, rowValuesFormulationHomePage[3], "The Related Substance, '" + relatedSubstance + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Formulation Name', '" + formulation_Name + "' got created in the '" + inbox + "'");
                    break;
                case "Wash Process DMF":
                    string plant = inboxItemValues["plant"];
                    string title_WashProcess = inboxItemValues["title"];
                    string loaTemplate_WashProcess = inboxItemValues["loaTemplate"];
                    string agencyName_WashProcess = inboxItemValues["agencyName"];

                    SearchItemInInboxHomePage(inbox, title_WashProcess, tabNameInInboxHomePage);
                    List<String> rowValuesWashProcessDMFHomePage = GetRowValues(1);

                    Assert.AreEqual(plant, rowValuesWashProcessDMFHomePage[0], "The plant Name, '" + plant + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(loaTemplate_WashProcess, rowValuesWashProcessDMFHomePage[1], "The Loa Template, '" + loaTemplate_WashProcess + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agencyName_WashProcess, rowValuesWashProcessDMFHomePage[2], "The Agency Name, '" + agencyName_WashProcess + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Plant Name', '" + plant + "' got created in the '" + inbox + "'");
                    break;
                case "Steril Process DMF":
                    string plantSterileProcess = inboxItemValues["plant"];
                    string title_SterileProcess = inboxItemValues["title"];
                    string loaTemplate_SterileProcess = inboxItemValues["loaTemplate"];
                    string agencyName_SterileProcess = inboxItemValues["agencyName"];

                    SearchItemInInboxHomePage(inbox, title_SterileProcess, tabNameInInboxHomePage);
                    List<String> rowValuesSterileProcessDMFHomePage = GetRowValues(1);

                    Assert.AreEqual(plantSterileProcess, rowValuesSterileProcessDMFHomePage[0], "The plant Name, '" + plantSterileProcess + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(loaTemplate_SterileProcess, rowValuesSterileProcessDMFHomePage[1], "The Loa Template, '" + loaTemplate_SterileProcess + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agencyName_SterileProcess, rowValuesSterileProcessDMFHomePage[2], "The Agency Name, '" + agencyName_SterileProcess + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Plant Name', '" + plantSterileProcess + "' got created in the '" + inbox + "'");
                    break;
                case "China Dossier Number":
                    string chinaDMFSubject = inboxItemValues["chinaDMFSubject"];
                    string dossierNumberCode = inboxItemValues["dossierNumberCode"];
                    string plant_ChinaDossier = inboxItemValues["plant"];

                    SearchItemInInboxHomePage(inbox, chinaDMFSubject, tabNameInInboxHomePage);
                    List<String> rowValuesChinaDossierNumberHomePage = GetRowValues(1);

                    Assert.AreEqual(chinaDMFSubject, rowValuesChinaDossierNumberHomePage[0], "The China DMF Subject, '" + chinaDMFSubject + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(dossierNumberCode, rowValuesChinaDossierNumberHomePage[1], "The Dossier Number Code, '" + dossierNumberCode + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(plant_ChinaDossier, rowValuesChinaDossierNumberHomePage[3], "The Plant Name, '" + plant_ChinaDossier + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'China DMF Subject', '" + chinaDMFSubject + "' got created in the '" + inbox + "'");
                    break;
                case "Pack Option":
                    string packOption = inboxItemValues["packOption"];
                    string titlePackOption = inboxItemValues["titlePackOption"];

                    SearchItemInInboxHomePage(inbox, packOption, tabNameInInboxHomePage);
                    List<String> rowValuesPackOptionHomePage = GetRowValues(1);

                    Assert.AreEqual(packOption, rowValuesPackOptionHomePage[0], "The Pack Option, '" + packOption + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the new 'Pack Option', '" + packOption + "' got created in the '" + inbox + "'");
                    break;
                case "Request Agency":
                    string loaID = inboxItemValues["loaID"];
                    string agency = inboxItemValues["agency"];
                    string applicationNo = inboxItemValues["applicationNo"];
                    string applicationType = inboxItemValues["applicationType"];

                    SearchItemInInboxHomePage(inbox, loaID, tabNameInInboxHomePage);
                    List<String> rowValuesRequestAgencyHomePage = GetRowValues(1);
                    Assert.AreEqual(loaID, rowValuesRequestAgencyHomePage[0], "The LOA ID, '" + loaID + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(agency, rowValuesRequestAgencyHomePage[1], "The Agency, '" + agency + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(applicationNo, rowValuesRequestAgencyHomePage[2].Trim(), "The Application No, '" + applicationNo + "' is not displayed in '" + inbox + "' inbox home page");
                    Assert.AreEqual(applicationType, rowValuesRequestAgencyHomePage[3], "The ApplicationType, '" + applicationType + "' is not displayed in '" + inbox + "' inbox home page");
                    LogInfo("Validated the 'LOA ID', '" + loaID + "' is present in the '" + inbox + "'");
                    break;
                default:
                    LogInfo("Nothing is available to validate in the '" + inbox + "' inbox");
                    break;
            }
            ToggleInboxesVisibility(false);
        }
        public void UpdateInboxItem(string inbox, Dictionary<string, string> inboxItemValues, Dictionary<string, string> updatedInboxItemValues, string tabNameInInboxHomePage, string updateSelectedInboxItemAction, string updateInboxItemPageTitle, string alertTitleInboxItemSaved, string alertMesageInboxItemSaved)
        {
            if (inbox == "Agency")
            {
                string agencyName = inboxItemValues["agencyName"];
                string agencyAbbreviation = inboxItemValues["agencyAbbreviation"];
                string updatedAgencyName = updatedInboxItemValues["agencyName"];
                string updatedParentAgency = updatedInboxItemValues["parentAgency"];
                string updatedAgencyAddress = updatedInboxItemValues["agencyAddress"];
                string updatedAgencyAbbreviation = updatedInboxItemValues["agencyAbbreviation"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, agencyName, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);

                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateAgencyAbbrUpdateAgencyPage(agencyAbbreviation);
                ClickClearEnterText(_requestLoaPageInstance.AgencyNameEntryTextbox, updatedAgencyName);
                ClickClearEnterText(_requestLoaPageInstance.AgencyAbbreviationEntryTextbox, updatedAgencyAbbreviation);
                ClickClearEnterText(_requestLoaPageInstance.ParentAgencyEntryTextbox, updatedParentAgency);
                ClickClearEnterText(_requestLoaPageInstance.AgencyAddressEntryTextbox, updatedAgencyAddress);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + agencyName + "', got updated to '" + updatedAgencyName + "'");
            }
            else if (inbox == "Formulation Type")
            {
                string formulationType = inboxItemValues["formulationType"];
                string updatedFormulationType = updatedInboxItemValues["formulationType"];
                string updatedTitleEntry = updatedInboxItemValues["titleEntry"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, formulationType, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox, formulationType);
                ClickClearEnterText(_requestLoaPageInstance.TitleEntryTextbox, updatedTitleEntry);
                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), updatedFormulationType);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + formulationType + "', got updated to '" + updatedFormulationType + "'");
            }
            else if (inbox == "Formulation DMF")
            {
                string locationName = inboxItemValues["locationName"];
                string formulationName = inboxItemValues["formulationName"];
                string updatedFormulationName = updatedInboxItemValues["formulationName"];
                string updatedLocationName = updatedInboxItemValues["locationName"];
                string updatedAgencyName = updatedInboxItemValues["agencyName"];

                ToggleInboxesVisibility(true);
                SearchEntryInInboxHomePage(inbox, locationName, tabNameInInboxHomePage, String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c))));
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox.Split(' ')[0], locationName);
                ClearTextboxValues(_requestLoaPageInstance.FormulationNameDropdown);
                ClickClearEnterText(_requestLoaPageInstance.FormulationNameDropdown, updatedFormulationName);
                ClearTextboxValues(_requestLoaPageInstance.FormulationAgencyNameDropdown);
                ClickClearEnterText(_requestLoaPageInstance.FormulationAgencyNameDropdown, updatedAgencyName);
                ClickClearEnterText(_requestLoaPageInstance.FormulationLocationNameEntryTextbox, updatedLocationName);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + formulationName + "', got updated to '" + updatedFormulationName + "'");
            }
            else if (inbox == "Coating DMF")
            {
                string coatingLocation = inboxItemValues["coatingLocation"];
                string updateCoatingLocation = updatedInboxItemValues["coatingLocation"];
                string updateAgencyName = updatedInboxItemValues["agencyName"];
                string updateCoatingName = updatedInboxItemValues["coatingName"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, coatingLocation, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateCoatingLocationUpdateCoatingDmfPage(coatingLocation);
                ClickClearEnterText(_requestLoaPageInstance.NewCoatingLocationTextbox, updateCoatingLocation);
                ClearTextboxValues(_requestLoaPageInstance.NewAgencyNameDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewAgencyNameDropdown, updateAgencyName);
                ClearTextboxValues(_requestLoaPageInstance.NewCoatingNameDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewCoatingNameDropdown, updateCoatingName);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + coatingLocation + "', got updated to '" + updateCoatingLocation + "'");
            }
            else if (inbox == "DMF")
            {
                string dmfNumber = inboxItemValues["dmfNumber"];
                string agencyName = updatedInboxItemValues["agencyName"];
                string dmfDescription = updatedInboxItemValues["dmfDescription"];
                string updatedDmfNumber = updatedInboxItemValues["dmfNumber"];
                string updatedDmfProcessType = updatedInboxItemValues["dmfProcessType"];
                string updatedDmfTitleText = updatedInboxItemValues["dmfTitleText"];
                string updatedDmfType = updatedInboxItemValues["dmfType"];
                string updatedLoaTemplateName = updatedInboxItemValues["loaTemplateName"];
                string updatedPlant = updatedInboxItemValues["plant"];
                string updatedDmfDisclaimer = updatedInboxItemValues["dmfDisclaimer"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, dmfNumber, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateDmfNumberUpdateDmfPage(dmfNumber);
                ClearTextboxValues(_requestLoaPageInstance.AgencyNameDropdown);
                ClickClearEnterText(_requestLoaPageInstance.AgencyNameDropdown, agencyName);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfNumberEntryTextbox, updatedDmfNumber);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfDescriptionEntryTextbox, dmfDescription);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfProcessTypeEntryTextbox, updatedDmfProcessType);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfTitleTextEntryTextbox, updatedDmfTitleText);
                ClickClearEnterText(_requestLoaPageInstance.NewDmfTypeEntryTextbox, updatedDmfType);
                ClearTextboxValues(_requestLoaPageInstance.LoaTemplateDropdown);
                ClickClearEnterText(_requestLoaPageInstance.LoaTemplateDropdown, updatedLoaTemplateName);
                ClearTextboxValues(_requestLoaPageInstance.PlantDropdown);
                ClickClearEnterText(_requestLoaPageInstance.PlantDropdown, updatedPlant);
                ClickClearEnterText(_requestLoaPageInstance.NewDisclaimerEditorTextbox, updatedDmfDisclaimer);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + dmfNumber + "', got updated to '" + updatedDmfNumber + "'");
            }
            else if (inbox == "Plant")
            {
                string plantAddress = inboxItemValues["plantAddress"];
                string updatedPlantAddress = updatedInboxItemValues["plantAddress"];
                string updatedPlantTitle = updatedInboxItemValues["plantTitle"];
                string updatedPlantAbbreviation = updatedInboxItemValues["plantAbbreviation"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, plantAddress, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidatePlantAddressUpdatePlantPage(plantAddress);
                ClickClearEnterText(_requestLoaPageInstance.NewPlantAddressEntry, updatedPlantAddress);
                ClickClearEnterText(_requestLoaPageInstance.NewPlantTitleEntry, updatedPlantTitle);
                ClickClearEnterText(_requestLoaPageInstance.NewPlantAbbreviationEntry, updatedPlantAbbreviation);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + plantAddress + "', got updated to '" + updatedPlantAddress + "'");
            }
            else if (inbox == "Standard Email Statement")
            {
                string titleEntry = inboxItemValues["titleEntry"];
                string updatedTitleEntry = updatedInboxItemValues["titleEntry"];
                string updatedStandardEmailStatement = updatedInboxItemValues["standardEmailStatement"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, titleEntry, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateTitleUpdateStandardEmailStatementPage(titleEntry);
                ClickClearEnterText(_requestLoaPageInstance.NewStandardEmailsTitleEntry, updatedTitleEntry);
                ClickClearEnterText(_requestLoaPageInstance.NewStandardEmailStatementEntry, updatedStandardEmailStatement); 
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + titleEntry + "', got updated to '" + updatedTitleEntry + "'");
            }
            else if (inbox == "Product")
            {
                string westItemNumber = inboxItemValues["westItemNumber"];
                string title = inboxItemValues["title"];
                string updatedTitle = updatedInboxItemValues["title"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, westItemNumber, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateWestItemNumberInUpdateProductPage(westItemNumber);
                FurnishDetailsInNewProductCreationPage(updatedInboxItemValues, true);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item with West Item Number '"+ westItemNumber + "' and Title, '" + title + "', got updated to '" + updatedTitle + "'");
            }
            else if (inbox == "Formulation")
            {
                string formulationName = inboxItemValues["formulationName"];
                string updatedFormulationName = updatedInboxItemValues["formulationName"];
                string updatedContains2MCBT = updatedInboxItemValues["contains2MCBT"];
                string updatedRelatedSubstance = updatedInboxItemValues["relatedSubstance"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, formulationName, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox, formulationName);
                ClickClearEnterText(_requestLoaPageInstance.FormulationEntryTextbox, updatedFormulationName);
                SelectContainsMCBTDropDownValue(updatedContains2MCBT);
                ClickClearEnterText(_requestLoaPageInstance.RelatedSubstanceEntryTextbox, updatedRelatedSubstance);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + formulationName + "', got updated to '" + updatedFormulationName + "'");
            }
            else if (inbox == "Wash Process DMF")
            {
                string plant = inboxItemValues["plant"];
                string title = inboxItemValues["title"];
                string updatedTitle = updatedInboxItemValues["title"];
                string updatedFormulationType = updatedInboxItemValues["formulationType"];
                string updatedPlant = updatedInboxItemValues["plant"];
                string updatedAgencyName = updatedInboxItemValues["agencyName"];
                string updatedLoaTemplate = updatedInboxItemValues["loaTemplate"];
                string updatedConfigBerFamily = updatedInboxItemValues["configBerFamily"];
                string updatedAmendment = updatedInboxItemValues["amendment"];
                string updatedBerTable = updatedInboxItemValues["berTable"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, title, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessTitleEntryTextbox, updatedTitle); 
                ClearTextboxValues(_requestLoaPageInstance.NewWashFormualtionTypeDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewWashFormualtionTypeDropdown, updatedFormulationType);
                ClearTextboxValues(_requestLoaPageInstance.NewWashPlantDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewWashPlantDropdown, updatedPlant);
                ClearTextboxValues(_requestLoaPageInstance.NewWashProcessDmfLoaAgencyDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfLoaAgencyDropdown, updatedAgencyName);
                ClearTextboxValues(_requestLoaPageInstance.NewWashProcessDmfLoaTemplateDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfLoaTemplateDropdown, updatedLoaTemplate);
                ClearTextboxValues(_requestLoaPageInstance.NewWashProcessConfigBerFamilyDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessConfigBerFamilyDropdown, updatedConfigBerFamily);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfAmendmentTextbox, updatedAmendment);
                ClickClearEnterText(_requestLoaPageInstance.NewWashProcessDmfBerTableTextbox, updatedBerTable);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + plant + "', got updated to '" + updatedPlant + "'");
            }
            else if (inbox == "China Dossier Number")
            {
                string chinaDMFSubject = inboxItemValues["chinaDMFSubject"];
                string dossierNumberCode = inboxItemValues["dossierNumberCode"];
                string updatedChinaDMFSubject = updatedInboxItemValues["chinaDMFSubject"];
                string updatedDossierNumberCode = updatedInboxItemValues["dossierNumberCode"];
                string updatedConfigurationsField = updatedInboxItemValues["configurationsField"];
                string updatedPlant = updatedInboxItemValues["plant"];
                string updatedSpecification = updatedInboxItemValues["specification"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, chinaDMFSubject, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox, dossierNumberCode);
                ClickClearEnterText(_requestLoaPageInstance.DmfSubjectEntryTextbox, updatedChinaDMFSubject);
                ClickClearEnterText(_requestLoaPageInstance.ChinaDossierNumberCodeEntryTextbox, updatedDossierNumberCode);
                ClickClearEnterText(_requestLoaPageInstance.ConfigarationFieldEntryTextbox, updatedConfigurationsField);
                ClearTextboxValues(_requestLoaPageInstance.ChinaDossierPlantDropdown);
                ClickClearEnterText(_requestLoaPageInstance.ChinaDossierPlantDropdown, updatedPlant);
                ClickClearEnterText(_requestLoaPageInstance.SpecificationEntryTextbox, updatedSpecification);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + chinaDMFSubject + "', got updated to '" + updatedChinaDMFSubject + "'");
            }
            else if (inbox == "Steril Process DMF")
            {
                string plant = inboxItemValues["plant"];
                string title = inboxItemValues["title"];
                string updatedTitle = updatedInboxItemValues["title"];
                string updatedPlant = updatedInboxItemValues["plant"];
                string updatedAgencyName = updatedInboxItemValues["agencyName"];
                string updatedPackingOption = updatedInboxItemValues["packingOption"];
                string updatedLoaTemplate = updatedInboxItemValues["loaTemplate"];
                string updatedAmendmentText = updatedInboxItemValues["amendmentText"];
                string updatedStmStrlProdDesc = updatedInboxItemValues["stmStrlProdDesc"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, title, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessTitleEntryTextbox, updatedTitle);
                ClearTextboxValues(_requestLoaPageInstance.NewSterilePlantDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewSterilePlantDropdown, updatedPlant);
                ClearTextboxValues(_requestLoaPageInstance.NewSterileProcessDmfLoaAgencyDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessDmfLoaAgencyDropdown, updatedAgencyName);
                ClearTextboxValues(_requestLoaPageInstance.NewSterileProcessPackOptionDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessPackOptionDropdown, updatedPackingOption);
                ClearTextboxValues(_requestLoaPageInstance.NewSterileLoaTemplateDropdown);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileLoaTemplateDropdown, updatedLoaTemplate);
                ClickClearEnterText(_requestLoaPageInstance.NewSterileProcessAmendmentTextbox, updatedAmendmentText);
                ClickClearEnterText(_requestLoaPageInstance.NewStmStrlProdDescEntryTextbox, updatedStmStrlProdDesc);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + plant + "', got updated to '" + updatedPlant + "'");
            }
            else if (inbox == "Pack Option")
            {
                string packOption = inboxItemValues["packOption"];
                string updatedPackOption = updatedInboxItemValues["packOption"];
                string updatedTitlePackOption = updatedInboxItemValues["titlePackOption"];

                ToggleInboxesVisibility(true);
                SearchItemInInboxHomePage(inbox, packOption, tabNameInInboxHomePage);
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox, packOption);
                ClickClearEnterText(_requestLoaPageInstance.TitlePackOptionTextbox, updatedTitlePackOption);
                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), updatedPackOption);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '" + packOption + "', got updated to '" + updatedPackOption + "'");
            }
            else
            {
                string inboxItemValue = inboxItemValues["inboxItemValue"];
                string updatedInboxItemValue = updatedInboxItemValues["inboxItemValue"];

                ToggleInboxesVisibility(true);
                SearchEntryInInboxHomePage(inbox, inboxItemValue, tabNameInInboxHomePage, String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c))));
                ToggleInboxesVisibility(false);
                OpenActionsFromInboxHomePage(inbox, updateSelectedInboxItemAction);
                ValidatePageTitleAddOrUpdateInboxPage(updateInboxItemPageTitle);
                ValidateInboxItemInUpdateInboxItemsPage(inbox, inboxItemValue);
                ClickClearEnterText(_requestLoaPageInstance.NewInboxItemEntryTextbox(String.Concat(inbox.Where(c => !Char.IsWhiteSpace(c)))), updatedInboxItemValue);
                ClickNewInboxItemSaveButton(inbox);
                ClickAlertWindowOKButton(alertTitleInboxItemSaved, alertMesageInboxItemSaved);
                LogInfo("The '" + inbox + "' inbox item, '"+ inboxItemValue + "', got updated to '" + updatedInboxItemValue + "'");
            }
        }
        public void ValidateCompanyNameFromLoaContactTab(string tabName, string custCompany, string reqCompany)
        {
            HashSet<string> hashSetActualFirstRowContacts = new HashSet<string>();
            HashSet<string> hashSetActualSecondRowContacts = new HashSet<string>();

            GetRowValues(1, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
            {
                if (!hashSetActualFirstRowContacts.Contains(value))
                    hashSetActualFirstRowContacts.Add(value);
            });
            GetRowValues(2, String.Concat(tabName.Where(c => !Char.IsWhiteSpace(c)))).ForEach(value =>
            {
                if (!hashSetActualSecondRowContacts.Contains(value))
                    hashSetActualSecondRowContacts.Add(value);
            });

            Assert.AreEqual(hashSetActualFirstRowContacts.Contains(custCompany), true, "The customer company name, '" + custCompany + "' is not diplayed in 'Contacts' page");
            Assert.AreEqual(hashSetActualSecondRowContacts.Contains(reqCompany), true, "The requestor company name, '" + reqCompany + "' is not diplayed in 'Contacts' page");

            ClickBackButton();
            LogInfo("The company names are present in the 'LOA Contact' tab of 'LOA Request' inbox'");

        }
        public void ValidateCompanyNameFromLoaDocument(string inbox_LOADocuments, string loaId, string editLoaDocumentAction, string custCompany, string loaDocumentsTabLabelFirst = "This Month Documents")
        {
            SearchEntryInInboxHomePage(inbox_LOADocuments, loaId, loaDocumentsTabLabelFirst, String.Concat(inbox_LOADocuments.Where(c => !Char.IsWhiteSpace(c))));
            OpenActionsFromInboxHomePage(inbox_LOADocuments, editLoaDocumentAction);
            string textOfLoaDocumentTemplate = _requestLoaPageInstance.ReviewLOADocumentTextRegion.Text;
            Assert.AreEqual(textOfLoaDocumentTemplate.Contains(custCompany), true, "The customer company name, '" + custCompany + "' is not diplayed in 'Contacts' page");
            ClickBackButton();
            LogInfo("Validated Company Name in LOA Document of the LOA, '" + loaId + " in the '" + inbox_LOADocuments + "' inbox page");
        }
        public bool ValidateTextExistanceInLoaDocument(int rowNumber, string editLoaDocumentAction, string textExistInDoc)
        {
            _inboxAction.ClickOnDetailActionSpecificRow(rowNumber+1);
            ClickOnOptionsOfActionDots(editLoaDocumentAction);
            WaitForMoment(2);
            string textOfLoaDocumentTemplate = _requestLoaPageInstance.ReviewLOADocumentTextRegion.Text;
            if (textOfLoaDocumentTemplate.Contains(textExistInDoc))
            {
                Assert.AreEqual(textOfLoaDocumentTemplate.Contains(textExistInDoc), true, "The '"+ textExistInDoc + "' is not diplayed in the LOA Document");
                ClickBackButton();
                LogInfo("Validated '"+ textExistInDoc + "' in LOA Document inbox page at '"+ rowNumber+1 + "' row");
                return true;
            }
            else
            {
                ClickBackButton();
                LogInfo("'" + textExistInDoc + "' is not found in LOA Document inbox page at '" + rowNumber + 1 + "' row");
                return false;
            }
        }
        public void ValidateIsDaikyoEmailSentStatus(string requestLOATabName, bool isDaikyo)
        {
            ScrollHorizontallyRequestLOAInboxPage();
            string isDaikyoValue = GetIsDykoEmailSentValue(requestLOATabName);
            if (isDaikyo)
                Assert.AreEqual("im_af_14.svg", isDaikyoValue, "The 'Tick' mark is displayed in the 'IsDaikyoEmailSent' field");
            else
                Assert.AreEqual("im_af_8.svg", isDaikyoValue, "The 'Cross' mark is displayed in the 'IsDaikyoEmailSent' field");
        }

        #endregion







        #region ApiCalls

        public string GenerateAccessToken(string clientId, string clientSecret)
        {
            string baseAddress = "https://login.microsoftonline.com/61a70d37-ff63-45e3-bb68-f0edbf718ffd";
            string resource = "api://" + clientId;
            using (var client = new HttpClient())
            {
                var form = new Dictionary<string, string>
                {
                    {"client_id", clientId},
                    {"client_secret", clientSecret},
                    {"resource", resource},
                    {"grant_type", "client_credentials"}
                };
                var tokenResponse = client.PostAsync(baseAddress + "/oauth2/token", new FormUrlEncodedContent(form)).Result;
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                LogInfo("Generated the 'access token, '" + token.AccessToken + "'");
                if (string.IsNullOrEmpty(token.Error))
                    return token.AccessToken;
                else
                    return token.Error;
            }
        }
        public async Task CreateLOAApiPOST(string accessToken, string newLoaId, string appEnvironmentName, string dataContent, string westItemNumber)
        {
            try
            {
                string url = "https://west-loa-api-" + appEnvironmentName + ".azurewebsites.net/odata/ExternalLoa";
                string requetBodyJson;
                apiInput = jsonInputsValuesForApi(dataContent);

                if (dataContent == "ThreeEntry")
                {
                    LoaAgencyTableList(apiInput["AppAgencyOneExpansion"], apiInput["AppTypeOne"], apiInput["AppNoOne"], "");
                    LoaAgencyTableList(apiInput["AppAgencyTwoExpansion"], apiInput["AppTypeTwo"], apiInput["AppNoTwo"], "");
                    LoaAgencyTableList(apiInput["AppAgencyThreeExpansion"], apiInput["AppTypeThree"], apiInput["AppNoThree"], "");
                    LoaAgencyTableList(apiInput["AppAgencyFourExpansion"], apiInput["AppTypeFour"], apiInput["AppNoFour"], "");

                    LoaItemTableList(apiInput["ItemNoOne"], apiInput["ItemDescriptionOne"], "Ready", "True", "", "", "");
                    LoaItemTableList(apiInput["ItemNoTwo"], apiInput["ItemDescriptionTwo"], "Ready", "False", "", "", "");
                    LoaItemTableList(apiInput["ItemNoThree"], apiInput["ItemDescriptionThree"], "Ready", "False", "", "", "");

                    LoaProductTableList(apiInput["ItemNoOne"], apiInput["ItemNoOneFormulation"], apiInput["ItemNoOneConfiguration"], "False");
                    LoaProductTableList(apiInput["ItemNoTwo"], apiInput["ItemNoTwoFormulation"], apiInput["ItemNoTwoConfiguration"], "False");
                    LoaProductTableList(apiInput["ItemNoThree"], apiInput["ItemNoThreeFormulation"], apiInput["ItemNoThreeConfiguration"], "False");
                }
                if (dataContent == "ProductEntry")
                {
                    apiInput.Add("ItemNoOne", westItemNumber);
                }
                if (dataContent == "EndotoxinEntry")
                {
                    apiInput.Add("ItemNoOne", westItemNumber);
                }
                requetBodyJson = "{\"SiteCoreId\":\"" + newLoaId + "\",\"FirstName\":\"FirstNmAutomation\",\"LastName\":\"LastNmAutomation\",\"YourTitle\":\"Mr\",\"Email\":\"automation.testmail@westpharma.com\",\"Phone\":\"" + GenerateRandomDigits(10) + "\",\"Address1\":\"Door No:12\",\"Address2\":\"Lane No: 34\",\"Address3\":\"StreetNameAutomation\",\"City\":\"CityAutomation\",\"State\":\"StateAutomation\",\"PostalCode\":\"" + GenerateRandomDigits(6) + "\",\"Country\":\"CountryAutomation\",\"Title\":\"AutomationTester\",\"Company\":\"CompanyAutomation\",\"CopyEmail\":\"copy.testmail@westpharma.com\",\"CopyFirstName\":\"CopyFstNmAutomation\",\"CopyLastName\":\"CopyLstNmAutomation\",\"CopyLoacopy\":\"yes\",\"CustomerFirstName\":\"CustFstNmAutomation\",\"CustomerLastName\":\"CustLstNmAutomation\",\"CustomerTitle\":\"Ms\",\"CustomerEmail\":\"customer.testmail@westpharma.com\",\"CustomerPhone\":\"" + GenerateRandomDigits(10) + "\",\"CustomerAddress1\":\"CustDoor No:12\",\"CustomerAddress2\":\"CustLane No: 34\",\"CustomerAddress3\":\"CustStreetNameAutomation\",\"CustomerCity\":\"CustCityAutomation\",\"CustomerState\":\"CustStateAutomation\",\"CustomerPostalCode\":\"" + GenerateRandomDigits(6) + "\",\"CustomerCountry\":\"CustCountryAutomation\",\"CustomerCompanyName\":\"CustCompanyAutomation\",\"CustomerLoacopy\":\"no\",\"DrugProductName\":\"DrugProduct Automation\",\"SalesOrderId\":\"" + GenerateRandomDigits(6) + "\",\"IsContractLabTest\":\"True\",\"ContractLabTest\":\"ContractLabTest Automation\",\"Crmnumber\":\"WestCRM01\",\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"Instruct\":\"Additional Instructions Automation\",\"DateRequested\":\"" + (DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:00'Z'")) + "\",\"DateRequired\":\"" + (DateTime.Now.AddDays(16).ToString("yyyy-MM-dd'T'HH:mm:00'Z'")) + "\",\"ItemNo1\":\"" + apiInput["ItemNoOne"] + "\",\"ItemNo2\":\"" + apiInput["ItemNoTwo"] + "\",\"ItemNo3\":\"" + apiInput["ItemNoThree"] + "\",\"ItemDescription1\":\"" + apiInput["ItemDescriptionOne"] + "\",\"ItemDescription2\":\"" + apiInput["ItemDescriptionTwo"] + "\",\"ItemDescription3\":\"" + apiInput["ItemDescriptionThree"] + "\",\"Drawing1\":\"" + apiInput["DrawingOne"] + "\",\"Drawing2\":\"" + apiInput["DrawingTwo"] + "\",\"Drawing3\":\"" + apiInput["DrawingThree"] + "\",\"AppAgency1\":\"" + apiInput["AppAgencyOne"] + "\",\"AppAgency2\":\"" + apiInput["AppAgencyTwo"] + "\",\"AppAgency3\": \"" + apiInput["AppAgencyThree"] + "\",\"AppAgency4\":\"" + apiInput["AppAgencyFour"] + "\",\"AppType1\":\"" + apiInput["AppTypeOne"] + "\",\"AppType2\":\"" + apiInput["AppTypeTwo"] + "\",\"AppType3\":\"" + apiInput["AppTypeThree"] + "\",\"AppType4\":\"" + apiInput["AppTypeFour"] + "\",\"AppNo1\":\"" + apiInput["AppNoOne"] + "\",\"AppNo2\":\"" + apiInput["AppNoTwo"] + "\",\"AppNo3\":\"" + apiInput["AppNoThree"] + "\",\"AppNo4\":\"" + apiInput["AppNoFour"] + "\"}";
             
                var client = new HttpClient();
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                httpRequest.Content = new StringContent(requetBodyJson, Encoding.UTF8, "application/json");
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                {
                    LogInfo(response.StatusCode.ToString());
                    using (HttpContent content = response.Content)
                        LogInfo(content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public async Task CreateLOAApiPOST(string accessToken, string newLoaId, string appEnvironmentName, string emailId, string itemNoOne, string appTypeOne, string appAgencyOne, string itemDescriptionOne, string attribute="", string formulation = "", string configuration = "")
        {
            try
            {
                string url = "https://west-loa-api-" + appEnvironmentName + ".azurewebsites.net/odata/ExternalLoa";
                string requetBodyJson;
                var client = new HttpClient();
                apiInput = jsonInputsValuesForApi();
                apiInput.Add("Formulation", formulation);
                apiInput.Add("Configuration", configuration);

                hashSetExpectedFirstRowContacts = new HashSet<string>() { "Company", apiInput["CustomerFirstName"], apiInput["CustomerLastName"], apiInput["CustomerTitle"], apiInput["CustomerCompanyName"], apiInput["CustomerAddress1"], apiInput["CustomerAddress2"], apiInput["CustomerAddress3"], apiInput["CustomerCity"], apiInput["CustomerState"], apiInput["CustomerPostalCode"], apiInput["CustomerCountry"], apiInput["CustomerPhone"], apiInput["CustomerEmail"], "False" };
                hashSetExpectedSecondRowContacts = new HashSet<string>() { "Requestor", apiInput["FirstName"], apiInput["LastName"], apiInput["YourTitle"], apiInput["Company"], apiInput["Address1"], apiInput["Address2"], apiInput["Address3"], apiInput["City"], apiInput["State"], apiInput["PostalCode"], apiInput["Country"], apiInput["Phone"], emailId, "" };

                LoaItemTableList(itemNoOne, itemDescriptionOne, "Ready", "True", "", "", "");
                LoaProductTableList(itemNoOne, formulation, configuration, "False");
                if(attribute == "CompanyNameSpecialChar")
                    requetBodyJson = "{\"City\":\"" + apiInput["City"] + "\",\"Email\":\"" + emailId + "\",\"Phone\":\"" + apiInput["Phone"] + "\",\"Title\":\"AutomationEngineer\",\"Company\":\"West!@#$%^&*()_+,.<>?/`~[]{}=-|\",\"Country\":\"" + apiInput["Country"] + "\",\"ItemNo1\":\"" + itemNoOne + "\",\"Address1\":\"" + apiInput["Address1"] + "\",\"AppType1\":\"" + appTypeOne + "\",\"LastName\":\"" + apiInput["LastName"] + "\",\"FirstName\":\"" + apiInput["FirstName"] + "\",\"AppAgency1\":\"" + appAgencyOne + "\",\"SalesOrderId\":\"" + apiInput["SalesOrderId"] + "\",\"AppNo1\":\"" + apiInput["AppNo1"] + "\",\"AppNo2\": null,\"AppNo3\": null,\"AppNo4\": null,\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"SiteCoreId\":\"" + newLoaId + "\",\"Address2\": \"" + apiInput["Address2"] + "\",\"Address3\": \"" + apiInput["Address3"] + "\",\"AppType2\": null,\"AppType3\": null,\"AppType4\": null,\"AppAgency2\": null,\"AppAgency3\": null,\"AppAgency4\": null,\"ContractLabTest\":\"" + apiInput["ContractLabTest"] + "\",\"CopyEmail\":\"" + apiInput["CopyEmail"] + "\",\"CopyFirstName\": \"" + apiInput["CopyFirstName"] + "\",\"CopyLastName\": \"" + apiInput["CopyLastName"] + "\",\"CopyLoacopy\":\"yes\",\"Crmnumber\":\"WestCRM01\",\"CustomerAddress1\":\"" + apiInput["CustomerAddress1"] + "\",\"CustomerAddress2\": \"" + apiInput["CustomerAddress2"] + "\",\"CustomerAddress3\": \"" + apiInput["CustomerAddress3"] + "\",\"CustomerCity\":\"" + apiInput["CustomerCity"] + "\",\"CustomerCompanyName\":\"CustWest!@#$%^&*()_+,.<>?/`~[]{}=-|\",\"CustomerCountry\":\"" + apiInput["CustomerCountry"] + "\",\"CustomerEmail\":\"" + apiInput["CustomerEmail"] + "\",\"CustomerFirstName\":\"" + apiInput["CustomerFirstName"] + "\",\"CustomerLastName\":\"" + apiInput["CustomerLastName"] + "\",\"CustomerLoacopy\":\"no\",\"CustomerPhone\":\"" + apiInput["CustomerPhone"] + "\",\"CustomerPostalCode\":\"" + apiInput["CustomerPostalCode"] + "\",\"CustomerState\":\"" + apiInput["CustomerState"] + "\",\"CustomerTitle\":\"" + apiInput["CustomerTitle"] + "\",\"Drawing1\":\"yes\",\"Drawing2\": \"no\",\"Drawing3\": \"no\",\"Instruct\":\"" + apiInput["Instruct"] + "\",\"IsContractLabTest\":\"True\",\"ItemDescription1\":\"" + itemDescriptionOne + "\",\"ItemDescription2\": null,\"ItemDescription3\": null,\"ItemNo2\": null,\"ItemNo3\": null,\"PostalCode\":\"" + apiInput["PostalCode"] + "\",\"State\":\"" + apiInput["State"] + "\",\"YourTitle\":\"" + apiInput["YourTitle"] + "\",\"DateRequested\":\"" + apiInput["DateRequested"] + "\",\"DateRequired\":\"" + apiInput["DateRequired"] + "\",\"DrugProductName\":\"" + apiInput["DrugProductName"] + "\"}";
                else if(attribute == "NovaPureRU")
                    requetBodyJson = "{\"City\":\"" + apiInput["City"] + "\",\"Email\":\"" + emailId + "\",\"Phone\":\"" + apiInput["Phone"] + "\",\"Title\":\"AutomationEngineer\",\"Company\":\"" + apiInput["Company"] + "\",\"Country\":\"" + apiInput["Country"] + "\",\"ItemNo1\":\"" + itemNoOne + "\",\"Address1\":\"" + apiInput["Address1"] + "\",\"AppType1\":\"" + appTypeOne + "\",\"LastName\":\"" + apiInput["LastName"] + "\",\"FirstName\":\"" + apiInput["FirstName"] + "\",\"AppAgency1\":\"" + appAgencyOne + "\",\"SalesOrderId\":\"" + apiInput["SalesOrderId"] + "\",\"AppNo1\":\"" + apiInput["AppNo1"] + "\",\"AppNo2\": null,\"AppNo3\": null,\"AppNo4\": null,\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"SiteCoreId\":\"" + newLoaId + "\",\"Address2\": \"" + apiInput["Address2"] + "\",\"Address3\": \"" + apiInput["Address3"] + "\",\"AppType2\": null,\"AppType3\": null,\"AppType4\": null,\"AppAgency2\": null,\"AppAgency3\": null,\"AppAgency4\": null,\"ContractLabTest\":\"" + apiInput["ContractLabTest"] + "\",\"CopyEmail\":\"" + apiInput["CopyEmail"] + "\",\"CopyFirstName\": \"" + apiInput["CopyFirstName"] + "\",\"CopyLastName\": \"" + apiInput["CopyLastName"] + "\",\"CopyLoacopy\":\"yes\",\"Crmnumber\":\"WestCRM01\",\"CustomerAddress1\":\"" + apiInput["CustomerAddress1"] + "\",\"CustomerAddress2\": \"" + apiInput["CustomerAddress2"] + "\",\"CustomerAddress3\": \"" + apiInput["CustomerAddress3"] + "\",\"CustomerCity\":\"" + apiInput["CustomerCity"] + "\",\"CustomerCompanyName\":\"" + apiInput["CustomerCompanyName"] + "\",\"CustomerCountry\":\"" + apiInput["CustomerCountry"] + "\",\"CustomerEmail\":\"" + apiInput["CustomerEmail"] + "\",\"CustomerFirstName\":\"" + apiInput["CustomerFirstName"] + "\",\"CustomerLastName\":\"" + apiInput["CustomerLastName"] + "\",\"CustomerLoacopy\":\"no\",\"CustomerPhone\":\"" + apiInput["CustomerPhone"] + "\",\"CustomerPostalCode\":\"" + apiInput["CustomerPostalCode"] + "\",\"CustomerState\":\"" + apiInput["CustomerState"] + "\",\"CustomerTitle\":\"" + apiInput["CustomerTitle"] + "\",\"Drawing1\":\"yes\",\"Drawing2\": \"no\",\"Drawing3\": \"no\",\"Instruct\":\"" + apiInput["Instruct"] + "\",\"IsContractLabTest\":\"True\",\"ItemDescription1\":\"" + itemDescriptionOne + "\",\"ItemDescription2\": null,\"ItemDescription3\": null,\"ItemNo2\": null,\"ItemNo3\": null,\"PostalCode\":\"" + apiInput["PostalCode"] + "\",\"State\":\"" + apiInput["State"] + "\",\"YourTitle\":\"" + apiInput["YourTitle"] + "\",\"DateRequested\":\"" + apiInput["DateRequested"] + "\",\"DateRequired\":\"" + apiInput["DateRequired"] + "\",\"DrugProductName\":\"" + apiInput["DrugProductName"] + "\"}";
                else if (attribute == "NovaPureRUThreeAgency")
                    requetBodyJson = "{\"City\":\"" + apiInput["City"] + "\",\"Email\":\"" + emailId + "\",\"Phone\":\"" + apiInput["Phone"] + "\",\"Title\":\"AutomationEngineer\",\"Company\":\"" + apiInput["Company"] + "\",\"Country\":\"" + apiInput["Country"] + "\",\"ItemNo1\":\"" + itemNoOne + "\",\"Address1\":\"" + apiInput["Address1"] + "\",\"AppType1\":\"" + appTypeOne + "\",\"LastName\":\"" + apiInput["LastName"] + "\",\"FirstName\":\"" + apiInput["FirstName"] + "\",\"AppAgency1\":\"" + appAgencyOne + "\",\"SalesOrderId\":\"" + apiInput["SalesOrderId"] + "\",\"AppNo1\":\"" + apiInput["AppNo1"] + "\",\"AppNo2\": null,\"AppNo3\": null,\"AppNo4\": null,\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"SiteCoreId\":\"" + newLoaId + "\",\"Address2\": \"" + apiInput["Address2"] + "\",\"Address3\": \"" + apiInput["Address3"] + "\",\"AppType2\": \"IND\",\"AppType3\": \"NADA\",\"AppType4\": null,\"AppAgency2\": \"Health Canada\",\"AppAgency3\": \"FDA @ CBER\",\"AppAgency4\": null,\"ContractLabTest\":\"" + apiInput["ContractLabTest"] + "\",\"CopyEmail\":\"" + apiInput["CopyEmail"] + "\",\"CopyFirstName\": \"" + apiInput["CopyFirstName"] + "\",\"CopyLastName\": \"" + apiInput["CopyLastName"] + "\",\"CopyLoacopy\":\"yes\",\"Crmnumber\":\"WestCRM01\",\"CustomerAddress1\":\"" + apiInput["CustomerAddress1"] + "\",\"CustomerAddress2\": \"" + apiInput["CustomerAddress2"] + "\",\"CustomerAddress3\": \"" + apiInput["CustomerAddress3"] + "\",\"CustomerCity\":\"" + apiInput["CustomerCity"] + "\",\"CustomerCompanyName\":\"" + apiInput["CustomerCompanyName"] + "\",\"CustomerCountry\":\"" + apiInput["CustomerCountry"] + "\",\"CustomerEmail\":\"" + apiInput["CustomerEmail"] + "\",\"CustomerFirstName\":\"" + apiInput["CustomerFirstName"] + "\",\"CustomerLastName\":\"" + apiInput["CustomerLastName"] + "\",\"CustomerLoacopy\":\"no\",\"CustomerPhone\":\"" + apiInput["CustomerPhone"] + "\",\"CustomerPostalCode\":\"" + apiInput["CustomerPostalCode"] + "\",\"CustomerState\":\"" + apiInput["CustomerState"] + "\",\"CustomerTitle\":\"" + apiInput["CustomerTitle"] + "\",\"Drawing1\":\"yes\",\"Drawing2\": \"no\",\"Drawing3\": \"no\",\"Instruct\":\"" + apiInput["Instruct"] + "\",\"IsContractLabTest\":\"True\",\"ItemDescription1\":\"" + itemDescriptionOne + "\",\"ItemDescription2\": null,\"ItemDescription3\": null,\"ItemNo2\": null,\"ItemNo3\": null,\"PostalCode\":\"" + apiInput["PostalCode"] + "\",\"State\":\"" + apiInput["State"] + "\",\"YourTitle\":\"" + apiInput["YourTitle"] + "\",\"DateRequested\":\"" + apiInput["DateRequested"] + "\",\"DateRequired\":\"" + apiInput["DateRequired"] + "\",\"DrugProductName\":\"" + apiInput["DrugProductName"] + "\"}";
                else if(attribute == "DaikyoProduct")
                    requetBodyJson = "{\"City\":\"" + apiInput["City"] + "\",\"Email\":\"" + emailId + "\",\"Phone\":\"" + apiInput["Phone"] + "\",\"Title\":\"AutomationEngineer\",\"Company\":\"" + apiInput["Company"] + "\",\"Country\":\"" + apiInput["Country"] + "\",\"ItemNo1\":\"" + itemNoOne + "\",\"Address1\":\"" + apiInput["Address1"] + "\",\"AppType1\":\"" + appTypeOne + "\",\"LastName\":\"" + apiInput["LastName"] + "\",\"FirstName\":\"" + apiInput["FirstName"] + "\",\"AppAgency1\":\"" + appAgencyOne + "\",\"SalesOrderId\":\"" + apiInput["SalesOrderId"] + "\",\"AppNo1\":\"" + apiInput["AppNo1"] + "\",\"AppNo2\": null,\"AppNo3\": null,\"AppNo4\": null,\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"SiteCoreId\":\"" + newLoaId + "\",\"Address2\": \"" + apiInput["Address2"] + "\",\"Address3\": \"" + apiInput["Address3"] + "\",\"AppType2\": null,\"AppType3\": null,\"AppType4\": null,\"AppAgency2\": null,\"AppAgency3\": null,\"AppAgency4\": null,\"ContractLabTest\":\"" + apiInput["ContractLabTest"] + "\",\"CopyEmail\":\"" + apiInput["CopyEmail"] + "\",\"CopyFirstName\": \"" + apiInput["CopyFirstName"] + "\",\"CopyLastName\": \"" + apiInput["CopyLastName"] + "\",\"CopyLoacopy\":\"yes\",\"Crmnumber\":\"WestCRM01\",\"CustomerAddress1\":\"" + apiInput["CustomerAddress1"] + "\",\"CustomerAddress2\": \"" + apiInput["CustomerAddress2"] + "\",\"CustomerAddress3\": \"" + apiInput["CustomerAddress3"] + "\",\"CustomerCity\":\"" + apiInput["CustomerCity"] + "\",\"CustomerCompanyName\":\"" + apiInput["CustomerCompanyName"] + "\",\"CustomerCountry\":\"" + apiInput["CustomerCountry"] + "\",\"CustomerEmail\":\"" + apiInput["CustomerEmail"] + "\",\"CustomerFirstName\":\"" + apiInput["CustomerFirstName"] + "\",\"CustomerLastName\":\"" + apiInput["CustomerLastName"] + "\",\"CustomerLoacopy\":\"no\",\"CustomerPhone\":\"" + apiInput["CustomerPhone"] + "\",\"CustomerPostalCode\":\"" + apiInput["CustomerPostalCode"] + "\",\"CustomerState\":\"" + apiInput["CustomerState"] + "\",\"CustomerTitle\":\"" + apiInput["CustomerTitle"] + "\",\"Drawing1\":\"yes\",\"Drawing2\": \"no\",\"Drawing3\": \"no\",\"Instruct\":\"" + apiInput["Instruct"] + "\",\"IsContractLabTest\":\"True\",\"ItemDescription1\":\"" + itemDescriptionOne + "\",\"ItemDescription2\": null,\"ItemDescription3\": null,\"ItemNo2\": null,\"ItemNo3\": null,\"PostalCode\":\"" + apiInput["PostalCode"] + "\",\"State\":\"" + apiInput["State"] + "\",\"YourTitle\":\"" + apiInput["YourTitle"] + "\",\"DateRequested\":\"" + apiInput["DateRequested"] + "\",\"DateRequired\":\"" + apiInput["DateRequired"] + "\",\"DrugProductName\":\"" + apiInput["DrugProductName"] + "\"}";
                else
                    requetBodyJson = "{\"City\":\"" + apiInput["City"] + "\",\"Email\":\"" + emailId + "\",\"Phone\":\"" + apiInput["Phone"] + "\",\"Title\":\"AutomationEngineer\",\"Company\":\"" + apiInput["Company"] + "\",\"Country\":\"" + apiInput["Country"] + "\",\"ItemNo1\":\"" + itemNoOne + "\",\"Address1\":\"" + apiInput["Address1"] + "\",\"AppType1\":\"" + appTypeOne + "\",\"LastName\":\"" + apiInput["LastName"] + "\",\"FirstName\":\"" + apiInput["FirstName"] + "\",\"AppAgency1\":\"" + appAgencyOne + "\",\"SalesOrderId\":\"" + apiInput["SalesOrderId"] + "\",\"AppNo1\":\"" + apiInput["AppNo1"] + "\",\"AppNo2\": null,\"AppNo3\": null,\"AppNo4\": null,\"AppOtherType1\": null,\"AppOtherType2\": null,\"AppOtherType3\": null,\"AppOtherType4\": null,\"SiteCoreId\":\"" + newLoaId + "\",\"Address2\": \"" + apiInput["Address2"] + "\",\"Address3\": \"" + apiInput["Address3"] + "\",\"AppType2\": null,\"AppType3\": null,\"AppType4\": null,\"AppAgency2\": null,\"AppAgency3\": null,\"AppAgency4\": null,\"ContractLabTest\":\"" + apiInput["ContractLabTest"] + "\",\"CopyEmail\":\"" + apiInput["CopyEmail"] + "\",\"CopyFirstName\": \"" + apiInput["CopyFirstName"] + "\",\"CopyLastName\": \"" + apiInput["CopyLastName"] + "\",\"CopyLoacopy\":\"yes\",\"Crmnumber\":\"WestCRM01\",\"CustomerAddress1\":\"" + apiInput["CustomerAddress1"] + "\",\"CustomerAddress2\": \"" + apiInput["CustomerAddress2"] + "\",\"CustomerAddress3\": \"" + apiInput["CustomerAddress3"] + "\",\"CustomerCity\":\"" + apiInput["CustomerCity"] + "\",\"CustomerCompanyName\":\"" + apiInput["CustomerCompanyName"] + "\",\"CustomerCountry\":\"" + apiInput["CustomerCountry"] + "\",\"CustomerEmail\":\"" + apiInput["CustomerEmail"] + "\",\"CustomerFirstName\":\"" + apiInput["CustomerFirstName"] + "\",\"CustomerLastName\":\"" + apiInput["CustomerLastName"] + "\",\"CustomerLoacopy\":\"no\",\"CustomerPhone\":\"" + apiInput["CustomerPhone"] + "\",\"CustomerPostalCode\":\"" + apiInput["CustomerPostalCode"] + "\",\"CustomerState\":\"" + apiInput["CustomerState"] + "\",\"CustomerTitle\":\"" + apiInput["CustomerTitle"] + "\",\"Drawing1\":\"yes\",\"Drawing2\": \"no\",\"Drawing3\": \"no\",\"Instruct\":\"" + apiInput["Instruct"] + "\",\"IsContractLabTest\":\"True\",\"ItemDescription1\":\"" + itemDescriptionOne + "\",\"ItemDescription2\": null,\"ItemDescription3\": null,\"ItemNo2\": null,\"ItemNo3\": null,\"PostalCode\":\"" + apiInput["PostalCode"] + "\",\"State\":\"" + apiInput["State"] + "\",\"YourTitle\":\"" + apiInput["YourTitle"] + "\",\"DateRequested\":\"" + apiInput["DateRequested"] + "\",\"DateRequired\":\"" + apiInput["DateRequired"] + "\",\"DrugProductName\":\"" + apiInput["DrugProductName"] + "\"}";

                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                httpRequest.Content = new StringContent(requetBodyJson, Encoding.UTF8, "application/json");
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                
                using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                {
                    LogInfo(response.StatusCode.ToString());
                    using (HttpContent content = response.Content)
                        LogInfo(content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        public IDictionary<string, string> jsonInputsValuesForApi()
        {
            IDictionary<string, string> jsonInputsValues = new Dictionary<string, string>();

            string tempString = GenerateRandomString(7);
            DateTime currDate = DateTime.Now;
            DateTime expctDate = DateTime.Now.AddDays(16);
            jsonInputsValues = new Dictionary<string, string>(){
                {"FirstName", "FirstName" + tempString},
                {"LastName", "LastName" + tempString},
                {"Phone", "9"+GenerateRandomDigits(9)},
                {"Company", "Company " + tempString},
                {"Address1", "AddressOne" + tempString},
                {"Address2", "AddressTwo" + tempString},
                {"Address3", "AddressThree" + tempString},
                {"City", "City " + tempString},
                {"State", "State" + tempString},
                {"Country", "Country" + tempString},
                {"SalesOrderId", "7"+GenerateRandomDigits(6)},
                {"AppNo1", "1"+GenerateRandomDigits(7)},
                {"ContractLabTest", "ContractLab " + tempString},
                {"CopyEmail", tempString + "copy@westpharma.com"},
                {"CopyFirstName", "CopyFstNm" + tempString},
                {"CopyLastName", "CopyLstNm" + tempString},
                {"CustomerAddress1", "CustAdrsOne" + tempString},
                {"CustomerAddress2", "CustAdrsTwo" + tempString},
                {"CustomerAddress3", "CustAdrsThree" + tempString},
                {"CustomerCity", "CustCity" + tempString},
                {"CustomerCompanyName", "CustCompany" + tempString},
                {"CustomerCountry", "CustCountry" + tempString},
                {"CustomerEmail", tempString + "Customer@westpharma.com"},
                {"CustomerFirstName", "CustFstNm" + tempString},
                {"CustomerLastName", "CustLstNm" + tempString},
                {"CustomerPhone", "8"+GenerateRandomDigits(9)},
                {"CustomerPostalCode", "5"+GenerateRandomDigits(5)},
                {"CustomerState", "CustState" + tempString},
                {"Instruct", "Cust Intruct " + tempString},
                {"PostalCode", "6"+GenerateRandomDigits(5)},
                {"DateRequested",(currDate.ToString("yyyy-MM-dd'T'HH:mm:00'Z'"))},
                {"DateRequired", (expctDate.ToString("yyyy-MM-dd'T'HH:mm:00'Z'"))},
                {"DateRequested_Format",(currDate.ToString("MMMMM d, yyyy"))},
                {"DateRequired_Format", (expctDate.ToString("MMMMM d, yyyy"))},
                {"DrugProductName", "Drug " + tempString},
                {"CustomerTitle", "Ms" },
                {"YourTitle", "Mr" }
            };

            return jsonInputsValues;
        }
        public IDictionary<string, string> jsonInputsValuesForApi(string dataContent)
        {
            IDictionary<string, string> jsonInputsValues = new Dictionary<string, string>();

            if (dataContent == "ThreeEntry")
            {
                jsonInputsValues = new Dictionary<string, string>(){
                    {"ItemNoOne", "19700225"},
                    {"ItemNoTwo", "19700226"},
                    {"ItemNoThree", "19700267"},
                    {"ItemDescriptionOne", "WPS S2-F451 4432/50GRY B2-40 WESTARRU/SP"},
                    {"ItemDescriptionTwo", "WPS S10-F451 4432/50GY B240 WESTAR RU/SP"},
                    {"ItemDescriptionThree", "WPS S2-F451 4432/50GRY B240 WESTARRU/SP1"},
                    {"DrawingOne", "yes"},
                    {"DrawingTwo", "no"},
                    {"DrawingThree", "no"},
                    {"AppAgencyOne", "FDA @ CDER or CVM"},
                    {"AppAgencyTwo", "FDA @ CBER"},
                    {"AppAgencyThree", "FDA @ CDRH"},
                    {"AppAgencyFour", "Health Canada"},
                    {"AppTypeOne", "INAD"},
                    {"AppTypeTwo", "IND"},
                    {"AppTypeThree", "INAD"},
                    {"AppTypeFour", "IND"},
                    {"AppNoOne", "5"+GenerateRandomDigits(7)},
                    {"AppNoTwo", "4"+GenerateRandomDigits(7)},
                    {"AppNoThree", "3"+GenerateRandomDigits(7)},
                    {"AppNoFour", "2"+GenerateRandomDigits(7)},
                    {"ItemNoOneFormulation", "4405/44 White"},
                    {"ItemNoTwoFormulation", "4432/50 Gray"},
                    {"ItemNoThreeFormulation", "4432/50 Gray"},
                    {"ItemNoOneConfiguration", "28mm PPF Stopper"},
                    {"ItemNoTwoConfiguration", "S10-F451"},
                    {"ItemNoThreeConfiguration", "S2-F451"},
                    {"AppAgencyOneExpansion", "Center for Drug Evaluation and Research"},
                    {"AppAgencyTwoExpansion", "Center for Biologics Evaluation and Research"},
                    {"AppAgencyThreeExpansion", "Center for Devices and Radiological Health"},
                    {"AppAgencyFourExpansion", "Health Canada"}
                };
            }
            else if (dataContent == "ZeroEntry")
            {
                jsonInputsValues = new Dictionary<string, string>(){
                    {"ItemNoOne", "00000000"},
                    {"ItemNoTwo", null},
                    {"ItemNoThree", null},
                    {"ItemDescriptionOne", null},
                    {"ItemDescriptionTwo", null},
                    {"ItemDescriptionThree", null},
                    {"DrawingOne", "no"},
                    {"DrawingTwo", "no"},
                    {"DrawingThree", "no"},
                    {"AppAgencyOne", "FDA @ CDER or CVM"},
                    {"AppAgencyTwo", "Health Canada"},
                    {"AppAgencyThree", null},
                    {"AppAgencyFour", null},
                    {"AppTypeOne", "INAD"},
                    {"AppTypeTwo", "IND"},
                    {"AppTypeThree", null},
                    {"AppTypeFour", null},
                    {"AppNoOne", "5"+GenerateRandomDigits(7)},
                    {"AppNoTwo", "4"+GenerateRandomDigits(7)},
                    {"AppNoThree", null},
                    {"AppNoFour", null}
                };
            }
            else if (dataContent == "ProductEntry")
            {
                jsonInputsValues = new Dictionary<string, string>(){
                    {"ItemNoTwo", null},
                    {"ItemNoThree", null},
                    {"ItemDescriptionOne", null},
                    {"ItemDescriptionTwo", null},
                    {"ItemDescriptionThree", null},
                    {"DrawingOne", "yes"},
                    {"DrawingTwo", "no"},
                    {"DrawingThree", "no"},
                    {"AppAgencyOne", "FDA @ CDER or CVM"},
                    {"AppAgencyTwo", null},
                    {"AppAgencyThree", null},
                    {"AppAgencyFour", null},
                    {"AppTypeOne", "INAD"},
                    {"AppTypeTwo", null},
                    {"AppTypeThree", null},
                    {"AppTypeFour", null},
                    {"AppNoOne", "5"+GenerateRandomDigits(7)},
                    {"AppNoTwo", null},
                    {"AppNoThree", null},
                    {"AppNoFour", null}
                };
            }
            else if (dataContent == "EndotoxinEntry")
            {
                jsonInputsValues = new Dictionary<string, string>(){
                    {"ItemNoTwo", null},
                    {"ItemNoThree", null},
                    {"ItemDescriptionOne", "DS PCNEST PIS 5ML FR2-2 D21-6-1 ND STMRU"},
                    {"ItemDescriptionTwo", null},
                    {"ItemDescriptionThree", null},
                    {"DrawingOne", "yes"},
                    {"DrawingTwo", "no"},
                    {"DrawingThree", "no"},
                    {"AppAgencyOne", "FDA @ CDER or CVM"},
                    {"AppAgencyTwo", null},
                    {"AppAgencyThree", null},
                    {"AppAgencyFour", null},
                    {"AppTypeOne", "INAD"},
                    {"AppTypeTwo", null},
                    {"AppTypeThree", null},
                    {"AppTypeFour", null},
                    {"AppNoOne", "5"+GenerateRandomDigits(7)},
                    {"AppNoTwo", null},
                    {"AppNoThree", null},
                    {"AppNoFour", null}
                };
            }
            else
            {
                jsonInputsValues = new Dictionary<string, string>(){
                    {"ItemNoOne", "19550210"},
                    {"ItemNoTwo", null},
                    {"ItemNoThree", null},
                    {"ItemDescriptionOne", "DS CZ TRAY ASSY VIAL 2ML 13MM-3 RU/RP"},
                    {"ItemDescriptionTwo", null},
                    {"ItemDescriptionThree", null},
                    {"DrawingOne", "yes"},
                    {"DrawingTwo", "no"},
                    {"DrawingThree", "no"},
                    {"AppAgencyOne", "FDA @ CDER or CVM"},
                    {"AppAgencyTwo", null},
                    {"AppAgencyThree", null},
                    {"AppAgencyFour", null},
                    {"AppTypeOne", "INAD"},
                    {"AppTypeTwo", null},
                    {"AppTypeThree", null},
                    {"AppTypeFour", null},
                    {"AppNoOne", "5"+GenerateRandomDigits(7)},
                    {"AppNoTwo", null},
                    {"AppNoThree", null},
                    {"AppNoFour", null}
                };
            }
            return jsonInputsValues;
        }
        #endregion

        #region Utils
        public string GenerateRandomDigits(int length)
        {
            Random random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
        public string GenerateRandomString(int stringLength)
        {
            Random random = new Random();
            const string allowedChars = "abcdefghijkmnopqrstuvwxyz";
            char[] chars = new char[stringLength];
            WaitForMoment(2);

            for (int i = 0; i < stringLength; i++)
                chars[i] = allowedChars[random.Next(0, allowedChars.Length)];

            return new string(chars);
        }
        public string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public string RemoveSpecialChars(string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
        }
        public bool isStringHasSpecialChars(string str)
        {
            Regex rgx = new Regex("[^A-Za-z0-9._-]");
            bool hasSpecialChars = rgx.IsMatch(str.ToString());
            return hasSpecialChars;
        }
        #endregion

    }



    class LoaAgencyTableInfo
    {
        public string AgencyName { get; set; }
        public string ApplicationType { get; set; }
        public string ApplicationNumber { get; set; }
        public string ApplicationOtherName { get; set; }
    }
    class LoaItemTableInfo
    {
        public string WestItemNo { get; set; }
        public string Description { get; set; }
        public string ItemStatus { get; set; }
        public string ControlledDrawing { get; set; }
        public string ControlledDrawingNo { get; set; }
        public string Submitted { get; set; }
        public string Emailed { get; set; }
    }
    class LoaProductTableInfo
    {
        public string WestItemNo { get; set; }
        public string Formulation { get; set; }
        public string Configuration { get; set; }
        public string IsDaikyo { get; set; }
    }
}
