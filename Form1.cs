using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Net.Sockets;
using System.Net;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyFirstWFApp
{
    public partial class Form1 : Form
        
    {
        public string instrumentListFileLocation = (Environment.CurrentDirectory + "\\instruments.csv");

        // Creating Fonts


        Font fontNormal = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);

        Font fontNormalSmall = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBoldSmall = new Font("Segoe UI", 9, FontStyle.Bold);

        // Creating color pallet
        
        Color DiscordBlue = Color.FromArgb(114,137,218);
        Color Light = Color.FromArgb(71, 74, 78);
        Color MediumLight = Color.FromArgb(66,69,73);
        Color Medium = Color.FromArgb(54, 57, 62);
        Color MediumDark = Color.FromArgb(40, 43, 48);
        Color Dark = Color.FromArgb(30, 33, 36);

        // PanelButton Pushed Variables

        bool sensorDataPushed;
        bool ConnectionPushed;
        bool NetworkPushed;
        bool SettingsPushed;

        // Create sub panels

        private FormSensorData FrmSensorData;
        private FormConnection FrmConnection;
        private FormNetwork FrmNetwork;
        private FormSettings FrmSettings;

        // Creating Lists

        List<string> servers = new List<string>();
        List<Instrument> instrumentList = new List<Instrument>();

        // Setting DateTime

        DateTime sessionStartTime;


        public Form1()
        {
            InitializeComponent();
        }

        // Session Summary Bridge

        public int AnalogSummary;
        public int DigitalSummary;
        public int FieldbusSummary;
        public int TotalSummary;

        // Instrument Data Bridge

        public string instrumentName = "";
        public string lrv = "";
        public string urv = "";
        public string alarmFloor = "";
        public string alarmCeiling = "";

        // Custom Boarder

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                this.Height += 15;
                this.Width += 20;
            }

            if (e.KeyChar == '-')
            {
                this.Height -= 15;
                this.Width -= 20;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "No Connection";




            // create panel
            
            this.panelMain.Controls.Clear();
            
            FrmSensorData = new FormSensorData(this);
            FrmSensorData.TopLevel = false;
            FrmSensorData.Dock = DockStyle.Fill;
            FrmSensorData.TopMost = true;
            this.panelMain.Controls.Add(FrmSensorData);

            FrmConnection = new FormConnection(this);
            FrmConnection.TopLevel = false;
            FrmConnection.Dock = DockStyle.Fill;
            FrmConnection.TopMost = true;
            this.panelMain.Controls.Add(FrmConnection);
            
            FrmNetwork = new FormNetwork();
            FrmNetwork.TopLevel = false;
            FrmNetwork.Dock = DockStyle.Fill;
            FrmNetwork.TopMost = true;
            this.panelMain.Controls.Add(FrmNetwork);

            FrmSettings = new FormSettings(this);
            FrmSettings.TopLevel = false;
            FrmSettings.Dock = DockStyle.Fill;
            FrmSettings.TopMost = true;
            this.panelMain.Controls.Add(FrmSettings);

            // set defaut tab

            InvokeOnClick(panelConnection, null);




            // get IP adresses

            IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresslist)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    servers.Add(address.ToString());
                }
            }
        }

       

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "No Connection";
        }

       

        

        public bool NewInstrument(string sensorName)
        {
            bool newInstrument = true;

            instrumentList.ForEach(delegate (Instrument instrument)
            {
                if (instrument.SensorName == sensorName)
                {
                    newInstrument = false;
                }

           
            });

            return newInstrument;
        }

        
        

       

            
        

        

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //compare two text inputs

            // compare upper and lower case

            bool textEqual = false;

            if (checkBoxCaseSensitive.Checked)
            {
                if (textBoxIP.Text.Equals(textBoxInputPort.Text))
                {
                    textBoxCommunication.Text = "Strings are equal \r\n";
                }

                else
                {
                    textBoxCommunication.Text = "Strings are not equal \r\n";
                }
            }

            else
            {
                if (textBoxIP.Text.Equals(textBoxInputPort.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    textBoxCommunication.Text = "Strings are equal \r\n";
                }

                else
                {
                    textBoxCommunication.Text = "Strings are not equal \r\n";
                }
            }

            //TCP Server start
            // make an endpoint for communication:
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),Convert.ToInt32(textBoxInputPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(endpoint);
            textBoxCommunication.AppendText("Connected to server.");

            //client send
            client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text));


            //client recieve
            byte[] buffer = new byte[1024];
            int bytesRecieved = client.Receive(buffer);
            textBoxCommunication.AppendText("Recieved: " + Encoding.ASCII.GetString(buffer, 0, bytesRecieved));

            

            //output info
            Console.WriteLine("Server started. Waiting for connection..");
            //if (logging) { Console.WriteLine()}

            // compare alphabetically

            int stringCompareResult;

            stringCompareResult = string.Compare(textBoxIP.Text, textBoxInputPort.Text, false);

            if (stringCompareResult > 0)

            {
                textBoxCommunication.AppendText(string.Format("{0} is after {1}", textBoxIP.Text, textBoxInputPort.Text) + "\r\n");
            }

            else if (stringCompareResult == 0)
            {
                textBoxCommunication.AppendText(string.Format("{0} is equal to {1}", textBoxIP.Text, textBoxInputPort.Text) + "\r\n");
            }

            else
            {
                textBoxCommunication.AppendText(string.Format("{0} is before {1}", textBoxIP.Text, textBoxInputPort.Text) + "\r\n");
            }

            // search string for substring

            string recievedString = "Unit345;90.0;12.5;10;Havoc";

            if (textBoxIP.Text.IndexOf(";")>0)
            {
                string[] textSeperateParts = textBoxIP.Text.Split(";");

                foreach (string part in textSeperateParts)
                {
                    textBoxCommunication.AppendText(part+"\r\n");
                }
            }

            // list









        }   



        

        private void buttonSummary_Click(object sender, EventArgs e)
        {
            System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
            double sessionTimeSeconds = Math.Ceiling(sessionTime.TotalSeconds);
            textBoxSummary.Clear();


        }

        

       

        private void tabControlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlList.SelectedIndex == 2) 
            {
                listBoxIpAdress.Items.Clear();
                listBoxIpAdress.Items.AddRange(servers.ToArray());
            }

        }
        
        //ColorChange Tab Buttons
        
            // Network
            
        private void panelNetwork_MouseEnter(object sender, EventArgs e)
        {
            panelNetwork.BackColor = Dark;
        }

        private void panelNetwork_MouseLeave(object sender, EventArgs e)
        {
            if (NetworkPushed == false)
            {
                panelNetwork.BackColor = MediumDark;
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panelNetwork.BackColor = Dark;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panelNetwork.BackColor = Dark;
        }
        
            // Sensor Data

        private void panelSensorData_MouseEnter(object sender, EventArgs e)
        {
            panelSensorData.BackColor = Dark;
        }

        private void panelSensorData_MouseLeave(object sender, EventArgs e)
        {
            if (sensorDataPushed == false)
            {
                panelSensorData.BackColor = MediumDark;
            }
            
        }

        private void labelSensorDataTab_MouseEnter(object sender, EventArgs e)
        {
            panelSensorData.BackColor = Dark;
        }

        private void pictureBoxSensorDataTab_MouseEnter(object sender, EventArgs e)
        {
            panelSensorData.BackColor = Dark;

        }
        
            // Connection

        private void panelConnection_MouseEnter(object sender, EventArgs e)
        {
            panelConnection.BackColor = Dark;

        }

        private void panelConnection_MouseLeave(object sender, EventArgs e)
        {
            if (ConnectionPushed == false)
            {
                panelConnection.BackColor = MediumDark;
            }

        }

        private void labelConnectionTab_MouseEnter(object sender, EventArgs e)
        {
            panelConnection.BackColor = Dark;

        }

        private void pictureBoxConnectionTab_MouseEnter(object sender, EventArgs e)
        {
            panelConnection.BackColor = Dark;

        }

        private void panelSettings_MouseEnter(object sender, EventArgs e)
        {
            panelSettings.BackColor = Dark;

        }

        private void panelSettings_MouseLeave(object sender, EventArgs e)
        {
            if (SettingsPushed == false)
            {
                panelSettings.BackColor = MediumDark;
            }

        }

        private void labelSettingsTab_MouseEnter(object sender, EventArgs e)
        {
            panelSettings.BackColor = Dark;

        }

        private void pictureBoxSettingsTab_MouseEnter(object sender, EventArgs e)
        {
            panelSettings.BackColor = Dark;

        }



        private void labelMeasureType_Click(object sender, EventArgs e)
        {

        }

        private void panel27_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void panelBoarderClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderClose.BackColor = Dark;
        }

        private void panelBoarderClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderClose.BackColor = MediumDark;

        }

        private void pictureBoxBoarderClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderClose.BackColor = Dark;

        }

        private void pictureBoxBoarderClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderClose.BackColor = Dark;

        }

        private void panelBoarderFullScreen_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderFullScreen.BackColor = Dark;

        }

        private void panelBoarderFullScreen_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderFullScreen.BackColor = MediumDark;

        }

        private void pictureBoxBoarderFullscreen_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderFullScreen.BackColor = Dark;

        }

        private void panelBoarderMinimize_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderMinimize.BackColor = Dark;

        }

        private void panelBoarderMinimize_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderMinimize.BackColor = MediumDark;

        }

        private void pictureBoxBoarderMinimize_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderMinimize.BackColor = Dark;

        }

        private void pictureBoxBoarderClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelBoarderClose_Click(object sender, EventArgs e)
        {
            Close();
            
        }



        private void pictureBoxBoarderFullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) 
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void panelBoarderFullScreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBoxBoarderMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void panelBoarderMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        

        private void panelSensorData_Click(object sender, EventArgs e)
        {


            // Switching Forms

            if (sensorDataPushed == false)

            {
                // Show Panel
                
                FrmSensorData.BringToFront();
                FrmSensorData.Show();


                // Set Pushed Bool

                sensorDataPushed = true;
                ConnectionPushed = false;
                NetworkPushed = false;
                SettingsPushed = false;

                // Darken buttons background color

                panelSensorData.BackColor = Dark;
                panelConnection.BackColor = MediumDark;
                panelNetwork.BackColor = MediumDark;
                panelSettings.BackColor = MediumDark;

            }

            
        }

        private void panelConnection_Click(object sender, EventArgs e)
        {
            // Switching Forms

            if (ConnectionPushed == false)

            {
                // Show Panel

                FrmConnection.BringToFront();
                FrmConnection.Show();

                // Set Pushed Bool

                sensorDataPushed = false;
                ConnectionPushed = true;
                NetworkPushed = false;
                SettingsPushed = false;

                // Darken buttons background color

                panelSensorData.BackColor = MediumDark;
                panelConnection.BackColor = Dark;
                panelNetwork.BackColor = MediumDark;
                panelSettings.BackColor = MediumDark;
            }

     

            
        }

        private void panelNetwork_Click(object sender, EventArgs e)
        {
            // Switching Forms

            if (NetworkPushed == false)
            {

                FrmNetwork.BringToFront();
                FrmNetwork.Show();

                // Set Pushed Bool

                sensorDataPushed = false;
                ConnectionPushed = false;
                NetworkPushed = true;
                SettingsPushed = false;

                // Darken buttons background color

                panelSensorData.BackColor = MediumDark;
                panelConnection.BackColor = MediumDark;
                panelNetwork.BackColor = Dark;
                panelSettings.BackColor = MediumDark;

            }

        }

        private void panelSettings_Click(object sender, EventArgs e)
        {
            // Switching Forms

            if (SettingsPushed == false)
            {
                
                FrmSettings.BringToFront();
                FrmSettings.Show();

                // Set Pushed Bool

                sensorDataPushed = false;
                ConnectionPushed = false;
                NetworkPushed = false;
                SettingsPushed = true;

                // Darken buttons background color

                panelSensorData.BackColor = MediumDark;
                panelConnection.BackColor = MediumDark;
                panelNetwork.BackColor = MediumDark;
                panelSettings.BackColor = Dark;

                // Get summary from SensorData form

                

            }

        }

        private void pictureBoxUserImage_Click(object sender, EventArgs e)
        {
            panelUserProfile.Visible = true;
           this.panelUserProfile.Location = new Point(280,85);
        }

        // Simulate tab-panel buttonclick


        private void labelSensorDataTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelSensorData, null);
        }

        private void pictureBoxSensorDataTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelSensorData, null);
        }

        private void labelConnectionTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelConnection, null);
        }

        private void pictureBoxConnectionTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelConnection, null);
        }

        private void labelNetworkTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelNetwork, null);
        }



        private void pictureBoxNetworkTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelNetwork, null);
        }

        private void labelSettingsTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelSettings, null);
        }

        private void pictureBoxSettingsTab_Click(object sender, EventArgs e)
        {
            InvokeOnClick(panelSettings, null);
        }

        private void pictureBoxUserImage_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxUserImage.Width = 96;
            pictureBoxUserImage.Height = 96;

            this.pictureBoxUserImage.Location = new Point(46, 23);
        }

        private void pictureBoxUserImage_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxUserImage.Width = 90;
            pictureBoxUserImage.Height = 90;

            this.pictureBoxUserImage.Location = new Point(49, 26);

        }

        private void pictureBoxAvatar1_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar1.Location.X;
            int y = pictureBoxAvatar1.Location.Y;

            pictureBoxAvatar1.Width = 130;
            pictureBoxAvatar1.Height = 130;

            this.pictureBoxAvatar1.Location = new Point(x - 5, y - 5);
        }

        private void pictureBoxAvatar1_MouseLeave(object sender, EventArgs e)

        {

            int x = pictureBoxAvatar1.Location.X;
            int y = pictureBoxAvatar1.Location.Y;

            pictureBoxAvatar1.Width = 120;
            pictureBoxAvatar1.Height = 120;

            this.pictureBoxAvatar1.Location = new Point(x + 5, y + 5);
        }

        private void pictureBoxAvatar2_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar2.Location.X;
            int y = pictureBoxAvatar2.Location.Y;

            pictureBoxAvatar2.Width = 130;
            pictureBoxAvatar2.Height = 130;

            this.pictureBoxAvatar2.Location = new Point(x - 5, y - 5);
        }

        private void pictureBoxAvatar2_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar2.Location.X;
            int y = pictureBoxAvatar2.Location.Y;

            pictureBoxAvatar2.Width = 120;
            pictureBoxAvatar2.Height = 120;

            this.pictureBoxAvatar2.Location = new Point(x + 5, y + 5);
        }

        private void pictureBoxAvatar3_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar3.Location.X;
            int y = pictureBoxAvatar3.Location.Y;

            pictureBoxAvatar3.Width = 130;
            pictureBoxAvatar3.Height = 130;

            this.pictureBoxAvatar3.Location = new Point(x - 5, y - 5);
        }

        private void pictureBoxAvatar3_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar3.Location.X;
            int y = pictureBoxAvatar3.Location.Y;

            pictureBoxAvatar3.Width = 120;
            pictureBoxAvatar3.Height = 120;

            this.pictureBoxAvatar3.Location = new Point(x + 5, y + 5);
        }

        private void pictureBoxAvatar4_MouseEnter(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar4.Location.X;
            int y = pictureBoxAvatar4.Location.Y;

            pictureBoxAvatar4.Width = 130;
            pictureBoxAvatar4.Height = 130;

            this.pictureBoxAvatar4.Location = new Point(x - 5, y - 5);
        }

        private void pictureBoxAvatar4_MouseLeave(object sender, EventArgs e)
        {
            int x = pictureBoxAvatar4.Location.X;
            int y = pictureBoxAvatar4.Location.Y;

            pictureBoxAvatar4.Width = 120;
            pictureBoxAvatar4.Height = 120;

            this.pictureBoxAvatar4.Location = new Point(x + 5, y + 5);
        }

        private void pictureBoxAvatar1_Click(object sender, EventArgs e)
        {
            pictureBoxUserImageBig.Image = pictureBoxAvatar1.Image;
        }

        private void pictureBoxAvatar2_Click(object sender, EventArgs e)
        {
            pictureBoxUserImageBig.Image = pictureBoxAvatar2.Image;
        }

        private void pictureBoxAvatar3_Click(object sender, EventArgs e)
        {
            pictureBoxUserImageBig.Image = pictureBoxAvatar3.Image;
        }

        private void pictureBoxAvatar4_Click(object sender, EventArgs e)
        {
            pictureBoxUserImageBig.Image = pictureBoxAvatar4.Image;
        }



        private void buttonIPSearchConfirm_Click(object sender, EventArgs e)
        {
            textBoxUserName.Text = char.ToUpper(textBoxUpdateUserName.Text[0])  
            + textBoxUpdateUserName.Text.Substring(1) + labelUserNumber.Text;


            pictureBoxUserImage.Image = pictureBoxUserImageBig.Image;
            panelUserProfile.Visible = false;

        }
        
        private void buttonIPSearchCancle_Click(object sender, EventArgs e)
        {
            string input = textBoxUserName.Text;
            string[] parts = input.Split('#');
            string firstPart = parts[0];
            string secondPart = parts[1];

            textBoxUpdateUserName.Text = firstPart;
            pictureBoxUserImageBig.Image = pictureBoxUserImage.Image;
            panelUserProfile.Visible = false;

            


        }

        private void panelBoarderUserProfileClose_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonCancleUserProfile, null);
        }

        private void pictureBoxSearchBoarderClose_Click(object sender, EventArgs e)
        {
            InvokeOnClick(buttonCancleUserProfile, null);

        }

        private void panelBoarderSearch_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panelUserProfile.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBoxSearchBoarderClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderUserProfileClose.BackColor = Dark;
        }

        private void pictureBoxSearchBoarderClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderUserProfileClose.BackColor = MediumDark;
        }

        private void panelBoarderUserProfileClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderUserProfileClose.BackColor = Dark;
        }

        private void panelBoarderUserProfileClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderUserProfileClose.BackColor = MediumDark;
        }

        private void textBoxUpdateUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxUpdateUserName.Text.Length > 8 && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                InvokeOnClick(buttonConfirmUserProfile, null);
            }
        }

        private void panelBoarder_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                InvokeOnClick(panelBoarderFullScreen, null); 
            }

            else
            {
                InvokeOnClick(panelBoarderFullScreen, null);
            }
        }
    }






}