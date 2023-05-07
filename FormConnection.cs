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
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyFirstWFApp
{

    public partial class FormConnection : Form

    {
        // Folderpath dialog and instrument list

        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string instrumentListFileLocation = (Environment.CurrentDirectory + "\\instruments.csv");

        // Creating color pallet

        Color DiscordBlue = Color.FromArgb(114, 137, 218);
        Color Light = Color.FromArgb(71, 74, 78);
        Color MediumLight = Color.FromArgb(66, 69, 73);
        Color Medium = Color.FromArgb(54, 57, 62);
        Color MediumDark = Color.FromArgb(40, 43, 48);
        Color Dark = Color.FromArgb(30, 33, 36);
        Color TextBlack = Color.FromArgb(0, 0, 25);
        Color TextWhite = Color.FromArgb(240, 240, 240);

        Form1 mainForm;

        // Create variables for connected instrument

        string instrumentScaled;
        string instrumentAlarmLow;
        string instrumentAlarmHigh;
        string instrumentName;
        string instrumentLRV;
        string instrumentURV;
        int instrumentStatus; // 0 = OK, 1 = Fail, 2 = Low Alarm, 3 = High Alarm
        string instrumentUnit = "Unit";

        // Creating lists

        List<string> servers = new List<string>();

        List<(string instrumentScaled, DateTime timestamp)> scaledDataRecievedLogList = new List<(string, DateTime)>();

        List<InstrumentLog> instrumentLogList = new List<InstrumentLog>();

        List<Instrument> instrumentList = new List<Instrument>();

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

        // State Variables

        bool connected = false;
        bool monitor = false;
        bool waitingForConnection = false;
        bool userSavedLogAsked = true;
        int usbTimeout = 0;
        bool userWarned = false;
        bool maximized = false;


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

                // Disable IP and Port boxes

                textBoxIP.Enabled = false;
                textBoxInputPort.Enabled = false;

                // While waiting, change the cursor to waiting cursors

                waitingForConnection = true;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                mainForm.toolStripStatusLabel1.Text = "...Connecting";
                labelChartStatus.Text = "Connecting..";
                labelChartStatus.Location = new Point(197, 112);
                TogglePictureBoxChartStatus();


                // Remove points in chart

                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();
                chart1.Series[0].Points.Add();

                // Start sending requests

                timerConnection_readscaled.Enabled = true;
                timerConnection_readscaled.Start();

                timerConnection_readstatus.Enabled = true;
                timerConnection_readstatus.Start();




            }

        }

        private void TogglePictureBoxChartStatus()
        {
            // show connection status to user
            
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
                labelChartStatus.Location = new Point(197, 112);
                TogglePictureBoxChartStatus();

                // Toggle buttons

                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;

                // Toggle IP and Port Boxes

                textBoxIP.Enabled = true;
                textBoxInputPort.Enabled = true;

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
                    // convert writeconf status
                    
                    int writeconfSucess = int.Parse(responseRecievedArray[1]);

                    // writeconf sucessfull
                    
                    if (writeconfSucess == 1)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument updated successfully!" + "\r\n");
                        MessageBox.Show("Instrument updated successfully!");

                        SendCommandToBE("readconf" + "," + textBoxCOM.Text + "," + textBoxBaud.Text);
                    }

                    // writeconf failed

                    else if (writeconfSucess == 0)
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument update failed!" + "\r\n");
                        MessageBox.Show("Instrument update failed" + "\r\nPlease check password");
                    }
                }

                else if (responseRecievedArray[0] == "readscaled")
                {

                    // User Feedback
                    
                    panelChartStatus.Visible = false;
                    panelComAndBitrateBackground.Visible = false;
                    waitingForConnection = false;
                    labelChartStatus.Text = "No Connection";
                    labelChartStatus.Location = new Point(197, 112);

                    // Ask user to save log to file if they disconnect

                    userSavedLogAsked = false;

                    // Display Controls

                    buttonConfigureInstrument.Enabled = true;
                    buttonFullscreen.Enabled = true;
                    buttonSaveLog.Enabled = true;
                    buttonConnectionLog.Enabled = true;
                    labelMonitor.Visible = true;
                    buttonStopMonitor.Enabled = true;


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
                   
                    //

                    chart1.Series[0].Points.AddXY(DateTime.Now.ToLongTimeString(), instrumentScaled);

                    // Set chart maximum and minimum values from instrument config

                    if (instrumentURV != null && instrumentLRV != null)
                    {
                        string[] maxArray = instrumentURV.Split('.');
                        string[] minArray = instrumentLRV.Split('.');

                        int max = int.Parse(maxArray[0]);
                        int min = int.Parse(minArray[0]);


                        chart1.ChartAreas[0].AxisY.Maximum = max;
                        chart1.ChartAreas[0].AxisY.Minimum = min;
                    }

                    // Display instrument name

                    labelMonitor.Text = "Instrument: " + instrumentName;

                    // Display instrument unit
                    
                    if (textBoxUnit.Text.Length > 0)
                    {
                        labelInstrumentUnit.Text = "[ " + textBoxUnit.Text + " ]";

                    }
                    else
                    {
                        labelInstrumentUnit.Text = "[ lux ]";

                    }

                    // Show alarm zones in graph

                    chart1.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
                    {
                        IntervalOffset = double.Parse(instrumentAlarmLow),
                        Interval = 0,
                        BorderColor = Color.Red,
                        BorderWidth = 2,
                        BorderDashStyle = ChartDashStyle.Dash,
                        StripWidth = 0.1,
                        Text = "",
                        TextLineAlignment = StringAlignment.Far,
                        TextOrientation = TextOrientation.Rotated270,
                        TextAlignment = StringAlignment.Center,

                    });

                    chart1.ChartAreas[0].AxisY.StripLines.Add(new StripLine()
                    {
                        IntervalOffset = double.Parse(instrumentAlarmHigh),
                        Interval = 0,
                        BorderColor = Color.Red,
                        BorderWidth = 2,
                        BorderDashStyle = ChartDashStyle.Dash,
                        StripWidth = 0.1,
                        Text = "",
                        TextLineAlignment = StringAlignment.Far,
                        TextOrientation = TextOrientation.Rotated270,
                        TextAlignment = StringAlignment.Center,

                    });

                    // Delete alarmzones if there are more than 2

                    if (chart1.ChartAreas[0].AxisY.StripLines.Count > 2)
                    {
                        chart1.ChartAreas[0].AxisY.StripLines.RemoveAt(0);
                        chart1.ChartAreas[0].AxisY.StripLines.RemoveAt(0);
                    }

                    labelValueScaled.Text = instrumentScaled.Substring(0, 5);

                    // Create new InstrumentLog and Update list

                    try

                    {
                        InstrumentLog instrumentLog = new InstrumentLog( DateTime.Now, instrumentScaled.Substring(0, (instrumentScaled.Length - 2)));

                        instrumentLogList.Add(instrumentLog);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                else if (responseRecievedArray[0] == "readstatus")
                {

                    // Convert readstatus to int

                    instrumentStatus = int.Parse(responseRecievedArray[1]);

                    // Give user feedback based on alarm status

                    if (instrumentStatus == 0) // alarmstatus = OK 
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: OK\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmGreen;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmGreen;

                        pictureBoxAlarmText.Visible = false;

                    }

                    else if (instrumentStatus == 1) // alarmstatus = Error 
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: FAIL\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmYellow;
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmYellow;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmYellow;

                        pictureBoxAlarmText.Visible = false;
                    }

                    else if (instrumentStatus == 2)// alarmstatus = Low Alarm 
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: LOW ALARM\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmGreen;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmRed;
                        
                        if (maximized)
                        {
                            pictureBoxAlarmText.Visible = true;
                        }
                    }

                    else if (instrumentStatus == 3)// alarmstatus = High Alarm
                    {
                        textBoxCommunication.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + "Instrument Status: HIGH ALARM\r\n");
                        pictureBoxAlarmHigh.Image = Properties.Resources.alarmRed;
                        pictureBoxAlarmLow.Image = Properties.Resources.alarmGreen;

                        if (maximized)
                        {
                            pictureBoxAlarmText.Visible = true;
                        }
                    }

                }

                else if (responseRecievedArray[0] == "ping")

                {
                    // Connected to BE but not instrument

                    // Activate controlls

                    buttonStartMonitor.Enabled = true;
                    buttonConfigureInstrument.Enabled = true;
                    buttonFullscreen.Enabled = true;
                    buttonSaveLog.Enabled = true;
                    buttonConnectionLog.Enabled = true;
                    labelCOM.Enabled = true;
                    labelBaudRate.Enabled = true;
                    textBoxCOM.Enabled = true;
                    textBoxBaud.Enabled = true;
                    buttonStartMonitorDisabled.Visible = false;
                    buttonStartMonitor.Visible = true;
                    buttonDisconnect.Enabled = true;

                    // Update visuals

                    labelChartStatus.Text = "Connected to BE";
                    labelChartStatus.Location = new Point(175, 112);
                    pictureBoxChartStatus.Image = Properties.Resources.chartStatusConnected;



                }

                else if (responseRecievedArray[0] == "error")
                {
                    // Error from BE: USB error
                    
                    if (responseRecievedArray[1] == "USB")
                    {
                        usbTimeout += 1;

                        if (usbTimeout == 3)
                        {
                            MessageBox.Show("USB Timeout. Check connection and try again.");

                            // Stop Monitoring
                            
                            InvokeOnClick(buttonStopMonitor, null);

                            usbTimeout = 0;

                        }
                    }
                }
                
                // Generic error
                
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

        private void textBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent user from typing illeagal characters into IP adress box
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxInputPort_KeyPress(object sender, KeyPressEventArgs e)

        {

            // Prevent user from typing illeagal characters into port box

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

        // Search for IP adress on local network
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
            mainForm.toolStripStatusLabel1.Text = "Disconnected";
            panelChartStatus.Visible = true;

            // Toggle buttons

            connected = false;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;

            // Enable IP and Port boxes

            textBoxIP.Enabled = true;
            textBoxInputPort.Enabled = true;

            // Stop Monitoring

            InvokeOnClick(buttonStopMonitor, null);

            buttonStartMonitor.Enabled = false;
            buttonConfigureInstrument.Enabled = false;
            buttonFullscreen.Enabled = false;
            buttonSaveLog.Enabled = false;
            buttonConnectionLog.Enabled = false;
            labelCOM.Enabled = false;
            labelBaudRate.Enabled = false;
            textBoxCOM.Enabled = false;
            textBoxBaud.Enabled = false;
            buttonStartMonitorDisabled.Visible = true;
            buttonStartMonitor.Visible = false;

            pictureBoxChartStatus.Image = Properties.Resources.chartStatusDisconnected;
            labelChartStatus.Text = "Disconnected";
            labelChartStatus.Location = new Point(187, 112);
        }

        private void timerConnection_readscaled_Tick(object sender, EventArgs e)
        {
            //send requests to BE
            
            if (monitor)
            {
                // Send readscaled
                
                SendCommandToBE("readscaled" + "," + textBoxCOM.Text + "," + textBoxBaud.Text);
            }

            else
            {
                // Ping
                
                SendCommandToBE("ping");
            }

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


        private void button2_Click(object sender, EventArgs e)
        {
            // remove focus

            pictureBoxLeapFrog.Focus();

            // send command

            if (textBoxCOM.Text.Length > 0 && textBoxBaud.Text.Length > 0)
            {
                SendCommandToBE("readconf" + "," + textBoxCOM.Text + "," + textBoxBaud.Text);

                // get instrument list 

                GetInstrumentList();

                // search instrument list for instrument name             

                foreach (Instrument instrument in instrumentList)
                {
                    if (instrument.SensorName == instrumentName)
                    {
                        // set unit type

                        textBoxUnit.Text = instrument.Unit;
                    }
                }
            }

            else
            {
                MessageBox.Show("Please enter a COM port and a Baud rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void WriteDataToFile()
        {
            try
            {
                StreamWriter outputFile = new StreamWriter(instrumentListFileLocation);

                foreach (Instrument instrument in instrumentList)
                {
                    outputFile.WriteLine(instrument.ToString());

                }

                outputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                                    + textBoxAlarmHigh.Text + "," + textBoxCOM.Text + "," + textBoxBaud.Text;



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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAlarmHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerConnection_readstatus_Tick(object sender, EventArgs e)
        {
            if (monitor)
            {
                SendCommandToBE("readstatus" + "," + textBoxCOM.Text + "," + textBoxBaud.Text);
            }

        }

        private void labelAlarmHigh_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxMinimizeFullscreen_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxMinimizeFullscreen.Image = Properties.Resources.minimizeFromFullscreenBlue;
        }

        private void pictureBoxMinimizeFullscreen_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMinimizeFullscreen.Image = Properties.Resources.minimizeFromFullscreenBlack;
        }

        private void pictureBoxMinimizeFullscreen_Click(object sender, EventArgs e)
        {
            // undock graph
            panelChart.Dock = DockStyle.None;
            panelChartStatus.Dock = DockStyle.None;
            panelChartBackground.Dock = DockStyle.None;


            // Show elements
            panelInstrumentConfig.Visible = true;
            pictureBoxAlarmHigh.Visible = true;
            pictureBoxAlarmLow.Visible = true;
            labelAlarmHigh.Visible = true;
            labelAlarmLow.Visible = true;
            panelInstrumentStatus.Visible = true;
            labelMonitor.Visible = true;
            paneMonitorHeadline.Visible = true;
            buttonStopMonitor.Visible = true;

            maximized = false;

            pictureBoxAlarmText.Visible = false;


            pictureBoxMinimizeFullscreen.Visible = false;
        }

        private void buttonConfigureInstrument_Click(object sender, EventArgs e)
        {
            panelConfigureInstrument.Visible = true;
            this.panelConfigureInstrument.Location = new Point(260, 209);


        }



        private void panelConfigureInstrumentBoarder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panelConfigureInstrument.Handle, 0x112, 0xf012, 0);
        }



        private void pictureBoxConfigureInstrumentClose_MouseEnter(object sender, EventArgs e)
        {
            panelConfigureInstrumentClose.BackColor = Dark;
        }

        private void panelConfigureInstrumentClose_MouseEnter(object sender, EventArgs e)
        {
            panelConfigureInstrumentClose.BackColor = Dark;
        }

        private void panelConfigureInstrumentClose_MouseLeave(object sender, EventArgs e)
        {
            panelConfigureInstrumentClose.BackColor = MediumDark;
        }

        private void pictureBoxConfigureInstrumentClose_MouseLeave(object sender, EventArgs e)
        {
            panelConfigureInstrumentClose.BackColor = MediumDark;
        }

        private void pictureBoxConfigureInstrumentClose_Click(object sender, EventArgs e)
        {
            panelConfigureInstrument.Visible = false;
        }

        private void panelConfigureInstrumentClose_Click(object sender, EventArgs e)
        {
            panelConfigureInstrument.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelConfigureInstrument.Visible = false;

            labelConfigureInstrument.Text = "Configure Instrument";
        }

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {

            if (monitor)
            {
                // dock graph
                panelChart.Dock = DockStyle.Fill;
                panelChartStatus.Dock = DockStyle.Fill;
                panelChartBackground.Dock = DockStyle.Fill;

                // Hide elements
                panelInstrumentConfig.Visible = false;
                panelIPSearch.Visible = false;
                panelConnectionLog.Visible = false;
                pictureBoxAlarmHigh.Visible = false;
                pictureBoxAlarmLow.Visible = false;
                labelAlarmHigh.Visible = false;
                labelAlarmLow.Visible = false;
                panelChartStatus.Visible = false;
                panelInstrumentStatus.Visible = false;
                labelMonitor.Visible = false;
                paneMonitorHeadline.Visible = false;
                buttonStopMonitor.Visible = false;



                pictureBoxMinimizeFullscreen.Visible = true;
                maximized = true;
                
                
            }


        }

        private void buttonConnectionLog_Click(object sender, EventArgs e)
        {
            panelConnectionLog.Visible = true;
            this.panelConnectionLog.Location = new Point(409, 177);
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            

            

            // Define the output file path

            string folderPath;

            folderBrowserDialog1.InitialDirectory = "c:\\";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath + "\\instrumentScaledValueLog.csv";

                string message = "Are you sure you want to save the instrumentScaledValueLog.csv file to this location?";
                string caption = "Confirm save";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(this, message, caption, buttons, icon);

                if (result == DialogResult.Yes)

                    // Write the data to the CSV file

                    try

                    {
                        StreamWriter outputFile = new StreamWriter(folderPath);

                        {
                            // Write overhead to file

                            outputFile.WriteLine("Time" + ";" + "Scaled");
                            

                            // Write each instrumentLog to a new line in the CSV file

                            foreach (InstrumentLog instrumentLog in instrumentLogList)
                            {
                                
                                outputFile.WriteLine(instrumentLog.ToString());
                            }

                            outputFile.Close();

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

            }
        }

        private void buttonSendConfigInfo_Click(object sender, EventArgs e)
        {
            // Send the configuration information to the instrument data screen

            mainForm.instrumentName = textBoxInstrumentName.Text;
            mainForm.lrv = textBoxLRV.Text;
            mainForm.urv = textBoxURV.Text;
            mainForm.alarmFloor = textBoxAlarmLow.Text;
            mainForm.alarmCeiling = textBoxAlarmHigh.Text;



        }

        private void buttonStartMonitor_Click(object sender, EventArgs e)
        {
            monitor = true;
            buttonStopMonitor.Visible = true;
            buttonStartMonitor.Visible = false;
            

            // disable com and bitrate selection

            
            textBoxCOM.Enabled = false;
            textBoxBaud.Enabled = false;


            SendCommandToBE("readconf" + "," + textBoxCOM.Text + "," + textBoxBaud.Text);

            GetInstrumentList();

            // search instrument list for instrument name             

            foreach (Instrument instrument in instrumentList)
            {
                if (instrument.SensorName == instrumentName)
                {
                    // set unit type

                    textBoxUnit.Text = instrument.Unit;


                }
            }
        }

        private void buttonStopMonitor_Click(object sender, EventArgs e)
        {
            monitor = false;
            buttonStartMonitor.Visible = true;
            buttonStopMonitor.Visible = false;
            buttonStopMonitor.Enabled = false;
            panelComAndBitrateBackground.Visible = true;
            panelChartStatus.Visible = true;

            // enable COM and Baud rate

            textBoxCOM.Enabled = true;
            textBoxBaud.Enabled = true;

            // Ask user if they want to save log to file, if they havent already done so

            if (userSavedLogAsked == false)

            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(this, "Do you want to save the log to a file?", "Save log", buttons, icon);

                if (result == DialogResult.Yes)
                {
                    InvokeOnClick(buttonSaveLog, null);
                }

                userSavedLogAsked = true;
            }

        }

        private void textBoxCOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent user from typing illeagal characters

            if (e.KeyChar == (char)Keys.Enter)
            {
                InvokeOnClick(buttonConnect, null);
            }

            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (textBoxCOM.Text.Length > 2 && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
            }
        }

        private void textBoxBaud_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent user from typing illeagal characters

            if (e.KeyChar == (char)Keys.Enter)
            {
                InvokeOnClick(buttonConnect, null);
            }

            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (textBoxBaud.Text.Length > 4 && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
            }
        }

        private void buttonImportInstrumentData_Click(object sender, EventArgs e)
        {
            // Show instrumnet list

            panelInstrumentSearchList.Visible = true;
            labelConfigureInstrument.Text = "Import from local file";

            // clear instrument list

            listBoxInstrumentList.Items.Clear();
            GetInstrumentList();
        }
        
        private void GetInstrumentList()
        {
            // Import instrument list

            string instrumentLine = "";
            string[] instrumentLineParts;
            instrumentList.Clear();

            string fileNameInstrumentList = (instrumentListFileLocation);

            if (File.Exists(fileNameInstrumentList))
            {

                var inputFile = new StreamReader(fileNameInstrumentList);

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
                    inputFile.Close();

                    // Update and Sort instrument list

                    int index = 0;
                    if (instrumentList.Count > 0)
                    {
                        // Sort instrumentList alphabetically in a case-insensitive manner

                        instrumentList.Sort((x, y) => string.Compare(x.SensorName, y.SensorName, StringComparison.OrdinalIgnoreCase));

                        // Update listbox

                        foreach (Instrument instrument in instrumentList)
                        {
                            listBoxInstrumentList.Items.Add(instrument.SensorName);
                            index += 1;
                        }
                    }
                }


            }
        }

        private void listBoxInstrumentList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxInstrumentList.SelectedItems.Count > 0)
            {
                buttonIPSearchConfirm.Enabled = true;
            }
        }

        private void buttonInstrumentListConfirm_Click(object sender, EventArgs e)
        {
            // Hide window

            panelInstrumentSearchList.Visible = false;
            labelConfigureInstrument.Text = "Configure Instrument";

            // Clear all boxes

            textBoxInstrumentName.Clear();
            textBoxLRV.Text = 0.0f.ToString();
            textBoxURV.Text = 0.0f.ToString();
            textBoxAlarmLow.Clear();
            textBoxAlarmHigh.Clear();
            textBoxUnit.Clear();


            // Fill boxes with selected sensor data

            int index = listBoxInstrumentList.SelectedIndex;

            textBoxInstrumentName.Text = instrumentList[index].SensorName;
            textBoxLRV.Text = instrumentList[index].LRV.ToString();
            textBoxURV.Text = instrumentList[index].URV.ToString();
            textBoxAlarmLow.Text = instrumentList[index].AlarmFloor.ToString();
            textBoxAlarmHigh.Text = instrumentList[index].AlarmCeiling.ToString();
            textBoxUnit.Text = instrumentList[index].Unit;
        }

        private void buttonInstrumentListCancle_Click(object sender, EventArgs e)
        {
            // Hide window

            panelInstrumentSearchList.Visible = false;
            labelConfigureInstrument.Text = "Configure Instrument";

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBaud_TextChanged(object sender, EventArgs e)
        {
            if (userWarned == false)
            {
                //warn user about baudrate error

                MessageBox.Show("Warning: Changing baud rate can cause critical errors" + "\r\nCheck instrument for specifications");
                userWarned = true;
            }
        }

        private void buttonSaveSSC_Click(object sender, EventArgs e)
        {
            // save configuration to .ssc file

            string fileName = textBoxInstrumentName.Text + ".ssc";

            SaveSSCFile(fileName);
        }

        private void SaveSSCFile(string fileName)
        {
            // create data string

            string instrumentConfigDataString = textBoxInstrumentName.Text + ";"
                                              + textBoxLRV.Text + ";"
                                              + textBoxURV.Text + ";"
                                              + textBoxUnit.Text + ";"
                                              + textBoxAlarmLow.Text + ";"
                                              + textBoxAlarmHigh.Text;
            // split data string into array

            string[] instrumentConfigDataArray = instrumentConfigDataString.Split(";");

            // Define the output file path

            string folderPath;

            folderBrowserDialog1.InitialDirectory = Environment.CurrentDirectory;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;


            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath + "\\" + fileName;

                string message = "Are you sure you want to save the instrument configuration file to this location?";
                string caption = "Confirm save";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;

                result = MessageBox.Show(this, message, caption, buttons, icon);

                if (result == DialogResult.Yes)

                    // Write the data to the SSC file

                    if (File.Exists(fileName))

                    {
                        // file already exists

                        DialogResult dialogResult = MessageBox.Show("File already exists, overwrite?", "File already exists", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // overwrite file

                            try
                            {
                                StreamWriter outputFile = new StreamWriter(folderPath);
                                {

                                    // Write each instrumentLog to a new line in the SSC file

                                    foreach (string instrumentConfigData in instrumentConfigDataArray)
                                    {
                                        outputFile.WriteLine(instrumentConfigData.ToString());
                                    }

                                    outputFile.Close();

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }


                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            // do nothing
                        }
                    }

                else

                    {

                        try
                            {
                            StreamWriter outputFile = new StreamWriter(folderPath);
                            {

                                // Write each instrumentLog to a new line in the SSC file

                                foreach (string instrumentConfigData in instrumentConfigDataArray)
                                {
                                    outputFile.WriteLine(instrumentConfigData.ToString());
                                }

                                outputFile.Close();

                            }
                            }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
            }

        }

        private void buttonLoadSSC_Click(object sender, EventArgs e)
        {
            // Import .ssc file

            // create openFileDialog

            string fileName;

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "text files (*.ssc)|*.ssc|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            // ask user to confirm

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
                    string instrumentConfigString = "";
                    string[] instrumentConfigArray = new string[7];

                    // check if file exists

                    if (File.Exists(fileName))
                    {

                        var inputFile = new StreamReader(fileName);

                        if (inputFile != null)

                        {

                            // read file
                            
                            int index = 0;
                            
                            while (!inputFile.EndOfStream)
                            {

                                instrumentConfigArray[index] = inputFile.ReadLine();

                                index += 1;

                            }

                            // fill boxes
                            
                            textBoxInstrumentName.Text = instrumentConfigArray[0];
                            textBoxLRV.Text = instrumentConfigArray[1];
                            textBoxURV.Text = instrumentConfigArray[2];
                            textBoxUnit.Text = instrumentConfigArray[3];
                            textBoxAlarmLow.Text = instrumentConfigArray[4];
                            textBoxAlarmHigh.Text = instrumentConfigArray[5];

                        }
                        // close file
                        
                        inputFile.Close();


                    }


                }
            }
        }
    }

}
    
