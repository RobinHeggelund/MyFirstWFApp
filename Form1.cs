using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Net.Sockets;
using System.Net;
using System.Xml.Linq;
using System.Text;

namespace MyFirstWFApp
{
    public partial class FormMain : Form
    {
        Font fontNormal = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);

        Font fontNormalSmall = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBoldSmall = new Font("Segoe UI", 9, FontStyle.Bold);

        string[] analogSignals = new string[] { "0-5VDC", "OmegaAnalog","0-8VDC EchoSensor","MicrosoftKinnect" };
        string[] digitalSignals = new string[] { "SuperDigital", "GIGA", "0-10Vs" };
        string[] fieldbusSignals = new string[] { "BussRP", "Modbus RTU", "Modbus TCP", "Profibus" };

        double lvrValue = 0.0;
        double uvrValue = 0.0;
        double spanRange = 0.0;
        string unitValue = string.Empty;

        int RegisterIndex = 0;
        int analogIndex = 0;
        int digitalIndex = 0;
        int fieldbusIndex = 0;

        List<string> servers = new List<string>();
        List<Instrument> instrumentList = new List<Instrument>();
 


        DateTime sessionStartTime;


        public FormMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            buttonRegisterNew.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

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
            toolStripStatusLabel1.Text = "Ready";
            this.Width = 587;
            comboBoxSignalType.SelectedIndex= 0;
            listBoxOptions.SelectedIndex = 0;
            
            textBoxLVR.Text = 0.ToString();
            textBoxURV.Text = 0.ToString();

            sessionStartTime = DateTime.Now;

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

        private void Form1_Click(object sender, EventArgs e)
        {

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
            toolStripStatusLabel1.Text = "Ready";
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Out of focus";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelSensorName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Define the sensors name.";
            this.Cursor = Cursors.Hand;
        }

