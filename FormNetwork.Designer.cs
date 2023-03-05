namespace MyFirstWFApp
{
    partial class FormNetwork
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
            this.pictureBoxWIP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWIP
            // 
            this.pictureBoxWIP.Image = global::MyFirstWFApp.Properties.Resources.WIP2;
            this.pictureBoxWIP.Location = new System.Drawing.Point(102, 26);
            this.pictureBoxWIP.Name = "pictureBoxWIP";
            this.pictureBoxWIP.Size = new System.Drawing.Size(780, 525);
            this.pictureBoxWIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWIP.TabIndex = 2;
            this.pictureBoxWIP.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(236, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Page under construction";
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxWIP);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNetwork";
            this.Text = "FormNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBoxWIP;
        private Label label1;
    }
}