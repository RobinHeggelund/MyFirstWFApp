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
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;

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
        bool waitingForConnection = false;


        public void buttonConnect_Click(object sender, EventArgs e)
        {

            // If IP and Port textboxes are empty, beep and focus on IP textbox


            if (textBoxIP.Text.Length < 2)
            {
                SystemSounds.Beep.Play();

                textBoxIP.Focus();
                return;
                

            }

            else if (textBoxInputPort.Text.Length < 2)
            {
                SystemSounds.Beep.Play();
                textBoxInputPort.Focus();
                return;
               
            }

            // If IP and Port textboxes are filled, start sending requests to backend
            
            else if (textBoxIP.Text.Length > 2 && textBoxInputPort.Text.Length > 2)
            {
                // Toggle buttons

                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = false;

                // While waiting, change the cursor to waiting cursors

                waitingForConnection = true;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                mainForm.toolStripStatusLabel1.Text = "...Connecting";
                labelChartStatus.Text = "Connecting..";
                TogglePictureBoxChartStatus();


                // Remove points in chart

                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                
                timerConnection_readscaled.Enabled = true;
                timerConnection_readscaled.Start();

                timerConnection_readstatus.Enabled = true;
                timerConnection_readstatus.Start();
            }

        }

        private void TogglePictureBoxChartStatus()
        {
            if (waitingForConnection)
            {
                pictureBoxChartStatus.Image = Properties.Resources.loading;
                pictureBoxChartStatus.Refresh();
                pictureBoxChartStatus.Visible = true;
            }

            else
            {
                pictureBoxChartStatus.Image = Properties.Resources.no_connection;
                pictureBoxChartStatus.Refresh();
                pictureBoxChartStatus.Visible = true;
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

                // Stop sending requests
               
                timerConnection_readscaled.Stop();
                timerConnection_readscaled.Enabled = false;

                timerConnection_readstatus.Stop();
                timerConnection_readstatus.Enabled = false;


                // Give user feedback

                waitingForConnection = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                mainForm.toolStripStatusLabel1.Text = "Connection Failed";
                labelChartStatus.Text = "No Connection";
                TogglePictureBoxChartStatus();

                // Toggle buttons

                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;

                // Display error message

                MessageBox.Show(ex.Message);
                return;
  
            }          
            
            if (client.Connected)
            {

                // Give user feedback

                
                this.Cursor = System.Windows.Forms.Cursors.Default;
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

            try
            {
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

                    // Fill textboxes with values

                    
                    textBoxInstrumentName.Text = instrumentName;
                    textBoxLRV.Text = instrumentLRV;
                    textBoxURV.Text = instrumentURV;
                    textBoxAlarmLow.Text = instrumentAlarmLow;
                    textBoxAlarmHigh.Text = instrumentAlarmHigh;
                    
                    
                }

                else if (responseRecievedArray[0] == "writeconf")
                {
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument updated successfully!" + "\r\n");

                }

                else if (responseRecievedArray[0] == "readscaled")
                {

                    // User Feedback
                    panelChartStatus.Visible = false;
                    waitingForConnection = false;
                    labelChartStatus.Text = "No Connection";

                    // Update Connection Log

                    instrumentScaled = responseRecievedArray[1];
                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument brightness reading: " + instrumentScaled + " [lux]\r\n");

                    // Toggle Buttons

                    buttonDisconnect.Enabled = true;

                    // Add readscale point to chart

                    if (chart1.Series[0].Points.Count > 6)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }

                    chart1.Series[0].Points.AddXY(DateTime.Now.ToLongTimeString(), instrumentScaled);

                }

                else if (responseRecievedArray[0] == "readstatus")
                {

                    // Update instrument alarm status

                    instrumentStatus = int.Parse(responseRecievedArray[1]);

                    // Update Connection Log and pictureboxes

                    if (instrumentStatus == 0)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: OK\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmGreen;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmGreen;
                    }

                    else if (instrumentStatus == 1)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: FAIL\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmYellow;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmYellow;
                    }

                    else if (instrumentStatus == 2)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: LOW ALARM\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmGreen;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmRed;
                    }

                    else if (instrumentStatus == 3)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: HIGH ALARM\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmRed;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmGreen;
                    }

                }

                else
                {

                    textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Error. No valid return from server.\r\n" + "[" + DateTime.Now.ToShortTimeString() + "] " + "Check instrumentBE.exe or logfile.\r\n");
                    pictureBoxAlarmHigh.Image = Properties.Resources.alarmBlack;
                    pictureBoxAlarmLow.Image = Properties.Resources.alarmBlack;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonConnect, null);
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
            // stop sending requests
            timerConnection_readscaled.Stop();
            timerConnection_readscaled.Enabled = false;

            timerConnection_readstatus.Stop();
            timerConnection_readstatus.Enabled = false;

            // User feedback

            TogglePictureBoxChartStatus();
            textBoxIP.Enabled = true;
            textBoxInputPort.Enabled = true;
            pictureBoxButtonSearch.Enabled = true;
            textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Disconnected.\r\n");
            mainForm.toolStripStatusLabel1.Text = "Ready - Disconnected";
            panelChartStatus.Visible = true;

            // Toggle buttons

            connected = false;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;




        }

        private void timerConnection_readscaled_Tick(object sender, EventArgs e)
        {
            SendCommandToBE("readscaled");
        }

        private void buttonOKConnectionLog_Click(object sender, EventArgs e)
        {
            panelConnectionLog.Visible = false;
        }

        private void pictureBoxConnectionLogClose_Click(object sender, EventArgs e)
        {
            panelConnectionLog.Visible = false;
        }

        private void panelConnectionLogClose_Click(object sender, EventArgs e)
        {
            panelConnectionLog.Visible = false;
        }

        private void pictureBoxConnectionLogClose_MouseEnter(object sender, EventArgs e)
        {
            panelConnectionLogClose.BackColor = Dark;
        }

        private void pictureBoxConnectionLogClose_MouseLeave(object sender, EventArgs e)
        {
            panelConnectionLogClose.BackColor = MediumDark;
        }

        private void panelConnectionLogClose_MouseEnter(object sender, EventArgs e)
        {
            panelConnectionLogClose.BackColor = Dark;
        }

        private void panelConnectionLogClose_MouseLeave(object sender, EventArgs e)
        {
            panelConnectionLogClose.BackColor = MediumDark;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelConnectionLog.Visible = true;
            this.panelConnectionLog.Location = new Point(409,177);

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxShowConnectionLog.Image = Properties.Resources.connectionLogBlue;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxShowConnectionLog.Image = Properties.Resources.connectionLogBlack;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (panelChart.Dock == DockStyle.None)
            {
                pictureBoxNewWindowChart.Image = Properties.Resources.newWindowBlue;
            }
            else
            {
                pictureBoxNewWindowChart.Image = Properties.Resources.minimizeBlue;
            }
            

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (panelChart.Dock == DockStyle.None)
            {
                pictureBoxNewWindowChart.Image = Properties.Resources.newWindowBlack;
            }
            else
            {
                pictureBoxNewWindowChart.Image = Properties.Resources.minimizeBlack;
            }
        }

        private void pictureBoxNewWindowChart_Click(object sender, EventArgs e)
        {
            
                // dock graph
                panelChart.Dock = DockStyle.Fill;
                panelChartStatus.Dock = DockStyle.Fill;
                panelChartBackground.Dock = DockStyle.Fill;
                
                // Hide elements
                panelInstrumentConfig.Visible = false;
                pictureBoxAlarmHigh.Visible = false;
                pictureBoxAlarmLow.Visible = false;
                labelAlarmHigh.Visible = false;
                labelAlarmLow.Visible = false;
                pictureBoxShowConnectionLog.Visible = false;
                pictureBoxNewWindowChart.Visible = false;

                pictureBoxMinimizeFullscreen.Visible = true;
                pictureBoxNewWindowChart.Image = Properties.Resources.newWindowBlack;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // remove focus
            pictureBoxLeapFrog.Focus();
            // send command
            SendCommandToBE("readconf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // remove focus
            pictureBoxLeapFrog.Focus();

            // ask for password
            
            string password = Microsoft.VisualBasic.Interaction.InputBox("Please enter the password to write the configuration to instrument: " + instrumentName, "Password", "", -1, -1);

            // create command
            string writeconfCommand = "writeconf>" + password + ">"
                                    + textBoxInstrumentName.Text + ";"
                                    + textBoxLRV.Text + ";"
                                    + textBoxURV.Text + ";"
                                    + textBoxAlarmLow.Text + ";"
                                    + textBoxAlarmHigh.Text;



            Console.WriteLine(writeconfCommand);
            // send command
            SendCommandToBE(writeconfCommand);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxLRV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxAlarmLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxAlarmHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerConnection_readstatus_Tick(object sender, EventArgs e)
        {
            SendCommandToBE("readstatus");
            
        }
        
        private void labelAlarmHigh_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxMinimizeFullscreen_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxMinimizeFullscreen.Image = Properties.Resources.minimizeBlue1;
        }

        private void pictureBoxMinimizeFullscreen_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMinimizeFullscreen.Image = Properties.Resources.minimizeBlack1;
        }

        private void pictureBoxMinimizeFullscreen_Click(object sender, EventArgs e)
        {
            // undock graph
            panelChart.Dock = DockStyle.None;
            panelChartStatus.Dock = DockStyle.None;
            panelChartBackground.Dock = DockStyle.None;
            pictureBoxNewWindowChart.Image = Properties.Resources.minimizeBlack;

            // Show elements
            panelInstrumentConfig.Visible = true;
            pictureBoxAlarmHigh.Visible = true;
            pictureBoxAlarmLow.Visible = true;
            labelAlarmHigh.Visible = true;
            labelAlarmLow.Visible = true;
            pictureBoxShowConnectionLog.Visible = true;
            pictureBoxNewWindowChart.Visible = true;

            pictureBoxMinimizeFullscreen.Visible = false;
        }
    }
}
    
