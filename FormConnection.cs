using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace MyFirstWFApp
{
    public partial class FormConnection : Form

    {

        // Creating color pallet

        Color DiscordBlue = Color.FromArgb(114, 137, 218);
        Color Light = Color.FromArgb(71, 74, 78);
        Color MediumLight = Color.FromArgb(66, 69, 73);
        Color Medium = Color.FromArgb(54, 57, 62);
        Color MediumDark = Color.FromArgb(40, 43, 48);
        Color Dark = Color.FromArgb(30, 33, 36);

        Form1 mainForm;
        
        // Creating lists
        
        List<string> servers = new List<string>();

        // Custom Border

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        public FormConnection(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        // Initialization end

        bool connected = false;


        public void buttonConnect_Click(object sender, EventArgs e)
        {

            if (textBoxIP.Text.Length == 0)
            {
                SystemSounds.Beep.Play();

                textBoxIP.Focus();

                

                return;

            }

            else if (textBoxInputPort.Text.Length == 0)
            {
                SystemSounds.Beep.Play();
                textBoxInputPort.Focus();
                return;
            }

            else if (textBoxSend.Text.Length == 0)
            {
                SystemSounds.Beep.Play();
                textBoxSend.Focus();
                return;

            }

            //TCP Server start
            // make an endpoint for communication:

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Convert.ToInt32(textBoxInputPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(endpoint);
            

            if (client.Connected)
            {
                mainForm.toolStripStatusLabel1.Text = "Connected";



                if (connected == false)
                {
                    textBoxCommunication.AppendText("Connected to server" + "\r\n");
                    connected = true;
                }
                
                
                buttonSend.Enabled = true;

            }

            //client send
            if (textBoxSend.Text.Length >0)
            {
                client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text));
            }

            else
            {
                client.Send(Encoding.ASCII.GetBytes("EMPTY"));
            }
                
            


            //client recieve
            byte[] buffer = new byte[1024];
            int bytesRecieved = client.Receive(buffer);
            textBoxCommunication.AppendText(Encoding.ASCII.GetString(buffer, 0, bytesRecieved) + "\r\n");

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonConnect, null);
        }

        private void textBoxSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormConnection_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxInputPort_KeyPress(object sender, KeyPressEventArgs e)
            
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                InvokeOnClick(buttonConnect, null);
            }
            
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (textBoxInputPort.Text.Length > 3 && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
            }

        }

        private void pictureBoxButtonSearch_Click(object sender, EventArgs e)
          
        {
            panelIPSearch.Visible = true;
            this.panelIPSearch.Location = new Point(260, 209);

            IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresslist)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    servers.Clear();
                    servers.Add(address.ToString());
                }
            }

            listBoxIPAdress.Items.Clear();
           
            listBoxIPAdress.Items.AddRange(servers.ToArray());
        }

        private void pictureBoxButtonSearch_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxButtonSearch.Image = Properties.Resources.loupe;
        }

        private void pictureBoxButtonSearch_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxButtonSearch.Image = Properties.Resources.search;
        }

        private void listBoxIPAdress_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxIPAdress.SelectedItems.Count > 0)
            {
                buttonIPSearchConfirm.Enabled = true;
            }
        }

        private void buttonIPSearchConfirm_Click(object sender, EventArgs e)
        {
            

            if (listBoxIPAdress.SelectedItem != null)
            {
                textBoxIP.Text = listBoxIPAdress.SelectedItem.ToString();
            }

            panelIPSearch.Visible = false;
            buttonIPSearchConfirm.Enabled = false;


        }

        private void buttonIPSearchCancle_Click(object sender, EventArgs e)
        {
            panelIPSearch.Visible = false;
            buttonIPSearchConfirm.Enabled = false;
        }

        private void panelBoarderSearch_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panelIPSearch.Handle, 0x112, 0xf012, 0);
            
            
        }

        private void panelBoarderSearchClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = Dark;
        }

        private void panelBoarderSearchClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = MediumDark;

        }

        private void pictureBoxBoarderSearchClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = Dark;

        }

        private void pictureBoxBoarderSearchClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = Dark;

        }

        private void panelBoarderSearchClose_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonIPSearchCancle, null);
        }

        private void pictureBoxSearchBoarderClose_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonIPSearchCancle, null);
        }
    }
}
