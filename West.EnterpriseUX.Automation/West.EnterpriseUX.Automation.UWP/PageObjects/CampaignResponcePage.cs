using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CampaignResponcePage :BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CampaignResponcePage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }

        public WindowsElement CreateCampaignResponce => FindElement("XPath:.//*[contains(@Name,'Create Campaign Response')]");
        public WindowsElement EditCampaignResponce => FindElement("XPath:.//*[contains(@Name,'Edit Campaign Response')]");
        public WindowsElement Subject => FindElement("XPath:.//*[contains(@Name,'Subject')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement Description => FindElement("XPath:.//*[contains(@Name,'Description')]/../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement RelatedCampaign => FindElement("XPath:.//*[contains(@Name,'Related Campaign')]/../../../following-sibling::*/*[contains(@Name,'Input Field')]");
        public WindowsElement ResponceType => FindElement("XPath:.//*[contains(@Name,'Response Type')]/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Channel => FindElement("XPath:.//*[contains(@Name,'Channel')]/../../../following-sibling::*//*[contains(@ClassName,'ComboBox')]");
        public WindowsElement Priority(string priority)
        {
            return FindElement($"XPath://*[contains(@Name,'{priority}')]");
        }

        public WindowsElement PromoCode => FindElement("XPath:.//*[contains(@Name,'Promo Code')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement OutsourcedVendor => FindElement("XPath:.//*[contains(@Name,'Outsourced Vendor')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement ReceivedFrom(string receivedFrom)
        {
            return FindElement($"XPath://*[contains(@Name,'{receivedFrom}')]");
        }

        
            public WindowsElement ProspectDropdown => FindElement("XPath:.//*[contains(@Name,'Prospect') or contains(@Name,'Contact')] /../../../following-sibling::*//*[contains(@ClassName,'TextBox')]");
        public WindowsElement Prospect => FindElement("XPath:.//*[contains(@Name,'Input Field')]");
        //public WindowsElement Prospect => FindElement("XPath:.//*[contains(@Name,'Prospect')]/../../../following-sibling::*//*[contains(@Name,'Input Field')]");
        public WindowsElement Phone => FindElement("XPath:.//*[contains(@Name,'Phone')]/../../../following-sibling::*/*[contains(@ClassName,'TextBox')]");
        public WindowsElement receiverInformation => FindElement("XPath:.//*[contains(@Name,'Receiver Information')]");
        public WindowsElement campaignInformation => FindElement("XPath:.//*[contains(@Name,'Campaign Information')]");
        public WindowsElement createButton => FindElement("XPath:.//*[contains(@Name,'Create') and contains(@ClassName,'Button')]");
        public WindowsElement UpdateWebFormButton => FindElement("XPath:.//Button[contains(@Name,'Update')]");
        public IList<WindowsElement> ValuebyRowAndColumnInGrid()
        {
            //return FindElement($"XPath://*[contains(@AutomationId,'{rowAndColumnInGrid}')] | //*[contains(@Name,'Row1')]//*[@ClassName='']");
            return FindElements($"XPath://*[@AutomationId=' Row1' or @Name=' Row1']/descendant::*[contains(@ClassName,'TextBlock')]");
        }
        
        public WindowsElement CampaignResponceTab => FindElement("XPath:.//*[contains(@Name,'Campaign Response') and contains(@AutomationId,'dashboardLabel')]");
    }
}
