using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class PivotViewPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public PivotViewPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement MeasureField => FindElement("XPath://*[contains(@Name,'Measure')]/following-sibling::Edit");
        public WindowsElement DiemensionField => FindElement("XPath://*[contains(@Name,'Dimension')]/following-sibling::Edit");
        public WindowsElement GenerateButton => FindElement("XPath://Button[contains(@Name,'Generate')]");
        public WindowsElement CreatePivotButton => FindElement("XPath://Button[contains(@Name,'Create')]");
        public WindowsElement SelectFieldValue(string value)
        {
            return FindElement($"XPath://Text[contains(@Name,'{value}')]");
        }
        public WindowsElement SelectDropdownValue(string value)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{value}')]/Text");
        }
        public WindowsElement PivotTitle => FindElement("XPath://*[@Name='Pivot']");
        public WindowsElement GlobalPivotTabTitle => FindElement("XPath://*[@Name='Global']");
        public WindowsElement CreatedByMePivotTabTitle => FindElement("XPath://*[@Name='Created by me']");
        public WindowsElement SharedWithMePivotTabTitle => FindElement("XPath://*[@Name='Shared with me']");
        public WindowsElement NoPivotAvailableOnPage => FindElement("XPath://*[@Name='No Pivot View available']");
        public WindowsElement CreateButton => FindElement("AccessibilityId:CreatePivotButton");
        public WindowsElement TitleOfPivot => FindElement("XPath://*[@Name='Title']");
        public WindowsElement DescriptionInPivot => FindElement("XPath://*[@Name='Description']");
        public WindowsElement PivotDescriptionTextField => FindElement("XPath://Edit[contains(@Name,'Description')] | //Edit[contains(@Name,'Description')]");
        public WindowsElement DimensionInPivot => FindElement("XPath://*[@Name='Dimension']");
        public WindowsElement PivotDimensionFieldComboBox => FindElement("XPath://*[@Name='Dimension']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit[contains(@AutomationId,'DefaultChartDimesionPicker Input Field')]");
        public WindowsElement MeasureInPivot => FindElement("XPath://*[@Name='Measure']");
        public WindowsElement PivotMeasureFieldComboBox => FindElement("XPath://*[@Name='Measure']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit[contains(@AutomationId,'DefaultChartMeasurePicker Input Field')]");
        public WindowsElement GenerateButtonInPivot => FindElement("AccessibilityId:GenerateButton");
        public WindowsElement SaveButtonInPivot => FindElement("XPath://*[@Name='Save']");
        public WindowsElement CloseButtonInPivot => FindElement("XPath://*[@Name='Close']");
        public WindowsElement DownloadButtonInPivot => FindElement("AccessibilityId:downloadExcel");
        public WindowsElement GlobalTab => FindElement("XPath://*[@Name='Global']/parent::Custom");
        public WindowsElement CreatedByMeTabInPivot => FindElement("XPath://*[@Name='Created by me']/parent::Custom");
        public WindowsElement SharedWithMeTabInPivot => FindElement("XPath://*[@Name='Shared with me']/parent::Custom");
        public WindowsElement DeleteImageInPivot => FindElement("AccessibilityId:DeletePivot");
        public WindowsElement EditButtonInPivot => FindElement("AccessibilityId:EditPivot");
        public WindowsElement AddPivotImage => FindElement("AccessibilityId:AddPivotImage");
        public IList<WindowsElement> DeleteButtonInPivot => FindElements("AccessibilityId:DeletePivot");
        public IList<WindowsElement> UserCreatedPivot => FindElements("XPath://Pane[@AutomationId='PART_ScrollViewer']/parent::List/following-sibling::Pane/child::Custom/Custom");
        public WindowsElement ConfirmationYesButtonPivot => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement ClearPivotDimension => FindElement("AccessibilityId:DefaultChartDimesionPicker Input Clear Button");
        public WindowsElement ClearPivotMeasure => FindElement("AccessibilityId:DefaultChartMeasurePicker Input Clear Button");
        public WindowsElement ContainsSearchButton => FindElement("XPath://*[@Name='Contains']");
        public WindowsElement StartsWithSearchButton => FindElement("XPath://*[@Name='Starts with']");
        public WindowsElement EndsWithSearchButton => FindElement("XPath://*[@Name='Ends with']");
        public WindowsElement SearchButton => FindElement("XPath://*[@AutomationId='SearchImage']");
        public WindowsElement SearchBox => FindElement("XPath://*[@AutomationId='searchEntry']");
        public WindowsElement SelectRandomPivotRecord(int randomNumber)
        {
            return FindElement($"XPath://*[@AutomationId=' Row{randomNumber}']/child::Group/child::Custom/child::Text");
        }
        public WindowsElement NoOfSearches => FindElement("XPath://*[@Name='Displayed']/following-sibling::Text");
        public WindowsElement CrossIcon => FindElement("XPath://*[@AutomationId='CrossIcon']");
        public WindowsElement SearchPicker => FindElement("XPath://*[@AutomationId='wildcardpicker']");
        public WindowsElement DialogMessage => FindElement("XPath://*[@AutomationId='dialogMessage']");
        public WindowsElement OkButton => FindElement("XPath://*[@AutomationId='okButton']");
        public WindowsElement PivotTitleTextBox => FindElement("XPath://Edit[@Name='Title']");
        public WindowsElement AggregateTypePicker => FindElement("XPath://*[@Name='Aggregate Type']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/*[@AutomationId='wildcardpicker']");
        public IList<WindowsElement> AggregateTypeOptions => FindElements("XPath://*[@Name='Aggregate Type']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/*[@AutomationId='wildcardpicker']/child::ListItem");
    }
}