        private void textBoxSensorName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Define the sensors name.";
        }

        private void textBoxSensorName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelSensorName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void maskedTextBoxSerialNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxSerialNumber_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Type in sensor serial number, 9 characters.";
            
        }

        private void maskedTextBoxSerialNumber_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelSerialNumber_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Type in sensor serial number, 9 characters.";
        }

        private void labelSerialNumber_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void checkBoxRegistered_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Check this box if the sensor has previously been registered";
            this.Cursor = Cursors.Hand;
        }

        private void checkBoxRegistered_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelRegistered_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Check this box if the sensor has previously been registered";
        }

        private void labelRegistered_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void dateTimePickerRegDate_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Choose the date of registration";
            this.Cursor = Cursors.Hand;
        }

        private void dateTimePickerRegDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelRegDate_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Choose the date of registration";
        }

        private void labelRegDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void comboBoxSignalType_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the sensor signal type";
            this.Cursor = Cursors.Hand;
        }

        private void comboBoxSignalType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelSignalType_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the sensor signal type";
        }

        private void labelSignalType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void listBoxOptions_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the corresponding sensor protocol";
            this.Cursor = Cursors.Hand;
        }

        private void listBoxOptions_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelOptions_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the corresponding sensor protocol";
        }

        private void labelOptions_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxComments_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Leave additional information that might be relevant for the registration process";
            this.Cursor = Cursors.Hand;
        }

        private void textBoxComments_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelComments_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Leave additional information that might be relevant for the registration process";

        }

        private void labelComments_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonRegisterNew_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Register a new sensor";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonRegisterNew_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonSave_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Save the registration to file";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonSave_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonDelete_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete a previously saved registration file";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void buttonRegisterNew_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Confirm selected action";
            this.Cursor = Cursors.Hand;
        }

        private void buttonRegisterNew_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void buttonRegisterNew_Click(object sender, EventArgs e)
        {



            if (radioButtonRegisterNew.Checked && DataEntryIsValid())
            {
                // Register new sensor

                this.Width = 1089;

                EnterDataIntoTextPreviewBox();



            }


            
            else if (radioButtonSave.Checked)
            {
                // Update an already registered sensor
            }

            else if (radioButtonDelete.Checked)

            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete all data?","Confirm Delete",MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete data

                    textBoxPreview.Clear();
                    textBoxSummary.Clear();
                    RegisterIndex = 0;
                    analogIndex = 0;
                    digitalIndex= 0;
                    fieldbusIndex= 0;

                }



            }

            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void EnterDataIntoTextPreviewBox()
        {
            // General sensor registration data


            if (NewInstrument(textBoxSensorName.Text))

            {

                // Create new instrument and add to list

                Instrument instrument = new Instrument(textBoxSensorName.Text,
                                                  maskedTextBoxSerialNumber.Text,
                                                  comboBoxSignalType.Text,
                                                  comboBoxMeasureType.Text,
                                                  listBoxOptions.Text,
                                                  textBoxComments.Text,
                                                  lvrValue,
                                                  uvrValue,
                                                  textBoxUnit.Text);


                instrumentList.Add(instrument);

                // Update register preview

                RegisterIndex += 1;
                textBoxPreview.AppendText("Sensor Index: " + RegisterIndex + "\r\n");
                textBoxPreview.AppendText("Sensor Name: " + textBoxSensorName.Text + "\r\n");
                textBoxPreview.AppendText("Serial Number: " + maskedTextBoxSerialNumber.Text + "\r\n");
                textBoxPreview.AppendText("Registered: " + checkBoxRegistered.CheckState + "\r\n");
                textBoxPreview.AppendText("Registration Date: " + dateTimePickerRegDate.Text + "\r\n");
                textBoxPreview.AppendText("Signal Type: " + comboBoxSignalType.Text + "\r\n");
                textBoxPreview.AppendText("Measure Type: " + comboBoxMeasureType.Text + "\r\n");
                textBoxPreview.AppendText("Protocol: " + listBoxOptions.Text + "\r\n");
                textBoxPreview.AppendText("Comment: " + textBoxComments.Text + "\r\n");

                // Specific sensor registration data

                if (comboBoxSignalType.Text == "Analog")
                {
                    analogIndex += 1;

                    textBoxPreview.AppendText("Lower Range: : " + textBoxLVR.Text + "\r\n");
                    textBoxPreview.AppendText("Upper Range: " + textBoxURV.Text + "\r\n");
                    textBoxPreview.AppendText("Span: " + spanRange + "\r\n");
                    textBoxPreview.AppendText("Measure Unit: " + textBoxUnit.Text + "\r\n");
                }

                else if (comboBoxSignalType.Text == "Digital")
                {
                    digitalIndex += 1;
                }

                else if (comboBoxSignalType.Text == "Fieldbus")
                {
                    fieldbusIndex += 1;
                }
                else { }

                textBoxPreview.AppendText("----------------------------" + "\r\n");

            }

            else
            {
                MessageBox.Show("Error: Sensor already registered", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private bool DataEntryIsValid()
        {

            lvrValue = Convert.ToDouble(textBoxLVR.Text, CultureInfo.InvariantCulture);
            uvrValue = Convert.ToDouble(textBoxURV.Text, CultureInfo.InvariantCulture);
            spanRange = uvrValue - lvrValue;

            bool sensorNameValid   = false;
            bool serialNumberValid = false;
            bool signalTypeValid   = false;
            bool measureTypeValid  = false;
            bool optionsValid      = false;
            bool lvrValueValid     = false;
            bool uvrValueValid     = false;
            bool spanValueValid    = false;
            bool unitValueValid = false;

            // Check if every data entry is valid and returns a boolean value, enables error icons

            // Sensor Name


            if (textBoxSensorName.Text.Length > 0)

            {
                sensorNameValid = true;
                pictureBoxErrorSensorName.Visible = false;
            }

            else
            {
                pictureBoxErrorSensorName.Visible = true;
            }

            // Serial Number

            if (maskedTextBoxSerialNumber.Text != "   -  -" )

            {
                serialNumberValid = true;
                pictureBoxErrorSerialNumber.Visible = false;
            }

            else
            {
                pictureBoxErrorSerialNumber.Visible = true;
            }

            // Signal Type

            if (comboBoxSignalType.Text != "")
            {
                signalTypeValid = true;
                pictureBoxErrorSignalType.Visible = false;
            }

            else
            {
                pictureBoxErrorSignalType.Visible = true;
            }

            // Measure Type

            if (comboBoxMeasureType.SelectedIndex >= 0)
            {
                measureTypeValid = true;
                pictureBoxErrorMeasureType.Visible = false;
            }

            else
            {
                pictureBoxErrorMeasureType.Visible = true;
            }

            // Options

            if (listBoxOptions.SelectedIndex >=0)
            {
                optionsValid = true;
                pictureBoxErrorOptions.Visible = false;
            }
            else
            {
                pictureBoxErrorOptions.Visible = true;
            }

            // Lower range value

            if (textBoxLVR.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                lvrValueValid = true;
                pictureBoxErrorLVR.Visible = false;
            }

            else
            {
                pictureBoxErrorLVR.Visible = true;
            }

            // Upper range value

            if (textBoxURV.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                uvrValueValid= true;
                pictureBoxErrorURV.Visible = false;
            }

            else
            {
                pictureBoxErrorURV.Visible = true;
            }

            
            // Unit value

            if (textBoxUnit.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                unitValueValid = true;
                pictureBoxErrorUnit.Visible = false;
            }

            else
            {
                pictureBoxErrorUnit.Visible = true;
            }

            // Span value

            if (uvrValue - lvrValue > 0 || comboBoxSignalType.Text != "Analog")
            {
                spanValueValid = true;
            }

            else
            {
                sensorNameValid = false;
                MessageBox.Show("Error: Invalid sensor range. Upper analog sensor value needs to be higher th lower analog sensor value");
                textBoxURV.Focus();
            }


            // Return boolean value

            if (sensorNameValid && serialNumberValid && signalTypeValid && measureTypeValid && optionsValid && lvrValueValid && uvrValueValid  )
            {
                return true;
            }

            else
            {
                return false;

            }

            
        }

        private void textBoxPreview_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRegisterNew.PerformClick();
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void textBoxSensorName_Enter(object sender, EventArgs e)
        {
            labelSensorName.Font = fontBold;
        }

        private void textBoxSensorName_Leave(object sender, EventArgs e)
        {
            labelSensorName.Font = fontNormal;
        }

        private void maskedTextBoxSerialNumber_Enter(object sender, EventArgs e)
        {
            labelSerialNumber.Font = fontBold;
            maskedTextBoxSerialNumber.Select(maskedTextBoxSerialNumber.TextLength, 8);
        }

        private void maskedTextBoxSerialNumber_Leave(object sender, EventArgs e)
        {
            labelSerialNumber.Font = fontNormal;
        }

        private void checkBoxRegistered_Enter(object sender, EventArgs e)
        {
            //labelRegistered.Font = fontBold;
        }

        private void checkBoxRegistered_Leave(object sender, EventArgs e)
        {
            //labelRegistered.Font = fontNormal;
        }

        private void dateTimePickerRegDate_Enter(object sender, EventArgs e)
        {
            labelRegDate.Font = fontBold;
        }

        private void dateTimePickerRegDate_Leave(object sender, EventArgs e)
        {
            labelRegDate.Font = fontNormal;
        }

        private void comboBoxSignalType_Enter(object sender, EventArgs e)
        {
            labelSignalType.Font = fontBold;
        }

        private void comboBoxSignalType_Leave(object sender, EventArgs e)
        {
            labelSignalType.Font = fontNormal;
        }

        private void listBoxOptions_Enter(object sender, EventArgs e)
        {
            labelOptions.Font = fontBold;
        }

        private void listBoxOptions_Leave(object sender, EventArgs e)
        {
            labelOptions.Font = fontNormal;
        }

        private void textBoxComments_Enter(object sender, EventArgs e)
        {
            labelComments.Font = fontBold;
        }

        private void textBoxComments_Leave(object sender, EventArgs e)
        {
            labelComments.Font = fontNormal;
        }

        private void radioButtonRegisterNew_CheckedChanged(object sender, EventArgs e)
        {
            buttonRegisterNew.Enabled = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSignalType_SelectionChangeCommitted(object sender, EventArgs e)
        {






        }

        private void groupBoxLVR_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMeasureType.Items.Clear();
            comboBoxMeasureType.Text = "";

            switch (comboBoxSignalType.Text)



            {

                case "Analog":
                    comboBoxMeasureType.Items.Clear();
                    comboBoxMeasureType.Items.AddRange(analogSignals);
                    groupBoxSignalRange.Visible = true;


                    break;

                case "Digital":
                    comboBoxMeasureType.Items.Clear();
                    comboBoxMeasureType.Items.AddRange(digitalSignals);
                    groupBoxSignalRange.Visible = false;
                    break;

                case "Fieldbus":
                    comboBoxMeasureType.Items.Clear();
                    comboBoxMeasureType.Items.AddRange(fieldbusSignals);
                    groupBoxSignalRange.Visible = false;
                    break;

                default:


                    break;

            }
        }

        private void buttonSummary_Click(object sender, EventArgs e)
        {
            System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
            double sessionTimeSeconds = Math.Ceiling(sessionTime.TotalSeconds);
            textBoxSummary.Clear();
            textBoxSummary.AppendText("Session time: "+sessionTimeSeconds.ToString() +" seconds."+ "\r\n");
            textBoxSummary.AppendText("Sensors registered: "+RegisterIndex.ToString() + "\r\n");
            textBoxSummary.AppendText("Analog sensors registered: " + analogIndex.ToString() + "\r\n");
            textBoxSummary.AppendText("Digital sensors registered: " + digitalIndex.ToString() + "\r\n");
            textBoxSummary.AppendText("Fieldbus sensors registered: " + fieldbusIndex.ToString() + "\r\n");

        }

        private void textBoxSensorName_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorSensorName.Visible)
            {
                pictureBoxErrorSensorName.Visible = false;
            }

            else if (textBoxSensorName.Text.Length == 0)
            {
                pictureBoxErrorSensorName.Visible = true;
            }
        }

        private void labelRegDate_Click(object sender, EventArgs e)
        {

        }

        private void labelPreview_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLVR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }



            // if (e.KeyChar != '0' || '1' || '2' || '3' || '4' || '5' || '6' || '7' || '8' || '9' || ',')
        }

        private void textBoxURV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxSignalType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxMeasureType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listBoxOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void maskedTextBoxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorSerialNumber.Visible)
            {
                pictureBoxErrorSerialNumber.Visible = false;
            }

            else if (maskedTextBoxSerialNumber.Text == "   -  -")
            {
                pictureBoxErrorSerialNumber.Visible = true;
            }
        }

        private void comboBoxSignalType_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorSignalType.Visible)
            {
                pictureBoxErrorSignalType.Visible = false;
            }

            else if (comboBoxSignalType.Text.Length == 0)
            {
                pictureBoxErrorSerialNumber.Visible = true;
            }

        }

        private void comboBoxMeasureType_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorMeasureType.Visible)
            {
                pictureBoxErrorMeasureType.Visible = false;
            }

            else if (comboBoxMeasureType.Text.Length == 0)
            {
                pictureBoxErrorMeasureType.Visible = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSummary.PerformClick();
        }

        private void comboBoxMeasureType_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select sensor measure type";
        }

        private void comboBoxMeasureType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxLVR_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Specify analog sensor lower range";
        }

        private void textBoxLVR_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxURV_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Specify analog sensor upper range";
        }

        private void textBoxURV_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxUnit_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Specify analog sensor unit type";
        }

        private void textBoxUnit_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxUnit_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorUnit.Visible)
            {
                pictureBoxErrorUnit.Visible = false;
            }

            else if (textBoxUnit.Text.Length == 0)
            {
                pictureBoxErrorUnit.Visible = true;
            }
        }

        private void textBoxLVR_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorLVR.Visible)
            {
                pictureBoxErrorLVR.Visible = false;
            }

            else if (textBoxLVR.Text == "")
            {
                textBoxLVR.Text = 0.ToString();
                textBoxLVR.SelectAll();
            }
        }

        private void textBoxURV_TextChanged(object sender, EventArgs e)
        {
            if (pictureBoxErrorURV.Visible)
            {
                pictureBoxErrorURV.Visible = false;
               
            }

            else if (textBoxURV.Text == "")
            {
                textBoxURV.Text = 0.ToString();
                textBoxURV.SelectAll();
            }

        }

        private void radioButtonSave_CheckedChanged(object sender, EventArgs e)
        {
            buttonRegisterNew.Enabled = true;
        }

        private void labelRegistered_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMeasureType_Enter(object sender, EventArgs e)
        {
            labelMeasureType.Font = fontBold;
        }

        private void comboBoxMeasureType_Leave(object sender, EventArgs e)
        {
            labelMeasureType.Font = fontNormal;
        }

        private void textBoxLVR_Enter(object sender, EventArgs e)
        {
            labelLowerValue.Font = fontBoldSmall;
        }

        private void textBoxLVR_Leave(object sender, EventArgs e)
        {
            labelLowerValue.Font = fontNormalSmall;
        }

        private void textBoxURV_Enter(object sender, EventArgs e)
        {
            labelUpperValue.Font = fontBoldSmall;
        }

        private void textBoxURV_Leave(object sender, EventArgs e)
        {
            labelUpperValue.Font = fontNormalSmall; 
        }

        private void textBoxUnit_Enter(object sender, EventArgs e)
        {
            labelUnit.Font = fontBoldSmall;
        }

        private void textBoxUnit_Leave(object sender, EventArgs e)
        {
            labelUnit.Font = fontNormalSmall; 
        }

        private void tabControlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlList.SelectedIndex == 2) 
            {
                listBoxIpAdress.Items.Clear();
                listBoxIpAdress.Items.AddRange(servers.ToArray());
            }

        }
    }
    
}