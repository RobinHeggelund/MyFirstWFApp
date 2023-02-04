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
            this.pictureBoxWIP = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSummary = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSummaryTotalDescription = new System.Windows.Forms.Label();
            this.labelSummaryFieldbusDescription = new System.Windows.Forms.Label();
            this.labelSummaryDigitalDescription = new System.Windows.Forms.Label();
            this.labelSummaryAnalogDescription = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxWIP
            // 
            this.pictureBoxWIP.Image = global::MyFirstWFApp.Properties.Resources.WIP2;
            this.pictureBoxWIP.Location = new System.Drawing.Point(12, 92);
            this.pictureBoxWIP.Name = "pictureBoxWIP";
            this.pictureBoxWIP.Size = new System.Drawing.Size(447, 321);
            this.pictureBoxWIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWIP.TabIndex = 2;
            this.pictureBoxWIP.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.panelSummary.Controls.Add(this.label6);
            this.panelSummary.Controls.Add(this.label5);
            this.panelSummary.Controls.Add(this.label4);
            this.panelSummary.Controls.Add(this.label3);
            this.panelSummary.Controls.Add(this.label2);
            this.panelSummary.Controls.Add(this.label1);
            this.panelSummary.Controls.Add(this.labelSummaryTotalDescription);
            this.panelSummary.Controls.Add(this.labelSummaryFieldbusDescription);
            this.panelSummary.Controls.Add(this.labelSummaryDigitalDescription);
            this.panelSummary.Controls.Add(this.labelSummaryAnalogDescription);
            this.panelSummary.Location = new System.Drawing.Point(482, 130);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(424, 143);
            this.panelSummary.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.label6.Location = new System.Drawing.Point(197, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 43);
            this.label6.TabIndex = 9;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(16, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "Session time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.label4.Location = new System.Drawing.Point(329, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 85);
            this.label4.TabIndex = 7;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.label3.Location = new System.Drawing.Point(229, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 85);
            this.label3.TabIndex = 6;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.label2.Location = new System.Drawing.Point(129, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 85);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 85);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
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
            this.label7.Location = new System.Drawing.Point(611, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "Summary";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(482, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 47);
            this.panel1.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(212, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 47);
            this.button2.TabIndex = 27;
            this.button2.Text = "Light";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(92, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 26;
            this.button1.Text = "Dark";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 47);
            this.panel2.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(12, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 21);
            this.label8.TabIndex = 25;
            this.label8.Text = "Theme";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.pictureBoxWIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBoxWIP;
        private System.Windows.Forms.Timer timer1;
        private Panel panelSummary;
        private Label labelSummaryAnalogDescription;
        private Label label1;
        private Label labelSummaryTotalDescription;
        private Label labelSummaryFieldbusDescription;
        private Label labelSummaryDigitalDescription;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label7;
        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Label label8;
    }
}