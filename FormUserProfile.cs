using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MyFirstWFApp
{
    public partial class FormUserProfile : Form
    {


        public FormUserProfile()
        {
            InitializeComponent();
        }

       

        private void pictureBoxAvatar1_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar1.Location.X;
            int y = pictureBoxAvatar1.Location.Y;

            pictureBoxAvatar1.Width = 130;
            pictureBoxAvatar1.Height = 130;

            this.pictureBoxAvatar1.Location = new Point(x-5, y-5);
        }

        private void pictureBoxAvatar1_MouseLeave(object sender, EventArgs e)

        {

            int x = pictureBoxAvatar1.Location.X;
            int y = pictureBoxAvatar1.Location.Y;
            
            pictureBoxAvatar1.Width = 120;
            pictureBoxAvatar1.Height = 120;

            this.pictureBoxAvatar1.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar2.Location.X;
            int y = pictureBoxAvatar2.Location.Y;

            pictureBoxAvatar2.Width = 130;
            pictureBoxAvatar2.Height = 130;

            this.pictureBoxAvatar2.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar2.Location.X;
            int y = pictureBoxAvatar2.Location.Y;

            pictureBoxAvatar2.Width = 120;
            pictureBoxAvatar2.Height = 120;

            this.pictureBoxAvatar2.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar3.Location.X;
            int y = pictureBoxAvatar3.Location.Y;

            pictureBoxAvatar3.Width = 130;
            pictureBoxAvatar3.Height = 130;

            this.pictureBoxAvatar3.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar3.Location.X;
            int y = pictureBoxAvatar3.Location.Y;

            pictureBoxAvatar3.Width = 120;
            pictureBoxAvatar3.Height = 120;

            this.pictureBoxAvatar3.Location = new Point(x + 5, y + 5);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar4.Location.X;
            int y = pictureBoxAvatar4.Location.Y;

            pictureBoxAvatar4.Width = 130;
            pictureBoxAvatar4.Height = 130;

            this.pictureBoxAvatar4.Location = new Point(x - 5, y - 5);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar4.Location.X;
            int y = pictureBoxAvatar4.Location.Y;

            pictureBoxAvatar4.Width = 120;
            pictureBoxAvatar4.Height = 120;

            this.pictureBoxAvatar4.Location = new Point(x + 5, y + 5);
        }

        private void pictureBoxAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxAvatar2_Click(object sender, EventArgs e)
        {
            pictureBoxUserImage.Image = pictureBoxAvatar2.Image;
        }

        private void pictureBoxAvatar3_Click(object sender, EventArgs e)
        {
            pictureBoxUserImage.Image = pictureBoxAvatar3.Image;
        }

        private void pictureBoxAvatar4_Click(object sender, EventArgs e)
        {
            pictureBoxUserImage.Image = pictureBoxAvatar4.Image;
        }
    }
}
