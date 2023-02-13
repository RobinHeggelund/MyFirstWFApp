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
using System.Windows.Forms.DataVisualization.Charting;

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

        // Create variables for connected instrument

        string instrumentScaled;
        string instrumentAlarmLow;
        string instrumentAlarmHigh;
        string instrumentName;
        string instrumentLRV;
        string instrumentURV;
        int instrumentStatus; // 0 = OK, 1 = Fail, 2 = Low Alarm, 3 = High Alarm

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

            else
            {
                timerConnection_readscaled.Enabled = true;
            }

            

        }

        private void SendCommandToBE(string commandToSend)
        {
            //TCP Server start
            // make an endpoint for communication:

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Convert.ToInt32(textBoxInputPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(endpoint);
            }

            catch (System.Net.Sockets.SocketException ex)
            {

                MessageBox.Show(ex.Message);
                timerConnection_readscaled.Stop();
                return;
  
            }
            
         


            if (client.Connected)
            {
                mainForm.toolStripStatusLabel1.Text = "Connected";



                if (connected == false)
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Connected to server" + "\r\n");
                    connected = true;
                }




            }

            //Client send confirmation
   
            
            client.Send(Encoding.ASCII.GetBytes(commandToSend));
            



            //Client recieve

            byte[] buffer = new byte[1024];
            int bytesRecieved = client.Receive(buffer);
            string responseRecieved = Encoding.ASCII.GetString(buffer, 0, bytesRecieved);

            //Split string

            string[] responseRecievedArray = responseRecieved.Split(';');

            //Check respons type, deligate values to variables
            //and return a readable message to connection log

            if (responseRecievedArray[0] == "readconf" && responseRecievedArray.Length == 6)
            {
                instrumentName = responseRecievedArray[1];
                instrumentLRV = responseRecievedArray[2];
                instrumentURV = responseRecievedArray[3];
                instrumentAlarmLow = responseRecievedArray[4];
                instrumentAlarmHigh = responseRecievedArray[5];

                // Update connection log:

                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Name: " + instrumentName + "\r\n");
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument LRV: " + instrumentLRV + "\r\n");
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument URV: " + instrumentURV + "\r\n");
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Alarm Floor: " + instrumentAlarmLow + "\r\n");
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Alarm Ceiling: " + instrumentAlarmHigh + "\r\n");
            }

            else if (responseRecievedArray[0] == "writeconf")
            {
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument updated successfully!" + "\r\n");

            }

            else if (responseRecievedArray[0] == "readscaled")
            {
                instrumentScaled = responseRecievedArray[1];
                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument brightness reading: " + instrumentScaled + " [lux]\r\n");
            }

            else if (responseRecievedArray[0] == "readstatus")
            {
                instrumentStatus = int.Parse(responseRecievedArray[1]);


                if (instrumentStatus == 0)
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: OK\r\n");
                }

                else if (instrumentStatus == 1)
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: FAIL\r\n");
                }

                else if (instrumentStatus == 2)
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: LOW ALARM\r\n");
                }

                else if (instrumentStatus == 3)
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: HIGH ALARM\r\n");
                }

            }

            else
            {

                textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Error. No valid return from server.\r\n" + "[" + DateTime.Now.ToShortTimeString() + "] " + "Check instrumentBE.exe or logfile.\r\n");
            }
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

        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.AddXY(Convert.ToDouble(textBoxXvalue.Text), Convert.ToDouble(textBoxYvalue.Text));
            //textBoxXvalue.Text = textBoxYvalue.Text = "";
        }

        private void panelBorderConnectionLog_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panelConnectionLog.Handle, 0x112, 0xf012, 0);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            timerConnection_readscaled.Enabled = false;
        }

        private void timerConnection_readscaled_Tick(object sender, EventArgs e)
        {
            SendCommandToBE("readscaled");
        }
    }
}
