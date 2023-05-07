using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWFApp
{
    public partial class FormSettings : Form

    {
        Form1 mainForm;

        List<Instrument> instrumentList = new List<Instrument>();
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

        public string instrumentListFileLocation = (Environment.CurrentDirectory + "\\instruments.csv");

        int sessionTime = 0;
        DateTime sessionStartTime = DateTime.Now;


        public FormSettings(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            
        }

        private void buttonRefreshSummary_Click(object sender, EventArgs e)
        {
            // System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
            // double sessionTimeSeconds = Math.Ceiling(sessionTime.TotalSeconds);
            //  textBoxSummary.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update instrument summary
            int AnalogSummary = mainForm.AnalogSummary;
            int DigitalSummary = mainForm.DigitalSummary;
            int FieldbusSummary = mainForm.FieldbusSummary;
            int TotalSummary = mainForm.TotalSummary;
            sessionTime += 1;
            

            labelSummaryAnalog.Text = AnalogSummary.ToString();
            labelSummaryDigital.Text = DigitalSummary.ToString();
            labelSummaryFieldBus.Text = FieldbusSummary.ToString();
            labelSummaryTotal.Text = TotalSummary.ToString();

            TimeSpan elapsed = DateTime.Now - sessionStartTime;
            labelSummaryTime.Text = elapsed.Minutes + " Min, " + elapsed.Seconds + " Sec";
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxSettings1.Location.X;
            int y = pictureBoxSettings1.Location.Y;

            pictureBoxSettings1.Width = 150;
            pictureBoxSettings1.Height = 150;

            this.pictureBoxSettings1.Location = new Point(x - 5, y - 5);

            labelSettings.Text = "About";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)

        {

            int x = pictureBoxSettings1.Location.X;
            int y = pictureBoxSettings1.Location.Y;

            pictureBoxSettings1.Width = 140;
            pictureBoxSettings1.Height = 140;

            this.pictureBoxSettings1.Location = new Point(x + 5, y + 5);

            labelSettings.Text = "";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxSettings2.Location.X;
            int y = pictureBoxSettings2.Location.Y;

            pictureBoxSettings2.Width = 174;
            pictureBoxSettings2.Height = 160;

            this.pictureBoxSettings2.Location = new Point(x - 5, y - 5);

            labelSettings.Text = "Change instrument directory";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxSettings2.Location.X;
            int y = pictureBoxSettings2.Location.Y;

            pictureBoxSettings2.Width = 164;
            pictureBoxSettings2.Height = 150;

            this.pictureBoxSettings2.Location = new Point(x + 5, y + 5);

            labelSettings.Text = "";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxSettings3.Location.X;
            int y = pictureBoxSettings3.Location.Y;

            pictureBoxSettings3.Width = 150;
            pictureBoxSettings3.Height = 150;

            this.pictureBoxSettings3.Location = new Point(x - 5, y - 5);

            labelSettings.Text = "Import instrument list from directory";


        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxSettings3.Location.X;
            int y = pictureBoxSettings3.Location.Y;

            pictureBoxSettings3.Width = 140;
            pictureBoxSettings3.Height = 140;

            this.pictureBoxSettings3.Location = new Point(x + 5, y + 5);

            labelSettings.Text = "";
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxSettings4.Location.X;
            int y = pictureBoxSettings4.Location.Y;

            pictureBoxSettings4.Width = 150;
            pictureBoxSettings4.Height = 150;

            this.pictureBoxSettings4.Location = new Point(x - 5, y - 5);

            labelSettings.Text = "Import instrument list from database";
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxSettings4.Location.X;
            int y = pictureBoxSettings4.Location.Y;

            pictureBoxSettings4.Width = 140;
            pictureBoxSettings4.Height = 140;

            this.pictureBoxSettings4.Location = new Point(x + 5, y + 5);

            labelSettings.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // About Box

            FormAboutBox FrmAboutBox = new FormAboutBox();
            FrmAboutBox.ShowDialog();


        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            // Set instrumentList path

            string folderPath;


            folderBrowserDialog1.InitialDirectory = "c:\\";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;

                string message = "Are you sure you want to set this directory to your default instrument list location?";
                string caption = "Confirm instrument list path";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(this, message, caption, buttons, icon);

                if (result == DialogResult.Yes)
                {

                    mainForm.instrumentListFileLocation = (folderPath + "\\instrumentList.csv");
                    

                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Import instrumentList from file

            string fileName;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "text files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                string message = "Are you sure you want to import this file?";
                string caption = "Confirm filename";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(this, message, caption, buttons, icon);

                if (result == DialogResult.Yes)
                {
                    string instrumentLine = "";
                    string[] instrumentLineParts;

                    if (File.Exists(fileName))
                    {

                        var inputFile = new StreamReader(fileName);

                        if (inputFile != null)

                        {

                            while (!inputFile.EndOfStream)
                            {

                                instrumentLine = inputFile.ReadLine();
                                instrumentLineParts = instrumentLine.Split(";");

                                Instrument instrument = new Instrument(Convert.ToDateTime(instrumentLineParts[0]),
                                                                        instrumentLineParts[1],
                                                                        instrumentLineParts[2],
                                                                        instrumentLineParts[3],
                                                                        instrumentLineParts[4],
                                                                        instrumentLineParts[5],
                                                                        instrumentLineParts[6],
                                                                        instrumentLineParts[7],
                                                                        Convert.ToDouble(instrumentLineParts[8]),
                                                                        Convert.ToDouble(instrumentLineParts[9]),
                                                                        Convert.ToInt32(instrumentLineParts[10]),
                                                                        Convert.ToInt32(instrumentLineParts[11]),
                                                                        Convert.ToString(instrumentLineParts[12]));
                                instrumentList.Add(instrument);
                                
                                
                                

                            }

                        }

                        inputFile.Close();
                    }
                }
                
            }
        }
    }
}
