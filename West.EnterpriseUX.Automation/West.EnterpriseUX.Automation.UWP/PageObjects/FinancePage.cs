using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class FinancePage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public FinancePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement SubPerona(string function)
        {
            return FindElement($"XPath://Text[@Name='{function}']");
        }

        public WindowsElement SubPersonaText => FindElement("XPath://*[@AutomationId='InboxNameGrid']/child::Custom/following-sibling::Text/following-sibling::Text");
        public WindowsElement ToggleExpand => FindElement("XPath://*[@AutomationId='PaneTogglePane']");
        public WindowsElement SearchEntry => FindElement("XPath://*[@AutomationId='searchEntry']");
        public WindowsElement FilterButton => FindElement("XPath://*[@AutomationId='ActiveFiltersPageButton']");
        public WindowsElement AddNewFilterButton => FindElement("XPath://*[@AutomationId='AddNewFilter']");
        public WindowsElement ClosePopupImage => FindElement("XPath://*[@AutomationId='ClosePopupImage']");
        public WindowsElement Refresh => FindElement("XPath://*[@Name='Refresh']");
        public WindowsElement Sort => FindElement("XPath://*[@Name='Sort']");
        public WindowsElement SortPopupTitle => FindElement("XPath://*[@AutomationId='PopupTitle']");
        public WindowsElement More => FindElement("XPath://*[@Name='More']");
        public WindowsElement MoreColobrationInsight => FindElement("XPath://*[@Name='More']");
        public WindowsElement Insight => FindElement("XPath://*[@Name='More']/../following-sibling::Custom/child::Image");
        public WindowsElement InsightText => FindElement("XPath://*[@Name='Insights']");
        public WindowsElement InsightTextClose => FindElement("XPath://*[@Name='Insights']/following-sibling::Image/following-sibling::Image");
        public WindowsElement CreateProposalButton => FindElement("XPath://*[@Name='Create Proposal']");

        public WindowsElement KPIs => FindElement("XPath://*[@Name='KPIs']");
        public WindowsElement GLobalKPIs => FindElement("XPath://*[@Name='Global']");
        public WindowsElement GlobalKPIsPERByBuckets => FindElement("XPath://*[@Name='PER by Buckets']");
        public WindowsElement GlobalKPIsPERByStatus => FindElement("XPath://*[@Name='PER by Status']");
        public WindowsElement CreatedByMeKPIs => FindElement("XPath://*[@Name='Created by me']");
        public WindowsElement CreatedByMeKPIsLabel1 => FindElement("XPath://*[@Name='UserCreatedlabel1']");
        public WindowsElement SharedWithMeKPIs => FindElement("XPath://*[@Name='Shared with me']");
        public WindowsElement SharedWithMeButton => FindElement("XPath://*[@AutomationId='PerformAction_Container']");
        public WindowsElement SearchUnderKPIs => FindElement("XPath://*[@Name='Search']");
        public WindowsElement ManageKPIs => FindElement("XPath://*[@Name='Manage KPIs']");     
        public WindowsElement ManageKpisPopup => FindElement("XPath://*[@AutomationId='PopupTitle']");
        public WindowsElement ManageKpisPopupCross => FindElement("XPath://*[@AutomationId='PopupTitle']/following-sibling::Image/following-sibling::Image");
        public WindowsElement ChartsPER => FindElement("XPath://*[@Name='Charts']");
        public WindowsElement ChartsPERsByPortifolioGlobal => FindElement("XPath://*[@Name='PERs by Portfolio']");
        public WindowsElement ChartsCreatedBymePER => FindElement("XPath://*[@Name='Created by me']");
        public WindowsElement ChartsSharedWithMePER => FindElement("XPath://*[@Name='Shared with me']");
        public WindowsElement ChartsSearchPER => FindElement("XPath://*[@Name='Search']");
        public WindowsElement StoryboardsPER => FindElement("XPath://*[@Name='Storyboards']");
        public WindowsElement CreatestoryboardPER => FindElement("XPath://*[@Name='Create storyboard']");
        public WindowsElement CloseBoardPER => FindElement("XPath://*[@Name='Close']//preceding-sibling::Image");

        public WindowsElement FirstPERId => FindElement("XPath://*[@Name=' Row1']/child::Group[2]");

        public WindowsElement SearchContains => FindElement("XPath:.//*[@Name='Search']/preceding-sibling::ComboBox");

        public WindowsElement SearchEditBox => FindElement("XPath:.//*[@Name='Search']");
        public WindowsElement FirstPERId1 => FindElement("XPath://*[@Name=' Row1']/child::Group[2]");

        public WindowsElement SearchContains1 => FindElement("XPath:.//*[@Name='Search']/preceding-sibling::ComboBox");

        public WindowsElement SearchEditBox1 => FindElement("XPath:.//*[@Name='Search']");

        public WindowsElement SearchImage => FindElement("XPath:.//*[@Name='Search']/following-sibling::Image[2]");

        public WindowsElement RecordCount => FindElement("XPath:.//*[contains(@Name,'All')]");
        public WindowsElement SearchImage1 => FindElement("XPath:.//*[@Name='Search']/following-sibling::Image[2]");
        public WindowsElement GeneralInfoTabPERScreen => FindElement("XPath://*[@Name='General Info']");
        public WindowsElement RecordCount1 => FindElement("XPath:.//*[contains(@Name,'All')]");

        public WindowsElement InvoiceInBoxFirstRecordAction => FindElement("XPath:.//*[@Name=' Row1']/child::Group[1]/child::Custom/child::Custom/child::Image[2]");

        public WindowsElement PostInvoiceAction => FindElement("XPath:.//*[@Name='Post Invoice']");
        public WindowsElement ReviewAndPostInvoice => FindElement("XPath:.//*[@Name='Review and Post Invoice']");

        public WindowsElement ExpandOptio => FindElement("XPath:.//*[@Name='Expand']");
        public WindowsElement CollarationBetaOption => FindElement("XPath:.//*[@Name='Collaboration(Beta)']");
        public WindowsElement DisplayInvoiceOption => FindElement("XPath:.//*[@Name='Display Invoice']");
        public WindowsElement PostInvoiceeOption => FindElement("XPath:.//*[@Name='Post Invoice']");
        public WindowsElement MarkasStatementOption => FindElement("XPath:.//*[@Name='Mark as Statement']");
        public WindowsElement MarkasReviewedOption => FindElement("XPath:.//*[@Name='Mark as Reviewed']");
        public WindowsElement DeleteInvoiceOption => FindElement("XPath:.//*[@Name='Delete Invoice']");
        public WindowsElement MarkasDuplicateeOption => FindElement("XPath:.//*[@Name='Mark as Duplicate']");

        public WindowsElement ParkJournalEntryButton => FindElement("XPath:.//*[@Name='Park Journal Entry']");
    }
}
