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
            int x = pictureBoxHelp.Location.X;
            int y = pictureBoxHelp.Location.Y;

            pictureBoxHelp.Width = 150;
            pictureBoxHelp.Height = 150;

            this.pictureBoxHelp.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)

        {

            int x = pictureBoxHelp.Location.X;
            int y = pictureBoxHelp.Location.Y;

            pictureBoxHelp.Width = 140;
            pictureBoxHelp.Height = 140;

            this.pictureBoxHelp.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBox2.Location.X;
            int y = pictureBox2.Location.Y;

            pictureBox2.Width = 174;
            pictureBox2.Height = 160;

            this.pictureBox2.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBox2.Location.X;
            int y = pictureBox2.Location.Y;

            pictureBox2.Width = 164;
            pictureBox2.Height = 150;

            this.pictureBox2.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBox3.Location.X;
            int y = pictureBox3.Location.Y;

            pictureBox3.Width = 150;
            pictureBox3.Height = 150;

            this.pictureBox3.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBox3.Location.X;
            int y = pictureBox3.Location.Y;

            pictureBox3.Width = 140;
            pictureBox3.Height = 140;

            this.pictureBox3.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBox4.Location.X;
            int y = pictureBox4.Location.Y;

            pictureBox4.Width = 150;
            pictureBox4.Height = 150;

            this.pictureBox4.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBox4.Location.X;
            int y = pictureBox4.Location.Y;

            pictureBox4.Width = 140;
            pictureBox4.Height = 140;

            this.pictureBox4.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // About Box

            FormAboutBox FrmAboutBox = new FormAboutBox();
            FrmAboutBox.ShowDialog();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            // Open File Dialog


            string fileName;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
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
                    MessageBox.Show("Filename: " + fileName + " imported.");
                }
            }

            






        }
    }
}
