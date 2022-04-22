using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class ProductReviewPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public ProductReviewPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement ProductListLbl => FindElement("XPath:.//*[contains(@Name,'Product List')]");
        public WindowsElement Justification => FindElement("XPath://Pane[@ClassName='ScrollViewer']//Edit[@ClassName='TextBox']");
        public WindowsElement TotalAmntLbl => FindElement("XPath://*[contains(@Name,'Total Amount')]/following-sibling::Text");
        public WindowsElement RequestQuoteBtn => FindElement("XPath:.//Button[contains(@Name,'Request Quote')]");
        public WindowsElement CancelBtn => FindElement("XPath:.//*[contains(@Name,'Cancel')]");
        public WindowsElement ApproveBtn => FindElement("XPath:.//Button[contains(@Name,'Approve')]");
        public WindowsElement RejectBtn => FindElement("XPath:.//*[contains(@Name,'Reject')]");
        public WindowsElement ApprovalComments => FindElement("XPath://Window[@Name='Pop-up']//Edit[@ClassName='TextBox']");
        public WindowsElement PopUpApproveBtn => FindElement("XPath://Window[@Name='Pop-up']//Button[@Name='Approve']");
        public WindowsElement PopUpRejectBtn => FindElement("XPath://Window[@Name='Pop-up']//Button[@Name='Reject']");
        public WindowsElement PopUpRecorrectionBtn => FindElement("XPath://Window[@Name='Pop-up']//Button[@Name='Request for correction']");
        public WindowsElement GeneratePDFBtn => FindElement("XPath:.//Button[contains(@Name,'Generate PDF') and contains(@AutomationId,'GeneratePDFBtn')]");
        //Generate PDF Pop up details
        public WindowsElement GeneratePDFPopUpTitle => FindElement("XPath:.//*[contains(@Name,'Generate PDF')]");
        public WindowsElement SalesOrg => FindElement("AccessibilityId:QuoteSalesPicker");
        public IList<WindowsElement> SalesOrgList(string salesOrgname)
        {
            return FindElements("XPath://*[@ClassName='ComboBoxItem']//Text");
        }
        public WindowsElement Language => FindElement("AccessibilityId:LanguagePicker");
        public IList<WindowsElement> LanguageList(string language)
        {
            return FindElements($"XPath://ListItem[@ClassName='ComboBoxItem']//Text[contains(@Name,'{language}')]");
        }
        public WindowsElement NotesForCustomer => FindElement("XPath://Window[@Name='Pop-up']//Edit[@ClassName='TextBox']");
        public WindowsElement DownloadBtn => FindElement("XPath://Button[contains(@Name,'Download')]");
        public IList<WindowsElement> DownloadToastMsg => FindElements("XPath://Text[@Name='Your Download is in progress'][@ClassName='TextBlock']");
        public IList<WindowsElement> SelectFolderPopUp => FindElements("XPath://Window[@Name='Select Folder'][@ClassName='#32770']");
        public WindowsElement FolderPath => FindElement("XPath://Window[@Name='Select Folder'][@ClassName='#32770']/Edit[@Name='Folder:'][@ClassName='Edit']");
        public WindowsElement SelectFolderBtn => FindElement("XPath://Button[@Name='Select Folder'][@ClassName='Button']");
        public IList<WindowsElement> DownloadedPDF(string customerName)
        {
            return FindElements($"XPath://Window[contains(@Name,'{customerName}')][@ClassName='AcrobatSDIWindow']");
        }
        public WindowsElement DownloadedToastMsg => FindElement("XPath://*[contains(@Name, 'PDF downloaded successfully!')]");
    }
}
