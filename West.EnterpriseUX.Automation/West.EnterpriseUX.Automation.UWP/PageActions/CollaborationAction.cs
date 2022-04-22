using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CollaborationAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CollaborationPage _pageInstance;
        protected WebDriverWait wait;
        public CollaborationAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CollaborationPage(_session);
        }
        public void SendMessageInCollaboration(string PostText)
        {
            WaitForLoadingToDisappear();
            _pageInstance.CollaborationTextBox.Clear();
            _pageInstance.CollaborationTextBox.SendKeys(PostText);
            _pageInstance.CollaborationSendButton.Click();
            LogInfo($"Posted message is: {PostText}");

            ScrollVertically(index: 1);
            WaitForMoment(1);
        }
        public void VerifyMessageSent(string PostText)
        {
            ScrollByOffSet();
            IList<WindowsElement> RecentMessages = _pageInstance.CollaborationRecentPostedMessage;
            LogInfo($"Count of Recent Messages posted in feed: {RecentMessages.Count}");
            if (RecentMessages.Count > 0)
            {
                string PostTxt = PostText.Trim();
                IList<WindowsElement> NewlyPostedMessage = _pageInstance.GetElementByText(PostTxt);
                LogInfo($"Message posted in feed: {NewlyPostedMessage[0].Text}");
                if(NewlyPostedMessage.Count > 0)
                {
                    LogInfo($"Recent post Text is displayed as expected in feed");
                }
                else
                {
                    Assert.Fail($"Recent post Text is not displayed as expected in feed");
                }
            }
            else
            {
                Assert.Fail("Recent post is not displayed in feed");
            }
        }
        public void DeleteMessagesInCollaboration()
        {
            if(_pageInstance.CollaborationRecentPostedMessage.Count > 0)
            {
                IList<WindowsElement> deleteIcons;
                bool continueDelete = false;

                do
                {
                    deleteIcons = _pageInstance.CollaborationDeleteButton.Where(x => x.Displayed).ToList();
                    if (deleteIcons.Count > 0)
                    {
                        foreach (WindowsElement eachOption in deleteIcons)
                        {
                            MouseClickOnWindowsElement(eachOption);
                            deleteIcons = _pageInstance.CollaborationDeleteButton.Where(x => x.Displayed).ToList();
                            if (deleteIcons.Count > 0)
                            {
                                continueDelete = true;
                            }
                            else
                            {
                                continueDelete = false;
                            }
                        }
                    }
                    else
                    {
                        continueDelete = false;
                    }
                } while (deleteIcons.Count > 0 && continueDelete);
                LogInfo($"All messages in collaboration are deleted");
            }
            else
            {
                LogInfo($"No messages available in collaboration");
            }
        }
        public void VerifyMessageEdit(string PostText, string PostTextUpdated)
        {
            ScrollVertically(index: 1);
            IList<WindowsElement> NewlyPostedMessage = _pageInstance.GetElementByText(PostText);
            LogInfo($"Message posted in feed: {NewlyPostedMessage[0].Text}");
            if (NewlyPostedMessage.Count > 0)
            {
                _pageInstance.CollaborationEditButton.Click();
                _pageInstance.CollaborationTextBox.Clear();
                _pageInstance.CollaborationTextBox.SendKeys(PostTextUpdated);
                _pageInstance.CollaborationEditSendButton.Click();
                IList<WindowsElement> EditedTag = _pageInstance.CollaborationEditedTag;
                if(EditedTag.Count > 0)
                {
                    LogInfo($"Tag: {EditedTag[0].Text} displayed for updated message");
                }
                else
                {
                    Assert.Fail($"Edited Tag not displayed for updated message");
                }
            }
        }
        public void VerifyMessageDeleteFunctionality(string PostText)
        {
            IList<WindowsElement> NewlyPostedMessage = _pageInstance.GetElementByText(PostText);
            LogInfo($"Message posted in feed: {NewlyPostedMessage[0].Text}");
            if (NewlyPostedMessage.Count > 0)
            {
                _pageInstance.CollaborationDeleteButton[0].Click();

                String DeletePopup = "Collaboration Message Deleted Successfully";
                WaitForElementToAppear(DeletePopup);

                IList<WindowsElement> NewlyPostedMsg = _pageInstance.GetElementByText(PostText);
                if(NewlyPostedMsg.Count == 0)
                {
                    LogInfo($"Deleted message not present in feed");
                }
                else
                {
                    Assert.Fail($"Deleted message still displayed in feed");
                }
            }
        }
        public void VerifyMessageReply(string PostText, string ReplyPostText)
        {
            ScrollVertically(index: 1);
            IList<WindowsElement> NewlyPostedMessage = _pageInstance.GetElementByText(PostText);
            LogInfo($"Message posted in feed: {NewlyPostedMessage[0].Text}");
            if (NewlyPostedMessage.Count > 0)
            {
                _pageInstance.CollaborationReplyButton(PostText).Click();
                WaitForMoment(1);
                _pageInstance.CollaborationReplyTextBox.Clear();
                _pageInstance.CollaborationReplyTextBox.SendKeys(ReplyPostText);
                _pageInstance.CollaborationReplySendButton.Click();

                ScrollVertically(index: 1);
                ScrollByOffSet();

                //Verification of replied text message displayed or not.
                IList<WindowsElement> ActualRepliedPostText = _pageInstance.GetElementByText(ReplyPostText);
                if(ActualRepliedPostText.Count > 0)
                {
                    LogInfo($"Replied text message is present");
                    if(_pageInstance.CollaborationReplyDeleteButton(ReplyPostText).Displayed)
                    {
                        LogInfo($"Delete button for replied message is present");
                        _pageInstance.CollaborationReplyDeleteButton(ReplyPostText).Click();
                    }
                    else
                    {
                        Assert.Fail($"Delete button for replied message is not present");
                    }
                }
                else
                {
                    Assert.Fail($"Replied text message is not present");
                }
            }
        }

        public void VerifyCollaborationInsightFunctionality()
        {

            _pageInstance.CollaborationInsightsIcon.Click();

            if (_pageInstance.InsightCollaborationImages.Count > 0)
            {
                LogInfo($" {_pageInstance.InsightCollaborationImages.Count}: Insight is in expanded mode. TopHastags, PeopleInvolved details are displayed ");
            }
            else
            {
                Assert.Fail($"{_pageInstance.InsightCollaborationImages.Count}: Insight is failed to expand. TopHastags, PeopleInvolved details not displayed ");
            }

            _pageInstance.CollaborationInsightsIcon.Click();

            if (_pageInstance.InsightCollaborationImages.Count == 0)
            {
                LogInfo($" {_pageInstance.InsightCollaborationImages.Count}: after clicking on Insight icon, Insight is in Collapsed mode. TopHastags, PeopleInvolved details are hidden ");
            }
            else
            {
                Assert.Fail($"{_pageInstance.InsightCollaborationImages.Count}: after clicking on Insight icon, Insight is failed to Collapse");
            }
        }
        public void VerifyLikeAndUnLikeMessage(string PostText)
        {
            ScrollVertically(index: 1);
            IList<WindowsElement> NewlyPostedMessage = _pageInstance.GetElementByText(PostText);
            if (NewlyPostedMessage.Equals(null))
            {
                NewlyPostedMessage = _pageInstance.CollaborationLikeCount(PostText);
            }
            LogInfo($"Message posted in feed: {NewlyPostedMessage[0].Text}");
            if (NewlyPostedMessage.Count > 0)
            {
                //Verify Like count for liked post.
                _pageInstance.CollaborationLikeButton(PostText).Click();
                WaitForMoment(1);

                IList<WindowsElement> LikeCountText = _pageInstance.CollaborationLikeCount(PostText);
                if(LikeCountText.Equals(null))
                {
                    LikeCountText = _pageInstance.CollaborationLikeCount(PostText);
                }
                int LikeCount = int.Parse(LikeCountText[0].Text);
                if(LikeCount > 0)
                {
                    LogInfo($"Like count {LikeCountText[0].Text} displayed on page");
                }
                else
                {
                    Assert.Fail($"Like count not displayed on page");
                }

                //Verify un-Like functionality for post having no likes.
                _pageInstance.CollaborationLikeButton(PostText).Click();
                WaitForMoment(2);

                IList<WindowsElement> UnLikeCount = _pageInstance.CollaborationLikeCount(PostText);
                if (UnLikeCount.Count == 0)
                {
                    LogInfo($"Unlike functionality working as expected.");
                }
                else
                {
                    Assert.Fail($"Unlike functionality working as expected.");
                }
            }
            else
            {
                Assert.Fail($"Message not posted in feed");
            }
        }
        public void VerifyTagUserInCollaboration(String UserName)
        {
            _pageInstance.CollaborationTextBox.Clear();
            SplitAndEnterText(_pageInstance.CollaborationTextBox, UserName);
            WaitForMoment(2);

            IList<WindowsElement> Usernames =  _pageInstance.SelectUserNames;
             if(Usernames.Count > 0)
            {
                LogInfo($"Username {Usernames[0].Text} available in dropdlown list");
                Usernames[0].Click();
            }
            else
            {
                Assert.Fail($"No username available in dropdown list");
            }   
        }
        public void VerifyPeopleInvolvedInCollaboaration(string UserName)
        {
            VerifyTagUserInCollaboration("@"+UserName);
            _pageInstance.CollaborationSendButton.Click();
            WaitForMoment(2);
            VerifyMessageSent(UserName);
            _pageInstance.CollaborationInsightsIcon.Click();
            WaitForElementToAppear("People Involved");

            IList<WindowsElement> PeopleInvolvedNames = _pageInstance.PeopleinvolvedNames(UserName);
            LogInfo($"People Involved count: {PeopleInvolvedNames.Count}");
            if(PeopleInvolvedNames.Count > 0)
            {
                LogInfo($"Names of people tagged in collaboration feed {PeopleInvolvedNames[0].Text} are available under People Involved section");
            }
            else
            {
                Assert.Fail($"Names of people tagged in collaboration feed are not available under People Involved section");
            }
        }
        public void ClickReloadIcon()
        {           
            _pageInstance.RefreshIcon.Click();           
        }

        public void VerifyTopHashTagsInCollaboaration(string HashTagName)
        {
            //Navigate to comment text box and enter any Hashtag (E.g.- #Test ). And click Send icon
            SendMessageInCollaboration(HashTagName);
            WaitForMoment(2);

            //Click on Insight icon
            _pageInstance.CollaborationInsightsIcon.Click();
            WaitForElementToAppear("Top Hashtags");

            IList<WindowsElement> TopHashTagNames = _pageInstance.TopHashTagNames(HashTagName);           
            LogInfo($"Top HashTags count: {TopHashTagNames.Count}");
            if (TopHashTagNames.Count > 0)
            {
                LogInfo($" {TopHashTagNames[0].Text} is available under Top HashTags section");
            }
            else
            {
                Assert.Fail($"Names of Hashtag in collaboration feed are not available under Top HashTags section");
            }
        }
        
        public void VerifyEntityTagging()
        {
            _pageInstance.CollaborationTextBox.Clear();
            _pageInstance.CollaborationTextBox.SendKeys("^");
            WaitForMoment(15);
            if(_pageInstance.taggedEntityList.Count > 0)
            {
                LogInfo($"Number of entities available are {_pageInstance.taggedEntityList.Count}");
                string firstEntity = _pageInstance.taggedEntityList[0].Text;
                LogInfo($"Selected Entity name: {firstEntity}");
                _pageInstance.taggedEntityList[0].Click();
                _pageInstance.CollaborationSendButton.Click();
                WaitForMoment(3);
                VerifyMessageSent(firstEntity);
                LogInfo($"Tagged Entity present on feed");
            }
            else
            {
                Assert.Fail($"No entity available to tag");
            }
            
        }
    }
}
