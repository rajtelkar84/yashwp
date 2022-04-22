using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class HRAddressAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly HRAddressPage _pageInstance;

        public HRAddressAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new HRAddressPage(_session);
        }
        public void SelectAddressType(string addressType)
        {
            WaitForMoment(0.3);
            _pageInstance.AddressTypePicker.Click();
            WaitForMoment(0.3);
            _pageInstance.SelectAddressType(addressType).Click();
        }
        public void EnterCareOf(string careOfValue)
        {
            _pageInstance.CareOfEdit.Clear();
            _pageInstance.CareOfEdit.SendKeys(careOfValue);
            WaitForMoment(0.3);
        }
        public void EnterAddressFirstLine(string addressFirstLine)
        {
            if (_pageInstance.AddressFirstLine.Count > 0)
            {
                _pageInstance.AddressFirstLine[0].SendKeys(addressFirstLine);
                WaitForMoment(0.3);
            }
        }
        public void EnterAddressSecondLine(string addressSecondLine)
        {
            if (_pageInstance.AddressSecondLine.Count > 0)
            {
                _pageInstance.AddressSecondLine[0].SendKeys(addressSecondLine);
                WaitForMoment(0.3);
            }
        }
        public void EnterCity(string city)
        {
            _pageInstance.CityEdit.SendKeys(city);
            WaitForMoment(0.3);
        }
        public void EnterPinCode(string pincode)
        {
            _pageInstance.PinCodeEdit.Click();
            WaitForMoment(1);
            _pageInstance.PinCodeEdit.SendKeys(pincode);
            string value = _pageInstance.PinCodeEdit.GetAttribute("Value.Value");
            if (!value.Equals(pincode))
            {
                _pageInstance.PinCodeEdit.Click();
                WaitForMoment(1);
                _pageInstance.PinCodeEdit.SendKeys(pincode);
            }
            WaitForMoment(0.3);
        }
        public void EnterTelephoneNo(string telephoneNo)
        {
            if (_pageInstance.TelephoneEdit.Count > 0)
            {
                _pageInstance.TelephoneEdit[0].Clear();
                _pageInstance.TelephoneEdit[0].SendKeys(telephoneNo);
                WaitForMoment(0.3);
            }
        }
        public void ClickOnSave()
        {
            _pageInstance.SaveButton.Click();
            WaitForMoment(0.3);
        }
        public void ClickOnOk()
        {
            _pageInstance.AcknowledgementOkButton.Click();
            WaitForMoment(0.3);
        }
        public void VerifyPersonalAddressField(string fieldValue)
        {
            ScrollVertically(0);
            _pageInstance.SearchingText(fieldValue).Click();
            WindowsElement addressField = _pageInstance.SearchingText(fieldValue);
            Assert.AreEqual(fieldValue, addressField.Text, $"Field Value {addressField.Text} is not as expected value {fieldValue}");
        }
        public string GetAddressType(int addressTypeNo)
        {
            string addressType = string.Empty;
            switch (addressTypeNo)
            {
                case 1:
                    addressType = "Permanent";
                    break;
                case 2:
                    addressType = "Temporary";
                    break;
                case 3:
                    addressType = "Emergency";
                    break;
                default:
                    break;
            }
            return addressType;
        }
        public void CreateAddress(string careOf, string addresFirstLine, string addresSecondLine, string city, string pincode, string telephoneNo,string country)
        {
            Random random = new Random();
            string addressType = GetAddressType(random.Next(1, 3));
            if (!addressType.ToLower().Contains("emergency"))
            {
                WaitForMoment(10);
                SelectAddressType(addressType);
                EnterCareOf(careOf);
                EnterAddressFirstLine(addresFirstLine);
                EnterCity(city);
                EnterPinCode(pincode);
                EnterAddressSecondLine(addresSecondLine);
                SelectAddressRegion();
                EnterTelephoneNo(telephoneNo);
            }
            else
            {
                SelectAddressType(addressType);
                EnterCareOf(careOf);
                EnterTelephoneNo(telephoneNo);
            }
            WaitForMoment(2);
            ClickOnSave();
            WaitForMoment(4);
            TakeScreenshot("CreateAddress_"+country);
            ClickOnOk();
            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }
        public void UpdateAddress(string careOf, string telephoneNo, string country)
        {
            EnterCareOf(careOf);
            WaitForMoment(1);
            EnterTelephoneNo(telephoneNo);
            WaitForMoment(1);
            ClickOnSave(); 
            WaitForMoment(1);
            TakeScreenshot("UpdateAddress_" + country);
            ClickOnOk();
        }
        public void NavigateToUpdateAddressPage(string country)
        {
            IList<WindowsElement> personalAddress = _pageInstance.UpdateImage;
            if (personalAddress.Count > 0)
            {
                _pageInstance.UpdateImage[0].Click();
                WaitForMoment(1);
                _pageInstance.UpdateButton.Click();
                WaitForMoment(1);
                WaitForLoadingToDisappear();
            }
            else
            {
                LogInfo($"Personal Address not present to update for this country: {country} ");
                Assert.Fail($"Personal Address not present to update for this country: {country} ");
            }
        }
        public void FilterDataBySearch(string value)
        {
            EnterSearchValue(value);
            WaitForMoment(1);
            ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }
        public void EnterSearchValue(string value)
        {
            _pageInstance.SearchEditInGrid.Clear();
            _pageInstance.SearchEditInGrid.SendKeys(value);
        }
        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButtonInGrid.Click();
            WaitForLoadingToDisappear();
        }
        public void SelectAddressRegion()
        {
            IList<WindowsElement> addressRegionField = _pageInstance.AddressRegionsCombobox;

            if(addressRegionField.Count>0)
            {
                List<string> availableAddressRegions = new List<string>();
                WaitForMoment(1);
                _pageInstance.AddressRegionsCombobox[0].Click();
                WaitForMoment(0.3);
                IList<WindowsElement> addressRegions = _pageInstance.AddressRegions;

                foreach (WindowsElement region in addressRegions)
                {
                    bool isDisplayed = region.Displayed;
                    if (isDisplayed)
                    {
                        availableAddressRegions.Add(region.Text);
                    }
                }
                _pageInstance.SelectAddressRegion(availableAddressRegions[1]).Click();
            }
        }

        public void CreateAddressDetails(string addressType, string careOf, string addresFirstLine, string addresSecondLine, string region, string city, string pincode, string telephoneNo, string country, string message)
        {
            if (addressType.ToLower().Contains("emergency"))
            {
                WaitForMoment(2);
                SelectAddressType(addressType);
                EnterCareOf(careOf);
                EnterTelephoneNo(telephoneNo);
            }
            else
            {
                SelectAddressType(addressType);
                SelectTomorrowStartDate();
                EnterCareOf(careOf);
                EnterAddressFirstLine(addresFirstLine);
                if (country.ToLower().Equals("usa"))
                {
                    EnterAddressSecondLine(addresSecondLine);
                    SelectGivenAddressRegion(region);
                    
                }
                EnterCity(city);
                EnterPinCode(pincode);
                EnterTelephoneNo(telephoneNo);
                if (region.ToLower().Equals("pennsylvania"))
                {
                    ClickOnSave();
                    WaitForMoment(2);
                    ValidatePopUpMessage("County field cannot be blank");
                    ClickOnOk();
                    SelectCounty();
                }
                    
                if (country.ToLower().Equals("germany"))
                {
                    EnterDistanceInKM();
                }
                   
            }
            WaitForMoment(2);
            ClickOnSave();
            WaitForMoment(2);
            ValidatePopUpMessage(message);
            TakeScreenshot("CreateAddress_" + country);
            ClickOnOk();
            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void SelectGivenAddressRegion(string givenRegion)
        {
            IList<WindowsElement> addressRegionField = _pageInstance.RegionImage;

            if (addressRegionField.Count > 0)
            {
                WaitForMoment(1);
                addressRegionField[0].Click();
                WaitForMoment(0.3);
                _pageInstance.SearchInGrid.Click();
                WaitForMoment(0.3);
                _pageInstance.SearchInGrid.SendKeys(givenRegion);
                WaitForMoment(0.3);
                _pageInstance.SearchButtonInSelectRegion.Click();
                WaitForMoment(0.3);
                _pageInstance.SelectAddressRegion(givenRegion).Click();
            }
        }
        public void ValidatePopUpMessage(string expectedMessage)
        {
            WaitForElementToAppear(expectedMessage);
            Assert.IsTrue(_pageInstance.PopUpDialogMessage.Displayed);
            string popUpMessage = _pageInstance.PopUpDialogMessage.Text;
            Assert.AreEqual(expectedMessage, popUpMessage);
        }

        public void VerifyAddressResetFunctionality(string addressType, string careOf, string addresFirstLine, string addresSecondLine, string region, string city, string pincode, string telephoneNo, string country, string message)
        {
            if (addressType.ToLower().Contains("emergency"))
            {
                WaitForMoment(2);
                SelectAddressType(addressType);
                EnterCareOf(careOf);
                EnterTelephoneNo(telephoneNo);
            }
            else
            {
                SelectAddressType(addressType);
                EnterCareOf(careOf);
                EnterAddressFirstLine(addresFirstLine);
                EnterAddressSecondLine(addresSecondLine);
                SelectGivenAddressRegion(region);
                EnterCity(city);
                EnterPinCode(pincode);
                EnterTelephoneNo(telephoneNo);
            }
            WaitForMoment(2);
            Assert.IsNotNull(_pageInstance.CareOfEdit.GetAttribute("Value.Value"));
            ClickOnReset();
            WaitForMoment(4);
            ValidatePopUpMessage(message);
            TakeScreenshot("ResetFunctionality_" + country);
            ClickOnOk();
            Assert.IsNull(_pageInstance.CareOfEdit.GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.AddressFirstLine[0].GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.AddressSecondLine[0].GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.CityEdit.GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.PinCodeEdit.GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.TelephoneEdit[0].GetAttribute("Value.Value"));
            Assert.IsNull(_pageInstance.RegionEditTextBox.GetAttribute("Value.Value"));
            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }

        public void ClickOnReset()
        {
            _pageInstance.ResetButton.Click();
            WaitForMoment(0.3);
        }

        public void EnterDistanceInKM()
        {
            if (_pageInstance.DistanceInKMEdit.Count > 0)
            {
                Random random = new Random();
                string distance = random.Next(1, 20).ToString();
                _pageInstance.DistanceInKMEdit[0].Clear();
                _pageInstance.DistanceInKMEdit[0].SendKeys(distance);
                WaitForMoment(0.3);
            }
        }

        public void SelectAddressAction()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(2);
            IList<WindowsElement> moreButtonList = _pageInstance.AddressDetailAction_More;
            moreButtonList[0].Click();
        }

        public void SelectEndNow()
        {
            IList<WindowsElement> EndNowElementsList = _pageInstance.EndNowAction;
            foreach (WindowsElement EndNowElement in EndNowElementsList)
            {
                bool isDisplayed = EndNowElement.Displayed;
                if (isDisplayed)
                {
                    EndNowElement.Click();
                    break;
                }
            }
        }
        public void SelectCounty()
        {
            _pageInstance.CountyImage.Click();
            WaitForMoment(2);
            _pageInstance.SelectCountyValue.Click();
        }

        public Boolean VerifyRecordPresent(string fieldValue)
        {
            bool temp = false;
            try
            {
                if (_pageInstance.SearchingText(fieldValue).Displayed)
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
            }
            catch (Exception)
            {
                temp = false;
            }
            return temp;
           
        }
        public void SelectTomorrowStartDate()
        {
            WaitForLoadingToDisappear();
            _pageInstance.calendarDatePicker.Click();
            IList<WindowsElement> dateItems = _pageInstance.CalendarPopUpDateItems;
            if (dateItems.Count > 1)
                dateItems[1].Click();
        }

        public void ClickDeleteAddressButton(string searchValue)
        {
            WaitForLoadingToDisappear();
            _pageInstance.AddressDeleteButton(searchValue).Click();
        }
        public void SelectAddressAccountMenuOption()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            _pageInstance.Address.Click();
        }
    }
}

