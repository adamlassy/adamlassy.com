using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace md1
{
    public partial class Form1 : Form
    {
        #region form constructor
        public Form1()
        {
            InitializeComponent();
            SelfCheck();
        }
        #endregion

        #region private constants
        const string selectADrive = "Select Drive...";
        const string fillOutAllInputFieldsBeforeClicking = "Please fill out all the input fields before clicking on the save button";
        const string removable = "Removable";
        const string noUSBDriveInput = "You do not have a USB Removable drive connected to your PC. Please choose the location you want to save your output file.";
        const string moreThanOneUSBDriveInput = "You have more than 1 USB Removable drive connected to your PC. Please choose the location you want to save your output file.";
        const string outputFilePrefix = "J1_";
        const string outputFileExtension = ".txt";
        const string outputFileSearchWildcard = "J1_*.txt";
        const string outputFileAlreadyExists = "\\J1_*****.txt already exists. \n Do you want to replace it?";
        const string savedSuccessfully = "Saved Successfully";
        const string logFileOutput = "C:\\Program Files\\Major Drilling\\logs\\major.md1.log";
        const string userSavedOutput = "C:\\Program Files\\Major Drilling\\logs\\user.saved";
        const string isRequired = " is a required field. Please fill it out in full.";
        const string typeValidationFailed = "Type validation failed.";
        const string canOnlyBeBetween = " can only be between";
        const string pleaseFillInTheValues = "Please revisit the field value.";
        const string logOutputDirectory = "C:\\Program Files\\Major Drilling\\logs";
        const string logDirectoryDoesntExist = logOutputDirectory + " doesn't exist. Creating it.";
        const string closePrompt = "Do You Really Wish to Close?";
        #endregion

        string focusLeaveControl = string.Empty;
        string radioFlag = "gps";

        string gpsLongDeg = "0";
        string gpsLongMin = "0";
        string gpsLongSec = "0";

        string gpsLatDeg = "0";
        string gpsLatMin = "0";
        string gpsLatSec = "0";

        string eastWest = "E";
        string northSouth = "N";

        string decimalLon = "0";
        string decimalLat = "0";
        string radLon = "0";
        string radLat = "0";

        Hashtable hashOfficeLocations = new Hashtable();


        #region private methods
        private void SelfCheck()
        {
            try
            {
                //Look for setup directory and log file directory to make sure they exist.
                CheckLogExists();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                SaveOutput();
            }
            catch ( Exception exception )
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }
        private void SaveOutput()
        {
            try
            {
                FolderBrowserDialog browserWindow = new FolderBrowserDialog();
                browserWindow.ShowNewFolderButton = false;
                browserWindow.Description = selectADrive;
                browserWindow.RootFolder = Environment.SpecialFolder.MyComputer;
                bool hasRemovableDrive = false;
                bool hasMoreThanOneRemovableDrive = false;
                string deviceDriveLetter = String.Empty;

                if (!ValidateInputFields())
                {
                    MessageBox.Show(fillOutAllInputFieldsBeforeClicking);
                    return;
                }

                string output = String.Empty;
                string userSettings = String.Empty;
                
                //Convert radioFlag type to decimal for output file
                if (radioFlag.CompareTo("gps") == 0)
                    convertGPSToDecimal(false);
                else if (radioFlag.CompareTo("radian") == 0)
                    convertRadianToDecimal(false);
                

                output = txtJobNumber.Text.Trim() + "," + txtHoleID.Text.Trim() + "," + txtRigID.Text.Trim() + "," + 
                    decimalLon + "," + decimalLat + "," + txtWirelineRate.Text.Trim() + "," + txtDrillingRate.Text.Trim() + "," + 
                    cboHoleSize.SelectedItem.ToString() + "," + txtHoleInclination.Text.Trim() + "," + cboDrillRods.SelectedItem.ToString() + "," + 
                    cboTubeHead.SelectedItem.ToString() + "," + cboCoreBarrelLength.SelectedItem.ToString() + "," + cboOverShotSize.SelectedItem.ToString() + "," +
                    cboCoreOrientation.SelectedItem.ToString() + "," + cboCoreOrientationbypass.SelectedItem.ToString() + "," + txtDepthWaterTable.Text.Trim();
                /*
                userSettings = txtJobNumber.Text.Trim() + "|" + txtHoleID.Text.Trim() + "|" + txtRigID.Text.Trim() + "|" +
                    decimalLon + "|" + decimalLat + "|" + txtWirelineRate.Text.Trim() + "|" + txtDrillingRate.Text.Trim() + "|" + 
                    cboHoleSize.SelectedIndex + "|" + txtHoleInclination.Text.Trim() + "|" + cboDrillRods.SelectedIndex + "|" + 
                    cboTubeHead.SelectedIndex + "|" + cboCoreBarrelLength.SelectedIndex + "|" + cboOverShotSize.SelectedIndex + "|" +
                    cboCoreOrientation.SelectedIndex + "|" + cboCoreOrientationbypass.SelectedIndex + "|" + txtDepthWaterTable.Text.Trim();
                */

                //Find the Removable device(s)
                //deviceDriveLetter = findRemovableDriveLetter(); //mpoirier
                
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    if (driveInfo.DriveType.ToString().ToUpper().Equals(removable.ToUpper()))
                    {
                        if (hasRemovableDrive)
                        {
                            hasMoreThanOneRemovableDrive = true;
                        }
                        hasRemovableDrive = true;
                        deviceDriveLetter = driveInfo.Name;
                    }
                }

                //Randomize the filename
                string random = RandomNumber(10000, 99999).ToString();

                //If the user doesn't have a removable drive connected to the PC or if the user has more than 1, we want to show the folder dialog
                if (!hasRemovableDrive || hasMoreThanOneRemovableDrive)
                {
                    if (!hasRemovableDrive)
                    {
                        MessageBox.Show(noUSBDriveInput);
                    }
                    else if (hasRemovableDrive)
                    {
                        MessageBox.Show(moreThanOneUSBDriveInput);
                    }

                    DialogResult result = browserWindow.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        WriteToFile(browserWindow.SelectedPath, "\\" + outputFilePrefix + random + outputFileExtension, output);
                    }
                }
                //If the user has 1 usb removable drive connected to the PC
                else if (hasRemovableDrive && !hasMoreThanOneRemovableDrive)
                {
                    // create a writer and open the file
                    WriteToFile(deviceDriveLetter, "\\" + outputFilePrefix + random + outputFileExtension, output);
                }

                //write user settings here: C:/Program Files/Major Drilling/logs/user.saved
                //WriteUserInputs(userSettings);
                AddToLog(System.DateTime.Now.ToString() + " | SAVED USER SETTINGS | " + userSavedOutput);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }

        private int RandomNumber( int min, int max )
        {
            try
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return -1;
            }
        }

        private void WriteToFile( string path, string filename, string output )
        {
            try
            {
                //Check to see if file pattern already exists before writing.
                string[] fileListToCheckFor = System.IO.Directory.GetFiles(path, outputFileSearchWildcard);

                //Initialize the continue flag to false to NOT write the output file by default.
                bool canContinue = false;

                //If there's already files matching the pattern
                if (fileListToCheckFor.Length > 0)
                {
                    DialogResult result = MessageBox.Show(path + outputFileAlreadyExists, "Save", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        //User clicked on NO, don't write the output file.
                        canContinue = false;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        //we want to flag the output for write.
                        canContinue = true;

                        //Remove the old files
                        for (int counter = 0; counter < fileListToCheckFor.Length; counter++)
                        {
                            File.Delete(fileListToCheckFor.GetValue(counter).ToString());
                        }
                    }
                }
                else if (fileListToCheckFor.Length == 0)
                {
                    //There were no old output files we needed to remove for the user, flag the output for write.
                    canContinue = true;
                }

                //If we're flagged to continue with the write.
                if (canContinue)
                {
                    TextWriter tw = new StreamWriter(path + filename);

                    // write a line of text to the file
                    tw.WriteLine(output);

                    // close the stream
                    tw.Close();

                    MessageBox.Show(savedSuccessfully);

                    //Add to Logging
                    AddToLog(System.DateTime.Now.ToString() + " | SAVE | " + path + filename);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }

        private void CheckLogExists()
        {
            //Check to see if the logging output directory exists
            if (!Directory.Exists(logOutputDirectory))
            {
                //Create the Directory
                Directory.CreateDirectory(logOutputDirectory);

                AddToLog(System.DateTime.Now.ToString() + " | WARNING | " + logDirectoryDoesntExist);
            }
        }

        private void AddToLog(string output)
        {
            try
            {
                CheckLogExists();

                StreamWriter tw = new StreamWriter(logFileOutput, true);
                tw.WriteLine(output);
                tw.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString() + " | Please Contact Support");
                //AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }
        
        /* WE'RE NOT WRITING TO THE HD ANYMORE. WE'RE JUST GOING TO USE THE WIRELINE HEADER FILE TO LOAD THE USER'S INPUT
        private void WriteUserInputs(string output)
        {
            try
            {                                                   //do not append
                StreamWriter tw = new StreamWriter(userSavedOutput, false);
                tw.WriteLine(output);
                tw.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }
        */
        
        private bool ValidateInputFields()
        {
            try
            {
                if (txtJobNumber.Text.Equals(String.Empty) || txtHoleID.Text.Equals(String.Empty) || txtRigID.Text.Equals(String.Empty) ||
                    //txtLongitude.Text.Equals(String.Empty) || txtLatitude.Text.Equals(String.Empty) || 
                    txtWirelineRate.Text.Equals(String.Empty) || txtDrillingRate.Text.Equals(String.Empty) || cboHoleSize.SelectedItem.ToString().Equals(String.Empty) || 
                    txtHoleInclination.Text.Equals(String.Empty) || cboDrillRods.SelectedItem == null || cboTubeHead.SelectedItem == null || 
                    cboCoreBarrelLength.SelectedItem == null || cboOverShotSize.SelectedItem == null || cboCoreOrientation.SelectedItem == null || 
                    cboCoreOrientationbypass.SelectedItem == null || txtDepthWaterTable.Text.Equals(String.Empty))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs args)
        {
            try
            {
                AddToLog(System.DateTime.Now.ToString() + " | STARTED APPLICATION");
                txtLongitude.Visible = false;
                txtLatitude.Visible = false;

                txtGPSLongDeg.Visible = true;
                txtGPSLongMin.Visible = true;
                txtGPSLongSec.Visible = true;
                txtGPSLatDeg.Visible = true;
                txtGPSLatMin.Visible = true;
                txtGPSLatSec.Visible = true;

                cboEastWest.Visible = true;
                cboNorthSouth.Visible = true;

                txtGPSLongDeg.Text = gpsLongDeg;
                txtGPSLongMin.Text = gpsLongMin;
                txtGPSLongSec.Text = gpsLongSec;

                txtGPSLatDeg.Text = gpsLatDeg;
                txtGPSLatMin.Text = gpsLatMin;
                txtGPSLatSec.Text = gpsLatSec;

                cboEastWest.SelectedIndex = 0;
                cboNorthSouth.SelectedIndex = 0;

                cboHoleSize.Items.Add("A");
                cboHoleSize.Items.Add("B");
                cboHoleSize.Items.Add("H");
                cboHoleSize.Items.Add("N");
                cboHoleSize.Items.Add("P");

                cboDrillRods.Items.Add("Standard");
                cboDrillRods.Items.Add("Internal Upset");

                cboTubeHead.Items.Add("Fast");
                cboTubeHead.Items.Add("Standard");

                cboCoreBarrelLength.Items.Add("5 ft(1.5 M)");
                cboCoreBarrelLength.Items.Add("10 ft(3M)");
                cboCoreBarrelLength.Items.Add("20 ft(6M)");

                cboOverShotSize.Items.Add("A");
                cboOverShotSize.Items.Add("B");
                cboOverShotSize.Items.Add("N");
                cboOverShotSize.Items.Add("H");

                cboCoreOrientation.Items.Add("Y");
                cboCoreOrientation.Items.Add("N");

                cboCoreOrientationbypass.Items.Add("Y");
                cboCoreOrientationbypass.Items.Add("N");

                loadUserSettings();
                loadMajorDrillingOffices();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }

        private void btnClose_Click( object sender, EventArgs args )
        {
            this.ControlValidation(false); //Deactivate Validation on all form controls
            this.Close();
        }
        #endregion
        
        #region field validations
        private void ControlValidation(bool status)
        {
            foreach (Control ctrl in this.Controls)
            {
                MaskedTextBox tb = ctrl as MaskedTextBox;
                if (tb != null)
                {
                    tb.CausesValidation = status;
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                ComboBox tb = ctrl as ComboBox;
                if (tb != null)
                {
                    tb.CausesValidation = status;
                }
            }
        }


        private bool ValidateControl(string textToCheck, string fieldName, bool checkIsEmpty, bool checkIsNumeric, bool displayErrorMessage)
        {
            if (checkIsEmpty)
            {
                if (textToCheck.Length == 0)
                {
                    if (displayErrorMessage)
                        MessageBox.Show(this, fieldName + " is a required field. It cannot be left empty.", "Type validation failed.");

                    return false;
                }
            }
            if (checkIsNumeric)
            {
                if (!IsNumeric(textToCheck))
                {
                    if (displayErrorMessage)
                        MessageBox.Show(this, fieldName + " has to be numeric.", "Type validation failed.");

                    return false;
                }
            }
            return true;
        }

        private bool CheckForCharacter(string textToCheck, string fieldName, string charToCheck)
        {
            if (textToCheck.Contains(charToCheck))
            {
                MessageBox.Show(this, fieldName + " does not allow commas.", "Type validation failed.");
                return false;
            }
            return true;
        }

        private void txtJobNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtJobNumber.Text, "Job Number", true, false, true))
            {
                txtJobNumber.Focus();
            }
            else if (!CheckForCharacter(txtJobNumber.Text, "Job Number", ","))
            {
                txtJobNumber.Focus();
            }
        }

        private void txtHoleID_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtHoleID.Text, "Hole ID", true, false, true))
            {
                txtHoleID.Focus();
            }
            else if (!CheckForCharacter(txtHoleID.Text, "Hole ID", ","))
            {
                txtHoleID.Focus();
            }
        }

        private void txtRigID_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtRigID.Text, "Rig ID", true, false, true))
            {
                txtRigID.Focus();
            }
            else if (!CheckForCharacter(txtRigID.Text, "Rig ID", ","))
            {
                txtRigID.Focus();
            }
        }

        private void txtWirelineRate_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtWirelineRate.Text, "Wireline Rate", true, false, true))
            {
                txtWirelineRate.Focus();
            }

            else if (!CheckForCharacter(txtWirelineRate.Text, "Wireline Rate", ","))
            {
                txtWirelineRate.Focus();
            }

            else if (int.Parse(txtWirelineRate.Text) < 15 || int.Parse(txtWirelineRate.Text) > 200)
            {
                MessageBox.Show(this, "Wireline Rate" + canOnlyBeBetween + " 15 and 200. " + pleaseFillInTheValues, typeValidationFailed);
                txtWirelineRate.Focus();
            }
        }

        private void txtDrillingRate_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtDrillingRate.Text, "Drilling Rate", true, false, true))
            {
                txtDrillingRate.Focus();
            }

            else if (!CheckForCharacter(txtDrillingRate.Text, "Drilling Rate", ","))
            {
                txtDrillingRate.Focus();
            }

            else if (int.Parse(txtDrillingRate.Text) < 1 || int.Parse(txtDrillingRate.Text) > 10)
            {
                MessageBox.Show(this, "Drilling Rate" + canOnlyBeBetween + " 1 and 10. " + pleaseFillInTheValues, typeValidationFailed);
                txtDrillingRate.Focus();
            }
        }

        private void cboHoleSize_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboHoleSize.Text, "Hole Size", true, false, true))
            {
                cboHoleSize.Focus();
            }
        }

        private void txtHoleInclination_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtHoleInclination.Text, "Hole Inclination", true, true, true))
            {
                txtHoleInclination.Focus();
            }

            else if (!CheckForCharacter(txtHoleInclination.Text, "Hole Inclination", ","))
            {
                txtHoleInclination.Focus();
            }

            else if (int.Parse(txtHoleInclination.Text) > 0 || int.Parse(txtHoleInclination.Text) < -90)
            {
                MessageBox.Show(this, "Hole Inclination" + canOnlyBeBetween + " 0 and -90. " + pleaseFillInTheValues, typeValidationFailed);
                txtHoleInclination.Focus();
            }
        }

        private void cboDrillRods_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboDrillRods.Text, "Drill Rods", true, false, true))
            {
                cboDrillRods.Focus();
            }
        }

        private void cboTubeHead_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboTubeHead.Text, "Tube Head", true, false, true))
            {
                cboTubeHead.Focus();
            }
        }

        private void cboCoreBarrelLength_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboCoreBarrelLength.Text, "Core Barrel Length", true, false, true))
            {
                cboCoreBarrelLength.Focus();
            }
        }

        private void cboOverShotSize_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboOverShotSize.Text, "Over Shot Size", true, false, true))
            {
                cboOverShotSize.Focus();
            }
        }

        private void cboCoreOrientation_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboCoreOrientation.Text, "Core Orientation", true, false, true))
            {
                cboCoreOrientation.Focus();
            }
        }

        private void cboCoreOrientationbypass_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(cboCoreOrientationbypass.Text, "Core Orientation Bypass", true, false, true))
            {
                cboCoreOrientationbypass.Focus();
            }
        }
        
        private void txtDepthWaterTable_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtDepthWaterTable.Text, "Depth Water Table", true, false, true))
            {
                txtDepthWaterTable.Focus();
            }

            else if (!CheckForCharacter(txtDepthWaterTable.Text, "Depth Water Table", ","))
            {
                txtDepthWaterTable.Focus();
            }
        }
        
        #endregion

        private void formControlLeaveFocus(object sender, EventArgs e)
        {
            focusLeaveControl = ((Control)sender).Name;
        }

        private void btnSave_Enter(object sender, EventArgs e) //We shouldn't have to do this.
        {
            if (focusLeaveControl.Equals("txtDepthWaterTable"))
            {
                txtDepthWaterTable_Validating(sender, null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.ControlValidation(false); //Deactivate Validation on all form controls
                DialogResult result = MessageBox.Show(closePrompt, "Confirm Exit", MessageBoxButtons.YesNo);
                //args.Cancel = result == DialogResult.No; //OLD
                if (result == DialogResult.Yes) //Close the Application
                {
                    AddToLog(System.DateTime.Now.ToString() + " | CLOSING APPLICATION");
                    e.Cancel = false;
                }
                else //Do not close the application, resume
                {
                    this.ControlValidation(true); //Re-activate Validation
                    foreach (Control ctrl in this.Controls)  //Put focus on the active form control
                    {
                        if (ctrl.Name.Equals(focusLeaveControl))
                        {
                            ctrl.Focus();
                        }
                    }
                    e.Cancel = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.GetBaseException().ToString());
                AddToLog(System.DateTime.Now.ToString() + " | EXCEPTION | " + exception.GetBaseException());
                return;
            }
        }

        private void radioGPS_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblLongitude.Text = "GPS Longitude:";
                lblLatitude.Text = "GPS Latitude:";
                
                updateCoordinates(radioFlag, "gps");

                txtGPSLongDeg.Text = gpsLongDeg;
                txtGPSLongMin.Text = gpsLongMin;
                txtGPSLongSec.Text = gpsLongSec;

                if (eastWest.CompareTo("E") == 0)
                    cboEastWest.SelectedIndex = 0;
                if (eastWest.CompareTo("W") == 0)
                    cboEastWest.SelectedIndex = 1;

                txtGPSLatDeg.Text = gpsLatDeg;
                txtGPSLatMin.Text = gpsLatMin;
                txtGPSLatSec.Text = gpsLatSec;

                if (northSouth.CompareTo("N") == 0)
                    cboNorthSouth.SelectedIndex = 0;
                if (northSouth.CompareTo("S") == 0)
                    cboNorthSouth.SelectedIndex = 1;

                radioFlag = "gps";

                enableGPS(true);
            }
        }

        private void radioUTM_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblLongitude.Text = "UTM Longitude:";
                lblLatitude.Text = "UTM Latitude:";

                txtLatitude.Text = string.Empty;
                txtLongitude.Text = string.Empty;

                enableLatLon(false);
                enableGPS(false);

                MessageBox.Show("UTM Conversion Unavailable. Please Choose an Office Location");
            }
        }

        private void radioDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                enableGPS(false);
                enableLatLon(true);

                lblLongitude.Text = "Decimal Longitude:";
                lblLatitude.Text = "Decimal Latitude:";
                updateCoordinates(radioFlag, "decimal");

                if (decimalLon.CompareTo("0") == 0)
                    txtLongitude.Text = String.Empty;
                else
                    txtLongitude.Text = decimalLon;

                if (decimalLat.CompareTo("0") == 0)
                    txtLatitude.Text = String.Empty;
                else
                    txtLatitude.Text = decimalLat;
                
                txtLatitude.Enabled = true;
                txtLongitude.Enabled = true;

                radioFlag = "decimal";
            }
        }

        private void radioRadian_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                enableGPS(false);
                enableLatLon(true);

                lblLongitude.Text = "Radian Longitude:";
                lblLatitude.Text = "Radian Latitude:";
                updateCoordinates(radioFlag, "radian");

                if (radLon.CompareTo("0") == 0)
                    txtLongitude.Text = String.Empty;
                else
                    txtLongitude.Text = radLon;

                if (radLat.CompareTo("0") == 0)
                    txtLatitude.Text = String.Empty;
                else
                    txtLatitude.Text = radLat;

                txtLatitude.Enabled = true;
                txtLongitude.Enabled = true;

                radioFlag = "radian";
            }
        }

        private void enableLatLon(bool reverse)
        {
            if (!reverse)
            {
                txtLongitude.Enabled = false;
                txtLatitude.Enabled = false;
            }
            else
            {
                txtLongitude.Enabled = true;
                txtLatitude.Enabled = true;
            }
        }

        private void enableGPS(bool reverse)
        {
            if (!reverse)
            {
                txtGPSLongDeg.Visible = false;
                txtGPSLongMin.Visible = false;
                txtGPSLongSec.Visible = false;
                txtGPSLatDeg.Visible = false;
                txtGPSLatMin.Visible = false;
                txtGPSLatSec.Visible = false;
                cboEastWest.Visible = false;
                cboNorthSouth.Visible = false;

                txtLongitude.Visible = true;
                txtLatitude.Visible = true;
            }
            else
            {
                //Put values in textboxes.
                if (gpsLongDeg.CompareTo(string.Empty) != 0)
                    txtGPSLongDeg.Text = gpsLongDeg;
                if (gpsLongMin.CompareTo(string.Empty) != 0)
                    txtGPSLongMin.Text = gpsLongMin;
                if (gpsLongSec.CompareTo(string.Empty) != 0)
                    txtGPSLongSec.Text = gpsLongSec;
                if (eastWest.CompareTo("E") == 0)
                    cboEastWest.SelectedIndex = 0;

                if (gpsLatDeg.CompareTo(string.Empty) != 0)
                    txtGPSLatDeg.Text = gpsLatDeg;
                if (gpsLatMin.CompareTo(string.Empty) != 0)
                    txtGPSLatMin.Text = gpsLatMin;
                if (gpsLatSec.CompareTo(string.Empty) != 0)
                    txtGPSLatSec.Text = gpsLatSec;
                if (eastWest.CompareTo("W") == 0)
                    cboEastWest.SelectedIndex = 1;

                txtGPSLongDeg.Visible = true;
                txtGPSLongMin.Visible = true;
                txtGPSLongSec.Visible = true;
                txtGPSLatDeg.Visible = true;
                txtGPSLatMin.Visible = true;
                txtGPSLatSec.Visible = true;
                cboEastWest.Visible = true;
                cboNorthSouth.Visible = true;

                txtLongitude.Visible = false;
                txtLatitude.Visible = false;
            }
        }

        private void loadUserSettings()
        {
            string userSettings = String.Empty;
            bool hasRemovableDrive = false;
            //bool hasMoreThanOneRemovableDrive = false;
            ArrayList deviceDriveLetter = new ArrayList();

            //Look for removable device(s)
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.DriveType.ToString().ToUpper().Equals(removable.ToUpper()))
                {
                    //if (hasRemovableDrive)
                    //{
                    //    hasMoreThanOneRemovableDrive = true;
                    //}
                    hasRemovableDrive = true;
                    deviceDriveLetter.Add(driveInfo.Name);
                }
            }

            //Now loop thru the drives and look for the first occurence of the "J1" file.
            Object[] deviceDriveLetterArray = deviceDriveLetter.ToArray();
            string path = string.Empty;
            string fileToUse = string.Empty;

            for(int i = 0; i < deviceDriveLetterArray.Length; i++)
            {
                path = (string)deviceDriveLetterArray[i];
                string[] fileListToCheckFor = System.IO.Directory.GetFiles(path, outputFileSearchWildcard);

                if(fileListToCheckFor.Length > 0)
                {
                    //we found 1 instance of the file on 1 removable drive, get out of the loop and load the user's settings.
                    fileToUse = (string)fileListToCheckFor.GetValue(0);
                    break;
                }
            }


            //Method to load user saved settings from the following file: C:\Program Files\Major Drilling\logs\user.saved
            if (File.Exists(fileToUse))
            {
                //using (StreamReader sr = new StreamReader(userSavedOutput))
                using (StreamReader sr = new StreamReader(fileToUse))
                {
                    string line = String.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        userSettings += line;
                    }
                }
                //Now, we parse the userSettings and set the form controls accordingly.
                //MessageBox.Show(userSettings);
                string[] userSettingsArray = new string[16];
                if (userSettings.CompareTo(String.Empty) != 0) //if not empty
                {
                    userSettingsArray = userSettings.Split(',');
                }

                radioFlag = "decimal";
                radioDecimal.Checked = true;
                enableLatLon(true);

                //Now set the form controls with the array values
                txtJobNumber.Text = userSettingsArray[0];
                txtHoleID.Text = userSettingsArray[1];
                txtRigID.Text = userSettingsArray[2];

                if (userSettingsArray[3].CompareTo("0") == 0)
                {
                    txtLongitude.Text = String.Empty;
                }
                else
                {
                    txtLongitude.Text = userSettingsArray[3];
                }

                if (userSettingsArray[4].CompareTo("0") == 0)
                {
                    txtLatitude.Text = String.Empty;
                }
                else
                {
                    txtLatitude.Text = userSettingsArray[4];
                }
                
                decimalLon = userSettingsArray[3];
                decimalLat = userSettingsArray[4];

                txtWirelineRate.Text = userSettingsArray[5];
                txtDrillingRate.Text = userSettingsArray[6];
                //cboHoleSize.SelectedIndex = int.Parse(userSettingsArray[7]);
                cboHoleSize.SelectedIndex = cboHoleSize.Items.IndexOf(userSettingsArray[7]);  

                txtHoleInclination.Text = userSettingsArray[8];
                
                //cboDrillRods.SelectedIndex = int.Parse(userSettingsArray[9]);
                cboDrillRods.SelectedIndex = cboDrillRods.Items.IndexOf(userSettingsArray[9]);  

                //cboTubeHead.SelectedIndex = int.Parse(userSettingsArray[10]);
                cboTubeHead.SelectedIndex = cboTubeHead.Items.IndexOf(userSettingsArray[10]);

                //cboCoreBarrelLength.SelectedIndex = int.Parse(userSettingsArray[11]);
                cboCoreBarrelLength.SelectedIndex = cboCoreBarrelLength.Items.IndexOf(userSettingsArray[11]);

                //cboOverShotSize.SelectedIndex = int.Parse(userSettingsArray[12]);
                cboOverShotSize.SelectedIndex = cboOverShotSize.Items.IndexOf(userSettingsArray[12]);

                //cboCoreOrientation.SelectedIndex = int.Parse(userSettingsArray[13]);
                cboCoreOrientation.SelectedIndex = cboCoreOrientation.Items.IndexOf(userSettingsArray[13]);

                //cboCoreOrientationbypass.SelectedIndex = int.Parse(userSettingsArray[14]);
                cboCoreOrientationbypass.SelectedIndex = cboCoreOrientationbypass.Items.IndexOf(userSettingsArray[14]);

                txtDepthWaterTable.Text = userSettingsArray[15];
            }
        }
        
        private void loadMajorDrillingOffices()
        {
            //List of Major Drilling Offices. This list is Static

            //Coordinates: 
            //RADIANS: http://home.online.no/~sigurdhu/Deg_formats.htm
            //UTM CONVERTER: http://home.hiwaay.net/~taylorc/toolbox/geography/geoutm.html
            //Another UTM? : http://www.uwgb.edu/DutchS/FieldMethods/UTMSystem.htm

            /* KML Structure */
            /*
                <?xml version="1.0" encoding="UTF-8"?>
                <kml xmlns="http://earth.google.com/kml/2.2">
                <Document>
                  <name>Major Drilling</name>
                  <description><![CDATA[]]></description>
                  <NetworkLink>
                    <Url>
                      <name>Major Drilling</name>
                      <href>http://maps.google.ca/maps/ms?hl=en&amp;ie=UTF8&amp;oe=UTF8&amp;msa=0&amp;msid=108874607583291668314.00043b39fd3544dbffa9b&amp;output=kml</href>
                    </Url>
                  </NetworkLink>
                </Document>
                </kml>
             */

            /*
            Major Drilling Group International - Corporate Headoffice (lat=46.08847, lon=-64.777451)
            Major Drilling Group International Inc. - Val d'Or (lat=48.113701, lon=-77.783775)
            Major Drilling Group International Inc. - Sudbury (lat=46.512466, lon=-80.930008)
            Major Drilling Group International Inc. - Winnipeg (lat=49.892399, lon=-97.26413)
            Major Drilling Group International Inc. - Flin Flon (lat=54.76429, lon=-101.869339)
            Major Drilling Group International Inc. – Saskatoon (lat=52.05249, lon=-106.875)
            Major Drilling Group International Inc. - Yellowknife (lat=62.593342, lon=-116.015625)
            Forage Major Kennebec Drilling Ltd. - Thetford Mines, QC (lat=46.164616, lon=-71.191406)
            Major Drilling America, Inc. - Salt Lake City, Utah (lat=40.721085, lon=-111.986717)
            Major Drilling America, INC - Elko, Nevada (lat=40.835434, lon=-115.759773)
            Major Drilling International Inc. - Barbados, West Indies (lat=13.132979, lon=-59.534912)
            Major Drilling De Mexico, S.A. De C.V. - Hermosillo, Sonora, Mexico (lat=29.026123, lon=-110.918304)
            Majortec Perforaciones S.A. - Bolivar, Venezuela (lat=6.026663, lon=-63.826141)
            Major Perforaciones S.A. - Mendoza, Argentina (lat=-32.892719, lon=-68.833099)
            Forage Major Guyane SARL - Guyane Française, S.A(lat=5, lon=-59)
            Major Drilling Chile S.A. (lat=-29.966564, lon=-71.333267)
            Major Drilling Pty Ltd - Brisbane, Australia (lat=-27.527758, lon=152.226562)
            Major Chile S.A. - Antofagasta, Chile (lat=-23.64126, lon=-70.399384)
            Major Drilling Pty Ltd - Townsville, Australia(lat=-19.263441, lon=146.767761)
            Major Drilling Pty Ltd - Orange, Australia (lat=-33.309887, lon=149.111099)
            Major Drilling Pty Ltd - Kalgoorlie, Australia (lat=-30.784281, lon=121.440773)
            Pt Pontil Indonesia - Jakarta, Indonesia (lat=-6.217438, lon=106.813156)
            Major Drilling Mongolia LLC - Ulaanbaatar, Mongolia (lat=48.033562, lon=106.561203)
            Major Drilling Botswana (PTY) Limited - Francistown, Botswana (lat=-21.167049, lon=27.4909)
            Major Drilling Namibia (PTY) Limited - Windhoek, Namibia (lat=-22.56485, lon=17.0931)
            Major Drilling South Africa (PTY) Limited - Centurion, South Africa (lat=-25.747334, lon=28.184395)
            Major Drilling Tanzania Limited - Mwanza, Tanzania (lat=-2.476803, lon=32.947777)       
            */

            //List<string> listOffices = new List<string>();
            //hashOfficeLocations.Add("Corporate Headoffice");

            listOfficeLocations.Items.Add("Corporate Headoffice");
            listOfficeLocations.Items.Add("Val d'Or");
            listOfficeLocations.Items.Add("Sudbury");
            listOfficeLocations.Items.Add("Winnipeg");
            listOfficeLocations.Items.Add("Flin Flon");
            listOfficeLocations.Items.Add("Saskatoon");
            listOfficeLocations.Items.Add("Yellowknife");
            listOfficeLocations.Items.Add("Thetford Mines, QC");
            listOfficeLocations.Items.Add("Salt Lake City, Utah");
            listOfficeLocations.Items.Add("Elko, Nevada");
            listOfficeLocations.Items.Add("Barbados, West Indies");
            listOfficeLocations.Items.Add("Hermosillo, Sonora, Mexico");
            listOfficeLocations.Items.Add("Bolivar, Venezuela");
            listOfficeLocations.Items.Add("Mendoza, Argentina");
            listOfficeLocations.Items.Add("Guyane Française, S.A");
            listOfficeLocations.Items.Add("Chile S.A.");
            listOfficeLocations.Items.Add("Brisbane, Australia");
            listOfficeLocations.Items.Add("Antofagasta, Chile");
            listOfficeLocations.Items.Add("Townsville, Australia");
            listOfficeLocations.Items.Add("Orange, Australia");
            listOfficeLocations.Items.Add("Kalgoorlie, Australia");
            listOfficeLocations.Items.Add("Jakarta, Indonesia");
            listOfficeLocations.Items.Add("Ulaanbaatar, Mongolia");
            listOfficeLocations.Items.Add("Francistown, Botswana");
            listOfficeLocations.Items.Add("Windhoek, Namibia");
            listOfficeLocations.Items.Add("Centurion, South Africa");
            listOfficeLocations.Items.Add("Mwanza, Tanzania");
            
            listOfficeLocations.Sorted = true;
            
            //Hashtable hashOfficeLocations = new Hashtable();
                                                                //lat   //long
            hashOfficeLocations.Add("Corporate Headoffice", "46.0884,-64.7774");
            hashOfficeLocations.Add("Val d'Or", "48.1137,-77.7837");
            hashOfficeLocations.Add("Sudbury", "46.5124,-80.9300");
            hashOfficeLocations.Add("Winnipeg", "49.8923,-97.2641");
            hashOfficeLocations.Add("Flin Flon", "54.7642,-101.8693");
            hashOfficeLocations.Add("Saskatoon", "52.0524,-106.875");
            hashOfficeLocations.Add("Yellowknife", "62.5933,-116.0156");
            hashOfficeLocations.Add("Thetford Mines, QC", "46.1646,-71.1914");
            hashOfficeLocations.Add("Salt Lake City, Utah", "40.7210,-111.9867");
            hashOfficeLocations.Add("Elko, Nevada", "40.8354,-115.7597");
            hashOfficeLocations.Add("Barbados, West Indies", "13.1329,-59.5349");
            hashOfficeLocations.Add("Hermosillo, Sonora, Mexico", "29.0261,-110.9183");
            hashOfficeLocations.Add("Bolivar, Venezuela", "6.0266,-63.8261");
            hashOfficeLocations.Add("Mendoza, Argentina", "-32.8927,-68.8330");
            hashOfficeLocations.Add("Guyane Française, S.A", "5,-59");
            hashOfficeLocations.Add("Chile S.A.", "29.9665,-71.3332");
            hashOfficeLocations.Add("Brisbane, Australia", "-27.5277,152.2265");
            hashOfficeLocations.Add("Antofagasta, Chile", "-23.6412,-70.3993");
            hashOfficeLocations.Add("Townsville, Australia", "-19.2634,146.7677");
            hashOfficeLocations.Add("Orange, Australia", "-33.3098,149.1110");
            hashOfficeLocations.Add("Kalgoorlie, Australia", "-30.7842,121.4407");
            hashOfficeLocations.Add("Jakarta, Indonesia", "-6.2174,106.8131");
            hashOfficeLocations.Add("Ulaanbaatar, Mongolia", "48.0335,106.5612");
            hashOfficeLocations.Add("Francistown, Botswana", "-21.1670,27.4909");
            hashOfficeLocations.Add("Windhoek, Namibia", "-22.5648,17.0931");
            hashOfficeLocations.Add("Centurion, South Africa", "-25.7473,28.1843");
            hashOfficeLocations.Add("Mwanza, Tanzania", "-2.4768,32.9477");
            
            //return hashOfficeLocations;

        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            if (listOfficeLocations.Visible)
                listOfficeLocations.Visible = false;
            else
                listOfficeLocations.Visible = true;
        }

        private void listOfficeLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            listOfficeLocations.Visible = false;
            string[] longlat = hashOfficeLocations[((ListBox)sender).SelectedItem.ToString()].ToString().Split(',');
            
            //decimalLon = longlat[0];
            //decimalLat = longlat[1];

            decimalLat = longlat[0];
            decimalLon = longlat[1];

            radioFlag = "decimal";
            radioDecimal.Checked = true;

            enableLatLon(true);
            //txtLongitude.Enabled = true;
            //txtLatitude.Enabled = true;

            //txtLongitude.Text = longlat[0];
            //txtLatitude.Text = longlat[1];

            txtLongitude.Text = decimalLon;
            txtLatitude.Text = decimalLat;


        }

        private void updateCoordinates(string previousType, string newType)
        {
            //update the main coordinates based on the type everytime the user clicks a radio button

            //Only do the conversion if the types changed and if there are values in the previousTypes
            if (previousType.CompareTo(newType) != 0)//  && checkifValuesExist(previousType)) 
            {
                if(previousType.CompareTo("gps") == 0)
                {
                    convertGPSToDecimal(false);
                }
                else if (previousType.CompareTo("utm") == 0)
                {                    
                    convertUTMToDecimal(false);
                }
                else if (previousType.CompareTo("decimal") == 0)
                {
                    ; //Do Nothing, it's already in Decimal
                }
                else if (previousType.CompareTo("radian") == 0)                 
                {
                    convertRadianToDecimal(false);
                }
                else
                {
                    MessageBox.Show("Invalid Coordinate Type");
                }

                //Now let's convert the decimal coordinates with what the user has selected in the radio options.
                if (newType.CompareTo("gps") == 0)
                {
                    //Convert from Decimal to GPS
                    
                    convertGPSToDecimal(true);

                    /*
                    txtGPSLongDeg.Text = gpsLongDeg;
                    txtGPSLongMin.Text = gpsLongMin;
                    txtGPSLongSec.Text = gpsLongSec;

                    if (eastWest.CompareTo("E") == 0)
                        cboEastWest.SelectedIndex = 0;
                    if (eastWest.CompareTo("W") == 0)
                        cboEastWest.SelectedIndex = 1;

                    txtGPSLatDeg.Text = gpsLatDeg;
                    txtGPSLatMin.Text = gpsLatMin;
                    txtGPSLatSec.Text = gpsLatSec;

                    if (northSouth.CompareTo("N") == 0)
                        cboNorthSouth.SelectedIndex = 0;
                    if (northSouth.CompareTo("S") == 0)
                        cboNorthSouth.SelectedIndex = 1;
                    */
                }
                else if (newType.CompareTo("decimal") == 0)
                {
                    //Don't do any conversion, it's already decimal
                    
                    //Update the textboxes with the new values
                    /*
                    txtLongitude.Text = decimalLon;
                    txtLatitude.Text = decimalLat;

                    txtLatitude.Enabled = true;
                    txtLongitude.Enabled = true;
                    */
                }
                else if (newType.CompareTo("utm") == 0)
                {
                    //MPoirier: UNSUPPORTED
                    ;
                }
                else if (newType.CompareTo("radian") == 0)
                {
                    //Convert from Decimal to Radian
                    convertRadianToDecimal(true);

                    /*
                    //Update the textboxes with the new values
                    txtLongitude.Text = radLon;
                    txtLatitude.Text = radLat;

                    txtLatitude.Enabled = true;
                    txtLongitude.Enabled = true;
                    */
                }
            }
        }

        private void convertGPSToDecimal(bool isReversed)
        {
            if (isReversed) //If we need to do the reverse conversion (Decimal to GPS)
            {
                /*
                    I.E.: 121.135
                    0.135 * 60 = 8.1 (The whole number becomes minutes)
                    .1 * 60 = 6 (Seconds)
                    121 degrees, 8 mins and 6 seconds
                */


                //////////////////////////////////////////  LATITUDE  ////////////////////////////////////////////////////////

                //Latitude
                double minutes = 0.0;
                double seconds = 0.0;
                int wholeNumber = 0;
                string selector = string.Empty;

                wholeNumber = int.Parse((decimalLat.Split('.'))[0]);                    //121 (Degrees)

                if (wholeNumber < 0)
                    selector = "S";
                else
                    selector = "N";

                //Strip out the '-' if present

                if (wholeNumber.ToString().IndexOf('-') != -1)
                {
                    string strWholeNumber = wholeNumber.ToString();
                    strWholeNumber = strWholeNumber.Remove(strWholeNumber.IndexOf('-'), 1);
                    wholeNumber = int.Parse(strWholeNumber);
                }
                
                
                //If there is a decimal value in the coordinate that needs parsing      //(0.135)
                if (decimalLat.IndexOf('.') > 0)
                {
                    string strMinutes = "0." + (decimalLat.Split('.'))[1];
                    minutes = double.Parse(strMinutes) * 60;                            //0.135 * 60 (this SHOULD return 8.1)
                    strMinutes = minutes.ToString();                                    //8.1 in string

                    //If there is a decimal value that needs parsing further (seconds)  //(8.1)
                    if (strMinutes.IndexOf('.') > 0)
                    {
                        minutes = double.Parse((strMinutes.Split('.'))[0]);
                        
                        seconds = double.Parse((strMinutes.Split('.'))[1]);
                        string strSeconds = "0." + seconds.ToString();
                        seconds = double.Parse(strSeconds) * 60;
                        strSeconds = seconds.ToString();
                        if (strSeconds.IndexOf('.') > 0)
                            seconds = int.Parse((strSeconds.Split('.'))[0]);
                    }
                    else
                        seconds = 0;
                }
                else
                {
                    minutes = 0;
                    seconds = 0;
                }

                gpsLatDeg = wholeNumber.ToString();
                gpsLatMin = minutes.ToString();
                gpsLatSec = seconds.ToString();
                northSouth = selector;


                //////////////////////////////////////////  LONGITUDE  ////////////////////////////////////////////////////////

                //Longitude
                minutes = 0.0;
                seconds = 0.0;
                wholeNumber = 0;
                selector = string.Empty;

                wholeNumber = int.Parse((decimalLon.Split('.'))[0]);                    //121 (Degrees)

                if (wholeNumber < 0)
                    selector = "W";
                else
                    selector = "E";

                //Strip out the '-' if present

                if (wholeNumber.ToString().IndexOf('-') != -1)
                {
                    string strWholeNumber = wholeNumber.ToString();
                    strWholeNumber = strWholeNumber.Remove(strWholeNumber.IndexOf('-'), 1);
                    wholeNumber = int.Parse(strWholeNumber);
                }

                //If there is a decimal value in the coordinate that needs parsing      //(0.135)
                if (decimalLon.IndexOf('.') > 0)
                {
                    string strMinutes = "0." + (decimalLon.Split('.'))[1];
                    minutes = double.Parse(strMinutes) * 60;                            //0.135 * 60 (this SHOULD return 8.1)
                    strMinutes = minutes.ToString();                                    //8.1 in string

                    //If there is a decimal value that needs parsing further (seconds)  //(8.1)
                    if (strMinutes.IndexOf('.') > 0)
                    {
                        minutes = double.Parse((strMinutes.Split('.'))[0]);

                        seconds = double.Parse((strMinutes.Split('.'))[1]);
                        string strSeconds = "0." + seconds.ToString();
                        seconds = double.Parse(strSeconds) * 60;
                        strSeconds = seconds.ToString();
                        if (strSeconds.IndexOf('.') > 0)
                            seconds = int.Parse((strSeconds.Split('.'))[0]);
                    }
                    else
                        seconds = 0;
                }
                else
                {
                    minutes = 0;
                    seconds = 0;
                }

                gpsLongDeg = wholeNumber.ToString();
                gpsLongMin = minutes.ToString();
                gpsLongSec = seconds.ToString();
                eastWest = selector;

            }
            else
            {
                //Converting GPS to Decimal

                /*                       (degree)      (Minutes)            (Seconds)
                    decimalCoordinate = dblValue0 + (dblValue1/60.0) + (dblValue2/3060.0);
                  
                 --> Then if it's W or S, add "-"
                */

                //////////////////////////////////////////  LATITUDE  ////////////////////////////////////////////////////////

                string degrees = gpsLatDeg;
                string minutes = gpsLatMin;
                string seconds = gpsLatSec;
                string selector = northSouth;

                double doubleDecimal = 0.0;

                doubleDecimal = double.Parse(degrees) + ((double.Parse(minutes)) / 60.0) + ((double.Parse(seconds)) / 3600.0);
                doubleDecimal = Math.Round(doubleDecimal, 4);
                decimalLat = doubleDecimal.ToString();

                if (selector.CompareTo("S") == 0)
                    decimalLat = "-" + decimalLat;

                //////////////////////////////////////////  LONGITUDE  ////////////////////////////////////////////////////////

                //degrees = (gpsLon.Split(' '))[0];
                degrees = gpsLongDeg;
                //minutes = (gpsLon.Split(' '))[1];
                minutes = gpsLongMin;
                //seconds = (gpsLon.Split(' '))[2];
                seconds = gpsLongSec;
                //selector = (gpsLon.Split(' '))[3];
                selector = eastWest;

                doubleDecimal = 0.0;

                doubleDecimal = double.Parse(degrees) + ((double.Parse(minutes)) / 60.0) + ((double.Parse(seconds)) / 3600.0);
                doubleDecimal = Math.Round(doubleDecimal, 4);
                decimalLon = doubleDecimal.ToString();

                if (selector.CompareTo("W") == 0)
                    decimalLon = "-" + decimalLon;
            }
        }

        private void convertUTMToDecimal(bool isReversed)
        {
            //UTM CURRENTLY NOT SUPPORTED
            if (isReversed) //If we need to do the reverse conversion
            {
                ;
            }
            else
            {
                ;
            }
        }

        private void convertRadianToDecimal(bool isReversed)
        {
            if (isReversed) //If we need to do the reverse conversion
            {
                //Decimal to Radian
                /*
                    From decimal-degrees (d) to radians (r) (circle = 2π radians)
                    r = d × π/180 
                    Example: d = 58.65375°
                    r = 58.65375 radians × π/180 = 1.023701 radians
                */

                double doubleRadLat = double.Parse(decimalLat) * (Math.PI / 180);
                doubleRadLat = Math.Round(doubleRadLat, 6);
                radLat = doubleRadLat.ToString();

                double doubleRadLon = double.Parse(decimalLon) * (Math.PI / 180);
                doubleRadLon = Math.Round(doubleRadLon, 6);
                radLon = doubleRadLon.ToString();
            }
            else
            {
                //Radian to Decimal
                /*
                    From radians (r) (circle = 2π radians) to decimal-degrees (d)
                    d = r × 180/π 
                    Example: r = 1.023701 radians
                    d = 1.023701° × 180/π = 58.65375° 
                */

                double doubleDecimalLat = double.Parse(radLat) * (180 / Math.PI);
                doubleDecimalLat = Math.Round(doubleDecimalLat, 4);
                decimalLat = doubleDecimalLat.ToString();

                double doubleDecimalLon = double.Parse(radLon) * (180 / Math.PI);
                doubleDecimalLon = Math.Round(doubleDecimalLon, 4);
                decimalLon = doubleDecimalLon.ToString();
            }
        }

        private void txtLongitude_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckForCharacter(txtLongitude.Text, "Longitude", ","))
            {
                txtLongitude.Focus();
            }
            if (!ValidateControl(txtLongitude.Text, "Longitude", true, true, false))
                txtLongitude.Text = String.Empty;
                //txtLongitude.Text = "0";
            
            if (radioFlag.CompareTo("decimal") == 0)
            {
                if (txtLongitude.Text.CompareTo(String.Empty) == 0)
                {
                    decimalLon = "0";
                }
                else
                {
                    decimalLon = txtLongitude.Text;
                }
            }
            else if (radioFlag.CompareTo("radian") == 0)
            {
                if (txtLongitude.Text.CompareTo(String.Empty) == 0)
                {
                    radLon = "0";
                }
                else
                {
                    radLon = txtLongitude.Text;
                }
            }
        }

        private void txtLatitude_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckForCharacter(txtLatitude.Text, "Latitude", ","))
            {
                txtLatitude.Focus();
            }

            if (!ValidateControl(txtLatitude.Text, "Latitude", true, true, false))
                txtLatitude.Text = String.Empty;
                //txtLatitude.Text = "0";

            if (radioFlag.CompareTo("decimal") == 0)
            {
                if (txtLatitude.Text.CompareTo(String.Empty) == 0)
                {
                    decimalLat = "0";
                }
                else
                {
                    decimalLat = txtLatitude.Text;
                }
            }
            else if (radioFlag.CompareTo("radian") == 0)
            {
                if (txtLatitude.Text.CompareTo(String.Empty) == 0)
                {
                    radLat = "0";
                }
                else
                {
                    radLat = txtLatitude.Text;
                }
            }
        }

        private void txtGPSLongDeg_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtGPSLongDeg.Text, "GPS Longitude Degree", true, true, false))
                txtGPSLongDeg.Text = "0";

            gpsLongDeg = txtGPSLongDeg.Text;
        }

        private void txtGPSLongMin_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtGPSLongMin.Text, "GPS Longitude Minute", true, true, false))
                txtGPSLongMin.Text = "0";

            gpsLongMin = txtGPSLongMin.Text;
        }

        private void txtGPSLongSec_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtGPSLongSec.Text, "GPS Longitude Second", true, true, false))
                txtGPSLongSec.Text = "0";
            
            gpsLongSec = txtGPSLongSec.Text;
        }

        private void txtGPSLatDeg_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtGPSLatDeg.Text, "GPS Latitude Degree", true, true, false))
                txtGPSLatDeg.Text = "0";

            gpsLatDeg = txtGPSLatDeg.Text;
        }

        private void txtGPSLatMin_Validating(object sender, CancelEventArgs e)
        {                                               
            if (!ValidateControl(txtGPSLatMin.Text, "GPS Latitude Minute", true, true, false))
                txtGPSLatMin.Text = "0";

            gpsLatMin = txtGPSLatMin.Text;
        }

        private void txtGPSLatSec_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateControl(txtGPSLatSec.Text, "GPS Latitude Second", true, true, false))
                txtGPSLatSec.Text = "0";

            gpsLatSec = txtGPSLatSec.Text;
        }

        private void cboEastWest_Validating(object sender, CancelEventArgs e)
        {
            //There can only be "GPS" selected if we see this textbox.
            if (radioFlag.CompareTo("gps") == 0)
            {
                if (cboEastWest.SelectedIndex == 0)
                    eastWest = "E";
                if (cboEastWest.SelectedIndex == 1)
                    eastWest = "W";
            }
        }

        private void cboNorthSouth_Validating(object sender, CancelEventArgs e)
        {
            //There can only be "GPS" selected if we see this textbox.
            if (radioFlag.CompareTo("gps") == 0)
            {
                if (cboNorthSouth.SelectedIndex == 0)
                    northSouth = "N";
                else
                    northSouth = "S";
            }
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            //Check to make sure at least one type of coordinate was completely entered by the user
            
            //check if gps coordinates
            if (radioFlag.CompareTo("gps") == 0)
            {
                if (!ValidateControl(gpsLongDeg, "GPS Longitude Degree", false, true, true))
                {
                    txtGPSLongDeg.Focus(); 
                    return;
                }
                else if (!ValidateControl(gpsLongMin, "GPS Longitude Minute", false, true, true))
                {
                    txtGPSLongMin.Focus(); 
                    return;
                }
                else if (!ValidateControl(gpsLongSec, "GPS Longitude Sec", false, true, true))
                {
                    txtGPSLongSec.Focus(); 
                    return;
                }
                else if (!ValidateControl(gpsLatDeg, "GPS Latitude Degree", false, true, true))
                {
                    txtGPSLatDeg.Focus(); 
                    return;
                }
                else if (!ValidateControl(gpsLatMin, "GPS Latitude Minute", false, true, true))
                {
                    txtGPSLatMin.Focus(); 
                    return;
                }
                else if (!ValidateControl(gpsLatSec, "GPS Latitude Second", false, true, true))
                {
                    txtGPSLatSec.Focus(); 
                    return;
                }
            }
            else if (radioFlag.CompareTo("decimal") == 0)
            {
                if (!ValidateControl(decimalLon, "Decimal Longitude", false, true, true))
                {
                    txtLongitude.Focus();
                    return;
                }
                else if (!ValidateControl(decimalLat, "Decimal Latitude", false, true, true))
                {
                    txtLatitude.Focus();
                    return;
                }
            }
            else if (radioFlag.CompareTo("radian") == 0)
            {
                if (!ValidateControl(radLon, "Radian Longitude", false, true, true))
                {
                    txtLongitude.Focus();
                    return;
                }
                else if (!ValidateControl(radLat, "Radian Latitude", false, true, true))
                {
                    txtLatitude.Focus();
                    return;
                }
            }
        }

        // IsNumeric Function
        static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            if (Convert.ToString(Expression).CompareTo(string.Empty) == 0)
                return true;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

    }
}