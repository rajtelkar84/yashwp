using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.IO;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class FinanceAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly FinancePage _pageInstance;

        public FinanceAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new FinancePage(_session);
        }

        public string getSubPersonaText(String subPersonaName)
        {
            WaitForMoment(1.5);
            _pageInstance.SubPerona(subPersonaName).Click();
            WaitForMoment(1.5);
            string subpersonaText= _pageInstance.SubPersonaText.Text;
            return subpersonaText;
        }

        public string CheckForSearchBox()
        {
            WaitForMoment(0.5);
            _pageInstance.ToggleExpand.Click();
            WaitForMoment(1.5);
            _pageInstance.SearchEntry.Click();
            WaitForMoment(1.5);
            string SearchedText = _pageInstance.SearchEntry.GetAttribute("Name");
            return SearchedText;
        }

        public string checkForFilter()
        {
            WaitForMoment(0.5);
            _pageInstance.FilterButton.Click();
            WaitForMoment(1.5);
            string AddNewFilterText=_pageInstance.AddNewFilterButton.Text;
            WaitForMoment(1.5);
            _pageInstance.ClosePopupImage.Click();
            return AddNewFilterText;
        }

        public void checkForRefreshButton()
        {
            WaitForMoment(0.5);
            _pageInstance.RefreshButton.Click();
        }

        public string checkForSort()
        {
            WaitForMoment(0.5);
            _pageInstance.Sort.Click();
            WaitForMoment(1.5);
            string SortPopupTitleText = _pageInstance.SortPopupTitle.Text;
            WaitForMoment(1.5);
            _pageInstance.ClosePopupImage.Click();
            return SortPopupTitleText;
        }

        public string checkForMore()
        {
            WaitForMoment(0.5);
            _pageInstance.More.Click();
            WaitForMoment(1.5);
            string MoreColobrationInsightText = _pageInstance.MoreColobrationInsight.Text;
            WaitForMoment(1.5);
            return MoreColobrationInsightText;
        }

        public string checkForInsights()
        {
            WaitForMoment(2);
            _pageInstance.Insight.Click();
            _pageInstance.Insight.Click();
            WaitForMoment(1.5);
            string InsightText = _pageInstance.InsightText.GetAttribute("Name");
            WaitForMoment(1.5);
            _pageInstance.InsightTextClose.Click();
            return InsightText;
        }

        public string checkForCreateProposalButton()
        {
            WaitForMoment(1.5);
            string CreateProposalButtonText = _pageInstance.CreateProposalButton.Text;
            return CreateProposalButtonText;
        }

        public void mooucehove(String subPersonaName)
        {
            WindowsElement windowsElement = _pageInstance.SubPerona(subPersonaName);
            MouseHoverOnWindowsElement(windowsElement);
        }

        public void KPIstest()
        {
            _pageInstance.KPIs.Click();
            WaitForMoment(2);
        }

        public (string perByBucket,string perBystatus) CheckGlobalPERKAPIs()
        {
           string pERByBuckets = _pageInstance.GlobalKPIsPERByBuckets.Text;
           string PerByStatus = _pageInstance.GlobalKPIsPERByStatus.Text;
           return (pERByBuckets, PerByStatus);
        }

        public string CheckCreatedBymePERKPIs()
        {
            _pageInstance.CreatedByMeKPIs.Click();
            WaitForMoment(2);
            string createdByme=_pageInstance.CreatedByMeKPIs.Text;
            return createdByme;
        }

        public string SharedWithmePERKPIs()
        {
            _pageInstance.SharedWithMeKPIs.Click();
            WaitForMoment(2);
            string sharedWithme = _pageInstance.SharedWithMeKPIs.Text;
            return sharedWithme;
        }

        public string SearchAndManagePERKPIs()
        {
            _pageInstance.SearchUnderKPIs.Click();
            WaitForMoment(2);
            _pageInstance.ManageKPIs.Click();
            string manageKPIs = _pageInstance.ManageKpisPopup.Text;
            _pageInstance.ManageKpisPopupCross.Click();
            return manageKPIs;
        }

        public (string PERsByPortFolio,string CreatedByme,string SharedWithMe) ChartPERTest()
        {
            _pageInstance.ChartsPER.Click();
            WaitForMoment(2);
            string PERsByPortFolio=_pageInstance.ChartsPERsByPortifolioGlobal.Text;
            _pageInstance.ChartsCreatedBymePER.Click();
            WaitForMoment(2);
            string CreatedByme=_pageInstance.ChartsCreatedBymePER.Text;
            _pageInstance.ChartsSharedWithMePER.Click();
            WaitForMoment(2);
            string _SharedWithMe= _pageInstance.ChartsSharedWithMePER.Text;
            _pageInstance.ChartsSearchPER.Click();
            return (PERsByPortFolio, CreatedByme, _SharedWithMe);

        }

        public string storyBoard()
        {
            _pageInstance.StoryboardsPER.Click();
            WaitForMoment(2);
           string createstoryBord= _pageInstance.CreatestoryboardPER.Text;
            _pageInstance.CreatestoryboardPER.Click();
            WaitForMoment(2);
            _pageInstance.CloseBoardPER.Click();
            return createstoryBord;
        }

        public string getFirstPERID()
        {
            string ab = _pageInstance.FirstPERId.Text;
            return _pageInstance.FirstPERId.Text;
        }

        public string TakeSearchText()
        {
            string ac = _pageInstance.SearchContains.Text;
            return ac;
        }

        public string searchRecord(string text)
        {
            _pageInstance.SearchBox.SendKeys(text);
            WaitForMoment(2);
            _pageInstance.SearchImage.Click();
            WaitForMoment(2);
            string searchedrecord = _pageInstance.RecordCount.Text;
            return searchedrecord;
        }

        public string validatePERScreen()
        {
            WaitForMoment(2);
            _pageInstance.CreateProposalButton.Click();
            WaitForMoment(2);
            string generInfoTab = _pageInstance.GeneralInfoTabPERScreen.Text;
            return generInfoTab;
        }

        public string reviewAndPostScreenValidation()
        {
            WaitForMoment(2);
            _pageInstance.InvoiceInBoxFirstRecordAction.Click();
            WaitForMoment(2);
            _pageInstance.PostInvoiceAction.Click();
            string reviewAndPostScreenText = _pageInstance.ReviewAndPostInvoice.Text;
            return reviewAndPostScreenText;
        }
        public (string ExpandOptio, string CollarationBetaOption, string DisplayInvoiceOption,string PostInvoiceeOption,string MarkasStatementOption,string MarkasReviewedOption,string DeleteInvoiceOption,string MarkasDuplicateeOption) DocumentAllAction()        
        {
            WaitForMoment(2);
            _pageInstance.InvoiceInBoxFirstRecordAction.Click();
            WaitForMoment(2);
            string ExpandOptio =_pageInstance.ExpandOptio.Text;
            string CollarationBetaOption =_pageInstance.CollarationBetaOption.Text;
            string DisplayInvoiceOption =_pageInstance.DisplayInvoiceOption.Text;
            string PostInvoiceeOption =_pageInstance.PostInvoiceeOption.Text;
            string MarkasStatementOption =_pageInstance.MarkasStatementOption.Text;
            string MarkasReviewedOption = _pageInstance.MarkasReviewedOption.Text;
            string DeleteInvoiceOption =_pageInstance.DeleteInvoiceOption.Text;
            string MarkasDuplicateeOption =_pageInstance.MarkasDuplicateeOption.Text;

            return (ExpandOptio, CollarationBetaOption, DisplayInvoiceOption, PostInvoiceeOption, MarkasStatementOption, MarkasReviewedOption, DeleteInvoiceOption, MarkasDuplicateeOption);

        }

        public string ParkJornalEntryButton()
        {
            WaitForMoment(2);
           string parkJournalEntry = _pageInstance.ParkJournalEntryButton.Text;
            return parkJournalEntry;
        }

    }
}
