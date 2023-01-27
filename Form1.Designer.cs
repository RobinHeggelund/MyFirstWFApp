namespace MyFirstWFApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxSignalRange = new System.Windows.Forms.GroupBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxURV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLVR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMeasureType = new System.Windows.Forms.ComboBox();
            this.labelMeasureType = new System.Windows.Forms.Label();
            this.labelRegistered = new System.Windows.Forms.Label();
            this.labelComments = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRegisterNew = new System.Windows.Forms.Button();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonSave = new System.Windows.Forms.RadioButton();
            this.radioButtonRegisterNew = new System.Windows.Forms.RadioButton();
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelSignalType = new System.Windows.Forms.Label();
            this.labelRegDate = new System.Windows.Forms.Label();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.labelSensorName = new System.Windows.Forms.Label();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.listBoxOptions = new System.Windows.Forms.ListBox();
            this.comboBoxSignalType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerRegDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxRegistered = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxSerialNumber = new System.Windows.Forms.MaskedTextBox();
            this.textBoxSensorName = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.labelPreview = new System.Windows.Forms.Label();
            this.buttonSummary = new System.Windows.Forms.Button();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxSignalRange.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxSignalRange);
            this.groupBox1.Controls.Add(this.comboBoxMeasureType);
            this.groupBox1.Controls.Add(this.labelMeasureType);
            this.groupBox1.Controls.Add(this.labelRegistered);
            this.groupBox1.Controls.Add(this.labelComments);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelOptions);
            this.groupBox1.Controls.Add(this.labelSignalType);
            this.groupBox1.Controls.Add(this.labelRegDate);
            this.groupBox1.Controls.Add(this.labelSerialNumber);
            this.groupBox1.Controls.Add(this.labelSensorName);
            this.groupBox1.Controls.Add(this.textBoxComments);
            this.groupBox1.Controls.Add(this.listBoxOptions);
            this.groupBox1.Controls.Add(this.comboBoxSignalType);
            this.groupBox1.Controls.Add(this.dateTimePickerRegDate);
            this.groupBox1.Controls.Add(this.checkBoxRegistered);
            this.groupBox1.Controls.Add(this.maskedTextBoxSerialNumber);
            this.groupBox1.Controls.Add(this.textBoxSensorName);
            this.groupBox1.Location = new System.Drawing.Point(4, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            this.groupBox1.MouseHover += new System.EventHandler(this.groupBox1_MouseHover);
            // 
            // groupBoxSignalRange
            // 
            this.groupBoxSignalRange.Controls.Add(this.textBoxUnit);
            this.groupBoxSignalRange.Controls.Add(this.label3);
            this.groupBoxSignalRange.Controls.Add(this.textBoxURV);
            this.groupBoxSignalRange.Controls.Add(this.label2);
            this.groupBoxSignalRange.Controls.Add(this.textBoxLVR);
            this.groupBoxSignalRange.Controls.Add(this.label1);
            this.groupBoxSignalRange.Location = new System.Drawing.Point(508, 18);
            this.groupBoxSignalRange.Name = "groupBoxSignalRange";
            this.groupBoxSignalRange.Size = new System.Drawing.Size(268, 235);
            this.groupBoxSignalRange.TabIndex = 17;
            this.groupBoxSignalRange.TabStop = false;
            this.groupBoxSignalRange.Visible = false;
            this.groupBoxSignalRange.Enter += new System.EventHandler(this.groupBoxLVR_Enter);
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(72, 140);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(120, 31);
            this.textBoxUnit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unit";
            // 
            // textBoxURV
            // 
            this.textBoxURV.Location = new System.Drawing.Point(72, 100);
            this.textBoxURV.Name = "textBoxURV";
            this.textBoxURV.Size = new System.Drawing.Size(120, 31);
            this.textBoxURV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "URV";
            // 
            // textBoxLVR
            // 
            this.textBoxLVR.Location = new System.Drawing.Point(72, 60);
            this.textBoxLVR.Name = "textBoxLVR";
            this.textBoxLVR.Size = new System.Drawing.Size(120, 31);
            this.textBoxLVR.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "LVR";
            // 
            // comboBoxMeasureType
            // 
            this.comboBoxMeasureType.FormattingEnabled = true;
            this.comboBoxMeasureType.Location = new System.Drawing.Point(184, 220);
            this.comboBoxMeasureType.Name = "comboBoxMeasureType";
            this.comboBoxMeasureType.Size = new System.Drawing.Size(315, 33);
            this.comboBoxMeasureType.TabIndex = 16;
            // 
            // labelMeasureType
            // 
            this.labelMeasureType.AutoSize = true;
            this.labelMeasureType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMeasureType.Location = new System.Drawing.Point(4, 216);
            this.labelMeasureType.Name = "labelMeasureType";
            this.labelMeasureType.Size = new System.Drawing.Size(132, 28);
            this.labelMeasureType.TabIndex = 15;
            this.labelMeasureType.Text = "Measure Type";
            // 
            // labelRegistered
            // 
            this.labelRegistered.AutoSize = true;
            this.labelRegistered.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRegistered.Location = new System.Drawing.Point(8, 104);
            this.labelRegistered.Name = "labelRegistered";
            this.labelRegistered.Size = new System.Drawing.Size(104, 28);
            this.labelRegistered.TabIndex = 13;
            this.labelRegistered.Text = "Registered";
            this.labelRegistered.MouseLeave += new System.EventHandler(this.labelRegistered_MouseLeave);
            this.labelRegistered.MouseHover += new System.EventHandler(this.labelRegistered_MouseHover);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelComments.Location = new System.Drawing.Point(4, 349);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(106, 28);
            this.labelComments.TabIndex = 12;
            this.labelComments.Text = "Comments";
            this.labelComments.MouseLeave += new System.EventHandler(this.labelComments_MouseLeave);
            this.labelComments.MouseHover += new System.EventHandler(this.labelComments_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonRegisterNew);
            this.groupBox2.Controls.Add(this.radioButtonDelete);
            this.groupBox2.Controls.Add(this.radioButtonSave);
            this.groupBox2.Controls.Add(this.radioButtonRegisterNew);
            this.groupBox2.Location = new System.Drawing.Point(508, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // buttonRegisterNew
            // 
            this.buttonRegisterNew.Location = new System.Drawing.Point(14, 157);
            this.buttonRegisterNew.Name = "buttonRegisterNew";
            this.buttonRegisterNew.Size = new System.Drawing.Size(246, 50);
            this.buttonRegisterNew.TabIndex = 10;
            this.buttonRegisterNew.TabStop = false;
            this.buttonRegisterNew.Text = "Register New";
            this.buttonRegisterNew.UseVisualStyleBackColor = true;
            this.buttonRegisterNew.Click += new System.EventHandler(this.buttonRegisterNew_Click);
            this.buttonRegisterNew.MouseLeave += new System.EventHandler(this.buttonRegisterNew_MouseLeave);
            this.buttonRegisterNew.MouseHover += new System.EventHandler(this.buttonRegisterNew_MouseHover);
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Location = new System.Drawing.Point(16, 112);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(87, 29);
            this.radioButtonDelete.TabIndex = 9;
            this.radioButtonDelete.Text = "Delete";
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            this.radioButtonDelete.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.radioButtonDelete.MouseLeave += new System.EventHandler(this.radioButtonDelete_MouseLeave);
            this.radioButtonDelete.MouseHover += new System.EventHandler(this.radioButtonDelete_MouseHover);
            // 
            // radioButtonSave
            // 
            this.radioButtonSave.AutoSize = true;
            this.radioButtonSave.Location = new System.Drawing.Point(16, 72);
            this.radioButtonSave.Name = "radioButtonSave";
            this.radioButtonSave.Size = new System.Drawing.Size(74, 29);
            this.radioButtonSave.TabIndex = 8;
            this.radioButtonSave.Text = "Save";
            this.radioButtonSave.UseVisualStyleBackColor = true;
            this.radioButtonSave.MouseLeave += new System.EventHandler(this.radioButtonSave_MouseLeave);
            this.radioButtonSave.MouseHover += new System.EventHandler(this.radioButtonSave_MouseHover);
            // 
            // radioButtonRegisterNew
            // 
            this.radioButtonRegisterNew.AutoSize = true;
            this.radioButtonRegisterNew.Location = new System.Drawing.Point(16, 32);
            this.radioButtonRegisterNew.Name = "radioButtonRegisterNew";
            this.radioButtonRegisterNew.Size = new System.Drawing.Size(140, 29);
            this.radioButtonRegisterNew.TabIndex = 7;
            this.radioButtonRegisterNew.Text = "Register New";
            this.radioButtonRegisterNew.UseVisualStyleBackColor = true;
            this.radioButtonRegisterNew.CheckedChanged += new System.EventHandler(this.radioButtonRegisterNew_CheckedChanged);
            this.radioButtonRegisterNew.MouseLeave += new System.EventHandler(this.radioButtonRegisterNew_MouseLeave);
            this.radioButtonRegisterNew.MouseHover += new System.EventHandler(this.radioButtonRegisterNew_MouseHover);
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOptions.Location = new System.Drawing.Point(4, 264);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(82, 28);
            this.labelOptions.TabIndex = 11;
            this.labelOptions.Text = "Options";
            this.labelOptions.MouseLeave += new System.EventHandler(this.labelOptions_MouseLeave);
            this.labelOptions.MouseHover += new System.EventHandler(this.labelOptions_MouseHover);
            // 
            // labelSignalType
            // 
            this.labelSignalType.AutoSize = true;
            this.labelSignalType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSignalType.Location = new System.Drawing.Point(6, 179);
            this.labelSignalType.Name = "labelSignalType";
            this.labelSignalType.Size = new System.Drawing.Size(112, 28);
            this.labelSignalType.TabIndex = 10;
            this.labelSignalType.Text = "Signal Type";
            this.labelSignalType.MouseLeave += new System.EventHandler(this.labelSignalType_MouseLeave);
            this.labelSignalType.MouseHover += new System.EventHandler(this.labelSignalType_MouseHover);
            // 
            // labelRegDate
            // 
            this.labelRegDate.AutoSize = true;
            this.labelRegDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRegDate.Location = new System.Drawing.Point(6, 144);
            this.labelRegDate.Name = "labelRegDate";
            this.labelRegDate.Size = new System.Drawing.Size(91, 28);
            this.labelRegDate.TabIndex = 9;
            this.labelRegDate.Text = "Reg Date";
            this.labelRegDate.MouseLeave += new System.EventHandler(this.labelRegDate_MouseLeave);
            this.labelRegDate.MouseHover += new System.EventHandler(this.labelRegDate_MouseHover);
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSerialNumber.Location = new System.Drawing.Point(6, 67);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(137, 28);
            this.labelSerialNumber.TabIndex = 8;
            this.labelSerialNumber.Text = "Serial Number";
            this.labelSerialNumber.MouseLeave += new System.EventHandler(this.labelSerialNumber_MouseLeave);
            this.labelSerialNumber.MouseHover += new System.EventHandler(this.labelSerialNumber_MouseHover);
            // 
            // labelSensorName
            // 
            this.labelSensorName.AutoSize = true;
            this.labelSensorName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSensorName.Location = new System.Drawing.Point(6, 30);
            this.labelSensorName.Name = "labelSensorName";
            this.labelSensorName.Size = new System.Drawing.Size(128, 28);
            this.labelSensorName.TabIndex = 7;
            this.labelSensorName.Text = "Sensor Name";
            this.labelSensorName.Click += new System.EventHandler(this.label1_Click);
            this.labelSensorName.MouseLeave += new System.EventHandler(this.labelSensorName_MouseLeave);
            this.labelSensorName.MouseHover += new System.EventHandler(this.labelSensorName_MouseHover);
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(184, 349);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(315, 127);
            this.textBoxComments.TabIndex = 6;
            this.textBoxComments.Enter += new System.EventHandler(this.textBoxComments_Enter);
            this.textBoxComments.Leave += new System.EventHandler(this.textBoxComments_Leave);
            this.textBoxComments.MouseLeave += new System.EventHandler(this.textBoxComments_MouseLeave);
            this.textBoxComments.MouseHover += new System.EventHandler(this.textBoxComments_MouseHover);
            // 
            // listBoxOptions
            // 
            this.listBoxOptions.FormattingEnabled = true;
            this.listBoxOptions.ItemHeight = 25;
            this.listBoxOptions.Items.AddRange(new object[] {
            "None",
            "HART Protocol",
            "GIGA Protocol"});
            this.listBoxOptions.Location = new System.Drawing.Point(184, 264);
            this.listBoxOptions.Name = "listBoxOptions";
            this.listBoxOptions.Size = new System.Drawing.Size(315, 79);
            this.listBoxOptions.TabIndex = 5;
            this.listBoxOptions.Enter += new System.EventHandler(this.listBoxOptions_Enter);
            this.listBoxOptions.Leave += new System.EventHandler(this.listBoxOptions_Leave);
            this.listBoxOptions.MouseLeave += new System.EventHandler(this.listBoxOptions_MouseLeave);
            this.listBoxOptions.MouseHover += new System.EventHandler(this.listBoxOptions_MouseHover);
            // 
            // comboBoxSignalType
            // 
            this.comboBoxSignalType.FormattingEnabled = true;
            this.comboBoxSignalType.Items.AddRange(new object[] {
            "Analog",
            "Digital",
            "Fieldbus"});
            this.comboBoxSignalType.Location = new System.Drawing.Point(184, 179);
            this.comboBoxSignalType.Name = "comboBoxSignalType";
            this.comboBoxSignalType.Size = new System.Drawing.Size(315, 33);
            this.comboBoxSignalType.TabIndex = 4;
            this.comboBoxSignalType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignalType_SelectedIndexChanged);
            this.comboBoxSignalType.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSignalType_SelectionChangeCommitted);
            this.comboBoxSignalType.Enter += new System.EventHandler(this.comboBoxSignalType_Enter);
            this.comboBoxSignalType.Leave += new System.EventHandler(this.comboBoxSignalType_Leave);
            this.comboBoxSignalType.MouseLeave += new System.EventHandler(this.comboBoxSignalType_MouseLeave);
            this.comboBoxSignalType.MouseHover += new System.EventHandler(this.comboBoxSignalType_MouseHover);
            // 
            // dateTimePickerRegDate
            // 
            this.dateTimePickerRegDate.Location = new System.Drawing.Point(184, 142);
            this.dateTimePickerRegDate.Name = "dateTimePickerRegDate";
            this.dateTimePickerRegDate.Size = new System.Drawing.Size(315, 31);
            this.dateTimePickerRegDate.TabIndex = 3;
            this.dateTimePickerRegDate.Enter += new System.EventHandler(this.dateTimePickerRegDate_Enter);
            this.dateTimePickerRegDate.Leave += new System.EventHandler(this.dateTimePickerRegDate_Leave);
            this.dateTimePickerRegDate.MouseLeave += new System.EventHandler(this.dateTimePickerRegDate_MouseLeave);
            this.dateTimePickerRegDate.MouseHover += new System.EventHandler(this.dateTimePickerRegDate_MouseHover);
            // 
            // checkBoxRegistered
            // 
            this.checkBoxRegistered.AutoSize = true;
            this.checkBoxRegistered.Location = new System.Drawing.Point(186, 110);
            this.checkBoxRegistered.Name = "checkBoxRegistered";
            this.checkBoxRegistered.Size = new System.Drawing.Size(22, 21);
            this.checkBoxRegistered.TabIndex = 2;
            this.checkBoxRegistered.UseVisualStyleBackColor = true;
            this.checkBoxRegistered.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBoxRegistered.Enter += new System.EventHandler(this.checkBoxRegistered_Enter);
            this.checkBoxRegistered.Leave += new System.EventHandler(this.checkBoxRegistered_Leave);
            this.checkBoxRegistered.MouseLeave += new System.EventHandler(this.checkBoxRegistered_MouseLeave);
            this.checkBoxRegistered.MouseHover += new System.EventHandler(this.checkBoxRegistered_MouseHover);
            // 
            // maskedTextBoxSerialNumber
            // 
            this.maskedTextBoxSerialNumber.Location = new System.Drawing.Point(184, 67);
            this.maskedTextBoxSerialNumber.Mask = "000-00-0000";
            this.maskedTextBoxSerialNumber.Name = "maskedTextBoxSerialNumber";
            this.maskedTextBoxSerialNumber.Size = new System.Drawing.Size(315, 31);
            this.maskedTextBoxSerialNumber.TabIndex = 1;
            this.maskedTextBoxSerialNumber.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxSerialNumber_MaskInputRejected);
            this.maskedTextBoxSerialNumber.Enter += new System.EventHandler(this.maskedTextBoxSerialNumber_Enter);
            this.maskedTextBoxSerialNumber.Leave += new System.EventHandler(this.maskedTextBoxSerialNumber_Leave);
            this.maskedTextBoxSerialNumber.MouseLeave += new System.EventHandler(this.maskedTextBoxSerialNumber_MouseLeave);
            this.maskedTextBoxSerialNumber.MouseHover += new System.EventHandler(this.maskedTextBoxSerialNumber_MouseHover);
            // 
            // textBoxSensorName
            // 
            this.textBoxSensorName.Location = new System.Drawing.Point(184, 30);
            this.textBoxSensorName.Name = "textBoxSensorName";
            this.textBoxSensorName.Size = new System.Drawing.Size(315, 31);
            this.textBoxSensorName.TabIndex = 0;
            this.textBoxSensorName.Enter += new System.EventHandler(this.textBoxSensorName_Enter);
            this.textBoxSensorName.Leave += new System.EventHandler(this.textBoxSensorName_Leave);
            this.textBoxSensorName.MouseLeave += new System.EventHandler(this.textBoxSensorName_MouseLeave);
            this.textBoxSensorName.MouseHover += new System.EventHandler(this.textBoxSensorName_MouseHover);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1424, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStripMain";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(208, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabelMain";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1424, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseHover += new System.EventHandler(this.menuStrip1_MouseHover);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(157, 34);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 34);
            this.toolStripMenuItem1.Text = "&Data";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(177, 34);
            this.clearToolStripMenuItem.Text = "&Register";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(177, 34);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 536);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(844, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sensor Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxResult);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.buttonTest);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(844, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(272, 64);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(460, 180);
            this.textBoxResult.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(224, 31);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 31);
            this.textBox1.TabIndex = 1;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 136);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(224, 108);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxPreview.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPreview.Location = new System.Drawing.Point(872, 112);
            this.textBoxPreview.Multiline = true;
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.ReadOnly = true;
            this.textBoxPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPreview.Size = new System.Drawing.Size(252, 369);
            this.textBoxPreview.TabIndex = 15;
            this.textBoxPreview.Visible = false;
            this.textBoxPreview.TextChanged += new System.EventHandler(this.textBoxPreview_TextChanged);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPreview.Location = new System.Drawing.Point(947, 78);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(79, 28);
            this.labelPreview.TabIndex = 14;
            this.labelPreview.Text = "Preview";
            this.labelPreview.Visible = false;
            // 
            // buttonSummary
            // 
            this.buttonSummary.Location = new System.Drawing.Point(872, 497);
            this.buttonSummary.Name = "buttonSummary";
            this.buttonSummary.Size = new System.Drawing.Size(246, 50);
            this.buttonSummary.TabIndex = 16;
            this.buttonSummary.TabStop = false;
            this.buttonSummary.Text = "Summary";
            this.buttonSummary.UseVisualStyleBackColor = true;
            this.buttonSummary.Click += new System.EventHandler(this.buttonSummary_Click);
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSummary.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSummary.Location = new System.Drawing.Point(1141, 112);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.ReadOnly = true;
            this.textBoxSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSummary.Size = new System.Drawing.Size(252, 369);
            this.textBoxSummary.TabIndex = 17;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSummary.Location = new System.Drawing.Point(1180, 81);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(165, 28);
            this.labelSummary.TabIndex = 18;
            this.labelSummary.Text = "Session Summary";
            this.labelSummary.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 655);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.textBoxSummary);
            this.Controls.Add(this.buttonSummary);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.textBoxPreview);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "MyFirstWFApp";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSignalRange.ResumeLayout(false);
            this.groupBoxSignalRange.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePickerRegDate;
        private CheckBox checkBoxRegistered;
        private MaskedTextBox maskedTextBoxSerialNumber;
        private TextBox textBoxSensorName;
        private GroupBox groupBox2;
        private Label labelSensorName;
        private TextBox textBoxComments;
        private ListBox listBoxOptions;
        private ComboBox comboBoxSignalType;
        private Label labelRegistered;
        private Label labelComments;
        private Label labelOptions;
        private Label labelSignalType;
        private Label labelRegDate;
        private Label labelSerialNumber;
        private RadioButton radioButtonDelete;
        private RadioButton radioButtonSave;
        private RadioButton radioButtonRegisterNew;
        private Button buttonRegisterNew;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private TextBox textBoxPreview;
        private Label labelPreview;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem dataToolStripMenuItem;
        private TextBox textBoxResult;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button buttonTest;
        private Label labelMeasureType;
        private ComboBox comboBoxMeasureType;
        private GroupBox groupBoxSignalRange;
        private TextBox textBoxUnit;
        private Label label3;
        private TextBox textBoxURV;
        private Label label2;
        private TextBox textBoxLVR;
        private Label label1;
        private Button buttonSummary;
        private TextBox textBoxSummary;
        private Label labelSummary;
    }
}