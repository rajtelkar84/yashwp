using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class ManufacturingTest : BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Tests Verifying Label Printing functionality;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_276786.csv", "Manufacturing_276786#csv", DataAccessMethod.Sequential)]
        public void TC_276786_LabelPrintingTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                // Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);
                WaitForMoment(2);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Checking for Print button functionality through Details action;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279218.csv", "Manufacturing_279218#csv", DataAccessMethod.Sequential)]
        public void TC_279218_LabelPrintingPrintButtonFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Select any one Label from below
                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Label Printing page should display after selecting Label Printing option in Context Menu;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_277612.csv", "Manufacturing_277612#csv", DataAccessMethod.Sequential)]

        public void TC_277612_LabelPrintingFunctionalityContextMenuTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxName = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox ,click on Context menu     
                _inboxAction.ClickContextMenuOfRespectedIndox(inboxName,"Label Printing");
                WaitForMoment(2);

                //Click on Label Printing option
                _timeConfirmationAction.ClickButton("Label Printing");
                WaitForMoment(4);

                //Verify Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Options in the Label Printing Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_277170.csv", "Manufacturing_277170#csv", DataAccessMethod.Sequential)]

        public void TC_277170_LabelPrintingOptionsInThePageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Verify the respected select label is present  
                _labelPrintingAction.VerifyLabelPrintingOptions("Weightment Label (90mm x 40mm)", 1);
                _labelPrintingAction.VerifyLabelPrintingOptions("Cart Label (90mm x 40mm)", 2);
                _labelPrintingAction.VerifyLabelPrintingOptions("Material Transfer Label (80mm x 90mm)", 3);
                _labelPrintingAction.VerifyLabelPrintingOptions("Process Label (90mm x 40mm)", 4);
                _labelPrintingAction.VerifyLabelPrintingOptions("Steribag Label - SCP (110mm x 90mm)", 5);
                _labelPrintingAction.VerifyLabelPrintingOptions("Tailgate/Sample Label (154mm x 50mm)", 6);
                _labelPrintingAction.VerifyLabelPrintingOptions("Post Wash Label (154mm x 50mm)", 7);
                _labelPrintingAction.VerifyLabelPrintingOptions("Inner/Outer Bag Labels (90mm x 40mm)", 8);

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Process Label(90mmx40mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279545.csv", "Manufacturing_279545#csv", DataAccessMethod.Sequential)]
        public void TC_279545_VerifyProcessLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string workCenterValue = this.TestContext.DataRow["workCenterValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Choose Process Label(90mmx40mm)
                _labelPrintingAction.SelectLabel("Process Label (90mm x 40mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                _labelPrintingAction.EnterWorkCenterValuelInTextBox(workCenterValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Weighment Label(90mmx40mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279422.csv", "Manufacturing_279422#csv", DataAccessMethod.Sequential)]

        public void TC_279422_VerifyWeighmentLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Choose Weighment Label(90mmx40mm)
                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Steribag Label(110mmx90mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279550.csv", "Manufacturing_279550#csv", DataAccessMethod.Sequential)]

        public void TC_279550_VerifyingSteribagLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string workCenterValue = this.TestContext.DataRow["workCenterValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Steribag Label(110mmx90mm)
                _labelPrintingAction.SelectLabel("Steribag Label - SCP (110mm x 90mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                _labelPrintingAction.EnterWorkCenterValuelInTextBox(workCenterValue);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Material Transfer Label(150mmx100mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279544.csv", "Manufacturing_279544#csv", DataAccessMethod.Sequential)]

        public void TC_279544_VerifyingMaterialTransferTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string workCenterValue = this.TestContext.DataRow["workCenterValue"].ToString();
                string quantityValue = this.TestContext.DataRow["quantityValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Material Transfer Label(150mmx100mm)
                _labelPrintingAction.SelectLabel("Material Transfer Label (80mm x 90mm)");

                //Enter/select the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Material");
                _labelPrintingAction.EnterWorkCenterValuelInTextBox(workCenterValue);
                _labelPrintingAction.EnterQuantityTextBox(quantityValue);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Feedback icon should be present in all pages of Label printing;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_250509.csv", "Manufacturing_250509#csv", DataAccessMethod.Sequential)]

        public void TC_250509_VerifyFeedbackLabelPrintingTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                string feedbackDetails = string.Empty;
                feedbackDetails = $"Test Feedback details submitting on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");


                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose any of the 4 radio button and click on next.

                //The opened page should have feedback button at the right top.
                WaitForMoment(2);
                _feedbackAction.ClickOnFeedbackIcon();
                _feedbackAction.SelectRating(4);
                _feedbackAction.EnterFeedbackTitle("Testing Feedback from Automation");
                _feedbackAction.EnterFeedbackDetails(feedbackDetails);
                _feedbackAction.SelectUserConsent();
                _feedbackAction.ClickOnSubmitButton();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Invalid Material;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279560.csv", "Manufacturing_279560#csv", DataAccessMethod.Sequential)]

        public void TC_279560_VerifyingInvalidMaterial()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Weighment Label(90mmx40mm)
                //Enter the valid data in to all fields 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");

                //try to enter invalid data into Material Field
                //Ex:-789065
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Error Pop-up Message should be display > Invalid Material
                WaitForMoment(2);
                _labelPrintingAction.VerifyErrorPopUp("Error", "Invalid Material");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Invalid-Number of Labels field;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_281564.csv", "Manufacturing_281564#csv", DataAccessMethod.Sequential)]

        public void TC_281564_VerifyingInvalidNoLabelsFieldTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Try to select any Label below

                //Enter the valid data in to all fields 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");

                //Try to Invalid data into Number of Labels Field EX:= -5,0,RTY
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Print  Preview  and Print button should not be enabled
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                _labelPrintingAction.EnterNoOfLabelInTextBox("5");
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Invalid Quantity field;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279722.csv", "Manufacturing_279722#csv", DataAccessMethod.Sequential)]

        public void TC_279722_VerifyingInvalidNoQuantityFieldTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string workCenterValue = this.TestContext.DataRow["workCenterValue"].ToString();
                string quantityValue = this.TestContext.DataRow["quantityValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose below Label "Material Transfer Label (80mm x 90mm)"

                //Choose Material Transfer Label(150mmx100mm)
                _labelPrintingAction.SelectLabel("Material Transfer Label (80mm x 90mm)");

                //Enter valid data into all pickers and Fields and 
                WaitForMoment(1);

                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Material");
                _labelPrintingAction.EnterWorkCenterValuelInTextBox(workCenterValue);

                //Try to enter invalid data into Quantity Field Ex - 0.000 or less than zero
                _labelPrintingAction.EnterQuantityTextBox("-52");
                _labelPrintingAction.EnterPrinterValueFromDropdown("PDFU");

                //Verify : Print and Print Preview button should be in Disable state 
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                _labelPrintingAction.EnterQuantityTextBox("42");
                _labelPrintingAction.EnterPrinterValueFromDropdown("PDFU");
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Reprinting Label;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279422.csv", "Manufacturing_279422#csv", DataAccessMethod.Sequential)]

        public void TC_281553_VerifyingReprintingLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Go to Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //Go to Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Label Printing");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Label Printing Page
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Choose Weighment Label(90mmx40mm)
                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

                //Try to reprint the selected same Label
                _labelPrintingAction.ClckOkPopUP();

                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Weighment");
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Post wash Label(154mmx50mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279558.csv", "Manufacturing_279558#csv", DataAccessMethod.Sequential)]

        public void TC_279558_VerifyingPostWashLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Post Wash Label(154mmx50mm)
                _labelPrintingAction.SelectLabel("Post Wash Label (154mm x 50mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                WaitForMoment(2);

                //click on Print Preview button
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Taligate/Sample Label(154mmx50mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279557.csv", "Manufacturing_279557#csv", DataAccessMethod.Sequential)]

        public void TC_279557_VerifyingTaligateSampleLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string batchValue = this.TestContext.DataRow["batchValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Post Wash Label(154mmx50mm)
                _labelPrintingAction.SelectLabel("Tailgate/Sample Label (154mm x 50mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                WaitForMoment(2);
                _labelPrintingAction.EnterWorkCenterValuelInTextBox("RUBBER PACKAGING, GEB001", "Clear");
                WaitForMoment(2);
                _labelPrintingAction.EnterBatchValuelInTextBox("DI00001351");

                //click on Print Preview button
                WaitForMoment(5);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Mandatory Pickers and Fields in Process Label;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_281555.csv", "Manufacturing_281555#csv", DataAccessMethod.Sequential)]

        public void TC_281555_VerifyingMandatoryFieldsProcessLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string workCenterValue = this.TestContext.DataRow["workCenterValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Process Label(90mmx40mm)
                _labelPrintingAction.SelectLabel("Process Label (90mm x 40mm)");

                //Check of Mandatory Pickers and Fields
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                _labelPrintingAction.EnterWorkCenterValuelInTextBox(workCenterValue);
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(2);
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(true);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(4);
                _labelPrintingAction.VerifyPopUpOpen();
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Mandatory Pickers and Fields in Taligate/Sample Label(154mmx50mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_280517.csv", "Manufacturing_280517#csv", DataAccessMethod.Sequential)]

        public void TC_280517_VerifyingTaligateSampleLabelMandatoryFieldTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string batchValue = this.TestContext.DataRow["batchValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Post Wash Label(154mmx50mm)
                _labelPrintingAction.SelectLabel("Tailgate/Sample Label (154mm x 50mm)");

                //Below Mandatory Fields and Pickers should be display
                // 1.Order
                // 2.Work Center
                // 3.Count
                // 4.Quanitity
                // 5.Printer
                //6.Number of Labels
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(false);

                //Check of Mandatory Pickers and Fields
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                WaitForMoment(2);
                _labelPrintingAction.EnterWorkCenterValuelInTextBox("RUBBER PACKAGING, GEB001", "Clear");
                WaitForMoment(2);
                _labelPrintingAction.EnterBatchValuelInTextBox("DI00001351");

                //click on Print Preview button
                WaitForMoment(5);
                _labelPrintingAction.VerifyPrintButtonEnableOrDisable(true);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Cart Label(90mmx40mm);;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_281520.csv", "Manufacturing_281520#csv", DataAccessMethod.Sequential)]
        public void TC_281520_VerifyingCartLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Choose Cart Label(90mmx40mm)
                _labelPrintingAction.SelectLabel("Cart Label (90mm x 40mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Material");
                WaitForMoment(2);

                //Enter/select the valid data in to all fields and pickers 
                _labelPrintingAction.EnterNoOfLabelInTextBox("5");

                //click on Print Preview button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(2);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Checking order number -Navigating through Details Action;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_285651.csv", "Manufacturing_285651#csv", DataAccessMethod.Sequential)]
        public void TC_285651_VerifyingNavigatingThroughDetailsActionLabelPrintingTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialValue = this.TestContext.DataRow["materialValue"].ToString();
                string noOfLabel = this.TestContext.DataRow["noOfLabel"].ToString();
                string printer = this.TestContext.DataRow["printer"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //>Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //>Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);
                WaitForMoment(2);

                //Select Label Printing Option from Details Action >> (For Particular Order number)                                                                      
                _inboxAction.EnterSearchValue(orderValue);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);
                _labelPrintingAction.ClickOnDetailsAction();
                _inboxAction.ClickOnActionOptions("Label Printing");

                //Verifying Application >>  Label Printing page should be display
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Select any one Label from below
                _labelPrintingAction.EnterMaterialValueInTextBox(materialValue);
                _labelPrintingAction.EnterNoOfLabelInTextBox(noOfLabel);
                _labelPrintingAction.EnterPrinterValueInTextBox(printer);
                WaitForMoment(1);

                //Enter the valid data in to all the pickers and fields then click on Print button
                _labelPrintingAction.ClickPrintButton();
                WaitForMoment(1);
                _labelPrintingAction.ClickPrintButton();

                //Verify Successful pop - up message should be display
                WaitForMoment(2);
                _labelPrintingAction.VerifyPopUpOpen();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("Verifying for Order Picker through Details Action;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_279733.csv", "Manufacturing_279733#csv", DataAccessMethod.Sequential)]
        public void TC_279733_VerifyingOrderDetailsActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //>Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);
                WaitForMoment(2);

                //Select Label Printing Option from Details Action 
                //(For Particular Order number)                                                                      
                // _inboxAction.EnterSearchValue(orderValue);
                _inboxAction.EnterSearchValue("1001476");
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);
                _labelPrintingAction.ClickOnDetailsAction();
                _inboxAction.ClickOnActionOptions("Label Printing");

                //Verifying Application >> Label Printing page should be display
                _labelPrintingAction.VerifyPageTitle("Label Printing");

                //Weighment Label(90mmx40mm)
                _labelPrintingAction.VerifyOrderID(orderValue, "Weighment");

                _labelPrintingAction.SelectLabel("Material Transfer Label (80mm x 90mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Weighment");

                _labelPrintingAction.SelectLabel("Process Label (90mm x 40mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Process");

                _labelPrintingAction.SelectLabel("Steribag Label - SCP (110mm x 90mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Process");

                _labelPrintingAction.SelectLabel("Tailgate/Sample Label (154mm x 50mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Process");

                _labelPrintingAction.SelectLabel("Post Wash Label (154mm x 50mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Process");

                _labelPrintingAction.SelectLabel("Inner/Outer Bag Labels (90mm x 40mm)");
                _labelPrintingAction.VerifyOrderID(orderValue, "Process");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Manufacturing")]
        [Description("UI Design of inner Outer bag Label;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_291105.csv", "Manufacturing_291105#csv", DataAccessMethod.Sequential)]
        [Ignore("This Test case is marked as Hold due to Bug in the functionality")]
        public void TC_291105_VerifyingInnerOuterBagLabelTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Navigate to Label Printing Page
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");

                //Select Label > inner/Outer bag Label under     
                _labelPrintingAction.SelectLabel("Inner/Outer Bag Labels (90mm x 40mm)");

                //Enter the valid data in to all fields and pickers 
                _labelPrintingAction.EnterOrderValueInTextBox(orderValue, "Process");
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region Time Confirmation
        #region TestMethods
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verifying for PO-Time Confirmation Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291071.csv", "TimeConfirmation_291071#csv", DataAccessMethod.Sequential)]
        public void TC_291071_POTimeConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for Next and Recent Confirmation button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291075.csv", "TimeConfirmation_291075#csv", DataAccessMethod.Sequential)]
        public void TC_291075_VerifyNextAndRecentConfirmationButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Check for  RECENT CONFIRMATIONS and NEXT Button        
                //Verify > Both the Buttons should be enabled
                _timeConfirmationAction.VerifyButtonEnableOrDisable("RecentConfirmations", true);
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for Next button Functionality;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291078.csv", "TimeConfirmation_291078#csv", DataAccessMethod.Sequential)]
        public void TC_291078_VerifyNextButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                List<string> fields = this.TestContext.DataRow["fields"].ToString().Split(',').ToList();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                WaitForMoment(1);
                _timeConfirmationAction.VerifyPageTextTimeConfirmation(fields[0], fields[1], fields[2]);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for RECENT COFIRMATIONS button Functionality;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291080.csv", "TimeConfirmation_291080#csv", DataAccessMethod.Sequential)]
        public void TC_291080_VerifyRecentConfirmationsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on RECENT CONFIRMATIONS Button                                                                                                               
                //1.User should able to click on RECENT CONFIRMATONS button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("RECENT CONFIRMATIONS", true);
                _timeConfirmationAction.ClickRecentConfirmationButton();
                WaitForMoment(1);

                //2.Application should navigate to RECENT CONFIRMATIONS Page
                _labelPrintingAction.VerifyPageTitle("Recent Confirmations");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for Recent Confirmations page columns;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291079.csv", "TimeConfirmation_291079#csv", DataAccessMethod.Sequential)]
        public void TC_291079_VerifyRecentConfirmationPageColumnsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                List<string> columns = this.TestContext.DataRow["columns"].ToString().Split(',').ToList();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on RECENT CONFIRMATIONS Button                                                                                                               
                //1.Application should navigate to RECENT CONFIRMATIONS Page
                _timeConfirmationAction.VerifyButtonEnableOrDisable("RECENT CONFIRMATIONS", true);
                _timeConfirmationAction.ClickRecentConfirmationButton();
                WaitForMoment(1);
                _labelPrintingAction.VerifyPageTitle("Recent Confirmations");

                //Verify Coloum fields
                //->Activity
                //->Yield
                //->Scrap
                //->Confirmation Type
                //->Confirmed By
                //->Confirmation Date
                //->Cancellation Text
                foreach (var column in columns)
                {
                    _timeConfirmationAction.VerifyPageText(column);

                }

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verifying for Partial Confirmation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291089.csv", "TimeConfirmation_291089#csv", DataAccessMethod.Sequential)]
        public void TC_291089_VerifyPartialConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                _timeConfirmationAction.EnterFields("Yeild", "2");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                _timeConfirmationAction.EnterFields("Yeild", "2");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Enter Batch ID
                //_timeConfirmationAction.EnterBatch("Goods Movement", batchId);

                //Due to data Depenency Click on Clear Bath for Process Order
                _timeConfirmationAction.ClickButton("Clear");
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton("YES");
                WaitForMoment(2);

                //Click on CONFIRM
                _timeConfirmationAction.ClickButton(ButtonActionOptions.CONFIRM.ToString());

                //Select Partial Confirmation
                //Click on CONFIRM
                _timeConfirmationAction.ConfirmOrder("Partial Confirmation", ButtonActionOptions.Confirm.ToString());

                //Proper error pop message should be display 
                WaitForMoment(3);
                _labelPrintingAction.VerifyErrorPopUp("Error", "Overdelivery is not permitted (Check entry)");
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton("OK");
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verifying for Final Confirmation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291895.csv", "TimeConfirmation_291895#csv", DataAccessMethod.Sequential)]
        public void TC_291895_VerifyFinalConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");

                //Click on NEXT button
                WaitForMoment(4);
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Enter Batch ID
                _timeConfirmationAction.EnterBatch("Goods Movement", batchId);

                //Click on CONFIRM
                _timeConfirmationAction.ClickButton(ButtonActionOptions.CONFIRM.ToString());

                //Select Final Confirmation
                //Click on CONFIRM
                _timeConfirmationAction.ConfirmOrder("Final Confirmation", ButtonActionOptions.Confirm.ToString());

                //Proper error pop message should be display 
                WaitForMoment(2);
                _labelPrintingAction.VerifyErrorPopUp("Error", "Overdelivery is not permitted (Check entry)");
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verifying the Edit Component for Split batch;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_296153.csv", "TimeConfirmation_296153#csv", DataAccessMethod.Sequential)]
        public void TC_296153_VerifyEditComponentSplitBatchTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Verify : Goods Movement Page should open
                _labelPrintingAction.VerifyPageTitle("Goods Movement (" + orderValue + ")");

                //Select or Enter batch id from the drop down
                _timeConfirmationAction.EnterBatch("Goods Movement", batchId);
                WaitForMoment(2);

                //Click Split Batch
                _timeConfirmationAction.ClickSplitBatch();

                //Edit the quantity 
                _timeConfirmationAction.EnterFields("Quantity", "24");
                WaitForMoment(1);

                //Click on Save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.SAVE.ToString());
                WaitForMoment(2);

                //Click on Yes
                _inboxChartsAction.ClickOnYes();
                _inboxAction.WaitForLoadingToDisappear();

                //Verify the edited quantity will reflected on the material Grid 
                //It should match the edited quantity 
                _timeConfirmationAction.VerifyEditedQuantity("24.0000");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify the delete component functionality of Split batch;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_299366.csv", "TimeConfirmation_299366#csv", DataAccessMethod.Sequential)]
        public void TC_299366_VerifyDeleteComponentSplitBatchTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();
                string batchEditId = this.TestContext.DataRow["batchEditId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Verify : Goods Movement Page should open
                _labelPrintingAction.VerifyPageTitle("Goods Movement (" + orderValue + ")");

                //Select or Enter batch id from the drop down
                _timeConfirmationAction.EnterBatch("Goods Movement", batchId);

                //Click Split Batch
                _timeConfirmationAction.ClickSplitBatch();
                WaitForMoment(2);

                //Click on edit button in split batch and try to delete any of the component
                _timeConfirmationAction.ClickAddBatch();
                WaitForMoment(1);
                _timeConfirmationAction.DeleteSplitBatch(1);
                WaitForMoment(1);

                //Edit the quantity and Batch
                _timeConfirmationAction.EnterFields("Quantity", "24");
                WaitForMoment(1);
                _timeConfirmationAction.EnterBatch(ButtonActionOptions.Edit.ToString(), batchEditId);

                //Click on Save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.SAVE.ToString());
                WaitForMoment(3);

                //Click on Yes
                _inboxChartsAction.ClickOnYes();
                _inboxAction.WaitForLoadingToDisappear();

                //Verify the edited quantity will reflected on the material Grid 
                //It should match the edited quantity 
                _timeConfirmationAction.VerifyEditedQuantity("24.0000");
                _timeConfirmationAction.VerifyBatchId(batchEditId);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Changes in Process order Time confirmation Dates;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_257564.csv", "TimeConfirmation_257564#csv", DataAccessMethod.Sequential)]
        public void TC_257564_VerifyChangeInProcessOrderDatesTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //start date entry should not greater than the finish date               
                _timeConfirmationAction.ClickButton("Start Date");

                //Select Start Date as Todays Date or any date which is greater than the finish date
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Today.ToString());
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(1);
                _labelPrintingAction.VerifyErrorPopUp("Attention", "End Date should not be before start date");
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify Reason For Variance Generic Picker functionality;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_62518.csv", "TimeConfirmation_62518#csv", DataAccessMethod.Sequential)]
        public void TC_262518_VerifyReasonForVarianceGenericPickerFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string reasonForVarianceCode = this.TestContext.DataRow["reasonForVarianceCode"].ToString();
                string reasonForVarianceDescription = this.TestContext.DataRow["reasonForVarianceDescription"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();

                //Click on the  Reason for Variance select icon 
                _timeConfirmationAction.ClickReasonforVariancePicker();

                //Search for Reason for Variance Code and verify
                _timeConfirmationAction.SearchReasonforVarianceAndVerify(reasonForVarianceCode);

                //Search for Reason for Variance discription and verify
                _timeConfirmationAction.SearchReasonforVarianceAndVerify("Expired date");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Maximum digits allowed for yield and scrap;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_62518.csv", "TimeConfirmation_62518#csv", DataAccessMethod.Sequential)]
        [Ignore("This Test case is marked as Hold due to Bug in the functionality")]
        public void TC_267057_VerifyInputFieldForYieldAndScrapTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string reasonForVarianceCode = this.TestContext.DataRow["reasonForVarianceCode"].ToString();
                string reasonForVarianceDescription = this.TestContext.DataRow["reasonForVarianceDescription"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter10 digits Yield and Scrap 
                //Rework. But the maximum allowed is 999,999,999. 
                _timeConfirmationAction.EnterFields("Yeild", "9999999999");
                _timeConfirmationAction.EnterFields("Scrap", "9999999999");
                _inboxAction.WaitForLoadingToDisappear();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Date should be reflected as per the localized system date;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_271370.csv", "TimeConfirmation_271370#csv", DataAccessMethod.Sequential)]
        public void TC_271370_VerifyResourcesDateLocalizedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Click on Edit icon of any of Time Confirmation cards > Click Start date
                _timeConfirmationAction.ClickButton("Start Date");

                //Select Start Date as Todays Date 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Today.ToString());
                WaitForMoment(2);

                //Verif The note that comes below the date control should be localized.
                _timeConfirmationAction.VerifyNoteText("Note: Today's Date & Time are based on your SAP Time Zone(EST)");
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify Scrap Value should be updated if already time confirmation has been performed.;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_261019.csv", "TimeConfirmation_261019#csv", DataAccessMethod.Sequential)]
        public void TC_261019_VerifyScrapValueUpdatedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.VerifyTmInputValues("KG");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify recent confirmation change date field with respect to the order confirmation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_291119.csv", "TimeConfirmation_291119#csv", DataAccessMethod.Sequential)]
        public void TC_291119_VerifyRecentConfirmationChangeDateFieldTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");

                //Click on NEXT button
                WaitForMoment(4);
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Click on Confirm
                _timeConfirmationAction.ClickButton(ButtonActionOptions.CONFIRM.ToString());

                //Select Final Confirmation or Partial Confirmation
                //Click on CONFIRM
                _timeConfirmationAction.ConfirmOrder("Partial Confirmation", ButtonActionOptions.Confirm.ToString());

                //Proper error pop message should be display 
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(5);

                //Navigate to the Time Cofirmation page
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Label Printing option
                _inboxAction.ClickOnActionOptions("Time Confirmation");
                WaitForMoment(4);

                //Verifying Application should be navigate to its respected action page
                _labelPrintingAction.VerifyPageTitle("Time Confirmation");

                //Enter > Select the same order Idr in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on Recent Confirmation 
                _timeConfirmationAction.ClickRecentConfirmationButton();
                WaitForMoment(1);
                _labelPrintingAction.VerifyPageTitle("Recent Confirmations");

                //Verify the Confirmation Date with respect to the order id confirmation
                _timeConfirmationAction.VerifyConfirmationDate(" Row2");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify Header message should be present in error popup;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_258068.csv", "TimeConfirmation_258068#csv", DataAccessMethod.Sequential)]
        public void TC_258068_VerifyHeaderErrorMessageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");

                //Click on NEXT button
                //Verify Error pop up message should be present for Production order and no error pop up message for Process order
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                _labelPrintingAction.VerifyErrorPopUp("No Error", "Time Confirmation");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verifying Add Batch error should not come if material is non-batch managed;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_261911.csv", "TimeConfirmation_261911#csv", DataAccessMethod.Sequential)]
        public void TC_261911_VerifyNonBatchManagedMaterialIdTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");

                //Click on NEXT button
                WaitForMoment(4);
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Verify "Add Batch" error should not come if material is non-batch managed.
                _timeConfirmationAction.VerifyBatchMaterialID(" (This is a non batch managed material) ", "Non Batch");
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("TimeConfirmation Material Batch warning;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_301746.csv", "TimeConfirmation_301746#csv", DataAccessMethod.Sequential)]
        public void TC_301746_VerifyTCMaterialBatchWarningTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "2");

                //Click on NEXT button
                WaitForMoment(4);
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                WaitForMoment(4);

                //Verify Time Confirmation Material Batch warning
                _timeConfirmationAction.VerifyBatchMaterialID(" (Please select the batch number.) ", "Batch");
            }

            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking order number -Navigating through Details Action;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_299926.csv", "Manufacturing_299926#csv", DataAccessMethod.Sequential)]
        public void TC_299926_VerifyTCOrderPickerDisableViaDetailsActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //>Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //>Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);
                WaitForMoment(2);

                //Select Time Confirmation Option from Details Action >> (For Particular Order number)                                                                      
                _inboxAction.EnterSearchValue(orderValue);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);
                _labelPrintingAction.ClickOnDetailsAction();
                _inboxAction.ClickOnActionOptions("Time Confirmation");
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Order Picker Disable in Details Action
                _timeConfirmationAction.VerifyOrderNumberField(false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for Goods Issue page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_285609.csv", "GoodsIssue_285609#csv", DataAccessMethod.Sequential)]
        public void TC_285609_VerifyGoodsIssuepageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for ADD  button Functionality Good issue page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286152.csv", "GoodsIssue_286152#csv", DataAccessMethod.Sequential)]
        public void TC_286152_VerifyADDButtonFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string materialDesc = this.TestContext.DataRow["materialDesc"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Remove Material Id
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());

                //Click on Add button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Add.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Enter the valid Material, Quantity, UOM and Batch
                _goodIssueAction.ClickMaterialPicker();
                WaitForMoment(1);
                _timeConfirmationAction.SearchReasonforVarianceAndVerify(materialID);
                WaitForMoment(1);
                _goodIssueAction.ClickMaterialID(materialID);
                WaitForMoment(1);
                _goodIssueAction.RemoveBatch();

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Created Compound 
                _goodIssueAction.VerifyAddedComponent("Component Material");
                _goodIssueAction.VerifyAddedComponent(materialDesc);

                //Verify Default Location
                _goodIssueAction.VerifyAddedComponent("PSWM, Prod Staging Loc");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description(" Verifying for Reload Button functionality Good issue page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_287003.csv", "GoodsIssue_287003#csv", DataAccessMethod.Sequential)]
        public void TC_287003_VerifyReloadButtonFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Remove Material Id
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());

                //Click on Reload button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Reload.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify > Data should be Reload
                _goodIssueAction.VerifyAddedComponent("Component Material");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for Goods Issue page from context Menu action;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_287347.csv", "GoodsIssue_287347#csv", DataAccessMethod.Sequential)]
        public void TC_287347_VerifyGoodsIssueContextMenuActionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function
                _homeAction.ClickOnFunction(function);

                //>Process Orders Management Persona
                _homeAction.ClickOnPersona(persona);

                //>Process Orders Inbox
                _inboxAction.ClickInbox(inboxNames);
                WaitForMoment(2);

                //Select Goods Issue  Option from Details Action >> (For Particular Order number)                                                                      
                _inboxAction.EnterSearchValue(orderValue);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);
                _labelPrintingAction.ClickOnDetailsAction();
                _inboxAction.ClickOnActionOptions("Goods Issue");
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Goods Issue page is display
                _labelPrintingAction.VerifyPageTitle("Goods Issue");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Checking for success Message after clicking Post button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286759.csv", "GoodsIssue_286759#csv", DataAccessMethod.Sequential)]
        public void TC_286759_VerifySuccessMessagePostButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Remove Material Id
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());

                //Click on Reload button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Reload.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify > Data should be Reload
                _goodIssueAction.VerifyAddedComponent("Component Material");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for delete Functionality Goods Issue page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286789.csv", "GoodsIssue_286789#csv", DataAccessMethod.Sequential)]
        public void TC_286789_VerifyDeleteFunctionalityGoodsIssueTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Click on Delete icon in any Component Material 
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());

                //Verify Component Material should deleted from the respective order number
                _goodIssueAction.VerifyAddedComponent("");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for Document Date Picker;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_287056.csv", "GoodsIssue_287056#csv", DataAccessMethod.Sequential)]
        public void TC_287056_VerifyDocumentDatePickerTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Check for Document Date Picker and Verifify its Check points
                //1.Document Date Picker should be default Today's Date 
                //2.Document Date picker should able accept Future and Current Date
                //3.Calendar icon on the picker
                //4.Calendar should be visible
                _goodIssueAction.VerifyDocumentDate("DocumentatonDate");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for Posting Date Picker;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_287057.csv", "GoodsIssue_287057#csv", DataAccessMethod.Sequential)]
        public void TC_287057_VerifyPostingDatePickerTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Check for Document Date Picker and Verifify its Check points
                //1.Posting Date Picker should be default Today's Date 
                //2.Posting should not accept Future and Previous date
                //3.Proper error message should be display at bottom Posting Date Picker in red color            
                _goodIssueAction.VerifPostingDate("PostingDate", "Please choose date within the 30 days limit", "You cannot post for a future date");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Checking Functionality of Assign a Batch link ;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286752.csv", "GoodsIssue_286752#csv", DataAccessMethod.Sequential)]
        public void TC_286752_VerifyAssignBatchLinkFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Click on Assign a Batch link
                _timeConfirmationAction.ClickButton("Assign a batch");

                WaitForMoment(2);

                //Try to enter valid data into Quantity and Batch field
                _goodIssueAction.EnterValue(qty);
                _goodIssueAction.EnterBatch(batchId);

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //1.Verify Page should Navigate to back to Goods issue
                _labelPrintingAction.VerifyPageTitle("Goods Issue");

                //2.Verify Check weather recently added batch should be present under respective component
                _goodIssueAction.VerifyAddedComponent("3 EA");
                _goodIssueAction.VerifyAddedComponent("DI00001663, 3 EA");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Checking for Non Assign a Batch link Color;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286744.csv", "GoodsIssue_286744#csv", DataAccessMethod.Sequential)]
        public void TC_286744_VerifyNonAssignBatchLinkFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify :In the component material cart > Non Batch Managed should be present 
                _goodIssueAction.VerifyAddedComponent("Non Batch Managed");

                //Click on Non Batch Managed 
                _timeConfirmationAction.ClickButton("Non Batch Managed");
                WaitForMoment(2);

                //Verify Page should navigate to Goods Issue edit component 
                _labelPrintingAction.VerifyPageTitle("Goods Issue - Edit Component");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Verifying for respective component Material should be display after entering/Selecting the Proper order number;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_286147.csv", "GoodsIssue_286147#csv", DataAccessMethod.Sequential)]
        public void TC_286147_VerifycomponentMaterialDetailsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify > 1.Respective order component materials  should be display
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //2.Document Date and Posting Date field
                _goodIssueAction.VerifyAddedComponent("Document Date");
                _goodIssueAction.VerifyAddedComponent("Posting Date");

                //3.Add and Reload Button should be Enable
                _goodIssueAction.VerifyButtonEnableOrDisable("Reload", true);
                _goodIssueAction.VerifyButtonEnableOrDisable("Add", true);

                //4.Post button should be disable
                _goodIssueAction.VerifyButtonEnableOrDisable("Post", false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("PO Good Issue Adding Multiple batch Application should not crash;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_287021.csv", "GoodsIssue_287021#csv", DataAccessMethod.Sequential)]
        public void TC_287021_VerifyAddingMultipleBatchTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Click on Assign a Batch link
                _timeConfirmationAction.ClickButton("Assign a batch", 2);
                WaitForMoment(2);

                //Enter valid data into Quantity and Batch field
                //Click on Plus mark on Right hand side corner

                for (int i = 0; i < 8; i++)
                {
                    _goodIssueAction.EnterValue(qty);
                    _goodIssueAction.EnterBatch(batchId);
                    WaitForMoment(1);
                    _goodIssueAction.FetchList(0);
                    WaitForMoment(1);

                    if (i < 7)
                    {
                        _goodIssueAction.AddBatch();
                        WaitForMoment(1);
                    }
                }

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Page should Navigate to back to Goods issue and application should be crash
                _labelPrintingAction.VerifyPageTitle("Goods Issue");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("In Good Issue - Adding Multiple batch and Quantity it should reflect as a Sum in the Component Material;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_328488.csv", "GoodsIssue_328488#csv", DataAccessMethod.Sequential)]
        public void TC_328488_VerifyAddingMultiplQuantityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string qty2 = this.TestContext.DataRow["qty2"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();
                string batchId2 = this.TestContext.DataRow["batchId2"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Click on Assign a Batch link
                _timeConfirmationAction.ClickButton("Assign a batch");
                WaitForMoment(2);

                //Enter valid data into Quantity and Batch field
                _goodIssueAction.EnterValue(qty);
                _goodIssueAction.EnterBatch(batchId);

                //Click on Plus mark on Right hand side corner
                _goodIssueAction.AddBatch();

                //Enter valid data into Quantity and Batch field in the new Field
                _goodIssueAction.EnterValue(qty2);
                _goodIssueAction.EnterBatch(batchId2);

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Page should Navigate to back to Goods issue page
                _labelPrintingAction.VerifyPageTitle("Goods Issue");

                //All the Qty Should be addes and display in the Component 
                _goodIssueAction.VerifyAddedComponent("7 EA");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssue")]
        [Description("Good Issue : Changing UON while creating the component it should reflect in the component material cart ;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_328488.csv", "GoodsIssue_328488#csv", DataAccessMethod.Sequential)]
        public void TC_329445_VerifyUONTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Degault UON
                _goodIssueAction.VerifyAddedComponent("0 EA");

                //Click on any Component Material
                _timeConfirmationAction.ClickButton("Assign a batch");
                WaitForMoment(2);

                //Change the UON for the dropdown 
                _goodIssueAction.SelectUNO();

                //Enter valid data into Quantity and Batch field
                _goodIssueAction.EnterValue(qty);
                _goodIssueAction.EnterBatch(batchId);

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Page should Navigate to back to Goods issue page
                _labelPrintingAction.VerifyPageTitle("Goods Issue");

                //Verify : > Details should be reflected as per the selected UON
                _goodIssueAction.VerifyAddedComponent("3 PC");
                _goodIssueAction.VerifyAddedComponent("0 PC");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [TestCategory("GoodsIssue")]
        [Description("Goods Issue in WD App;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssue_253005.csv", "GoodsIssue_253005#csv", DataAccessMethod.Sequential)]
        public void TC_253005_VerifyGoodsIssueSmokeTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string materialID = this.TestContext.DataRow["materialID"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string qty2 = this.TestContext.DataRow["qty2"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();
                string batchId2 = this.TestContext.DataRow["batchId2"].ToString();

                //Navigation in WD application: Manufacturing>Order Management>Manufacturing Order
                //Click on master action and Select Goods Issue from that
                //Click on Goods issue 
                //Verify: > Will be navigated to the Goods Issue screen.
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue");

                //Either enter the value in the Process order picker or you can type in in the picker. 
                // Select the value in the search list.
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(1);

                //Verify : > Information on each card is seen.
                //-->  Available stock
                _goodIssueAction.VerifyAddedComponent("Available Stock");

                //-->  Requirement Qty.
                _goodIssueAction.VerifyAddedComponent("Requirement Qty.");

                //-->  Remaining Qty.
                _goodIssueAction.VerifyAddedComponent("Remaining Qty.");

                //--> Batch , Qty
                _goodIssueAction.VerifyAddedComponent("Batch Qty.");

                //--> Issuing Qty.
                _goodIssueAction.VerifyAddedComponent("Issuing Qty.");

                //--> Issued Qty.
                _goodIssueAction.VerifyAddedComponent("Issued Qty.");

                //--> Storage Location
                _goodIssueAction.VerifyAddedComponent("Storage Location");
                WaitForMoment(1);

                //Edit Component:--> Click on any Component Material
                _timeConfirmationAction.ClickButton("Assign a batch");
                WaitForMoment(2);

                //Verify Quantity Field 
                _goodIssueAction.VerifyAddedComponent("Quantity");

                //Verify Batch Field 
                _goodIssueAction.VerifyAddedComponent("Batch");

                //Veify UOM, by default set to base unit of measure
                _goodIssueAction.VerifyAddedComponent("UOM");
              
                //Add Multiple Batches: Click on add symbol to add
                _goodIssueAction.EnterValue(qty);
                _goodIssueAction.EnterBatch(batchId);
                WaitForMoment(1);
                _goodIssueAction.AddBatch();
                WaitForMoment(1);
                _goodIssueAction.EnterValue(qty2);
                _goodIssueAction.EnterBatch(batchId2);

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Add Component:Click on Add Button to add new component to the existing list.
                //Remove Material Id
                //Verify:>  Delete the component from the screen
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());

                _timeConfirmationAction.ClickButton(ButtonActionOptions.Add.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Page should navigate to Goods Issue Add component 
                _labelPrintingAction.VerifyPageTitle("Goods Issue - Add Component");

                //Enter the valid Material, Quantity, UOM and Batch
                //Verify > Batch input is visible on the screen based on the choices made.
                _goodIssueAction.ClickMaterialPicker();
                WaitForMoment(2);
                _goodIssueAction.ClickMaterialID(materialID);
                WaitForMoment(1);

                //Verify Remove Batch
                _goodIssueAction.RemoveBatch();

                //Click on save button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Save.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify Created Compound 
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Verify Reload the selection
                _goodIssueAction.RemoveDeleteMaterial(ButtonActionOptions.Yes.ToString());
                _timeConfirmationAction.ClickButton(ButtonActionOptions.Reload.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify > Data should be Reload
                _goodIssueAction.VerifyAddedComponent("Component Material");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region Cancle Time Confirmation
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Verifying for PO- Cancel Time Confirmation Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_331680.csv", "CancelTimeConfirmation_331680#csv", DataAccessMethod.Sequential)]
        public void TC_331680_POCancelTimeConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Verify Select Order and Operation Number in Cancel Time Confirmation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_331688.csv", "CancelTimeConfirmation_331688#csv", DataAccessMethod.Sequential)]
        public void TC_331688_CancelTimeConfirmationOrderAndOperationNumberTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Cancel Time Confirmation : Verify respected column field should display when a User Enters Oder Number / Operation Lan Number and click on Next button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_332257.csv", "CancelTimeConfirmation_332257#csv", DataAccessMethod.Sequential)]
        public void TC_332257_CancelTimeConfirmationColumnFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Verify table displayed filed >  Respected column should be present
                WaitForMoment(2);

                //1.Activity
                _timeConfirmationAction.VerifyTimeComfirmation("Activity");

                //2.Yield
                _timeConfirmationAction.VerifyTimeComfirmation("Yield");

                //3.Scrap
                _timeConfirmationAction.VerifyTimeComfirmation("Scrap");

                //4.Rework
                _timeConfirmationAction.VerifyTimeComfirmation("Rework");

                //5.UOM
                _timeConfirmationAction.VerifyTimeComfirmation("UoM");

                //6.Confirmation Date
                _timeConfirmationAction.VerifyTimeComfirmation("Confirmation Date");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Verify Comment Box of Cancel time confirmation ;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_333019.csv", "CancelTimeConfirmation_333019#csv", DataAccessMethod.Sequential)]
        public void TC_333019_CancelTimeConfirmationCommentBoxTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", "0021, CQ FINA");

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Click on the any of the Row with details in it 
                _timeConfirmationAction.ClickButton("RowData Row1");
                WaitForMoment(2);

                //Verify text displaying in the comment pop up 
                _timeConfirmationAction.VerifyTimeComfirmation("Are you sure you want to perform cancel time confirmation ?");

                //Verify the buttons on the comment pop up
                _timeConfirmationAction.VerifyTimeComfirmation("Cancel");
                _timeConfirmationAction.VerifyTimeComfirmation("Confirm");

                //1.Cancel : Screen goes back to Cancel time confirmation page
                _timeConfirmationAction.ClickButton("Cancel");
                WaitForMoment(2);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Verify Comment Box of Cancel time confirmation ;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_332286.csv", "CancelTimeConfirmation_332286#csv", DataAccessMethod.Sequential)]
        public void TC_332286_CancelTimeConfirmationoperationLanNumberDetailsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify operation /Lan number
                _timeConfirmationAction.VerifyTimeComfirmation(orderValue);
                _timeConfirmationAction.VerifyTimeComfirmation(operationValue);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Cancel Time for PO in WD App;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_253080.csv", "CancelTimeConfirmation_253080#csv", DataAccessMethod.Sequential)]
        public void TC_253080_SmokeTestCancelTimeConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", "0021, CQ FINA");

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify operation /Lan number
                _timeConfirmationAction.VerifyTimeComfirmation(orderValue);
                _timeConfirmationAction.VerifyTimeComfirmation(operationValue);

                //Click on the any of the Row with details in it 
                _timeConfirmationAction.ClickButton("RowData Row1");
                WaitForMoment(2);

                //Verify text displaying in the comment pop up 
                _timeConfirmationAction.VerifyTimeComfirmation("Are you sure you want to perform cancel time confirmation ?");

                //Verify the buttons on the comment pop up
                _timeConfirmationAction.VerifyTimeComfirmation("Cancel");
                _timeConfirmationAction.VerifyTimeComfirmation("Confirm");

                //1.Cancel : Screen goes back to Cancel time confirmation page
                _timeConfirmationAction.ClickButton("Cancel");
                WaitForMoment(2);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Cancel time confirmation header message localized;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CancelTimeConfirmation_261631.csv", "CancelTimeConfirmation_261631#csv", DataAccessMethod.Sequential)]
        public void TC_261631_HeaderMessageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify operation /Lan number
                _timeConfirmationAction.VerifyTimeComfirmation(orderValue);
                _timeConfirmationAction.VerifyTimeComfirmation(operationValue);

                //Click on the any of the Row with details in it 
                _timeConfirmationAction.ClickButton("RowData Row1");
                WaitForMoment(2);

                //Verify text displaying in the comment pop up 
                _timeConfirmationAction.VerifyTimeComfirmation("Are you sure you want to perform cancel time confirmation ?");

                //Verify the buttons on the comment pop up
                _timeConfirmationAction.VerifyTimeComfirmation("Cancel");
                _timeConfirmationAction.VerifyTimeComfirmation("Confirm");

                //Enter comments 
                _timeConfirmationAction.EnterComments(orderValue);
                WaitForMoment(1);

                ///Click on Confirm
                _timeConfirmationAction.ClickButton("Confirm");
                WaitForMoment(2);

                //Verify success message popup.
                _timeConfirmationAction.VerifyTimeComfirmation("Success");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region PM_Actions

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_340445.csv", "CreateMaintenance_340445#csv", DataAccessMethod.Sequential)]
        public void TC_340445_CreateMaintenanceTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order Page Pre populated fields;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_340520.csv", "CreateMaintenance_340520#csv", DataAccessMethod.Sequential)]
        public void TC_340520_CreateMaintenanceOrderPrePopulatedFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
                WaitForMoment(2);

                //Verify field in the Create Maintenance Order Page
                _createMaintenanceAction.VerifyField("Reference Object");
                _createMaintenanceAction.VerifyField("Order Type");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Equipment");
                _createMaintenanceAction.VerifyField("Functional Location");
                _createMaintenanceAction.VerifyField("Planning Plant");
                _createMaintenanceAction.VerifyField("Work Center");
                _createMaintenanceAction.VerifyField("Business Area");
                _createMaintenanceAction.VerifyField("Order Description");
                _createMaintenanceAction.VerifyField("WBS Element");
                _createMaintenanceAction.VerifyField("Customer");
                _createMaintenanceAction.VerifyField("Dates & Priority");
                _createMaintenanceAction.VerifyField("Start Date");
                _createMaintenanceAction.VerifyField("Finish Date");
                _createMaintenanceAction.VerifyField("Priority");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order Page Pre populated fields with Respect to reference notification number;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_359483.csv", "CreateMaintenance_359483#csv", DataAccessMethod.Sequential)]
        public void TC_359483_CreateMaintenanceOrderRefrenceNotificationPrePopulatedFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string referenceNo = this.TestContext.DataRow["referenceNo"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
                WaitForMoment(2);

                //Click on Create with reference notification check box.
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                _createMaintenanceAction.VerifyField("Notification Number");

                //Enter Notification reference number 
                _createMaintenanceAction.EnterRefrenceNumber("Notification Number", referenceNo);

                //Verify field in the Create Maintenance Order Page
                _createMaintenanceAction.VerifyField("Reference Object");
                _createMaintenanceAction.VerifyField("Order Type");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Equipment");
                _createMaintenanceAction.VerifyField("Functional Location");
                _createMaintenanceAction.VerifyField("Planning Plant");
                _createMaintenanceAction.VerifyField("Work Center");
                _createMaintenanceAction.VerifyField("Business Area");
                _createMaintenanceAction.VerifyField("Order Description");
                _createMaintenanceAction.VerifyField("WBS Element");
                _createMaintenanceAction.VerifyField("Customer");
                _createMaintenanceAction.VerifyField("Dates & Priority");
                _createMaintenanceAction.VerifyField("Start Date");
                _createMaintenanceAction.VerifyField("Finish Date");
                _createMaintenanceAction.VerifyField("Priority");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order > Operations Page +Add Operation Pop up;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_363703.csv", "CreateMaintenance_363703#csv", DataAccessMethod.Sequential)]
        public void TC_363703_VerifyOperationsPageAddOperationPopUpTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string referenceNo = this.TestContext.DataRow["referenceNo"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
                WaitForMoment(2);

                //Click on Create with reference notification check box.
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                _createMaintenanceAction.VerifyField("Notification Number");

                //Enter Notification reference number 
                _createMaintenanceAction.EnterRefrenceNumber("Notification Number", referenceNo);
                WaitForMoment(2);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Click +Add
                _timeConfirmationAction.ClickButton("Add");
                WaitForMoment(2);

                //Verify Add Operation Pop up and Feilds
                _createMaintenanceAction.VerifyField("Add Operation");
                _createMaintenanceAction.VerifyField("Control Key");
                _createMaintenanceAction.VerifyField("Operation Description");
                _createMaintenanceAction.VerifyField("Work Involved for Activity");
                _createMaintenanceAction.VerifyField("Unit of Work");
                _createMaintenanceAction.VerifyField("Number of Capacity");
                _createMaintenanceAction.VerifyField("Person Responsible");
                _createMaintenanceAction.VerifyField("Description");

                //Verify Buttons
                _createMaintenanceAction.VerifyField("Cancel");
                _createMaintenanceAction.VerifyField("Submit");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order +Add Component Pop up;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_369211.csv", "CreateMaintenance_369211#csv", DataAccessMethod.Sequential)]
        public void TC_369211_VerifyOperationsPageAddComponentPopUpTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string referenceNo = this.TestContext.DataRow["referenceNo"].ToString();
                string operationDescription = this.TestContext.DataRow["operationDescription"].ToString();
                string work = this.TestContext.DataRow["work"].ToString();
                string capacity = this.TestContext.DataRow["capacity"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
                WaitForMoment(3);

                //Click on Create with reference notification check box.
                _createMaintenanceAction.ClickCheckBox("File");
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(1);
                _createMaintenanceAction.VerifyField("Notification Number");

                //Enter Notification reference number 
                _createMaintenanceAction.EnterRefrenceNumber("Notification Number", referenceNo);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Click +Add
                _timeConfirmationAction.ClickButton("Add");
                WaitForMoment(2);

                //Verify Add Operation Pop up and Feilds
                _createMaintenanceAction.VerifyField("Add Operation");

                //Fill Opereation Fields
                _createMaintenanceAction.EnterField("Operation Description", operationDescription);
                _createMaintenanceAction.EnterField("Work Involved for Activity", work);
                _createMaintenanceAction.EnterField("Number of Capacity", capacity);
                _createMaintenanceAction.EnterField("Description", description);

                //Click Submit
                _timeConfirmationAction.ClickButton("Submit");
                WaitForMoment(2);

                //Verify Created Operations in the Grid
                //Grid Header
                _createMaintenanceAction.VerifyField("Operation");
                _createMaintenanceAction.VerifyField("Control Key");
                _createMaintenanceAction.VerifyField("Work Involved for Activity");
                _createMaintenanceAction.VerifyField("Number of Capacity");
                _createMaintenanceAction.VerifyField("Person Responsible");
                _createMaintenanceAction.VerifyField("Actions");

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Click +Add
                _timeConfirmationAction.ClickButton("Add");
                WaitForMoment(2);

                //Verify Add Component Pop up and Feilds
                _createMaintenanceAction.VerifyField("Add Component");
                _createMaintenanceAction.VerifyField("Component");
                _createMaintenanceAction.VerifyField("Quantity");
                _createMaintenanceAction.VerifyField("Unit of Measure");
                _createMaintenanceAction.VerifyField("Available Quantity");
                _createMaintenanceAction.VerifyField("Storage Location");
                _createMaintenanceAction.VerifyField("Operation Number");

                //Verify Buttons
                _createMaintenanceAction.VerifyField("Cancel");
                _createMaintenanceAction.VerifyField("Submit");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [TestCategory("PMActions")]
        [Description("PM Verify for Create Maintenance Order workflow WD;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateMaintenance_312525.csv", "CreateMaintenance_312525#csv", DataAccessMethod.Sequential)]
        public void TC_312525_Smoke_PMCreateMaintenanceOrderWDTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string referenceNo = this.TestContext.DataRow["referenceNo"].ToString();
                string operationDescription = this.TestContext.DataRow["operationDescription"].ToString();
                string work = this.TestContext.DataRow["work"].ToString();
                string capacity = this.TestContext.DataRow["capacity"].ToString();
                string description = this.TestContext.DataRow["description"].ToString();
                string equipment = this.TestContext.DataRow["equipment"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Create Maintenance Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Maintenance Order");
                WaitForMoment(3);

                //Verify field in the Create Maintenance Order Page
                _createMaintenanceAction.VerifyField("Reference Object");
                _createMaintenanceAction.VerifyField("Order Type");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Create with Reference Notification");
                _createMaintenanceAction.VerifyField("Equipment");
                _createMaintenanceAction.VerifyField("Functional Location");
                _createMaintenanceAction.VerifyField("Planning Plant");
                _createMaintenanceAction.VerifyField("Work Center");
                _createMaintenanceAction.VerifyField("Business Area");
                _createMaintenanceAction.VerifyField("Order Description");
                _createMaintenanceAction.VerifyField("WBS Element");
                _createMaintenanceAction.VerifyField("Customer");
                _createMaintenanceAction.VerifyField("Dates & Priority");
                _createMaintenanceAction.VerifyField("Start Date");
                _createMaintenanceAction.VerifyField("Finish Date");
                _createMaintenanceAction.VerifyField("Priority");

                //Refrence No Test Data is not present so change the flow below code is for future refrence
                ////Click on Create with reference notification check box.
                //_createMaintenanceAction.ClickCheckBox();
                //_inboxAction.WaitForLoadingToDisappear();
                //WaitForMoment(1);
                //_createMaintenanceAction.VerifyField("Notification Number");

                //Enter Notification reference number 
                _createMaintenanceAction.EnterRefrenceNumber("Equipment", equipment);
                WaitForMoment(3);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Click +Add
                _timeConfirmationAction.ClickButton("Add");
                WaitForMoment(2);

                //Verify Add Operation Pop up and Feilds
                _createMaintenanceAction.VerifyField("Add Operation");
                _createMaintenanceAction.VerifyField("Control Key");
                _createMaintenanceAction.VerifyField("Operation Description");
                _createMaintenanceAction.VerifyField("Work Involved for Activity");
                _createMaintenanceAction.VerifyField("Unit of Work");
                _createMaintenanceAction.VerifyField("Number of Capacity");
                _createMaintenanceAction.VerifyField("Person Responsible");
                _createMaintenanceAction.VerifyField("Description");

                //Verify Buttons
                _createMaintenanceAction.VerifyField("Cancel");
                _createMaintenanceAction.VerifyField("Submit");

                //Fill Opereation Fields
                _createMaintenanceAction.EnterField("Operation Description", operationDescription);
                _createMaintenanceAction.EnterField("Work Involved for Activity", work);
                _createMaintenanceAction.EnterField("Number of Capacity", capacity);
                _createMaintenanceAction.EnterField("Description", description);

                //Click Submit
                _timeConfirmationAction.ClickButton("Submit");
                WaitForMoment(2);

                //Verify Created Operations in the Grid
                //Grid Header
                _createMaintenanceAction.VerifyField("Operation");
                _createMaintenanceAction.VerifyField("Control Key");
                _createMaintenanceAction.VerifyField("Work Involved for Activity");
                _createMaintenanceAction.VerifyField("Number of Capacity");
                _createMaintenanceAction.VerifyField("Person Responsible");
                _createMaintenanceAction.VerifyField("Actions");

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Click +Add
                _timeConfirmationAction.ClickButton("Add");
                WaitForMoment(2);

                //Verify Add Component Pop up and Feilds
                _createMaintenanceAction.VerifyField("Add Component");
                _createMaintenanceAction.VerifyField("Component");
                _createMaintenanceAction.VerifyField("Quantity");
                _createMaintenanceAction.VerifyField("Unit of Measure");
                _createMaintenanceAction.VerifyField("Available Quantity");
                _createMaintenanceAction.VerifyField("Storage Location");
                _createMaintenanceAction.VerifyField("Operation Number");

                //Verify Buttons
                _createMaintenanceAction.VerifyField("Cancel");
                _createMaintenanceAction.VerifyField("Submit");

                //Enter Component
                _createMaintenanceAction.EnterRefrenceNumber("Component", "170011514");

                //Enter Quantity
                _createMaintenanceAction.EnterField("Quantity", "5");

                //Click Submit
                _timeConfirmationAction.ClickButton("Submit");
                WaitForMoment(2);

                //Verify Created Operations in the Grid
                //Grid Header
                _createMaintenanceAction.VerifyField("Item Number");
                _createMaintenanceAction.VerifyField("Component");
                _createMaintenanceAction.VerifyField("Operation Number");
                _createMaintenanceAction.VerifyField("Quantity");
                _createMaintenanceAction.VerifyField("Storage Location");
                _createMaintenanceAction.VerifyField("Actions");

                //Click Check Box
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);

                //Click Save
                _timeConfirmationAction.ClickButton("Save");
                WaitForMoment(4);

                //Verify Success
                _createMaintenanceAction.VerifyField("success");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Create Maintenance Order Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateNotification_341284.csv", "CreateNotification_341284#csv", DataAccessMethod.Sequential)]
        public void TC_341284_CreateNotificationPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Notification");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Edit Notification Page details;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateNotification_341323.csv", "CreateNotification_341323#csv", DataAccessMethod.Sequential)]
        public void TC_341323_VerifyNotificationPageDetailsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Notification");
                WaitForMoment(2);

                //Verify Field 
                _createMaintenanceAction.VerifyField("Reference Object");
                _createMaintenanceAction.VerifyField("Notification Type");
                _createMaintenanceAction.VerifyField("Equipment");
                _createMaintenanceAction.VerifyField("Functional Location");
                _createMaintenanceAction.VerifyField("Plant");
                _createMaintenanceAction.VerifyField("Description");
                _createMaintenanceAction.VerifyField("Long Description");

                _createMaintenanceAction.VerifyField("Responsibilities");
                _createMaintenanceAction.VerifyField("Planner Group");
                _createMaintenanceAction.VerifyField("Work Center");

                _createMaintenanceAction.VerifyField("Dates & Priority");
                _createMaintenanceAction.VerifyField("Start Date");
                _createMaintenanceAction.VerifyField("Finish Date");
                _createMaintenanceAction.VerifyField("Priority");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Edit Notification Partner Info page details;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"CreateNotification_341339.csv", "CreateNotification_341339#csv", DataAccessMethod.Sequential)]
        public void TC_341339_VerifyNotificationPartnerInfoTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Notification");
                WaitForMoment(2);

                //Enter Equipment Number
                _createMaintenanceAction.EnterRefrenceNumber("Equipment", "4000001");
                WaitForMoment(3);

                //Enter Descrpition
                _createMaintenanceAction.EnterField("Description", "Automation Description");

                //Enter Long Description
                _createMaintenanceAction.EnterField("Long Description", "Automation Long Description");
                WaitForMoment(1);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Page 
                _createMaintenanceAction.VerifyField("Partners");

                //Click Add Partner
                _timeConfirmationAction.ClickButton("Add Partner");

                //Verify Next button
                _createMaintenanceAction.VerifyField("Next");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Edit Notification details when all the transaction of notification is done;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EditNotification_377630.csv", "EditNotification_377630#csv", DataAccessMethod.Sequential)]
        public void TC_377630_VerifyEditNotificationDetailsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Notification");
                WaitForMoment(2);

                //Enter Equipment Number
                _createMaintenanceAction.EnterRefrenceNumber("Equipment", "4000001");
                WaitForMoment(3);

                //Enter Descrpition
                _createMaintenanceAction.EnterField("Description", "Automation Description");

                //Enter Long Description
                _createMaintenanceAction.EnterField("Long Description", "Automation Long Description");
                WaitForMoment(1);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Page 
                _createMaintenanceAction.VerifyField("Partners");

                //Click Add Partner
                _timeConfirmationAction.ClickButton("Add Partner");

                //Verify Next button
                _createMaintenanceAction.VerifyField("Next");

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Review Page
                _createMaintenanceAction.VerifyField("Notification");

                //Click on Submit
                _timeConfirmationAction.ClickButton("Submit");
                WaitForMoment(4);

                //Verify Success pop up for notification
                _createMaintenanceAction.VerifyField("Success");

                //Note the Created Notification
                string Notification=_createMaintenanceAction.GetCreatedOrder();

                //Click ok 
                WaitForMoment(1);
                _configureProductsAction.ClickOnYesOnConfirmationPopUp();

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Edit Notification option
                _inboxAction.ClickOnActionOptions("Edit Notification");
                WaitForMoment(2);

                //Verifying Application should be navigate to its respected action page
                _labelPrintingAction.VerifyPageTitle("Edit Notification");
                WaitForMoment(3);

                //Enter Created Notification
                _createMaintenanceAction.EnterNotification(Notification);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Click on Next
                _timeConfirmationAction.ClickButton("NEXT");
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("PMActions")]
        [Description("Verify Edit Notification Updated details in the notification page are displayed in the Review Page and transaction should takes place;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"EditNotification_379243.csv", "EditNotification_379243#csv", DataAccessMethod.Sequential)]
        public void TC_379243_VerifyEditNotificationReviewPageDetailsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Create Notification");
                WaitForMoment(2);

                //Enter Equipment Number
                _createMaintenanceAction.EnterRefrenceNumber("Equipment", "4000001");
                WaitForMoment(3);

                //Enter Descrpition
                _createMaintenanceAction.EnterField("Description", "Automation Description");

                //Enter Long Description
                _createMaintenanceAction.EnterField("Long Description", "Automation Long Description");
                WaitForMoment(1);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Page 
                _createMaintenanceAction.VerifyField("Partners");

                //Click Add Partner
                _timeConfirmationAction.ClickButton("Add Partner");

                //Verify Next button
                _createMaintenanceAction.VerifyField("Next");

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Review Page
                _createMaintenanceAction.VerifyField("Notification");

                //Click on Submit
                _timeConfirmationAction.ClickButton("Submit");
                _timeConfirmationAction.ClickButton("OK");
                WaitForMoment(4);

                //Verify Success pop up for notification
                _createMaintenanceAction.VerifyField("Success");

                //Note the Created Notification
                string Notification = _createMaintenanceAction.GetCreatedOrder();

                //Click ok 
                WaitForMoment(1);
                _timeConfirmationAction.ClickButton("OK");

                //Click on Master Action button, on right top corner.
                _inboxAction.ClickOnCreateMasterAction();

                //Click on Edit Notification option
                _inboxAction.ClickOnActionOptions("Edit Notification");
                WaitForMoment(2);

                //Verifying Application should be navigate to its respected action page
                _labelPrintingAction.VerifyPageTitle("Edit Notification");
                WaitForMoment(3);

                //Enter Created Notification
                _createMaintenanceAction.EnterNotification(Notification);
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Click on Next
                _timeConfirmationAction.ClickButton("NEXT");
                WaitForMoment(2);

                //Enter Edit Descrpition
                _createMaintenanceAction.EnterField("Description", "Edit Automation Description");

                //Enter Long Description
                _createMaintenanceAction.EnterField("Long Description", "Edit Automation Long Description");
                WaitForMoment(1);

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Page 
                _createMaintenanceAction.VerifyField("Partners");

                //Click Add Partner
                _timeConfirmationAction.ClickButton("Add Partner");

                //Verify Next button
                _createMaintenanceAction.VerifyField("Next");

                //Click on Next
                _timeConfirmationAction.ClickButton("Next");
                WaitForMoment(2);

                //Verify Review Page
                _createMaintenanceAction.VerifyField("Notification");

                //Verify Edit Description
                _createMaintenanceAction.VerifyField("Edit Automation Description");

                //Verify Long Description
                _createMaintenanceAction.VerifyField("Edit Automation Long Description");

                //Click on Submit
                _timeConfirmationAction.ClickButton("Submit");
                WaitForMoment(4);

                //Verify Success pop up for notification
                _createMaintenanceAction.VerifyField("Success");

                //Note the Created Notification
                string EditedNotification = _createMaintenanceAction.GetCreatedOrder();
                Assert.AreEqual(Notification, EditedNotification);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        //Production Label Print
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("Verify Print bag box Label print;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PPLabelPrint_342751.csv", "PPLabelPrint_342751#csv", DataAccessMethod.Sequential)]
        public void TC_342751_VerifyBagBoxLabelPrintTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");
                WaitForMoment(2);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("Verify Print bag box Label print;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"PPLabelPrint_342815.csv", "PPLabelPrint_342815#csv", DataAccessMethod.Sequential)]
        public void TC_342815_VerifyBagBoxLabelPrintFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Notification Page  Option from Context Menu/Master Action
                //Create Maintenance Page should display
                NavigateToSpecificAction(function, persona, inboxNames, "Label Printing");
                WaitForMoment(2);

                //Verify Bag Box Label Print Fields 
                _createMaintenanceAction.VerifyField("Order");
                _createMaintenanceAction.VerifyField("Label Type");
                _createMaintenanceAction.VerifyField("Bag");
                _createMaintenanceAction.VerifyField("Box");
                _createMaintenanceAction.VerifyField("Number of Labels/GR Quantity");
                _createMaintenanceAction.VerifyField("Number of Labels");
                _createMaintenanceAction.VerifyField("GR Quantity");
                _createMaintenanceAction.VerifyField("Bag Quantity");
                _createMaintenanceAction.VerifyField("Last Bag Number");
                _createMaintenanceAction.VerifyField("Output Device");
                _createMaintenanceAction.VerifyField("Cavity ID");
                _createMaintenanceAction.VerifyField("Cancel");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region Audit
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("CM Site Verify for Audit Report page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380814.csv", "ReprintAudit_380814#csv", DataAccessMethod.Sequential)]
        public void TC_380814_VerifyAuditPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Audit Report
                _timeConfirmationAction.ClickButton("Audit Report");
                _reportAction.EnterOrderNumber("Audit Report", orderNumber);
                WaitForMoment(4);

                //Verify Fields
                _createMaintenanceAction.VerifyField("File Name");
                _createMaintenanceAction.VerifyField("Reprint Count");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("CM Site Verify for No option in Success message;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380816.csv", "ReprintAudit_380816#csv", DataAccessMethod.Sequential)]
        public void TC_380016_VerifyAuditPageNoOptionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(4);

                //Click on the any File
                //Select  the check box of any File and Enter the any Out put Device
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                _createMaintenanceAction.EnterField("Output Device", "PDFU");
                WaitForMoment(4);

                //Click on Reprint button
                _reportAction.ClickButton("Reprint");
                WaitForMoment(4);

                //Verify Page it should Navigate Back to the Dashboard
                _createMaintenanceAction.VerifyField("Production Orders");
                _createMaintenanceAction.VerifyField("Inboxes");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("AuditReprint")]
        [Description("Verify the output device default associated;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380816.csv", "ReprintAudit_380816#csv", DataAccessMethod.Sequential)]
        public void TC_502714_VerifyAuditReprintDefaultOutputTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", "1004088");
                WaitForMoment(4);

                //Click on the any File
                //Verify the output Device
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                _createMaintenanceAction.EnterField("Output Device", "PDFU");
                WaitForMoment(4);

                //PDFU is a default device 
                _createMaintenanceAction.VerifyField("PDFU");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("Production Order Management: Verify for the Reprint count;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380816.csv", "ReprintAudit_380816#csv", DataAccessMethod.Sequential)]
        public void TC_327157_VerifyReprintCountTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(4);

                //Click on the any File
                //Select  the check box of any File and Enter the any Out put Device
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                int CountBeforeReprint = _reportAction.ReprintCount();
                _createMaintenanceAction.EnterField("Output Device", "PDFU");
                WaitForMoment(4);

                //Click on Reprint button
                _reportAction.ClickButton("Reprint");
                WaitForMoment(4);
                _timeConfirmationAction.ClickButton("YES");

                //Verify the Count of reprint 
                WaitForMoment(4);
                int CountAfterReprint= _reportAction.ReprintCount();
                Assert.AreNotEqual(CountBeforeReprint,CountAfterReprint);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("P Production Order Management: Verify for the Reprint Shift Data;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380816.csv", "ReprintAudit_380816#csv", DataAccessMethod.Sequential)]
        public void TC_505263_VerifyReprintShiftDataTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(4);

                //Click on the any File
                //Select  the check box of any File and Enter the any Out put Device
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(2);
                _createMaintenanceAction.EnterField("Output Device", "PDFU");
                WaitForMoment(4);

                //Open Sequence No Picker 
                _reportAction.OpenSequenceNo();
                WaitForMoment(2);

                //Verify Sequence No data 
                _createMaintenanceAction.VerifyField("1");
                _createMaintenanceAction.VerifyField("2");
                _createMaintenanceAction.VerifyField("3");
                _createMaintenanceAction.VerifyField("4");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("CM Site Checking for the report only when order selected/entered;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_380822.csv", "ReprintAudit_380822#csv", DataAccessMethod.Sequential)]
        public void TC_380822_VerifyAuditPageNoOptionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(5);

                //Click Audit Report
                _timeConfirmationAction.ClickButton("Audit Report");

                //Now UI has been changed there be no alert message if the order no dont have any files in it
                _reportAction.EnterOrderNumber("Audit Report", orderNumber);
                WaitForMoment(5);

                //Verify Audit Report details page should display
                //Order Picker
                _createMaintenanceAction.VerifyField("Order");

                //Report section contains
                //1.File Name
                _createMaintenanceAction.VerifyField("File Name");

                //2.Originially Printed Owner
                _createMaintenanceAction.VerifyField("Originally Printed User");
                
                //3.Re - printed User
                _createMaintenanceAction.VerifyField("Reprinted User");

                //4.Printed on
                _createMaintenanceAction.VerifyField("Printed On");

                //5.Re - Print Count
                _createMaintenanceAction.VerifyField("Reprint Count");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("CM Site Verify for Cancel Button in Audit Report;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_327170.csv", "ReprintAudit_327170#csv", DataAccessMethod.Sequential)]
        public void TC_327170_VerifyCancelButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(4);

                //Click Audit Report
                _timeConfirmationAction.ClickButton("Audit Report");

                //Now UI has been changed there be no alert message if the order no dont have any files in it
                _reportAction.EnterOrderNumber("Audit Report", orderNumber);
                WaitForMoment(4);

                //Verify Audit Report details page should display
                //Order Picker
                _createMaintenanceAction.VerifyField("Order");

                //Report section contains
                //1.File Name
                _createMaintenanceAction.VerifyField("File Name");

                //2.Originially Printed Owner
                _createMaintenanceAction.VerifyField("Originally Printed User");

                //3.Re - printed User
                _createMaintenanceAction.VerifyField("Reprinted User");

                //4.Printed on
                _createMaintenanceAction.VerifyField("Printed On");

                //5.Re - Print Count
                _createMaintenanceAction.VerifyField("Reprint Count");

                //Click on Cancel button
                _reportAction.ClickButton("Cancel");

                WaitForMoment(4);

                //Verify Page it should Navigate Back to the Dashboard
                _createMaintenanceAction.VerifyField("Production Orders");
                _createMaintenanceAction.VerifyField("Inboxes");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionAudit")]
        [Description("CM Site -Verify for No Report Found empty Template in Audit Report;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_327170.csv", "ReprintAudit_327170#csv", DataAccessMethod.Sequential)]
        public void TC_327171_VerifyAuditNoReportTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(4);

                //Click Audit Report
                _timeConfirmationAction.ClickButton("Audit Report");

                //Now UI has been changed there be no alert message if the order no dont have any files in it
                _reportAction.EnterOrderNumber("Audit Report", orderNumber);
                WaitForMoment(4);

                //Verify Audit Report details page should display
                //Order Picker
                _createMaintenanceAction.VerifyField("Order");

                //Report section contains
                //1.File Name
                _createMaintenanceAction.VerifyField("File Name");

                //2.Originially Printed Owner
                _createMaintenanceAction.VerifyField("Originally Printed User");

                //3.Re - printed User
                _createMaintenanceAction.VerifyField("Reprinted User");

                //4.Printed on
                _createMaintenanceAction.VerifyField("Printed On");

                //5.Re - Print Count
                _createMaintenanceAction.VerifyField("Reprint Count");

                //Verify If there is No Order Number/Batch OR Printed By OR Date Selected
                WaitForMoment(4);

                //Verify Cancel button are Enable
                _createMaintenanceAction.VerifyField("Cancel");
                //Verify Download button are Enable
                _createMaintenanceAction.VerifyField("Download");
                WaitForMoment(1);

                //Click on Downoad and Save the file 
                _timeConfirmationAction.ClickButton("Download");
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton("Save");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("ProductionPrint")]
        [Description("CM Site Verify for Cancel Button in Audit Report;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ReprintAudit_395097.csv", "ReprintAudit_395097#csv", DataAccessMethod.Sequential)]
        public void TC_326156_VerifyPreviewTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Plant Maintenance Persona->Work Order Inbox
                //Select Reprint and Audit Report from Context Menu/Master Action
                NavigateToSpecificAction(function, persona, inboxNames, "Reprint and Audit Report");
                WaitForMoment(2);

                //Click Reprint
                _reportAction.EnterOrderNumber("Reprint", orderNumber);
                WaitForMoment(1.5);

                //Enter Output Device
                _createMaintenanceAction.EnterField("Output Device", "PDFU");
                WaitForMoment(1.5);

                //Click on the checkboxes
                _createMaintenanceAction.ClickCheckBox("File");
                WaitForMoment(1.5);
                _createMaintenanceAction.ClickCheckBox("Final Confirmation");

                //Enter Qty
                _createMaintenanceAction.EnterField("Quantity", "5");
                _createMaintenanceAction.EnterField("Cavity ID", "Test Automation ID");
                _createMaintenanceAction.EnterField("Sequence", "1");
                WaitForMoment(1.5);

                //Verify Preview PDF
                _createMaintenanceAction.VerifyField("Print Preview");
                _timeConfirmationAction.ClickButton("Print Preview");
                WaitForMoment(5);
                _createMaintenanceAction.VerifyField("Preview");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region ProductionTimeConfirmation

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify for Production Order Time confirmation Page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_381561.csv", "TimeConfirmation_381561#csv", DataAccessMethod.Sequential)]
        public void TC_381561_ProductionOrderTimeConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order Verify for Next and RECENT Confirmation button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_381572.csv", "TimeConfirmation_381572#csv", DataAccessMethod.Sequential)]
        public void TC_381572_VerifyProductionNextAndRecentConfirmationButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Check for  RECENT CONFIRMATIONS and NEXT Button        
                //Verify > Both the Buttons should be enabled
                _timeConfirmationAction.VerifyButtonEnableOrDisable("RecentConfirmations", true);
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order TM Checking for Next button Functionality;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_381581.csv", "TimeConfirmation_381581#csv", DataAccessMethod.Sequential)]
        public void TC_381581_VerifyProductionOrderNextButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox          
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                WaitForMoment(4);

                //Verify Fields
                _createMaintenanceAction.VerifyField("Yield *");
                _createMaintenanceAction.VerifyField("Unit");
                _createMaintenanceAction.VerifyField("Scrap");
                _createMaintenanceAction.VerifyField("Reason for Variance");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order Checking for Multi-scan button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_404598.csv", "TimeConfirmation_404598#csv", DataAccessMethod.Sequential)]
        public void TC_404598_VerifyMultiScanButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox          
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                WaitForMoment(4);

                //Verify Check for Multi- scan button next to Yield\
                _createMaintenanceAction.VerifyField("Click for Multi-Scan");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order Checking for Yield field should be Mandatory;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_404585.csv", "TimeConfirmation_404585#csv", DataAccessMethod.Sequential)]
        public void TC_404585_VerifyYieldFieldMandatoryTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox          
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                WaitForMoment(4);

                //Check for Yield field Mandatory
                _createMaintenanceAction.VerifyField("Yield *");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order Verify for attention message by default yield is Zero or entering value zero in the Yield field;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_404464.csv", "TimeConfirmation_404464#csv", DataAccessMethod.Sequential)]
        public void TC_404464_VerifyYieldAlertTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox          
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(4);

                //Check attention message by default yield is Zero or entering value zero in the Yield field
                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());               
                WaitForMoment(4);

                //Verify Alert message 
                _createMaintenanceAction.VerifyField("Attention");
                _createMaintenanceAction.VerifyField("NO");
                _createMaintenanceAction.VerifyField("YES");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify for Partial Confirmation Production Order - Time Confirmation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_382020.csv", "TimeConfirmation_382020#csv", DataAccessMethod.Sequential)]
        public void TC_382020_VerifyPOPartialConfirmationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();

                //Enter/Select the Proper data in Yield, Scrap and Reason for Variance if required 
                _timeConfirmationAction.EnterFields("Yeild", "50");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                _timeConfirmationAction.EnterFields("Yeild", "50");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                _timeConfirmationAction.EnterFields("Yeild", "50");
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                //Click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(3);

                //Enter the valid data then click on NEXT button
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Click on CONFIRM
                _timeConfirmationAction.ClickButton(ButtonActionOptions.CONFIRM.ToString());

                //Select Partial Confirmation
                //Click on CONFIRM
                _timeConfirmationAction.ConfirmOrder("Partial Confirmation", ButtonActionOptions.Confirm.ToString());
                WaitForMoment(3);

                //Proper error pop message should be display 
                _createMaintenanceAction.VerifyField("Success");
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton("OK");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Production Order Verify for attention message by default yield is Zero or entering value zero in the Yield field;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_403912.csv", "TimeConfirmation_403912#csv", DataAccessMethod.Sequential)]
        public void TC_403912_VerifyNegativeYeildTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox          
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Note: This Functionality has been changed So commenting out for the Future Reference
                //_timeConfirmationAction.EnterOperationLaneNumber(operationValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable("Next", true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(4);

                //Enter Negative value in the Yield field
                _timeConfirmationAction.EnterFields("Yeild", "-50");

                //Click for Multi Scan
                _timeConfirmationAction.ClickButton("Click for Multi-Scan");
                WaitForMoment(1);

                //Verify the Alert message for the Negative value input
                _createMaintenanceAction.VerifyField("Negative values are not allowed in the yield.");

             }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        //Production Cancel Time Confirmation 
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Verify for Cancel Time Confirmation page-Production Order;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POCancelTimeConfirmation_383421.csv", "POCancelTimeConfirmation_383421#csv", DataAccessMethod.Sequential)]
        public void TC_383421_SmokeTestPOCancelTimeConfirmationPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");
          
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Checking for Next  button- Cancel Time Confirmation-Production Order;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POCancelTimeConfirmation_393079.csv", "POCancelTimeConfirmation_393079#csv", DataAccessMethod.Sequential)]
        public void TC_393079_POCancelTimeConfirmationNextButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        //Production PO
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Cancel Time Confirmation : Verify respected column field should display when a User Enters Oder Number / Operation Lan Number and click on Next button;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POCancelTimeConfirmation_381589.csv", "POCancelTimeConfirmation_381589#csv", DataAccessMethod.Sequential)]
        public void TC_381589_POCancelTCFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();

                //Verify table displayed filed >  Respected column should be present
                WaitForMoment(4);

                //1.Activity
                _timeConfirmationAction.VerifyTimeComfirmation("Activity");

                //2.Yield
                _timeConfirmationAction.VerifyTimeComfirmation("Yield");

                //3.Scrap
                _timeConfirmationAction.VerifyTimeComfirmation("Scrap");

                //4.Rework
                _timeConfirmationAction.VerifyTimeComfirmation("Rework");

                //5.UOM
                _timeConfirmationAction.VerifyTimeComfirmation("UOM");

                //6.Confirmation Date
                _timeConfirmationAction.VerifyTimeComfirmation("Confirmation Date");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("CancelTimeConfirmation")]
        [Description("Cancel Time Confirmation WD in Production Order;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POCancelTimeConfirmation_422734.csv", "POCancelTimeConfirmation_422734#csv", DataAccessMethod.Sequential)]
        public void TC_422734_POCancelTCTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Cancel Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Cancel Time Confirmation");

                //Enter Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox("Cancel Time Confirmation", orderValue);
                WaitForMoment(1);

                //Enter Operation / Lane Number
                _timeConfirmationAction.EnterOperationLaneNumber("Cancel Time Confirmation", operationValue);

                //Click Next 
                _timeConfirmationAction.ClickButton(ButtonActionOptions.NEXT.ToString());
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Click on the any of the Row with details in it 
                _timeConfirmationAction.ClickButton("RowData Row1");
                WaitForMoment(2);

                //Verify text displaying in the comment pop up 
                _timeConfirmationAction.VerifyTimeComfirmation("Are you sure you want to perform cancel time confirmation ?");

                //Verify the buttons on the comment pop up
                _timeConfirmationAction.VerifyTimeComfirmation("Cancel");
                _timeConfirmationAction.VerifyTimeComfirmation("Confirm");

                //1.Cancel : Screen goes back to Cancel time confirmation page
                _timeConfirmationAction.ClickButton("Cancel");
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #region Inventory Dashboard
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description("Verify for Production Inventory Dashboard page;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_415507.csv", "POInventoryDashboard_415507#csv", DataAccessMethod.Sequential)]
        public void TC_415507_POInventoryDashboardPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description(" Production Inventory Dashboard : Checking for plant picker;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_415523.csv", "POInventoryDashboard_415523#csv", DataAccessMethod.Sequential)]
        public void TC_415523_POInventoryDashboardPlantPickerTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");
                WaitForMoment(5);

                //Verify : Go to Plant picker and select the USRO Plant
                _inventoryDashboardAction.EnterPlant("USRO");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description("Checking for fields in the Production Inventory Dashboard;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_415536.csv", "POInventoryDashboard_415536#csv", DataAccessMethod.Sequential)]
        public void TC_415536_POVerifyInventoryDashboardFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string operationValue = this.TestContext.DataRow["operationValue"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");
                WaitForMoment(5);

                //Verify fields in the Production Inventory Dashboard
                //1.Plant Picker
                _inventoryDashboardAction.VerifyField("Plant");

                //2.Order Picker
                _inventoryDashboardAction.VerifyField("Order Number");

                //3.Component Picker
                _inventoryDashboardAction.VerifyField("Component");

                //4.Time Internal
                _inventoryDashboardAction.VerifyField("Time interval");

                //5.Countdown Time
                _inventoryDashboardAction.VerifyField("Countdown timer");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description("Verifying for Table fields in the Production Inventory Dashboard;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_431373.csv", "POInventoryDashboard_431373#csv", DataAccessMethod.Sequential)]
        public void TC_431373_POVerifyInventoryDashboardTabelGridFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");
                WaitForMoment(5);

                //Verify Tabel fields in the Production Inventory Dashboard
                //1.Order
                _inventoryDashboardAction.VerifyField("Order");

                //2.Plant
                _inventoryDashboardAction.VerifyField("Plant");

                //3.Status
                _inventoryDashboardAction.VerifyField("Status");

                //4.Start Date
                _inventoryDashboardAction.VerifyField("Start Date");

                //5.Material
                _inventoryDashboardAction.VerifyField("Material");

                //6.Confirmation Yield
                _inventoryDashboardAction.VerifyField("Confirmed Yield");

                //7.Scrap
                _inventoryDashboardAction.VerifyField("Scrap");

                //8.Work Center
                _inventoryDashboardAction.VerifyField("Work Center");

                //9.Component
                _inventoryDashboardAction.VerifyField("Component");

                //10.Requirement Quantity 
                _inventoryDashboardAction.VerifyField("Requirement Quantity");

                //11.Withdrawal Quantity
                _inventoryDashboardAction.VerifyField("Withdrawal Quantity");

                //12.Delivery Batch
                _inventoryDashboardAction.VerifyField("Delivery Batch");

                //13.Available Qty
                _inventoryDashboardAction.VerifyField("Available Quantity");

                //14.Available Batch
                _inventoryDashboardAction.VerifyField("Available Batch");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description("Verifying Time Interval field in Inventory Dashboard;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_431888.csv", "POInventoryDashboard_431888#csv", DataAccessMethod.Sequential)]
        public void TC_431888_POVerifyInventoryDashboardTimeIntervalFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");
                WaitForMoment(5);

                //Verify Time Interval field in the  Inventory Dashboard
                _inventoryDashboardAction.VerifyField("Time interval");

                //Change Time Interval value to 5 and Verify
                _inventoryDashboardAction.SelectFromDropDown("5", "Time interval");

                //Change Time Interval value to 10 and Verify
                _inventoryDashboardAction.SelectFromDropDown("10", "Time interval");

                //Change Time Interval value to 15 and Verify
                _inventoryDashboardAction.SelectFromDropDown("15", "Time interval");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("InventoryReport")]
        [Description(" Checking for 5 Time Interval Auto Refresh-Inventory Report;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"POInventoryDashboard_421827.csv", "POInventoryDashboard_421827#csv", DataAccessMethod.Sequential)]
        public void TC_421827_POVerifyInventoryDashboardAutoRefreshTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Production Orders Management Persona->Production Orders Inbox
                //Select Inventory Report Option from Master Action/Context Menu/Details Action
                //Inventory Report Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Inventory Report");
                WaitForMoment(5);

                //Verify Time Interval field in the  Inventory Dashboard
                _inventoryDashboardAction.VerifyField("Time interval");

                //Enter Plant as "USRO"
                _inventoryDashboardAction.EnterPlant("USRO");

                //As data is huge fetching from the SAP wait appox 10 to 15 sec
                WaitForMoment(10);

                //Change Time Interval value to 10 and Verify
                _inventoryDashboardAction.SelectFromDropDown("10", "Time interval");

                //Verify Loading For every 10 mints data should Auto refresh
                _inventoryDashboardAction.VerifyField("Loading");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify for Taligate Check box -Time confirmation -Production Orders;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_433290.csv", "TimeConfirmation_433290#csv", DataAccessMethod.Sequential)]
        public void TC_433290_VerifyPOTaligateCheckBoxTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                //_timeConfirmationAction.EnterOrderValueInTextBox(orderValue);
                _timeConfirmationAction.EnterOrderValueInTextBox("1002900");

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify for Taligate check box in yield page
                _inventoryDashboardAction.VerifyField("Tailgate");

                //For specific Order 
                //1.User should able to check or uncheck the Taligate
                _createMaintenanceAction.ClickCheckBox("Tailgate");
                WaitForMoment(2);

                //2.If user checked the taligate check box below yield field ,Taligate quantity should dispay
                _inventoryDashboardAction.VerifyField("Maximum tailgate quantity is 100 TS.");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for Attention pop up When you enter the less than Taligate Quantity;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434235.csv", "TimeConfirmation_434235#csv", DataAccessMethod.Sequential)]
        public void TC_434235_VerifyPOTaligateLessQtyAlertTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify for Taligate check box in yield page
                _inventoryDashboardAction.VerifyField("Tailgate");

                //Check for Taligate check box in yield page
                _createMaintenanceAction.ClickCheckBox("Tailgate");
                WaitForMoment(2);

                //Enter the Quantity in Yield field less then taligate quantity
                _timeConfirmationAction.EnterFields("Yeild", "0.01");
                WaitForMoment(5);

                //Click on Next
                _timeConfirmationAction.ClickButton("NEXT");
                WaitForMoment(3);

                //Verify:Proper Attention pop up should display
                _createMaintenanceAction.VerifyField("Attention");
                _createMaintenanceAction.VerifyField("Yield is less than tailgate quantity 0.1 TS. Do you want to continue ? ");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Verify for entering equal to Taligate Quantity -Time confirmation -Production Orders;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434234.csv", "TimeConfirmation_434234#csv", DataAccessMethod.Sequential)]
        public void TC_434234_VerifyPOTaligateQtyTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify for Taligate check box in yield page
                _inventoryDashboardAction.VerifyField("Tailgate");

                //Check for Taligate check box in yield page
                _createMaintenanceAction.ClickCheckBox("Tailgate");
                WaitForMoment(2);

                //Enter the Quantity in Yield field less then taligate quantity
                _timeConfirmationAction.EnterFields("Yeild", "0.1");
                WaitForMoment(5);

                //Click on Next
                _timeConfirmationAction.ClickButton("NEXT");
                WaitForMoment(2);
                //_timeConfirmationAction.ClickButton("Yes");
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //User should able continue for Further process and Navigate to Next page 
                _inventoryDashboardAction.VerifyField("Activities");
                _inventoryDashboardAction.VerifyField("Time Confirmation");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("TimeConfirmation")]
        [Description("Checking for Attention pop up when you enter the more than Taligate Quantity Time confirmation Production Orders;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434235.csv", "TimeConfirmation_434235#csv", DataAccessMethod.Sequential)]
        public void TC_434237_VerifyPOTaligateMoreQtyAlertTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["OrderValue"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Time Confirmation Option from Master Action/Context Menu/Details Action
                //Time Confirmation Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Time Confirmation");

                //Enter > Select the Proper order in the Order Picker
                _inboxAction.WaitForLoadingToDisappear();
                _timeConfirmationAction.EnterOrderValueInTextBox(orderValue);

                //Click on NEXT Button                                                            
                //1.User should able to click on NEXT button
                _timeConfirmationAction.VerifyButtonEnableOrDisable(ButtonActionOptions.NEXT.ToString(), true);
                _timeConfirmationAction.ClickNextButton();
                _inboxAction.WaitForLoadingToDisappear();
                WaitForMoment(2);

                //Verify for Taligate check box in yield page
                _inventoryDashboardAction.VerifyField("Tailgate");

                //Check for Taligate check box in yield page
                _createMaintenanceAction.ClickCheckBox("Tailgate");
                WaitForMoment(2);

                //Enter the Quantity in Yield field more then taligate quantity
                _timeConfirmationAction.EnterFields("Yeild", "5");
                WaitForMoment(5);

                //Click on Next
                _timeConfirmationAction.ClickButton("NEXT");
                WaitForMoment(3);

                //Verify:Proper Attention pop up should display
                _createMaintenanceAction.VerifyField("Attention");
                _createMaintenanceAction.VerifyField("Yield is more than tailgate quantity 0.1 TS. Do you want to continue ? ");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("MaterialStaging")]
        [Description("Verify Production order Request for staging page navigation;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434234.csv", "TimeConfirmation_434234#csv", DataAccessMethod.Sequential)]
        public void TC_440301_VerifyRequestforStagingNavigationTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select "Material Staging" Option from Master Action/Context Menu/Details Action
                //Verify:"Request for staging/ Material Staging" page should open 
                NavigateToSpecificAction(function, persona, inboxNames, "Request for Staging");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("MaterialStaging")]
        [Description("Verify Production Order Request for staging filter fields;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434234.csv", "TimeConfirmation_434234#csv", DataAccessMethod.Sequential)]
        public void TC_440755_VerifyRequestforStagingFiltersTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select "Material Staging" Option from Master Action/Context Menu/Details Action
                //Verify:"Request for staging/ Material Staging" page should open 
                NavigateToSpecificAction(function, persona, inboxNames, "Request for Staging");
                WaitForMoment(2);

                //Verify Below fields should available 
                //1.Order : Mandatory Field
                _inventoryDashboardAction.VerifyField("Order");

                //2.Requirement Date
                _inventoryDashboardAction.VerifyField("Requirement Date");

                //3.Location
                _inventoryDashboardAction.VerifyField("Location");

                //4.Material
                _inventoryDashboardAction.VerifyField("Material");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("MaterialStaging")]
        [Description("Verify Production Order Request for staging Table fields;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_434234.csv", "TimeConfirmation_434234#csv", DataAccessMethod.Sequential)]
        public void TC_442116_VerifyRequestforStagingTabelFieldsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select "Material Staging" Option from Master Action/Context Menu/Details Action
                //Verify:"Request for staging/ Material Staging" page should open 
                NavigateToSpecificAction(function, persona, inboxNames, "Request for Staging");
                WaitForMoment(2);

                //Select Order Number
                //Verify Below Tabel fields should available 
                //1.Material
                _inventoryDashboardAction.VerifyField("Material");
                //2.Requirement Date
                _inventoryDashboardAction.VerifyField("Requirement Date");
                //3.Requirement Qty.
                _inventoryDashboardAction.VerifyField("Requirement Qty.");
                //4.Available Stock
                _inventoryDashboardAction.VerifyField("Available Stock at Work Center");
                //4.Warehouse Stock
                _inventoryDashboardAction.VerifyField("Warehouse Qty.");
                //5.Missing Qty.
                _inventoryDashboardAction.VerifyField("Missing Qty.");
                //6.Staging Qty.
                _inventoryDashboardAction.VerifyField("Staging Qty.");              
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }      
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("MaterialStaging")]
        [Description("Verify Production Order Request for staging Posting the staging QTY alert pop up;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"TimeConfirmation_443077.csv", "TimeConfirmation_443077#csv", DataAccessMethod.Sequential)]
        public void TC_443077_VerifyRequestforStagingQTYAlertTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderNumber = this.TestContext.DataRow["orderNumber"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select "Material Staging" Option from Master Action/Context Menu/Details Action
                //Verify:"Request for staging/ Material Staging" page should open 
                NavigateToSpecificAction(function, persona, inboxNames, "Request for Staging");
                WaitForMoment(2);

                //Select Order Number
                //_timeConfirmationAction.EnterOrderValueInTextBox("Material Stageing", "1003315");
                _timeConfirmationAction.EnterOrderValueInTextBox("Material Stageing", orderNumber);
                WaitForMoment(2);

                //Click Start Analysis
                _timeConfirmationAction.ClickButton("Start Analysis");
                WaitForMoment(5);

                //Enter Intvalue in Staging Text box or check the CheckBox
                _createMaintenanceAction.ClickCheckBox("Staging");
                WaitForMoment(2);
                _timeConfirmationAction.ClickButton("Post");
                WaitForMoment(2);

                //Verify the Alert Message 
                _inventoryDashboardAction.VerifyField("Attention");
                _inventoryDashboardAction.VerifyField("Are you sure you want to post?");             
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        //Goods Issue Reversal 
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssueReversal")]
        [Description("Goods Issue reversal : Edit Component Material Card;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssueReversal_490266.csv", "GoodsIssueReversal_490266#csv", DataAccessMethod.Sequential)]
        public void TC_490266_VerifyGIREditComponentMaterialCardTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Reversal Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue Reversal");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Component Material card
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Click on any Component Material
                //Click on the check box of the Component Material
                 _timeConfirmationAction.ClickButton("Component Material");
                WaitForMoment(2);

                //Edit the Qty in the Edit text box with respected to batch 
                _timeConfirmationAction.EnterFields("Quantity", qty);

                //Click on save
                _timeConfirmationAction.ClickButton("SAVE");

                //Verify the success message and it navigate to the Goods Issue Reversal page
                _labelPrintingAction.VerifyPageTitle("Goods Issue Reversal");
                _goodIssueAction.VerifyAddedComponent("Component Material");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssueReversal")]
        [Description("Verify Component Material Card Goods Issue reversal;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssueReversal_490177.csv", "GoodsIssueReversal_490177#csv", DataAccessMethod.Sequential)]
        public void TC_490177_VerifyGIRComponentMaterialCardTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Reversal Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue Reversal");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Component Material card
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Verify Issued QTY
                _goodIssueAction.VerifyAddedComponent("Issued Qty.");

                //Verify Issued Reversing QTY
                _goodIssueAction.VerifyAddedComponent("Reversing Qty.");

                //Verify Batch ID
                _goodIssueAction.VerifyAddedComponent("Batch");
                _goodIssueAction.VerifyAddedComponent(batchId);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssueReversal")]
        [Description("Verify Component Material Card check box Goods Issue reversal;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssueReversal_490177.csv", "GoodsIssueReversal_490177#csv", DataAccessMethod.Sequential)]
        public void TC_490185_VerifyGIRComponentMaterialCardcheckBoxTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Reversal Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue Reversal");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Component Material card
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Verify Issued QTY
                _goodIssueAction.VerifyAddedComponent("Issued Qty.");

                //Verify Issued Reversing QTY
                _goodIssueAction.VerifyAddedComponent("Reversing Qty.");

                //Verify Batch ID
                _goodIssueAction.VerifyAddedComponent("Batch");
                _goodIssueAction.VerifyAddedComponent(batchId);

                //Click on the check box of the Component Material 
                _binsProductsAction.SelectBatchCheckbox(1);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("GoodsIssueReversal")]
        [Description("Smoke Test Case Goods Issue reversal;;")]
        [Owner("Faizal.KhanEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"GoodsIssueReversal_490177.csv", "GoodsIssueReversal_490177#csv", DataAccessMethod.Sequential)]
        public void TC_327291_VerifyGIRSmokeTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();
                string orderValue = this.TestContext.DataRow["orderValue"].ToString();
                string qty = this.TestContext.DataRow["qty"].ToString();
                string batchId = this.TestContext.DataRow["batchId"].ToString();

                //Go to Manufacturing Function->Process Orders Management Persona->Process Orders Inbox
                //Select Goods Issue from Master Action/Context Menu/Details Action
                //Goods Issue Reversal Page should Display
                NavigateToSpecificAction(function, persona, inboxNames, "Goods Issue Reversal");

                //Select Order Number
                _inboxAction.WaitForLoadingToDisappear();
                _goodIssueAction.EnterOrderValueInTextBox(orderValue);
                _inboxAction.WaitForLoadingToDisappear();

                //Verify Component Material card
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Verify Issued QTY
                _goodIssueAction.VerifyAddedComponent("Issued Qty.");

                //Verify Issued Reversing QTY
                _goodIssueAction.VerifyAddedComponent("Reversing Qty.");

                //Verify Batch ID
                _goodIssueAction.VerifyAddedComponent("Batch");
                _goodIssueAction.VerifyAddedComponent(batchId);

                //Edit Component
                _timeConfirmationAction.ClickButton("Component Material");
                WaitForMoment(2);

                //Edit the Qty in the Edit text box with respected to batch 
                _timeConfirmationAction.EnterFields("Quantity", qty);

                //Click on save
                _timeConfirmationAction.ClickButton("SAVE");
                WaitForMoment(2);
                _goodIssueAction.VerifyAddedComponent("Component Material");

                //Click on all the check box of the component card which user want to select
                //click on Post button and verify Success
                _timeConfirmationAction.ClickButton("Post");
                WaitForMoment(3);
                _goodIssueAction.VerifyAddedComponent("Success");

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
    }
}