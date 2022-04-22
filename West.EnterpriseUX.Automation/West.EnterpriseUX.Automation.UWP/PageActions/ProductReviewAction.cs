using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;
using Keys = OpenQA.Selenium.Keys;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class ProductReviewAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly ProductReviewPage _pageInstance;

        public ProductReviewAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new ProductReviewPage(_session);
        }
        public bool VerifyProductReviewPageDisplayed()
        {
            bool reviewPageDisplayed = Exists(_pageInstance.ProductListLbl);
            LogInfo("Product review page is displayed -" + reviewPageDisplayed);
            return reviewPageDisplayed;
        }
        public bool VerifyTotalAmount(string totAmt)
        {
            string QITotAmt = _pageInstance.TotalAmntLbl.GetAttribute("Name").Replace(",", "");
            bool verifyTotalAmount = QITotAmt.Contains(totAmt);
            LogInfo("The total amount matches with " + totAmt + " - " + verifyTotalAmount);
            return verifyTotalAmount;
        }
        public void EnterJustification(string justification)
        {
            ClickElement(_pageInstance.Justification);
            EnterText(_pageInstance.Justification, justification);
            LogInfo("Justification entered is - " + justification);
        }

        public void ClickOnRequestQuote()
        {
            ClickElement(_pageInstance.RequestQuoteBtn);
            LogInfo("Request quote button is clicked from the review page");
            WaitForMoment(5);
        }
        public void ClickOnApproveQuote()
        {
            _pageInstance.ApproveBtn.Click();
            LogInfo("Approve quote button is clicked from the review page");
        }
        public void ClickOnRejectQuote()
        {
            _pageInstance.RejectBtn.Click();
            LogInfo("Reject quote button is clicked from the review page");
        }
        public void ClickOnApproveInThePopUp()
        {
            _pageInstance.PopUpApproveBtn.Click();
            LogInfo("Approve quote button is clicked from the aproval pop up");
        }
        public void ClickOnRejectInThePopUp()
        {
            _pageInstance.PopUpRejectBtn.Click();
            LogInfo("Reject quote button is clicked from the aproval pop up");
        }
        public void ClickOnRecorrectionInThePopUp()
        {
            _pageInstance.PopUpRecorrectionBtn.Click();
            LogInfo("Request for recorrection button is clicked from the aproval pop up");
        }

        public void EnterTheApprovalComments(string notes)
        {
            _pageInstance.ApprovalComments.Click();
            WaitForMoment(2);
            _pageInstance.ApprovalComments.SendKeys(notes);
            LogInfo("The notes entered for customer is: " + notes);
        }

        public void ClickOnCancelButton()
        {
            _pageInstance.CancelBtn.Click();
        }
        public void ClickOnGeneratePDFButton()
        {
            ClickElement(_pageInstance.GeneratePDFBtn);
            WaitForMoment(3);
            LogInfo("Clicked on Generate PDF button in the review page");
        }
        public bool VerifyGeneratePDFPopupDisplayed()
        {
            bool generatePDFPopupDisplayed = _pageInstance.GeneratePDFPopUpTitle.Displayed;
            LogInfo("Generate PDF pop up is displayed - " + generatePDFPopupDisplayed);
            return generatePDFPopupDisplayed;
        }
        public void SelectSalesOrg(string salesOrgname)
        {
            EnterText(_pageInstance.SalesOrg, salesOrgname);
            LogInfo("Salesorg selected is - " + salesOrgname);
            WaitForMoment(2);
        }

        public void SlectLanguage(string language)
        {
            EnterText(_pageInstance.Language, language);
            LogInfo("language selected is - " + language);
            WaitForMoment(1);
        }
        public void EnterTheNotesForCustomer(string notes)
        {
            ClickElement(_pageInstance.NotesForCustomer);
            ClearElement(_pageInstance.NotesForCustomer);
            EnterText(_pageInstance.NotesForCustomer, notes);

            LogInfo("The notes entered for customer is: " + notes);
        }
        public void ClickOnDownloadBtn()
        {
            ClickElement(_pageInstance.DownloadBtn);
            LogInfo("Download button is clicked");
        }
        public bool VerifyDownloadToaster()
        {
            bool downloadToasterDisplayed;
            IList<WindowsElement> downloadToast = _pageInstance.DownloadToastMsg;
            if (downloadToast.Count > 0)
            {
                downloadToasterDisplayed = true;
                LogInfo("Downloadtoastmessage displayed");
            }
            else
            {
                downloadToasterDisplayed = false;
                LogInfo("Download toast message not displayed");
            }
            return downloadToasterDisplayed;
        }

        public bool SelectDownloadFolder(string folderPath)
        {
            bool isPresent = false;
            bool pdfDownloaded;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int timeout = 120;
            do
            {
                IList<WindowsElement> selectFolder = _pageInstance.SelectFolderPopUp;
                if (selectFolder.Count > 0)
                {
                    isPresent = selectFolder.Count > 0;
                }
                WaitForMoment(1);
            } while (!(isPresent || stopwatch.Elapsed.Seconds > timeout));
            if (isPresent)
            {
                _pageInstance.FolderPath.Click();
                _pageInstance.FolderPath.SendKeys(folderPath);
                _pageInstance.SelectFolderBtn.Click();
                pdfDownloaded = true;
                LogInfo("The PDF is downloaded in the folderpath : " + folderPath);
            }
            else
            {
                LogInfo("The PDF is not downloaded with in " + stopwatch.Elapsed.Seconds);
                pdfDownloaded = false;
            }
            stopwatch.Stop();
            return pdfDownloaded;
        }


        public bool VerifyDownloadedPDFOpens(string customerName)
        {
            bool isPresent = false;
            bool pdfOpened;
            Stopwatch stopwatch = new Stopwatch();
            int timeout = 120;
            do
            {
                IList<WindowsElement> DownloadedPDFs = _pageInstance.DownloadedPDF(customerName);
                if (DownloadedPDFs.Count > 0)
                {
                    isPresent = DownloadedPDFs.Count > 0;
                }
                else
                {
                    break;
                }
                WaitForMoment(1);
            } while (isPresent && stopwatch.Elapsed.Seconds < timeout);
            if (isPresent)
            {
                LogInfo("The PDF is downloaded and opened for the customer : " + customerName);
                pdfOpened = true;
            }
            else
            {
                LogInfo("The downloaded PDF didnt open with in " + stopwatch.Elapsed.Seconds);
                pdfOpened = false;
            }
            return pdfOpened;
        }
        public bool VerifyPDFDownloaded(int pdfcount, string folderpath)
        {
            if (CountNumFilesInTheFolder(folderpath, ".pdf") == (pdfcount + 1))
            {
                LogInfo("The PDF has been downloaded");
                return true;
            }
            else
            {
                LogInfo("The PDF has been downloaded");
                return false;
            }
        }
    }
}
