using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InboxKpisPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public InboxKpisPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement KPIConfigSaveButton => FindElement("XPath://*[@Name='Save']");
        public WindowsElement AddKPITemplate => FindElement("AccessibilityId:AddKpi");
        public IList<WindowsElement> KPIMicroFilterOptions => FindElements("XPath://*[@ClassName='MenuFlyout']//Text");
        public IList<WindowsElement> MicroFilter => FindElements("AutomationId:MicroFilter");
        public WindowsElement ManageKPIs => FindElement("XPath://*[@Name='Manage KPIs']");
        public WindowsElement KPINameTextfield  => FindElement("XPath://Edit[contains(@Name,'Enter KPI Name')] | //Edit[contains(@Name,'Enter name')]");
        //public WindowsElement KPINameTextfield => FindElement("XPath://*[@Name='Enter KPI Name']");
        public WindowsElement KPIValueTextField => FindElement("AccessibilityId:ChartName");
        public WindowsElement FieldKpiTemplateName => FindElement("XPath://Edit[@AutomationId='Chart name'] | //Edit[contains(@Name,'Enter name')]");
        public WindowsElement KPIsComboBox => FindElement("XPath://ComboBox[@AutomationId='sharedPicker']");
        public IList<WindowsElement> KPIsComboBoxList => FindElements($"XPath://ComboBox[@AutomationId='sharedPicker']/child::ListItem");
        public IList<WindowsElement> InputClearButton => FindElements($"XPath://Button[contains(@AutomationId,'Input Clear Button')]");
        public IList<WindowsElement> GetKPIByLabelName(string labelName)
        {
            return FindElements($"XPath:.//Custom[@AutomationId='automationZoom']/Text[contains(@Name,'{labelName}')]/parent::Custom/parent::Custom/parent::Custom/parent::Custom");
        }
        public IList<WindowsElement> GetKPIToZoom(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='Zoom']");
        }
        public IList<WindowsElement> GetKPIToFavorite(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='Favourite']");
        }
        public WindowsElement GetKPIHeaderName(string kPIName)
        {
            return FindElement($"XPath://Text[contains(@Name,'{kPIName}')]");
        }
        public IList<WindowsElement> GetAdvanceFilterByKPIName(string kPIName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{kPIName}')]/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='MicroFilter']");
        }
        public WindowsElement GetEditImageByKPIName(string kPIName)
        {
            return FindElement($"XPath://Text[@Name='{kPIName}']/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='More']");
        }
        public IList<WindowsElement> GetKPIMoreOption(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='More']");
        }
       
        public WindowsElement SelectAggregationTypeForKPIValues(string aggregationName)
        {
            return FindElement($"XPath://*[@Name='{aggregationName}' and @AutomationId='aggregationType_{aggregationName}']");
        }
        public WindowsElement MeasureFieldCombobox()
        {
            return FindElement($"XPath://Text[@Name='Measure']/following::ComboBox[1]");
        }
        public WindowsElement DimensionFieldCombobox()
        {
            return FindElement($"XPath://Text[@Name='Dimension']/following::ComboBox[1]");
        }
        public WindowsElement PropertyFieldCombobox()
        {
            return FindElement($"XPath://Text[@Name='Property']/following::Edit//*[contains(@AutomationId,'Dropdown Button')]");
        }
        public WindowsElement SelectFavoriteByKPIName(string kPIName)
        {
            return FindElement($"XPath://Text[@Name='{kPIName}']/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='Favourite']");
        }
        public WindowsElement SelectPropertyValue(string value)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{value}')]/Text");
        }
        public IList<WindowsElement> SearchingText(string textValue)
        {
            return FindElements($"XPath://Text[contains(@Name,'{textValue}')]");
        }
        public WindowsElement ShowHideKPIByName(string kPIName)
        {
            return FindElement($"XPath://*[@ClassName='TextBlock' and contains(@Name,'{kPIName}')]/following-sibling::Image");
        }
        public IList<WindowsElement> KPIMoreOption(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='More']");
        }
        public IList<WindowsElement> KPICreateTab(string kpiTab)
        {
            return FindElements($"XPath://Text[contains(@Name,'{kpiTab}')]");
        }
        public IList<WindowsElement> AddKPIImage => FindElements("AccessibilityId:PerformAction");
        public WindowsElement CreatedByMeTab => FindElement("Name:Created by me");
    }
}
