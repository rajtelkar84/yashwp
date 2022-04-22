using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CasesPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CasesPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement Inbox => FindElement("XPath://*[@Name='Select Inbox']");
        public WindowsElement InboxSearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement CreateCase => FindElement("XPath:.//*[contains(@Name,'Create Case')]");
        public WindowsElement Title => FindElement("XPath://*[@AutomationId='AIdCaseTitleEntry']");
        public WindowsElement AccountArrow => FindElement("XPath://*[@AutomationId='AIdCaseCompanyNameGenericPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement AccountNameField => FindElement("XPath://*[@AutomationId='AIdCaseCompanyNameGenericPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement AccountSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SelectAnItemFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement ContactArrow => FindElement("XPath://*[@AutomationId='AIdCaseContactPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement ContactNameField => FindElement("XPath://*[@AutomationId='AIdCaseContactPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement LowPriority => FindElement("XPath://*[@Name='Low']");
        public WindowsElement NormalPriority => FindElement("XPath://*[@Name='Normal']");
        public WindowsElement HighPriority => FindElement("XPath://*[@Name='High']");
        public WindowsElement Origin => FindElement("XPath://*[@AutomationId='AIdCaseOriginPicker']");
        public WindowsElement OriginNameField => FindElement("XPath://*[@AutomationId='AIdCaseOriginPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ProductOrigin => FindElement("XPath://*[@AutomationId='AIdCaseProductOriginPicker']");
        public WindowsElement ProductOriginNameField => FindElement("XPath://*[@AutomationId='AIdCaseProductOriginPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ProductOriginOk => FindElement("XPath://*[@Name='OK']");
        public WindowsElement CaseInvolvment => FindElement("XPath://*[@AutomationId='AIdCaseInvolvemntPicker']");
        public WindowsElement CaseInvolvmentNameField => FindElement("XPath://*[@AutomationId='AIdCaseInvolvemntPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement CaseOwnerNameField => FindElement("XPath://*[@AutomationId='AIdCaseOwnerPicker']/descendant::*[@ClassName='TextBox']");
        public WindowsElement CaseOwnerArrow => FindElement("XPath://*[@AutomationId='AIdCaseOwnerPicker']/descendant::*[@ClassName='Image']");
        public WindowsElement BussinessType => FindElement("XPath://*[@AutomationId='AIdCaseBusinessTypePicker']");
        public WindowsElement BussinessTypeNameField => FindElement("XPath://*[@AutomationId='AIdCaseBusinessTypePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement BussinessSubType => FindElement("XPath://*[@AutomationId='AIdCaseBusinessSubTypePicker']");
        public WindowsElement BussinessSubTypeNameField => FindElement("XPath://*[@AutomationId='AIdCaseBusinessSubTypePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement ProductArrow => FindElement("XPath:(//*[@AutomationId='AIdCaseContactPicker']/descendant::*[@ClassName='Image'])[3]");
        public WindowsElement ProductNameField => FindElement("XPath:(//*[@AutomationId='AIdCaseContactPicker']/descendant::*[@ClassName='TextBox'])[2]");
        public WindowsElement ProductSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement ProductFirstRow => FindElement("XPath://*[@Name=' Row1']");
        public WindowsElement ProductSecondRow => FindElement("XPath://*[@Name=' Row2']");
        public WindowsElement WestInitiative => FindElement("XPath://*[@AutomationId='AIdCaseWestIntiativePicker']");
        public WindowsElement WestInitiativeNameField => FindElement("XPath://*[@AutomationId='AIdCaseWestIntiativePicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement WestCampaign => FindElement("XPath://*[@AutomationId='AIdCaseWestCampaignPicker']");
        public WindowsElement WestCampaignNameField => FindElement("XPath://*[@AutomationId='AIdCaseWestCampaignPicker']/descendant::*[@ClassName='ComboBoxItem']");
        public WindowsElement DescriptionOrAdditionalInformation => FindElement("XPath://*[@AutomationId='AIdCaseCommentsRTE']");
        public WindowsElement DescriptionOrAdditionalInformationNameField => FindElement("XPath://*[@AutomationId='AIdCaseCommentsRTE']/descendant::*[@ClassName='TextBox']");
        public WindowsElement Submit => FindElement("XPath://*[@Name='Submit']");
        public WindowsElement AddCaseType => FindElement("XPath://*[@AutomationId='AIGenericPickerButton']");
        public WindowsElement BackButton => FindElement("XPath:.//*[@Name='Back' or @AutomationId='Back']");
        public WindowsElement ResolveCase => FindElement("XPath:.//*[contains(@Name,'Resolve Case')]");
        public WindowsElement ResolvedOn => FindElement("XPath:.//*[@AutomationId='AIdResolveOnDatePicker']");
        public WindowsElement CalanderPrevious => FindElement("XPath:.//*[contains(@Name,'Previous')]");
        public WindowsElement CalanderNext => FindElement("XPath:.//*[contains(@Name,'Next')]");
        public WindowsElement TotalTime => FindElement("XPath:.//*[@AutomationId='AIdResolutionTimeEntry']");
        public WindowsElement TimeUnit => FindElement("XPath:.//*[@AutomationId='AIdTimeDurationPicker']");
        public WindowsElement ResolutionRemarks => FindElement("XPath:.//*[@AutomationId='AIdResolutionRemarkEditor']");
        public WindowsElement Resolve => FindElement("XPath:.//*[@AutomationId='AIdResolveCaseResolveButton']");
        public WindowsElement ReopenCase => FindElement("XPath:.//*[contains(@Name,'Reopen Case')]");
        public WindowsElement ConfirmationYes => FindElement("XPath://*[@Name='Yes']");
        public WindowsElement CancelCase => FindElement("XPath:.//*[@Name='Cancel Case ']");
        public WindowsElement EditCase => FindElement("XPath:.//*[contains(@Name,'Edit Case')]");
        public WindowsElement Refresh => FindElement("XPath:.//*[contains(@Name,'Refresh')]");
        public WindowsElement SelectAnItemSearchBox => FindElement("XPath://*[@Name='Search']");
        public WindowsElement Status => FindElement("XPath:.//*[@AutomationId='AIdCaseStatusDefaultEntry']");
        public WindowsElement StatusPicker => FindElement("XPath:.//*[@AutomationId='AIdCaseStatusPicker']/descendant::*[@ClassName='ComboBoxItem']");
        
        public WindowsElement Description => FindElement("XPath:.//*[@Name='Description']/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement SearchInPopUpList => FindElement("XPath:.//*[contains(@ClassName,'ScrollViewer')]//*[contains(@ClassName,'ScrollViewer')]//*[contains(@ClassName,'TextBlock')]");
        public WindowsElement AllTab => FindElement("XPath:.//*[contains(@Name,'All') and contains(@AutomationId,'dashboardLabel')]");
        public IList<WindowsElement> OKButton => FindElements("XPath:.//Button[contains(@Name,'OK')]");
        public WindowsElement CreateButton => FindElement("XPath:.//Button[contains(@Name,'Create')]");
        public WindowsElement SaveAndCloseButton => FindElement("XPath:.//*[@AutomationId='AIdCaseSaveButton']");
        public WindowsElement ResolveCaseButton => FindElement("XPath://Button[@Name='Resolve Case']");
        public WindowsElement ResolveButton => FindElement("XPath:.//Button[contains(@Name,'Resolve')]");
        public WindowsElement CaseClassification => FindElement("XPath:.//*[contains(@Name,'Case Classification')]");
        public WindowsElement CaseView => FindElement("XPath:.//*[contains(@Name,'Case View')]");
        public IList<WindowsElement> CaseSubType => FindElements("XPath:.//Button[contains(@Name,'Add CaseSubType/CaseType')]");
        public IList<WindowsElement> AllRow => FindElements("XPath://*[contains(@Name,'Row')]");
        public WindowsElement DialogTitle => FindElement("XPath:.//*[@AutomationId='dialogTitle']");
        public WindowsElement DialogMessage => FindElement("XPath:.//*[@AutomationId='dialogMessage']");
        public WindowsElement ResolveCaseCancelButton => FindElement("XPath:.//*[@AutomationId='cancelButton']");
        public WindowsElement ResolveCaseOkButton => FindElement("XPath:.//*[@AutomationId='okButton']");
        public IList<WindowsElement> CaseClassificationDetails()
        {
            return FindElements($"XPath://*[@ClassName='NamedContainerAutomationPeer']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        public WindowsElement CaseClassificationData(String Value)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'AIdNewCaseClassDefaultDataGrid {Value}')]");
        }
        public WindowsElement CaseClassificationChildInboxData(String Value)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'{Value}')]");
        }
        public WindowsElement ClickOnRow(int Value)
        {
            return FindElement($"XPath://*[@Name=' Row{Value}']");
        }
        public WindowsElement OptionsValue(string Value)
        {
            return FindElement($"XPath://*[@Name='{Value}']");
        }
        public WindowsElement LabelActivityTab(String label)
        {
            return FindElement("XPath:.//*[contains(@Name,'" + label + "') and contains(@AutomationId,'dashboardLabel')]");
        }
        public WindowsElement RowWiseCaseName(int rowNumber)
        {
            return FindElement($"XPath://*[contains(@AutomationId,'R" + rowNumber + "C1')]");
        }
       
        public WindowsElement ElementByLabel(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        }
        public WindowsElement SelectElementByLabel(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        }

        public WindowsElement ImageByLabel(string label)
        {
            return FindElement("XPath:.//*[@Name='" + label + "']/../../../following-sibling::*//*[contains(@ClassName,'Image')]");
        }
        public WindowsElement Radiobutton(string radiobtnName)
        {
            return FindElement("XPath:.//*[@Name='" + radiobtnName + "' and @ClassName='RadioButton']");
        }
    }
}
