using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class CRMTest : BaseTest
    {

        #region LatestCRM

        #region Prospect

        [TestMethod]
        [Priority(1)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests create prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Prospect.csv", "CRM_Prospect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Prospect.csv")]
        public void TC_373305_ValidateCreateProspectFlow()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");

                _prospectsAction.SearchInbox(inbox);
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.VerifyCreatedDateAndProspectAge(" (0 Days)");
                _prospectsAction.EnterProspectMandatoryDetails(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email);
                //_prospectsAction.ClickCopyDetails();
                //_prospectsAction.VerifyFieldsAfterClickingOnCopyDetails("abcd@west.com", "St1", "St2", "St3", "Banglore", "India", "Andhra Pradesh", "1234567", "0987654321", "www.west.com");
                _prospectsAction.ClickCreateButton();
                _prospectsAction.EnterProspectOtherDetails(prospectOwner, addressLine1, addressLine2, addressLine3, cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website,
                  regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickEngagedButton();
                _prospectsAction.VerifyProspectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                 cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.SaveAndCloseButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox(firstName1, lastName, jobFunction, prospectOwner, "Engaged ", jobTitle, countryValue, companyName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(2)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests edit prospect displayed in the inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Prospect.csv", "CRM_Prospect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Prospect.csv")]
        public void TC_374381_ValidateEditProspectIsDisplayedInTheInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");

                _prospectsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_373305_ValidateCreateProspectFlow();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnEditProspects();
                _prospectsAction.VerifyProspectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                 cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.EditProspectDetails(firstName1, lastName);
                _prospectsAction.SaveAndCloseButton();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox(lastName, firstName1, jobFunction, prospectOwner, "Engaged ", jobTitle, countryValue, companyName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(3)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests Qualify prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_QualifyProspect.csv", "CRM_QualifyProspect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_QualifyProspect.csv")]
        public void TC_381905_ValidateQualifyProspect()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();

                _prospectsAction.SearchInbox(inbox);
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.VerifyCreatedDateAndProspectAge(" (0 Days)");
                _prospectsAction.EnterProspectDetails(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                   cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickCreateButton();
                _prospectsAction.ClickEngagedButton();
                _prospectsAction.ClickWorkingButton();
                _prospectsAction.VerifyProspectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                  cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickUpdateProspect();
                _prospectsAction.QualifyProspect();
                _prospectsAction.VerifyLeadPageAfterQualifingProspect(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3, cityInfo,
                    countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails);
                _leadsAction.EnterTopic(topic);
                _prospectsAction.SaveAndCloseButton();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox(firstName1, lastName, jobFunction, prospectOwner, "Close-Qualify", jobTitle, countryValue, companyName);
                _prospectsAction.SearchInbox("Leads (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName1, lastName, cityInfo, jobTitle, jobFunction, prospectOwner, "Assigned ", topic, companyName, countryValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(4)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests View Qualify Prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_QualifyProspect.csv", "CRM_QualifyProspect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_QualifyProspect.csv")]
        public void TC_472230_ValidateViewQualifiedProspect()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["dqr"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");

                _prospectsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_381905_ValidateQualifyProspect();
                    _prospectsAction.SearchInbox(inbox);
                    _inboxAction.SelectSearchOption(searchOption);
                    _inboxAction.EnterSearchValueInGrid(firstName1);
                    _inboxAction.ClickOnSearchButton();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnViewProspects();
                _prospectsAction.ValidateViewPropsectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3, cityInfo,
                    countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, "Close-Qualify", comment);
                _prospectsAction.VerifyConvertedToAndDate("Lead");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(5)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests Disqualify prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyProspect.csv", "CRM_DisqualifyProspect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyProspect.csv")]
        public void TC_392853_ValidateDisQualifyProspect()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["dqr"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _prospectsAction.SearchInbox(inbox);
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.VerifyCreatedDateAndProspectAge(" (0 Days)");
                _prospectsAction.EnterProspectDetails(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                   cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickCreateButton();
                _prospectsAction.ClickEngagedButton();
                _prospectsAction.ClickWorkingButton();
                _prospectsAction.VerifyProspectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                  cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickUpdateProspect();
                _prospectsAction.DisqualifyProspect(disQualifyReason, otherstext);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox(firstName1, lastName, jobFunction, prospectOwner, "Close-Disqualify", jobTitle, countryValue, companyName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(6)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests View Disqualify Prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyProspect.csv", "CRM_DisqualifyProspect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyProspect.csv")]
        public void TC_392855_ValidateViewDisqualifiedProspect()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["dqr"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");

                _prospectsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_392853_ValidateDisQualifyProspect();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnViewProspects();
                _prospectsAction.ValidateViewPropsectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3, cityInfo,
                    countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, "Close-Disqualify", comment);
                _prospectsAction.VerifyDisqualifyReason(otherstext);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(7)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests Reopen prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyProspect.csv", "CRM_DisqualifyProspect#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyProspect.csv")]
        public void TC_381911_ValidateReopenProspect()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameProspect"].ToString();
                string lastName = this.TestContext.DataRow["lastNameProspect"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string prospectOwner = this.TestContext.DataRow["prosOwn"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");

                _prospectsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_392853_ValidateDisQualifyProspect();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnReOpenProspects();
                _prospectsAction.ClickOnReOpenProspectsConfirmation();
                _prospectsAction.VerifyProspectPage(salutation, firstName1, lastName, prospectOwner, companyName, jobTitle, jobFunction, email, addressLine1, addressLine2, addressLine3,
                 cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ProspectStatus("Assigned");
                LogInfo("Verified all the fields in reopen prospect page");
                _prospectsAction.ClickBackButton();
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox(firstName1, lastName, jobFunction, prospectOwner, "Assigned", jobTitle, countryValue, companyName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Contact

        [TestMethod]
        [Priority(8)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests Create New Contact functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_398413_ValidateCreateContactFlow()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _contactsAction.SearchInbox(inbox);
                _contactsAction.ClickOnCreateContacts();
                //_contactsAction.ClickCopyDetails();
                //_contactsAction.VerifyFieldsAfterClickingOnCopyDetails(email, addressLine1, addressLine2, addressLine3, cityInfo, countryValue, stateValue, zip, phoneNumber1, website);
                _contactsAction.EnterContactDetails(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email1, contOwner, account, addressLine1, addressLine2, addressLine3, cityInfo,
                    countryValue, stateValue, phoneCode1, phoneNumber1, phoneCode2, phoneNumber2, zip, website, regionValue, channel, channelDetails, comment);
                _contactsAction.ClickToggleSwitchs();
                //_contactsAction.EnterTranslateContactDetails(translate, salutation, firstName, lastName, website, addressLine1, addressLine2, addressLine3, companyName, jobTitle, jobFunction, email,
                //  cityInfo, countryValue, stateValue, zip, phoneNumber1, phoneNumber2);
                _contactsAction.ClickOnCreateContactsButton();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(firstName1, lastName, email1, addressLine1, cityInfo, jobTitle, jobFunction, contOwner);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(9)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests Edit contact in the inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_398441_ValidateEditContactIsDisplayedInTheInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _contactsAction.SearchInbox(inbox);
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_398413_ValidateCreateContactFlow();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _contactsAction.ClickOnEditContacts();
                _contactsAction.VerifyContactPage(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email1, contOwner, addressLine1, addressLine2, addressLine3, cityInfo, countryValue,
                    stateValue, phoneCode1, phoneNumber1, phoneCode2, phoneNumber2, zip, website, regionValue, channel, channelDetails, comment);
                _contactsAction.EditContactDetails(firstName1, lastName);
                _contactsAction.ClickOnUpdateButton();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(lastName, firstName1, email1, addressLine1, cityInfo, jobTitle, jobFunction, contOwner);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(10)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Opportunity from Contact")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_398483_ValidateCreateOpportunityFromContact()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");

                _contactsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_398441_ValidateEditContactIsDisplayedInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _contactsAction.ClickOnCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _contactsAction.ValidateOpportunityPage(regionValue);
                _opportunityAction.EnterOpportuityName(opportunityName);
                _opportunityAction.SelectProjectedCloseDate("10");
                String companyName1 = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickSaveAndClose();
                WaitForMoment(2);
                _contactsAction.ClickOnRefreshData();
                _contactsAction.SearchInbox("Opportunities (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, companyName1, "Definition", "0", contOwner, "Open");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(11)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Contact from Lead")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_452969_ValidateCreateLeadFromContact()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");

                _contactsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_398441_ValidateEditContactIsDisplayedInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _contactsAction.ClickOnCreateLead();
                _contactsAction.VerifyLeadPage(" (0 Days)", salutation, lastName, firstName1, contOwner, companyName, jobTitle, jobFunction, email1, addressLine1, addressLine2, addressLine3, cityInfo,
                    countryValue, stateValue, phoneCode1, phoneNumber1, zip, website, regionValue, channel, channelDetails);
                _leadsAction.EnterTopic("topic");
                _leadsAction.ClickToggleSwitchs();
                _leadsAction.ClickOnCreateButton();
                _opportunityAction.ClickSaveAndClose();
                WaitForMoment(2);
                _contactsAction.ClickOnRefreshData();
                _contactsAction.SearchInbox("Leads (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(lastName, firstName1, cityInfo, jobTitle, jobFunction, contOwner, "Assigned ", "topic", companyName, countryValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(12)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Contact from Meeting Report")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_453693_ValidateCreateContactFromMeetingReport()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + "MeetingReport" + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + "MeetingReport" + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _contactsAction.SearchInbox("Meeting Report (Sales)");
                _meetingReportAction.ClickCreateMeetingReport();
                _meetingReportAction.SelectCompany();
                _meetingReportAction.ClickCreateContact();
                _homeAction.VerifyActionPageTitle("Contact");
                _contactsAction.VerifyCompanyNameField();
                _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName1, lastName, jobTitle, jobFunction, email1, contOwner, addressLine1, cityInfo);
                _contactsAction.ClickOnCreateContactsButton();
                _homeAction.VerifyActionPageTitle("Meeting Report");
                _prospectsAction.ClickBackButton();
                WaitForMoment(3);
                _contactsAction.ClickOnRefreshData();
                _contactsAction.SearchInbox("Contacts (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(firstName1, lastName, email1, addressLine1, cityInfo, jobTitle, jobFunction, contOwner);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(13)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Contact from Case")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_453699_ValidateCreateContactFromCase()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + "Case" + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + "Case" + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _homeAction.ClickOnFunction("Sales");
                _homeAction.ClickOnPersona("Sales");
                _homeAction.ClickOnPersona("Technical Customer Service");
                _inboxAction.ClickInbox("Cases");
                _casesAction.ClickOnCreateCase();
                _casesAction.SelectAccount("");
                _casesAction.ClickCreateContact();
                _homeAction.VerifyActionPageTitle("Contact");
                _contactsAction.VerifyCompanyNameField();
                _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName1, lastName, jobTitle, jobFunction, email1, contOwner, addressLine1, cityInfo);
                _contactsAction.ClickOnCreateContactsButton();
                _homeAction.VerifyActionPageTitle("Case");
                _prospectsAction.ClickBackButton();
                WaitForMoment(3);
                _contactsAction.ClickOnRefreshData();
                _contactsAction.SearchInbox("Contacts (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(firstName1, lastName, email1, addressLine1, cityInfo, jobTitle, jobFunction, contOwner);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(14)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Contact from Opportunity")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_401202_ValidateCreateContactFromOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string lastName = this.TestContext.DataRow["lastNameContact"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["JobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["JobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string contOwner = this.TestContext.DataRow["contOwn"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string addressLine1 = this.TestContext.DataRow["add1"].ToString();
                string addressLine2 = this.TestContext.DataRow["add2"].ToString();
                string addressLine3 = this.TestContext.DataRow["add3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phoneCode1 = this.TestContext.DataRow["phonecode1"].ToString();
                string phoneNumber1 = this.TestContext.DataRow["phoneNumber1"].ToString();
                string phoneCode2 = this.TestContext.DataRow["phonecode2"].ToString();
                string phoneNumber2 = this.TestContext.DataRow["phoneNumber2"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionValue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string translate = this.TestContext.DataRow["translate"].ToString();
                string firstName1 = firstName + "Opportunity" + DateTime.UtcNow.ToString("ddMMyy");
                string email1 = DateTime.UtcNow.ToString("ddMMyy") + "Opportunity" + email;
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _opportunityAction.SearchInbox("Opportunities (Sales)");
                _opportunityAction.ClickCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.SelectAccountName();
                _opportunityAction.ClickCreateContact();
                _homeAction.VerifyActionPageTitle("Contact");
                _contactsAction.VerifyCompanyNameField();
                _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName1, lastName, jobTitle, jobFunction, email1, contOwner, addressLine1, cityInfo);
                _contactsAction.ClickOnCreateContactsButton();
                _homeAction.VerifyActionPageTitle("Opportunity");
                _prospectsAction.ClickBackButton();
                WaitForMoment(3);
                _contactsAction.SearchInbox("Contacts (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(firstName1, lastName, email1, addressLine1, cityInfo, jobTitle, jobFunction, contOwner);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(15)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Validate Deactivate Contact")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Contact.csv", "CRM_Contact#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Contact.csv")]
        public void TC_447316_ValidateDeactivateContact()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string firstName = this.TestContext.DataRow["firstNameContact"].ToString();
                string firstName1 = firstName + "Opportunity" + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _contactsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_401202_ValidateCreateContactFromOpportunity();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _contactsAction.ClickOnDeactivateContact();
                _contactsAction.ClickOnYes();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                Assert.IsTrue(_inboxAction.CheckDataNotAvailable());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Lead

        [TestMethod]
        [Priority(16)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests to create new Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Lead.csv", "CRM_Lead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Lead.csv")]
        public void TC_374386_ValidateCreateLeadFlow()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.VerifyCreatedDateAndAge(" (0 Days)");
                _leadsAction.EnterLeadMandatoryDetails(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email, topic);
                //_leadsAction.ClickCopyDetails();
                //_leadsAction.VerifyFieldsAfterClickingOnCopyDetails("abcd@west.com", "St1", "St2", "St3", "Banglore", "India", "Andhra Pradesh", "1234567", "0987654321", "www.west.com");
                _leadsAction.ClickOnCreateButton();
                _leadsAction.EnterLeadOtherDetails(leadOwner, address1, address2, address3, cityInfo, countryValue, stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _leadsAction.ClickToggleSwitchs();
                _leadsAction.ClickOnEngagedButton();
                _leadsAction.VerifyLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                    stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _leadsAction.ClickOnSaveAndCloseButton();
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName1, lastName, cityInfo, jobTitle, jobFunction, leadOwner, "Engaged ", topic, companyName, countryValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(17)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests create contact from lead inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Lead.csv", "CRM_Lead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Lead.csv")]
        public void TC_454566_CreateContactFromLeadInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();


                _leadsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_374386_ValidateCreateLeadFlow();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.CreateContactFromLeadInbox();
                _contactsAction.VerifyContactPageCreatedFromLeadInbox(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email, leadOwner, address1, address2, address3, cityInfo, countryValue,
                  stateValue, phoneNumber, zip, website, regionvalue, channel, channelDetails);
                _contactsAction.ClickOnUpdateButton();
                _prospectsAction.ClickBackButton();
                _opportunityAction.ClickOnRefreshData();
                _contactsAction.SearchInbox("Contacts (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox(firstName1, lastName, email, address1, cityInfo, jobTitle, jobFunction, leadOwner);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(18)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests edit lead in the inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Lead.csv", "CRM_Lead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Lead.csv")]
        public void TC_374389_ValidateEditLeadIsDisplayedInTheInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_374386_ValidateCreateLeadFlow();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.EditLead();
                _leadsAction.VerifyLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                    stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _leadsAction.EditLeadDetails(firstName1, lastName);
                _leadsAction.ClickOnSaveAndCloseButton();
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(lastName, firstName1, cityInfo, jobTitle, jobFunction, leadOwner, "Engaged ", topic, companyName, countryValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(19)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests Qualify Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_QualifyLead.csv", "CRM_QualifyLead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_QualifyLead.csv")]
        public void TC_382124_ValidateQualifyLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");

                _leadsAction.SearchInbox(inbox);
                WaitForMoment(2);
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.VerifyCreatedDateAndAge(" (0 Days)");
                _leadsAction.EnterLeadDetails(salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue, stateValue,
                    phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment, topic);
                _leadsAction.ClickToggleSwitchs();
                _leadsAction.ClickOnCreateButton();
                _leadsAction.ClickOnEngagedButton();
                _leadsAction.ClickOnWorkingButton();
                _leadsAction.VerifyLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                  stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _leadsAction.ClickOnUpdateButton();
                _leadsAction.QualifyLead();
                _opportunityAction.ClickOverViewExpandICon();
                _leadsAction.ValidateOpportunityPage(regionvalue, companyName);
                _opportunityAction.EnterOpportuityName(opportunityName);
                _opportunityAction.SelectProjectedCloseDate("25");
                _opportunityAction.EnterOpportunityOwnerFromLead(leadOwner);
                _prospectsAction.SaveAndCloseButton();
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName1, lastName, cityInfo, jobTitle, jobFunction, leadOwner, "Qualified", topic, companyName, countryValue);
                _leadsAction.SearchInbox("Opportunities (Sales)");
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, companyName, "Definition", "0", leadOwner, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(20)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests View Qualifiy Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_QualifyLead.csv", "CRM_QualifyLead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_QualifyLead.csv")]
        public void TC_472243_ValidateViewQualifiedLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["disQualifyReason"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_382124_ValidateQualifyLead();
                    _leadsAction.SearchInbox(inbox);
                    _inboxAction.SelectSearchOption(searchOption);
                    _inboxAction.EnterSearchValueInGrid(firstName1);
                    _inboxAction.ClickOnSearchButton();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.ClickOnViewLead();
                _leadsAction.VerifyViewLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                   stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, "Close-Qualify", comment);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(21)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests Disqualify Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyLead.csv", "CRM_DisqualifyLead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyLead.csv")]
        public void TC_382125_ValidateDisQualifyLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["disQualifyReason"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                WaitForMoment(2);
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.VerifyCreatedDateAndAge(" (0 Days)");
                _leadsAction.EnterLeadDetails(salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue, stateValue,
                    phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment, topic);
                _leadsAction.ClickToggleSwitchs();
                _leadsAction.ClickOnCreateButton();
                _leadsAction.ClickOnEngagedButton();
                _leadsAction.ClickOnWorkingButton();
                _leadsAction.VerifyLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                    stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _leadsAction.ClickOnUpdateButton();
                _leadsAction.DisqualifyLead(disQualifyReason, otherstext);
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName1, lastName, cityInfo, jobTitle, jobFunction, leadOwner, "Disqualified", topic, companyName, countryValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(22)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests View Disqualify Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyLead.csv", "CRM_DisqualifyLead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyLead.csv")]
        public void TC_403931_ValidateViewDisqualifiedLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["disQualifyReason"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_382125_ValidateDisQualifyLead();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.ClickOnViewLead();
                _leadsAction.VerifyViewLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                   stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, "Close-Disqualify", comment);
                _leadsAction.VerifyDisqualifyReasonField(disQualifyReason);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(23)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests Reopen Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_DisqualifyLead.csv", "CRM_DisqualifyLead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_DisqualifyLead.csv")]
        public void TC_382126_ValidateReopenLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string leadOwner = this.TestContext.DataRow["leadOwner"].ToString();
                string address1 = this.TestContext.DataRow["address1"].ToString();
                string address2 = this.TestContext.DataRow["address2"].ToString();
                string address3 = this.TestContext.DataRow["address3"].ToString();
                string cityInfo = this.TestContext.DataRow["cityInfo"].ToString();
                string countryValue = this.TestContext.DataRow["countryValue"].ToString();
                string stateValue = this.TestContext.DataRow["stateValue"].ToString();
                string phonecode = this.TestContext.DataRow["phonecode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string regionvalue = this.TestContext.DataRow["regionvalue"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string channelDetails = this.TestContext.DataRow["channelDetails"].ToString();
                string comment = this.TestContext.DataRow["comment"].ToString();
                string disQualifyReason = this.TestContext.DataRow["disQualifyReason"].ToString();
                string otherstext = this.TestContext.DataRow["otherstext"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + DateTime.UtcNow.ToString("ddMMyy");
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();

                _leadsAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_382125_ValidateDisQualifyLead();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.ReopenLead();
                _leadsAction.VerifyLeadPage(topic, salutation, firstName1, lastName, leadOwner, companyName, jobTitle, jobFunction, email, address1, address2, address3, cityInfo, countryValue,
                   stateValue, phonecode, phoneNumber, zip, website, regionvalue, channel, channelDetails, comment);
                _prospectsAction.ClickBackButton();
                _opportunityAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(firstName1);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName1, lastName, cityInfo, jobTitle, jobFunction, leadOwner, "Assigned ", topic, companyName, countryValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(24)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests create contact from lead of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Lead.csv", "CRM_Lead#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Lead.csv")]
        public void TC_403958_CreateContactFromLead()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + "Contact" + this.TestContext.DataRow["email"].ToString();
                string account = this.TestContext.DataRow["acc"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string firstName1 = firstName + "Contact from" + DateTime.UtcNow.ToString("ddMMyy");

                _leadsAction.SearchInbox(inbox);
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.VerifyCreatedDateAndAge(" (0 Days)");
                _leadsAction.EnterLeadMandatoryDetails(salutation, firstName1, lastName, companyName, jobTitle, jobFunction, email, topic);
                _leadsAction.ClickOnCreateButton();
                _leadsAction.ClickOnEngagedButton();
                _leadsAction.ClickOnWorkingButton();
                _leadsAction.ClickOnUpdateButton();
                _leadsAction.CreateContact();
                _contactsAction.VerifyContactMandatoryFields(salutation, firstName1, lastName, jobTitle, jobFunction, email);
                _contactsAction.ClickOnCreateContactsButton();
                _leadsAction.ClickOnUpdateButton();
                _leadsAction.ClickOnUpdateButton();
                _leadsAction.VerifyQualifyPopupHeader();
                _leadsAction.SearchCreatedContact(firstName1, lastName);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Cases

        [TestMethod]
        [Priority(25)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests create new Case functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_455590_ValidateCreateCase()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _casesAction.ClickOnCreateCase();
                _casesAction.CaseDetails(title, account, contact, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation);
                _casesAction.EnterDescriptionOrAdditionalInformation(additionalInformation);
                _casesAction.ClickSubmit();
                _casesAction.ValidateCaseData(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                _casesAction.AddCase();
                _casesAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(26)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Edit Case functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_445968_ValidateEditCaseInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string title1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["title"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    _homeAction.ClickOnFunction("Home");
                    TC_455590_ValidateCreateCase();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickEditCase();
                _casesAction.ValidateCaseData(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                _casesAction.EnterTitle(title1);
                _casesAction.ClickLowPriority();
                _casesAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(27)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Resolve Case and View Resolved Case functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_445969_ValidateResolveCaseInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string title1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["title"].ToString();
                string resolvedOn = this.TestContext.DataRow["resolvedOn"].ToString();
                string totalTime = this.TestContext.DataRow["totalTime"].ToString();
                string timeUnit = this.TestContext.DataRow["timeUnit"].ToString();
                string resolutionRemarks = this.TestContext.DataRow["resolutionRemarks"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");
                }
                catch (Exception)
                {
                    _homeAction.ClickOnFunction("Home");
                    TC_445968_ValidateEditCaseInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickResolveCase();
                _casesAction.ResolvedOn(resolvedOn);
                _casesAction.EnterTotalTime(totalTime);
                _casesAction.TimeUnit(timeUnit);
                _casesAction.EnterResolutionRemarks(resolutionRemarks);
                _casesAction.ClickResolve();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "Resolved");
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickViewCase();
                _casesAction.ValidateCaseData(title1, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "Resolved");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                //_casesAction.VerifyCaseClassification();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(28)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Reopen Case functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_445970_ValidateReopenCaseInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string title1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["title"].ToString();
                string reopenCaseStatus = this.TestContext.DataRow["reopenCaseStatus"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "Resolved");
                }
                catch (Exception)
                {
                    _homeAction.ClickOnFunction("Home");
                    TC_445969_ValidateResolveCaseInTheInbox();
                    _prospectsAction.ClickBackButton();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickReopenCase();
                _casesAction.ValidateCaseData(title1, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                //_casesAction.VerifyCaseClassification();
                _prospectsAction.SaveAndCloseButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, reopenCaseStatus);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(29)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Cancel Case and View Cancelled case functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_445971_ValidateCancelCaseInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string title1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["title"].ToString();
                string cancelCaseStatus = this.TestContext.DataRow["cancelCaseStatus"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");

                }
                catch (Exception)
                {
                    _homeAction.ClickOnFunction("Home");
                    TC_445970_ValidateReopenCaseInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickCancelCase();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title1);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title1, "Low", origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, cancelCaseStatus);
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickViewCase();
                _casesAction.ValidateCaseData(title1, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, cancelCaseStatus);
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                //_casesAction.VerifyCaseClassification();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(30)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests To Validate Case classifications under Case child inbox functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_474107_ValidateCaseclassificationsUnderCaseChildInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + "Classification" + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _casesAction.ClickOnCreateCase();
                _casesAction.CaseMandatoryDetails(title, account, contact, origin, productOrigin, caseInvolvement);
                _casesAction.ClickSubmit();
                _casesAction.AddMultipleCase(2);
                List<string> caseDetails = _casesAction.caseTypeDetails();
                int startIndex = caseDetails.IndexOf(_casesAction.CCData("R1C0"));
                _casesAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Case Classification");
                _customerAction.VerifyChildInboxCount("Case Classification", "3");
                /*Assert.AreEqual(caseDetails[startIndex], _casesAction.CCDataInChildInbox("R1C3"));
                Assert.AreEqual(caseDetails[startIndex+1], _casesAction.CCDataInChildInbox("R1C4"));
                Assert.AreEqual(caseDetails[startIndex+3], _casesAction.CCDataInChildInbox("R2C3"));
                Assert.AreEqual(caseDetails[startIndex+4], _casesAction.CCDataInChildInbox("R2C4"));
                Assert.AreEqual(caseDetails[startIndex+6], _casesAction.CCDataInChildInbox("R3C3"));
                Assert.AreEqual(caseDetails[startIndex+7], _casesAction.CCDataInChildInbox("R3C4"));*/
                LogInfo("Verified Case Child Inbox");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(31)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Validate resolve case with daikyo product without case description functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_475373_ValidateResolveCaseWithDaikyoProductWithoutCaseDescription()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + "Diakyo" + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string resolvedOn = this.TestContext.DataRow["resolvedOn"].ToString();
                string totalTime = this.TestContext.DataRow["totalTime"].ToString();
                string timeUnit = this.TestContext.DataRow["timeUnit"].ToString();
                string resolutionRemarks = this.TestContext.DataRow["resolutionRemarks"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _casesAction.ClickOnCreateCase();
                _casesAction.CaseDetails(title, account, contact, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation);
                _casesAction.ClickSubmit();
                _casesAction.AddCase();
                _casesAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickResolveCase();
                _casesAction.ResolveCase(resolvedOn, totalTime, timeUnit, resolutionRemarks);
                _casesAction.VerifyResolveCaseDialogueMesssage(productOrigin);
                _casesAction.ClickOnAddDescription();
                _casesAction.ValidateCaseData(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.EnterDescriptionOrAdditionalInformation(additionalInformation);
                _casesAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickResolveCase();
                _casesAction.ResolvedOn(resolvedOn);
                _casesAction.EnterTotalTime(totalTime);
                _casesAction.TimeUnit(timeUnit);
                _casesAction.EnterResolutionRemarks(resolutionRemarks);
                _casesAction.ClickResolve();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "Resolved");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(32)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Validate Create Case from Contact functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_488175_ValidateCreateCaseFromContact()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + " Contact " + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string resolvedOn = this.TestContext.DataRow["resolvedOn"].ToString();
                string totalTime = this.TestContext.DataRow["totalTime"].ToString();
                string timeUnit = this.TestContext.DataRow["timeUnit"].ToString();
                string resolutionRemarks = this.TestContext.DataRow["resolutionRemarks"].ToString();

                _contactsAction.SearchInbox("Contacts (Sales)");
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickCreateCaseInDA();
                _casesAction.VerifyAccountAndContactIsAutoPopulated();
                _casesAction.EnterCaseDetailsFromContact(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign);
                _casesAction.EnterDescriptionOrAdditionalInformation(additionalInformation);
                _casesAction.ClickSubmit();
                _casesAction.ValidateCaseData(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                _casesAction.AddCase();
                _casesAction.ClickSaveAndClose();
                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "In Progress");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(33)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests Resolve Case from Case Page functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Cases.csv", "CRM_Cases#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Cases.csv")]
        public void TC_490784_ValidateResolveCaseFromCasePage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona1 = this.TestContext.DataRow["persona1"].ToString();
                string persona2 = this.TestContext.DataRow["persona2"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string title = "Resolve "+this.TestContext.DataRow["title"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string account = this.TestContext.DataRow["account"].ToString();
                string contact = this.TestContext.DataRow["contact"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvement = this.TestContext.DataRow["caseInvolvement"].ToString();
                string caseOwner = this.TestContext.DataRow["caseOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string additionalInformation = this.TestContext.DataRow["additionalInformation"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string resolvedOn = this.TestContext.DataRow["resolvedOn"].ToString();
                string totalTime = this.TestContext.DataRow["totalTime"].ToString();
                string timeUnit = this.TestContext.DataRow["timeUnit"].ToString();
                string resolutionRemarks = this.TestContext.DataRow["resolutionRemarks"].ToString();

                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona(persona1);
                _homeAction.ClickOnPersona(persona2);
                _inboxAction.ClickInbox(inbox);
                _casesAction.ClickOnCreateCase();
                _casesAction.CaseDetails(title, account, contact, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation);
                _casesAction.EnterDescriptionOrAdditionalInformation(additionalInformation);
                _casesAction.ClickSubmit();
                _casesAction.ValidateCaseData(title, origin, productOrigin, caseInvolvement, caseOwner, bussinessType, bussinessSubType, westInitiative, westCampaign, additionalInformation, "In Progress");
                _casesAction.VerifyAdditionalInformation(additionalInformation);
                _casesAction.AddCase();
                _casesAction.ClickResolveCaseButton();
                _casesAction.VerifyTotalTime("0");
                _casesAction.ResolvedOn(resolvedOn);
                _casesAction.EnterTotalTime(totalTime);
                _casesAction.TimeUnit(timeUnit);
                _casesAction.VerifyTotalTime(totalTime);
                _casesAction.EnterResolutionRemarks(resolutionRemarks);
                _casesAction.ClickResolve();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, caseOwner, caseInvolvement, bussinessType, bussinessSubType, "Resolved");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Meeting Report

        [TestMethod]
        [Priority(34)]
        [TestCategory("Regression")]
        [TestCategory("MeetingReportTest")]
        [TestCategory("CRM")]
        [Description("Tests create Meeting Report functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_MeetingReport.csv", "CRM_MeetingReport#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_MeetingReport.csv")]
        public void TC_414676_ValidateCreateMeetingReport()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string meetingDate = this.TestContext.DataRow["meetingDate"].ToString();
                string meetingType = this.TestContext.DataRow["meetingType"].ToString();
                string meetingPurpose = this.TestContext.DataRow["meetingPurpose"].ToString();
                string meetingLocation = this.TestContext.DataRow["meetingLocation"].ToString();
                string notifyReference1 = this.TestContext.DataRow["notifyReference1"].ToString();
                string notify1 = this.TestContext.DataRow["notify1"].ToString();
                string notifyReference2 = this.TestContext.DataRow["notifyReference2"].ToString();
                string notify2 = this.TestContext.DataRow["notify2"].ToString();
                string otherParticipents1 = this.TestContext.DataRow["otherParticipents1"].ToString();
                string otherParticipents2 = this.TestContext.DataRow["otherParticipents2"].ToString();
                string CCReference1 = this.TestContext.DataRow["CCReference1"].ToString();
                string CC1 = this.TestContext.DataRow["CC1"].ToString();
                string CCReference2 = this.TestContext.DataRow["CCReference2"].ToString();
                string CC2 = this.TestContext.DataRow["CC2"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string actionNotifyReference = this.TestContext.DataRow["actionNotifyReference"].ToString();
                string actionNotify = this.TestContext.DataRow["actionNotify"].ToString();
                string actionDueDate = this.TestContext.DataRow["actionDueDate"].ToString();
                string objective = this.TestContext.DataRow["objective"].ToString();
                string outComes = this.TestContext.DataRow["outComes"].ToString();

                _meetingReportAction.SearchInbox("Meeting Report (Sales)");
                _meetingReportAction.ClickCreateMeetingReport();
                _meetingReportAction.EnterMeetingReportDetails(subject, meetingDate, meetingType, meetingPurpose, meetingLocation, notifyReference1, notify1, notifyReference2, notify2, otherParticipents1, otherParticipents2,
                    CCReference1, CC1, CCReference2, CC2, description, actionNotifyReference, actionNotify, actionDueDate, objective, outComes);
                _meetingReportAction.ClickCreateButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(subject);
                _inboxAction.ClickOnSearchButton();
                _meetingReportAction.ValidateCreatedMeetingReportInInboxGrid(meetingType, subject, meetingPurpose, meetingLocation);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(35)]
        [TestCategory("Regression")]
        [TestCategory("MeetingReportTest")]
        [TestCategory("CRM")]
        [Description("Tests Edit Meeting Report functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_MeetingReport.csv", "CRM_MeetingReport#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_MeetingReport.csv")]
        public void TC_414899_ValidateEditMeetingReportInTheInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string meetingDate = this.TestContext.DataRow["meetingDate"].ToString();
                string meetingType = this.TestContext.DataRow["meetingType"].ToString();
                string meetingPurpose = this.TestContext.DataRow["meetingPurpose"].ToString();
                string meetingLocation = this.TestContext.DataRow["meetingLocation"].ToString();
                string notifyReference1 = this.TestContext.DataRow["notifyReference1"].ToString();
                string notify1 = this.TestContext.DataRow["notify1"].ToString();
                string notifyReference2 = this.TestContext.DataRow["notifyReference2"].ToString();
                string notify2 = this.TestContext.DataRow["notify2"].ToString();
                string otherParticipents1 = this.TestContext.DataRow["otherParticipents1"].ToString();
                string otherParticipents2 = this.TestContext.DataRow["otherParticipents2"].ToString();
                string CCReference1 = this.TestContext.DataRow["CCReference1"].ToString();
                string CC1 = this.TestContext.DataRow["CC1"].ToString();
                string CCReference2 = this.TestContext.DataRow["CCReference2"].ToString();
                string CC2 = this.TestContext.DataRow["CC2"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string actionNotifyReference = this.TestContext.DataRow["actionNotifyReference"].ToString();
                string actionNotify = this.TestContext.DataRow["actionNotify"].ToString();
                string actionDueDate = this.TestContext.DataRow["actionDueDate"].ToString();
                string objective = this.TestContext.DataRow["objective"].ToString();
                string outComes = this.TestContext.DataRow["outComes"].ToString();
                string subject1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["subject"].ToString();
                string meetingPurpose1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["meetingPurpose"].ToString();

                _meetingReportAction.SearchInbox("Meeting Report (Sales)");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(subject);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_414676_ValidateCreateMeetingReport();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _meetingReportAction.ClickEditMeetingReport();
                _meetingReportAction.ClickAllExpandIcons();
                _meetingReportAction.ValidateMeetingReportData(subject, meetingDate, meetingType, meetingPurpose, meetingLocation, notify1, notify2, CC1, CC2, objective, outComes, description, actionNotify);
                _meetingReportAction.EnterSubject(subject1);
                _meetingReportAction.EnterMeetingPurpose(meetingPurpose1);
                _meetingReportAction.AddMoreAction("Nayak", "Nayak, Sanghamitra (EXTERNAL)", description + 123, "15");
                _meetingReportAction.ClickOnUpdateButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(subject1);
                _inboxAction.ClickOnSearchButton();
                _meetingReportAction.ValidateCreatedMeetingReportInInboxGrid(meetingType, subject1, meetingPurpose1, meetingLocation);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(36)]
        [TestCategory("Regression")]
        [TestCategory("MeetingReportTest")]
        [TestCategory("CRM")]
        [Description("Tests Send A Copy in Meeting Report functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_MeetingReport.csv", "CRM_MeetingReport#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_MeetingReport.csv")]
        public void TC_415356_ValidateSendACopyInTheInbox()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string subject1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["subject"].ToString();
                string meetingType = this.TestContext.DataRow["meetingType"].ToString();
                string meetingPurpose1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["meetingPurpose"].ToString();
                string meetingLocation = this.TestContext.DataRow["meetingLocation"].ToString();
                string CCReference1 = this.TestContext.DataRow["CCReference1"].ToString();
                string CC1 = this.TestContext.DataRow["CC1"].ToString();

                _meetingReportAction.SearchInbox("Meeting Report (Sales)");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(subject1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_414899_ValidateEditMeetingReportInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _meetingReportAction.ClickSendACopy();
                _meetingReportAction.ValidateSendACopyData(subject1, meetingType, meetingPurpose1, meetingLocation);
                _meetingReportAction.AddRecipients(CCReference1, CC1);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Opportunity

        [TestMethod]
        [Priority(37)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests save and close opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_448515_ValidateSaveAndCloseOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + "Save And Close" + DateTime.UtcNow.ToString("ddMMyy");
                string address = this.TestContext.DataRow["address"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _opportunityAction.ClickCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.SaveAndCloseManfatoryfields(opportunityName, address, projectedClosureDate);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, companyName, "Definition", "0", testUser, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(38)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests create new opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_381168_ValidateCreateOpportunityIsDisplayedInTheInbox()
        {
            try
            {
                
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _opportunityAction.ClickCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.CheckOpportunityStatus("New");
                _opportunityAction.opportunityOverviewFields(opportunityName, address, opportunityOwnerReference, opportunityOwner, bussinessType, bussinessSubType, projectedClosureDate, region, forecastedValue,
                    marketUnit, currency, segment, subSegment, probaility, strategicAcountClassification, application, sipDesignation, closeWonType, organizationalVP, busDev);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickCreateButton();
                _opportunityAction.CheckOpportunityStatus("Open");
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, companyName, "Definition", "100", opportunityOwner, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(39)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests edit opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_381172_ValidateEditOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_381168_ValidateCreateOpportunityIsDisplayedInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickEditOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.VerifyOpportunityOverViewFields(opportunityName, address, opportunityOwner, bussinessType, bussinessSubType, projectedClosureDate, region, "100.00", marketUnit,
                  currency, segment, subSegment, probaility, strategicAcountClassification, application, sipDesignation, closeWonType, organizationalVP, busDev);
                _opportunityAction.EnterOpportuityName(opportunityName1);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.EnterForcastedValue("1500");
                _opportunityAction.CheckOpportunityStatus("Open");
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName1, companyName, "Definition", "1,500", opportunityOwner, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(40)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests to add forecast functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_454878_ValidateAddForecast()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string puroseOfInquiry = this.TestContext.DataRow["puroseOfInquiry"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string therapeuticClass = this.TestContext.DataRow["therapeuticClass"].ToString();
                string clinicalPhase = this.TestContext.DataRow["clinicalPhase"].ToString();
                string detailedRequest = this.TestContext.DataRow["detailedRequest"].ToString();
                string bussinessImpact = this.TestContext.DataRow["bussinessImpact"].ToString();
                string generalNotes = this.TestContext.DataRow["generalNotes"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string forecastYearOneQuantity = this.TestContext.DataRow["forecastYearOneQuantity"].ToString();
                string forecastUnitPrice = this.TestContext.DataRow["forecastUnitPrice"].ToString();
                string annualForecastedRevenue = this.TestContext.DataRow["annualForecastedRevenue"].ToString();
                string totalForecastedRevenue = this.TestContext.DataRow["totalForecastedRevenue"].ToString();
                string comments = this.TestContext.DataRow["comments"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Open", "Definition");
                }
                catch (Exception)
                {
                    TC_381172_ValidateEditOpportunity();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickEditOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.AddProducts();
                _opportunityAction.AddNewOpportunityForecast(forecastYearOneQuantity, forecastUnitPrice, currency, annualForecastedRevenue, totalForecastedRevenue, comments,
                    forecastYearOneQuantity, forecastUnitPrice, annualForecastedRevenue, "0.00", "0.00");
                _opportunityAction.ClickOnOpportunityManagement();
                //_opportunityAction.VerifyForecastedValue(totalForecast);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickDetailsExpandIcon();
                _opportunityAction.opportunityDetailsFields(puroseOfInquiry, westInitiative, westCampaign, clinicalPhase, detailedRequest, bussinessImpact, generalNotes);
                _opportunityAction.ClickNextStageSingleTime();
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName1, companyName, "Feasibility", "2,400", opportunityOwner, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(41)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests to Push To Apo functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_455645_ValidatePushToAPO()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string forecastYearOneQuantity = this.TestContext.DataRow["forecastYearOneQuantity"].ToString();
                string forecastUnitPrice = this.TestContext.DataRow["forecastUnitPrice"].ToString();
                string annualForecastedRevenue = this.TestContext.DataRow["annualForecastedRevenue"].ToString();
                string totalForecastedRevenue = this.TestContext.DataRow["totalForecastedRevenue"].ToString();
                string comments = this.TestContext.DataRow["comments"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Open", "Feasibility");

                }
                catch (Exception)
                {
                    TC_454878_ValidateAddForecast();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickEditOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.pushToAPO("SRI International", strategicAcountClassification);
                _opportunityAction.ClickOnOpportunityManagement();
                //_opportunityAction.VerifyForecastedValue(totalForecast);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName1, companyName, "Proposal", "2,400", opportunityOwner, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(42)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests to Add Opportunity Service functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_455829_ValidateOpportunityService()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString();
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Open", "Proposal");

                }
                catch (Exception)
                {
                    TC_455645_ValidatePushToAPO();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickEditOpportunity();
                _opportunityAction.ClickAddService();
                _opportunityAction.SelectAnalyticalLabService();
                _opportunityAction.EnterDrugProductAndContainerClosureFields("a", "b", "c", "d", "e", "f", "g", "h", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w");
                _opportunityAction.EnterHeliumLeakFields("100", "40C", "Comments");
                _opportunityAction.EnterHeadSpaceAnalysisFields("200", "Oxygen", "comments");
                _opportunityAction.HighVoltageLeakDetectionFields("100", "Comments");
                _opportunityAction.VaccumDecayFields("300", "Comments");
                _opportunityAction.WestStabilityFields("120", "40C", "Inverted", "Comments");
                _opportunityAction.EnterTextInRTE("Commented", "100");
                _opportunityAction.ClickCreateService();
                _opportunityAction.VerifyServiceIsCreatedOrNot();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(43)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests Won Opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_448511_ValidateClosedWonOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string puroseOfInquiry = this.TestContext.DataRow["puroseOfInquiry"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string therapeuticClass = this.TestContext.DataRow["therapeuticClass"].ToString();
                string clinicalPhase = this.TestContext.DataRow["clinicalPhase"].ToString();
                string detailedRequest = this.TestContext.DataRow["detailedRequest"].ToString();
                string bussinessImpact = this.TestContext.DataRow["bussinessImpact"].ToString();
                string generalNotes = this.TestContext.DataRow["generalNotes"].ToString();
                string requestType = this.TestContext.DataRow["requestType"].ToString();
                string promiseDate = this.TestContext.DataRow["promiseDate"].ToString();
                string deliveryDate = this.TestContext.DataRow["deliveryDate"].ToString();
                string expirationDate = this.TestContext.DataRow["expirationDate"].ToString();
                string forecastYearOneQuantity = this.TestContext.DataRow["forecastYearOneQuantity"].ToString();
                string forecastUnitPrice = this.TestContext.DataRow["forecastUnitPrice"].ToString();
                string annualForecastedRevenue = this.TestContext.DataRow["annualForecastedRevenue"].ToString();
                string totalForecastedRevenue = this.TestContext.DataRow["totalForecastedRevenue"].ToString();
                string comments = this.TestContext.DataRow["comments"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();
                string primaryCloseReason = this.TestContext.DataRow["primaryCloseReason"].ToString();
                string secondaryCloseReason = this.TestContext.DataRow["secondaryCloseReason"].ToString();
                string closeConfoirmation = this.TestContext.DataRow["closeConfoirmation"].ToString();
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Open", "Proposal");
                }
                catch (Exception)
                {
                    TC_455645_ValidatePushToAPO();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickEditOpportunity();
                _opportunityAction.ClickDetailsExpandIcon();
                _opportunityAction.ClickActivityExpandIcon();
                _opportunityAction.OpportunityActivityField(requestType, promiseDate, deliveryDate, expirationDate);
                _opportunityAction.ClickOnNextStage();
                _opportunityAction.ClickOverViewExpandICon();
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.CloseOpportunity(status, primaryCloseReason, secondaryCloseReason);
                //_opportunityAction.CloseWonOpportunityConfirmation(closeConfoirmation);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName1, companyName, "Agreement", "2,400", opportunityOwner, "Won ");
                _opportunityAction.VerifyActualCloseDate(DateTime.UtcNow.ToString("M/d/yyyy"));
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(44)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests View opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_448516_ValidateViewOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string puroseOfInquiry = this.TestContext.DataRow["puroseOfInquiry"].ToString();
                string westInitiative = this.TestContext.DataRow["westInitiative"].ToString();
                string westCampaign = this.TestContext.DataRow["westCampaign"].ToString();
                string therapeuticClass = this.TestContext.DataRow["therapeuticClass"].ToString();
                string clinicalPhase = this.TestContext.DataRow["clinicalPhase"].ToString();
                string detailedRequest = this.TestContext.DataRow["detailedRequest"].ToString();
                string bussinessImpact = this.TestContext.DataRow["bussinessImpact"].ToString();
                string generalNotes = this.TestContext.DataRow["generalNotes"].ToString();
                string requestType = this.TestContext.DataRow["requestType"].ToString();
                string promiseDate = this.TestContext.DataRow["promiseDate"].ToString();
                string deliveryDate = this.TestContext.DataRow["deliveryDate"].ToString();
                string expirationDate = this.TestContext.DataRow["expirationDate"].ToString();
                string forecastYearOneQuantity = this.TestContext.DataRow["forecastYearOneQuantity"].ToString();
                string forecastUnitPrice = this.TestContext.DataRow["forecastUnitPrice"].ToString();
                string annualForecastedRevenue = this.TestContext.DataRow["annualForecastedRevenue"].ToString();
                string totalForecastedRevenue = this.TestContext.DataRow["totalForecastedRevenue"].ToString();
                string comments = this.TestContext.DataRow["comments"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();
                string primaryCloseReason = this.TestContext.DataRow["primaryCloseReason"].ToString();
                string secondaryCloseReason = this.TestContext.DataRow["secondaryCloseReason"].ToString();
                string closeConfoirmation = this.TestContext.DataRow["closeConfoirmation"].ToString();
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Won ", "Agreement");
                }
                catch (Exception)
                {
                    TC_448511_ValidateClosedWonOpportunity();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.ClickViewOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.ClickDetailsExpandIcon();
                _opportunityAction.ClickActivityExpandIcon();
                _opportunityAction.VerifyViewOpportunityPage(opportunityName1, address, opportunityOwner, bussinessType, bussinessSubType, projectedClosureDate, region, totalForecast,
                    marketUnit, currency, segment, subSegment, probaility, strategicAcountClassification, application, sipDesignation, closeWonType, organizationalVP, busDev, "Closed Won",
                    primaryCloseReason, secondaryCloseReason, puroseOfInquiry, westInitiative, westCampaign, clinicalPhase, detailedRequest, bussinessImpact, generalNotes, requestType);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(45)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests Copy opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_455652_ValidateCopyOpportunity()
        {
            try
            {
                
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["opportunityName"].ToString();
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string primaryCloseReason = this.TestContext.DataRow["primaryCloseReason"].ToString();
                string opportunityName1 = DateTime.UtcNow.ToString("ddMMyy") + "Copy" + this.TestContext.DataRow["opportunityName"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();
                string testUserOrgVP = this.TestContext.DataRow["testUserOrgVP"].ToString();

                _opportunityAction.SearchInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                    _opportunityAction.VerifyStatusAndStage("Won ", "Agreement");
                }
                catch (Exception)
                {
                    TC_448511_ValidateClosedWonOpportunity();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _opportunityAction.CopyOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.VerifyFieldsAfterCopyOpportunity(opportunityName, testUser, region, marketUnit, segment, subSegment, strategicAcountClassification, application, sipDesignation, testUserOrgVP);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.EnterOpportuityName(opportunityName1);
                _opportunityAction.ClickSaveAndClose();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName1);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName1, companyName, "Definition", "0", testUser, "Open");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(46)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests Lost Opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Opportunity.csv", "CRM_Opportunity#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Opportunity.csv")]
        public void TC_448513_ValidateClosedLostOpportunity()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string opportunityName = this.TestContext.DataRow["opportunityName"].ToString() + "lost" + DateTime.UtcNow.ToString("ddMMyy");
                string address = this.TestContext.DataRow["address"].ToString();
                string opportunityOwnerReference = this.TestContext.DataRow["opportunityOwnerReference"].ToString();
                string opportunityOwner = this.TestContext.DataRow["opportunityOwner"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string projectedClosureDate = this.TestContext.DataRow["projectedClosureDate"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string forecastedValue = this.TestContext.DataRow["forecastedValue"].ToString();
                string marketUnit = this.TestContext.DataRow["marketUnit"].ToString();
                string segment = this.TestContext.DataRow["segment"].ToString();
                string subSegment = this.TestContext.DataRow["subSegment"].ToString();
                string probaility = this.TestContext.DataRow["probaility"].ToString();
                string strategicAcountClassification = this.TestContext.DataRow["strategicAcountClassification"].ToString();
                string application = this.TestContext.DataRow["application"].ToString();
                string hvp = this.TestContext.DataRow["hvp"].ToString();
                string sipDesignation = this.TestContext.DataRow["sipDesignation"].ToString();
                string closeWonType = this.TestContext.DataRow["closeWonType"].ToString();
                string organizationalVP = this.TestContext.DataRow["organizationalVP"].ToString();
                string busDev = this.TestContext.DataRow["busDev"].ToString();
                string currency = this.TestContext.DataRow["currency"].ToString();
                string totalForecast = this.TestContext.DataRow["totalForecast"].ToString();
                string inboxStatus = this.TestContext.DataRow["inboxStatus"].ToString();
                string primaryCloseReason = this.TestContext.DataRow["primaryCloseReason"].ToString();


                _opportunityAction.SearchInbox(inbox);
                _opportunityAction.ClickCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.CheckOpportunityStatus("New");
                _opportunityAction.opportunityOverviewFields(opportunityName, address, opportunityOwnerReference, opportunityOwner, bussinessType, bussinessSubType, projectedClosureDate, region, forecastedValue,
                    marketUnit, currency, segment, subSegment, probaility, strategicAcountClassification, application, sipDesignation, closeWonType, organizationalVP, busDev);
                String companyName = _opportunityAction.GetAccountNameValue();
                _opportunityAction.ClickCreateButton();
                _opportunityAction.CheckOpportunityStatus("Open");
                _opportunityAction.CloseOpportunity("Closed Lost", primaryCloseReason, "Lack of capacity at West");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, companyName, "Definition", "100", opportunityOwner, "Lost");
                _opportunityAction.VerifyActualCloseDate(DateTime.UtcNow.ToString("M/d/yyyy"));
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Customer

        [TestMethod]
        [Priority(47)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to create new Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449656_ValidateCreatedCustomerIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _customerAction.ClickOnCreateCustomer();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(48)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to create New Opportunity from Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CustomerToOtherEntities.csv", "CRM_CustomerToOtherEntities#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CustomerToOtherEntities.csv")]
        public void TC_468261_ValidateCreateOpportunityFromCustomer()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + "contact" + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string contOwn = this.TestContext.DataRow["contOwn"].ToString();
                string opportunityName = "opportunity" + this.TestContext.DataRow["comapanyName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                String companyName = _customerAction.CompanyName();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _customerAction.ClickOnCreateOpportunity();
                _homeAction.VerifyActionPageTitle("Opportunity");
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.ValidateOpportunityPageCreatedFromCustomer(companyName, street1 + ", " + street2 + ", " + street3, testUser);
                _opportunityAction.EnterOpportuityName(opportunityName);
                _opportunityAction.ClickPrimaryCustomerContactGP();
                try
                {
                    Assert.IsFalse(_opportunityAction.CheckNoDataAvailable());
                    _opportunityAction.SelectContactInPicker();
                }
                catch (Exception)
                {
                    _opportunityAction.CreateContactInPicker();
                    _homeAction.VerifyActionPageTitle("Contact");
                    _contactsAction.VerifyCompanyNameField();
                    _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName, lastName, jobTitle, jobFunction, email, contOwn, street1, city);
                    _contactsAction.ClickOnCreateContactsButton();
                    _homeAction.VerifyActionPageTitle("Opportunity");
                    _opportunityAction.SelectPrimaryCustomerContact();
                }
                _opportunityAction.SelectProjectedCloseDate("15");
                _opportunityAction.ClickSaveAndClose();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(companyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Opportunities");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(opportunityName);
                _inboxAction.ClickOnSearchButton();
                _opportunityAction.ValidateCreatedOpportunityInInbox(opportunityName, "companyName", "Definition", "0", testUser, "Open");
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Opportunities", _opportunityAction.DashBoardLabelValue());
                //_customerAction.VerifyChildInboxCount("Contacts", "1");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(49)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to create New Lead from Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CustomerToOtherEntities.csv", "CRM_CustomerToOtherEntities#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CustomerToOtherEntities.csv")]
        public void TC_468251_ValidateCreateLeadFromCustomer()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string contOwn = this.TestContext.DataRow["contOwn"].ToString();
                string opportunityName = "opportunity" + this.TestContext.DataRow["comapanyName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                String companyName = _customerAction.CompanyName();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _customerAction.ClickOnCreateLead();
                _homeAction.VerifyActionPageTitle("Lead");
                _leadsAction.VerifyCompanyNameField(companyName);
                _leadsAction.EnterTopic("topic");
                _leadsAction.EnterSalutation(salutation);
                _leadsAction.EnterFirstName(firstName);
                _leadsAction.EnterLastName(lastName);
                _leadsAction.EnterJobTitle(jobTitle);
                _leadsAction.EnterJobFunctionValue(jobFunction);
                _leadsAction.EnterEmail(email);
                _leadsAction.EnterCountry(country);
                _leadsAction.ClickOnCreateButton();
                _opportunityAction.ClickSaveAndClose();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(companyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Leads");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(firstName);
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid(firstName, lastName, city, jobTitle, jobFunction, testUser, "Assigned ", "topic", companyName, country);
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Leads", _opportunityAction.DashBoardLabelValue());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(50)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to create New Case from Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CustomerToOtherEntities.csv", "CRM_CustomerToOtherEntities#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CustomerToOtherEntities.csv")]
        public void TC_468254_ValidateCreateCaseFromCustomer()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string contOwn = this.TestContext.DataRow["contOwn"].ToString();
                string opportunityName = "opportunity" + this.TestContext.DataRow["comapanyName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string title = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["title"].ToString();
                string origin = this.TestContext.DataRow["origin"].ToString();
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString();
                string caseInvolvment = this.TestContext.DataRow["caseInvolvment"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string bussinessType = this.TestContext.DataRow["bussinessType"].ToString();
                string bussinessSubType = this.TestContext.DataRow["bussinessSubType"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                String companyName = _customerAction.CompanyName();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _customerAction.ClickOnCreateCase();
                _homeAction.VerifyActionPageTitle("Case");
                _casesAction.VerifyAccountNameField(companyName);
                _casesAction.EnterTitle(title);
                _casesAction.ClickContactGP();
                try
                {
                    Assert.IsFalse(_opportunityAction.CheckNoDataAvailable());
                    _casesAction.SelectContactInPicker();
                }
                catch (Exception)
                {
                    _opportunityAction.CreateContactInPicker();
                    _homeAction.VerifyActionPageTitle("Contact");
                    _contactsAction.VerifyCompanyNameField();
                    _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName, lastName, jobTitle, jobFunction, email, contOwn, street1, city);
                    _contactsAction.ClickOnCreateContactsButton();
                    _homeAction.VerifyActionPageTitle("Case");
                    _casesAction.SelectContact("");
                }
                _casesAction.SelectOrigin(origin);
                _casesAction.SelectProductOrigin(productOrigin);
                _casesAction.SelectCaseInvolvment(caseInvolvment);
                _casesAction.SelectBussinessType(bussinessType);
                _casesAction.SelectBussinessSubType(bussinessSubType);
                _casesAction.ClickSubmitButton();
                _prospectsAction.ClickBackButton();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(companyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Cases");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(title);
                _inboxAction.ClickOnSearchButton();
                _casesAction.ValidateCreatedCaseInInboxGrid(title, priority, origin, testUser, caseInvolvment, bussinessType, bussinessSubType, "In Progress");
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Cases", _opportunityAction.DashBoardLabelValue());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(51)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to create New Meeting Report from Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CustomerMeetingReport.csv", "CRM_CustomerMeetingReport#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CustomerMeetingReport.csv")]
        public void TC_501249_ValidateCreateMeetingReportFromCustomer()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string pageTitle = this.TestContext.DataRow["pageTitle"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string meetingDate = this.TestContext.DataRow["meetingDate"].ToString();
                string meetingType = this.TestContext.DataRow["meetingType"].ToString();
                string meetingPurpose = this.TestContext.DataRow["meetingPurpose"].ToString();
                string meetingLocation = this.TestContext.DataRow["meetingLocation"].ToString();
                string notifyReference1 = this.TestContext.DataRow["notifyReference1"].ToString();
                string notify1 = this.TestContext.DataRow["notify1"].ToString();
                string notifyReference2 = this.TestContext.DataRow["notifyReference2"].ToString();
                string notify2 = this.TestContext.DataRow["notify2"].ToString();
                string otherParticipents1 = this.TestContext.DataRow["otherParticipents1"].ToString();
                string otherParticipents2 = this.TestContext.DataRow["otherParticipents2"].ToString();
                string CCReference1 = this.TestContext.DataRow["CCReference1"].ToString();
                string CC1 = this.TestContext.DataRow["CC1"].ToString();
                string CCReference2 = this.TestContext.DataRow["CCReference2"].ToString();
                string CC2 = this.TestContext.DataRow["CC2"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string actionNotifyReference = this.TestContext.DataRow["actionNotifyReference"].ToString();
                string actionNotify = this.TestContext.DataRow["actionNotify"].ToString();
                string actionDueDate = this.TestContext.DataRow["actionDueDate"].ToString();
                string objective = this.TestContext.DataRow["objective"].ToString();
                string outComes = this.TestContext.DataRow["outComes"].ToString();
                string salutation = this.TestContext.DataRow["salutation"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string jobTitle = this.TestContext.DataRow["jobTitle"].ToString();
                string jobFunction = this.TestContext.DataRow["jobFunction"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                String companyName = _customerAction.CompanyName();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _customerAction.ClickOnCreateMeetingReport();
                _homeAction.VerifyActionPageTitle(pageTitle);
                _meetingReportAction.VerifyCompanyNameField(companyName);
                _meetingReportAction.EnterMeetingReportDetailCreatingFromCustomer(subject,meetingDate,meetingType,meetingPurpose,meetingLocation,notifyReference1,notify1,notifyReference2,notify2,otherParticipents1,
                    otherParticipents2, CCReference1, CC1,CCReference2, CC2,description, actionNotifyReference,actionNotify,actionDueDate,objective,outComes);
                try
                {
                    _meetingReportAction.ClickParticipantsFromCustomerGenericPicker();
                    Assert.IsFalse(_opportunityAction.CheckNoDataAvailable());
                    _meetingReportAction.SelectContacts();
                }
                catch (Exception)
                {
                    _opportunityAction.CreateContactInPicker();
                    _homeAction.VerifyActionPageTitle("Contact");
                    _contactsAction.VerifyCompanyNameField();
                    _contactsAction.EnterContactMandatoryDetailsFromOtherInbox(salutation, firstName, lastName, jobTitle, jobFunction, email, testUser, street1, city);
                    _contactsAction.ClickOnCreateContactsButton();
                    _homeAction.VerifyActionPageTitle(pageTitle);
                    _casesAction.SelectContact("");
                }
                _meetingReportAction.ClickCreateButton();
                _contactsAction.ClickOnRefreshData();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(companyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox(pageTitle);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(subject);
                _inboxAction.ClickOnSearchButton();
                _meetingReportAction.ValidateCreatedMeetingReportInInboxGrid(meetingType, subject, meetingPurpose, meetingLocation);
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount(pageTitle, _opportunityAction.DashBoardLabelValue());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(52)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Edit Customer functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449657_ValidateEditCustomerIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();
                string CompanyNameEdited = this.TestContext.DataRow["comapanyName"].ToString() + DateTime.UtcNow.ToString("ddMMyy");

                _homeAction.ClickOnFunction("Sales");
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                try
                {
                    Assert.IsFalse(_inboxAction.CheckDataNotAvailable());
                }
                catch (Exception)
                {
                    TC_449656_ValidateCreatedCustomerIsDisplayedInTheInbox();
                }
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _customerAction.ClickOnEditCustomer();
                _customerAction.ValidateCustomerPage(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.EditCustomer(CompanyNameEdited, "Banglore");
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(CompanyNameEdited);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(CompanyNameEdited, "Banglore", country + countryCode, state);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
       
        [TestMethod]
        [Priority(53)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Prospect functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449687_ValidateCreateCustomerFromProspectIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Prospect" + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();
                string CompanyNameEdited = DateTime.UtcNow.ToString("mddyy") + this.TestContext.DataRow["comapanyName"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _prospectsAction.SearchInbox("Prospects (Sales)");
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Prospect");
                _prospectsAction.VerifyCompanyNameField(comapanyName);
                _prospectsAction.EnterSalutation("Mr.");
                _prospectsAction.EnterFirstName("Create");
                _prospectsAction.EnterLastName(DateTime.UtcNow.ToString("ddMMyy") + "Prospect");
                _prospectsAction.EnterJobTitle("Manager");
                _prospectsAction.EnterJobFunction("Marketing");
                _prospectsAction.EnterEmail("auto@auto.com");
                _prospectsAction.NewProspectStatus();
                _prospectsAction.ClickCopyDetails();
                _prospectsAction.VerifyFieldsAfterClickingOnCopyDetails(street1, street2, street3, city, country, state, zip, phoneNumber, website);
                _prospectsAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Prospects");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(DateTime.UtcNow.ToString("ddMMyy") + "Prospect");
                _inboxAction.ClickOnSearchButton();
                _prospectsAction.ValidateProspectStatusInInbox("Create", DateTime.UtcNow.ToString("ddMMyy") + "Prospect", "Marketing", testUser, "Assigned", "Manager", "", comapanyName);
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Prospects", _opportunityAction.DashBoardLabelValue());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(54)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Lead functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449712_ValidateCreateCustomerFromLeadIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Lead" + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _prospectsAction.SearchInbox("Leads (Sales)");
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Lead");
                _leadsAction.VerifyCompanyNameField(comapanyName);
                _leadsAction.EnterTopic("Customer");
                _leadsAction.EnterSalutation("Mr.");
                _leadsAction.EnterFirstName("Create");
                _leadsAction.EnterLastName(DateTime.UtcNow.ToString("ddMMyy") + "Lead");
                _leadsAction.EnterJobTitle("Manager");
                _leadsAction.EnterJobFunctionValue("Marketing");
                _leadsAction.EnterEmail("create@lead.com");
                _leadsAction.NewLeadStatus();
                _leadsAction.ClickCopyDetails();
                _leadsAction.VerifyFieldsAfterClickingOnCopyDetails(street1, street2, street3, city, country, state, zip, phoneNumber, website);
                _leadsAction.ClickOnCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Leads");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(DateTime.UtcNow.ToString("ddMMyy") + "Lead");
                _inboxAction.ClickOnSearchButton();
                _leadsAction.ValidateCreatedLeadsInInboxGrid("Create", DateTime.UtcNow.ToString("ddMMyy") + "Lead", city, "Manager", "Marketing", testUser, "Assigned ", "Customer", comapanyName, "");
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Leads", _opportunityAction.DashBoardLabelValue());

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(55)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Contact functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449762_ValidateCreateCustomerFromContactIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Contact" + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _prospectsAction.SearchInbox("Contacts (Sales)");
                _contactsAction.ClickOnCreateContacts();
                _contactsAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Contact");
                _contactsAction.VerifyCompanyNameFieldWithName(comapanyName);
                _contactsAction.EnterSalutation("Mr.");
                _contactsAction.EnterFirstName("Create");
                _contactsAction.EnterLastName(DateTime.UtcNow.ToString("ddMMyy") + "Contact");
                _contactsAction.EnterJobTitle("Manager");
                _contactsAction.EnterJobFunction("Marketing");
                _contactsAction.EnterEmail(email);
                _contactsAction.ClickCopyDetails();
                _contactsAction.VerifyFieldsAfterClickingOnCopyDetails(street1, street2, street3, city, country, state, zip, phoneNumber, website);
                _contactsAction.ClickOnCreateContactsButton();
                _contactsAction.ClickOnRefreshData();
                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Contacts");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(DateTime.UtcNow.ToString("ddMMyy") + "Contact");
                _inboxAction.ClickOnSearchButton();
                _contactsAction.ValidateCreatedContactInInbox("Create", DateTime.UtcNow.ToString("ddMMyy") + "Contact", email, street1, city, "Manager", "Marketing", testUser);
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Contacts", _opportunityAction.DashBoardLabelValue());

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(56)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Opportunity functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449769_ValidateCreateCustomerFromOpportunityIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Opportunity" + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();
                string testUser = this.TestContext.DataRow["testUser"].ToString();

                _prospectsAction.SearchInbox("Opportunities (Sales)");
                _opportunityAction.ClickCreateOpportunity();
                _opportunityAction.ClickOverViewExpandICon();
                _opportunityAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Opportunity");
                _opportunityAction.ValidateOpportunityPageCreatedFromCustomer(comapanyName, street1 + ", " + street2 + ", " + street3, testUser);
                _prospectsAction.ClickBackButton();
                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(57)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Meeting Report functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449774_ValidateCreateCustomerFromMeetingReportIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Meeting Report " + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();

                _prospectsAction.SearchInbox("Meeting Report (Sales)");
                _meetingReportAction.ClickCreateMeetingReport();
                _meetingReportAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Meeting Report");
                _meetingReportAction.EnterSubject(DateTime.UtcNow.ToString("ddMMyy") + "Meeting Report");
                _meetingReportAction.VerifyCompanyName(comapanyName);
                _meetingReportAction.SelectMeetingDate("15");
                _meetingReportAction.SelectMeetingType("Audit");
                _meetingReportAction.EnterMeetingPurpose("Routine Audit");
                _meetingReportAction.SelectMeetingLocation("Industry Event");
                _meetingReportAction.ExpandAndSelectEmployeeNotify("Vijay", "Pangulur, Vijay (EXTERNAL)");
                _meetingReportAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.ClickOnFunction(function);
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
                _customerAction.ClickChildInboxIcon();
                _customerAction.ClickChildInbox("Meeting Report");
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(DateTime.UtcNow.ToString("ddMMyy") + "Meeting Report");
                _inboxAction.ClickOnSearchButton();
                _meetingReportAction.ValidateCreatedMeetingReportInInboxGrid("Audit", DateTime.UtcNow.ToString("ddMMyy") + "Meeting Report", "Routine Audit", "Industry Event");
                _contactsAction.ClickOnRefreshData();
                _customerAction.VerifyChildInboxCount("Meeting Report", _opportunityAction.DashBoardLabelValue());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(58)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Create Customer from Cases functionality of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_Customer.csv", "CRM_Customer#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_Customer.csv")]
        public void TC_449779_ValidateCreateCustomerFromCasesIsDisplayedInTheInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string comapanyName = DateTime.UtcNow.ToString("ddMMyy") + "Cases" + this.TestContext.DataRow["comapanyName"].ToString();
                string street1 = this.TestContext.DataRow["street1"].ToString();
                string street2 = this.TestContext.DataRow["street2"].ToString();
                string street3 = this.TestContext.DataRow["street3"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string accountManager = this.TestContext.DataRow["accountManager"].ToString();
                string website = this.TestContext.DataRow["website"].ToString();
                string email = DateTime.UtcNow.ToString("ddMMyy") + this.TestContext.DataRow["email"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string phoneType = this.TestContext.DataRow["phoneType"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string countryCode = this.TestContext.DataRow["countryCode"].ToString();

                _homeAction.ClickOnFunction("Sales");
                _homeAction.ClickOnPersona("Sales");
                _homeAction.ClickOnPersona("Technical Customer Service");
                _inboxAction.ClickInbox("Cases");
                _casesAction.ClickOnCreateCase();
                _casesAction.ClickCreateAccount();
                _customerAction.EnterCustomerDetails(comapanyName, street1, street2, street3, country, state, accountManager, website, email, zip, city, phoneType, phoneNumber);
                _customerAction.ClickOnCreateOrUpdateButtonButton();
                _homeAction.VerifyActionPageTitle("Case");
                _casesAction.VerifyAccountNameField(comapanyName);
                _prospectsAction.ClickBackButton();
                _homeAction.ClickOnFunction(function);
                _homeAction.ClickOnPersona("Sales");
                _inboxAction.ClickInbox(inbox);
                _inboxAction.SelectSearchOption("Starts with");
                _inboxAction.EnterSearchValueInGrid(comapanyName);
                _inboxAction.ClickOnSearchButton();
                _customerAction.ValidateCreatedCustomerInInbox(comapanyName, city, country + countryCode, state);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Inbox Count

        [TestMethod]
        [Priority(59)]
        [TestCategory("Regression")]
        [TestCategory("OpportunityTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Total Count in Opportunity Inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_489602_VerifyOpportunityInboxCount()
        {
            try
            {
                _prospectsAction.SearchInbox("Opportunities (Sales)");
                _opportunityAction.VerifyOpportunityDashbordLabelValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(60)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Total Count in Prospect Inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_489575_VerifyProspectInboxCount()
        {
            try
            {
                _prospectsAction.SearchInbox("Prospects (Sales)");
                _opportunityAction.VerifyProspectDashbordLabelValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(61)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Total Count in Lead Inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_489577_VerifyLeadInboxCount()
        {
            try
            {
                _prospectsAction.SearchInbox("Leads (Sales)");
                _opportunityAction.VerifyLeadDashBoardLabelValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(62)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Total Count in Cases Inbox of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_489621_VerifyCasesInboxCount()
        {
            try
            {
                _homeAction.ClickOnFunction("Sales");
                _homeAction.ClickOnPersona("Sales");
                _homeAction.ClickOnPersona("Technical Customer Service");
                _inboxAction.ClickInbox("Cases");
                _opportunityAction.VerifyCaseDashBoardLabelValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Mandatory Fields

        [TestMethod]
        [Priority(63)]
        [TestCategory("Regression")]
        [TestCategory("ProspectsTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Prospect of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_497711_VerifyMandatoryFieldsMessageInProspect()
        {
            try
            {
                _meetingReportAction.SearchInbox("Prospects (Sales)");
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _prospectsAction.ClickOnCreateProspects();
                _prospectsAction.EnterSalutation("Mr.");
                _prospectsAction.EnterFirstName("Vijay");
                _prospectsAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(64)]
        [TestCategory("Regression")]
        [TestCategory("LeadTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Lead of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_497807_VerifyMandatoryFieldsMessageInLead()
        {
            try
            {
                _meetingReportAction.SearchInbox("Leads (Sales)");
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _leadsAction.ClickOnCreateLeads();
                _leadsAction.EnterTopic("Topic");
                _leadsAction.EnterFirstName("Vijay");
                _leadsAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(65)]
        [TestCategory("Regression")]
        [TestCategory("MeetingReportTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Meeting Report of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_498080_VerifyMandatoryFieldsMessageInMeetingReport()
        {
            try
            {
                _meetingReportAction.SearchInbox("Meeting Report (Sales)");
                _meetingReportAction.ClickCreateMeetingReport();
                _meetingReportAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _meetingReportAction.ClickCreateMeetingReport();
                _meetingReportAction.EnterSubject("Meeting Test");
                _meetingReportAction.SelectCompany();
                _meetingReportAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        [Priority(66)]
        [TestCategory("Regression")]
        [TestCategory("ContactTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Contact of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_498012_VerifyMandatoryFieldsMessageInContact()
        {
            try
            {
                _meetingReportAction.SearchInbox("Contacts (Sales)");
                _contactsAction.ClickOnCreateContacts();
                _contactsAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _contactsAction.ClickOnCreateContacts();
                _contactsAction.EnterSalutation("Mr.");
                _contactsAction.EnterFirstName("Vijay");
                _contactsAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(67)]
        [TestCategory("Regression")]
        [TestCategory("CustomerTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Customer of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_498190_VerifyMandatoryFieldsMessageInCustomer()
        {
            try
            {
                _homeAction.ClickOnFunction("Sales");
                _inboxAction.ClickInbox("CRM Accounts/Customers");
                _customerAction.ClickOnCreateCustomer();
                _customerAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _customerAction.ClickOnCreateCustomer();
                _customerAction.EnterCompanyName("New Customer");
                _customerAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Priority(68)]
        [TestCategory("Regression")]
        [TestCategory("CaseTest")]
        [TestCategory("CRM")]
        [Description("Tests to Verify Mandatory Fields Message in Cases of the application")]
        [Owner("Vijay.PangulurEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_CopyDetails.csv", "CRM_CopyDetails#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_CopyDetails.csv")]
        public void TC_498223_VerifyMandatoryFieldsMessageInCases()
        {
            try
            {
                _homeAction.ClickOnFunction("Sales");
                _homeAction.ClickOnPersona("Sales");
                _homeAction.ClickOnPersona("Technical Customer Service");
                _inboxAction.ClickInbox("Cases");
                _casesAction.ClickOnCreateCase();
                _casesAction.VerifyMandatoryFieldsMessage();
                _prospectsAction.ClickBackButton();
                _casesAction.ClickOnCreateCase();
                _casesAction.EnterTitle("Case Test");
                _casesAction.SelectAccount("");
                _casesAction.VerifyMandatoryFieldsMessageAfterEnteringMandatoryValue();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #endregion

        #region OldCRM

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("ProspectsTest")]
        //[TestCategory("CRM")]
        [Description("Tests the create new prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_212242.csv", "CRM_212242#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_212242.csv")]
        [Ignore]
        public void TC_212242_CreateNewProspect()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameProspect = this.TestContext.DataRow["firstName"].ToString();
                string lastNameProspect = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameProspect = firstNameProspect + rNum;
                    lastNameProspect = lastNameProspect + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string prospectSource = this.TestContext.DataRow["prospectSource"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                loginAsUX1(function, inbox);

                _inboxAction.ClickOnCreateMasterAction();
                _prospectsAction.ClickOnCreateProspects();
                //_prospectsAction.EnterProspectDetails(firstNameProspect, lastNameProspect, email, phoneCode, phoneNumber, moreInfo
                //  , prospectSource, companyName);
                _prospectsAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("ProspectsTest")]
        //[TestCategory("CRM")]
        [Description("Tests the create new prospect functionality of the application and validate in inbox")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_212242.csv", "CRM_212242#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_212242.csv")]
        [Ignore]
        public void TC_212243_CreateNewProspectInInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameProspect = this.TestContext.DataRow["firstName"].ToString();
                string lastNameProspect = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameProspect = firstNameProspect + rNum;
                    lastNameProspect = lastNameProspect + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string prospectSource = this.TestContext.DataRow["prospectSource"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                loginAsUX1(function, inbox);
                _inboxAction.ClickOnCreateMasterAction();
                _prospectsAction.ClickOnCreateProspects();
                //_prospectsAction.EnterProspectDetails(firstNameProspect, lastNameProspect, email, phoneCode, phoneNumber, moreInfo
                //  , prospectSource, companyName);
                _prospectsAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _prospectsAction.FilterDataBySearch(firstNameProspect);
                _prospectsAction.ValidateCreatedProspects(firstNameProspect, lastNameProspect, email);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("ProspectsTest")]
        //[TestCategory("CRM")]
        [Description("Tests the edit prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRM_212245.csv", "CRM_212245#csv", DataAccessMethod.Sequential), DeploymentItem("CRM_212245.csv")]
        [Ignore]
        public void TC_212245_EditProspect()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameProspect = this.TestContext.DataRow["firstName"].ToString();
                string lastNameProspect = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameProspect = firstNameProspect + rNum;
                    lastNameProspect = lastNameProspect + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string prospectSource = this.TestContext.DataRow["prospectSource"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                Boolean recordExist = loginAsUX1(function, inbox);
                if (recordExist.Equals(false)) { TC_212242_CreateNewProspect(); }
                _homeAction.MenuActions();
                List<String> firstRowValues = _prospectsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnEditProspects();
                _prospectsAction.ValidateProspectsInUpdatePage(firstRowValues);
                //_prospectsAction.EnterProspectDetails(firstNameProspect, lastNameProspect, email, phoneCode, phoneNumber, moreInfo
                //     , prospectSource, companyName);
                _prospectsAction.ClickUpdateProspect();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _prospectsAction.FilterDataBySearch(firstNameProspect);
                _prospectsAction.ValidateCreatedProspects(firstNameProspect, lastNameProspect, email);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Leads")]
        //[TestCategory("CRM")]
        [Description("Tests the create new leads functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMLeads_212247.csv", "CRMLeads_212247#csv", DataAccessMethod.Sequential), DeploymentItem("CRMLeads_212247.csv")]
        [Ignore]
        public void TC_212247_CreateLeadFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string leadSource = this.TestContext.DataRow["leadSource"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string intrestedIn = this.TestContext.DataRow["intrestedIn"].ToString();
                string campaignType = this.TestContext.DataRow["campaignType"].ToString();
                string rating = this.TestContext.DataRow["rating"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["State"].ToString();

                loginAsUX1(function, inbox);
                _inboxAction.ClickOnCreateMasterAction();
                _leadsAction.ClickOnCreateLeads();
                //_leadsAction.EnterLeadInformation(leadSource, firstName, lastName, email, moreInfo, topic, intrestedIn, campaignType, rating);
                _leadsAction.ClickOnCompanyInformation();
                //_leadsAction.EnterCompanyInformation(companyName, phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Leads")]
        //[TestCategory("CRM")]
        [Description("Tests the create new leads functionality of the application and validate in inbox")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMLeads_212247.csv", "CRMLeads_212247#csv", DataAccessMethod.Sequential), DeploymentItem("CRMLeads_212247.csv")]
        [Ignore]
        public void TC_212248_CreateLeadInInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string leadSource = this.TestContext.DataRow["leadSource"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string intrestedIn = this.TestContext.DataRow["intrestedIn"].ToString();
                string campaignType = this.TestContext.DataRow["campaignType"].ToString();
                string rating = this.TestContext.DataRow["rating"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                loginAsUX1(function, inbox);
                _inboxAction.ClickOnCreateMasterAction();
                _leadsAction.ClickOnCreateLeads();
                // _leadsAction.EnterLeadInformation(leadSource, firstName, lastName, email, moreInfo, topic, intrestedIn, campaignType, rating);
                _leadsAction.ClickOnCompanyInformation();
                //_leadsAction.EnterCompanyInformation(companyName, phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                //_leadsAction.ClickOnCreateLeadsButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                //_prospectsAction.FilterDataBySearch(firstName);
                //_leadsAction.ValidateCreatedLeadsInInboxGrid(firstName, lastName, rating, campaignType, intrestedIn);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Leads")]
        //[TestCategory("CRM")]
        [Description("Tests the edit leads functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMLeads_212249.csv", "CRMLeads_212249#csv", DataAccessMethod.Sequential), DeploymentItem("CRMLeads_212249.csv")]
        [Ignore]
        public void TC_212249_EditLeadFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string leadSource = this.TestContext.DataRow["leadSource"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string intrestedIn = this.TestContext.DataRow["intrestedIn"].ToString();
                string campaignType = this.TestContext.DataRow["campaignType"].ToString();
                string rating = this.TestContext.DataRow["rating"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();


                Boolean recordExist = loginAsUX1(function, inbox);
                if (recordExist.Equals(false)) { TC_212248_CreateLeadInInbox(); }
                _homeAction.MenuActions();
                List<String> firstRowValues = _leadsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _leadsAction.EditLead();
                _leadsAction.ValidateLeadsInUpdatePage(firstRowValues);
                //_leadsAction.EnterLeadInformation(leadSource, firstName, lastName, email, moreInfo, topic, intrestedIn, campaignType, rating);
                _leadsAction.ClickOnCompanyInformation();
                //_leadsAction.EnterCompanyInformation(companyName, phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                _leadsAction.ClickOnUpdateLeadsButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                //_prospectsAction.FilterDataBySearch(firstName);
                //_leadsAction.ValidateCreatedLeadsInInboxGrid(firstName, lastName, rating, campaignType, intrestedIn);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Leads")]
        //[TestCategory("CRM")]
        [Description("Tests the Validate Create Lead From Existing Prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMLeads_212250.csv", "CRMLeads_212250#csv", DataAccessMethod.Sequential), DeploymentItem("CRMLeads_212250.csv")]
        [Ignore]
        public void TC_212250_CreateLeadFromExistingProspect()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string leadSource = this.TestContext.DataRow["leadSource"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string intrestedIn = this.TestContext.DataRow["intrestedIn"].ToString();
                string campaignType = this.TestContext.DataRow["campaignType"].ToString();
                string rating = this.TestContext.DataRow["rating"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                Boolean recordExist = loginAsUX1(function, inbox);
                _prospectsAction.FilterDataBySearch("FN_");
                if (recordExist.Equals(false)) { TC_212242_CreateNewProspect(); }
                List<String> firstRowValues = _prospectsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnCreateLeadProspects();
                firstName = firstRowValues[0];
                lastName = firstRowValues[1];
                _leadsAction.ValidateLeadsInUpdatePageFromProspect(firstRowValues);
                _leadsAction.EnterLeadInformationFromProspect(moreInfo, topic, intrestedIn, campaignType, rating);
                _leadsAction.ClickOnCompanyInformation();
                //_leadsAction.EnterCompanyInformationFromProspect(phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                //_leadsAction.ClickOnCreateLeadsButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Contact")]
        //[TestCategory("CRM")]
        [Description("Tests the create new prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContacts_212252.csv", "CRMContacts_212252#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContacts_212252.csv")]
        [Ignore]
        public void TC_212252_CreatingnewContactFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameContact = this.TestContext.DataRow["firstName"].ToString();
                string lastNameContact = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameContact = firstNameContact + rNum;
                    lastNameContact = lastNameContact + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string modeOfContact = this.TestContext.DataRow["preferedModeOfContact"].ToString();
                string subscribeToMarketingMail = this.TestContext.DataRow["subscribeToMarketingMail"].ToString();
                string eComAccessLevel = this.TestContext.DataRow["eCommerceAccessLevel"].ToString();
                string accountName = this.TestContext.DataRow["accountName"].ToString();
                string companyPhoneCode = this.TestContext.DataRow["companyPhoneCode"].ToString();
                string companyPhoneNumber = this.TestContext.DataRow["companyPhoneNumber"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _contactsAction.ClickOnCreateContacts();
                //_contactsAction.EnterContactInformation(firstNameContact, lastNameContact, email, phoneCode, phoneNumber, moreInfo, modeOfContact, subscribeToMarketingMail, eComAccessLevel);
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.EnterCompanyInformation(accountName, phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Contact")]
        //[TestCategory("CRM")]
        [Description("Tests  Validate the newly created Contact is listed under inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContacts_212252.csv", "CRMContacts_212252#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContacts_212252.csv")]
        [Ignore]
        public void TC_212253_NewlyCreatedContactIsListedUnderInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameContact = this.TestContext.DataRow["firstName"].ToString();
                string lastNameContact = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameContact = firstNameContact + rNum;
                    lastNameContact = lastNameContact + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string fullPhoneNumber = phoneCode + phoneNumber;
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string modeOfContact = this.TestContext.DataRow["preferedModeOfContact"].ToString();
                string subscribeToMarketingMail = this.TestContext.DataRow["subscribeToMarketingMail"].ToString();
                string eComAccessLevel = this.TestContext.DataRow["eCommerceAccessLevel"].ToString();
                string accountName = this.TestContext.DataRow["accountName"].ToString();
                string companyPhoneCode = this.TestContext.DataRow["companyPhoneCode"].ToString();
                string companyPhoneNumber = this.TestContext.DataRow["companyPhoneNumber"].ToString();
                string fullCompanyNumber = companyPhoneCode + companyPhoneNumber;
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();


                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _contactsAction.ClickOnCreateContacts();
                //_contactsAction.EnterContactInformation(firstNameContact, lastNameContact, email, phoneCode, phoneNumber, moreInfo, modeOfContact, subscribeToMarketingMail, eComAccessLevel);
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.EnterCompanyInformation(accountName, phoneCode, companyPhoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                _contactsAction.ClickOnCreateContactsButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                // UncommentFrameworkissue
                // _homeAction.FilterDataBySearch(firstNameContact);
                _contactsAction.ValidateCreatedContactInInboxGrid(firstNameContact, lastNameContact, email, fullPhoneNumber
                    , accountName, fullCompanyNumber, companyWebsite);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Contact")]
        //[TestCategory("CRM")]
        [Description("Tests  Validate Editing Contact Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContacts_212254.csv", "CRMContacts_212254#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContacts_212254.csv")]
        [Ignore]
        public void TC_212254_EditingContactFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameContact = this.TestContext.DataRow["firstName"].ToString();
                string lastNameContact = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameContact = firstNameContact + rNum;
                    lastNameContact = lastNameContact + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string fullPhoneNumber = phoneCode + phoneNumber;
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string modeOfContact = this.TestContext.DataRow["preferedModeOfContact"].ToString();
                string subscribeToMarketingMail = this.TestContext.DataRow["subscribeToMarketingMail"].ToString();
                string eComAccessLevel = this.TestContext.DataRow["eCommerceAccessLevel"].ToString();
                string accountName = this.TestContext.DataRow["accountName"].ToString();
                string companyPhoneCode = this.TestContext.DataRow["companyPhoneCode"].ToString();
                string companyPhoneNumber = this.TestContext.DataRow["companyPhoneNumber"].ToString();
                string fullCompanyNumber = companyPhoneCode + companyPhoneNumber;
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                Boolean recordExist = loginAsUX1(function, inbox);
                if (recordExist.Equals(false)) { TC_212253_NewlyCreatedContactIsListedUnderInbox(); }
                _homeAction.MenuActions();
                List<String> firstRowValues = _contactsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                //_contactsAction.EditContacts();
                _contactsAction.ValidateContactInformationInUpdatePage(firstRowValues);
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.ValidateCompanyInformationInUpdatePage(firstRowValues);
                _contactsAction.ClickOnContactInformation();
                //_contactsAction.EnterContactInformation(firstNameContact, lastNameContact, email, phoneCode, phoneNumber, moreInfo, modeOfContact, subscribeToMarketingMail, eComAccessLevel);
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.EnterCompanyInformation(accountName, phoneCode, companyPhoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                //_contactsAction.ClickOnUpdateContactsButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                // RemoveFrameworkIssue
                _prospectsAction.ClearSearchField();
                //FrameworkIssueUncomment
                //_homeAction.FilterDataBySearch(firstNameContact);
                _contactsAction.ValidateCreatedContactInInboxGrid(firstNameContact, lastNameContact, email, fullPhoneNumber
                     , accountName, fullCompanyNumber, companyWebsite);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Contacts")]
        //[TestCategory("CRM")]
        [Description("Tests the Validate Create contacts From Existing Prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContacts_212255.csv", "CRMContacts_212255#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContacts_212255.csv")]
        [Ignore]
        public void TC_212255_CreateContactsFromExistingProspect()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameContact = this.TestContext.DataRow["firstName"].ToString();
                string lastNameContact = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameContact = firstNameContact + rNum;
                    lastNameContact = lastNameContact + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string modeOfContact = this.TestContext.DataRow["preferedModeOfContact"].ToString();
                string subscribeToMarketingMail = this.TestContext.DataRow["subscribeToMarketingMail"].ToString();
                string eComAccessLevel = this.TestContext.DataRow["eCommerceAccessLevel"].ToString();
                string accountName = this.TestContext.DataRow["accountName"].ToString();
                string companyPhoneCode = this.TestContext.DataRow["companyPhoneCode"].ToString();
                string companyPhoneNumber = this.TestContext.DataRow["companyPhoneNumber"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                int rowNum;

                Boolean recordExist = loginAsUX1(function, inbox);
                _prospectsAction.FilterDataBySearch("FN_");
                if (recordExist.Equals(false)) { TC_212242_CreateNewProspect(); }
                rowNum = _prospectsAction.RowNumberWithoutConvertedToContact();
                List<String> firstRowValues = _prospectsAction.GetFirstRowValuesByRowNumber(rowNum);
                _inboxAction.ClickOnDetailActionSpecificRow(rowNum);
                _prospectsAction.ClickOnCreateContactsProspects();
                firstNameContact = firstRowValues[0];
                lastNameContact = firstRowValues[1];
                _contactsAction.ValidateContactInformationInUpdatePageFromProspect(firstRowValues);
                //_contactsAction.EnterContactInformation(firstNameContact, lastNameContact, email, phoneCode, phoneNumber, moreInfo, modeOfContact, subscribeToMarketingMail, eComAccessLevel, "Prospects");
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.EnterCompanyInformation(accountName, phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                //_contactsAction.ClickOnUpdateContactssButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Contacts")]
        //[TestCategory("CRM")]
        [Description("Tests the Validate Create Lead From Existing Prospect functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContacts_212255.csv", "CRMContacts_212255#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContacts_212255.csv")]
        [Ignore]
        public void TC_212264_CreateContactsFromExistingProspectListingUnderContact()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstNameContact = this.TestContext.DataRow["firstName"].ToString();
                string lastNameContact = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstNameContact = firstNameContact + rNum;
                    lastNameContact = lastNameContact + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string fullPhoneNumber = phoneCode + phoneNumber;
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string modeOfContact = this.TestContext.DataRow["preferedModeOfContact"].ToString();
                string subscribeToMarketingMail = this.TestContext.DataRow["subscribeToMarketingMail"].ToString();
                string eComAccessLevel = this.TestContext.DataRow["eCommerceAccessLevel"].ToString();
                string accountName = this.TestContext.DataRow["accountName"].ToString();
                string companyPhoneCode = this.TestContext.DataRow["companyPhoneCode"].ToString();
                string companyPhoneNumber = this.TestContext.DataRow["companyPhoneNumber"].ToString();
                string fullCompanyNumber = companyPhoneCode + companyPhoneNumber;
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                int rowNum;

                Boolean recordExist = loginAsUX1(function, inbox);
                _prospectsAction.FilterDataBySearch("FN_");
                if (recordExist.Equals(false)) { TC_212242_CreateNewProspect(); }
                // RemoveFrameworkIssue
                _homeAction.ClickOnRefreshButton();
                rowNum = _prospectsAction.RowNumberWithoutConvertedToContact();
                List<String> firstRowValues = _prospectsAction.GetFirstRowValuesByRowNumber(rowNum);
                _inboxAction.ClickOnDetailActionSpecificRow(rowNum);
                _prospectsAction.ClickOnCreateContactsProspects();
                firstNameContact = firstRowValues[0];
                lastNameContact = firstRowValues[1];
                email = firstRowValues[2];
                _contactsAction.ValidateContactInformationInUpdatePageFromProspect(firstRowValues);
                //_contactsAction.EnterContactInformation(firstNameContact, lastNameContact, email, phoneCode, phoneNumber, moreInfo, modeOfContact, subscribeToMarketingMail, eComAccessLevel, "Prospects");
                _contactsAction.ClickOnCompanyInformation();
                _contactsAction.EnterCompanyInformation(accountName, phoneCode, companyPhoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                _contactsAction.ClickOnCreateContactsButton();
                _prospectsAction.ClickBackButton();
                // RemoveFrameworkIssue
                _prospectsAction.ClearSearchField();
                _homeAction.MenuActions();
                NavigateToInboxByGlobalSearch(function, "Contacts (Sales)", false);
                //RemoveFrameworkIssue
                _homeAction.ClickOnRefreshButton();
                //UnCommentFrameworkIssue
                //_prospectsAction.FilterDataBySearch(firstName);
                _contactsAction.ValidateCreatedContactInInboxGrid(firstNameContact, lastNameContact, email, fullPhoneNumber
                        , accountName, fullCompanyNumber, companyWebsite);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Leads")]
        //[TestCategory("CRM")]
        [Description("Tests the Validate Create lead from prospect is listing under lead inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMLeads_212250.csv", "CRMLeads_212250#csv", DataAccessMethod.Sequential), DeploymentItem("CRMLeads_212250.csv")]
        [Ignore]
        public void TC_212262_CreateLeadFromProspectListingUnderLeadInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string moreInfo = this.TestContext.DataRow["moreInfo"].ToString();
                string leadSource = this.TestContext.DataRow["leadSource"].ToString();
                string topic = this.TestContext.DataRow["topic"].ToString();
                string intrestedIn = this.TestContext.DataRow["intrestedIn"].ToString();
                string campaignType = this.TestContext.DataRow["campaignType"].ToString();
                string rating = this.TestContext.DataRow["rating"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string companyWebsite = this.TestContext.DataRow["companyWebsite"].ToString();
                string address1 = this.TestContext.DataRow["companyAddressLine1"].ToString();
                string address2 = this.TestContext.DataRow["companyAddressLine2"].ToString();
                string address3 = this.TestContext.DataRow["companyAddressLine3"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zipcode = this.TestContext.DataRow["zipCode"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                Boolean recordExist = loginAsUX1(function, inbox);
                _prospectsAction.FilterDataBySearch("FN_");
                if (recordExist.Equals(false)) { TC_212242_CreateNewProspect(); }
                // RemoveFrameworkIssue
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValues = _prospectsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prospectsAction.ClickOnCreateLeadProspects();
                firstName = firstRowValues[0];
                lastName = firstRowValues[1];
                _leadsAction.ValidateLeadsInUpdatePageFromProspect(firstRowValues);
                _leadsAction.EnterLeadInformationFromProspect(moreInfo, topic, intrestedIn, campaignType, rating);
                _leadsAction.ClickOnCompanyInformation();
                //_leadsAction.EnterCompanyInformationFromProspect(phoneCode, phoneNumber, companyWebsite, address1, address2, address3, city, zipcode, country, state);
                //_leadsAction.ClickOnCreateLeadsButton();
                _prospectsAction.ClickBackButton();
                // RemoveFrameworkIssue
                _prospectsAction.ClearSearchField();
                _homeAction.MenuActions();
                NavigateToInboxByGlobalSearch(function, "Leads (Sales)", false);
                //RemoveFrameworkIssue
                _homeAction.ClickOnRefreshButton();
                //UnCommentFrameworkIssue
                //_prospectsAction.FilterDataBySearch(firstName);
                //_leadsAction.ValidateCreatedLeadsInInboxGrid(firstName, lastName, rating, campaignType, intrestedIn);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebForm")]
        [TestCategory("CRM")]
        [Description("Tests the create new webform functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebForm_254161.csv", "CRMWebForm_254161#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebForm_254161.csv")]
        [Ignore]
        public void TC_254161_CreateWebformFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();

                string name = this.TestContext.DataRow["name"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    name = name + rNum;
                    subject = subject + rNum;
                }
                string webForm = this.TestContext.DataRow["webForm"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();


                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webFormAction.ClickOnWebForm();
                _webFormAction.EnterWebForm(name, subject, webForm, reference, startTime);
                _webFormAction.ClickCreateButton();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebForm")]
        [TestCategory("CRM")]
        [Description("Tests the Validate Newly Created Webform Listed Under Activity Inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebForm_254161.csv", "CRMWebForm_254161#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebForm_254161.csv")]
        [Ignore]
        public void TC_254165_NewlyCreatedWebformListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();

                string name = this.TestContext.DataRow["name"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    name = name + rNum;
                    subject = subject + rNum;
                }
                string webForm = this.TestContext.DataRow["webForm"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string regarding = string.Empty;


                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webFormAction.ClickOnWebForm();
                regarding = _webFormAction.EnterWebForm(name, subject, webForm, reference, startTime);
                _webFormAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webFormAction.ClickOnWebFormTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webFormAction.ValidateCreatedWebformInInboxGrid(subject, "Open", "Web Form", regarding);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebForm")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Web Form Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebForm_254172.csv", "CRMWebForm_254172#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebForm_254172.csv")]
        [Ignore]
        public void TC_254172_EditingWebFormFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();

                string name = this.TestContext.DataRow["name"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    name = name + rNum;
                    subject = subject + rNum;
                }
                string webForm = this.TestContext.DataRow["webForm"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string regarding = string.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _webFormAction.ClickOnWebFormTab();
                List<String> firstRowValues = _contactsAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _webFormAction.ClickOnEditWebForm();
                _webFormAction.ValidateWebFormInUpdatePage(firstRowValues);
                regarding = _webFormAction.EnterWebForm(name, subject, webForm, reference, startTime);
                _webFormAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webFormAction.ClickOnWebFormTab();
                _homeAction.ClearSearchField();
                //FrameworkIssueUnCommentafter fix
                //_homeAction.FilterDataBySearch(subject);
                _webFormAction.ValidateCreatedWebformInInboxGrid(subject, "Open", "Web Form", regarding);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CampaignResponse")]
        [TestCategory("CRM")]
        [Description("Tests the Create Campaign Response functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCampaignResponse_254158.csv", "CRMCampaignResponse_254158#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCampaignResponse_254158.csv")]
        [Ignore]
        public void TC_254158_CreateCampaignResponseFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string description = this.TestContext.DataRow["discription"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    description = description + rNum;
                    subject = subject + rNum;
                }
                string relatedCampaign = this.TestContext.DataRow["relatedCampaign"].ToString();
                string responceType = this.TestContext.DataRow["responceType"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string promeCode = this.TestContext.DataRow["promoCode"].ToString();
                string outsourcedVendor = this.TestContext.DataRow["outsourcedVendor"].ToString();
                string receivedFrom = this.TestContext.DataRow["receivedFrom"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _campaignResponceAction.ClickOnCreateCampaignResponce();
                _campaignResponceAction.EnterCampaignResponce(subject, description, relatedCampaign, responceType,
                    channel, priority, promeCode, outsourcedVendor, receivedFrom, phone);
                _campaignResponceAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CampaignResponse")]
        [TestCategory("CRM")]
        [Description("Test the Validate newly created Campaign Response is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCampaignResponse_254158.csv", "CRMCampaignResponse_254158#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCampaignResponse_254158.csv")]
        [Ignore]
        public void TC_254166_NewlyCreatedCampaignResponseListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string description = this.TestContext.DataRow["discription"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    description = description + rNum;
                    subject = subject + rNum;
                }
                string relatedCampaign = this.TestContext.DataRow["relatedCampaign"].ToString();
                string responceType = this.TestContext.DataRow["responceType"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string promeCode = this.TestContext.DataRow["promoCode"].ToString();
                string outsourcedVendor = this.TestContext.DataRow["outsourcedVendor"].ToString();
                string receivedFrom = this.TestContext.DataRow["receivedFrom"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();
                string regarding = String.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _campaignResponceAction.ClickOnCreateCampaignResponce();
                regarding = _campaignResponceAction.EnterCampaignResponce(subject, description, relatedCampaign, responceType,
                    channel, priority, promeCode, outsourcedVendor, receivedFrom, phone);
                _campaignResponceAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _campaignResponceAction.ClickOnCampaignResponceTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webFormAction.ValidateCreatedWebformInInboxGrid(subject, "Open", "Campaign Response", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CampaignResponse")]
        [TestCategory("CRM")]
        [Description("Test the Validate Editing Campaign Response Flow (TC 254173) functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCampaignResponse_254173.csv", "CRMCampaignResponse_254173#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCampaignResponse_254173.csv")]
        [Ignore]
        public void TC_254173_EditingCampaignResponseFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string description = this.TestContext.DataRow["discription"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    description = description + rNum;
                    subject = subject + rNum;
                }
                string relatedCampaign = this.TestContext.DataRow["relatedCampaign"].ToString();
                string responceType = this.TestContext.DataRow["responceType"].ToString();
                string channel = this.TestContext.DataRow["channel"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string promeCode = this.TestContext.DataRow["promoCode"].ToString();
                string outsourcedVendor = this.TestContext.DataRow["outsourcedVendor"].ToString();
                string receivedFrom = this.TestContext.DataRow["receivedFrom"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();
                string regarding = String.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _campaignResponceAction.ClickOnCampaignResponceTab();
                List<String> firstRowValues = _inboxAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _campaignResponceAction.ClickOnEditCampaignResponce();
                _campaignResponceAction.ValidateCampaignResponseInUpdatePage(firstRowValues);
                _campaignResponceAction.ClickCampaignInformationTab();
                regarding = _campaignResponceAction.EnterCampaignResponce(subject, description, relatedCampaign, responceType,
                    channel, priority, promeCode, outsourcedVendor, receivedFrom, phone);
                _campaignResponceAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _campaignResponceAction.ClickOnCampaignResponceTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);

                _webFormAction.ValidateCreatedWebformInInboxGrid(subject, "Open", "Campaign Response", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebFormKmApproval")]
        [TestCategory("CRM")]
        [Description("Tests the create new WebFormKmApproval functionality of the application")]
        [Owner("Harshitha.Penamalli@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKm_281941.csv", "CRMWebFormKm_281941#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKm_281941.csv")]
        [Ignore]
        public void TC_326558_CreateWebformKmApprovalFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                }
                string ApprovalStatus = this.TestContext.DataRow["approvalStatus"].ToString();
                string ApprovalEmail = this.TestContext.DataRow["approvalEmail"].ToString();
                string Comments = this.TestContext.DataRow["comments"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string link = this.TestContext.DataRow["link"].ToString();
                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webformKmApprovalAction.ClickOnWebFormKmApproval();
                _webformKmApprovalAction.EnterWebFormKmApproval(subject, reference, ApprovalStatus, ApprovalEmail, Comments);
                _webformKmApprovalAction.ClickKMCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebFormKmApproval")]
        [TestCategory("CRM")]
        [Description("Tests Validate newly created Web Form-Km Approval is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKm_281941.csv", "CRMWebFormKm_281941#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKm_281941.csv")]
        [Ignore]
        public void TC_327984_NewlyCreatedWebFormKMApprovalListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                }
                string ApprovalStatus = this.TestContext.DataRow["approvalStatus"].ToString();
                string ApprovalEmail = this.TestContext.DataRow["approvalEmail"].ToString();
                string Comments = this.TestContext.DataRow["comments"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string link = this.TestContext.DataRow["link"].ToString();
                string regarding;
                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webformKmApprovalAction.ClickOnWebFormKmApproval();
                regarding = _webformKmApprovalAction.EnterWebFormKmApproval(subject, reference, ApprovalStatus, ApprovalEmail, Comments);
                _webformKmApprovalAction.ClickKMCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webformKmApprovalAction.ClickOnKMApprovalTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webinarAction.ValidateCreatedWebinarInInboxGrid(subject, "Open", "Web Form KM Approval", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebFormKmApproval")]
        [TestCategory("CRM")]
        [Description("Tests Validate edit Web Form-Km Approval functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKm_327991.csv", "CRMWebFormKm_327991#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKm_327991.csv")]
        [Ignore]
        public void TC_327991_EditingWebFormKMApprovalFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                }
                string ApprovalStatus = this.TestContext.DataRow["approvalStatus"].ToString();
                string ApprovalEmail = this.TestContext.DataRow["approvalEmail"].ToString();
                string Comments = this.TestContext.DataRow["comments"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string link = this.TestContext.DataRow["link"].ToString();
                string regarding;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _webformKmApprovalAction.ClickOnKMApprovalTab();
                List<String> firstRowValues = _inboxAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _webformKmApprovalAction.ClickOnEditKMApproval();
                _webformKmApprovalAction.ValidateContactUsInUpdatePage(firstRowValues);
                regarding = _webformKmApprovalAction.EnterWebFormKmApproval(subject, reference, ApprovalStatus, ApprovalEmail, Comments);
                _contactUSAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webformKmApprovalAction.ClickOnKMApprovalTab();
                //CommentAfterFix
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                ////CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webinarAction.ValidateCreatedWebinarInInboxGrid(subject, "Open", "Web Form KM Approval", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebformKMRegistration")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Webform Km registration Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKMRegistration_254160.csv", "CRMWebFormKMRegistration_254160#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKMRegistration_254160.csv")]
        [Ignore]
        public void TC_254160_CreateWebformKmRegistrationFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    companyName = companyName + rNum;
                }
                string reference = this.TestContext.DataRow["reference"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webformKMRegistrationAction.ClickOnWebFormKMRegistration();
                _webformKMRegistrationAction.EnterWebformKMRegistration(subject, reference, firstName, lastName,
                    email, country, companyName, city, state);
                _webformKMRegistrationAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebformKMRegistration")]
        [TestCategory("CRM")]
        [Description("Test Validate newly created Web Form-Km Registration is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKMRegistration_254160.csv", "CRMWebFormKMRegistration_254160#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKMRegistration_254160.csv")]
        [Ignore]
        public void TC_254168_NewlyCreatedWebFormKMRegistrationListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    companyName = companyName + rNum;
                }
                string reference = this.TestContext.DataRow["reference"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string regarding = string.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webformKMRegistrationAction.ClickOnWebFormKMRegistration();
                regarding = _webformKMRegistrationAction.EnterWebformKMRegistration(subject, reference, firstName, lastName,
                    email, country, companyName, city, state);
                _webformKMRegistrationAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webformKMRegistrationAction.ClickOnKMRegistrationTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webformKMRegistrationAction.ValidateCreatedContactInInboxGrid(subject, "Open", "Web Form KM Registration", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("WebformKMRegistration")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing WebForm KM Registration Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebFormKMRegistration_254175.csv", "CRMWebFormKMRegistration_254175#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebFormKMRegistration_254175.csv")]
        [Ignore]
        public void TC_254175_EditingWebFormKMRegistrationFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    companyName = companyName + rNum;
                }
                string reference = this.TestContext.DataRow["reference"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string regarding = string.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _webformKMRegistrationAction.ClickOnKMRegistrationTab();
                List<String> firstRowValues = _inboxAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _webformKMRegistrationAction.ClickOnEditKMRegistration();
                _webformKMRegistrationAction.ValidateCampaignResponseInUpdatePage(firstRowValues);
                regarding = _webformKMRegistrationAction.EnterWebformKMRegistration(subject, reference, firstName, lastName,
                    email, country, companyName, city, state);
                _webformKMRegistrationAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webformKMRegistrationAction.ClickOnKMRegistrationTab();
                //CommentAfterFix
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);

                _webformKMRegistrationAction.ValidateCreatedContactInInboxGrid(subject, "Open", "Web Form KM Registration", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Webinar")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Webinar Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebinar_254156.csv", "CRMWebinar_254156#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebinar_254156.csv")]
        [Ignore]
        public void TC_254156_CreateWebinarScreen()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string comment = this.TestContext.DataRow["comments"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webinarAction.ClickOnCreateWebinar();
                _webinarAction.EnterWebinar(subject, reference, firstName, lastName,
                    email, country, phoneCode, phoneNumber, comment);
                _webinarAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Webinar")]
        [TestCategory("CRM")]
        [Description("Test Validate Newly created Webinar is listed under Activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebinar_254156.csv", "CRMWebinar_254156#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebinar_254156.csv")]
        [Ignore]
        public void TC_254180_NewlyCreatedWebinarListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string comment = this.TestContext.DataRow["comments"].ToString();
                string regarding;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _webinarAction.ClickOnCreateWebinar();
                regarding = _webinarAction.EnterWebinar(subject, reference, firstName, lastName,
                    email, country, phoneCode, phoneNumber, comment);
                _webinarAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webinarAction.ClickOnWebinarTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webinarAction.ValidateCreatedWebinarInInboxGrid(subject, "Open", "Webinar", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Webinar")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Webinar Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMWebinar_254181.csv", "CRMWebinar_254181#csv", DataAccessMethod.Sequential), DeploymentItem("CRMWebinar_254181.csv")]
        [Ignore]
        public void TC_254181_EditingWebinarFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();

                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string comment = this.TestContext.DataRow["comments"].ToString();
                string regarding;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _webinarAction.ClickOnWebinarTab();
                List<String> firstRowValues = _inboxAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _webinarAction.ClickOnEditWebinar();
                _webinarAction.ValidateWebinarInUpdatePage(firstRowValues);
                regarding = _webinarAction.EnterWebinar(subject, reference, firstName, lastName,
                    email, country, phoneCode, phoneNumber, comment);
                _webinarAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _webinarAction.ClickOnWebinarTab();
                //CommentAfterFix
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                _webinarAction.ValidateCreatedWebinarInInboxGrid(subject, "Open", "Webinar", regarding);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ContactUS")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Contact Us Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContactUs_318657.csv", "CRMContactUs_318657#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContactUs_318657.csv")]
        [Ignore]
        public void TC_327955_CreateContactUsScreen()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string title = this.TestContext.DataRow["title"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string street = this.TestContext.DataRow["street"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string customerIntrest = this.TestContext.DataRow["customerIntrest"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    title = title + rNum;
                    companyName = companyName + rNum;
                    street = street + rNum;
                    message = message + rNum;
                    customerIntrest = customerIntrest + rNum;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _contactUSAction.ClickOnCreateContactUs();
                _contactUSAction.EnterContactUs(subject, reference, startTime, firstName, lastName, email, title,
                    companyName, street, city, zip, country, state, message, customerIntrest, phoneCode, phoneNumber);
                _contactUSAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ContactUS")]
        [TestCategory("CRM")]
        [Description("Test Validate newly created Contact us  is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContactUs_318657.csv", "CRMContactUs_318657#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContactUs_318657.csv")]
        [Ignore]
        public void TC_327956_NewlyCreatedContactUsListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string title = this.TestContext.DataRow["title"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string street = this.TestContext.DataRow["street"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string customerIntrest = this.TestContext.DataRow["customerIntrest"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    title = title + rNum;
                    companyName = companyName + rNum;
                    street = street + rNum;
                    message = message + rNum;
                    customerIntrest = customerIntrest + rNum;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string regarding = string.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _contactUSAction.ClickOnCreateContactUs();
                regarding = _contactUSAction.EnterContactUs(subject, reference, startTime, firstName, lastName, email, title,
                    companyName, street, city, zip, country, state, message, customerIntrest, phoneCode, phoneNumber);
                _contactUSAction.ClickCreateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _contactUSAction.ClickOnContactUsTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _webFormAction.ValidateCreatedWebformInInboxGrid(subject, "Open", "Contact Us", regarding);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ContactUS")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Contact us  Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMContactUs_318659.csv", "CRMContactUs_318659#csv", DataAccessMethod.Sequential), DeploymentItem("CRMContactUs_318659.csv")]
        [Ignore]
        public void TC_327957_EditingContactUsFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString();
                string firstName = this.TestContext.DataRow["firstName"].ToString();
                string lastName = this.TestContext.DataRow["lastName"].ToString();
                string email = this.TestContext.DataRow["email"].ToString();
                string title = this.TestContext.DataRow["title"].ToString();
                string companyName = this.TestContext.DataRow["companyName"].ToString();
                string street = this.TestContext.DataRow["street"].ToString();
                string message = this.TestContext.DataRow["message"].ToString();
                string customerIntrest = this.TestContext.DataRow["customerIntrest"].ToString();
                if (randomNum.Equals("Yes"))
                {
                    string rNum = _helper.GenerateUniqueRandomNumber();
                    subject = subject + rNum;
                    firstName = firstName + rNum;
                    lastName = lastName + rNum;
                    email = rNum + email;
                    title = title + rNum;
                    companyName = companyName + rNum;
                    street = street + rNum;
                    message = message + rNum;
                    customerIntrest = customerIntrest + rNum;
                }
                string country = this.TestContext.DataRow["country"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string state = this.TestContext.DataRow["state"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string regarding = string.Empty;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _contactUSAction.ClickOnContactUsTab();
                List<String> firstRowValues = _inboxAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _contactUSAction.ClickOnEditContactUs();
                _contactUSAction.ValidateContactUsInUpdatePage(firstRowValues);
                regarding = _contactUSAction.EnterContactUs(subject, reference, startTime, firstName, lastName, email, title,
                   companyName, street, city, zip, country, state, message, customerIntrest, phoneCode, phoneNumber);
                _contactUSAction.ClickUpdateButton();
                _prospectsAction.ClickBackButton();
                _homeAction.MenuActions();
                _contactUSAction.ClickOnContactUsTab();
                //CommentAfterFix
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);  
                _contactUSAction.ValidateCreatedWebinarInInboxGrid(subject, "Open", "Contact Us", regarding);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PRQ")]
        [TestCategory("CRM")]
        [Description("Test Validate Create PRQ Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPRQ_327998.csv", "CRMPRQ_327998#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPRQ_327998.csv")]
        [Ignore]
        public void TC_327998_CreatePRQScreen()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string firstName = this.TestContext.DataRow["firstName"].ToString() + rNum;
                string lastName = this.TestContext.DataRow["lastName"].ToString() + rNum;
                string email = this.TestContext.DataRow["email"].ToString() + rNum;
                string companyName = this.TestContext.DataRow["companyName"].ToString() + rNum;
                string productName = this.TestContext.DataRow["productName"].ToString() + rNum;
                string chemicalDescription = this.TestContext.DataRow["chemicalDescription"].ToString() + rNum;
                string chemicalName = this.TestContext.DataRow["chemicalName"].ToString() + rNum;
                string therapeuticCategory = this.TestContext.DataRow["therapeuticCategory"].ToString() + rNum;
                string excipientsUsed = this.TestContext.DataRow["excipientsUsed"].ToString() + rNum;
                string storageCondition = this.TestContext.DataRow["storageCondition"].ToString() + rNum;
                string sensivities = this.TestContext.DataRow["sensivities"].ToString() + rNum;
                string sensivitiesComments = this.TestContext.DataRow["sensivitiesComments"].ToString() + rNum;
                string address1 = this.TestContext.DataRow["address1"].ToString() + rNum;
                string address2 = this.TestContext.DataRow["address2"].ToString() + rNum;
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();
                string pH = this.TestContext.DataRow["pH"].ToString();

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _prqAction.ClickOnPRQ();
                _prqAction.EnterPersonalInformation(companyName, firstName, lastName, address1,
                    address2, city, region, country, zip, email, phone);
                _prqAction.ClickOnProductInformationTab();
                _prqAction.EnterProductInformation(productName, chemicalDescription, chemicalName, therapeuticCategory,
                    excipientsUsed, pH, storageCondition, sensivities, sensivitiesComments);
                _crmCommonAction.ClickCreateButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PRQ")]
        [TestCategory("CRM")]
        [Description("Test Validate newly created PRQ  is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPRQ_327998.csv", "CRMPRQ_327998#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPRQ_327998.csv")]
        [Ignore]
        public void TC_327999_CreatedPRQListedUnderActivityInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string firstName = this.TestContext.DataRow["firstName"].ToString() + rNum;
                string lastName = this.TestContext.DataRow["lastName"].ToString() + rNum;
                string email = this.TestContext.DataRow["email"].ToString() + rNum;
                string companyName = this.TestContext.DataRow["companyName"].ToString() + rNum;
                string productName = this.TestContext.DataRow["productName"].ToString() + rNum;
                string chemicalDescription = this.TestContext.DataRow["chemicalDescription"].ToString() + rNum;
                string chemicalName = this.TestContext.DataRow["chemicalName"].ToString() + rNum;
                string therapeuticCategory = this.TestContext.DataRow["therapeuticCategory"].ToString() + rNum;
                string excipientsUsed = this.TestContext.DataRow["excipientsUsed"].ToString() + rNum;
                string storageCondition = this.TestContext.DataRow["storageCondition"].ToString() + rNum;
                string sensivities = this.TestContext.DataRow["sensivities"].ToString() + rNum;
                string sensivitiesComments = this.TestContext.DataRow["sensivitiesComments"].ToString() + rNum;
                string address1 = this.TestContext.DataRow["address1"].ToString() + rNum;
                string address2 = this.TestContext.DataRow["address2"].ToString() + rNum;
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();
                string pH = this.TestContext.DataRow["pH"].ToString();
                string regarding = "selvaraj,tamilmani <tamilmani.selvaraj02@westpharma.com>";
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _prqAction.ClickOnPRQ();
                _prqAction.EnterPersonalInformation(companyName, firstName, lastName, address1,
                    address2, city, region, country, zip, email, phone);
                _prqAction.ClickOnProductInformationTab();
                _prqAction.EnterProductInformation(productName, chemicalDescription, chemicalName, therapeuticCategory,
                    excipientsUsed, pH, storageCondition, sensivities, sensivitiesComments);
                _crmCommonAction.ClickCreateButton();
                _crmCommonAction.ClickBackButton();
                _homeAction.MenuActions();
                _prqAction.ClickOnPRQTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _prqAction.ValidateCreatedPRQInInboxGrid(companyName, "Open", "PRQ", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PRQ")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing PRQ Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPRQ_328000.csv", "CRMPRQ_328000#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPRQ_328000.csv")]
        [Ignore]
        public void TC_328000_EditPRQ()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string firstName = this.TestContext.DataRow["firstName"].ToString() + rNum;
                string lastName = this.TestContext.DataRow["lastName"].ToString() + rNum;
                string email = this.TestContext.DataRow["email"].ToString() + rNum;
                string companyName = this.TestContext.DataRow["companyName"].ToString() + rNum;
                string productName = this.TestContext.DataRow["productName"].ToString() + rNum;
                string chemicalDescription = this.TestContext.DataRow["chemicalDescription"].ToString() + rNum;
                string chemicalName = this.TestContext.DataRow["chemicalName"].ToString() + rNum;
                string therapeuticCategory = this.TestContext.DataRow["therapeuticCategory"].ToString() + rNum;
                string excipientsUsed = this.TestContext.DataRow["excipientsUsed"].ToString() + rNum;
                string storageCondition = this.TestContext.DataRow["storageCondition"].ToString() + rNum;
                string sensivities = this.TestContext.DataRow["sensivities"].ToString() + rNum;
                string sensivitiesComments = this.TestContext.DataRow["sensivitiesComments"].ToString() + rNum;
                string address1 = this.TestContext.DataRow["address1"].ToString() + rNum;
                string address2 = this.TestContext.DataRow["address2"].ToString() + rNum;
                string city = this.TestContext.DataRow["city"].ToString();
                string zip = this.TestContext.DataRow["zip"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string phone = this.TestContext.DataRow["phone"].ToString();
                string pH = this.TestContext.DataRow["pH"].ToString();
                string regarding = "selvaraj,tamilmani <tamilmani.selvaraj02@westpharma.com>";
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _prqAction.ClickOnPRQTab();
                List<String> firstRowValues = _crmCommonAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _prqAction.ClickEditPRQ();
                _prqAction.ValidatePRQInUpdatePage(firstRowValues);
                _prqAction.EnterPersonalInformation(companyName, firstName, lastName, address1,
                    address2, city, region, country, zip, email, phone);
                _prqAction.ClickOnProductInformationTab();
                _prqAction.EnterProductInformation(productName, chemicalDescription, chemicalName, therapeuticCategory,
                    excipientsUsed, pH, storageCondition, sensivities, sensivitiesComments);
                _crmCommonAction.ClickUpdateButton();
                _crmCommonAction.ClickBackButton();
                _homeAction.MenuActions();
                _prqAction.ClickOnPRQTab();
                //CommentAfterFix
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                ////CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _prqAction.ValidateCreatedPRQInInboxGrid(companyName, "Open", "PRQ", regarding);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test Validate Cases Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328056.csv", "CRMCases_328056#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328056.csv")]
        [Ignore]
        public void TC_328056_CreateCasesFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string casesInvolvment = this.TestContext.DataRow["casesInvolvment"].ToString() + rNum;
                string title = this.TestContext.DataRow["title"].ToString() + rNum;
                string account = this.TestContext.DataRow["account"].ToString() + rNum;
                string contact = this.TestContext.DataRow["contact"].ToString() + rNum;
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString() + rNum;
                string origin = this.TestContext.DataRow["origin"].ToString() + rNum;
                string product = this.TestContext.DataRow["product"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string westProgramName = this.TestContext.DataRow["westProgramName"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;


                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _casesAction.ClickOnCreateCase();
                _casesAction.EnterPersonalInformation(casesInvolvment, title, productOrigin, origin, priority, description);
                _casesAction.ClickCreateButton();
                _casesAction.AddCaseClassification();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test Validate Cases listed in inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328056.csv", "CRMCases_328056#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328056.csv")]
        [Ignore]
        public void TC_328055_CreateCasesListedUnderInbox()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string casesInvolvment = this.TestContext.DataRow["casesInvolvment"].ToString() + rNum;
                string title = this.TestContext.DataRow["title"].ToString() + rNum;
                string account = this.TestContext.DataRow["account"].ToString() + rNum;
                string contact = this.TestContext.DataRow["contact"].ToString() + rNum;
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString() + rNum;
                string origin = this.TestContext.DataRow["origin"].ToString() + rNum;
                string product = this.TestContext.DataRow["product"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string westProgramName = this.TestContext.DataRow["westProgramName"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                String[] caseNumber;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _casesAction.ClickOnCreateCase();
                caseNumber = _casesAction.EnterPersonalInformation(casesInvolvment, title, productOrigin, origin, priority, description);
                _casesAction.ClickCreateButton();
                _casesAction.AddCaseClassification();
                _crmCommonAction.ClickBackButton();
                _homeAction.MenuActions();
                _casesAction.ClickOnOpenCasesTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _casesAction.ValidateCreatedPRQInInboxGrid(caseNumber[0], title, caseNumber[1], "Open", priority);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test Validate Edit Case functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328057.csv", "CRMCases_328057#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328057.csv")]
        [Ignore]
        public void TC_328057_ValidateEditCase()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = _helper.GenerateUniqueRandomNumber();
                }
                string casesInvolvment = this.TestContext.DataRow["casesInvolvment"].ToString() + rNum;
                string title = this.TestContext.DataRow["title"].ToString() + rNum;
                string account = this.TestContext.DataRow["account"].ToString() + rNum;
                string contact = this.TestContext.DataRow["contact"].ToString() + rNum;
                string productOrigin = this.TestContext.DataRow["productOrigin"].ToString() + rNum;
                string origin = this.TestContext.DataRow["origin"].ToString() + rNum;
                string product = this.TestContext.DataRow["product"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string westProgramName = this.TestContext.DataRow["westProgramName"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                String[] caseNumber;

                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                _casesAction.ClickOnOpenCasesTab();
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValues = _crmCommonAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickEditCase();
                _casesAction.ValidateCaseInUpdatePage(firstRowValues);
                caseNumber = _casesAction.EnterPersonalInformation(casesInvolvment, title, productOrigin, origin, priority, description);
                //_casesAction.ClickUpdateButton();
                _casesAction.AddCaseClassification();
                _crmCommonAction.ClickBackButton();
                _homeAction.MenuActions();
                _casesAction.ClickOnOpenCasesTab();
                _homeAction.ClearSearchField();
                //UncommentAfterFixingIssue
                //_homeAction.FilterDataBySearch(subject);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                _casesAction.ValidateCreatedPRQInInboxGrid(caseNumber[0], title, caseNumber[1], "Open", priority);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test Validate Resolve case  functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328056.csv", "CRMCases_328056#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328056.csv")]
        [Ignore]
        public void TC_328058_ValidateResolveCase()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string openCase = "Open Cases";
                string resolvedCase = "Resolved Cases";
                int openCaseCount;
                int resolvedCaseCount;
                int openCaseCountResolve;
                int resolvedCaseCountResolve;
                int rowNum;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                openCaseCount = _casesAction.NumberOfRecordsInLabel(openCase);
                resolvedCaseCount = _casesAction.NumberOfRecordsInLabel(resolvedCase);
                _casesAction.ClickOnTabByName(openCase);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValuesOpenCase = _crmCommonAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickResolveCase();
                _casesAction.ResolveCase();
                _casesAction.ClickOnTabByName(resolvedCase);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                rowNum = _casesAction.RowNumberOfCase(firstRowValuesOpenCase[0]);
                List<String> firstRowValuesResolvedCase = _crmCommonAction.GetFirstRowValuesByRowNumber(rowNum);
                _casesAction.ValidateTwoRowValues(firstRowValuesOpenCase, firstRowValuesResolvedCase, "Resolved");
                openCaseCountResolve = _casesAction.NumberOfRecordsInLabel(openCase);
                resolvedCaseCountResolve = _casesAction.NumberOfRecordsInLabel(resolvedCase);
                _casesAction.ValidateCount(openCaseCount, openCaseCountResolve, -1);
                _casesAction.ValidateCount(resolvedCaseCount, resolvedCaseCountResolve, 1);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test Validate Reopen case functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328056.csv", "CRMCases_328056#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328056.csv")]
        [Ignore]
        public void TC_335069_ValidateReopenCase()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string openCase = "Open Cases";
                string resolvedCase = "Resolved Cases";
                int openCaseCount;
                int resolvedCaseCount;
                int openCaseCountResolve;
                int resolvedCaseCountResolve;
                int rowNum;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                openCaseCount = _casesAction.NumberOfRecordsInLabel(openCase);
                resolvedCaseCount = _casesAction.NumberOfRecordsInLabel(resolvedCase);
                _casesAction.ClickOnTabByName(resolvedCase);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValuesResolveCase = _crmCommonAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                _casesAction.ClickReopenCase();
                _casesAction.ClickOnTabByName(openCase);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                rowNum = _casesAction.RowNumberOfCase(firstRowValuesResolveCase[0]);
                List<String> firstRowValuesOpenCase = _crmCommonAction.GetFirstRowValuesByRowNumber(rowNum);
                _casesAction.ValidateTwoRowValues(firstRowValuesResolveCase, firstRowValuesOpenCase, "Open");
                openCaseCountResolve = _casesAction.NumberOfRecordsInLabel(openCase);
                resolvedCaseCountResolve = _casesAction.NumberOfRecordsInLabel(resolvedCase);
                _casesAction.ValidateCount(openCaseCount, openCaseCountResolve, 1);
                _casesAction.ValidateCount(resolvedCaseCount, resolvedCaseCountResolve, -1);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        //[TestCategory("Regression")]
        //[TestCategory("Cases")]
        //[TestCategory("CRM")]
        [Description("Test validate delete case functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCases_328056.csv", "CRMCases_328056#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCases_328056.csv")]
        [Ignore]
        public void TC_335070_ValidateDeleteCase()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string openCase = "Open Cases";
                string allCase = "All";
                int openCaseCount;
                int allCaseCount;
                int openCaseCountResolve;
                int allCaseCountResolve;
                loginAsUX1(function, inbox);

                _homeAction.MenuActions();
                openCaseCount = _casesAction.NumberOfRecordsInLabel(openCase);
                allCaseCount = _casesAction.NumberOfRecordsInLabel(allCase);
                _casesAction.ClickOnTabByName(openCase);
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValuesOpenCase = _crmCommonAction.GetFirstRowValues();
                _inboxAction.ClickOnDetailActionForFirstRecord();
                //_casesAction.ClickDeleteCase();
                //CommentAfterFix
                _homeAction.ClickOnRefreshButton();
                List<String> firstRowValuesOpenCaseDelete = _crmCommonAction.GetFirstRowValues();
                _casesAction.ValidateCaseNumberNotExist(firstRowValuesOpenCase, firstRowValuesOpenCaseDelete);
                openCaseCountResolve = _casesAction.NumberOfRecordsInLabel(openCase);
                allCaseCountResolve = _casesAction.NumberOfRecordsInLabel(allCase);
                _casesAction.ValidateCount(openCaseCount, openCaseCountResolve, -1);
                _casesAction.ValidateCount(allCaseCount, allCaseCountResolve, -1);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Task Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMTask_327972.csv", "CRMTask_327972#csv", DataAccessMethod.Sequential), DeploymentItem("CRMTask_327972.csv")]
        [Ignore]
        public void TC_327972_CreateTaskFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                _activitiesAction.EnterTask(subject, description, priority, reference, status);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Newly created Task is listed under calendar construct  functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMTask_327972.csv", "CRMTask_327972#csv", DataAccessMethod.Sequential), DeploymentItem("CRMTask_327972.csv")]
        [Ignore]
        public void TC_327979_CreateTaskListedUnderCalenderConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                var addedValues = _activitiesAction.EnterTask(subject, description, priority, reference, status);
                _activitiesAction.ClickCreateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, addedValues[1] + " - " + addedValues[2], "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Task Flow  functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMTask_327986.csv", "CRMTask_327986#csv", DataAccessMethod.Sequential), DeploymentItem("CRMTask_327986.csv")]
        [Ignore]
        public void TC_327986_EditTask()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string priority = this.TestContext.DataRow["priority"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string dueTime = this.TestContext.DataRow["dueTime"].ToString();


                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                int numOfTask = _activitiesAction.NumberOfActivityByName(activity);
                if (numOfTask <= 0)
                {
                    _activitiesAction.SelectActivity(activity);
                    _activitiesAction.EnterTask(subject + "New", description, priority, reference, status);
                    _activitiesAction.ClickCreateButton();
                    _crmCommonAction.ClickBackButton();
                    if (_activitiesAction.CreateActivityButtonCount() == 0)
                    {
                        _inboxAction.ClickOnCreateMasterAction();
                        _activitiesAction.ClickOnCreateCalendarConstruct();
                    }
                    _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                }
                _activitiesAction.ClickActivityByName(activity);
                var addedValues = _activitiesAction.EnterTask(subject, description, priority, reference, status);
                _activitiesAction.EnterStartAndDueTime(startTime, dueTime);
                _activitiesAction.ClickUpdateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, startTime + " - " + dueTime, "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Appointment Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMAppointement_327971.csv", "CRMAppointement_327971#csv", DataAccessMethod.Sequential), DeploymentItem("CRMAppointement_327971.csv")]
        [Ignore]
        public void TC_327971_CreateAppointmentFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + rNum;
                string location = this.TestContext.DataRow["location"].ToString();
                string recurrence = this.TestContext.DataRow["recurrence"].ToString();
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string relatedTo = this.TestContext.DataRow["relatedTo"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                _activitiesAction.EnterAppointement(title, location, recurrence, description, relatedTo, status);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate newly created appointment is listed under calendar construct functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMAppointement_327971.csv", "CRMAppointement_327971#csv", DataAccessMethod.Sequential), DeploymentItem("CRMAppointement_327971.csv")]
        [Ignore]
        public void TC_327980_CreateAppointmentListedUnderCalendarConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + rNum;
                string location = this.TestContext.DataRow["location"].ToString();
                string recurrence = this.TestContext.DataRow["recurrence"].ToString();
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string relatedTo = this.TestContext.DataRow["relatedTo"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                var addedValues = _activitiesAction.EnterAppointement(title, location, recurrence, description, relatedTo, status);
                _activitiesAction.ClickSetupButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, title, addedValues[1] + " - " + addedValues[2], "Subject");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Appointment Flow  functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMAppointement_327971.csv", "CRMAppointement_327971#csv", DataAccessMethod.Sequential), DeploymentItem("CRMAppointement_327971.csv")]
        [Ignore]
        public void TC_327987_EditAppointmentInCalendarConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string title = this.TestContext.DataRow["title"].ToString() + " edit" + rNum;
                string location = this.TestContext.DataRow["location"].ToString();
                string recurrence = this.TestContext.DataRow["recurrence"].ToString();
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string relatedTo = this.TestContext.DataRow["relatedTo"].ToString();
                string status = this.TestContext.DataRow["status"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string endTime = this.TestContext.DataRow["endTime"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                int numOfTask = _activitiesAction.NumberOfActivityByName(activity);
                if (numOfTask <= 0)
                {
                    _activitiesAction.SelectActivity(activity);
                    _activitiesAction.EnterAppointement(title + "New", location, recurrence, description, relatedTo, status);
                    _activitiesAction.ClickSetupButton();
                    _crmCommonAction.ClickBackButton();
                    if (_activitiesAction.CreateActivityButtonCount() == 0)
                    {
                        _inboxAction.ClickOnCreateMasterAction();
                        _activitiesAction.ClickOnCreateCalendarConstruct();
                    }
                    _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                }
                _activitiesAction.ClickActivityByName(activity);
                var addedValues = _activitiesAction.EnterAppointement(title, location, recurrence, description, relatedTo, status);
                _activitiesAction.EnterStartAndEndTime(startTime, endTime);
                _activitiesAction.ClickUpdateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, title, startTime + " - " + endTime, "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Create Phone call Screen functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPhoneCall_327973.csv", "CRMPhoneCall_327973#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPhoneCall_327973.csv")]
        [Ignore]
        public void TC_327973_CreatePhonecallFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string callType = this.TestContext.DataRow["callType"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                _activitiesAction.EnterPhoneCall(reference, callType, phoneCode, phoneNumber, priority, subject, description, status);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate newly created Phone Call is listed under activity inbox functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPhoneCall_327973.csv", "CRMPhoneCall_327973#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPhoneCall_327973.csv")]
        [Ignore]
        public void TC_327981_NewlyCreatedPhoneCallListedunderCalenderConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string callType = this.TestContext.DataRow["callType"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string status = this.TestContext.DataRow["status"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                var addedValues = _activitiesAction.EnterPhoneCall(reference, callType, phoneCode, phoneNumber, priority, subject, description, status);
                _activitiesAction.ClickCreateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, addedValues[1] + " - " + addedValues[2], "Subject");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate Editing Phone Call Flow functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMPhoneCall_327988.csv", "CRMPhoneCall_327988#csv", DataAccessMethod.Sequential), DeploymentItem("CRMPhoneCall_327988.csv")]
        [Ignore]
        public void TC_327988_EditPhoneCall()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string reference = this.TestContext.DataRow["reference"].ToString();
                string callType = this.TestContext.DataRow["callType"].ToString();
                string phoneCode = this.TestContext.DataRow["phoneCode"].ToString();
                string phoneNumber = this.TestContext.DataRow["phoneNumber"].ToString();
                string priority = this.TestContext.DataRow["priority"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string description = this.TestContext.DataRow["description"].ToString() + rNum;
                string status = this.TestContext.DataRow["status"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string endTime = this.TestContext.DataRow["endTime"].ToString();



                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                int numOfTask = _activitiesAction.NumberOfActivityByName(activity);
                if (numOfTask <= 0)
                {
                    _activitiesAction.SelectActivity(activity);
                    _activitiesAction.EnterPhoneCall(reference, callType, phoneCode, phoneNumber, priority, subject + "New", description, status);
                    _activitiesAction.ClickCreateButton();
                    _crmCommonAction.ClickBackButton();
                    if (_activitiesAction.CreateActivityButtonCount() == 0)
                    {
                        _inboxAction.ClickOnCreateMasterAction();
                        _activitiesAction.ClickOnCreateCalendarConstruct();
                    }
                    _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                }
                _activitiesAction.ClickActivityByName(activity);
                var addedValues = _activitiesAction.EnterPhoneCall(reference, callType, phoneCode, phoneNumber, priority, subject, description, status);
                _activitiesAction.EnterStartAndEndTime(startTime, endTime);
                _activitiesAction.ClickUpdateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, startTime + " - " + endTime, "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate create customer visit flow from calendar construct functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCustomerVisit_337372.csv", "CRMCustomerVisit_337372#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCustomerVisit_337372.csv")]
        [Ignore]
        public void TC_337372_CreateCustomerVisitFlow()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string mediumOfVisit = this.TestContext.DataRow["mediumOfVisit"].ToString();
                string appointment = this.TestContext.DataRow["appointment"].ToString();
                string account = this.TestContext.DataRow["account"].ToString();
                string businessDevelopementManager = this.TestContext.DataRow["businessDevelopementManager"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                _activitiesAction.EnterCustomerVisit(subject, mediumOfVisit, appointment, account, businessDevelopementManager);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate create customer visit flow from calendar construct functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCustomerVisit_337372.csv", "CRMCustomerVisit_337372#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCustomerVisit_337372.csv")]
        [Ignore]
        public void TC_337384_CreatedCustomerVisitInCalanderConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + rNum;
                string mediumOfVisit = this.TestContext.DataRow["mediumOfVisit"].ToString();
                string appointment = this.TestContext.DataRow["appointment"].ToString();
                string account = this.TestContext.DataRow["account"].ToString();
                string businessDevelopementManager = this.TestContext.DataRow["businessDevelopementManager"].ToString();

                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.SelectActivity(activity);
                var addedValues = _activitiesAction.EnterCustomerVisit(subject, mediumOfVisit, appointment, account, businessDevelopementManager);
                _activitiesAction.ClickCreateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, addedValues[1] + " - " + addedValues[2], "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Activities")]
        [TestCategory("CRM")]
        [Description("Test Validate editing customer visit flow from calendar construct (TC ) functionality of the application")]
        [Owner("veeresh.menasinakaiExternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CRMCustomerVisit_337372.csv", "CRMCustomerVisit_337372#csv", DataAccessMethod.Sequential), DeploymentItem("CRMCustomerVisit_337372.csv")]
        [Ignore]
        public void TC_337376_EditCustomerVisitInCalenderConstruct()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string randomNum = this.TestContext.DataRow["randomNumber"].ToString();
                string rNum = string.Empty;
                if (randomNum.Equals("Yes"))
                {
                    rNum = " " + _helper.GenerateUniqueRandomNumber();
                }
                int daysPastOrFuture = Int32.Parse(this.TestContext.DataRow["daysPastOrFuture"].ToString());
                string activity = this.TestContext.DataRow["activity"].ToString();
                string subject = this.TestContext.DataRow["subject"].ToString() + " edit " + rNum;
                string mediumOfVisit = this.TestContext.DataRow["mediumOfVisit"].ToString();
                string appointment = this.TestContext.DataRow["appointment"].ToString();
                string account = this.TestContext.DataRow["account"].ToString();
                string businessDevelopementManager = this.TestContext.DataRow["businessDevelopementManager"].ToString();
                string startTime = this.TestContext.DataRow["startTime"].ToString();
                string endTime = this.TestContext.DataRow["endTime"].ToString();


                loginAsUX1(function, inbox);
                _homeAction.MenuActions();
                _inboxAction.ClickOnCreateMasterAction();
                _activitiesAction.ClickOnCreateCalendarConstruct();
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                int numOfTask = _activitiesAction.NumberOfActivityByName(activity);
                if (numOfTask <= 0)
                {
                    _activitiesAction.SelectActivity(activity);
                    _activitiesAction.EnterCustomerVisit(subject + "New", mediumOfVisit, appointment, account, businessDevelopementManager);
                    _activitiesAction.ClickCreateButton();
                    _crmCommonAction.ClickBackButton();
                    if (_activitiesAction.CreateActivityButtonCount() == 0)
                    {
                        _inboxAction.ClickOnCreateMasterAction();
                        _activitiesAction.ClickOnCreateCalendarConstruct();
                    }
                    _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                }
                _activitiesAction.ClickActivityByName(activity);
                var addedValues = _activitiesAction.EnterCustomerVisit(subject, mediumOfVisit, appointment, account, businessDevelopementManager);
                _activitiesAction.EnterStartAndEndTime(startTime, endTime);
                _activitiesAction.ClickUpdateButton();
                _crmCommonAction.ClickBackButton();
                if (_activitiesAction.CreateActivityButtonCount() == 0)
                {
                    _inboxAction.ClickOnCreateMasterAction();
                    _activitiesAction.ClickOnCreateCalendarConstruct();
                }
                _activitiesAction.SelectFutureOrPastDateFromToday(daysPastOrFuture);
                _activitiesAction.ValidateCreatedTaskInCalendar(activity, subject, startTime + " - " + endTime, "Subject");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        // ********* CRM test Generic Methods ******************//

        public Boolean loginAsUX1(string function, string inbox)
        {

            Boolean dataPresent = false;

            string passwordUX1Encrypted = TestContext.Properties["TestUX1Password"].ToString();
            string sdLoginID = "Test_UX1@westpharma.com";
            string passwordUX1 = CommonTestSettings.Decrypt(passwordUX1Encrypted);
            Boolean LoggedInUserName;

            _baseAction.WaitForLoadingToDisappear();
            _homeAction.ClickOnProfileImage();
            WaitForMoment(3);
            LoggedInUserName = _homeAction.LoggedinUser("TEST UX1");
            _homeAction.ClickOnHomeActionsButton();
            WaitForMoment(2);
            if (!LoggedInUserName)
            {
                LogoutWD();
                LaunchApp();
                LoginToWD(sdLoginID, passwordUX1);
            }
            NavigateToInboxByGlobalSearch(function, inbox, false);
            if (_inboxAction.CheckActionForFirstRecord())
            {
                LogInfo("Prospects are displayed ");
                dataPresent = true;
            }
            else if (_inboxAction.CheckDataNotAvailable())
            {
                LogInfo("Data does not exist for this user");
                dataPresent = false;
            }
            else
            {
                LogInfo("Problem in the page");
                Assert.Fail();
            }
            return dataPresent;
        }

        #endregion


    }

}
