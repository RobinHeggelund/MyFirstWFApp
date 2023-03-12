namespace MyFirstWFApp
{
    partial class FormSettings
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSummary = new System.Windows.Forms.Panel();
            this.labelSummaryTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSummaryTotal = new System.Windows.Forms.Label();
            this.labelSummaryFieldBus = new System.Windows.Forms.Label();
            this.labelSummaryDigital = new System.Windows.Forms.Label();
            this.labelSummaryAnalog = new System.Windows.Forms.Label();
            this.labelSummaryTotalDescription = new System.Windows.Forms.Label();
            this.labelSummaryFieldbusDescription = new System.Windows.Forms.Label();
            this.labelSummaryDigitalDescription = new System.Windows.Forms.Label();
            this.labelSummaryAnalogDescription = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxSettings1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings4 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelSettings = new System.Windows.Forms.TextBox();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.panelSummary.Controls.Add(this.labelSummaryTime);
            this.panelSummary.Controls.Add(this.label5);
            this.panelSummary.Controls.Add(this.labelSummaryTotal);
            this.panelSummary.Controls.Add(this.labelSummaryFieldBus);
            this.panelSummary.Controls.Add(this.labelSummaryDigital);
            this.panelSummary.Controls.Add(this.labelSummaryAnalog);
            this.panelSummary.Controls.Add(this.labelSummaryTotalDescription);
            this.panelSummary.Controls.Add(this.labelSummaryFieldbusDescription);
            this.panelSummary.Controls.Add(this.labelSummaryDigitalDescription);
            this.panelSummary.Controls.Add(this.labelSummaryAnalogDescription);
            this.panelSummary.Location = new System.Drawing.Point(482, 130);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(424, 204);
            this.panelSummary.TabIndex = 23;
            // 
            // labelSummaryTime
            // 
            this.labelSummaryTime.AutoSize = true;
            this.labelSummaryTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.labelSummaryTime.Location = new System.Drawing.Point(210, 155);
            this.labelSummaryTime.Name = "labelSummaryTime";
            this.labelSummaryTime.Size = new System.Drawing.Size(145, 26);
            this.labelSummaryTime.TabIndex = 9;
            this.labelSummaryTime.Text = "0 Min, 0 Sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(56, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Elapsed Time:";
            // 
            // labelSummaryTotal
            // 
            this.labelSummaryTotal.AutoSize = true;
            this.labelSummaryTotal.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.labelSummaryTotal.Location = new System.Drawing.Point(329, 48);
            this.labelSummaryTotal.Name = "labelSummaryTotal";
            this.labelSummaryTotal.Size = new System.Drawing.Size(72, 85);
            this.labelSummaryTotal.TabIndex = 7;
            this.labelSummaryTotal.Text = "0";
            // 
            // labelSummaryFieldBus
            // 
            this.labelSummaryFieldBus.AutoSize = true;
            this.labelSummaryFieldBus.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryFieldBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.labelSummaryFieldBus.Location = new System.Drawing.Point(229, 48);
            this.labelSummaryFieldBus.Name = "labelSummaryFieldBus";
            this.labelSummaryFieldBus.Size = new System.Drawing.Size(72, 85);
            this.labelSummaryFieldBus.TabIndex = 6;
            this.labelSummaryFieldBus.Text = "0";
            // 
            // labelSummaryDigital
            // 
            this.labelSummaryDigital.AutoSize = true;
            this.labelSummaryDigital.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryDigital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.labelSummaryDigital.Location = new System.Drawing.Point(129, 48);
            this.labelSummaryDigital.Name = "labelSummaryDigital";
            this.labelSummaryDigital.Size = new System.Drawing.Size(72, 85);
            this.labelSummaryDigital.TabIndex = 5;
            this.labelSummaryDigital.Text = "0";
            this.labelSummaryDigital.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelSummaryAnalog
            // 
            this.labelSummaryAnalog.AutoSize = true;
            this.labelSummaryAnalog.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryAnalog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.labelSummaryAnalog.Location = new System.Drawing.Point(29, 48);
            this.labelSummaryAnalog.Name = "labelSummaryAnalog";
            this.labelSummaryAnalog.Size = new System.Drawing.Size(72, 85);
            this.labelSummaryAnalog.TabIndex = 4;
            this.labelSummaryAnalog.Text = "0";
            // 
            // labelSummaryTotalDescription
            // 
            this.labelSummaryTotalDescription.AutoSize = true;
            this.labelSummaryTotalDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryTotalDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSummaryTotalDescription.Location = new System.Drawing.Point(331, 21);
            this.labelSummaryTotalDescription.Name = "labelSummaryTotalDescription";
            this.labelSummaryTotalDescription.Size = new System.Drawing.Size(73, 29);
            this.labelSummaryTotalDescription.TabIndex = 3;
            this.labelSummaryTotalDescription.Text = "Total";
            // 
            // labelSummaryFieldbusDescription
            // 
            this.labelSummaryFieldbusDescription.AutoSize = true;
            this.labelSummaryFieldbusDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryFieldbusDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSummaryFieldbusDescription.Location = new System.Drawing.Point(210, 21);
            this.labelSummaryFieldbusDescription.Name = "labelSummaryFieldbusDescription";
            this.labelSummaryFieldbusDescription.Size = new System.Drawing.Size(115, 29);
            this.labelSummaryFieldbusDescription.TabIndex = 2;
            this.labelSummaryFieldbusDescription.Text = "Fieldbus";
            // 
            // labelSummaryDigitalDescription
            // 
            this.labelSummaryDigitalDescription.AutoSize = true;
            this.labelSummaryDigitalDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryDigitalDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSummaryDigitalDescription.Location = new System.Drawing.Point(116, 19);
            this.labelSummaryDigitalDescription.Name = "labelSummaryDigitalDescription";
            this.labelSummaryDigitalDescription.Size = new System.Drawing.Size(88, 29);
            this.labelSummaryDigitalDescription.TabIndex = 1;
            this.labelSummaryDigitalDescription.Text = "Digital";
            // 
            // labelSummaryAnalogDescription
            // 
            this.labelSummaryAnalogDescription.AutoSize = true;
            this.labelSummaryAnalogDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSummaryAnalogDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSummaryAnalogDescription.Location = new System.Drawing.Point(16, 19);
            this.labelSummaryAnalogDescription.Name = "labelSummaryAnalogDescription";
            this.labelSummaryAnalogDescription.Size = new System.Drawing.Size(94, 29);
            this.labelSummaryAnalogDescription.TabIndex = 0;
            this.labelSummaryAnalogDescription.Text = "Analog";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(576, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "Session Summary";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBoxSettings1
            // 
            this.pictureBoxSettings1.Image = global::MyFirstWFApp.Properties.Resources.folder;
            this.pictureBoxSettings1.Location = new System.Drawing.Point(84, 130);
            this.pictureBoxSettings1.Name = "pictureBoxSettings1";
            this.pictureBoxSettings1.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxSettings1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings1.TabIndex = 25;
            this.pictureBoxSettings1.TabStop = false;
            this.pictureBoxSettings1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBoxSettings1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBoxSettings1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBoxSettings2
            // 
            this.pictureBoxSettings2.Image = global::MyFirstWFApp.Properties.Resources.folder__1_;
            this.pictureBoxSettings2.Location = new System.Drawing.Point(234, 123);
            this.pictureBoxSettings2.Name = "pictureBoxSettings2";
            this.pictureBoxSettings2.Size = new System.Drawing.Size(164, 150);
            this.pictureBoxSettings2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings2.TabIndex = 26;
            this.pictureBoxSettings2.TabStop = false;
            this.pictureBoxSettings2.Click += new System.EventHandler(this.PictureBox2_Click);
            this.pictureBoxSettings2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBoxSettings2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBoxSettings3
            // 
            this.pictureBoxSettings3.Image = global::MyFirstWFApp.Properties.Resources.folder__2_;
            this.pictureBoxSettings3.Location = new System.Drawing.Point(84, 302);
            this.pictureBoxSettings3.Name = "pictureBoxSettings3";
            this.pictureBoxSettings3.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxSettings3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings3.TabIndex = 27;
            this.pictureBoxSettings3.TabStop = false;
            this.pictureBoxSettings3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBoxSettings3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBoxSettings3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBoxSettings4
            // 
            this.pictureBoxSettings4.ErrorImage = global::MyFirstWFApp.Properties.Resources.folder__3_;
            this.pictureBoxSettings4.Image = global::MyFirstWFApp.Properties.Resources.folder__3_;
            this.pictureBoxSettings4.Location = new System.Drawing.Point(250, 302);
            this.pictureBoxSettings4.Name = "pictureBoxSettings4";
            this.pictureBoxSettings4.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxSettings4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings4.TabIndex = 28;
            this.pictureBoxSettings4.TabStop = false;
            this.pictureBoxSettings4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBoxSettings4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelSettings
            // 
            this.labelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.labelSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelSettings.Enabled = false;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSettings.Location = new System.Drawing.Point(12, 473);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(464, 26);
            this.labelSettings.TabIndex = 30;
            this.labelSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.pictureBoxSettings4);
            this.Controls.Add(this.pictureBoxSettings3);
            this.Controls.Add(this.pictureBoxSettings2);
            this.Controls.Add(this.pictureBoxSettings1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel panelSummary;
        private Label labelSummaryAnalogDescription;
        private Label labelSummaryAnalog;
        private Label labelSummaryTotalDescription;
        private Label labelSummaryFieldbusDescription;
        private Label labelSummaryDigitalDescription;
        private Label labelSummaryFieldBus;
        private Label labelSummaryDigital;
        private Label labelSummaryTime;
        private Label label5;
        private Label labelSummaryTotal;
        private Label label7;
        private PictureBox pictureBoxSettings1;
        private PictureBox pictureBoxSettings2;
        private PictureBox pictureBoxSettings3;
        private PictureBox pictureBoxSettings4;
        private OpenFileDialog openFileDialog1;
        private TextBox labelSettings;
    }
}