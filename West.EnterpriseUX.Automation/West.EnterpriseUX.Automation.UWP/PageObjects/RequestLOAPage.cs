using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    class RequestLOAPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public RequestLOAPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement DetailActionOptionButton(string detailActionOptionText)
        {
            //WindowsElement abc = FindElement($"XPath://*[@AutomationId='TextBlock' and contains(@Name, '{detailActionOptionText}')]");
            return FindElement($"XPath://*[@AutomationId='TextBlock' and @Name='{detailActionOptionText}']");
        }
        public WindowsElement DropDownBox => FindElement("XPath://*[@AutomationId='SelectedStatusPicker' and @ClassName='ComboBox']");
        public WindowsElement DropDownBoxListItem(string dropDownItemName)
        {
            return FindElement($"XPath://*[@Name='{dropDownItemName}']");
        }
        public WindowsElement LOAIDTextBox => FindElement("XPath://*[@AutomationId='LoaIdEntry']");
        public WindowsElement TabNameFromInboxHomePage(string tabName)
        {
            return FindElement($"XPath://*[contains(@Name,'{tabName}') and contains(@AutomationId,'dashboardLabel')]");
        }
        public WindowsElement SaveButton => FindElement("XPath://*[@ClassName='Button' and @Name='Save']");
        public WindowsElement AlertWindowOKButton => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement AlertWindowDialogTitle => FindElement("XPath://*[@AutomationId='dialogTitle']");
        public WindowsElement AlertWindowDialogMessage => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement ReviewLOADocumentUpdateButton => FindElement("XPath://*[@AutomationId='LoaDocumentViewPrimaryButton']");
        public WindowsElement TabFromEditRequestLOA(string tabName)
        {
            return FindElement($"XPath://*[@ClassName='TextBlock' and @Name='{tabName}']");
        }
        public WindowsElement DateRequestedTextbox => FindElement("XPath://*[@AutomationId='DatePicker']");
        public WindowsElement DateRequiredTextbox => FindElement("XPath://*[@AutomationId='DateTimeToDateTimeOffsetConverterPicker']");
        public WindowsElement DrugTextbox => FindElement("XPath://*[@AutomationId='DrugEntry']");
        public WindowsElement ContractLabTestTextbox => FindElement("XPath://*[@AutomationId='ContractLabTestEntry']");
        public WindowsElement CustomerInstructionTextbox => FindElement("XPath://*[@AutomationId='CustomerInstructionsEditor']");
        public WindowsElement CommentBox => FindElement("XPath://*[@AutomationId='CommentEditor']");
        public WindowsElement HorizontalIncreaseButton => FindElement("XPath://*[@AutomationId='HorizontalSmallIncrease']");
        public WindowsElement LoaRequestHeaderText => FindElement("XPath://*[@AutomationId='LoaRequestLabel']");
        public WindowsElement LoaContactHeaderText => FindElement("XPath://*[@AutomationId='LoaContactLabel']");
        public WindowsElement LoaAgencyHeaderText => FindElement("XPath://*[@AutomationId='LoaAgencyLabel']");
        public WindowsElement LoaItemsHeaderText => FindElement("XPath://*[@AutomationId='Title1Label']");
        public WindowsElement LoaProductsHeaderText => FindElement("XPath://*[@AutomationId='Title2Label']");
        public WindowsElement EmptyDataScreenText => FindElement("XPath://*[@AutomationId='EmptyLabel']");
        public WindowsElement EmptyDataScreenImage => FindElement("XPath://*[@AutomationId='EmptyImage']");
        public WindowsElement FirstRowDetailAction => FindElement("XPath://*[@Name=' Row1']//Image[@AutomationId='More']");
        public WindowsElement IsDykoEmailSentNew => FindElement($"XPath://*[contains(@AutomationId,'R1C11') and contains(@ClassName,'NamedContainerAutomationPeer')]");
        public WindowsElement IsDykoEmailSentInProgress => FindElement($"XPath://*[contains(@AutomationId,'R1C13') and contains(@ClassName,'NamedContainerAutomationPeer')]");
        public WindowsElement IsDykoEmailSentOutForApproval => FindElement($"XPath://*[contains(@AutomationId,'R1C13') and contains(@ClassName,'NamedContainerAutomationPeer')]");
        public WindowsElement IsDykoEmailSentComplete => FindElement($"XPath://*[contains(@AutomationId,'R1C10') and contains(@ClassName,'NamedContainerAutomationPeer')]");

        //Product 
        public WindowsElement NewProductCreationButton => FindElement("XPath://*[@ClassName='TextBlock' and @Name='New Product Creation']");
        public WindowsElement NewProductCreationPageTitleLabel => FindElement("XPath://*[@AutomationId='PageTitleLabel']");
        public WindowsElement TitleTextbox => FindElement("XPath://*[@AutomationId='NewProductTitleEntry']");
        public WindowsElement FormulationDropDownBox => FindElement("XPath://*[@AutomationId='NewProductFormulationListComboBox Input Field']");
        public WindowsElement CoatingDropDownBox => FindElement("XPath://*[@AutomationId='NewProductCreationCoatingListComboBox Input Field']");
        public WindowsElement SterilePlantDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSterilePlantComboBox Input Field']");
        public WindowsElement ConfigurationTypeDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSelectedConfigurationTypeComboBox Input Field']");
        public WindowsElement ConfigBerFamilyDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSelectedConfigBerFamilyComboBox Input Field']");
        public WindowsElement IndexTextbox => FindElement("XPath://*[@AutomationId='NewProductIndexEntry']");
        public WindowsElement HcCoatingDmfDropDownBox => FindElement("XPath://*[@AutomationId='NewProductHcCoatingDmfPicker']");
        public WindowsElement ChinaDossierNumberDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSelectedChinaDossierComboBox Input Field']");
        public WindowsElement ChinaProcesingTypeTextbox => FindElement("XPath://*[@AutomationId='NewProductChinaProcessingTypeEntry']");
        public WindowsElement WestItemNumberTextbox => FindElement("XPath://*[@AutomationId='NewProductWestItemNoEntry']");
        public WindowsElement FormulationTypeDropDownBox => FindElement("XPath://*[@AutomationId='NewProductFormulationTypeListCombeBox Input Field']");
        public WindowsElement WashPlantDropDownBox => FindElement("XPath://*[@AutomationId='NewProductWashPlantComboBox Input Field']");
        public WindowsElement ConfigurationDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSelectedConfigurationComboBox Input Field']");
        public WindowsElement PackingOptionDropDownBox => FindElement("XPath://*[@AutomationId='NewProductSelectedPackOptionComboBox Input Field']");
        public WindowsElement SpecificationTextbox => FindElement("XPath://*[@AutomationId='NewProductSpecificationEntry']");
        public WindowsElement TemplatesDropDownBox => FindElement("XPath://*[@AutomationId='NewProductLoaTemplateListComboBox Input Field']");
        public WindowsElement HcFormulaDmfDropDownBox => FindElement("XPath://*[@AutomationId='NewProductHcFormulaDmfPicker']");
        public WindowsElement StatusDropDownBox => FindElement("XPath://*[@AutomationId='NewProductStatusPicker']");
        public WindowsElement NewProductSaveButton => FindElement("XPath://*[@AutomationId='NewProductCreationPrimaryButton']");
        public IList<WindowsElement> ProductInboxMultipanelDropdowns => FindElements($"XPath://*[contains(@AutomationId,'NewProduct') and contains(@AutomationId,'ComboBox Input Clear Button')]");
        
        //Edit Documents Metadata
        public WindowsElement LoaDocumentHeaderTextLabel => FindElement("XPath://*[@AutomationId='loaDocumentsTextLabel']");
        public WindowsElement LoaDocumentNameTextbox => FindElement("XPath://*[@AutomationId='LoaDocumentNameEntry']");
        public WindowsElement LoaTemplateTextbox => FindElement("XPath://*[@AutomationId='LoaTemplateEntry']");
        public WindowsElement AgencyEntryTextbox => FindElement("XPath://*[@AutomationId='AgencyPickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement LoaIdEntryTextbox => FindElement("XPath://*[@AutomationId='LOAIDEntry']");
        public WindowsElement WestItemNoTextbox => FindElement("XPath://*[@AutomationId='WestItemNoEntry']");
        public WindowsElement DrugEntryTextbox => FindElement("XPath://*[@AutomationId='DrugEntry']");
        public WindowsElement CompanyNameEntryTextbox => FindElement("XPath://*[@AutomationId='CompanyNameEntry']");
        public WindowsElement CoatingsTextbox => FindElement("XPath://*[@AutomationId='CoatingsPickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement FormulationEntryTextbox => FindElement("XPath://*[@AutomationId='FormulationEntry']");
        public WindowsElement CityEntryTextbox => FindElement("XPath://*[@AutomationId='CityEntry']");
        public WindowsElement StateEntryTextbox => FindElement("XPath://*[@AutomationId='StateEntry']");
        public WindowsElement PostalCodeEntryTextbox => FindElement("XPath://*[@AutomationId='PostalCodeEntry']");
        public WindowsElement DMFNumberTextbox => FindElement("XPath://*[@AutomationId='DMFNumberPickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement ApplicationTypeTextbox => FindElement("XPath://*[@AutomationId='ApplicationTypePickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement CountryEntryTextbox => FindElement("XPath://*[@AutomationId='CountryEntry']");
        public WindowsElement AddressEntryTextbox => FindElement("XPath://*[@AutomationId='AddressEntry']");
        public WindowsElement Address2EntryTextbox => FindElement("XPath://*[@AutomationId='Address2Entry']");
        public WindowsElement Address3EntryTextbox => FindElement("XPath://*[@AutomationId='Address3Entry']");
        public WindowsElement FirstNameEntryTextbox => FindElement("XPath://*[@AutomationId='FirstNameEntry']");
        public WindowsElement LastNameEntryTextbox => FindElement("XPath://*[@AutomationId='LastNameEntry']");
        public WindowsElement ContactsTitleEntryTextbox => FindElement("XPath://*[@AutomationId='ContactsTitleEntry']");
        public WindowsElement RequestorFirstNameEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorFirstNameEntry']");
        public WindowsElement RequestorLastNameEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorLastNameEntry']");
        public WindowsElement RequestorContactsTitleEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorContactsTitleEntry']");
        public WindowsElement RequestorAddress1EntryTextbox => FindElement("XPath://*[@AutomationId='RequestorAddress1Entry']");
        public WindowsElement RequestorAddress2EntryTextbox => FindElement("XPath://*[@AutomationId='RequestAddress2Entry']");
        public WindowsElement RequestorAddress3EntryTextbox => FindElement("XPath://*[@AutomationId='RequestAddress3Entry']");
        public WindowsElement RequestorCityEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorCityEntry']");
        public WindowsElement RequestorStateEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorStateEntry']");
        public WindowsElement RequestorPostalCodeEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorPostalCodeEntry']");
        public WindowsElement RequestorCountryEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorCountryEntry']");
        public WindowsElement RequestorCompanyEntryTextbox => FindElement("XPath://*[@AutomationId='RequestorCompanyEntry']");
        public WindowsElement WestLoaIdEntryTextbox => FindElement("XPath://*[@AutomationId='WestLoaIdEntry']");
        public WindowsElement FileNameDatePickerControlTextbox => FindElement("XPath://*[@AutomationId='FileNameDatePickerControl']");
        public WindowsElement DocumentAuthorEntryTextbox => FindElement("XPath://*[@AutomationId='DocumentAuthorEntry']");
        public WindowsElement WashPlantTextbox => FindElement("XPath://*[@AutomationId='WashPlantPickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement SterilePlantTextbox => FindElement("XPath://*[@AutomationId='SterilePlantPickerControl_Container']//*[@ClassName='TextBox']");
        public WindowsElement CompanyAddressEntryTextbox => FindElement("XPath://*[@AutomationId='CompanyAddressEntry']");
        public WindowsElement ItemDescriptionEntryTextbox => FindElement("XPath://*[@AutomationId='ItemDescriptionEntry']");
        public WindowsElement ReferenceInformationEntryTextbox => FindElement("XPath://*[@AutomationId='ReferenceInformationEntry']");
        public WindowsElement ConfigurationTypeEntryTextbox => FindElement("XPath://*[@AutomationId='ConfigurationTypeEntry']");
        public WindowsElement LoaReferenceInformationEntryTextbox => FindElement("XPath://*[@AutomationId='LoaReferenceInformationEntry ']");
        public WindowsElement ReviewLOADocumentTextRegion => FindElement("XPath://*[@AutomationId='defaultRTE_rte-edit-view']");
        public WindowsElement LoaDocumentUpdateButton => FindElement("XPath://*[@AutomationId='LoaDocumentPrimaryButton']");
        public WindowsElement LoaDocumentCancelButton => FindElement("XPath://*[@AutomationId='LoaDocumentSecondaryButton']");
        public WindowsElement LoaPDFImage => FindElement("XPath://*[@ClassName='NamedContainerAutomationPeer']");
        public WindowsElement BackButton => FindElement("XPath://*[@AutomationId='Back']");
        public WindowsElement EmailStatementCheckbox(string checkboxName)
        {
            return FindElement($"XPath://*[@ClassName='CheckBox' and @Name='{checkboxName}']");
        }
        public WindowsElement EmailStatementTextbox => FindElement("XPath://*[@Name='Standard Email Statement']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit");
        public WindowsElement ReviewLOADocMissingProduct => FindElement("XPath://*[@AutomationId='defaultRTE']//*[contains(@Name,'Missing product lookup record in LOA ID')]");
        public IList<WindowsElement> ValuebyRowAndColumnInEditRequestLoaGrid(string rowNumber, string tabName)
        {
            return FindElements($"XPath://*[@AutomationId='{tabName}Grid']//*[@AutomationId=' Row{rowNumber}' or @Name=' Row{rowNumber}']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public IList<WindowsElement> GetRowsInEditRequestLoaGrid(string tabName)
        {
            return FindElements($"XPath://*[@AutomationId='{tabName}Grid']//*[contains(@AutomationId,' Row')]");
        }
        public WindowsElement RecordsDataRows(string rowNumber) 
        {
            return FindElement($"XPath://Group[contains(@AutomationId,' Row{rowNumber}') and contains(@Name,' Row{rowNumber}') and @ClassName='NamedContainerAutomationPeer']");
        }
        public WindowsElement VerticalSmallIncreaseIcon => FindElement("XPath://*[@AutomationId='parentInboxGridView']//*[@AutomationId='VerticalSmallIncrease']");
        public WindowsElement HorizontalSmallIncreaseIcon => FindElement("XPath://*[@AutomationId='HorizontalScrollBar']/*[@AutomationId='HorizontalSmallIncrease']");
        public WindowsElement VerticalScrollBar => FindElement("XPath://*[@AutomationId='parentInboxGridView']//*[@AutomationId='VerticalScrollBar']");
        public IList<WindowsElement> InboxPageTabLabels => FindElements("XPath://*[@AutomationId='parentInboxGridView']//*[@AutomationId='dashboardLabel']");
        public WindowsElement WordDocColumnValue(string rowNumber) 
        { 
            return FindElement($"XPath://*[contains(@AutomationId,'Row{rowNumber}')]//*[contains(@AutomationId,'R{rowNumber}C5')]");
        }
        public WindowsElement WordDocColumnHeader(string columnHeader)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'Row0')]//*[@Name='{columnHeader}']");
        }

        //Agency Inbox
        public WindowsElement NewAgencyCreationButton => FindElement("XPath://*[@Name='New Agency Creation']");
        public WindowsElement AgencyNameEntryTextbox => FindElement("XPath://*[@AutomationId='AgencyNameEntry']");
        public WindowsElement ParentAgencyEntryTextbox => FindElement("XPath://*[@AutomationId='ParentAgencyEntry']");
        public WindowsElement AgencyAbbreviationEntryTextbox => FindElement("XPath://*[@AutomationId='AgencyAbbreviationEntry']");
        public WindowsElement AgencyAddressEntryTextbox => FindElement("XPath://*[@AutomationId='AddressEntry']");
        public WindowsElement NewAgencySaveButton => FindElement("XPath://*[@AutomationId='NewAgencyPrimaryBotton']");
        public WindowsElement NewAgencyCancelButton => FindElement("XPath://*[@AutomationId='NewAgencyCreationCancelButton']");
        public WindowsElement PageTitleAddOrUpdateAgency => FindElement("XPath://*[@AutomationId='PageTitleLabel']");
        
        //Application Type Inbox
        public WindowsElement NewApplicationTypeCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New AppType Creation']");
        public WindowsElement NewApplicationTypeEntryTextbox => FindElement("XPath://*[@AutomationId='ApplicationTypeEntry']");
        public WindowsElement NewApplicationTypeSaveButton => FindElement("XPath://*[@AutomationId='NewApplicationTypeCreationSaveButton']");
        
        //Coating Inbox
        public WindowsElement NewCoatingCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New Coating Form Creation']");
        public WindowsElement NewCoatingEntryTextbox => FindElement("XPath://*[@AutomationId='CoatingNameEntry']");
        public WindowsElement NewCoatingSaveButton => FindElement("XPath://*[@AutomationId='NewCoatingCreationSaveButton']");

        //Coating DMF Inbox 
        public WindowsElement NewCoatingDmfCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New CoatingDmf Creation']");
        public WindowsElement NewCoatingLocationTextbox => FindElement("XPath://*[@AutomationId='LocationEntry']");
        public WindowsElement NewAgencyNameDropdown => FindElement("XPath://*[@AutomationId='SelectedAgencyComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewCoatingNameDropdown => FindElement("XPath://*[@AutomationId='SelectedCoatingComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewCoatingDmfSaveButton => FindElement("XPath://*[@AutomationId='NewCoatingDmfSaveButton']");

        //Configuration Inbox
        public WindowsElement NewConfigurationCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New Configuration Creation']");
        public WindowsElement NewConfigurationEntryTextbox => FindElement("XPath://*[@AutomationId='ConfigurationNameEntry']");
        public WindowsElement NewConfigurationSaveButton => FindElement("XPath://*[@AutomationId='NewConfigurationSaveButton']");

        //Configuration Type Inbox
        public WindowsElement NewConfigurationTypeCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New Configuration Type Creation']");
        public WindowsElement NewConfigurationTypeEntryTextbox => FindElement("XPath://*[@AutomationId='ConfigurationTypeEntry']");
        public WindowsElement NewConfigurationTypeSaveButton => FindElement("XPath://*[@AutomationId='NewConfigurationTypeCreationSaveButton']");

        //DMF Inbox 
        public WindowsElement NewDmfCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New DMF Creation']");
        public WindowsElement AgencyNameDropdown => FindElement("XPath://*[@AutomationId='SelectedAgencyComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewDmfDescriptionEntryTextbox => FindElement("XPath://*[@AutomationId='DmfDescriptionEntry']");
        public WindowsElement NewDmfNumberEntryTextbox => FindElement("XPath://*[@AutomationId='DmfNumberEntry']");
        public WindowsElement NewDmfProcessTypeEntryTextbox => FindElement("XPath://*[@AutomationId='DmfProcessTypeEntry']");
        public WindowsElement NewDmfTitleTextEntryTextbox => FindElement("XPath://*[@AutomationId='DmfTitleTextEntry']");
        public WindowsElement NewDmfTypeEntryTextbox => FindElement("XPath://*[@AutomationId='DmfTypeEntry']");
        public WindowsElement LoaTemplateDropdown => FindElement("XPath://*[@AutomationId='LoaTemplateListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement PlantDropdown => FindElement("XPath://*[@AutomationId='SelectedPlantComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewDisclaimerEditorTextbox => FindElement("XPath://*[@AutomationId='DisclaimerEditor']");
        public WindowsElement NewDmfSaveButton => FindElement("XPath://*[@AutomationId='NewDMFCreationPrimaryButton']");

        //DMF Numbers
        public WindowsElement NewDMFNumberCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New Drug Master File Numbers']");
        public WindowsElement NewDMFNumberEntryTextbox => FindElement("XPath://*[@AutomationId='DMFNumbersEntry']");
        public WindowsElement NewDMFNumberSaveButton => FindElement("XPath://*[@AutomationId='NewDrugMasterFileNumberPrimaryButton']");
        
        //Document Type
        public WindowsElement NewDocumentTypeCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New Document Type Creation']");
        public WindowsElement NewDocumentTypeEntryTextbox => FindElement("XPath://*[@AutomationId='DocumentTypeNameEntry']");
        public WindowsElement NewDocumentTypeSaveButton => FindElement("XPath://*[@AutomationId='NewDocumentTypePrimaryButton']");

        //Drug Classification
        public WindowsElement NewDrugClassificationCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New DrugClassification Creation']");
        public WindowsElement NewDrugClassificationEntryTextbox => FindElement("XPath://*[@AutomationId='DrugClassificationNameEntry']");
        public WindowsElement NewDrugClassificationSaveButton => FindElement("XPath://*[@AutomationId='NewDrugClassificationCreationPrimaryButton']");

        //Formulation Type
        public WindowsElement NewFormulationTypeCreationButton => FindElement("XPath://*[@AutomationId='masterAction_Container']//*[@Name='New FormulationType']");
        public WindowsElement TitleEntryTextbox => FindElement("XPath://*[@AutomationId='TitleEntry']");
        public WindowsElement NewFormulationTypeEntryTextbox => FindElement("XPath://*[@AutomationId='FormulationTypeNameEntry']");
        public WindowsElement NewFormulationTypeSaveButton => FindElement("XPath://*[@AutomationId='NewFormulationTypeCreationPrimaryButton']");

        //Generic Mthod
        public WindowsElement NewInboxItemCreationButton(string newItemCreationButtonName)
        {
            return FindElement($"XPath://*[@AutomationId='masterAction_Container']//*[@Name='{newItemCreationButtonName}']");
        }
        public WindowsElement NewInboxItemEntryTextbox(string inboxItemTextboxAutoId)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'{inboxItemTextboxAutoId}') and contains(@AutomationId,'Entry')]");
        }
        public WindowsElement NewInboxItemSaveButton => FindElement("XPath://*[contains(@AutomationId,'PrimaryButton') or contains(@AutomationId,'SaveButton') or contains(@AutomationId,'PrimaryBotton')]");
        public WindowsElement PageTitleAddOrUpdateInboxItem => FindElement("XPath://*[@AutomationId='PageTitleLabel']");

        // Formulation DMF 
        public WindowsElement FormulationNameDropdown => FindElement("XPath://*[@AutomationId='SelectedFormulationComboBox Input Field']//*[@AutomationId='ContentElement']");
        public WindowsElement FormulationAgencyNameDropdown => FindElement("XPath://*[@AutomationId='LoaAgencyListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement FormulationLocationNameEntryTextbox => FindElement("XPath://*[@AutomationId='FormulationLocationNameEntry']");

        // Formulation DMF 
        public WindowsElement NewPlantAddressEntry => FindElement("XPath://*[@AutomationId='NewPlantAddressEntry']");
        public WindowsElement NewPlantTitleEntry => FindElement("XPath://*[@AutomationId='NewPlantTitleEntry']");
        public WindowsElement NewPlantAbbreviationEntry => FindElement("XPath://*[@AutomationId='NewPlantAbbreviationEntry']");

        //Standard Email Statement 
        public WindowsElement NewStandardEmailsTitleEntry => FindElement("XPath://*[@AutomationId='NewStandardEmailsTitleEntry']");
        public WindowsElement NewStandardEmailStatementEntry => FindElement("XPath://*[@AutomationId='NewStandardEmailStatement1Editor']");

        // Formulation
        public WindowsElement Contains2MCBTPickerDropdown => FindElement("XPath://*[@AutomationId='Contains2MCBTPicker']");
        public WindowsElement RelatedSubstanceEntryTextbox => FindElement("XPath://*[@AutomationId='RelatedSubstanceEntry']");

        // Wash Process DMF
        public WindowsElement NewWashProcessTitleEntryTextbox => FindElement("XPath://*[@AutomationId='NewWashProcessTitleEntry']");
        public WindowsElement NewWashFormualtionTypeDropdown => FindElement("XPath://*[@AutomationId='NewWashFormualtionTypeListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewWashPlantDropdown => FindElement("XPath://*[@AutomationId='NewWashPlantListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewWashProcessDmfLoaAgencyDropdown => FindElement("XPath://*[@AutomationId='NewWashProcessDmfLoaAgencyListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewWashProcessDmfLoaTemplateDropdown => FindElement("XPath://*[@AutomationId='NewWashProcessDmfLoaTemplateListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewWashProcessConfigBerFamilyDropdown => FindElement("XPath://*[@AutomationId='NewWashProcessConfigBerFamilyListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewWashProcessDmfAmendmentTextbox => FindElement("XPath://*[@AutomationId='NewWashProcessDmfAmendmentEditor']");
        public WindowsElement NewWashProcessDmfBerTableTextbox => FindElement("XPath://*[@AutomationId='NewWashProcessDmfBerTableEditor']");

        //ChinaDossierNumber

        public WindowsElement DmfSubjectEntryTextbox => FindElement("XPath://*[@AutomationId='DmfSubjectEntry']");
        public WindowsElement ChinaDossierNumberCodeEntryTextbox => FindElement("XPath://*[@AutomationId='ChinaDossierNumberCodeEntry']");
        public WindowsElement ConfigarationFieldEntryTextbox => FindElement("XPath://*[@AutomationId='ConfigarationFieldEntry']");
        public WindowsElement SpecificationEntryTextbox => FindElement("XPath://*[@AutomationId='SpecificationEntry']");
        public WindowsElement ChinaDossierPlantDropdown => FindElement("XPath://*[@AutomationId='SelectedPlantCombobox Input Field']/*[@AutomationId='ContentElement']");

        // Sterile Process DMF
        public WindowsElement NewSterileProcessTitleEntryTextbox => FindElement("XPath://*[@AutomationId='NewSterilProcessTitleEntry']");
        public WindowsElement NewSterilePlantDropdown => FindElement("XPath://*[@AutomationId='NewSterilProcessSelectedPlantComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewSterileProcessDmfLoaAgencyDropdown => FindElement("XPath://*[@AutomationId='NewSterilProcessLoaAgencyListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewSterileProcessPackOptionDropdown => FindElement("XPath://*[@AutomationId='NewSterilProcessPackOptionListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewSterileLoaTemplateDropdown => FindElement("XPath://*[@AutomationId='NewSterilLoaTemplateListComboBox Input Field']/*[@AutomationId='ContentElement']");
        public WindowsElement NewSterileProcessAmendmentTextbox => FindElement("XPath://*[@AutomationId='NewSterilProcessAmendmentTextEntry']");
        public WindowsElement NewStmStrlProdDescEntryTextbox => FindElement("XPath://*[@AutomationId='NewStmStrlProdDescEntry']");

        //Pack Option
        public WindowsElement TitlePackOptionTextbox => FindElement("XPath://*[@AutomationId='NewPackOptionCreationPageTitle']");
    }

}
