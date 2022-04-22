using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CampaignResponceAction :BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CampaignResponcePage _pageInstance;

        public CampaignResponceAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CampaignResponcePage(_session);
        }

        public void ClickOnCreateCampaignResponce()
        {
            ClickElement(_pageInstance.CreateCampaignResponce);
            LogInfo("Clicked on create campaign responce");
            WaitForLoadingToDisappear();
        }

        public void EnterSubject(String subject)
        {
            ClickClearEnterText(_pageInstance.Subject, subject);
            LogInfo("Entered subject");
        }

        public void EnterDescription(String description)
        {
            ClickClearEnterText(_pageInstance.Description, description);
            LogInfo("Entered description");
        }
        public void SelectRelatedCampaign(String campaign)
        {
            ClickElement(_pageInstance.RelatedCampaign);
            WaitForMoment(.25);
            EnterText(_pageInstance.RelatedCampaign, Keys.Down);           
            WaitForMoment(.25);
            EnterText(_pageInstance.RelatedCampaign, Keys.Return);
            WaitForMoment(.25);
            LogInfo("Selected related campaign");
        }

        public void SelectResponceType(String responceType)
        {
            EnterText(_pageInstance.ResponceType, responceType);
            LogInfo("Selected responce type ");
        }

        public void SelectChannel(String channel)
        {
            EnterText(_pageInstance.Channel, channel);
            LogInfo("Selected responce type ");
        }

        public void SelectPriority(String priority)
        {
            ClickElement(_pageInstance.Priority(priority));
            LogInfo("Selected responce type ");
        }

        public void EnterPromoCode(String promoCode)
        {
            ClickClearEnterText(_pageInstance.PromoCode, promoCode);
            LogInfo("Entered PromoCode");
        }

        public void EnterOutsourcedVendor(String outsourcedVendor)
        {
            ClickClearEnterText(_pageInstance.OutsourcedVendor, outsourcedVendor);
            LogInfo("Entered OutsourcedVendor");
        }
        public void SelectReceivedFrom(String receivedFrom)
        {
            ClickElement(_pageInstance.ReceivedFrom(receivedFrom));
            LogInfo("Selected receivedFrom ");
        }

        public string SelectProspect()
        {
            String selectedValue = string.Empty;
            //EnterText(_pageInstance.Link, link);
            ClickElement(_pageInstance.ProspectDropdown);
            WaitForMoment(.25);
            EnterText(_pageInstance.ProspectDropdown, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.ProspectDropdown, Keys.Down);
            WaitForMoment(.25);
            EnterText(_pageInstance.ProspectDropdown, Keys.Return);
            WaitForMoment(.25);
            selectedValue = GetAttribute(_pageInstance.ProspectDropdown, "Value.Value");
            LogInfo("Selected Prospect");
            return selectedValue;

        }

        public void EnterPhone(String phone)
        {
            ClickClearEnterText(_pageInstance.Phone, phone);
            LogInfo("Entered phone");
        }

        public void ClickReceiverInformationTab()
        {
            ClickElement(_pageInstance.receiverInformation);
            ClickElement(_pageInstance.receiverInformation);
            LogInfo("Clicked on receiver information tab");
            WaitForLoadingToDisappear();
        }

        public void ClickCampaignInformationTab()
        {
            ClickElement(_pageInstance.campaignInformation);
            ClickElement(_pageInstance.campaignInformation);
            LogInfo("Clicked on campaign information tab");
            WaitForLoadingToDisappear();
        }
        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on create button");
            WaitForLoadingToDisappear();
        }


       
        /// <summary>
        /// Enter Campaign Responce
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="releatedCampaign"></param>
        /// <param name="responceType"></param>
        /// <param name="channel"></param>
        /// <param name="priority"></param>
        /// <param name="promoCode"></param>
        /// <param name="outsourcedVendor"></param>
        /// <param name="receivedFrom"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string EnterCampaignResponce(String subject = "Subject", String description = "Description", string releatedCampaign = "BrightVerify 2018",
            string responceType = "Intrested", string channel = "Phone",String priority="Low",string promoCode="12345",
            string outsourcedVendor = "Outsourced Vendor",string receivedFrom ="Prospect", String phone="9060666615")
        {
            
            EnterSubject(subject);
            EnterDescription(description);
            SelectRelatedCampaign(releatedCampaign);
            SelectResponceType(responceType);
            SelectChannel(channel);
            SelectPriority(priority);
            EnterPromoCode(promoCode);
            EnterOutsourcedVendor(outsourcedVendor);
            ClickReceiverInformationTab();
            SelectReceivedFrom(receivedFrom);
            String selectedLink= SelectProspect();
            EnterPhone(phone);
            return selectedLink;
        }

        public void ClickOnCampaignResponceTab()
        {
            ClickElement(_pageInstance.CampaignResponceTab);
            LogInfo("Clicked on create Create Campaign Responce Tab");
            WaitForLoadingToDisappear();
        }

        public void ClickOnEditCampaignResponce()
        {
            ClickElement(_pageInstance.EditCampaignResponce);
            LogInfo("Clicked on edit campaign response");
            WaitForLoadingToDisappear();
        }

        public void ValidateCampaignResponseInUpdatePage(List<String> input)
        {
            Assert.AreEqual(input[0], GetAttribute(_pageInstance.Subject, "Value.Value"));
            ClickReceiverInformationTab();
            ClickReceiverInformationTab();
            Assert.AreEqual(input[4], GetAttribute(_pageInstance.ProspectDropdown, "Value.Value"));
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateWebFormButton);
            LogInfo("Clicked on update web form button");
            WaitForLoadingToDisappear();
        }

    }
}

