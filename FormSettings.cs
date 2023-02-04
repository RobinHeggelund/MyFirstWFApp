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
        public FormSettings()
        {
            InitializeComponent();
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
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            pictureBox1.Width = 150;
            pictureBox1.Height = 150;

            this.pictureBox1.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)

        {

            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            pictureBox1.Width = 140;
            pictureBox1.Height = 140;

            this.pictureBox1.Location = new Point(x + 5, y + 5);
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
    }
}
