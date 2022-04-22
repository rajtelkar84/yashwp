using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class HomePage:BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public HomePage(WindowsDriver<WindowsElement> session):base(session)
        {
            this._session = session;
        }

        public WindowsElement LogoutButton => FindElement("Name:Logout");
        public IList<WindowsElement> LoggedInUser(string logedInUserName)
        {
            return FindElements($"XPath://*[@Name='{logedInUserName}']");
        }
        public WindowsElement BackButton => FindElement("AccessibilityId:Back");
        public IList<WindowsElement> InsightsFavourites => FindElements("AccessibilityId:Favourite");
        public IList<WindowsElement> FavouritesInboxes => FindElements("AccessibilityId:InboxFavourite");
        public WindowsElement KPIsAndCharts => FindElement("AccessibilityId:KPIs & Charts");
        public IList<WindowsElement> MenuName => FindElements("Name:Menu");
        public WindowsElement ConnectivityTab => FindElement("Name:Connectivity");
        public WindowsElement ConnectivityEnvironmentName => FindElement($"XPath://Text[contains(@AutomationId,'ConnectivityId')]");
        public WindowsElement ActionButton => FindElement($"XPath://*[@ClassName='SfButton']");
      
        public WindowsElement SearchForActionName => FindElement("Name:Search for action name");       
        public WindowsElement ActionPageTitle => FindElement("AccessibilityId:PageTitleLabel");
       public WindowsElement ToggleIcon => FindElement("AccessibilityId:PaneTogglePane");
        public IList<WindowsElement> TogglesText => FindElements("AccessibilityId:HeaderName");
       
        public WindowsElement SelectFunction(string function)
        {
            return FindElement($"XPath://ListItem[@ClassName='ListViewItem']//Text[@Name='{function}']");
        }
        public WindowsElement SelectPersona(string persona)
        {
            return FindElement($"XPath://Custom[@AutomationId='PersonaNameGrid']//*[@Name=\"{persona}\"]");
        }
        public IList<WindowsElement> VerifyInsightsKPI(string labelName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{labelName}')]");
        }
        public WindowsElement SelectMyAppsTab(string tabName)
        {
            return FindElement($"XPath://Text[@AutomationId='HeaderName' and @Name='{tabName}']");
        }
        public IList<WindowsElement> GetInboxToFavorite(string inboxName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{inboxName}')]/following-sibling::Custom/Image");
        }
        public IList<WindowsElement> GetInboxesName(string inboxName)
        {
            return FindElements($"XPath://Text[contains(@Name,'{inboxName}')]");
        }
        public IList<WindowsElement> Personas => FindElements($"XPath://Custom[@AutomationId='PersonaNameGrid']");
        public IList<WindowsElement> Inboxes => FindElements($"XPath://Text[@AutomationId='InboxName']");
        public IList<WindowsElement> FunctionLists => FindElements("XPath://ListItem[@Name='West.EnterpriseUX.Models.Functions.FunctionModel']//Custom//Custom//Custom//Text");
        public IList<WindowsElement> PersonasLists => FindElements("AccessibilityId:PersonaName");
        public IList<WindowsElement> InboxList => FindElements("XPath://Window[@AutomationId='PaneRoot']//Text[@AutomationId='InboxName']");
        public WindowsElement TermsOfUseLink => FindElement("Name:Terms of Use");
        
        public WindowsElement ViewProfileButton(string logedInUserName)
        {
            return FindElement($"XPath://*[contains(@Name,'{logedInUserName})']/../following-sibling::Image");
        }
        public WindowsElement ViewProfileButton()
        {
            return FindElement($"XPath://Window[@Name='Pop-up'][@ClassName='Popup']/Custom/Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Image");
        }
    }
}
