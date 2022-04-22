using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class InboxChartsPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;
        public InboxChartsPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement MyChartsTab => FindElement("Name:My Charts");
        public IList<WindowsElement> AddChartImage => FindElements("AccessibilityId:PerformAction");
        public WindowsElement ChartNameTextfield => FindElement("XPath://Edit[contains(@Name,'Enter Chart Name')] | //Edit[contains(@Name,'Enter name')]");
        public WindowsElement MeasureFieldComboBox => FindElement("XPath://*[@Name='Measures']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit[contains(@AutomationId,'Input Field')]");
        public WindowsElement DimensionFieldComboBox => FindElement("XPath://*[@Name='Dimensions']/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Edit[contains(@AutomationId,'Input Field')]");
        public WindowsElement CreateChartButton => FindElement("XPath://Button[@AutomationId='Create']");
        public IList<WindowsElement> GetChartDetailsValues => FindElements($"XPath://*[@ClassName='SfChart']//Text");
        public WindowsElement ViewInDetails => FindElement("XPath://Button[@AutomationId='detials']");
        public WindowsElement ChartTypeDropdown => FindElement("XPath://*[@AutomationId='ChartPicker']");
        public WindowsElement ChartTypeList => FindElement("XPath://*[@AutomationId='ChartPicker']/ListItem[@ClassName='ComboBoxItem']");
        public IList<WindowsElement> ChartTypes => FindElements($"XPath://*[@AutomationId='ChartPicker']/child::ListItem");
        public IList<WindowsElement> GetChartTypes => FindElements($"XPath://Text[contains(@Name,'Chart type')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Pane/child::Custom//Text");
        public IList<WindowsElement> ChartAdvanceConfiguration => FindElements($"XPath://*[contains(@AutomationId,'ExpandIcon')]");
        public IList<WindowsElement> AlternativeChartTypes => FindElements($"XPath://Text[contains(@Name,'Alternative')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom//Pane/child::Custom//Text");
        public IList<WindowsElement> ConfiguredLabel => FindElements("Name:Global");
        public IList<WindowsElement> ChartMoreOption => FindElements("AccessibilityId:More");
        public WindowsElement GetPageTitle => FindElement("AccessibilityId:PageTitleLabel");
        public WindowsElement ChartsComboBox => FindElement("XPath://ComboBox[@AutomationId='sharedPicker']");
        public IList<WindowsElement> ChartsComboBoxList => FindElements($"XPath://ComboBox[@AutomationId='sharedPicker']/child::ListItem");
       
        public WindowsElement SelectDropdownValue(string value)
        {
            return FindElement($"XPath://ListItem[contains(@Name,'{value}')]/Text");
        }
        public IList<WindowsElement> SearchingText(string textValue)
        {
            return FindElements($"XPath://Text[contains(@Name,'{textValue}')]");
        }
        public IList<WindowsElement> GetChartToZoom(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='Zoom']");
        }
        public IList<WindowsElement> GetChartToFavorite(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='Favourite']");
        }
        public IList<WindowsElement> GetChartToDelete(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='More']");
        }
        public IList<WindowsElement> GetChartToEdit(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]/parent::Custom/parent::Custom/parent::Custom/following-sibling::Custom/Image[@AutomationId='More']");
        }
        public IList<WindowsElement> GetChartByTitle(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]");
        }
        public IList<WindowsElement> GetChartToRefresh(string chartName)
        {
            return FindElements($"XPath://Text[@AutomationId='Title' and contains(@Name,'{chartName}')]/parent::Custom/parent::Custom/parent::Custom/following::Custom/Image[@AutomationId='More']");
        }
    }
}
