using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InboxPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public InboxPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public IList<WindowsElement> PopUpWindow => FindElements("AccessibilityId:Popup Window");
        public WindowsElement PopUpOkButton => FindElement("AccessibilityId:Button0");
        public IList<WindowsElement> ViewSemantics => FindElements("AccessibilityId:ViewSemantic");
        public IList<WindowsElement> InboxGridRecords => FindElements("XPath://Group[@ClassName='NamedContainerAutomationPeer' and contains(@AutomationId,'Row')]");
        public IList<WindowsElement> InboxTabOptions => FindElements("XPath://Tab[@ClassName='Pivot']//TabItem[@ClassName='PivotItem']");
        public IList<WindowsElement> InboxLabels => FindElements("XPath://*[@AutomationId='parentInboxGridView']//List[@ClassName='ListView']//Text");
        public WindowsElement SaveLabelButton => FindElement("XPath://*[contains(@Name,'Pop-up')]//Button[contains(@Name,'Save')]");
        public IList<WindowsElement> LabelNameEdit => FindElements("XPath://Edit");
        public IList<WindowsElement> LabelNameEditOptional => FindElements("XPath://Text[contains(@Name,'Save New')]/parent::Custom/parent::Custom//Edit");
        public IList<WindowsElement> DashboardLabels => FindElements("AccessibilityId:dashboardLabel");
        public IList<WindowsElement> InboxList => FindElements("XPath://ListItem[@Name='West.EnterpriseUX.Models.Inbox.InboxModel']//Custom//Custom//Text[@ClassName='TextBlock']");
        public IList<WindowsElement> GridRefresh => FindElements("AccessibilityId:RefreshData");
        public IList<WindowsElement> GridRecordsCheckBoxes => FindElements("XPath://Group[contains(@AutomationId,' Row')]//CheckBox");
        public WindowsElement SortImage => FindElement("AccessibilityId:Sort");
        public WindowsElement AddSortButton => FindElement("XPath://Button[contains(@Name,'Add Sort')]");
        public IList<WindowsElement> Settings => FindElements("AccessibilityId:Settings");
        public WindowsElement SaveLabelCustom => FindElement("AccessibilityId:Save");
        public WindowsElement SaveButtonCustom => FindElement("XPath://*[contains(@Name,'Save')");
        public IList<WindowsElement> DetailsMoreOptionImage => FindElements("XPath://*[@Name='More']/following-sibling::*[@AutomationId='More']");
        public WindowsElement ContextMoreImage => FindElement("XPath://*[@AutomationId='ViewSemantic']/following-sibling::*[@AutomationId='More']");
        public WindowsElement GetHeaderInExpandView => FindElement($"XPath://*[@ClassName='Popup']//Image[1]/following-sibling::Text[@ClassName='TextBlock']");
        public IList<WindowsElement> GetExpandRecordsData => FindElements($"XPath://*[@ClassName='Popup']//List[@ClassName='ListView']//ListItem[@ClassName='ListViewItem']//Text[2]");
        public IList<WindowsElement> GetMasterActionOptions => FindElements($"XPath://*[@Name='Pop-upHost']//*[@ClassName='MenuFlyoutItem']//Text");
        public WindowsElement SearchOptionDropdown => FindElement("AccessibilityId:wildcardpicker");
        public IList<WindowsElement> GetInboxLabelCount => FindElements($"XPath:.//Text[contains(@AutomationId,'dashboardLabel')]");
        public IList<WindowsElement> DetailAction => FindElements("XPath://*[@Name=' Row1']//Image[@AutomationId='More']");
        public WindowsElement LastSyncedTime => FindElement("XPath:.//*[contains(@ClassName,'TextBlock') and contains(@AutomationId,'InboxCachingTime')]");
        public IList<WindowsElement> DetailActionAllRow(int rowNum)
        {
            return FindElements($"XPath://*[@Name=' Row" + rowNum + "']//Image[@AutomationId='More']");
        }

        public WindowsElement DataNotAvailable => FindElement("XPath://*[@Name='Data not available']");
        public WindowsElement ServerResponceAvailable => FindElement("XPath://Button[@Name='Retry']");
        public IList<WindowsElement> DashboardLabelDelete => FindElements("AccessibilityId:Delete");
        public IList<WindowsElement> InboxesContextMenus => FindElements("AccessibilityId:inboxContextMenu");
        public IList<WindowsElement> ConfirmSave => FindElements("AccessibilityId:CommandButton_6");
        public IList<WindowsElement> GetInboxNameTitle => FindElements("XPath://*[@AutomationId='InboxNameGrid']//*[@AutomationId='InboxName']");
        public WindowsElement ExportCountEdit => FindElement("XPath://Edit[contains(@Name,'Count')]");
        public WindowsElement ExportButton => FindElement("XPath://Button[@Name='Export']");
        public WindowsElement DialogSaveFileName => FindElement("AccessibilityId:1001");
        public IList<WindowsElement> DialogSaveButton => FindElements("XPath://*[@AutomationId='1' and @Name='Save']");
        public IList<WindowsElement> SortDeleteButton => FindElements("XPath://*[@Name='Select column to sort']/parent::Custom/parent::Custom/parent::Custom/parent::Custom/parent::Custom/following-sibling::Image[@ClassName='Image']");
        public IList<WindowsElement> InboxDashboardLabels(string labelName)
        {
            return FindElements($"XPath://List[@ClassName='ListView']//Text[contains(@Name,'{labelName}')]");
        }
        public IList<WindowsElement> MangeLablePoupUpList(string labelName)
        {
            return FindElements($"XPath://*[contains(@Name,'{labelName}')]");
        }
        public IList<WindowsElement> EnableDissableIconInManageLebel(string labelName)
        {
            return FindElements($"XPath://*[contains(@Name,'{labelName}')]/following-sibling::*[contains(@ClassName,'Image')]");
        }
        public WindowsElement SelectAbstraction(string abstractionName)
        {
            return FindElement($"XPath://TabItem[@ClassName='PivotItem' and contains(@Name,'{abstractionName}')]");
        }
        public IList<WindowsElement> VerifyLabelName(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]");
        }

        public WindowsElement SelectSortColumn(string column)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{column}')]/Text");
        }
        public IList<WindowsElement> GetRecordByRow(int rowNo)
        {
            return FindElements($"XPath://Group[@AutomationId=' Row{rowNo}' and @ClassName='NamedContainerAutomationPeer']//Group//Text");
        }
        public IList<WindowsElement> GetDetailOption(string detailAction)
        {
            return FindElements($"XPath://*[@ClassName='MenuFlyoutItem' and contains(@Name,'{detailAction}')]");//
        }
        public IList<WindowsElement> GetInbox(string inboxName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{inboxName}')]");
        }
        public IList<WindowsElement> GetDetailsMoreOption(string moreOption)
        {
            return FindElements($"XPath://Text[contains(@Name,'{moreOption}')]");
        }
        public IList<WindowsElement> GetExportDataCheckBox(string exportName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{exportName}')]/preceding-sibling::CheckBox");
        }
        public IList<WindowsElement> GetSortColumnInputField(int index = 0)
        {
            return FindElements($"XPath://*[@Name='Select column to sort']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit[contains(@AutomationId,'Input Field')]");
        }
        public IList<WindowsElement> GetSortOrderCombobox(int index = 0)
        {
            return FindElements($"XPath://*[@Name='Select sort order']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//*[contains(@AutomationId,'Dropdown Button')]");
        }
        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            //return FindElement($"XPath://*[contains(@AutomationId,'{rowAndColumnInGrid}')] | //*[contains(@Name,'Row1')]//*[@ClassName='']");
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public WindowsElement HyperlinkInSemantic(string hyperlinkText)
        {
            return FindElement($"XPath://Text[contains(@Name,'Sold-To Party')]/following-sibling::Text[contains(@Name,'{hyperlinkText}')]");
        }
        #region PageNavigationOptions
        public WindowsElement PaginationFirstPage => FindElement("AccessibilityId:PreviousEnd");
        public WindowsElement PaginationPreviousPage => FindElement("AccessibilityId:Previous");
        public WindowsElement PaginationNextPage => FindElement("AccessibilityId:Next");
        public WindowsElement PaginationLastPage => FindElement("AccessibilityId:NextEnd");
        public WindowsElement RecordsPerPageDropdown => FindElement("AccessibilityId: Dropdown Button");
        public IList<WindowsElement> GetPageNumber(string pageNumber)
        {
            return FindElements($"XPath://ListItem[@ClassName='ListBoxItem' and contains(@Name,'{pageNumber}')]");
        }
        public IList<WindowsElement> PageNumberTextField => FindElements("XPath://*[@AutomationId='Previous']/following-sibling::Edit[contains(@AutomationId,'Input Field')]");
        #endregion
        public IList<WindowsElement> OpenLabel => FindElements("XPath://*[@Name='Open']");
        public IList<WindowsElement> AllManageLabels => FindElements("XPath://*[@Name='All']");
        public WindowsElement AlldashboardLabels => FindElement("XPath://*[@AutomationId='dashboardLabel' and contains(@Name,'All')]");
        public WindowsElement ManageLabelsSaveButton => FindElement("XPath://*[@Name='Save']");
        public IList<WindowsElement> ManageLabelsSuccessMsg => FindElements("XPath://*[@Name='Success']");
        public IList<WindowsElement> ManageLabels => FindElements("XPath://*[@ClassName='TextBlock']");
        public IList<WindowsElement> InboxContextMenu => FindElements("XPath://*[@ClassName='Image']");
        public IList<WindowsElement> SearchedInboxNames => FindElements("AccessibilityId:InboxName");
        public WindowsElement SearchForAction => FindElement("XPath://*[@AutomationId='SearchEntry']");
        public WindowsElement Tab360View => FindElement("XPath://*[@Name='360º View']");
        public WindowsElement KPICount => FindElement("XPath://*[contains(@Name,'Load More')]/parent::Custom/preceding-sibling::Text");
        public IList<WindowsElement> KPIsOnPage => FindElements("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom");
        public IList<WindowsElement> dashboardLabelsRightArrow => FindElements("AccessibilityId:right");
        public IList<WindowsElement> CrossIcons => FindElements("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Image[2]");
        public WindowsElement ManageGridColumnSearchBox => FindElement("XPath://Edit[@ClassName='TextBox']");
        public WindowsElement GridColumnCheckBox => FindElement("XPath://CheckBox[@ClassName='CheckBox']");
        public WindowsElement ManageGridColumnSaveButton => FindElement("XPath://Button[@Name='Save']");
        public IList<WindowsElement> GridColumnNames => FindElements("XPath://Group[@Name=' Row0']/Custom/Text");
        public WindowsElement GridColumnNameFirst => FindElement("XPath://Group[@Name=' Row0']/Custom[2]/Text");
        public WindowsElement GridColumnNameSecond => FindElement("XPath://Group[@Name=' Row0']/Custom[3]/Text");
        public WindowsElement ManageGridColumnResetButton => FindElement("XPath://Button[@Name='Reset']");
        public WindowsElement ActionsButtonInSemantic => FindElement("XPath://Text[@Name='Actions']");
        public IList<WindowsElement> MAConfirmationPopup => FindElements("XPath://Window[@ClassName='Popup']/Custom/Custom");
        public WindowsElement MAConfirmationPopupText => FindElement("AccessibilityId:dialogTitle");
        public WindowsElement CustomerIdGridRecord => FindElement("XPath://Group[@ClassName='NamedContainerAutomationPeer' and contains(@AutomationId,' R1C1 50010')]");
        public WindowsElement InsightIcon => FindElement("XPath://*[@Name='More']/parent::Custom/following-sibling::Custom/*[contains(@ClassName,'Image')]");

        public WindowsElement ExpandCardViewDetailButton => FindElement("AccessibilityId:SemanticNavigation");
        public WindowsElement GetPageTitle => FindElement("AccessibilityId:PageTitleLabel");
        public WindowsElement RecipientInputField => FindElement("AccessibilityId:Recipient Input Field");
        public WindowsElement ShareButton => FindElement("AccessibilityId:Create");
        public WindowsElement ManageAccessPopupTitle => FindElement("XPath://Text[@AutomationId='PopupTitle']");
        public WindowsElement FeedbackImageOnPopup => FindElement("XPath://Image[@AutomationId='FeedBackImage']");
        public WindowsElement ClosePopupImage => FindElement("XPath://Image[@AutomationId='ClosePopupImage']");
        public WindowsElement UpdateButtonOnPopup => FindElement("XPath://Button[@AutomationId='update']");
        public WindowsElement RecipientOnPopup => FindElement("XPath://Custom[@AutomationId='HeaderView']/following-sibling::List/ListItem/Custom/Custom/Custom/Text");
        public IList<WindowsElement> MoreContextMenu(string name)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{name}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='More']");
        }
        public IList<WindowsElement> RecipientDropdown(string RecipientName)
        {
            return FindElements($"XPath://*[@AutomationId='Recipient Dropdown']/ListItem//Text[contains(@Name,'{RecipientName}')]");
        }
        public WindowsElement SortClearAllButton => FindElement("XPath://Button[@Name='Clear All']");
        public IList<WindowsElement> InsightsLabel => FindElements("XPath://*[@Name='Insights']");
        public IList<WindowsElement> InsightsZoomIcon => FindElements("XPath://*[@Name='Insights']/following-sibling::Image[1]");
        public IList<WindowsElement> InsightsCloseIcon => FindElements("XPath://*[@Name='Insights']/following-sibling::Image[2]");
        public WindowsElement BackNavigationButton => FindElement("AccessibilityId:Back");
        public WindowsElement PersonaNameText(string personaName) { 
            return FindElement($"XPath://*[@AutomationId='PersonaName' and @Name='{personaName}']");
        }
        public IList<WindowsElement> InboxNamesList()
        {
            return FindElements("XPath://*[@AutomationId='PART_ScrollViewer' and @ClassName='ScrollViewer']//*[@AutomationId='InboxName' and @ClassName='TextBlock']");
        }
        public IList<WindowsElement> QuickFilterButton => FindElements("AccessibilityId:QuickFilters");
        public IList<WindowsElement> QuickFilterTexts => FindElements("AccessibilityId:OpenPreferredFilter");
        public WindowsElement ExportToExcelPopupTitle => FindElement("XPath://*[@Name='Export to Excel']");
        public WindowsElement FileNameTextBox => FindElement("XPath://*[@AutomationId='1001' and @Name='File name:']");
        public WindowsElement NewWindowTitle => FindElement("XPath://*[@AutomationId='PageTitleLabel']");
        public WindowsElement NumberOfItemsToExportText => FindElement("XPath://*[@Name='Enter Number of Items to Export']");
        public WindowsElement CountTextBox => FindElement("XPath://*[@Name='Count']");
        public WindowsElement SearchBoxOnDetails => FindElement("XPath://*[@Name='Search' and @ClassName='TextBox']");
        public WindowsElement CopyOption => FindElement("XPath://*[@Name='Copy' and @ClassName='AppBarButton']");
        public WindowsElement PasteOption => FindElement("XPath://*[@Name='Paste' and @ClassName='AppBarButton']");
        public WindowsElement SalesOrderItemsChildInbox => FindElement("XPath://*[@Name='Sales Order Items' and @AutomationId='InboxName']");
    }
}
