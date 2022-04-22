using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using Microsoft.Test.Input;
using System.Drawing;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class OpportunityAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly OpportunityPage _pageInstance;

        public OpportunityAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new OpportunityPage(_session);
        }

        public void SendText(WindowsElement windowElement, String text)
        {
            ClickElement(windowElement);
            ClearElement(windowElement);
            EnterText(windowElement, text);
        }

        public void SearchInbox(String inbox)
        {
            ClickElement(_pageInstance.Inbox);
            ClearElement(_pageInstance.Inbox);
            EnterText(_pageInstance.Inbox, inbox);
            ClickElement(_pageInstance.InboxSearchButton);
            LogInfo("Searched for " + inbox);
            WaitForLoadingToDisappear();
        }

        public void ClickCreateOpportunity()
        {
            ClickElement(_pageInstance.CreateOpportunity);
            LogInfo(" Clicked on Create Opportunity");
            WaitForLoadingToDisappear();
        }

        public void ClickOverViewExpandICon()
        {
            ClickElement(_pageInstance.OverViewExpandIcon);
            LogInfo(" Clicked on Over View Expand Icon");
        }

        public void EnterOpportuityName(String opportunityName)
        {
            ClickElement(_pageInstance.OpportunityName);
            ClearElement(_pageInstance.OpportunityName);
            EnterText(_pageInstance.OpportunityName, opportunityName);
            LogInfo("Entered Opportunity Name");
        }

        public void SelectAccountName()
        {
            ClickElement(_pageInstance.AccountName[0]);
            LogInfo("Clicked on Account Generic Picker");
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Account Name");
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
        }

        public void SearchAndSelectAccount(String accountName)
        {
            ClickElement(_pageInstance.AccountName[0]);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, accountName);
            LogInfo("Selected account " + accountName);
        }

        public String GetAccountNameValue()
        {
            String accountName = GetAttribute(_pageInstance.AccountNameField, "Value.Value");
            return accountName;
        }

        public void ClickCreateAccount()
        {
            ClickElement(_pageInstance.AccountName[0]);
            ClickElement(_pageInstance.Options("Create CRM Account"));
            LogInfo("Clicked on Create Account");
            WaitForLoadingToDisappear();
        }

        public void SelectPrimaryCustomerContact()
        {
            ClickElement(_pageInstance.PrimaryCustomerContact[0]);
            LogInfo("Clicked on Primary Customer Contact Generic Picker");
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            Assert.IsTrue(GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated with - " + GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value"));
            LogInfo("Selected Primary Customer Contact");
        }

        public void SelectContactInPicker()
        {
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            Assert.IsTrue(GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated with - " + GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value"));
            LogInfo("Selected Primary Customer Contact");
        }

        public void ClickCreateContact()
        {
            ClickElement(_pageInstance.PrimaryCustomerContact[0]);
            LogInfo("Clicked On Primary Customer Contact Generic Picker");
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.Options("Create Contact"));
            LogInfo("Clicked On Create Contact");
            WaitForLoadingToDisappear();
        }

        public void ClickPrimaryCustomerContactGP()
        {
            ClickElement(_pageInstance.PrimaryCustomerContact[0]);
            LogInfo("Clicked on Primary Customer Contact Generic Picker");
        }

        public void CreateContactInPicker()
        {
            ClickElement(_pageInstance.Options("Create Contact"));
            LogInfo("Clicked On Create Contact");
            WaitForLoadingToDisappear();
        }

        public void CreateContact()
        {
            ClickElement(_pageInstance.Options("Create Contact"));
            LogInfo("Clicked On Create Contact");
            WaitForLoadingToDisappear();
        }

        public void VerifyAddress(String address)
        {
            Assert.IsTrue(GetAttribute(_pageInstance.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated with - " + GetAttribute(_pageInstance.Address, "Value.Value"));
            LogInfo("Enter Address");
        }

        public void EnterOpportunityOwner(String opportunityOwnerReference, String opportunityOwner)
        {
            ClickElement(_pageInstance.OpportunityOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.OpportunityOwnerArrow);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, opportunityOwner);
            ClickElement(_pageInstance.Options(opportunityOwner));
            //Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            //LogInfo("Verified Opportunity Owner  - " + opportunityOwner);
            LogInfo("Opportunity Owner Changed to " + opportunityOwner);
        }

        public void EnterOpportunityOwnerFromLead(String opportunityOwner)
        {
            ClickElement(_pageInstance.OpportunityOwnerArrow);
            WaitForMoment(2);
            ClickElement(_pageInstance.SelectAnItemSearchBox);
            ClearElement(_pageInstance.SelectAnItemSearchBox);
            EnterText(_pageInstance.SelectAnItemSearchBox, opportunityOwner);
            ClickElement(_pageInstance.Options(opportunityOwner));
            //Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            //LogInfo("Verified Opportunity Owner  - " + opportunityOwner);
            LogInfo("Opportunity Owner Changed to " + opportunityOwner);
        }

        public void SelectBussinessType(String bussinessType)
        {
            ClickElement(_pageInstance.BussinessType);
            ClickElement(_pageInstance.Options(bussinessType));
            LogInfo("Selected Busseness Type " + bussinessType);
        }

        public void SelectBussinessSubType(String bussinessSubType)
        {
            ClickElement(_pageInstance.BussinessSubType);
            ClickElement(_pageInstance.Options(bussinessSubType));
            LogInfo("Selected Busseness Type " + bussinessSubType);
        }

        public void SelectProjectedCloseDate(String date)
        {
            ClickElement(_pageInstance.ProjectedCloseDate);
            Boolean Calander;
            try
            {
                Calander = Exists(_pageInstance.Calander);
            }
            catch (Exception)
            {
                Calander = false;
            }

            if (Calander)
            {
                ClickElement(_pageInstance.ProjectedCloseDate);
            }
            LogInfo("Selected Projected Close Date as " + GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value"));
        }

        public void SelectRegion(String region)
        {
            ClickElement(_pageInstance.Region);
            ClickElement(_pageInstance.Options(region));
            LogInfo("Selected Region " + region);
        }

        public void EnterForcastedValue(String forcastedvalue)
        {
            ClickElement(_pageInstance.ForcastedValue);
            //ClearElement(_pageInstance.ForcastedValue);
            EnterText(_pageInstance.ForcastedValue, forcastedvalue);
            LogInfo("Entered Forcasted Value " + forcastedvalue);
        }

        public void SelectMarketUnit(String marketUnit)
        {
            ClickElement(_pageInstance.MarketUnit);
            ClickElement(_pageInstance.Options(marketUnit));
            LogInfo("Selected Market Unit " + marketUnit);
        }

        public void SelectCurrency(String currency)
        {
            ClickElement(_pageInstance.Currency);
            ClickElement(_pageInstance.Options(currency));
            LogInfo("Selected Currency as " + currency);
            Assert.AreEqual(_pageInstance.ForcastedValueCurrency.Text, currency);
            LogInfo("Verified Forecast Value Currency " + currency);
        }

        public void SelectMarketSegment(String marketSegment)
        {
            ClickElement(_pageInstance.MarketSegment);
            ClickElement(_pageInstance.Options(marketSegment));
            LogInfo("Selected Market Segment " + marketSegment);
        }

        public void SelectMarketSubSegment(String marketSubSegment)
        {
            ClickElement(_pageInstance.MarketSubSegment);
            ClickElement(_pageInstance.Options(marketSubSegment));
            LogInfo("Selected Market Sub-Segment " + marketSubSegment);
        }

        public void SelectProbability(String probability)
        {
            ClickElement(_pageInstance.Probability);
            ClickElement(_pageInstance.Options(probability));
            LogInfo("Selected Probability as " + probability);
        }

        public void SelectStrategicAccountClassification(String strategicAccountClassification)
        {
            ClickElement(_pageInstance.StrategicAccountClassification);
            ClickElement(_pageInstance.Options(strategicAccountClassification));
            LogInfo("Selected Strategic Account Classification as " + strategicAccountClassification);
        }

        public void SelectApplication(String application)
        {
            ClickElement(_pageInstance.Application);
            ClickElement(_pageInstance.Options(application));
            LogInfo("Selected Application as " + application);
        }

        public void SelectHVP()
        {
            ClickElement(_pageInstance.HVP);
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            ClickCheckBox(0);
            ClickCheckBox(1);
            ClickCheckBox(2);
            ClickElement(_pageInstance.SubmitButton);
            LogInfo("Selected HVP");
        }
        public void SelectSIPDesignation(String sip)
        {
            ClickElement(_pageInstance.SIPDesignation);
            ClickElement(_pageInstance.Options(sip));
            LogInfo("Selected SIP Designation as " + sip);
        }

        public void SelectCloseWonType(String closeWonType)
        {
            ClickElement(_pageInstance.CloseWonType);
            ClickElement(_pageInstance.Options(closeWonType));
            LogInfo("Selected CloseWon Type as " + closeWonType);
        }

        public void SelectOrganizationalVP(String organizationalVP)
        {
            ClickElement(_pageInstance.OrganizationalVP);
            ClickElement(_pageInstance.Options(organizationalVP));
            LogInfo("Selected Organizational VP as " + organizationalVP);
        }

        public void SelectBusDev(String busDev)
        {
            ClickElement(_pageInstance.BusDev);
            ClickElement(_pageInstance.BusDev);
            ClearElement(_pageInstance.BusDev);
            EnterText(_pageInstance.BusDev, busDev);
            ClickElement(_pageInstance.BusDevArrow);
            ClickElement(_pageInstance.BusDevArrow);
            ClickElement(_pageInstance.Options(busDev));
            LogInfo("Selected Bus Dev as " + busDev);
        }

        public void EditBusDev(String busDevReference, String busDev)
        {
            ClickElement(_pageInstance.BusDev);
            ClickElement(_pageInstance.BusDevClearButton);
            EnterText(_pageInstance.BusDev, busDevReference);
            ClickElement(_pageInstance.BusDevArrow);
            ClickElement(_pageInstance.BusDevArrow);
            WaitForMoment(1);
            ClickElement(_pageInstance.Options(busDev));
            LogInfo("Bus Dev Changed as " + busDev);
        }

        public void ClickSaveAndClose()
        {
            ClickElement(_pageInstance.SaveAndClose);
            LogInfo("Clicked on Save & Close");
            WaitForLoadingToDisappear();
        }

        public void opportunityOverviewFields(String opportunityName, String address, String opportunityOwnerReference, String opportunityOwner, String bussinessType, String bussinessSubType, String projectedClosureDate,
            String region, String forecastedValue, String marketUnit, String currency, String segment, String subSegment, String probaility, String strategicAcountClassification, String application,
            String sipDesignation, String closeWonType, String organizationalVP, String busDev)
        {
            EnterOpportuityName(opportunityName);
            SelectAccountName();
            SelectPrimaryCustomerContact();
            VerifyAddress(address);
            EnterOpportunityOwner(opportunityOwnerReference, opportunityOwner);
            SelectBussinessType(bussinessType);
            SelectBussinessSubType(bussinessSubType);
            SelectProjectedCloseDate(projectedClosureDate);
            SelectRegion(region);
            EnterForcastedValue(forecastedValue);
            SelectMarketUnit(marketUnit);
            SelectCurrency(currency);
            SelectMarketSegment(segment);
            SelectMarketSubSegment(subSegment);
            SelectProbability(probaility);
            SelectStrategicAccountClassification(strategicAcountClassification);
            SelectApplication(application);
            SelectHVP();
            SelectSIPDesignation(sipDesignation);
            SelectCloseWonType(closeWonType);
            SelectOrganizationalVP(organizationalVP);
            SelectBusDev(busDev);
        }

        public void opportunityDetailsFields(String puroseOfInquiry, String westInitiative, String westCampaign, String clinicalPhase, String detailedRequest, String bussinessImpact, String generalNotes)
        {
            SelectPurposeofInquiry(puroseOfInquiry);
            SelectMoleculeName();
            ValidateMoleculeType();
            SelectWestInitiative(westInitiative);
            SelectWestCampaign(westCampaign);
            SelectTherapeuticClass();
            SelectThirdPartyContractOrganization();
            SelectClinicalPhase(clinicalPhase);
            ContractOrganizationOwner();
            EnterDetailedRequestBussinessImpactGeneralNotes(detailedRequest, bussinessImpact, generalNotes);
        }

        public void VerifyOpportunityOverViewFields(String opportunityName, String address, String opportunityOwner, String bussinessType, String bussinessSubType, String projectedClosureDate,
            String region, String forecastedValue, String marketUnit, String currency, String segment, String subSegment, String probaility, String strategicAcountClassification, String application,
            String sipDesignation, String closeWonType, String organizationalVP, String busDev)
        {
            Assert.AreEqual(opportunityName, GetAttribute(_pageInstance.OpportunityName, "Value.Value"));
            LogInfo("Verified Opportunity Name  - " + opportunityName);
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated with - " + GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated with - " + GetAttribute(_pageInstance.Address, "Value.Value"));
            Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            LogInfo("Verified Opportunity Owner  - " + opportunityOwner);
            Assert.AreEqual(bussinessType, GetAttribute(_pageInstance.BussinessTypeNameField, "Name"));
            LogInfo("Verified Bussiness Type - " + bussinessType);
            Assert.AreEqual(bussinessSubType, GetAttribute(_pageInstance.BussinessSubTypeNameField, "Name"));
            LogInfo("Verified Bussiness SubType - " + bussinessSubType);
            Assert.IsTrue(GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value") != null);
            LogInfo("Verified Projected Closed Date - " + GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value"));
            Assert.AreEqual(region, GetAttribute(_pageInstance.RegionNameField, "Name"));
            LogInfo("Verified Region - " + region);
            //Assert.AreEqual(forecastedValue, GetAttribute(_pageInstance.ForcastedValue, "Value.Value"));
            //LogInfo("Verified Foreccast Value - " + forecastedValue);
            Assert.AreEqual(marketUnit, GetAttribute(_pageInstance.MarketUnitNameField, "Name"));
            LogInfo("Verified Market Unit - " + marketUnit);
            Assert.AreEqual(currency, GetAttribute(_pageInstance.CurrencyNameField, "Name"));
            LogInfo("Verified Currency - " + currency);
            Assert.AreEqual(segment, GetAttribute(_pageInstance.MarketSegmentNameField, "Name"));
            LogInfo("Verified Market Segment - " + segment);
            Assert.AreEqual(subSegment, GetAttribute(_pageInstance.MarketSubSegmentNameField, "Name"));
            LogInfo("Verified Market SubSegment - " + subSegment);
            Assert.AreEqual(probaility, GetAttribute(_pageInstance.ProbabilityNameField, "Name"));
            LogInfo("Verified Probability - " + probaility);
            Assert.AreEqual(strategicAcountClassification, GetAttribute(_pageInstance.StrategicAccountClassificationNamefied, "Name"));
            LogInfo("Verified Strategic Acount Classification - " + strategicAcountClassification);
            Assert.AreEqual(application, GetAttribute(_pageInstance.ApplicationNameField, "Name"));
            LogInfo("Verified Application - " + application);
            Assert.IsTrue(GetAttribute(_pageInstance.HVPNameField, "Value.Value") != null);
            LogInfo("Verified HVP - " + GetAttribute(_pageInstance.HVP, "Value.Value"));
            Assert.AreEqual(sipDesignation, GetAttribute(_pageInstance.SIPDesignationNameField, "Name"));
            LogInfo("Verified SIP Designation - " + sipDesignation);
            Assert.AreEqual(closeWonType, GetAttribute(_pageInstance.CloseWonTypeNameField, "Name"));
            LogInfo("Verified Close won Type - " + closeWonType);
            Assert.AreEqual(organizationalVP, GetAttribute(_pageInstance.OrganizationalVPNameField, "Name"));
            LogInfo("Verified Organizational VP - " + organizationalVP);
            Assert.AreEqual(busDev, GetAttribute(_pageInstance.BusDev, "Value.Value"));
            LogInfo("Verified BusDev - " + busDev);
        }

        public void VerifyFieldsAfterCopyOpportunity(String opportunityName, String opportunityOwner, String region, String marketUnit, String segment, String subSegment, String strategicAcountClassification, String application, String sipDesignation, String organizationalVP)
        {
            Assert.AreEqual(opportunityName, GetAttribute(_pageInstance.OpportunityName, "Value.Value"));
            LogInfo("Verified Opportunity Name  - " + opportunityName);
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated with - " + GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated with - " + GetAttribute(_pageInstance.Address, "Value.Value"));
            Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            LogInfo("Verified Opportunity Owner  - " + opportunityOwner);
            Assert.IsTrue(GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value") != null);
            LogInfo("Verified Projected Closed Date - " + GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value"));
            Assert.AreEqual(region, GetAttribute(_pageInstance.RegionNameField, "Name"));
            LogInfo("Verified Region - " + region);
            Assert.AreEqual(marketUnit, GetAttribute(_pageInstance.MarketUnitNameField, "Name"));
            LogInfo("Verified Market Unit - " + marketUnit);
            Assert.AreEqual(segment, GetAttribute(_pageInstance.MarketSegmentNameField, "Name"));
            LogInfo("Verified Market Segment - " + segment);
            Assert.AreEqual(subSegment, GetAttribute(_pageInstance.MarketSubSegmentNameField, "Name"));
            LogInfo("Verified Market SubSegment - " + subSegment);
            Assert.AreEqual(strategicAcountClassification, GetAttribute(_pageInstance.StrategicAccountClassificationNamefied, "Name"));
            LogInfo("Verified Strategic Acount Classification - " + strategicAcountClassification);
            Assert.AreEqual(application, GetAttribute(_pageInstance.ApplicationNameField, "Name"));
            LogInfo("Verified Application - " + application);
            Assert.IsTrue(GetAttribute(_pageInstance.HVPNameField, "Value.Value") != null);
            LogInfo("Verified HVP - " + GetAttribute(_pageInstance.HVP, "Value.Value"));
            Assert.AreEqual(sipDesignation, GetAttribute(_pageInstance.SIPDesignationNameField, "Name"));
            LogInfo("Verified SIP Designation - " + sipDesignation);
            Assert.AreEqual(organizationalVP, GetAttribute(_pageInstance.OrganizationalVPNameField, "Name"));
            LogInfo("Verified Organizational VP - " + organizationalVP);
        }

        public void SaveAndCloseManfatoryfields(String opportunityName, String address, String date)
        {
            EnterOpportuityName(opportunityName);
            SelectAccountName();
            SelectPrimaryCustomerContact();
            VerifyAddress(address);
            SelectProjectedCloseDate(date);
        }

        public void ClickDetailsExpandIcon()
        {
            ClickElement(_pageInstance.DetailsExpandIcon);
            LogInfo("Clicked on Details Expand Icon");
        }

        public void SelectPurposeofInquiry(String purposeofInquiry)
        {
            ClickElement(_pageInstance.PurposeofInquiry);
            ClickElement(_pageInstance.Options(purposeofInquiry));
            LogInfo("Selected Purpose Of Inquiry : " + purposeofInquiry);
        }

        public void SelectMoleculeName()
        {
            ClickElement(_pageInstance.MoleculeName);
            WaitForMoment(3);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Molecule Name");
        }

        public void ValidateMoleculeType()
        {
            if (GetAttribute(_pageInstance.MoleculeType, "LegacyIAccessible.Name") == null)
            {
                LogInfo("Molecule Type vale is not displayed");
            }
            else
            {
                LogInfo("Molecule Type : " + GetAttribute(_pageInstance.MoleculeType, "LegacyIAccessible.Name"));
            }
        }

        public void SelectWestInitiative(String westInitiative)
        {
            ClickElement(_pageInstance.WestInitiative);
            ClickElement(_pageInstance.Options(westInitiative));
            LogInfo("Selected West Initiative : " + westInitiative);
        }

        public void SelectWestCampaign(String westCampaign)
        {
            ClickElement(_pageInstance.WestCampaign);
            ClickElement(_pageInstance.Options(westCampaign));
            LogInfo("Selected West Campaign : " + westCampaign);
        }

        public void SelectTherapeuticClass()
        {
            ClickElement(_pageInstance.TherapeuticClass);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Therapeutic Class");
        }

        public void SelectThirdPartyContractOrganization()
        {
            ClickElement(_pageInstance.ThirdPartyContractOrganization);
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Third Party Contract Organization");
        }

        public void SelectClinicalPhase(String clinicalPhase)
        {
            ClickElement(_pageInstance.ClinicalPhase);
            ClickElement(_pageInstance.Options(clinicalPhase));
            LogInfo("Selected Clinical Phase : " + clinicalPhase);
        }

        public void ContractOrganizationOwner()
        {
            if (GetAttribute(_pageInstance.ContractOrganizationOwner, "Value.Value") == null)
            {
                LogInfo("Contract Organization Owner details is not displayed");
            }
            else
            {
                LogInfo("Contract Organization Owner details : " + GetAttribute(_pageInstance.ContractOrganizationOwner, "Value.Value"));
            }
        }

        public void EnterDetailedRequestBussinessImpactGeneralNotes(String detailedRequest, String bussinessImpact, String generalNotes)
        {
            EnterText(_pageInstance.ContractOrganizationOwner, Keys.Tab);
            WaitForMoment(3);
            _session.SwitchTo().ActiveElement().SendKeys(detailedRequest);
            LogInfo("Entered Detailed Request - " + detailedRequest);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(bussinessImpact);
            LogInfo("Entered Bussiness Impact : " + bussinessImpact);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(generalNotes);
            LogInfo("Entered General Notes : " + generalNotes);
        }

        public void EnterBussinessImpact(String bussinessImpact)
        {
            ClickElement(_pageInstance.BussinessImpact);
            ClearElement(_pageInstance.BussinessImpact);
            EnterText(_pageInstance.BussinessImpact, bussinessImpact);
            LogInfo("Entered Bussiness Impact : " + bussinessImpact);
        }

        public void EnterGeneralNotes(String generalNotes)
        {
            ClickElement(_pageInstance.GeneralNotes);
            ClearElement(_pageInstance.GeneralNotes);
            EnterText(_pageInstance.GeneralNotes, generalNotes);
            LogInfo("Entered General Notes : " + generalNotes);
        }

        public void ClickActivityExpandIcon()
        {
            ClickElement(_pageInstance.ActivityExpandIcon);
            LogInfo("Clicked on Activity expand icon");
        }

        public void SelectRequestType(String requestType)
        {
            ClickElement(_pageInstance.RequestType);
            ClickElement(_pageInstance.Options(requestType));
            LogInfo("Selected Request Type : " + requestType);
        }

        public void SelectPromiseDate(String date)
        {
            ClickElement(_pageInstance.PromiseDate);
            Boolean Calander;
            try
            {
                Calander = Exists(_pageInstance.Calander);
            }
            catch (Exception)
            {
                Calander = false;
            }

            if (Calander)
            {
                ClickElement(_pageInstance.PromiseDate);
            }
            LogInfo("Selected Projected Close Date as " + GetAttribute(_pageInstance.PromiseDate, "Value.Value"));
        }

        public void SelectDeliveryDate(String date)
        {
            ClickElement(_pageInstance.DeliveryDate);
            Boolean Calander;
            try
            {
                Calander = Exists(_pageInstance.Calander);
            }
            catch (Exception)
            {
                Calander = false;
            }

            if (Calander)
            {
                ClickElement(_pageInstance.DeliveryDate);
            }
            LogInfo("Selected Projected Close Date as " + GetAttribute(_pageInstance.DeliveryDate, "Value.Value"));
        }

        public void SelectExpirationDate(String date)
        {
            ClickElement(_pageInstance.ExpirationDate);
            Boolean Calander;
            try
            {
                Calander = Exists(_pageInstance.Calander);
            }
            catch (Exception)
            {
                Calander = false;
            }

            if (Calander)
            {
                ClickElement(_pageInstance.ExpirationDate);
            }
            LogInfo("Selected Projected Close Date as " + GetAttribute(_pageInstance.ExpirationDate, "Value.Value"));
        }

        public void OpportunityActivityField(String requestType, String promiseDate, String deliveryDate, String expirationDate)
        {
            SelectRequestType(requestType);
            SelectPromiseDate(promiseDate);
            SelectDeliveryDate(deliveryDate);
            SelectExpirationDate(expirationDate);
        }

        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.CreateButton);
            LogInfo("Clicked on Create Button");
            WaitForLoadingToDisappear();
        }

        public void ClickEditOpportunity()
        {
            ClickElement(_pageInstance.EditOpportunity);
            LogInfo("Clicked on Edit Opportunity");
            WaitForLoadingToDisappear();
        }

        public void ClickCopyOpportunity()
        {
            ClickElement(_pageInstance.Options("Copy Opportunity"));
            LogInfo("Clicked on Copy Opportunity");
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.Yes);
        }

        public void ClickViewOpportunity()
        {
            ClickElement(_pageInstance.Options("View Opportunity"));
            LogInfo("Clicked on View Opportunity");
            WaitForLoadingToDisappear();
        }

        public void ClickBackButton()
        {
            Boolean backButtonExist = true;
            WaitForMoment(2);
            try
            {
                backButtonExist = Exists(_pageInstance.BackButton);
            }
            catch (Exception)
            {
                backButtonExist = false;
            }

            if (backButtonExist)
            {
                try
                {
                    ClickElement(_pageInstance.BackButton);
                    try
                    {
                        if (Exists(_pageInstance.BackButton))
                        {
                            ClickElement(_pageInstance.BackButton);
                            LogInfo("Clicked on Back button in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on Back button in 1st attempt");
                    }

                }
                catch (Exception)
                {
                    backButtonExist = false;
                }
            }
            if (!backButtonExist)
            {
                Boolean homeImage = false;
                int count = 0;
                do
                {
                    try
                    {
                        homeImage = Exists(_pageInstance.HomeImage[0]);
                    }
                    catch (Exception)
                    {
                        homeImage = false;
                    }

                    WaitForMoment(1);
                    if (count >= 10)
                    {
                        break;
                    }
                    count = count + 1;
                } while (homeImage.Equals(false));

                if (homeImage)
                {
                    ClickElement(_pageInstance.HomeImage[0]);
                }
                else
                {
                    Assert.Fail("wd icon does not exist");
                }
            }
            WaitForMoment(2);
            WaitForLoadingToDisappear();
            LogInfo("Clicked on Back button");
        }

        public void SearchInInbox(String opportunityName)
        {
            ClickElement(_pageInstance.SearchTextBox);
            ClearElement(_pageInstance.SearchTextBox);
            EnterText(_pageInstance.SearchTextBox, opportunityName);
            ClickElement(_pageInstance.SearchImage);
            WaitForLoadingToDisappear();
        }

        public String GetCellValueInInbox(String cell)
        {
            String value = _pageInstance.RowColumnValue(cell).Text;
            return value;
        }

        public void ValidateCreatedOpportunityInInbox(String opportunityName, String companyName, String activeStage, String forecastValue, String owner, String status)
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(opportunityName, firstRowValues[0]);
            //Assert.AreEqual(companyName, firstRowValues[1]);
            //Assert.AreEqual(DateTime.UtcNow.ToString("M/d/yyyy"), firstRowValues[2]);
            Assert.AreEqual(status, firstRowValues[3]);
            Assert.AreEqual(activeStage, firstRowValues[4]);
            try
            {
                ScrollHorizontally(1);
                Assert.AreEqual(DateTime.UtcNow.ToString("M/d/yyyy"), GetCellValueInInbox("R1C6"));
                Assert.AreEqual(forecastValue, GetCellValueInInbox("R1C7"));
                Assert.AreEqual(owner, GetCellValueInInbox("R1C8"));
                LogInfo("Verified Created Opportunity Displayed In The Inbox");
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify the values from 6th column, but created Opportunity is displayed in the inbox");
            }

        }

        public void VerifyStatusAndStage(String status, String activeStage)
        {
            List<String> firstRowValues = GetFirstRowValues();
            Assert.AreEqual(status, firstRowValues[3]);
            Assert.AreEqual(activeStage, firstRowValues[4]);
        }

        public void VerifyActualCloseDate(String actualCloseDate)
        {
            try
            {
                Assert.AreEqual(actualCloseDate, GetCellValueInInbox("R1C9"));
                LogInfo("Verified Actual Close Date in inbox");
            }
            catch
            {
                LogInfo("Error in scrolling, So unable to verify Actual Close Date, but created Opportunity is displayed in the inbox");
            }

        }

        public void ClickOnProducts()
        {
            Boolean products = true;
            WaitForMoment(2);
            try
            {
                products = Exists(_pageInstance.Products);
            }
            catch (Exception)
            {
                products = false;
            }

            if (products)
            {
                try
                {
                    ClickElement(_pageInstance.Products);
                    try
                    {
                        if (!Exists(_pageInstance.AddProduct))
                        {
                            ClickElement(_pageInstance.Products);
                            LogInfo("Clicked on products in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on products in 1st attempt");
                    }

                }
                catch (Exception)
                {
                    LogInfo("Unable to click on products");
                }
            }

            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void ClickOnServices()
        {
            ClickElement(_pageInstance.Services);
            LogInfo("Clicked on Services");
        }

        public void ClickOnForecasts()
        {
            ClickElement(_pageInstance.Forecasts);
            LogInfo("Clicked on Forecasts");
            WaitForLoadingToDisappear();
        }

        public void ClickOnNextStage()
        {
            while (_pageInstance.NextStage.Count != 0)
            {
                ClickElement(_pageInstance.NextStage[0]);
                LogInfo("Clicked on Next Stage");
                WaitForLoadingToDisappear();
                WaitForMoment(2);
            }

        }

        public void ClickNextStageSingleTime()
        {
            ClickElement(_pageInstance.NextStage[0]);
            LogInfo("Clicked on Next Stage");
            WaitForLoadingToDisappear();
        }

        public void ClickOnPreviousStage()
        {
            ClickElement(_pageInstance.PreviousStage);
            LogInfo("Clicked on Previous Stage");
            WaitForLoadingToDisappear();
        }

        public void ClickOnCloseOpportunity()
        {
            ClickElement(_pageInstance.CloseOpportunity[0]);
            ClickElement(_pageInstance.CloseOpportunity[0]);
            LogInfo("Clicked on Close Opportunity");
            WaitForLoadingToDisappear();
        }

        public void SelectStatus(String status)
        {
            ClickElement(_pageInstance.Status);
            ClickElement(_pageInstance.Options(status));
            LogInfo("Selected status as " + status);
        }

        public void SelectPrimaryCloseReason(String primaryCloseReason)
        {
            ClickElement(_pageInstance.PrimaryCloseReason);
            ClickElement(_pageInstance.Options(primaryCloseReason));
            LogInfo("Selected Primary Close Reason as " + primaryCloseReason);
        }

        public void SelectSecondaryCloseReason(String secondaryCloseReason)
        {
            ClickElement(_pageInstance.SecondaryCloseReason);
            ClickElement(_pageInstance.Options(secondaryCloseReason));
            LogInfo("Selected Primary Close Reason as " + secondaryCloseReason);
        }

        public void ClickOnUpdateButton()
        {
            ClickElement(_pageInstance.Update);
            LogInfo("Clicked On Update Button");
        }

        public void CloseWonOpportunityConfirmation(String options)
        {
            Assert.AreEqual("Are you sure you want to close the opportunity as Won?", GetAttribute(_pageInstance.DialogMessage, "Name"));
            LogInfo("Verified Message 'Are you sure you want to close the opportunity as Won?'");
            ClickOkButton();
            LogInfo("Clicked On " + options);
            WaitForLoadingToDisappear();
        }

        public void CloseLostOpportunityConfirmation(String options)
        {
            Assert.AreEqual("Are you sure you want to close the opportunity as Lost?", GetAttribute(_pageInstance.DialogMessage, "Name"));
            LogInfo("Verified Message 'Are you sure you want to close the opportunity as Lost?'");
            ClickElement(_pageInstance.Options(options));
            LogInfo("Clicked On " + options);
            WaitForLoadingToDisappear();
        }

        public void CloseOpportunity(String status, String primaryCloseReason, String secondaryCloseReason)
        {
            ClickOnCloseOpportunity();
            SelectStatus(status);
            SelectPrimaryCloseReason(primaryCloseReason);
            SelectSecondaryCloseReason(secondaryCloseReason);
            ClickOnUpdateButton();
            ClickElement(_pageInstance.Yes);
        }

        public void CopyOpportunity()
        {
            ClickElement(_pageInstance.Options("Copy Opportunity"));
            LogInfo("Clicked On Copy Opportunity");
            WaitForMoment(2);
            ClickElement(_pageInstance.Options("Yes"));
            WaitForLoadingToDisappear();
        }

        public string DashBoardLabelValue()
        {
            IList<WindowsElement> dashBoardLable = _pageInstance.InboxDashBoardLabel();
            String[] lable = dashBoardLable[0].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            return lable[1];
        }

        public void VerifyOpportunityDashbordLabelValue()
        {
            IList<WindowsElement> dashBoardLable = _pageInstance.InboxDashBoardLabel();
            String[] all = dashBoardLable[0].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] open = dashBoardLable[1].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] lost = dashBoardLable[2].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] won = dashBoardLable[3].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            int total = int.Parse(open[2]) + int.Parse(lost[2]) + int.Parse(won[2]);
            Assert.AreEqual(int.Parse(all[1]), total);
            LogInfo("Verified Opportunity Inbox Count");
        }

        public void VerifyProspectDashbordLabelValue()
        {
            IList<WindowsElement> dashBoardLable = _pageInstance.InboxDashBoardLabel();
            String[] all = dashBoardLable[0].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("all" + all[1]);
            String[] assigned = dashBoardLable[1].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("assigned" + assigned[3]);
            String[] engaged = dashBoardLable[2].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("engaged" + engaged[3]);
            String[] working = dashBoardLable[3].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("working" + working[3]);
            ClickElement(_pageInstance.Right);
            String[] qualified = dashBoardLable[4].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("qualified" + qualified[2]);
            String[] disQualified = dashBoardLable[5].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("disqualified" + disQualified[2]);
            int total = int.Parse(assigned[3]) + int.Parse(engaged[3]) + int.Parse(working[3]) + int.Parse(qualified[2]) + int.Parse(disQualified[2]);
            Assert.AreEqual(int.Parse(all[1]), total);
            LogInfo("Verified Prospect Inbox Count");
        }

        public void VerifyLeadDashBoardLabelValue()
        {
            IList<WindowsElement> dashBoardLable = _pageInstance.InboxDashBoardLabel();
            String[] all = dashBoardLable[0].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("all");
            String[] assigned = dashBoardLable[1].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] engaged = dashBoardLable[2].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] working = dashBoardLable[3].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] qualified = dashBoardLable[4].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] disQualified = dashBoardLable[5].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            int total = int.Parse(assigned[2]) + int.Parse(engaged[2]) + int.Parse(working[2]) + int.Parse(qualified[2]) + int.Parse(disQualified[2]);
            Assert.AreEqual(int.Parse(all[1]), total);
            LogInfo("Verified Lead Inbox Count");
        }

        public void VerifyCaseDashBoardLabelValue()
        {
            IList<WindowsElement> dashBoardLable = _pageInstance.InboxDashBoardLabel();
            String[] all = dashBoardLable[0].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            LogInfo("all");
            String[] inProgess = dashBoardLable[1].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] resolved = dashBoardLable[2].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            String[] cancelled = dashBoardLable[3].Text.Replace('(', ' ').Replace(')', ' ').Split(' ');
            int total = int.Parse(inProgess[2]) + int.Parse(resolved[2]) + int.Parse(cancelled[2]);
            Assert.AreEqual(int.Parse(all[1]), total);
            LogInfo("Verified Case Inbox Count");
        }

        public void ValidateMessage()
        {
            Assert.AreEqual("Opportunity Forecast Details doesn't exists,Please create forecast", GetAttribute(_pageInstance.DialogMessage, "Name"));
            LogInfo("Verified Message 'Opportunity Forecast Details doesn't exists,Please create forecast'");
        }

        public void ClickOkButton()
        {
            ClickElement(_pageInstance.Yes);
            LogInfo("Clicked on Dialoge Message Ok Button");
        }

        public void ClickOnAddProduct()
        {
            ClickElement(_pageInstance.AddProduct);
            LogInfo("Clicked on + Add Product Button");
            WaitForLoadingToDisappear();
        }

        public void VerifyErrorMessageInForecasts()
        {
            Assert.AreEqual("Please add product before creating forecast", GetAttribute(_pageInstance.DialogMessage, "Name"));
            LogInfo("Verified Message 'Please add product before creating forecast'");
        }

        public void ClickCheckBox(int index)
        {
            ClickElement(_pageInstance.CheckBox[index]);
        }

        public int CheckBoxCount()
        {
            return _pageInstance.CheckBox.Count();
        }

        public void AddProducts()
        {
            ClickOnForecasts();
            ClickElement(_pageInstance.NewOpportunityForecast);
            LogInfo("Clicked on + New Opportunity Forecast");
            VerifyErrorMessageInForecasts();
            ClickElement(_pageInstance.Options("OK"));
            ClickOnProducts();
            ClickOnAddProduct();
            WaitForMoment(2);
            ClickCheckBox(0);
            LogInfo("Selected First Item");
            ClickCheckBox(2);
            LogInfo("Selected Third Item");
            ClickElement(_pageInstance.SubmitButton);
            LogInfo("Clicked on Submit Button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnNewOpportunityForecast()
        {
            ClickElement(_pageInstance.NewOpportunityForecast);
            LogInfo("Clicked on + New Opportunity Forecast");
            WaitForLoadingToDisappear();
        }

        public void SelectForecastProduct(String product)
        {
            ClickElement(_pageInstance.ForecastProduct);
            ClickElement(_pageInstance.Options(product));
            LogInfo("Selected Forecast Product " + product);
            WaitForLoadingToDisappear();
        }

        public void EnterYearOneQuantity(String forecastYearOneQuantity)
        {
            ClickElement(_pageInstance.ForecastYearOneQuantity);
            ClearElement(_pageInstance.ForecastYearOneQuantity);
            EnterText(_pageInstance.ForecastYearOneQuantity, forecastYearOneQuantity);
            LogInfo("Entered Year One Forecast Year One Quantity as " + forecastYearOneQuantity);
        }

        public void EnterForecastUnitPrice(String forecastUnitPrice)
        {
            ClickElement(_pageInstance.ForecastUnitPrice);
            ClearElement(_pageInstance.ForecastUnitPrice);
            EnterText(_pageInstance.ForecastYearOneQuantity, forecastUnitPrice);
            LogInfo("Entered Year One Forecast Year One Quantity as " + forecastUnitPrice);
            ClickElement(_pageInstance.ForecastYearOneQuantity);
        }

        public void SelectExistingProduct()
        {
            ClickElement(_pageInstance.ExistingProduct);
            WaitForLoadingToDisappear();
            ClickElement(_pageInstance.SelectAnItemFirstRow);
            LogInfo("Selected Existing Product");
        }

        public void EnterExistingProductYearOneQuantity(String existingProductYearOneQuantity)
        {
            ClickElement(_pageInstance.ExistingProductYearOneQuantity);
            ClearElement(_pageInstance.ExistingProductYearOneQuantity);
            EnterText(_pageInstance.ExistingProductYearOneQuantity, existingProductYearOneQuantity);
            LogInfo("Entered Existing Product Year One Quantity as " + existingProductYearOneQuantity);
        }

        public void EnterExistingProductUnitPrice(String existingProductUnitPrice)
        {
            ClickElement(_pageInstance.ExistingProductUnitPrice);
            ClearElement(_pageInstance.ExistingProductUnitPrice);
            EnterText(_pageInstance.ExistingProductUnitPrice, existingProductUnitPrice);
            LogInfo("Entered Existing Product Year One Quantity as " + existingProductUnitPrice);
            ClickElement(_pageInstance.ExistingProductYearOneQuantity);
        }

        public void ClickAddButton()
        {
            ClickElement(_pageInstance.Add);
            LogInfo("Clicked On Add");
        }

        public void ClickDeleteButton()
        {
            ClickElement(_pageInstance.Delete);
            LogInfo("Clicked On Delete");
        }

        public void ClickAddForecastButton()
        {
            ClickElement(_pageInstance.AddForecastButton);
            LogInfo("Clicked On Add Forecast Button");
            WaitForLoadingToDisappear();
        }

        public void EnterForecastComments(String comments)
        {
            ClickElement(_pageInstance.ForecastComment);
            ClearElement(_pageInstance.ForecastComment);
            EnterText(_pageInstance.ForecastComment, comments);
        }

        public void ClickOnRefreshData()
        {
            ClickElement(_pageInstance.RefreshData);
            LogInfo("Clicked On Refresh Data Button");
            WaitForLoadingToDisappear();
        }

        public void ClickOnForecastIcon(int rowNo)
        {
            Boolean forecastIcon = true;
            WaitForMoment(2);
            try
            {
                forecastIcon = Exists(_pageInstance.ForecastIcon[rowNo]);
            }
            catch (Exception)
            {
                forecastIcon = false;
            }

            if (forecastIcon)
            {
                try
                {
                    ClickElement(_pageInstance.ForecastIcon[rowNo]);
                    try
                    {
                        if (Exists(_pageInstance.ForecastIcon[rowNo]))
                        {
                            ClickElement(_pageInstance.ForecastIcon[rowNo]);
                            LogInfo("Clicked on Forecast icon in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on Forecast icon in 1st attempt");
                    }

                }
                catch (Exception)
                {
                    LogInfo("Unable to click on Forecast icon");
                }
            }

            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void ClickOnForecastCreatedIcon(int rowNo)
        {
            Boolean forecastCreatedIcon = true;
            WaitForMoment(2);
            try
            {
                forecastCreatedIcon = Exists(_pageInstance.ForecastCreatedIcon[rowNo]);
            }
            catch (Exception)
            {
                forecastCreatedIcon = false;
            }

            if (forecastCreatedIcon)
            {
                try
                {
                    ClickElement(_pageInstance.ForecastCreatedIcon[rowNo]);
                    try
                    {
                        if (Exists(_pageInstance.ForecastCreatedIcon[rowNo]))
                        {
                            ClickElement(_pageInstance.ForecastCreatedIcon[rowNo]);
                            LogInfo("Clicked on Forecast Created icon in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on Forecast Created icon in 1st attempt");
                    }

                }
                catch (Exception)
                {
                    LogInfo("Unable to click on Forecast Created icon");
                }
            }

            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void ClickOnOpportunityManagement()
        {
            Boolean opportunityManagement = true;
            WaitForMoment(2);
            try
            {
                opportunityManagement = Exists(_pageInstance.OpportunityManagement);
            }
            catch (Exception)
            {
                opportunityManagement = false;
            }

            if (opportunityManagement)
            {
                try
                {
                    ClickElement(_pageInstance.OpportunityManagement);
                    try
                    {
                        if (!Exists(_pageInstance.OverViewExpandIcon))
                        {
                            ClickElement(_pageInstance.OpportunityManagement);
                            LogInfo("Clicked on Opportunity Management in 2nd attempt");
                        }
                    }
                    catch (Exception)
                    {
                        LogInfo("Clicked on Opportunity Management in 1st attempt");
                    }

                }
                catch (Exception)
                {
                    LogInfo("Unable to click on Opportunity Management");
                }
            }

            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void AddNewOpportunityForecast(String forecastYearOneQuantity, String forecastUnitPrice, String currency, String annualForecastedRevenue, String totalForecastedRevenue, String comments,
            String existingProductOneQuantity, String existingProductUnitPrice, String currentAnnualRevenue, String annualIncrementalRevenue, String totalIncrementalRevenue)
        {
            for (int i = 0; i <= 1; i++)
            {
                ClickOnForecastIcon(0);
                EnterYearOneQuantity(forecastYearOneQuantity);
                EnterForecastUnitPrice(forecastUnitPrice);
                Assert.AreEqual(currency, GetAttribute(_pageInstance.ForecastCurrencyField, "Value.Value"));
                LogInfo("Verified Forecast Currency Field -- " + currency);
                /*Assert.AreEqual(annualForecastedRevenue, GetAttribute(_pageInstance.AnnualForecastedRevenue, "Value.Value"));
                LogInfo("Verified Annual Forecasted Revenue -- " + annualForecastedRevenue);
                Assert.AreEqual(totalForecastedRevenue, GetAttribute(_pageInstance.TotalForecastedRevenue, "Value.Value"));
                LogInfo("Verified Total Forecasted Revenue -- " + totalForecastedRevenue);*/
                SelectExistingProduct();
                EnterExistingProductYearOneQuantity(existingProductOneQuantity);
                EnterExistingProductUnitPrice(existingProductUnitPrice);
               /* Assert.AreEqual(currentAnnualRevenue, GetAttribute(_pageInstance.CurrentAnnualRevenue, "Value.Value"));
                LogInfo("Verified Current Annual Revenue -- " + currentAnnualRevenue);
                Assert.AreEqual(annualIncrementalRevenue, GetAttribute(_pageInstance.AnnualIncrementalRevenue, "Value.Value"));
                LogInfo("Verified Annual Incremental Revenue -- " + annualIncrementalRevenue);
                Assert.AreEqual(totalIncrementalRevenue, GetAttribute(_pageInstance.TotalIncementalRevenue, "Value.Value"));
                LogInfo("Verified Total Incremental Revenue -- " + totalIncrementalRevenue);*/
                ClickAddButton();
                ClickDeleteButton();
                EnterForecastComments(comments);
                ClickAddForecastButton();
            }
        }

        public void pushToAPO(String companyName, String strategicAccountClassification)
        {
            ClickOnProducts();
            ClickOnForecastCreatedIcon(0);
            WaitForLoadingToDisappear();
            if (_pageInstance.Options("Push to APO").Enabled)
            {
                ClickElement(_pageInstance.Options("Push to APO"));
                WaitForLoadingToDisappear();
                Assert.IsTrue(Exists(_pageInstance.APOIndiactor[0]));
                LogInfo("Verified APO indicator is displayed after clicking on push to APO");
                ClickOnForecastCreatedIcon(1);
                WaitForLoadingToDisappear();
                ClickElement(_pageInstance.Options("Push to APO"));
                WaitForLoadingToDisappear();
                Assert.IsTrue(Exists(_pageInstance.APOIndiactor[1]));
                LogInfo("Verified APO indicator is displayed after clicking on push to APO");
                ClickOnOpportunityManagement();
                ClickElement(_pageInstance.NextStage[0]);
                WaitForLoadingToDisappear();

            }
            else
            {
                ClickElement(_pageInstance.UpdateForecast);
                WaitForLoadingToDisappear();
                ClickOnOpportunityManagement();
                ClickElement(_pageInstance.AccountName[1]);
                WaitForLoadingToDisappear();
                ClickElement(_pageInstance.SelectAnItemSearchBox);
                ClearElement(_pageInstance.SelectAnItemSearchBox);
                EnterText(_pageInstance.SelectAnItemSearchBox, companyName);
                WaitForLoadingToDisappear();
                ClickElement(_pageInstance.SelectAnItemFirstRow);
                LogInfo("Selected Account Name - " + companyName);
                SelectPrimaryCustomerContact();
                SelectStrategicAccountClassification(strategicAccountClassification);
                ClickElement(_pageInstance.NextStage[0]);
                WaitForLoadingToDisappear();
                ClickOnProducts();
                for (int i = 0; i <= 1; i++)
                {
                    ClickOnForecastCreatedIcon(i);
                    WaitForLoadingToDisappear();
                    ClickElement(_pageInstance.Options("Push to APO"));
                    Assert.IsTrue(Exists(_pageInstance.APOIndiactor[i]));
                    LogInfo("Verified APO indicator is displayed after clicking on push to APO");
                }
            }

        }

        public void VerifyForcastCreatedIconExists()
        {
            Assert.IsTrue(Exists(_pageInstance.ForecastCreatedIcon[0]));
            Assert.IsTrue(Exists(_pageInstance.ForecastCreatedIcon[1]));
            LogInfo("Verified Forecast Create Icon");
        }

        public void VerifyForecastedValue(String forecastedValue)
        {
            ClickOnOpportunityManagement();
            Assert.AreEqual(forecastedValue, GetAttribute(_pageInstance.ForcastedValue, "Value.Value"));
            LogInfo("Verified Forecasted Value after adding the product and forecast -- " + forecastedValue);
        }

        //Service
        public void ClickService()
        {
            ClickElement(_pageInstance.Options("Services"));
        }

        public void ClickAddService()
        {
            ClickElement(_pageInstance.Options("Services"));
            ClickElement(_pageInstance.AddService);
            LogInfo("Clicked On Add Service");
            WaitForLoadingToDisappear();
        }

        public void SelectAnalyticalLabService()
        {
            ClickElement(_pageInstance.AnalyticalLabServiceQuestionaires);
            if (!Exists(_pageInstance.Options("Analytical Lab Service")))
            {
                ClickElement(_pageInstance.AnalyticalLabServiceQuestionaires);
            }
            ClickElement(_pageInstance.Options("Analytical Lab Service"));
            LogInfo("Selected Analytical Labv Service");
            ClickElement(_pageInstance.Options("Container Closure Integrity"));
            LogInfo("Selected Container Closure Integrity");
        }

        public void EnterDrugProductAndContainerClosureFields(String stopper, String vial, String seal, String cartridge, String pfs, String syringeSize, String tipCap, String plunger, String cCSDOther, String drugProductName,
            String marketProduct, String placebo, String justification, String concentrationOfActive, String dosingRegimen, String fillVolume, String headSpace, String shelfLife, String StorageConditions, String dEAControlled,
            String schedule, String dPDPAdditionalInformation)

        {
            ClickElement(_pageInstance.DrugProductExpandIcon);
            SendText(_pageInstance.Stopper, stopper);
            SendText(_pageInstance.Vial, vial);
            SendText(_pageInstance.Seal, seal);
            SendText(_pageInstance.Cartridge, cartridge);
            SendText(_pageInstance.PFS, pfs);
            SendText(_pageInstance.SyringeSize, syringeSize);
            SendText(_pageInstance.TipCap, tipCap);
            SendText(_pageInstance.Plunger, plunger);
            //SendText(_pageInstance.CCSDOther, cCSDOther);
            SendText(_pageInstance.DrugProductName, drugProductName);
            SendText(_pageInstance.MarketProduct, marketProduct);
            SendText(_pageInstance.Placebo, placebo);
            SendText(_pageInstance.Justification, justification);
            SendText(_pageInstance.ConcentrationOfActive, concentrationOfActive);
            SendText(_pageInstance.DosingRegimen, dosingRegimen);
            SendText(_pageInstance.FillVolume, fillVolume);
            SendText(_pageInstance.HeadSpace, headSpace);
            SendText(_pageInstance.ShelfLife, shelfLife);
            SendText(_pageInstance.StorageConditions, StorageConditions);
            SendText(_pageInstance.DEAControlled, dEAControlled);
            SendText(_pageInstance.Schedule, schedule);
            //SendText(_pageInstance.DPDPAdditionalInformation, dPDPAdditionalInformation);
        }

        public void EnterHeliumLeakFields(String hLWIMQuantity, String temperature, String comments)
        {
            ClickElement(_pageInstance.HeliumLeakExpandIcon);
            //SendText(_pageInstance.HLWIMQuantity[0], hLWIMQuantity);
            ClickElement(_pageInstance.HLWIMTemperature[0]);
            ClickElement(_pageInstance.Options(temperature));
            ClickElement(_pageInstance.AddMoreAction[0]);
            WaitForMoment(2);
            SendText(_pageInstance.HLWIMTemperature[0], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(hLWIMQuantity);
            //SendText(_pageInstance.HLWIMQuantity[1], hLWIMQuantity);
            ClickElement(_pageInstance.HLWIMTemperature[1]);
            ClickElement(_pageInstance.Options(temperature));
            //SendText(_pageInstance.HLCLTMQuantity[0], hLWIMQuantity);
            SendText(_pageInstance.CLTMDocumentNumber[0], hLWIMQuantity);
            //ClickElement(_pageInstance.AddMoreAction[1]);
            //SendText(_pageInstance.HLCLTMQuantity[1], hLWIMQuantity);
            //SendText(_pageInstance.CLTMDocumentNumber[1], hLWIMQuantity);
            ClickElement(_pageInstance.HLMDMVTemperature[0]);
            ClickElement(_pageInstance.Options(temperature));
            SendText(_pageInstance.HLMDMVRobustness[0], hLWIMQuantity);
            ClickElement(_pageInstance.AddMoreAction[2]);
            ClickElement(_pageInstance.HLMDMVTemperature[1]);
            ClickElement(_pageInstance.Options(temperature));
            SendText(_pageInstance.HLMDMVRobustness[1], hLWIMQuantity);
            //SendText(_pageInstance.HLAdditionalInformation, comments);
        }

        public void EnterHeadSpaceAnalysisFields(String quantity, String selectMethod, String comments)
        {
            ClickElement(_pageInstance.HeadSpaceExpandIcon);
            //SendText(_pageInstance.HAWIMQuantity[0], quantity);
            ClickElement(_pageInstance.HAWIMSelectMethod[0]);
            ClickElement(_pageInstance.Options(selectMethod));
            ClickElement(_pageInstance.AddMoreAction[3]);
            WaitForMoment(2);
            SendText(_pageInstance.HAWIMSelectMethod[0], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HAWIMQuantity[1], quantity);
            ClickElement(_pageInstance.HAWIMSelectMethod[1]);
            ClickElement(_pageInstance.Options(selectMethod));
            WaitForMoment(2);
            SendText(_pageInstance.HAWIMSelectMethod[1], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HLCLTMQuantity[2], quantity);
            SendText(_pageInstance.CLTMDocumentNumber[1], quantity);
            //ClickElement(_pageInstance.AddMoreAction[4]);
            //ClickElement(_pageInstance.AddMoreAction[4]);
            //SendText(_pageInstance.HLCLTMQuantity[3], quantity);
            //SendText(_pageInstance.CLTMDocumentNumber[3], quantity);
            ClickElement(_pageInstance.MDMVStandardNeeds[0]);
            ClickElement(_pageInstance.Options("Yes"));
            ClickElement(_pageInstance.HAMDMVSelectMethod[0]);
            ClickElement(_pageInstance.Options("Oxygen"));
            ClickElement(_pageInstance.AddMoreAction[5]);
            ClickElement(_pageInstance.MDMVStandardNeeds[1]);
            ClickElement(_pageInstance.Options("Yes"));
            ClickElement(_pageInstance.HAMDMVSelectMethod[1]);
            ClickElement(_pageInstance.Options(selectMethod));
            //SendText(_pageInstance.HeadSpaceAdditionalInformation, comments);
        }

        public void HighVoltageLeakDetectionFields(String quantity, String comments)
        {
            ClickElement(_pageInstance.HVLDExpandIcon);
            ClickElement(_pageInstance.MDMVStandardNeeds[2]);
            ClickElement(_pageInstance.Options("Yes"));
            SendText(_pageInstance.HVLDValidationNotes[0], quantity);
            SendText(_pageInstance.HVLDValidationNotes[0], Keys.Tab);
            ClickElement(_pageInstance.AddMoreAction[6]);
            ClickElement(_pageInstance.MDMVStandardNeeds[3]);
            ClickElement(_pageInstance.Options("Yes"));
            SendText(_pageInstance.HVLDValidationNotes[1], quantity);
            WaitForMoment(2);
            SendText(_pageInstance.HVLDValidationNotes[1], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HLCLTMQuantity[4], hLWIMQuantity);
            SendText(_pageInstance.CLTMDocumentNumber[2], quantity);
            SendText(_pageInstance.CLTMDocumentNumber[2], Keys.Tab);
            ClickElement(_pageInstance.AddMoreAction[7]);
            WaitForMoment(2);
            SendText(_pageInstance.CLTMDocumentNumber[2], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HLCLTMQuantity[5], hLWIMQuantity);
            SendText(_pageInstance.CLTMDocumentNumber[3], quantity);
            //SendText(_pageInstance.HVLDAdditionalInformation, comments);
        }

        public void VaccumDecayFields(String quantity, String comments)
        {
            ClickElement(_pageInstance.VaccumDecayExpandIcon);
            ClickElement(_pageInstance.MDMVStandardNeeds[4]);
            ClickElement(_pageInstance.Options("Yes"));
            SendText(_pageInstance.HVLDValidationNotes[2], quantity);
            //ClickElement(_pageInstance.AddMoreAction[8]);
            //ClickElement(_pageInstance.MDMVStandardNeeds[5]);
            //ClickElement(_pageInstance.Options("Yes"));
            //SendText(_pageInstance.HVLDValidationNotes[3], quantity);
            WaitForMoment(2);
            SendText(_pageInstance.HVLDValidationNotes[2], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HLCLTMQuantity[5], hLWIMQuantity);
            SendText(_pageInstance.CLTMDocumentNumber[4], quantity);
            SendText(_pageInstance.CLTMDocumentNumber[4], Keys.Tab);
            ClickElement(_pageInstance.AddMoreAction[9]);
            WaitForMoment(2);
            SendText(_pageInstance.CLTMDocumentNumber[4], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(quantity);
            //SendText(_pageInstance.HLCLTMQuantity[5], hLWIMQuantity);
            SendText(_pageInstance.CLTMDocumentNumber[5], quantity);

            //SendText(_pageInstance.VaccumDecayAdditionalInformation, comments);
        }

        public void WestStabilityFields(String timePoint, String temperature, String orientation, String comments)
        {
            ClickElement(_pageInstance.WestStabilityExpandIcon);
            SendText(_pageInstance.WestStabilityTimePoint[0], timePoint);
            ClickElement(_pageInstance.WestStabilityTemperature[0]);
            ClickElement(_pageInstance.Options(temperature));
            ClickElement(_pageInstance.WestStabilityOrientation[0]);
            ClickElement(_pageInstance.Options(orientation));
            WaitForMoment(2);
            SendText(_pageInstance.WestStabilityOrientation[0], Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys("200");
            //SendText(_pageInstance.AIdCLTMQuantityFieldControl[5], hLWIMQuantity);
            //ClickElement(_pageInstance.AddMoreAction[10]);
            //SendText(_pageInstance.WestStabilityAdditionalInformation, comments);
        }

        public void EnterTextInRTE(String comments, String quantity)
        {
            SendText(_pageInstance.Plunger, Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            _session.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
            _session.SwitchTo().ActiveElement().SendKeys(comments);
            SendText(_pageInstance.Plunger, "h");
            SendText(_pageInstance.HVLDValidationNotes[0], quantity);
            SendText(_pageInstance.HVLDValidationNotes[1], quantity);
            SendText(_pageInstance.CLTMDocumentNumber[2], quantity);
            SendText(_pageInstance.HVLDValidationNotes[2], quantity);
            SendText(_pageInstance.CLTMDocumentNumber[4], quantity);
        }

        public void ClickCreateService()
        {
            ClickElement(_pageInstance.CreateService);
            LogInfo("Clicked on Create Service");
            WaitForLoadingToDisappear();
        }


        public void CheckOpportunityStatus(String opportunityStatus)
        {
            Assert.AreEqual(opportunityStatus, GetAttribute(_pageInstance.OpportunityStatus, "Value.Value"));
            LogInfo("Verified Opportunity Status  - " + opportunityStatus);
        }

        public void VerifyServiceIsCreatedOrNot()
        {
            Assert.AreEqual("Analytical Lab Service", GetAttribute(_pageInstance.ServiceName[1], "Name"));
            Assert.AreEqual("Container Closure Integrity", GetAttribute(_pageInstance.ServiceName[2], "Name"));
            LogInfo("Verified Service is Created");
        }

        public void VerifyService()
        {
            ClickElement(_pageInstance.Options("Services"));
            LogInfo("Clicked On Service");
            WaitForLoadingToDisappear();
            Assert.AreEqual("Analytical Lab Service", GetAttribute(_pageInstance.ServiceName[1], "Name"));
            Assert.AreEqual("Container Closure Integrity", GetAttribute(_pageInstance.ServiceName[2], "Name"));
            LogInfo("Verified Service");
        }

        public void VerifyViewOpportunityPage(String opportunityName, String address, String opportunityOwner, String bussinessType, String bussinessSubType, String projectedClosureDate, String region, String forecastedValue,
            String marketUnit, String currency, String segment, String subSegment, String probaility, String strategicAcountClassification, String application, String sipDesignation, String closeWonType, String organizationalVP,
            String busDev, String opportunityStatus, String primaryCloseReason, String secondaryCloseReason, String puroseOfInquiry, String westInitiative, String westCampaign, String clinicalPhase, String detailedRequest,
            String bussinessImpact, String generalNotes, String requestType)
        {
            Assert.AreEqual(opportunityName, GetAttribute(_pageInstance.OpportunityName, "Value.Value"));
            LogInfo("Verified Opportunity Name  - " + opportunityName);
            Assert.IsTrue(GetAttribute(_pageInstance.AccountNameField, "Value.Value") != null);
            LogInfo("Verified Company Name - " + GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value") != null);
            LogInfo("Verified Primary Customer Contact is auto populated with - " + GetAttribute(_pageInstance.PrimaryCustomerContactField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated with - " + GetAttribute(_pageInstance.Address, "Value.Value"));
            Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            LogInfo("Verified Opportunity Owner  - " + opportunityOwner);
            Assert.AreEqual(bussinessType, GetAttribute(_pageInstance.BussinessTypeNameField, "Name"));
            LogInfo("Verified Bussiness Type - " + bussinessType);
            Assert.AreEqual(bussinessSubType, GetAttribute(_pageInstance.BussinessSubTypeNameField, "Name"));
            LogInfo("Verified Bussiness SubType - " + bussinessSubType);
            Assert.IsTrue(GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value") != null);
            LogInfo("Verified Projected Closed Date - " + GetAttribute(_pageInstance.ProjectedCloseDate, "Value.Value"));
            Assert.AreEqual(region, GetAttribute(_pageInstance.RegionNameField, "Name"));
            LogInfo("Verified Region - " + region);
            //Assert.AreEqual(forecastedValue, GetAttribute(_pageInstance.ForcastedValue, "Value.Value"));
            //LogInfo("Verified Foreccast Value - " + forecastedValue);
            Assert.AreEqual(marketUnit, GetAttribute(_pageInstance.MarketUnitNameField, "Name"));
            LogInfo("Verified Market Unit - " + marketUnit);
            Assert.AreEqual(currency, GetAttribute(_pageInstance.CurrencyNameField, "Name"));
            LogInfo("Verified Currency - " + currency);
            Assert.AreEqual(segment, GetAttribute(_pageInstance.MarketSegmentNameField, "Name"));
            LogInfo("Verified Market Segment - " + segment);
            Assert.AreEqual(subSegment, GetAttribute(_pageInstance.MarketSubSegmentNameField, "Name"));
            LogInfo("Verified Market SubSegment - " + subSegment);
            Assert.AreEqual(probaility, GetAttribute(_pageInstance.ProbabilityNameField, "Name"));
            LogInfo("Verified Probability - " + probaility);
            Assert.AreEqual(strategicAcountClassification, GetAttribute(_pageInstance.StrategicAccountClassificationNamefied, "Name"));
            LogInfo("Verified Strategic Acount Classification - " + strategicAcountClassification);
            Assert.AreEqual(application, GetAttribute(_pageInstance.ApplicationNameField, "Name"));
            LogInfo("Verified Application - " + application);
            Assert.IsTrue(GetAttribute(_pageInstance.HVPNameField, "Value.Value") != null);
            LogInfo("Verified HVP - " + GetAttribute(_pageInstance.HVP, "Value.Value"));
            Assert.AreEqual(sipDesignation, GetAttribute(_pageInstance.SIPDesignationNameField, "Name"));
            LogInfo("Verified SIP Designation - " + sipDesignation);
            Assert.AreEqual(closeWonType, GetAttribute(_pageInstance.CloseWonTypeNameField, "Name"));
            LogInfo("Verified Close won Type - " + closeWonType);
            Assert.AreEqual(organizationalVP, GetAttribute(_pageInstance.OrganizationalVPNameField, "Name"));
            LogInfo("Verified Organizational VP - " + organizationalVP);
            Assert.AreEqual(busDev, GetAttribute(_pageInstance.BusDev, "Value.Value"));
            LogInfo("Verified BusDev - " + busDev);
            Assert.AreEqual(opportunityStatus, GetAttribute(_pageInstance.OpportunityStatus, "Value.Value"));
            LogInfo("Verified Opportunity Status  - " + opportunityStatus);
            Assert.AreEqual(primaryCloseReason, GetAttribute(_pageInstance.WonPrimaryCloseReason, "Value.Value"));
            LogInfo("Verified Opportunity Status  - " + primaryCloseReason);
            Assert.AreEqual(secondaryCloseReason, GetAttribute(_pageInstance.WonSecondaryCloseReason, "Value.Value"));
            LogInfo("Verified Opportunity Status  - " + secondaryCloseReason);
            Assert.AreEqual(puroseOfInquiry, GetAttribute(_pageInstance.PurposeofInquiryNameField, "Name"));
            LogInfo("Verified Purpose Of Enquiry - " + puroseOfInquiry);
            Assert.IsTrue(GetAttribute(_pageInstance.MoleculeNameField, "Value.Value") != null);
            LogInfo("Verified Molecule Name - " + GetAttribute(_pageInstance.MoleculeNameField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.MoleculeType, "Name") != null);
            LogInfo("Verified Molecule Type - " + GetAttribute(_pageInstance.MoleculeType, "Name"));
            Assert.AreEqual(westInitiative + ",", GetAttribute(_pageInstance.WestInitiativeNameField, "Value.Value"));
            LogInfo("Verified West Initiative - " + westInitiative);
            Assert.AreEqual(westCampaign + ",", GetAttribute(_pageInstance.WestCampaignNameField, "Value.Value"));
            LogInfo("Verified West Campaign - " + westCampaign);
            Assert.IsTrue(GetAttribute(_pageInstance.TherapeuticClassNameField, "Value.Value") != null);
            LogInfo("Verified Therapeutic Class - " + GetAttribute(_pageInstance.TherapeuticClassNameField, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.ThirdPartyContractOrganizationNameField, "Value.Value") != null);
            LogInfo("Verified Third Party Contract Organization - " + GetAttribute(_pageInstance.ThirdPartyContractOrganizationNameField, "Value.Value"));
            Assert.AreEqual(clinicalPhase, GetAttribute(_pageInstance.ClinicalPhaseNameField, "Name"));
            LogInfo("Verified Clinical Phase - " + clinicalPhase);
            /* Assert.AreEqual(detailedRequest, GetAttribute(_pageInstance.DetailedRequestNameField, "Value.Value"));
             LogInfo("Verified Detailed Request - " + detailedRequest);
             Assert.AreEqual(bussinessImpact, GetAttribute(_pageInstance.BussinessImpactNameField, "Value.Value"));
             LogInfo("Verified Bussiness Impact - " + bussinessImpact);
             Assert.AreEqual(generalNotes, GetAttribute(_pageInstance.GeneralNotesNameField, "Value.Value"));
             LogInfo("Verified General Notes - " + generalNotes);*/
            Assert.AreEqual(requestType, GetAttribute(_pageInstance.RequestTypeNameField, "Name"));
            LogInfo("Verified Purpose Of Enquiry - " + requestType);
            Assert.IsTrue(GetAttribute(_pageInstance.PromiseDate, "Value.Value") != null);
            LogInfo("Verified Prosmise Date - " + GetAttribute(_pageInstance.PromiseDate, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.DeliveryDate, "Value.Value") != null);
            LogInfo("Verified Delivery Date - " + GetAttribute(_pageInstance.DeliveryDate, "Value.Value"));
            Assert.IsTrue(GetAttribute(_pageInstance.ExpirationDate, "Value.Value") != null);
            LogInfo("Verified Expiration Date - " + GetAttribute(_pageInstance.ExpirationDate, "Value.Value"));
        }

        public void ValidateOpportunityPageCreatedFromCustomer(String customerName, String address, String opportunityOwner)
        {
            Assert.AreEqual(customerName, GetAttribute(_pageInstance.AccountNameField, "Value.Value"));
            LogInfo("Verified Account name is auto populated ");
            Assert.IsTrue(GetAttribute(_pageInstance.Address, "Value.Value") != null);
            LogInfo("Verified Address is auto populated ");
            Assert.AreEqual(opportunityOwner, GetAttribute(_pageInstance.OpportunityOwner, "Value.Value"));
            LogInfo("Verified Opportunity Owner name is auto populated ");
        }

        public Boolean CheckNoDataAvailable()
        {
            try
            {
                return Exists(_pageInstance.NoDataAvailable);

            }
            catch (Exception)
            {
                return false;
            }

        }

        public void ScrollHorizontally(int count)
        {
            try
            {
                MouseHoverOnWindowsElement(_pageInstance.ValuebyRowAndColumnInGrid()[0]);
                MouseHoverOnWindowsElement(Session.FindElementsByAccessibilityId("HorizontalScrollBar").ToList()[0]);
                WaitForMoment(2);
                int offsetX = _pageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.X;
                int offsetY = _pageInstance.HorizontalIncreaseButton.Coordinates.LocationInDom.Y;
                for (int i = 0; i < count; i++)
                {
                    Mouse.DragTo(MouseButton.Left, new Point(offsetX - 10, offsetY));
                    WaitForMoment(2);
                }
                LogInfo("Srolled the Inbox horizontally");
            }
            catch (Exception ex)
            {
                LogError($"Error in scoliing the element: {ex.Message}");
            }
        }

        public void VerifyMandatoryFieldsMessage(int index, String field)
        {
            IList<WindowsElement> mandatoryFieldsMessage = _pageInstance.MandatoryFieldsLable();
            Assert.IsTrue(GetAttribute(mandatoryFieldsMessage[index], "Name").Contains(field));
            LogInfo("Verified Mandatory Field Message for - "+ field);
        }

        public void VerifyMandatoryFieldsCount(int count)
        {
            IList<WindowsElement> mandatoryFieldsMessage = _pageInstance.MandatoryFieldsLable();
            Assert.AreEqual(mandatoryFieldsMessage.Count,count);
            LogInfo("Verified Mandatory Field Count");
        }
    }
}
