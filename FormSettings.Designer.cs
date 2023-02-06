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
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelSettings = new System.Windows.Forms.TextBox();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
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
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.Image = global::MyFirstWFApp.Properties.Resources.folder;
            this.pictureBoxHelp.Location = new System.Drawing.Point(84, 130);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHelp.TabIndex = 25;
            this.pictureBoxHelp.TabStop = false;
            this.pictureBoxHelp.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBoxHelp.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBoxHelp.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MyFirstWFApp.Properties.Resources.folder__1_;
            this.pictureBox2.Location = new System.Drawing.Point(234, 123);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MyFirstWFApp.Properties.Resources.folder__2_;
            this.pictureBox3.Location = new System.Drawing.Point(84, 302);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(140, 140);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.ErrorImage = global::MyFirstWFApp.Properties.Resources.folder__3_;
            this.pictureBox4.Image = global::MyFirstWFApp.Properties.Resources.folder__3_;
            this.pictureBox4.Location = new System.Drawing.Point(250, 302);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(140, 140);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(482, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 47);
            this.panel3.TabIndex = 28;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(259, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 47);
            this.button3.TabIndex = 27;
            this.button3.Text = "Light";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(94, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 47);
            this.button4.TabIndex = 26;
            this.button4.Text = "Dark";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 47);
            this.panel4.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(18, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Theme";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(482, 426);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(424, 47);
            this.panel5.TabIndex = 28;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(259, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 47);
            this.button5.TabIndex = 27;
            this.button5.Text = "Light";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.SystemColors.Control;
            this.button6.Location = new System.Drawing.Point(94, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 47);
            this.button6.TabIndex = 26;
            this.button6.Text = "Dark";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(94, 47);
            this.panel6.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(18, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 21);
            this.label10.TabIndex = 25;
            this.label10.Text = "Theme";
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
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBoxHelp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private PictureBox pictureBoxHelp;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel3;
        private Button button3;
        private Button button4;
        private Panel panel4;
        private Label label9;
        private Panel panel5;
        private Button button5;
        private Button button6;
        private Panel panel6;
        private Label label10;
        private OpenFileDialog openFileDialog1;
        private TextBox labelSettings;
    }
}