using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CasesAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CasesPage _pageInstance;
        private readonly OpportunityAction _opportunityAction;

        public CasesAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CasesPage(_session);
            _opportunityAction = new OpportunityAction(_session);
        }

        public void ClickOnCreateCase()
        {
            ClickElement(_pageInstance.CreateCase);
            LogInfo("Clicked on Create Case");
            WaitForLoadingToDisappear();
            Assert.AreEqual("New", GetAttribute(_pageInstance.Status, "Value.Value"));
            LogInfo("Verified Lead Status - " + GetAttribute(_pageInstance.Status, "Value.Value"));
        }

        public void EnterTitle(String title)
        {
            ClickElement(_pageInstance.Title);
            ClearElement(_pageInstance.Title);
            EnterText(_pageInstance.Title, title);
            LogInfo("Entered Title");
        }

        public void SelectAccount(String account)
        {
            ClickElement(_pageInstance.AccountArrow);
            WaitForMoment(2);
            //ClickElement(_pageInstance.AccountSearchBox);
            //ClearElement(_pageInstance.AccountSearchBox);
            //EnterText(_pageInstance.AccountSearchBox, account);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Account Selected");
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Account Name - " + GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
        }

        public void ClickCreateAccount()
        {
            ClickElement(_pageInstance.AccountArrow);
            ClickElement(_pageInstance.OptionsValue("Create CRM Account"));
            LogInfo("Clicked on Create Account");
            WaitForLoadingToDisappear();
        }

        public void SelectContact(String contact)
        {
            ClickElement(_pageInstance.ContactArrow);
            WaitForLoadingToDisappear();
            WaitForMoment(3);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Contact Selected");
        }

        public void ClickContactGP()
        {
            ClickElement(_pageInstance.ContactArrow);
            LogInfo("Clicked on contact GP");
            WaitForLoadingToDisappear();
            WaitForMoment(3);
        }

        public void SelectContactInPicker()
        {
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Contact Selected");
        }

        public void CreateContact()
        {
            ClickElement(_pageInstance.OptionsValue("Create Contact"));
            LogInfo("Clicked On Create Contact");
        }

        public void ClickCreateContact()
        {
            ClickElement(_pageInstance.ContactArrow);
            LogInfo("Clicked On Participants From Customer Generic Picker");
            ClickElement(_pageInstance.OptionsValue("Create Contact"));
            LogInfo("Clicked On Create Contact");
        }

        public void ClickLowPriority()
        {
            ClickElement(_pageInstance.LowPriority);
            LogInfo("Clicked on Low Priority");
        }

        public void ClickNormalPriority()
        {
            ClickElement(_pageInstance.NormalPriority);
            LogInfo("Clicked on Normal Priority");
        }

        public void ClickHighPriority()
        {
            ClickElement(_pageInstance.HighPriority);
            LogInfo("Clicked on High Priority");
        }

        public void SelectOrigin(String originValue)
        {
            ClickElement(_pageInstance.Origin);
            ClickElement(_pageInstance.OptionsValue(originValue));
            LogInfo("Selected Origin");
        }

        public void SelectProductOrigin(String productOriginValue)
        {
            ClickElement(_pageInstance.ProductOrigin);
            ClickElement(_pageInstance.OptionsValue(productOriginValue));
            ClickElement(_pageInstance.ProductOriginOk);
            LogInfo("Selected Product Origin");
        }

        public void SelectCaseInvolvment(String caseInvolvmentValue)
        {
            ClickElement(_pageInstance.CaseInvolvment);
            ClickElement(_pageInstance.OptionsValue(caseInvolvmentValue));
            LogInfo("Selected Case Involvement");
        }

        public void ChangeCaseOwner(String caseOwner)
        {
            ClickElement(_pageInstance.CaseOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.CaseOwnerArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, caseOwner);
            ClickElement(_pageInstance.OptionsValue(caseOwner));
            Assert.AreEqual(caseOwner, GetAttribute(_pageInstance.CaseOwnerNameField, "Value.Value"));
            LogInfo("Verified Case Owner  - " + caseOwner);
            LogInfo("Case Owner Changed to " + caseOwner);
        }

        public void SelectBussinessType(String bussinessType)
        {
            ClickElement(_pageInstance.BussinessType);
            ClickElement(_pageInstance.OptionsValue(bussinessType));
            LogInfo("Selected Bussiness Type");
        }

        public void SelectBussinessSubType(String bussinessSubType)
        {
            ClickElement(_pageInstance.BussinessSubType);
            ClickElement(_pageInstance.OptionsValue(bussinessSubType));
            LogInfo("Selected Bussiness Sub Type");
        }

        public void SelectProduct()
        {
            ClickElement(_pageInstance.ProductArrow);
            LogInfo("Clicked on Product Generic Picker");
            WaitForLoadingToDisappear();
            WaitForMoment(3);
            _opportunityAction.ClickCheckBox(0);
            LogInfo("Selected First Product");
            _opportunityAction.ClickCheckBox(1);
            LogInfo("Selected Second Product");
            ClickElement(_pageInstance.Submit);
            LogInfo("Clicked on Submit");
        }

        public void SelectWestInitiative(String westInitiativeValue)
        {
            ClickElement(_pageInstance.WestInitiative);
            ClickElement(_pageInstance.OptionsValue(westInitiativeValue));
            LogInfo("Selected WestInitiative");
        }

        public void SelectWestCampaign(String westCampaignValue)
        {
            ClickElement(_pageInstance.WestCampaign);
            ClickElement(_pageInstance.OptionsValue(westCampaignValue));
            LogInfo("Selected WestCampaign");
        }


        public void EnterDescriptionOrAdditionalInformation(String comments)
        {
            ClickElement(_pageInstance.DescriptionOrAdditionalInformation);
            ClearElement(_pageInstance.DescriptionOrAdditionalInformation);
            EnterText(_pageInstance.DescriptionOrAdditionalInformation, comments);
            LogInfo("Entered Description Or Additional Information");
        }

        public void ClickSubmit()
        {
            ClickElement(_pageInstance.Submit);
            LogInfo("Clicked on Submit Button");
            WaitForLoadingToDisappear();
        }
        public void ClickAddCaseType()
        {
            ClickElement(_pageInstance.AddCaseType);
            try
            {
                if (Exists(_pageInstance.AddCaseType))
                {
                    ClickElement(_pageInstance.AddCaseType);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on Add Case in first chance");
            }
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Add Case");
        }


        public void AddCase()
        {
            ClickAddCaseType();
            _opportunityAction.ClickCheckBox(0);
            ClickElement(_pageInstance.Submit);
            WaitForMoment(3);
            ClickAddCaseType();
            _opportunityAction.ClickCheckBox(1);
            ClickElement(_pageInstance.Submit);
            LogInfo("Added Case Type");
        }

        public void AddMultipleCase(int caseCount)
        {
            ClickAddCaseType();
            for (int i = 0; i <= caseCount; i++)
            {
                _opportunityAction.ClickCheckBox(i);
            }
            ClickElement(_pageInstance.Submit);
        }

        public List<string> caseTypeDetails()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> caseTypeDetails = _pageInstance.CaseClassificationDetails();
            if (caseTypeDetails.Equals(null))
            {
                caseTypeDetails = _pageInstance.CaseClassificationDetails();
            }
            for (int i = 0; i < caseTypeDetails.Count; i++)
            {
                values.Add(caseTypeDetails[i].Text);
            }
            LogInfo("Stored All Data");

            return values;

        }

        public string CCData(String value)
        {
            string cc = _pageInstance.CaseClassificationData(value).Text;
            return cc;
        }

        public string CCDataInChildInbox(String value)
        {
            String cc=_pageInstance.CaseClassificationChildInboxData(value).Text;
            return cc;
        }

        public void ClickSaveAndClose()
        {
            ClickElement(_pageInstance.SaveAndCloseButton);
            try
            {
                if (Exists(_pageInstance.SaveAndCloseButton))
                {
                    ClickElement(_pageInstance.SaveAndCloseButton);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on Save & Close button in first chance");
            }
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Save & Close Button");
        }

        public void ClickResolveCaseButton()
        {
            ClickElement(_pageInstance.ResolveCaseButton);
            try
            {
                if (Exists(_pageInstance.ResolveCaseButton))
                {
                    ClickElement(_pageInstance.ResolveCaseButton);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on Resolve Case in first chance");
            }
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Resolve Case");
        }

        public void VerifyResolveCaseButtonExist()
        {
            Assert.IsTrue(Exists(_pageInstance.ResolveCaseButton));
            LogInfo("Verified Resolve Case button is displayed");
        }

        public void ClickResolveCase()
        {
            ClickElement(_pageInstance.ResolveCase);
            LogInfo("Clicked on Resolve Case");
            WaitForLoadingToDisappear();
        }

        public void ClickCreateCaseInDA()
        {
            ClickElement(_pageInstance.OptionsValue("Create Case"));
            LogInfo("Clicked on Create Case in Contact Detailed Action");
            WaitForLoadingToDisappear();
        }

        public void ClickViewCase()
        {
            ClickElement(_pageInstance.OptionsValue("View Case"));
            LogInfo("Clicked on View Case");
            WaitForLoadingToDisappear();
        }

        public void ResolvedOn(String date)
        {
            ClickElement(_pageInstance.ResolvedOn);
            ClickElement(_pageInstance.CalanderNext);
            LogInfo("Clicked on Calander Next Button");
            ClickElement(_pageInstance.OptionsValue(date));
            LogInfo("Clicked Resolved on Date as " + date);
        }

        public void EnterTotalTime(String time)
        {
            ClickElement(_pageInstance.TotalTime);
            ClearElement(_pageInstance.TotalTime);
            EnterText(_pageInstance.TotalTime, time);
            LogInfo("Entered Total Time");
        }

        public void TimeUnit(String timeUnit)
        {
            ClickElement(_pageInstance.TimeUnit);
            ClickElement(_pageInstance.OptionsValue(timeUnit));
            LogInfo("Selected Total Unit");
        }

        public void VerifyTotalTime(String totalTime)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.TotalTime, "Value.Value"), totalTime);
            LogInfo("Verified Total Time");
        }

        public void EnterResolutionRemarks(String resolutionRemarks)
        {
            ClickElement(_pageInstance.ResolutionRemarks);
            ClearElement(_pageInstance.ResolutionRemarks);
            EnterText(_pageInstance.ResolutionRemarks, resolutionRemarks);
            LogInfo("Entered Resolution Remarks");
        }

        public void ClickResolve()
        {
            ClickElement(_pageInstance.Resolve);
            LogInfo("Clicked Resolved Button");
            WaitForLoadingToDisappear();
        }

        public void ResolveCase(String date, String time, String timeUnit, String resolutionRemarks)
        {
            ResolvedOn(date);
            EnterTotalTime(time);
            TimeUnit(timeUnit);
            EnterResolutionRemarks(resolutionRemarks);
            ClickElement(_pageInstance.Resolve);
            LogInfo("Clicked Resolved Button");
        }

        public void ClickReopenCase()
        {
            ClickElement(_pageInstance.ReopenCase);
            LogInfo("Clicked on reopen Case");
            WaitForMoment(2);
            ClickElement(_pageInstance.ConfirmationYes);
            LogInfo("Clicked on Reopen The Case Confirmation as Yes ");
            WaitForLoadingToDisappear();
        }

        public void ClickCancelCase()
        {
            ClickElement(_pageInstance.CancelCase);
            LogInfo("Clicked on Cancel Case");
            WaitForMoment(2);
            ClickElement(_pageInstance.ConfirmationYes);
            LogInfo("Clicked on Cancel The Case Confirmation as Yes ");
            WaitForLoadingToDisappear();
        }

        public void ClickEditCase()
        {
            ClickElement(_pageInstance.EditCase);
            LogInfo("Clicked on Edit Case");
            WaitForLoadingToDisappear();
            WaitForLoadingToDisappear();
        }

        public void ValidateCreatedCaseInInboxGrid(String title, String priority, String caseOrigin, String caseOwner, String caseInvolvement, String bussinessType, String bussinessSubType, String status)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> rowValues = GetFirstRowValues();
            Assert.AreEqual(title, rowValues[1]);
            Assert.AreEqual(priority, rowValues[2]);
            Assert.AreEqual(caseOrigin, rowValues[3]);
            Assert.AreEqual(status, rowValues[4]);
            try
            {
                Assert.AreEqual(caseOwner, _opportunityAction.GetCellValueInInbox("R1C6"));
                _opportunityAction.ScrollHorizontally(1);
                Assert.AreEqual(caseInvolvement, _opportunityAction.GetCellValueInInbox("R1C8"));
                LogInfo("Verified Created Case is Displayed in the Inbox ");
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify Case Involvement, but created contact is displayed in the inbox");
            }
        }

        public void ValidateCaseData(String title, String origin, String productOrigin, String caseInvolvement, String caseOwner, String bussinessType, String bussinessSubType, String westInitiative, String westCampaign, String additionalInformation, String status)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.Title, "Value.Value"), title);
            LogInfo("Verified Title");
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Account Name");
            Assert.IsTrue(GetAttribute(_pageInstance.ContactNameField, "Value.Value") != null);
            LogInfo("Verified Contact Name");
            Assert.AreEqual(GetAttribute(_pageInstance.OriginNameField, "Name"), origin);
            LogInfo("Verified Origin");
            Assert.AreEqual(GetAttribute(_pageInstance.ProductOriginNameField, "Name"), productOrigin);
            LogInfo("Verified Product Origin");
            Assert.AreEqual(GetAttribute(_pageInstance.CaseInvolvmentNameField, "Name"), caseInvolvement);
            LogInfo("Verified Case Involvement");
            Assert.AreEqual(GetAttribute(_pageInstance.CaseOwnerNameField, "Value.Value"), caseOwner);
            LogInfo("Verified Case Owner");
            Assert.AreEqual(GetAttribute(_pageInstance.StatusPicker, "Name"), status);
            LogInfo("Verified Status");
            Assert.AreEqual(GetAttribute(_pageInstance.BussinessTypeNameField, "Name"), bussinessType);
            LogInfo("Verified Bussiness Type");
            Assert.AreEqual(GetAttribute(_pageInstance.BussinessSubTypeNameField, "Name"), bussinessSubType);
            LogInfo("Verified Bussiness Sub Type");
            Assert.IsTrue(GetAttribute(_pageInstance.ProductNameField, "Value.Value") != null);
            LogInfo("Verified Product");
            Assert.AreEqual(GetAttribute(_pageInstance.WestInitiativeNameField, "Name"), westInitiative);
            LogInfo("Verified West Initiative");
            Assert.AreEqual(GetAttribute(_pageInstance.WestCampaignNameField, "Name"), westCampaign);
            LogInfo("Verified West Campaign");
        }

        public void VerifyAccountAndContactIsAutoPopulated()
        {
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Account Name");
            Assert.IsTrue(GetAttribute(_pageInstance.ContactNameField, "Value.Value") != null);
            LogInfo("Verified Contact Name");
        }

        public void VerifyCaseClassification()
        {
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R1C0")));
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R1C1")));
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R1C2")));
            LogInfo("Verified Row 1 Exist");
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R1C0")));
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R2C1")));
            Assert.IsTrue(Exists(_pageInstance.CaseClassificationData("R2C2")));
            LogInfo("Verified Row 2 Exist");
        }

        public void VerifyAdditionalInformation(String additionalInformation)
        {
            Assert.AreEqual(GetAttribute(_pageInstance.DescriptionOrAdditionalInformation, "Value.Value"), additionalInformation);
            LogInfo("Verified Additional Information");
        }

        public void VerifyResolveCaseDialogueMesssage(String productOrigin)
        {
            Assert.AreEqual(_pageInstance.DialogTitle.Text, "Daikyo case tracking reminder!");
            Assert.AreEqual(_pageInstance.DialogMessage.Text, "You have selected "+productOrigin+" as product origin. Please add the case description to it.");
            Assert.AreEqual(_pageInstance.ResolveCaseOkButton.Text, "Add Description");
            Assert.AreEqual(_pageInstance.ResolveCaseCancelButton.Text, "Cancel");
            LogInfo("Verified Resolve Case Popup Message");
        }

        public void VerifyResolveCaseDialogueMesssageInCasePage(String productOrigin)
        {
            Assert.AreEqual(_pageInstance.DialogTitle.Text, "Daikyo case tracking reminder!");
            Assert.AreEqual(_pageInstance.DialogMessage.Text, "You have selected " + productOrigin + " as product origin.Please add the case description to it.");
            Assert.AreEqual(_pageInstance.ResolveCaseOkButton.Text, "OK");
            LogInfo("Verified Resolve Case Popup Message In Case Page");
        }

        public void ClickOnAddDescription()
        {
            ClickElement(_pageInstance.ResolveCaseOkButton);
            LogInfo("Clicked On Add Description");
            WaitForLoadingToDisappear();
        }

        /// <summary>
        /// To cases
        /// </summary>
        /// <param name="title"></param>
        /// <param name="account"></param>
        /// <param name="contact"></param>
        /// <param name="origin"></param>
        /// <param name="productOrigin"></param>
        /// <param name="caseInvolvement"></param>
        /// <param name="caseOwner"></param>
        /// <param name="bussinesstype"></param>
        /// <param name="bussinessSubType"></param>
        /// <param name="westInitiative"></param>
        /// <param name="westCampaign"></param>
        public void CaseDetails(String title, String account, String contact, String origin, String productOrigin, String caseInvolvement, String caseOwner, String bussinesstype, String bussinessSubType,
            String westInitiative, String westCampaign, String comments)
        {
            EnterTitle(title);
            SelectAccount(account);
            SelectContact(contact);
            ClickLowPriority();
            ClickHighPriority();
            ClickNormalPriority();
            SelectOrigin(origin);
            SelectProductOrigin(productOrigin);
            SelectCaseInvolvment(caseInvolvement);
            ChangeCaseOwner(caseOwner);
            SelectBussinessType(bussinesstype);
            SelectBussinessSubType(bussinessSubType);
            SelectProduct();
            SelectWestInitiative(westInitiative);
            SelectWestCampaign(westCampaign);
            WaitForMoment(2);
        }

        public void EnterCaseDetailsFromContact(String title, String origin, String productOrigin, String caseInvolvement, String caseOwner, String bussinesstype, String bussinessSubType,
            String westInitiative, String westCampaign)
        {
            EnterTitle(title);
            ClickLowPriority();
            ClickHighPriority();
            ClickNormalPriority();
            SelectOrigin(origin);
            SelectProductOrigin(productOrigin);
            SelectCaseInvolvment(caseInvolvement);
            ChangeCaseOwner(caseOwner);
            SelectBussinessType(bussinesstype);
            SelectBussinessSubType(bussinessSubType);
            SelectProduct();
            SelectWestInitiative(westInitiative);
            SelectWestCampaign(westCampaign);
        }

        public void CaseMandatoryDetails(String title, String account, String contact, String origin, String productOrigin, String caseInvolvement)
        {
            EnterTitle(title);
            SelectAccount(account);
            SelectContact(contact);
            ClickLowPriority();
            ClickHighPriority();
            ClickNormalPriority();
            SelectOrigin(origin);
            SelectProductOrigin(productOrigin);
            SelectCaseInvolvment(caseInvolvement);
        }

        public void ResolveCase()
        {
            EnterDataByLabel("Resolved case", "Resolution Remarks");
            ClickElement(_pageInstance.ResolveButton);
            WaitForLoadingToDisappear();
        }

        public void EnterDataByLabel(String firstName, string label)
        {
            WaitForMoment(1);
            ClickClearEnterText(_pageInstance.ElementByLabel(label), firstName);
            LogInfo("Entered " + label);
            WaitForMoment(1);
        }

        public void EnterDescription(String firstName)
        {
            EnterText(_pageInstance.Description, firstName);
            LogInfo("Entered description");
            WaitForMoment(1);
        }

        public void SelectFromDropDown(string entryText, String label)
        {
            EnterText(_pageInstance.SelectElementByLabel(label), entryText);
            LogInfo("Entered " + label);
            try
            {
                if (Exists(_pageInstance.OKButton[0]))
                {
                    ClickElement(_pageInstance.OKButton[0]);
                }
            }
            catch (Exception)
            {
                LogInfo("Ok popup is not displayed");
            }
        }

        public void SearchSelectFromDropdown(string label)
        {
            ClickCaseView();
            ClickElement(_pageInstance.ImageByLabel(label));
            WaitForMoment(2);
            ClickElement(_pageInstance.SearchInPopUpList);
            WaitForMoment(2);
            LogInfo("Selected from dropdown " + label);
        }

        public void ClickSubmitButton()
        {
            ClickElement(_pageInstance.SubmitButton);
            LogInfo("Clicked on Submit button");
        }

        public void ClickCaseClassification()
        {
            ClickElement(_pageInstance.CaseClassification);
            ClickElement(_pageInstance.CaseClassification);
            LogInfo("Clicked on Case classification");
        }
        public void ClickCaseView()
        {
            ClickElement(_pageInstance.CaseView);
            LogInfo("Clicked on Case view");
        }
        public void AddCaseSubType()
        {
            WaitForMoment(2);
            ClickElement(_pageInstance.CaseSubType[0]);
            WaitForMoment(2);
            ClickElement(_pageInstance.SearchInPopUpList);
            LogInfo("Added case subtype");
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.CreateButton);
            try
            {
                if (Exists(_pageInstance.CreateButton))
                {
                    ClickElement(_pageInstance.CreateButton);
                }
            }
            catch (Exception)
            {
                LogInfo("Clicked on create 2nd time button");
            }
            LogInfo("Clicked on create button");
        }


        public void SelectRadioButton(string buttonName)
        {
            ClickElement(_pageInstance.Radiobutton(buttonName));
            ClickElement(_pageInstance.Radiobutton(buttonName));
            LogInfo("Selected radio button " + buttonName);
        }

        public void SelectByArrow(string label)
        {
            SelectFirstValueInDropDown(_pageInstance.ElementByLabel(label), label);
            LogInfo("Selected" + label);
        }

        public void VerifyMandatoryFieldsMessage()
        {
            ClickSubmit();
            LogInfo("Clicked on Submit Button");
            _opportunityAction.VerifyMandatoryFieldsCount(6);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Title");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Account");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Contact");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Origin");
            _opportunityAction.VerifyMandatoryFieldsMessage(4, "Product Origin");
            _opportunityAction.VerifyMandatoryFieldsMessage(5, "Case Involvement");
        }

        public void VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue()
        {

            ClickSubmit();
            LogInfo("Clicked on Submit Button");
            _opportunityAction.VerifyMandatoryFieldsCount(4);
            _opportunityAction.VerifyMandatoryFieldsMessage(0, "Contact");
            _opportunityAction.VerifyMandatoryFieldsMessage(1, "Origin");
            _opportunityAction.VerifyMandatoryFieldsMessage(2, "Product Origin");
            _opportunityAction.VerifyMandatoryFieldsMessage(3, "Case Involvement");
        }

        public void ClickOnALLTab()
        {
            ClickElement(_pageInstance.AllTab);
            LogInfo("Clicked on PRQ tab");
            WaitForLoadingToDisappear();
        }
        public void ClickOnOpenCasesTab()
        {
            ClickElement(_pageInstance.LabelActivityTab("Open Cases"));
            LogInfo("Clicked on Open cases tab");
            WaitForLoadingToDisappear();
        }

        public void ClickOnTabByName(String name)
        {
            ClickElement(_pageInstance.LabelActivityTab(name));
            LogInfo("Clicked on Open cases tab");
            WaitForLoadingToDisappear();
        }
        public int NumberOfRecordsInLabel(string labelText)
        {
            String textOfLabel = GetAttribute(_pageInstance.LabelActivityTab(labelText), "Name");
            String countstring = textOfLabel.Substring(textOfLabel.IndexOf('(') + 1).Replace(")", "");
            return Int32.Parse(countstring);
        }
        public string GetTextOfTextbox(string label)
        {
            String selectedValue = string.Empty;

            selectedValue = GetAttribute(_pageInstance.ElementByLabel(label), "Value.Value");
            LogInfo("Selected link");
            return selectedValue;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caseInvolment"></param>
        /// <param name="title"></param>
        /// <param name="productOrigin"></param>
        /// <param name="origin"></param>
        /// <param name="priority"></param>
        /// <param name="description"></param>
        public string[] EnterPersonalInformation(string caseInvolment = "TCS Answered", string title = "Title",
            string productOrigin = "West", string origin = "Phone", string priority = "High",
            string description = "Description")
        {
            String[] selectedValues = new String[2];
            SelectFromDropDown(caseInvolment, "Case Involvment");
            EnterDataByLabel(title, "Title");
            SearchSelectFromDropdown("Account");
            SearchSelectFromDropdown("Contact");
            SelectFromDropDown(productOrigin, "Product Origin");
            SelectFromDropDown(origin, "Origin");
            SearchSelectFromDropdown("Product");
            ClickSubmitButton();
            SelectRadioButton(priority);
            SelectByArrow("West Program Name");
            WaitForMoment(2);
            EnterDescription(description);
            selectedValues[0] = GetTextOfTextbox("Case Number");
            selectedValues[1] = GetTextOfTextbox("Account");
            return selectedValues;

        }

        public void AddCaseClassification()
        {
            ClickCaseClassification();
            if (_pageInstance.CaseSubType.Count > 0)
            {
                AddCaseSubType();
                ClickSubmitButton();
            }

        }

        public void ValidateCreatedPRQInInboxGrid(String caseNumber, String title, String accountName, string status, string priority)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(caseNumber, firstRowValues[0]);
            Assert.AreEqual(title, firstRowValues[1]);
            Assert.AreEqual(accountName.Replace(",", ""), firstRowValues[2]);
            Assert.AreEqual(status, firstRowValues[3]);
            Assert.AreEqual(priority, firstRowValues[4]);
            LogInfo("Verified Cases in inbox");
        }

        public void ValidateCaseInUpdatePage(List<String> firstRowValue)
        {
            Assert.AreEqual(firstRowValue[0], GetAttribute(_pageInstance.ElementByLabel("Case Number"), "Value.Value"));
            Assert.AreEqual(firstRowValue[1], GetAttribute(_pageInstance.ElementByLabel("Title"), "Value.Value"));
            Assert.AreEqual(firstRowValue[2], GetAttribute(_pageInstance.ElementByLabel("Account"), "Value.Value"));
        }

        public void ValidateTwoRowValues(List<String> FirstCase, List<String> SecondCase, String status)
        {
            Assert.AreEqual(FirstCase[0], SecondCase[0]);
            Assert.AreEqual(FirstCase[1], SecondCase[1]);
            Assert.AreEqual(FirstCase[2], SecondCase[2]);
            Assert.AreEqual(status, SecondCase[3]);
            Assert.AreEqual(FirstCase[4], SecondCase[4]);
            if (SecondCase.Count > 7)
            {
                Assert.AreEqual("TEST UX1", SecondCase[6]);
            }
        }

        public void VerifyAccountNameField(String accountName)
        {
            Assert.AreEqual(accountName, GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
            LogInfo("Verified Account name is auto populated ");
        }

        public void ValidateCaseNumberNotExist(List<String> FirstCase, List<String> SecondCase)
        {
            Assert.AreNotEqual(FirstCase[0], SecondCase[0]);
        }

        public void ValidateCount(int intitialCount, int endCount, int incresedOrDecreased)
        {
            Assert.AreEqual(intitialCount + incresedOrDecreased, endCount);
        }

        public int RowNumberOfCase(String caseNumber)
        {
            int value = -1;
            IList<WindowsElement> DetailActions = _pageInstance.AllRow;
            if (DetailActions.Count > 0)
            {
                for (int i = 0; i < DetailActions.Count; i++)
                {
                    string nameContact = GetAttribute(_pageInstance.RowWiseCaseName(i + 1), "Name");
                    if (nameContact.Equals(caseNumber))
                    {
                        value = i + 1;
                        break;
                    }
                }
                LogInfo("Detail action for the 1st inbox record is clicked");
                WaitForMoment(2);
            }
            else
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");

            }
            return value;
        }

    }
}
