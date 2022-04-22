using OpenQA.Selenium.Appium.Windows;
using System;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using System.Collections.Generic;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class WebformKmApprovalAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly WebformKmApprovalPage _pageInstance;
        public WebformKmApprovalAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new WebformKmApprovalPage(_session);
        }
        public void ClickOnWebFormKmApproval()
        {
            ClickElement(_pageInstance.CreateWebFormKmApproval);
            LogInfo("Clicked on create web form km Approval");
            WaitForLoadingToDisappear();
        }
        public void EnterSubject(string subject)
        {
            ClickClearEnterText(_pageInstance.Subject, subject);
            LogInfo("Entered subject");
        }
        public void SelectReference(string reference)
        {
            EnterText(_pageInstance.Reference, reference);
            LogInfo("Selected reference");
        }
        public string SelectLink()
        {
            String selectedValue = string.Empty;
            ClearElement(_pageInstance.Link);
            ClickElement(_pageInstance.Link);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.Link, Keys.Return);
            WaitForMoment(.25);
            selectedValue = GetAttribute(_pageInstance.Link, "Value.Value");
            LogInfo("Selected link");
            return selectedValue;

        }
        public void ApprovalStatus(String approvalStatus)
        {
            ClickClearEnterText(_pageInstance.ApprovalStatus, approvalStatus);
            LogInfo("Entered ApprovalStatus");
        }
        public void ApprovalEmail(String approvalEmail)
        {
            ClickClearEnterText(_pageInstance.ApprovalEmail, approvalEmail);
            LogInfo("Entered ApprovalEmail");
        }
        public void Comments(String comments)
        {
            ClickClearEnterText(_pageInstance.Comments, comments);
            LogInfo("Entered Comments");
        }
        public void ClickKMCreateButton()
        {
            ClickElement(_pageInstance.CreateWebFormKmButton);
            LogInfo("Clicked on create web form km approval button");
            WaitForLoadingToDisappear();
        }
        /// <summary>
        /// To KM Approval Create
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="reference"></param>
        /// <param name="approvalStatus"></param>
        /// <param name="approvalEmail"></param>
        /// <param name="comments"></param>
        public string EnterWebFormKmApproval(String subject = "Subject", string reference = "Prospect", string approvalStatus = "Approved",
            string approvalEmail = "test_ux1@email.com", string comments = "Test Km approval")
        {
            EnterSubject(subject);
            SelectReference(reference);
            String selectedLink = SelectLink();
            ApprovalStatus(approvalStatus);
            ApprovalEmail(approvalEmail);
            Comments(comments);
            return selectedLink;
        }

        public void ClickOnKMApprovalTab()
        {
            ClickElement(_pageInstance.KMApprovalTab);
            LogInfo("Clicked on KM approval Tab");
            WaitForLoadingToDisappear();
        }

        public void ClickOnEditKMApproval()
        {
            ClickElement(_pageInstance.EditKMApproval);
            LogInfo("Clicked on edit KM Approval");
            WaitForLoadingToDisappear();
        }

        public void ValidateContactUsInUpdatePage(List<String> firstRowValue)
        {
            Assert.AreEqual(firstRowValue[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            Assert.AreEqual(firstRowValue[4], GetAttribute(_pageInstance.Link, "Value.Value"));
        }
    }
}