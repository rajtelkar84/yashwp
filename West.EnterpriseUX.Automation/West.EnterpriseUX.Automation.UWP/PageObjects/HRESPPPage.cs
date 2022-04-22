using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class HRESPPPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public HRESPPPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public IList<WindowsElement> InboxList => FindElements("AccessibilityId:InboxName");

        public WindowsElement enrollButton => FindElement("XPath://Text[@Name='Enroll']");
        public IList<WindowsElement> moreImage => FindElements("AccessibilityId:More");
        public WindowsElement editAction => FindElement("XPath://Text[@Name='Edit']");
        public WindowsElement ESPPElectionImage => FindElement("XPath://*[@Name='ESPP Election']/../../parent::Custom/following-sibling::Custom/Custom/Custom/Custom/Image");
        public WindowsElement SearchInGrid => FindElement("XPath://*[@Name='Search']");
        public WindowsElement SearchButtonInSelectWindow => FindElement("XPath://*[@Name='Search']/preceding-sibling::Image");
        public WindowsElement SelectSearchValue(string searchValue)
        {
            return FindElement($"XPath://Text[@Name='{searchValue}']");
        }
        public WindowsElement AuthorizeCheckbox => FindElement("XPath://Text[contains(@Name,'I hereby authorize West Pharmaceutical')]/../CheckBox/Text");
        public WindowsElement ReadUnderstoodCheckbox => FindElement("XPath://Text[contains(@Name,' confirm that I have read, understand')]/preceding-sibling::*[@ClassName='CheckBox']/Text");
        //public WindowsElement SubmitButton => FindElement("XPath://Button[contains(@Name, 'Submit')]");
        public WindowsElement PopUpDialogMessage => FindElement("AccessibilityId:dialogMessage");
        public WindowsElement AcknowledgementOkButton => FindElement("AccessibilityId:okButton");
        public WindowsElement EstimatedAmountPerPayCheckEdit => FindElement("XPath://Text[@Name='Estimated Amount Per Paycheck']/following-sibling::Edit");
        public WindowsElement AuthorizeText => FindElement("XPath://Text[contains(@Name,'I hereby authorize West Pharmaceutical')]");
        public IList<WindowsElement> checkBoxAuthorize => FindElements("XPath://Text[contains(@Name,'I hereby authorize West Pharmaceutical')]/../*[@ClassName='CheckBox']");
        public WindowsElement SelectSearchValueContains(string searchValue)
        {
            return FindElement($"XPath://Text[contains(@Name,'{searchValue}')]");
        }
        public WindowsElement openInBrowserIcon => FindElement("AccessibilityId:UwpOpeninbrowserIcon");
        public IList<WindowsElement> percentageSliderText => FindElements("XPath://Text[contains(@Name,'Percentage Per Paycheck')]/following-sibling::Custom/Text");

        public WindowsElement percentageSliderThumb => FindElement("XPath://Text[contains(@Name,'Percentage Per Paycheck')]/following-sibling::Custom/Thumb");

        public WindowsElement percentageSelectedTab => FindElement("AccessibilityId:PercentageSelected tab");
        public WindowsElement selectedPercentageText=> FindElement("XPath://Text[contains(@Name,'Selected Percentage')]");



    }
}
