namespace md1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lbl15 = new System.Windows.Forms.Label();
            this.lbl16 = new System.Windows.Forms.Label();
            this.cboHoleSize = new System.Windows.Forms.ComboBox();
            this.cboDrillRods = new System.Windows.Forms.ComboBox();
            this.cboTubeHead = new System.Windows.Forms.ComboBox();
            this.cboCoreBarrelLength = new System.Windows.Forms.ComboBox();
            this.cboOverShotSize = new System.Windows.Forms.ComboBox();
            this.cboCoreOrientation = new System.Windows.Forms.ComboBox();
            this.cboCoreOrientationbypass = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtJobNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtHoleID = new System.Windows.Forms.MaskedTextBox();
            this.txtRigID = new System.Windows.Forms.MaskedTextBox();
            this.txtLongitude = new System.Windows.Forms.MaskedTextBox();
            this.txtLatitude = new System.Windows.Forms.MaskedTextBox();
            this.txtWirelineRate = new System.Windows.Forms.MaskedTextBox();
            this.txtDrillingRate = new System.Windows.Forms.MaskedTextBox();
            this.txtHoleInclination = new System.Windows.Forms.MaskedTextBox();
            this.txtDepthWaterTable = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioGPS = new System.Windows.Forms.RadioButton();
            this.radioUTM = new System.Windows.Forms.RadioButton();
            this.radioDecimal = new System.Windows.Forms.RadioButton();
            this.radioRadian = new System.Windows.Forms.RadioButton();
            this.panelRadio = new System.Windows.Forms.Panel();
            this.btnOffice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNorthSouth = new System.Windows.Forms.ComboBox();
            this.cboEastWest = new System.Windows.Forms.ComboBox();
            this.txtGPSLatSec = new System.Windows.Forms.MaskedTextBox();
            this.txtGPSLatMin = new System.Windows.Forms.MaskedTextBox();
            this.txtGPSLatDeg = new System.Windows.Forms.MaskedTextBox();
            this.txtGPSLongSec = new System.Windows.Forms.MaskedTextBox();
            this.txtGPSLongMin = new System.Windows.Forms.MaskedTextBox();
            this.txtGPSLongDeg = new System.Windows.Forms.MaskedTextBox();
            this.listOfficeLocations = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRadio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(510, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(24, 32);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Job Number:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(24, 61);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(56, 16);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Hole ID:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(24, 90);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(48, 16);
            this.lbl3.TabIndex = 3;
            this.lbl3.Text = "Rig ID:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(362, 20);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(184, 16);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Wireline Rate (feet or meters):";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(15, 87);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(89, 16);
            this.lblLatitude.TabIndex = 5;
            this.lblLatitude.Text = "GPS Latitude:";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(15, 58);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(101, 16);
            this.lblLongitude.TabIndex = 4;
            this.lblLongitude.Text = "GPS Longitude:";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(362, 195);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(122, 16);
            this.lbl7.TabIndex = 12;
            this.lbl7.Text = "Core Barrel Length:";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.Location = new System.Drawing.Point(362, 166);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(80, 16);
            this.lbl8.TabIndex = 11;
            this.lbl8.Text = "Tube Head:";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.Location = new System.Drawing.Point(362, 137);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(70, 16);
            this.lbl9.TabIndex = 10;
            this.lbl9.Text = "Drill Rods:";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.Location = new System.Drawing.Point(362, 108);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(102, 16);
            this.lbl10.TabIndex = 9;
            this.lbl10.Text = "Hole Inclination:";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.Location = new System.Drawing.Point(362, 78);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(69, 16);
            this.lbl11.TabIndex = 8;
            this.lbl11.Text = "Hole Size:";
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.Location = new System.Drawing.Point(362, 49);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(170, 16);
            this.lbl12.TabIndex = 7;
            this.lbl12.Text = "Drilling Rate (inches or cm):";
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl13.Location = new System.Drawing.Point(362, 311);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(125, 16);
            this.lbl13.TabIndex = 16;
            this.lbl13.Text = "Depth Water Table:";
            // 
            // lbl14
            // 
            this.lbl14.AutoSize = true;
            this.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl14.Location = new System.Drawing.Point(362, 282);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(156, 16);
            this.lbl14.TabIndex = 15;
            this.lbl14.Text = "Core Orientation Bypass:";
            // 
            // lbl15
            // 
            this.lbl15.AutoSize = true;
            this.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl15.Location = new System.Drawing.Point(362, 253);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(107, 16);
            this.lbl15.TabIndex = 14;
            this.lbl15.Text = "Core Orientation:";
            // 
            // lbl16
            // 
            this.lbl16.AutoSize = true;
            this.lbl16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl16.Location = new System.Drawing.Point(362, 224);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(99, 16);
            this.lbl16.TabIndex = 13;
            this.lbl16.Text = "Over Shot Size:";
            // 
            // cboHoleSize
            // 
            this.cboHoleSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoleSize.FormattingEnabled = true;
            this.cboHoleSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboHoleSize.Location = new System.Drawing.Point(561, 72);
            this.cboHoleSize.MaxDropDownItems = 100;
            this.cboHoleSize.Name = "cboHoleSize";
            this.cboHoleSize.Size = new System.Drawing.Size(100, 21);
            this.cboHoleSize.TabIndex = 13;
            this.cboHoleSize.Validating += new System.ComponentModel.CancelEventHandler(this.cboHoleSize_Validating);
            this.cboHoleSize.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboDrillRods
            // 
            this.cboDrillRods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrillRods.FormattingEnabled = true;
            this.cboDrillRods.Location = new System.Drawing.Point(561, 136);
            this.cboDrillRods.MaxDropDownItems = 100;
            this.cboDrillRods.Name = "cboDrillRods";
            this.cboDrillRods.Size = new System.Drawing.Size(100, 21);
            this.cboDrillRods.TabIndex = 15;
            this.cboDrillRods.Validating += new System.ComponentModel.CancelEventHandler(this.cboDrillRods_Validating);
            this.cboDrillRods.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboTubeHead
            // 
            this.cboTubeHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTubeHead.FormattingEnabled = true;
            this.cboTubeHead.Location = new System.Drawing.Point(561, 165);
            this.cboTubeHead.MaxDropDownItems = 100;
            this.cboTubeHead.Name = "cboTubeHead";
            this.cboTubeHead.Size = new System.Drawing.Size(100, 21);
            this.cboTubeHead.TabIndex = 16;
            this.cboTubeHead.Validating += new System.ComponentModel.CancelEventHandler(this.cboTubeHead_Validating);
            this.cboTubeHead.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboCoreBarrelLength
            // 
            this.cboCoreBarrelLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoreBarrelLength.FormattingEnabled = true;
            this.cboCoreBarrelLength.Location = new System.Drawing.Point(561, 194);
            this.cboCoreBarrelLength.MaxDropDownItems = 100;
            this.cboCoreBarrelLength.Name = "cboCoreBarrelLength";
            this.cboCoreBarrelLength.Size = new System.Drawing.Size(100, 21);
            this.cboCoreBarrelLength.TabIndex = 17;
            this.cboCoreBarrelLength.Validating += new System.ComponentModel.CancelEventHandler(this.cboCoreBarrelLength_Validating);
            this.cboCoreBarrelLength.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboOverShotSize
            // 
            this.cboOverShotSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverShotSize.FormattingEnabled = true;
            this.cboOverShotSize.Location = new System.Drawing.Point(561, 223);
            this.cboOverShotSize.MaxDropDownItems = 100;
            this.cboOverShotSize.Name = "cboOverShotSize";
            this.cboOverShotSize.Size = new System.Drawing.Size(100, 21);
            this.cboOverShotSize.TabIndex = 18;
            this.cboOverShotSize.Validating += new System.ComponentModel.CancelEventHandler(this.cboOverShotSize_Validating);
            this.cboOverShotSize.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboCoreOrientation
            // 
            this.cboCoreOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoreOrientation.FormattingEnabled = true;
            this.cboCoreOrientation.Location = new System.Drawing.Point(561, 252);
            this.cboCoreOrientation.MaxDropDownItems = 100;
            this.cboCoreOrientation.Name = "cboCoreOrientation";
            this.cboCoreOrientation.Size = new System.Drawing.Size(100, 21);
            this.cboCoreOrientation.TabIndex = 19;
            this.cboCoreOrientation.Validating += new System.ComponentModel.CancelEventHandler(this.cboCoreOrientation_Validating);
            this.cboCoreOrientation.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // cboCoreOrientationbypass
            // 
            this.cboCoreOrientationbypass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoreOrientationbypass.FormattingEnabled = true;
            this.cboCoreOrientationbypass.Location = new System.Drawing.Point(561, 281);
            this.cboCoreOrientationbypass.MaxDropDownItems = 100;
            this.cboCoreOrientationbypass.Name = "cboCoreOrientationbypass";
            this.cboCoreOrientationbypass.Size = new System.Drawing.Size(100, 21);
            this.cboCoreOrientationbypass.TabIndex = 20;
            this.cboCoreOrientationbypass.Validating += new System.ComponentModel.CancelEventHandler(this.cboCoreOrientationbypass_Validating);
            this.cboCoreOrientationbypass.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnClose.Location = new System.Drawing.Point(586, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Tag = "";
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.BeepOnError = true;
            this.txtJobNumber.HidePromptOnLeave = true;
            this.txtJobNumber.Location = new System.Drawing.Point(144, 27);
            this.txtJobNumber.Mask = "&&&&&&&&";
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(100, 20);
            this.txtJobNumber.TabIndex = 0;
            this.txtJobNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtJobNumber_Validating);
            this.txtJobNumber.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtHoleID
            // 
            this.txtHoleID.BeepOnError = true;
            this.txtHoleID.HidePromptOnLeave = true;
            this.txtHoleID.Location = new System.Drawing.Point(144, 57);
            this.txtHoleID.Mask = "&&&&&&&&";
            this.txtHoleID.Name = "txtHoleID";
            this.txtHoleID.Size = new System.Drawing.Size(100, 20);
            this.txtHoleID.TabIndex = 1;
            this.txtHoleID.Validating += new System.ComponentModel.CancelEventHandler(this.txtHoleID_Validating);
            this.txtHoleID.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtRigID
            // 
            this.txtRigID.BeepOnError = true;
            this.txtRigID.HidePromptOnLeave = true;
            this.txtRigID.Location = new System.Drawing.Point(144, 86);
            this.txtRigID.Mask = "&&&&&&&&";
            this.txtRigID.Name = "txtRigID";
            this.txtRigID.Size = new System.Drawing.Size(100, 20);
            this.txtRigID.TabIndex = 2;
            this.txtRigID.Validating += new System.ComponentModel.CancelEventHandler(this.txtRigID_Validating);
            this.txtRigID.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtLongitude
            // 
            this.txtLongitude.BeepOnError = true;
            this.txtLongitude.HidePromptOnLeave = true;
            this.txtLongitude.Location = new System.Drawing.Point(150, 54);
            this.txtLongitude.Mask = "#CCCCCCCC";
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 20);
            this.txtLongitude.TabIndex = 3;
            this.txtLongitude.Validating += new System.ComponentModel.CancelEventHandler(this.txtLongitude_Validating);
            this.txtLongitude.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtLatitude
            // 
            this.txtLatitude.BeepOnError = true;
            this.txtLatitude.HidePromptOnLeave = true;
            this.txtLatitude.Location = new System.Drawing.Point(150, 83);
            this.txtLatitude.Mask = "#CCCCCCCC";
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 20);
            this.txtLatitude.TabIndex = 4;
            this.txtLatitude.Validating += new System.ComponentModel.CancelEventHandler(this.txtLatitude_Validating);
            this.txtLatitude.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtWirelineRate
            // 
            this.txtWirelineRate.BeepOnError = true;
            this.txtWirelineRate.HidePromptOnLeave = true;
            this.txtWirelineRate.Location = new System.Drawing.Point(561, 15);
            this.txtWirelineRate.Mask = "000";
            this.txtWirelineRate.Name = "txtWirelineRate";
            this.txtWirelineRate.Size = new System.Drawing.Size(100, 20);
            this.txtWirelineRate.TabIndex = 11;
            this.txtWirelineRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtWirelineRate_Validating);
            this.txtWirelineRate.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtDrillingRate
            // 
            this.txtDrillingRate.BeepOnError = true;
            this.txtDrillingRate.HidePromptOnLeave = true;
            this.txtDrillingRate.Location = new System.Drawing.Point(561, 44);
            this.txtDrillingRate.Mask = "00";
            this.txtDrillingRate.Name = "txtDrillingRate";
            this.txtDrillingRate.Size = new System.Drawing.Size(100, 20);
            this.txtDrillingRate.TabIndex = 12;
            this.txtDrillingRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtDrillingRate_Validating);
            this.txtDrillingRate.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtHoleInclination
            // 
            this.txtHoleInclination.BeepOnError = true;
            this.txtHoleInclination.HidePromptOnLeave = true;
            this.txtHoleInclination.Location = new System.Drawing.Point(561, 102);
            this.txtHoleInclination.Mask = "-99";
            this.txtHoleInclination.Name = "txtHoleInclination";
            this.txtHoleInclination.Size = new System.Drawing.Size(100, 20);
            this.txtHoleInclination.TabIndex = 14;
            this.txtHoleInclination.Validating += new System.ComponentModel.CancelEventHandler(this.txtHoleInclination_Validating);
            this.txtHoleInclination.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // txtDepthWaterTable
            // 
            this.txtDepthWaterTable.BeepOnError = true;
            this.txtDepthWaterTable.HidePromptOnLeave = true;
            this.txtDepthWaterTable.Location = new System.Drawing.Point(561, 311);
            this.txtDepthWaterTable.Mask = "#####";
            this.txtDepthWaterTable.Name = "txtDepthWaterTable";
            this.txtDepthWaterTable.Size = new System.Drawing.Size(100, 20);
            this.txtDepthWaterTable.TabIndex = 22;
            this.txtDepthWaterTable.Validating += new System.ComponentModel.CancelEventHandler(this.txtDepthWaterTable_Validating);
            this.txtDepthWaterTable.Leave += new System.EventHandler(this.formControlLeaveFocus);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::md1.Properties.Resources.majorLogo;
            this.pictureBox1.Location = new System.Drawing.Point(27, 342);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // radioGPS
            // 
            this.radioGPS.AutoSize = true;
            this.radioGPS.Checked = true;
            this.radioGPS.Location = new System.Drawing.Point(9, 2);
            this.radioGPS.Name = "radioGPS";
            this.radioGPS.Size = new System.Drawing.Size(47, 17);
            this.radioGPS.TabIndex = 20;
            this.radioGPS.TabStop = true;
            this.radioGPS.Text = "GPS";
            this.radioGPS.UseVisualStyleBackColor = true;
            this.radioGPS.CheckedChanged += new System.EventHandler(this.radioGPS_CheckedChanged);
            // 
            // radioUTM
            // 
            this.radioUTM.AutoSize = true;
            this.radioUTM.Location = new System.Drawing.Point(64, 2);
            this.radioUTM.Name = "radioUTM";
            this.radioUTM.Size = new System.Drawing.Size(49, 17);
            this.radioUTM.TabIndex = 21;
            this.radioUTM.Text = "UTM";
            this.radioUTM.UseVisualStyleBackColor = true;
            this.radioUTM.CheckedChanged += new System.EventHandler(this.radioUTM_CheckedChanged);
            // 
            // radioDecimal
            // 
            this.radioDecimal.AutoSize = true;
            this.radioDecimal.Location = new System.Drawing.Point(119, 2);
            this.radioDecimal.Name = "radioDecimal";
            this.radioDecimal.Size = new System.Drawing.Size(63, 17);
            this.radioDecimal.TabIndex = 22;
            this.radioDecimal.Text = "Decimal";
            this.radioDecimal.UseVisualStyleBackColor = true;
            this.radioDecimal.CheckedChanged += new System.EventHandler(this.radioDecimal_CheckedChanged);
            // 
            // radioRadian
            // 
            this.radioRadian.AutoSize = true;
            this.radioRadian.Location = new System.Drawing.Point(188, 1);
            this.radioRadian.Name = "radioRadian";
            this.radioRadian.Size = new System.Drawing.Size(59, 17);
            this.radioRadian.TabIndex = 23;
            this.radioRadian.Text = "Radian";
            this.radioRadian.UseVisualStyleBackColor = true;
            this.radioRadian.CheckedChanged += new System.EventHandler(this.radioRadian_CheckedChanged);
            // 
            // panelRadio
            // 
            this.panelRadio.Controls.Add(this.radioGPS);
            this.panelRadio.Controls.Add(this.radioRadian);
            this.panelRadio.Controls.Add(this.radioUTM);
            this.panelRadio.Controls.Add(this.radioDecimal);
            this.panelRadio.Location = new System.Drawing.Point(3, 28);
            this.panelRadio.Name = "panelRadio";
            this.panelRadio.Size = new System.Drawing.Size(250, 17);
            this.panelRadio.TabIndex = 24;
            // 
            // btnOffice
            // 
            this.btnOffice.Location = new System.Drawing.Point(18, 121);
            this.btnOffice.Name = "btnOffice";
            this.btnOffice.Size = new System.Drawing.Size(98, 23);
            this.btnOffice.TabIndex = 25;
            this.btnOffice.Text = "Office Locations";
            this.btnOffice.UseVisualStyleBackColor = true;
            this.btnOffice.Click += new System.EventHandler(this.btnOffice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNorthSouth);
            this.groupBox1.Controls.Add(this.cboEastWest);
            this.groupBox1.Controls.Add(this.txtGPSLatSec);
            this.groupBox1.Controls.Add(this.txtGPSLatMin);
            this.groupBox1.Controls.Add(this.txtGPSLatDeg);
            this.groupBox1.Controls.Add(this.txtGPSLongSec);
            this.groupBox1.Controls.Add(this.txtGPSLongMin);
            this.groupBox1.Controls.Add(this.txtGPSLongDeg);
            this.groupBox1.Controls.Add(this.btnOffice);
            this.groupBox1.Controls.Add(this.txtLatitude);
            this.groupBox1.Controls.Add(this.lblLongitude);
            this.groupBox1.Controls.Add(this.txtLongitude);
            this.groupBox1.Controls.Add(this.lblLatitude);
            this.groupBox1.Controls.Add(this.panelRadio);
            this.groupBox1.Location = new System.Drawing.Point(27, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 164);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordinates";
            this.groupBox1.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox1_Validating);
            // 
            // cboNorthSouth
            // 
            this.cboNorthSouth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNorthSouth.FormattingEnabled = true;
            this.cboNorthSouth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboNorthSouth.Items.AddRange(new object[] {
            "North",
            "South"});
            this.cboNorthSouth.Location = new System.Drawing.Point(214, 82);
            this.cboNorthSouth.MaxDropDownItems = 100;
            this.cboNorthSouth.Name = "cboNorthSouth";
            this.cboNorthSouth.Size = new System.Drawing.Size(54, 21);
            this.cboNorthSouth.TabIndex = 10;
            this.cboNorthSouth.Validating += new System.ComponentModel.CancelEventHandler(this.cboNorthSouth_Validating);
            // 
            // cboEastWest
            // 
            this.cboEastWest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEastWest.FormattingEnabled = true;
            this.cboEastWest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboEastWest.Items.AddRange(new object[] {
            "East",
            "West"});
            this.cboEastWest.Location = new System.Drawing.Point(214, 54);
            this.cboEastWest.MaxDropDownItems = 100;
            this.cboEastWest.Name = "cboEastWest";
            this.cboEastWest.Size = new System.Drawing.Size(54, 21);
            this.cboEastWest.TabIndex = 6;
            this.cboEastWest.Validating += new System.ComponentModel.CancelEventHandler(this.cboEastWest_Validating);
            // 
            // txtGPSLatSec
            // 
            this.txtGPSLatSec.BeepOnError = true;
            this.txtGPSLatSec.HidePromptOnLeave = true;
            this.txtGPSLatSec.Location = new System.Drawing.Point(182, 83);
            this.txtGPSLatSec.Mask = "000";
            this.txtGPSLatSec.Name = "txtGPSLatSec";
            this.txtGPSLatSec.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLatSec.TabIndex = 9;
            this.txtGPSLatSec.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLatSec_Validating);
            // 
            // txtGPSLatMin
            // 
            this.txtGPSLatMin.BeepOnError = true;
            this.txtGPSLatMin.HidePromptOnLeave = true;
            this.txtGPSLatMin.Location = new System.Drawing.Point(152, 83);
            this.txtGPSLatMin.Mask = "000";
            this.txtGPSLatMin.Name = "txtGPSLatMin";
            this.txtGPSLatMin.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLatMin.TabIndex = 8;
            this.txtGPSLatMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLatMin_Validating);
            // 
            // txtGPSLatDeg
            // 
            this.txtGPSLatDeg.BeepOnError = true;
            this.txtGPSLatDeg.HidePromptOnLeave = true;
            this.txtGPSLatDeg.Location = new System.Drawing.Point(122, 83);
            this.txtGPSLatDeg.Mask = "000";
            this.txtGPSLatDeg.Name = "txtGPSLatDeg";
            this.txtGPSLatDeg.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLatDeg.TabIndex = 7;
            this.txtGPSLatDeg.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLatDeg_Validating);
            // 
            // txtGPSLongSec
            // 
            this.txtGPSLongSec.BeepOnError = true;
            this.txtGPSLongSec.HidePromptOnLeave = true;
            this.txtGPSLongSec.Location = new System.Drawing.Point(182, 54);
            this.txtGPSLongSec.Mask = "000";
            this.txtGPSLongSec.Name = "txtGPSLongSec";
            this.txtGPSLongSec.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLongSec.TabIndex = 5;
            this.txtGPSLongSec.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLongSec_Validating);
            // 
            // txtGPSLongMin
            // 
            this.txtGPSLongMin.BeepOnError = true;
            this.txtGPSLongMin.HidePromptOnLeave = true;
            this.txtGPSLongMin.Location = new System.Drawing.Point(152, 54);
            this.txtGPSLongMin.Mask = "000";
            this.txtGPSLongMin.Name = "txtGPSLongMin";
            this.txtGPSLongMin.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLongMin.TabIndex = 4;
            this.txtGPSLongMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLongMin_Validating);
            // 
            // txtGPSLongDeg
            // 
            this.txtGPSLongDeg.BeepOnError = true;
            this.txtGPSLongDeg.HidePromptOnLeave = true;
            this.txtGPSLongDeg.Location = new System.Drawing.Point(122, 54);
            this.txtGPSLongDeg.Mask = "000";
            this.txtGPSLongDeg.Name = "txtGPSLongDeg";
            this.txtGPSLongDeg.Size = new System.Drawing.Size(24, 20);
            this.txtGPSLongDeg.TabIndex = 3;
            this.txtGPSLongDeg.Validating += new System.ComponentModel.CancelEventHandler(this.txtGPSLongDeg_Validating);
            // 
            // listOfficeLocations
            // 
            this.listOfficeLocations.CausesValidation = false;
            this.listOfficeLocations.FormattingEnabled = true;
            this.listOfficeLocations.Location = new System.Drawing.Point(200, 253);
            this.listOfficeLocations.Name = "listOfficeLocations";
            this.listOfficeLocations.Size = new System.Drawing.Size(180, 95);
            this.listOfficeLocations.TabIndex = 27;
            this.listOfficeLocations.Visible = false;
            this.listOfficeLocations.SelectedIndexChanged += new System.EventHandler(this.listOfficeLocations_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(700, 417);
            this.ControlBox = false;
            this.Controls.Add(this.listOfficeLocations);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDepthWaterTable);
            this.Controls.Add(this.txtHoleInclination);
            this.Controls.Add(this.txtDrillingRate);
            this.Controls.Add(this.txtWirelineRate);
            this.Controls.Add(this.txtRigID);
            this.Controls.Add(this.txtHoleID);
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboCoreOrientationbypass);
            this.Controls.Add(this.cboCoreOrientation);
            this.Controls.Add(this.cboOverShotSize);
            this.Controls.Add(this.cboCoreBarrelLength);
            this.Controls.Add(this.cboTubeHead);
            this.Controls.Add(this.cboDrillRods);
            this.Controls.Add(this.cboHoleSize);
            this.Controls.Add(this.lbl13);
            this.Controls.Add(this.lbl14);
            this.Controls.Add(this.lbl15);
            this.Controls.Add(this.lbl16);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl11);
            this.Controls.Add(this.lbl12);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MD1 Header Data Logging  v1.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRadio.ResumeLayout(false);
            this.panelRadio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.ComboBox cboHoleSize;
        private System.Windows.Forms.ComboBox cboDrillRods;
        private System.Windows.Forms.ComboBox cboTubeHead;
        private System.Windows.Forms.ComboBox cboCoreBarrelLength;
        private System.Windows.Forms.ComboBox cboOverShotSize;
        private System.Windows.Forms.ComboBox cboCoreOrientation;
        private System.Windows.Forms.ComboBox cboCoreOrientationbypass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MaskedTextBox txtJobNumber;
        private System.Windows.Forms.MaskedTextBox txtHoleID;
        private System.Windows.Forms.MaskedTextBox txtRigID;
        private System.Windows.Forms.MaskedTextBox txtLongitude;
        private System.Windows.Forms.MaskedTextBox txtLatitude;
        private System.Windows.Forms.MaskedTextBox txtWirelineRate;
        private System.Windows.Forms.MaskedTextBox txtDrillingRate;
        private System.Windows.Forms.MaskedTextBox txtHoleInclination;
        private System.Windows.Forms.MaskedTextBox txtDepthWaterTable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioGPS;
        private System.Windows.Forms.RadioButton radioUTM;
        private System.Windows.Forms.RadioButton radioDecimal;
        private System.Windows.Forms.RadioButton radioRadian;
        private System.Windows.Forms.Panel panelRadio;
        private System.Windows.Forms.Button btnOffice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listOfficeLocations;
        private System.Windows.Forms.MaskedTextBox txtGPSLongDeg;
        private System.Windows.Forms.MaskedTextBox txtGPSLongMin;
        private System.Windows.Forms.MaskedTextBox txtGPSLatSec;
        private System.Windows.Forms.MaskedTextBox txtGPSLatMin;
        private System.Windows.Forms.MaskedTextBox txtGPSLatDeg;
        private System.Windows.Forms.MaskedTextBox txtGPSLongSec;
        private System.Windows.Forms.ComboBox cboEastWest;
        private System.Windows.Forms.ComboBox cboNorthSouth;

        

    }
}

