using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class CollaborationTest : BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Send Message Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324343_VerifySendMessageFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string PostText = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                PostText = "Sample text message from automation " + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.SendMessageInCollaboration(PostText);
                _collaborationAction.VerifyMessageSent(PostText);
                _collaborationAction.DeleteMessagesInCollaboration();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Edit Message Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324346_VerifyEditMessageFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string PostText = string.Empty;
                string PostTextUpdated = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                PostText = "Sample text message from automation " + uniqueNumber;
                PostTextUpdated = "This is updated text message from automation";

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.SendMessageInCollaboration(PostText);
                WaitForMoment(1);
                _collaborationAction.VerifyMessageEdit(PostText, PostTextUpdated);
                _collaborationAction.DeleteMessagesInCollaboration();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Delete Message Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324662_VerifyDeleteMessageFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string PostText = string.Empty;
                string PostTextUpdated = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                PostText = "Sample text message from automation " + uniqueNumber;
                PostTextUpdated = "This is updated text message from automation";

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.SendMessageInCollaboration(PostText);
                _collaborationAction.VerifyMessageSent(PostText);
                _collaborationAction.VerifyMessageDeleteFunctionality(PostText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Reply Message Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324670_VerifyReplyMessageFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string PostText = string.Empty;
                string ReplyPostText = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                PostText = "Sample text message from automation " + uniqueNumber;
                ReplyPostText = "This is replied text message from automation "+ uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.SendMessageInCollaboration(PostText);
                WaitForMoment(1);
                _collaborationAction.VerifyMessageReply(PostText, ReplyPostText);
                _collaborationAction.DeleteMessagesInCollaboration();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Tests Verify Insights functionality in Collaboration feature;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_324212_VerifyInsightsFunctionalityInCollaborationFeatureTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Navigate to Collaboration tab of first record
                _inboxAction.SelectDetailAction("Collaboration");

                //Verify Insights functionality in Collaboration
                _collaborationAction.VerifyCollaborationInsightFunctionality();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Like and unlike Message Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324344_VerifyLikeAndUnlikeMessageFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string PostText = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                PostText = "Sample text message from automation " + uniqueNumber;

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Navigate to All dashboard label.
                _inboxAction.SelectLabel("All");

                //Navigate to Collaboration tab of first record.
                _inboxAction.SelectDetailAction("Collaboration");

                //Delete old messages in collaboration if any.
                _collaborationAction.DeleteMessagesInCollaboration();

                //Send message in collaboration.
                _collaborationAction.SendMessageInCollaboration(PostText);
                WaitForMoment(1);

                //Verify like and unlike functionality for message in collaboration.
                _collaborationAction.VerifyLikeAndUnLikeMessage(PostText);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Tests Verify Reload functionality in Collaboration feature;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324220_VerifyReloadFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Navigate to All dashboard label.
                _inboxAction.SelectLabel("All");

                //Navigate to Collaboration tab of first record
                _inboxAction.SelectDetailAction("Collaboration");

                //Click on Reload icon
                _collaborationAction.ClickReloadIcon();

                //verify whether refreshing loader appearing on clicking on Collaboration Reload Icon - Loader appears only for fraction of secs, unable to locate the loader
                _homeAction.WaitForLoaderToDisappear();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify People Involved Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Collaboration_324241.csv", "Collaboration_324241#csv", DataAccessMethod.Sequential)]
        public void TC_324241_VerifyPeopleInvolvedFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string UserNameToTag = this.TestContext.DataRow["username"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.VerifyPeopleInvolvedInCollaboaration(UserNameToTag);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify User Tagging Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Collaboration_324241.csv", "Collaboration_324241#csv", DataAccessMethod.Sequential)]
        public void TC_324664_VerifyUserTaggingFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string UserNameToTag = this.TestContext.DataRow["username"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.VerifyTagUserInCollaboration("@" + UserNameToTag);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify HashTag Functionality In Collaboration;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Collaboration_324203.csv", "Collaboration_324203#csv", DataAccessMethod.Sequential)]
        public void TC_324203_VerifyHashTagFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string topHashTagName = this.TestContext.DataRow["topHashTagName"].ToString()+" ";

               
                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();

                //Verify HashTag functionality
                _collaborationAction.VerifyTopHashTagsInCollaboaration(topHashTagName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Entity Tagging Functionality In Collaboration;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Collaboration_324205.csv", "Collaboration_324205#csv", DataAccessMethod.Sequential)]
        public void TC_324205_VerifyEntityTaggingFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();                

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.VerifyEntityTagging();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("CollaborationTest")]
        [Description("Verify Posting Link Functionality In Collaboration;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_324233_VerifyPostingLinkFunctionalityInCollaborationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string postLink = "https://install.appcenter.ms/apps";

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.SelectDetailAction("Collaboration");
                _collaborationAction.DeleteMessagesInCollaboration();
                _collaborationAction.SendMessageInCollaboration(postLink);
                _collaborationAction.VerifyMessageSent(postLink);
                _collaborationAction.DeleteMessagesInCollaboration();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion
    }
}
