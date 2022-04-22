using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace West.EnterpriseUX.Automation.UWP.PageObjects
{
    public class CollaborationPage : BasePage
    {
        protected WindowsDriver<WindowsElement> _session;

        public CollaborationPage(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
        }
        public WindowsElement CollaborationTextBox => FindElement("AccessibilityId:searchEntry");
        public WindowsElement CollaborationSendButton => FindElement("XPath://Edit[@Name='Type a new message']/parent::Custom/following-sibling::Image[2]");
        public IList<WindowsElement> CollaborationRecentPostedMessage => FindElements("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Custom/Custom/Custom[3]/Text");       
        public WindowsElement CollaborationEditButton => FindElement("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Custom/Custom/Custom[2]/Image[3]");
        public IList<WindowsElement> CollaborationEditedTag => FindElements("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Custom/Custom/Custom[1]/Text[2]");
        public WindowsElement CollaborationEditSendButton => FindElement("XPath://Edit[@Name='Edit']/parent::Custom/following-sibling::Image[2]");
        public IList<WindowsElement> CollaborationDeleteButton => FindElements("XPath://Pane[@ClassName='ScrollViewer']/Custom/Custom/Custom/Custom/Custom/Custom[2]/Image[4]");
        public WindowsElement CollaborationReplyTextBox => FindElement("XPath://Edit[@Name='Send a reply']");
        public WindowsElement CollaborationReplySendButton => FindElement("XPath://Edit[@Name='Send a reply']/parent::Custom/following-sibling::Image[2]");
        public WindowsElement CollaborationInsightsIcon => FindElement("AccessibilityId:collaborationInsights");
        public IList<WindowsElement> InsightCollaborationImages => FindElements("AccessibilityId:Save");
        public IList<WindowsElement> SelectUserNames => FindElements($"XPath://List[contains(@AutomationId,'Recipient')]/ListItem/Custom/Text");
        public IList<WindowsElement> taggedEntityList => FindElements($"XPath://List[contains(@AutomationId,'TaggedEntity')]/ListItem/Custom/Text");

        public WindowsElement CollaborationReplyButton(string PostText)
        {
            return FindElement($"XPath://Text[contains(@Name,'{PostText}')]/parent::Custom/preceding-sibling::Custom/Image[contains(@AutomationId,'Reply')]");
        }
        public WindowsElement CollaborationReplyDeleteButton(string ReplyPostText)
        {
            return FindElement($"XPath://Text[contains(@Name,'{ReplyPostText}')]/parent::Custom/preceding-sibling::Custom/Image[3]");
        }
        public WindowsElement CollaborationLikeButton(string PostText)
        {
            return FindElement($"XPath://Text[contains(@Name,'{PostText}')]/parent::Custom/preceding-sibling::Custom/Image[contains(@AutomationId,'Like')]");
        }
        public IList<WindowsElement> CollaborationLikeCount(string PostText)
        {
            return FindElements($"XPath://Text[contains(@Name,'{PostText}')]/parent::Custom/preceding-sibling::Custom/Image[contains(@AutomationId,'Like')]/following-sibling::Text");
        }
        public WindowsElement RefreshIcon => FindElement("AccessibilityId:Refresh");


        public IList<WindowsElement> PeopleinvolvedNames(string UserName)
        {
            return FindElements($"XPath://Text[contains(@ClassName,'TextBlock') and contains(@Name,'{UserName}')]");
        }

        public IList<WindowsElement> TopHashTagNames(string UserName)
        {
            return FindElements($"XPath://Text[contains(@ClassName,'TextBlock') and contains(@Name,'{UserName}')]");
        }
    }
}
