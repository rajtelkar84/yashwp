using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InboxFilterPage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public InboxFilterPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement AddFilterButton => FindElement("AccessibilityId:AddNewFilter");
        public WindowsElement ClearAllButton => FindElement("AccessibilityId:ClearAllFilter");
        public WindowsElement RecentFilters => FindElement("XPath://*[@Name='Recent filters']");
        public WindowsElement RecentFilterItems => FindElement("AccessibilityId:RecentFilterItems");
        public WindowsElement EditableFilterImage => FindElement("AccessibilityId:EditableFilterImage");
        public WindowsElement ActiveFilters => FindElement("XPath://*[@Name='Active Filters']");
        public WindowsElement ActiveFilterView => FindElement("AccessibilityId:ActiveFilterView");
        public IList<WindowsElement> DeleteFilterOption => FindElements("AccessibilityId:EditableFilterRemove");
        public IList<WindowsElement> EditFilterOption => FindElements("AccessibilityId:EditableFilterImageEdit");
        public IList<WindowsElement> FilterConditionsCheckbox => FindElements("XPath://Custom[@AutomationId='FilterConditions']//CheckBox");
        public WindowsElement GroupFilterButton => FindElement("Name:Group");
        public IList<WindowsElement> FilterConjunction => FindElements("XPath://*[@AutomationId='FilterFieldTitle']/preceding-sibling::ComboBox");
        public IList<WindowsElement> FilterConjunctions => FindElements("ClassName:ComboBoxItem");
        #region Filter Value Pop-Up
        public WindowsElement PopUpFilterValueEdit => FindElement("XPath://Group[@ClassName='AutoSuggestBox']/Edit");
        public WindowsElement PopUpApplyButton => FindElement("XPath:(//*[@Name='Apply'])[2]");
        public IList<WindowsElement> CalendarPreviousButton => FindElements("AccessibilityId:PreviousButton");
        public WindowsElement CalendarDate => FindElement("XPath://DataItem[contains(@Name,'2')]");
        public WindowsElement DynamicDateFromFrequency => FindElement("AccessibilityId:DynamicDateFirstDateFrequency");
        public WindowsElement DynamicDateToFrequency => FindElement("AccessibilityId:DynamicDateSecondDateFrequency");
        public WindowsElement DynamicBetweenFromField => FindElement("AccessibilityId:FromRollingDate");
        public IList<WindowsElement> EditableFilterRemove => FindElements("AccessibilityId:EditableFilterRemove");
        public WindowsElement PopUpFilteredValueCheckbox(string value)
        {
            return FindElement($"XPath://CheckBox[@ClassName='CheckBox' and contains(@Name,\"{value}\")]");
        }
        public WindowsElement SelectFilterFieldValue(string value)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{value}')]");
        }
        public WindowsElement FilterFieldComboBoxesSearchField(int filterFieldIndex=1)
        {
            return FindElement($"XPath:(//*[@AutomationId='FilterFieldTitle']//Edit[@AutomationId=' Input Field'])[{filterFieldIndex}]");
        }
        public WindowsElement OperatorComboBoxesSearchField(int operatorIndex = 1)
        {
            return FindElement($"XPath:(//*[contains(@AutomationId,'FilterOperatorPicker')])[{operatorIndex}]");
        }
        public WindowsElement FilterValueTextBoxes(int filterValuendex = 1)
        {
            return FindElement($"XPath:(//*[contains(@AutomationId,'FilterValueView')])[{filterValuendex}]");
        }
        public WindowsElement FilterValueEdits(int filterValuendex = 1)
        {
            return FindElement($"XPath:(//*[contains(@AutomationId,'FilterValueView')]//Edit[contains(@AutomationId,'Editor')])[{filterValuendex}]");
        }
        public WindowsElement FilterValueDropdowns(int filterValuendex = 1)
        {
            return FindElement($"XPath:(//*[contains(@AutomationId,'FilterValueView')]//*[contains(@AutomationId,'Picker')])[{filterValuendex}]");
        }
        public WindowsElement FilterValueCalendarFrom(int filterValuendex = 1)
        {
            return FindElement($"XPath:(//*[contains(@AutomationId,'FreomDate')])[{filterValuendex}]");
        }
        public WindowsElement DynamicBetweenFromDate => FindElement("AccessibilityId:DynamicFromDate");
        public WindowsElement DynamicBetweenToDate => FindElement("AccessibilityId:DynamicToDate");
        public WindowsElement FromIncrementType => FindElement("AccessibilityId:FromIncrementType");
        public WindowsElement FromIncrementTypeMinus => FindElement($"XPath:(//*[@AutomationId='FromIncrementType'])//*[@Name='Minus']");
        public WindowsElement FromIncrementByValue => FindElement("AccessibilityId:FromIncrementBy");
        public WindowsElement FromDateFrequency => FindElement("AccessibilityId:FromDateFrequency");
        public IList<WindowsElement> FromDateFrequencyWeek => FindElements($"XPath:(//*[@AutomationId='FromIncrementType'])//*[@ClassName='ComboBoxItem']");
        public IList<WindowsElement> ConfirmationPopupTextPlaceholder => FindElements("AccessibilityId:dialogMessage");
        public IList<WindowsElement> FilterValuePicker => FindElements($"XPath://Custom[@AutomationId='FilterValueView']//Image");
        public IList<WindowsElement> FilterValuePopUp => FindElements($"XPath://Text[@AutomationId='PopupTitle' and @Name='Search']");
        public WindowsElement FilterValuePickerIcon => FindElement($"XPath://Custom[@AutomationId='MultiSelectorPicker']//Image");
        public WindowsElement PopUpSearchButton => FindElement($"XPath://*[@AutomationId='QueryButton']");
        public WindowsElement SelectCheckBox(string value)
        {  
            return FindElement($"XPath://*[@ClassName='CheckBox' and @Name='{value}']");
        } 
        public WindowsElement OpenFilter_Container => FindElement("@AutomationId='CloseFilter_Container'");


        #endregion



    }
}
