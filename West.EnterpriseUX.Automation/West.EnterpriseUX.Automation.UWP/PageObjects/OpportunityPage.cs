using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class OpportunityPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public OpportunityPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateOpportunity => FindElement("XPath://*[@Name='Create Opportunity']");
        public WindowsElement OverViewExpandIcon => FindElement("XPath://*[@AutomationId='AIdOpportunityOverviewExpandIcon']");
        public WindowsElement OverViewCollapseIcon => FindElement("XPath://*[@AutomationId='AIdOpportunityOverviewCollapseIcon']");
        public WindowsElement OpportunityName => FindElement("XPath://*[@AutomationId='AIdOpportunityNameFieldControl']");
        public IList<WindowsElement> AccountName => FindElements("XPath://*[@AutomationId='AIdAccountNameFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement AccountNameField => FindElement("XPath://*[@AutomationId='AIdAccountNameFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public IList<WindowsElement> PrimaryCustomerContact => FindElements("XPath://*[@AutomationId='AIdPrimaryCustomerContactFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement PrimaryCustomerContactField => FindElement("XPath://*[@AutomationId='AIdPrimaryCustomerContactFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement Address => FindElement("XPath://*[@AutomationId='AIdAddressFieldControl']");
        public WindowsElement OpportunityOwner => FindElement("XPath://*[@AutomationId='AIdOpportunityOwnerFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement OpportunityOwnerArrow => FindElement("XPath://*[@AutomationId='AIdOpportunityOwnerFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement BussinessType => FindElement("XPath://*[@AutomationId='AIdOpportunityTypeFieldControl']");
        public WindowsElement BussinessTypeNameField => FindElement("XPath://*[@AutomationId='AIdOpportunityTypeFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement BussinessSubType => FindElement("XPath://*[@AutomationId='AIdOpportunitySubtypeFieldControl']");
        public WindowsElement BussinessSubTypeNameField => FindElement("XPath://*[@AutomationId='AIdOpportunitySubtypeFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ProjectedCloseDate => FindElement("XPath://*[@AutomationId='AIdProjectedCloseDateFieldControl_Container']/descendant::*[@ClassName='CalendarDatePicker']");
        public WindowsElement Calander => FindElement("XPath://*[@AutomationId='CalendarView']");
        public WindowsElement Region => FindElement("XPath://*[@AutomationId='AIdRegionFieldControl']");
        public WindowsElement RegionNameField => FindElement("XPath://*[@AutomationId='AIdRegionFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ForcastedValue => FindElement("XPath://*[@AutomationId='AIdForecastedStackLayout']/descendant::*[@AutomationId='ContentElement']");
        public WindowsElement ForcastedValueCurrency => FindElement("XPath://*[@AutomationId='AIdForecastedStackLayout']/descendant::*[@ClassName='TextBlock']");
        public WindowsElement MarketUnit => FindElement("XPath://*[@AutomationId='AIdMarketUnitTitleFieldControl']");
        public WindowsElement MarketUnitNameField => FindElement("XPath://*[@AutomationId='AIdMarketUnitTitleFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Currency => FindElement("XPath://*[@AutomationId='AIdCurrencyFieldControl']");
        public WindowsElement CurrencyNameField => FindElement("XPath://*[@AutomationId='AIdCurrencyFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement MarketSegment => FindElement("XPath://*[@AutomationId='AIdMarketSegmentPickerFieldControl']");
        public WindowsElement MarketSegmentNameField => FindElement("XPath://*[@AutomationId='AIdMarketSegmentPickerFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement MarketSubSegment => FindElement("XPath://*[@AutomationId='AIdMarketSubSegmentFieldControl']");
        public WindowsElement MarketSubSegmentNameField => FindElement("XPath://*[@AutomationId='AIdMarketSubSegmentFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ActualCloseDate => FindElement("XPath://*[@AutomationId='AIdActualCloseDateFieldControl_Container']/descendant::*[@AutomationId='CalendarDatePicker']");
        public WindowsElement Probability => FindElement("XPath://*[@AutomationId='AIdProbabilityFieldControl']");
        public WindowsElement ProbabilityNameField => FindElement("XPath://*[@AutomationId='AIdProbabilityFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement StrategicAccountClassification => FindElement("XPath://*[@AutomationId='AIdStrategicAccountClassificationFieldControl']");
        public WindowsElement StrategicAccountClassificationNamefied => FindElement("XPath://*[@AutomationId='AIdStrategicAccountClassificationFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement Application => FindElement("XPath://*[@AutomationId='AIdApplicationFieldControl']");
        public WindowsElement ApplicationNameField => FindElement("XPath://*[@AutomationId='AIdApplicationFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement HVP => FindElement("XPath://*[@AutomationId='AIdHVPFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement HVPNameField => FindElement("XPath://*[@AutomationId='AIdHVPFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement SIPDesignation => FindElement("XPath://*[@AutomationId='AIdSIPDesignationFieldControl']");
        public WindowsElement SIPDesignationNameField => FindElement("XPath://*[@AutomationId='AIdSIPDesignationFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement CloseWonType => FindElement("XPath://*[@AutomationId='AIdCloseWonTypeFieldControl']");
        public WindowsElement CloseWonTypeNameField => FindElement("XPath://*[@AutomationId='AIdCloseWonTypeFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement OrganizationalVP => FindElement("XPath://*[@AutomationId='AIdOrganizationalVPFieldControl']");
        public WindowsElement OrganizationalVPNameField => FindElement("XPath://*[@AutomationId='AIdOrganizationalVPFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement BusDev => FindElement("XPath://*[@AutomationId='AIdBusDevSupportFieldControl Input Field']");
        public WindowsElement BusDevArrow => FindElement("XPath://*[@AutomationId='AIdBusDevSupportFieldControl Dropdown Button']");
        public WindowsElement BusDevClearButton => FindElement("XPath://*[@AutomationId='AIdBusDevSupportFieldControl Input Clear Button']");
        public WindowsElement SaveAndClose => FindElement("XPath://*[@Name='Save & Close']");
        public WindowsElement DetailsExpandIcon => FindElement("XPath://*[@AutomationId='AIdOpportunityDetailsExpand']");
        public WindowsElement PurposeofInquiry => FindElement("XPath://*[@AutomationId='AIdPurposeofInquiryFieldControl']");
        public WindowsElement PurposeofInquiryNameField => FindElement("XPath://*[@AutomationId='AIdPurposeofInquiryFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement MoleculeName => FindElement("XPath://*[@AutomationId='AIdMoleculeNameFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement MoleculeNameField => FindElement("XPath://*[@AutomationId='AIdMoleculeNameFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement MoleculeType => FindElement("XPath://*[@AutomationId='AIdMoleculeTypeFieldControl']/descendant::*[@AutomationId='ContentPresenter']");
        public WindowsElement WestInitiative => FindElement("XPath://*[@AutomationId='AIdWestInitiativeFieldControl Dropdown Button']");
        public WindowsElement WestInitiativeNameField => FindElement("XPath://*[@AutomationId='AIdWestInitiativeFieldControl Input Field']");
        public WindowsElement WestInitiativeClearButton => FindElement("XPath://*[@AutomationId='AIdWestInitiativeFieldControl Input Clear Button']");
        public WindowsElement WestCampaign => FindElement("XPath://*[@AutomationId='AIdWestCampaignFieldControl Dropdown Button']");
        public WindowsElement WestCampaignNameField => FindElement("XPath://*[@AutomationId='AIdWestCampaignFieldControl Input Field']");
        public WindowsElement WestCampaignClearButton => FindElement("XPath://*[@AutomationId='AIdWestCampaignFieldControl Input Clear Button']");
        public WindowsElement TherapeuticClass => FindElement("XPath://*[@AutomationId='AIdTherapeuticClassFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement TherapeuticClassNameField => FindElement("XPath://*[@AutomationId='AIdTherapeuticClassFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ThirdPartyContractOrganization => FindElement("XPath://*[@AutomationId='AIdThirdPartyContractOrganizationFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement ThirdPartyContractOrganizationNameField => FindElement("XPath://*[@AutomationId='AIdThirdPartyContractOrganizationFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ClinicalPhase => FindElement("XPath://*[@AutomationId='AIdClinicalPhaseFieldControl']");
        public WindowsElement ClinicalPhaseNameField => FindElement("XPath://*[@AutomationId='AIdClinicalPhaseFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ContractOrganizationOwner => FindElement("XPath://*[@AutomationId='AIdContractOrganizationOwnerFieldControl']");
        public WindowsElement DetailedRequest => FindElement("XPath://*[@AutomationId='AIdDetailedRequestFieldControl']");
        public WindowsElement DetailedRequestNameField => FindElement("XPath://*[@AutomationId='AIdDetailedRequestFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement BussinessImpact => FindElement("XPath://*[@AutomationId='AIdBusinessImpactFieldControl']");
        public WindowsElement BussinessImpactNameField => FindElement("XPath://*[@AutomationId='AIdBusinessImpactFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement GeneralNotes => FindElement("XPath://*[@AutomationId='AIdGeneralNotesUpdatesFieldControl']");
        public WindowsElement GeneralNotesNameField => FindElement("XPath://*[@AutomationId='AIdGeneralNotesUpdatesFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement ActivityExpandIcon => FindElement("XPath://*[@AutomationId='AIdOpportunityActivityExpand']");
        public WindowsElement RequestType => FindElement("XPath://*[@AutomationId='AIdRequestTypeFieldControl']");
        public WindowsElement RequestTypeNameField => FindElement("XPath://*[@AutomationId='AIdRequestTypeFieldControl']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement PromiseDate => FindElement("XPath://*[@AutomationId='AIdPromiseDateFieldControl_Container']/descendant::*[@ClassName='CalendarDatePicker']");
        public WindowsElement DeliveryDate => FindElement("XPath://*[@AutomationId='AIdDeliveryDateFieldControl_Container']/descendant::*[@ClassName='CalendarDatePicker']");
        public WindowsElement ExpirationDate => FindElement("XPath://*[@AutomationId='AIdExpirationDateFieldControl_Container']/descendant::*[@ClassName='CalendarDatePicker']");
        public WindowsElement CreateButton => FindElement("XPath://*[@AutomationId='CreateOpportunityBtn']");
        public WindowsElement EditOpportunity => FindElement("XPath://*[@Name='Edit Opportunity']");
        public WindowsElement BackButton => FindElement("XPath://*[@Name='Back' or @AutomationId='Back']");
        public WindowsElement OpportunityManagement => FindElement("XPath://*[@Name='Opportunity Management']");
        public WindowsElement Products => FindElement("XPath://*[@Name='Products']");
        public WindowsElement Services => FindElement("XPath://*[@Name='Services']");
        public WindowsElement Forecasts => FindElement("XPath://*[@Name='Forecasts']");
        public IList<WindowsElement> NextStage => FindElements("XPath://*[@Name='Next Stage']");
        public WindowsElement PreviousStage => FindElement("XPath://*[@Name='Previous Stage']");
        public IList<WindowsElement> CloseOpportunity => FindElements("XPath://*[@Name='Close Opportunity']");
        public WindowsElement Status => FindElement("XPath://*[@ClassName='ComboBox']");
        public WindowsElement PrimaryCloseReason => FindElement("XPath:(//*[@AutomationId=' Dropdown Button'])[1]");
        public WindowsElement SecondaryCloseReason => FindElement("XPath:(//*[@AutomationId=' Dropdown Button'])[2]");
        public WindowsElement Update => FindElement("XPath://*[@Name='Update']");
        public WindowsElement Yes => FindElement("XPath://*[@Name='YES']");
        public WindowsElement No => FindElement("XPath://*[@Name='NO']");
        public WindowsElement DialogMessage => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement DialogMessageOkayButton => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement DialogMessageCancelButton => FindElement("XPath://*[@AutomationId='cancelButton']");
        public WindowsElement AddProduct => FindElement("XPath://*[@Name='+ Add Product']");
        public WindowsElement NewOpportunityForecast => FindElement("XPath://*[@Name='+ New Opportunity Forecast']");
        public WindowsElement ForecastProduct => FindElement("XPath://*[@AutomationId='AIdProductFieldControl']");
        public WindowsElement ForecastYearOneQuantity => FindElement("XPath:(//*[@AutomationId=' Input Field']/descendant::*[@AutomationId='ContentElement'])[1]");
        public WindowsElement ForecastUnitPrice => FindElement("XPath:(//*[@AutomationId=' Input Field']/descendant::*[@AutomationId='ContentElement'])[2]");
        public WindowsElement ForecastCurrencyField => FindElement("XPath://*[@AutomationId='AIdCurrencyFieldControl']");
        public WindowsElement AnnualForecastedRevenue => FindElement("XPath:(//*[@AutomationId=' Input Field'])[8]");
        public WindowsElement TotalForecastedRevenue => FindElement("XPath:(//*[@AutomationId=' Input Field'])[4]");
        public WindowsElement ExistingProductYearOneQuantity => FindElement("XPath:(//*[@AutomationId=' Input Field']/descendant::*[@AutomationId='ContentElement'])[5]");
        public WindowsElement ExistingProductUnitPrice => FindElement("XPath:(//*[@AutomationId=' Input Field']/descendant::*[@AutomationId='ContentElement'])[6]");
        public WindowsElement CurrentAnnualRevenue => FindElement("XPath:(//*[@AutomationId=' Input Field'])[7]");
        public WindowsElement AnnualIncrementalRevenue => FindElement("XPath:(//*[@AutomationId=' Input Field'])[3]");
        public WindowsElement TotalIncementalRevenue => FindElement("XPath:(//*[@AutomationId=' Input Field'])[9]");
        public WindowsElement ExistingProduct => FindElement("XPath://*[@AutomationId='AIdExistingProductFieldControl']/descendant::*[@ClassName='Image']");
        public WindowsElement ExistingProductNameField => FindElement("XPath://*[@AutomationId='AIdExistingProductFieldControl']/descendant::*[@ClassName='TextBox']");
        public WindowsElement Add => FindElement("XPath://*[@Name='+ Add']");
        public WindowsElement Delete => FindElement("XPath://*[@Name='Delete']");
        public WindowsElement AddForecastButton => FindElement("XPath://*[@Name='Add Forecast']");
        public WindowsElement UpdateForecast => FindElement("XPath://*[@AutomationId='AIdUpdateForecast']");
        public IList<WindowsElement> ForecastIcon => FindElements("XPath://*[@AutomationId='AIdOpportunityProductForecastFieldControl']");
        public IList<WindowsElement> ForecastCreatedIcon => FindElements("XPath://*[@AutomationId='AIdOpportunityProductexistForecastFieldControl']");
        public IList<WindowsElement> APOIndiactor => FindElements("XPath://*[@AutomationId='AIdOpportunityAPOFieldControl']");
        public IList<WindowsElement> ProductDeleteIcon => FindElements("XPath://*[@AutomationId='AIdOpportunityProductdeleteFieldControl']");
        public WindowsElement RefreshData => FindElement("XPath:(//*[@AutomationId='RefreshData'])[2]");
        public WindowsElement ForecastComment => FindElement("XPath://*[@AutomationId='AIdARApprovalPopupGeneralCommentsCustomEditor']");
        public WindowsElement SearchTextBox => FindElement("XPath://*[@AutomationId='searchEntry']");
        public WindowsElement SearchImage => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement AddService => FindElement("XPath://*[@AutomationId='AIdOpenServicesFieldControl']");
        public WindowsElement AnalyticalLabServiceQuestionaires => FindElement("XPath://*[@AutomationId='LabServicesQuestionairesPicker']");
        public WindowsElement DrugProductExpandIcon => FindElement("XPath://*[@AutomationId='AIdCCSDetailsExpand']");
        public WindowsElement HeliumLeakExpandIcon => FindElement("XPath://*[@AutomationId='AIdHeliumLeaksExpand']");
        public WindowsElement HeadSpaceExpandIcon => FindElement("XPath://*[@AutomationId='AIdHeadspaceAnalysisExpand']");
        public WindowsElement HVLDExpandIcon => FindElement("XPath://*[@AutomationId='AIdHVLDExpand']");
        public WindowsElement VaccumDecayExpandIcon => FindElement("XPath://*[@AutomationId='AIdVacuumDecayExpand']");
        public WindowsElement WestStabilityExpandIcon => FindElement("XPath://*[@AutomationId='AIdWestStabilityExpand']");
        public WindowsElement OpportunityStatus => FindElement("XPath://*[@AutomationId='AIdStatusFieldControl']");
        public WindowsElement WonPrimaryCloseReason => FindElement("XPath://*[@AutomationId='AIdprimaryClosewonReasonFieldControl']");
        public WindowsElement WonSecondaryCloseReason => FindElement("XPath://*[@AutomationId='AIdSecondaryCloseWonReasonFieldControl']");
        public IList<WindowsElement> CheckBox => FindElements("XPath://*[@ClassName='CheckBox']");
        public WindowsElement NoDataAvailable => FindElement("XPath://*[@Name='No Data Available']");

        //DPCCSD
        public WindowsElement Stopper => FindElement("XPath://*[@AutomationId='AIdStopperFieldControl']");
        public WindowsElement Vial => FindElement("XPath://*[@AutomationId='AIdVialFieldControl']");
        public WindowsElement Seal => FindElement("XPath://*[@AutomationId='AIdSealFieldControl']");
        public WindowsElement Cartridge => FindElement("XPath://*[@AutomationId='AIdCartridgeFieldControl']");
        public WindowsElement PFS => FindElement("XPath://*[@AutomationId='AIdPFSFieldControl']");
        public WindowsElement SyringeSize => FindElement("XPath://*[@AutomationId='AIdSyringeSizeFieldControl']");
        public WindowsElement TipCap => FindElement("XPath://*[@AutomationId='AIdTipCapFieldControl']");
        public WindowsElement Plunger => FindElement("XPath://*[@AutomationId='AIdPlungerFieldControl']");
        public WindowsElement CCSDOther => FindElement("XPath://*[@AutomationId='AIdOtherFieldControl']");
        public WindowsElement DrugProductName => FindElement("XPath://*[@AutomationId='AIdDrugProductNameFieldControl']");
        public WindowsElement MarketProduct => FindElement("XPath://*[@AutomationId='AIdMarketedProductFieldControl']");
        public WindowsElement Placebo => FindElement("XPath://*[@AutomationId='AIdPlaceboSurrogateFieldControl']");
        public WindowsElement Justification => FindElement("XPath://*[@AutomationId='AIdJustificationFieldControl']");
        public WindowsElement ConcentrationOfActive => FindElement("XPath://*[@AutomationId='AIdConcentrationOfActiveFieldControl']");
        public WindowsElement DosingRegimen => FindElement("XPath://*[@AutomationId='AIdDosingRegimenFieldControl']");
        public WindowsElement FillVolume => FindElement("XPath://*[@AutomationId='AIdFillVolumeFieldControl']");
        public WindowsElement HeadSpace => FindElement("XPath://*[@AutomationId='AIdHeadspaceFieldControl']");
        public WindowsElement ShelfLife => FindElement("XPath://*[@AutomationId='AIdShelfLifeFieldControl']");
        public WindowsElement StorageConditions => FindElement("XPath://*[@AutomationId='AIdStorageConditionsFieldControl']");
        public WindowsElement DEAControlled => FindElement("XPath://*[@AutomationId='AIdDEAControlledFieldControl']");
        public WindowsElement Schedule => FindElement("XPath://*[@AutomationId='AIdScheduleFieldControl']");
        public WindowsElement DPDPAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdAdditionalInformationFieldControl']");
        //HeliumLeak
        public IList<WindowsElement> HLWIMQuantity => FindElements("XPath://*[@AutomationId='AIdWINQuantityFieldControl']");
        public IList<WindowsElement> HLWIMTemperature => FindElements("XPath://*[@AutomationId='AIdWINTemperatureFieldControl']");
        public IList<WindowsElement> AddMoreAction => FindElements("XPath://*[@Name='+ Add More Action']");
        public IList<WindowsElement> HLCLTMQuantity => FindElements("XPath://*[@AutomationId='AIdCLTMQuantityFieldControl']");
        public IList<WindowsElement> CLTMDocumentNumber => FindElements("XPath://*[@AutomationId='AIdCLTMFieldControl']");
        public IList<WindowsElement> HLMDMVTemperature => FindElements("XPath://*[@AutomationId='AIdRobustnessTemperatureFieldControl']");
        public IList<WindowsElement> HLMDMVRobustness => FindElements("XPath://*[@AutomationId='AIdRobustnessFieldControl']");
        public WindowsElement HLAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdHeliumLeakAdditionalNotesFieldControl']");
        //HeadSpaceAnalysis
        public IList<WindowsElement> HAWIMQuantity => FindElements("XPath://*[@AutomationId='AIdWIMQuantityControl']");
        public IList<WindowsElement> HAWIMSelectMethod => FindElements("XPath://*[@AutomationId='AIdWIMSelectMethodControl']");
        public IList<WindowsElement> HACLTMQuantity => FindElements("XPath://*[@AutomationId='AIdCLTMQuantityFieldControl']");
        public IList<WindowsElement> MDMVStandardNeeds => FindElements("XPath://*[@AutomationId='AIdMDMVStandardsNeededFieldControl']");
        public IList<WindowsElement> HAMDMVSelectMethod => FindElements("XPath://*[@AutomationId='AIdMDMVSelectMethodFieldControl']");
        public WindowsElement HeadSpaceAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdHeadSpaceCommentsFieldControl']");
        //High Voltage Leak Detection
        public IList<WindowsElement> HVLDFixtureRequired => FindElements("XPath://*[@AutomationId='AIdMDMVStandardsNeededFieldControl']");
        public IList<WindowsElement> HVLDValidationNotes => FindElements("XPath://*[@AutomationId='AIdMDMVValidationNotesFieldControl']");
        public IList<WindowsElement> HVLDCLTMQuantity => FindElements("XPath://*[@AutomationId='AIdCLTMQuantityFieldControl']");
        public WindowsElement HVLDAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdHVLDCommentsFieldControl']");
        //VaccumDecay
        public IList<WindowsElement> VaccumDecayCLTMQuantity => FindElements("XPath://*[@AutomationId='AIdCLTMQuantityFieldControl']");
        public WindowsElement VaccumDecayAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdVacuumDecayCommentsFieldControl']");
        //WestStability
        public IList<WindowsElement> WestStabilityTimePoint => FindElements("XPath://*[@AutomationId='AIdTimePointsFieldControl']");
        public IList<WindowsElement> WestStabilityTemperature => FindElements("XPath://*[@AutomationId='AIdSelectedTemperatureFieldControl']");
        public IList<WindowsElement> WestStabilityOrientation => FindElements("XPath://*[@AutomationId='AIdSelectedOrientationControl']");
        public IList<WindowsElement> WestStabilityQuantity => FindElements("XPath://*[@AutomationId='AIdQuantityFieldControl']");
        public WindowsElement WestStabilityAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdCommentsFieldControl']");
        public WindowsElement CreateService => FindElement("XPath://*[@AutomationId='CreateServicesBtn']");
        public IList<WindowsElement> ServiceName => FindElements("XPath://*[@ClassName='NamedContainerAutomationPeer']");
        public WindowsElement HorizontalIncreaseButton => FindElement("XPath://*[@AutomationId='HorizontalSmallIncrease']");
        public IList<WindowsElement> InputFields => FindElements("XPath://*[@AutomationId=' Input Field']");
        public WindowsElement Right => FindElement("XPath://*[@AutomationId='right']");

        public WindowsElement RowColumnValue(string RowNoColumnNo)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'{RowNoColumnNo}')]/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public IList<WindowsElement> InboxRowHeader()
        {
            return FindElements($"XPath://*[@AutomationId=' Row0' or @Name=' Row0']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public WindowsElement ProductName(string RowNo)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'R{RowNo}C1')]");
        }
        public WindowsElement MaterialDescription(string Row)
        {
            return FindElement($"XPath:(//*[@Name=' Row1']/descendant::*[@ClassName='TextBlock'])[{Row}]");
        }
        public WindowsElement Options(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }
        public IList<WindowsElement> InboxDashBoardLabel()
        {
            return FindElements($"XPath://*[@AutomationId='dashboardLabel']");
        }
        public IList<WindowsElement> MandatoryFieldsLable()
        {
            return FindElements("XPath://*[@AutomationId='AIdErrorLabel']");
        }


    }
}
