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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 240D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 450D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 310D);
            this.pictureBoxWIP = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxXvalue = new System.Windows.Forms.TextBox();
            this.textBoxYvalue = new System.Windows.Forms.TextBox();
            this.buttonAddPoint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWIP
            // 
            this.pictureBoxWIP.Image = global::MyFirstWFApp.Properties.Resources.WIP2;
            this.pictureBoxWIP.Location = new System.Drawing.Point(776, 497);
            this.pictureBoxWIP.Name = "pictureBoxWIP";
            this.pictureBoxWIP.Size = new System.Drawing.Size(244, 160);
            this.pictureBoxWIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWIP.TabIndex = 2;
            this.pictureBoxWIP.TabStop = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(80, 46);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(758, 392);
            this.chart1.TabIndex = 57;
            this.chart1.Text = "chart1";
            // 
            // textBoxXvalue
            // 
            this.textBoxXvalue.Location = new System.Drawing.Point(722, 161);
            this.textBoxXvalue.Name = "textBoxXvalue";
            this.textBoxXvalue.Size = new System.Drawing.Size(100, 23);
            this.textBoxXvalue.TabIndex = 58;
            // 
            // textBoxYvalue
            // 
            this.textBoxYvalue.Location = new System.Drawing.Point(722, 201);
            this.textBoxYvalue.Name = "textBoxYvalue";
            this.textBoxYvalue.Size = new System.Drawing.Size(100, 23);
            this.textBoxYvalue.TabIndex = 59;
            // 
            // buttonAddPoint
            // 
            this.buttonAddPoint.Location = new System.Drawing.Point(722, 239);
            this.buttonAddPoint.Name = "buttonAddPoint";
            this.buttonAddPoint.Size = new System.Drawing.Size(100, 23);
            this.buttonAddPoint.TabIndex = 60;
            this.buttonAddPoint.Text = "button1";
            this.buttonAddPoint.UseVisualStyleBackColor = true;
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(982, 635);
            this.Controls.Add(this.buttonAddPoint);
            this.Controls.Add(this.textBoxYvalue);
            this.Controls.Add(this.textBoxXvalue);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBoxWIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNetwork";
            this.Text = "FormNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBoxWIP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private TextBox textBoxXvalue;
        private TextBox textBoxYvalue;
        private Button buttonAddPoint;
    }
}