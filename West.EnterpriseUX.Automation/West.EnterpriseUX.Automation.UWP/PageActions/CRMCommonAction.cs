using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class CRMCommonAction:BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly CRMCommonPage _pageInstance;

        public CRMCommonAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new CRMCommonPage(_session);
        }
        public void ClickCreateButton()
        {
            ClickElement(_pageInstance.createButton);
            LogInfo("Clicked on create button");
            WaitForLoadingToDisappear();
        }

        public void ClickUpdateButton()
        {
            ClickElement(_pageInstance.UpdateButton);
            LogInfo("Clicked on update button");
            WaitForLoadingToDisappear();
        }

        public string ClickBackButton()
        {
            Boolean backButtonExist = true;
            String clickedButton = "BackButton";
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
                        clickedButton = "HomeIcon";
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
            return clickedButton;
        }

        public List<String> GetFirstRowValues()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }

        public List<String> GetFirstRowValuesByRowNumber(int rowNumber)
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGridRowWise(rowNumber);
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGridRowWise(rowNumber);
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }
    }


}
