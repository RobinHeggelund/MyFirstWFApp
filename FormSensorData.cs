using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System.IO;

namespace MyFirstWFApp
{
    public partial class FormSensorData : Form
    {
        Form1 mainForm;
        

        string instrumentListFileLocation = (Environment.CurrentDirectory + "\\instruments.csv");

        public FormSensorData(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        Font fontNormal = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);

        Font fontNormalSmall = new Font("Segoe UI", 9, FontStyle.Regular);
        Font fontBoldSmall = new Font("Segoe UI", 9, FontStyle.Bold);

        // Creating color pallet

        Color DiscordBlue = Color.FromArgb(114, 137, 218);
        Color Light = Color.FromArgb(71, 74, 78);
        Color MediumLight = Color.FromArgb(66, 69, 73);
        Color Medium = Color.FromArgb(54, 57, 62);
        Color MediumDark = Color.FromArgb(40, 43, 48);
        Color Dark = Color.FromArgb(30, 33, 36);

        // Creating Singal Types


        string[] analogSignals = new string[] { "0-5VDC", "230V-AC", "2-12V_DC", };
        string[] digitalSignals = new string[] { "Digital TCP", "Omega Digital" };
        string[] fieldbusSignals = new string[] { "BussRP", "Modbus RTU", "Modbus TCP", "Profibus" };

        // Creating Variables

        double lvrValue = 0.0;
        double uvrValue = 0.0;
        int alarmFloorValue = 0;
        int alarmCeilingValue = 0;
        double spanRange = 0.0;
        string unitValue = string.Empty;

        int RegisterIndex = 0;
        int analogIndex = 0;
        int digitalIndex = 0;
        int fieldbusIndex = 0;

        // Creating Lists

        List<string> servers = new List<string>();
        List<Instrument> instrumentList = new List<Instrument>();

        


        // Setting DateTime

        DateTime sessionStartTime;


        // Custom Boarder

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            buttonRegisterNew.Enabled = true;
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

        private void FormSensorData_Load(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Ready";

            comboBoxSignalType.SelectedIndex = 0;
            listBoxOptions.SelectedIndex = 0;

 

            sessionStartTime = DateTime.Now;

            InvokeOnClick(buttonAnalog, null);

            //Import instrument list from file

            ImportInstrumentListFromFile();
        }

        private void ImportInstrumentListFromFile()
        {
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
                                                                Convert.ToDouble(instrumentLineParts[7]),
                                                                Convert.ToDouble(instrumentLineParts[8]),
                                                                int.Parse(instrumentLineParts[9]),
                                                                int.Parse(instrumentLineParts[10]),
                                                                Convert.ToString(instrumentLineParts[11]));
                        instrumentList.Add(instrument);
                        

                    }
                    inputFile.Close();
                }

                
            }
            else
            {
                
            }

            PushInstrumentSummary();
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


        private void RegisterNewInstrument()
        {
            // General sensor registration data


            if (NewInstrument(textBoxSensorName.Text))

            {

                // Create new instrument and add to list

                Instrument instrument = new Instrument(DateTime.Now,
                                                  textBoxSensorName.Text,
                                                  maskedTextBoxSerialNumber.Text,
                                                  comboBoxSignalType.Text,
                                                  comboBoxMeasureType.Text,
                                                  listBoxOptions.Text,
                                                  textBoxComments.Text,
                                                  lvrValue,
                                                  uvrValue,
                                                  alarmFloorValue,
                                                  alarmCeilingValue,
                                                  textBoxUnit.Text);


                instrumentList.Add(instrument);

                // Update register preview with standard values

                RegisterIndex += 1;
                textBoxPreview.AppendText("Sensor Index: " + RegisterIndex + "\r\n");
                textBoxPreview.AppendText("Sensor Name: " + textBoxSensorName.Text + "\r\n");
                textBoxPreview.AppendText("Serial Number: " + maskedTextBoxSerialNumber.Text + "\r\n");

                textBoxPreview.AppendText("Registration Date: " + DateTime.Now + "\r\n");
                textBoxPreview.AppendText("Signal Type: " + comboBoxSignalType.Text + "\r\n");
                textBoxPreview.AppendText("Measure Type: " + comboBoxMeasureType.Text + "\r\n");
                textBoxPreview.AppendText("Protocol: " + listBoxOptions.Text + "\r\n");
                textBoxPreview.AppendText("Comment: " + textBoxComments.Text + "\r\n");

                // Specific sensor registration with specific analog values

                if (comboBoxSignalType.Text == "Analog")
                {
                    analogIndex += 1;

                    textBoxPreview.AppendText("Lower Range: : " + textBoxLVR.Text + "\r\n");
                    textBoxPreview.AppendText("Upper Range: " + textBoxURV.Text + "\r\n");
                    textBoxPreview.AppendText("Span: " + spanRange + "\r\n");
                    textBoxPreview.AppendText("Measure Unit: " + textBoxUnit.Text + "\r\n");
                }

                if (comboBoxSignalType.Text == "Digital")
                {
                    digitalIndex += 1;
                }

                if (comboBoxSignalType.Text == "Fieldbus")
                {
                    fieldbusIndex += 1;
                }

            }

            else
            {
                // Inform user about already registered sensor and ask if they want to overwrite said sensor in list

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Sensor already registered. Do you want to overwrite?", 
                    "Sensor already registered", buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Overwrite sensor in list

                    instrumentList.RemoveAll(x => x.SensorName == textBoxSensorName.Text);

                    // Create new instrument and add to list

                    Instrument instrument = new Instrument(DateTime.Now,
                                                      textBoxSensorName.Text,
                                                      maskedTextBoxSerialNumber.Text,
                                                      comboBoxSignalType.Text,
                                                      comboBoxMeasureType.Text,
                                                      listBoxOptions.Text,
                                                      textBoxComments.Text,
                                                      lvrValue,
                                                      uvrValue,
                                                      alarmFloorValue,
                                                      alarmCeilingValue,
                                                      textBoxUnit.Text);
                    instrumentList.Add(instrument);



                }
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
            alarmFloorValue = int.Parse(textBoxAlarmFloor.Text);
            alarmCeilingValue = int.Parse(textBoxAlarmCeiling.Text);

            spanRange = uvrValue - lvrValue;

            bool sensorNameValid = false;
            bool serialNumberValid = false;
            bool signalTypeValid = false;
            bool measureTypeValid = false;
            bool optionsValid = false;
            bool lvrValueValid = false;
            bool uvrValueValid = false;
            bool spanValueValid = false;
            bool unitValueValid = false;

            // Check if every data entry is valid and returns a boolean value, enables error icons

            // Sensor Name


            if (textBoxSensorName.Text.Length > 0)

            {
                sensorNameValid = true;

            }

            else
            {

            }

            // Serial Number

            if (maskedTextBoxSerialNumber.Text != "   -  -")

            {
                serialNumberValid = true;

            }

            else
            {

            }

            // Signal Type

            if (comboBoxSignalType.Text != "")
            {
                signalTypeValid = true;

            }

            else
            {

            }

            // Measure Type

            if (comboBoxMeasureType.Text.Length > 0)
            {
                measureTypeValid = true;

            }

            else
            {

            }

            // Options

            if (listBoxOptions.SelectedIndex >= 0)
            {
                optionsValid = true;

            }
            else
            {

            }

            // Lower range value

            if (textBoxLVR.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                lvrValueValid = true;

            }

            else
            {

            }

            // Upper range value

            if (textBoxURV.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                uvrValueValid = true;

            }

            else
            {

            }


            // Unit value

            if (textBoxUnit.Text.Length > 0 || comboBoxSignalType.Text != "Analog")
            {
                unitValueValid = true;

            }

            else
            {

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

            if (sensorNameValid && serialNumberValid && signalTypeValid && measureTypeValid && unitValueValid  && lvrValueValid && uvrValueValid)
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

        private void maskedTextBoxSerialNumber_Enter(object sender, EventArgs e)
        {

            maskedTextBoxSerialNumber.Select(maskedTextBoxSerialNumber.TextLength, 8);
        }


        private void radioButtonRegisterNew_CheckedChanged(object sender, EventArgs e)
        {
            buttonRegisterNew.Enabled = true;
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
                    panelValueRangesBack.Visible = true;

                    this.panelOptionsCommentsBack.Location = new Point(13, 266);

                  


                    break;

                case "Digital":
                    comboBoxMeasureType.Items.Clear();
                    comboBoxMeasureType.Items.AddRange(digitalSignals);
                    panelValueRangesBack.Visible = false;
                    this.panelOptionsCommentsBack.Location = new Point(13, 216);

                  


                    break;

                case "Fieldbus":
                    comboBoxMeasureType.Items.Clear();
                    comboBoxMeasureType.Items.AddRange(fieldbusSignals);
                    panelValueRangesBack.Visible = false;
                    this.panelOptionsCommentsBack.Location = new Point(13, 216);

                  


                    break;

                default:


                    break;

            }
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











        private void buttonAnalog_Click_1(object sender, EventArgs e)
        {
            buttonAnalog.BackColor = Dark;
            buttonDigital.BackColor = Medium;
            buttonFieldbus.BackColor = Medium;

            comboBoxSignalType.Text = "Analog";

            panelMeasureTypeAnalogBack.Visible = true;
            panelMeasureTypeDigitalBack.Visible = false;
            panelMeasureTypeFieldbusBack.Visible = false;

            buttonMT_Digital_1.BackColor = Medium;
            buttonMT_Digital_2.BackColor = Medium;

            buttonMT_Fieldbus_1.BackColor = Medium;
            buttonMT_Fieldbus_2.BackColor = Medium;
            buttonMT_Fieldbus_3.BackColor = Medium;
            buttonMT_Fieldbus_4.BackColor = Medium;

            textBoxLVR.Enabled = true;
            textBoxURV.Enabled = true;
            textBoxUnit.Enabled = true;
            

        }

        private void buttonDigital_Click_1(object sender, EventArgs e)
        {
            buttonAnalog.BackColor = Medium;
            buttonDigital.BackColor = Dark;
            buttonFieldbus.BackColor = Medium;

            comboBoxSignalType.Text = "Digital";

            panelMeasureTypeAnalogBack.Visible = false;
            panelMeasureTypeDigitalBack.Visible = true;
            panelMeasureTypeFieldbusBack.Visible = false;

            buttonMT_Analog_1.BackColor = Medium;
            buttonMT_Analog_2.BackColor = Medium;
            buttonMT_Analog_3.BackColor = Medium;

            buttonMT_Fieldbus_1.BackColor = Medium;
            buttonMT_Fieldbus_2.BackColor = Medium;
            buttonMT_Fieldbus_3.BackColor = Medium;
            buttonMT_Fieldbus_4.BackColor = Medium;

            textBoxLVR.Enabled = false;
            textBoxURV.Enabled = false;
            textBoxUnit.Enabled = false;
            
        }

        private void buttonFieldbus_Click_1(object sender, EventArgs e)
        {
            buttonAnalog.BackColor = Medium;
            buttonDigital.BackColor = Medium;
            buttonFieldbus.BackColor = Dark;

            comboBoxSignalType.Text = "Fieldbus";

            panelMeasureTypeAnalogBack.Visible = false;
            panelMeasureTypeDigitalBack.Visible = false;
            panelMeasureTypeFieldbusBack.Visible = true;

            buttonMT_Analog_1.BackColor = Medium;
            buttonMT_Analog_2.BackColor = Medium;
            buttonMT_Analog_3.BackColor = Medium;


            buttonMT_Digital_1.BackColor = Medium;
            buttonMT_Digital_2.BackColor = Medium;

            textBoxLVR.Enabled = false;
            textBoxURV.Enabled = false;
            textBoxUnit.Enabled = false;
            

        }

        private void buttonMT_Analog_1_Click_1(object sender, EventArgs e)
        {
            buttonMT_Analog_1.BackColor = Dark;
            buttonMT_Analog_2.BackColor = Medium;
            buttonMT_Analog_3.BackColor = Medium;

            comboBoxMeasureType.Text = "0-5VDC";
        }

        private void buttonMT_Analog_2_Click_1(object sender, EventArgs e)
        {
            buttonMT_Analog_1.BackColor = Medium;
            buttonMT_Analog_2.BackColor = Dark;
            buttonMT_Analog_3.BackColor = Medium;

            comboBoxMeasureType.Text = "230V-AC";
        }

        private void buttonMT_Analog_3_Click_1(object sender, EventArgs e)
        {
            buttonMT_Analog_1.BackColor = Medium;
            buttonMT_Analog_2.BackColor = Medium;
            buttonMT_Analog_3.BackColor = Dark;

            comboBoxMeasureType.Text = "2-12V_DC";
        }

        private void buttonMT_Digital_1_Click_1(object sender, EventArgs e)
        {
            buttonMT_Digital_1.BackColor = Dark;
            buttonMT_Digital_2.BackColor = Medium;

            comboBoxMeasureType.Text = "Digital TCP";

        }

        private void buttonMT_Digital_2_Click_1(object sender, EventArgs e)
        {
            buttonMT_Digital_1.BackColor = Medium;
            buttonMT_Digital_2.BackColor = Dark;

            comboBoxMeasureType.Text = "Omega Digital";
        }

        private void buttonMT_Fieldbus_1_Click_1(object sender, EventArgs e)
        {
            buttonMT_Fieldbus_1.BackColor = Dark;
            buttonMT_Fieldbus_2.BackColor = Medium;
            buttonMT_Fieldbus_3.BackColor = Medium;
            buttonMT_Fieldbus_4.BackColor = Medium;

            comboBoxMeasureType.Text = "BussRP";
        }

        private void buttonMT_Fieldbus_2_Click_1(object sender, EventArgs e)
        {
            buttonMT_Fieldbus_1.BackColor = Medium;
            buttonMT_Fieldbus_2.BackColor = Dark;
            buttonMT_Fieldbus_3.BackColor = Medium;
            buttonMT_Fieldbus_4.BackColor = Medium;

            comboBoxMeasureType.Text = "Modbus RTU";
        }

        private void buttonMT_Fieldbus_3_Click_1(object sender, EventArgs e)
        {
            buttonMT_Fieldbus_1.BackColor = Medium;
            buttonMT_Fieldbus_2.BackColor = Medium;
            buttonMT_Fieldbus_3.BackColor = Dark;
            buttonMT_Fieldbus_4.BackColor = Medium;

            comboBoxMeasureType.Text = "ModbusTCP";
        }

        private void buttonMT_Fieldbus_4_Click_1(object sender, EventArgs e)
        {
            buttonMT_Fieldbus_1.BackColor = Medium;
            buttonMT_Fieldbus_2.BackColor = Medium;
            buttonMT_Fieldbus_3.BackColor = Medium;
            buttonMT_Fieldbus_4.BackColor = Dark;

            comboBoxMeasureType.Text = "Profibus";
        }

        private void comboBoxSignalType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxMeasureType.Text = "";
        }



        private void buttonRegisterNew_Click_1(object sender, EventArgs e)
        {
            if (DataEntryIsValid())
            {
                // Register new sensor
                RegisterNewInstrument();

                // Save data to file

                WriteDataToFile();

                PushInstrumentSummary();

            }

            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void WriteDataToFile()
        {
            try { 
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

        private void textBoxLVR_Enter(object sender, EventArgs e)
        {
            textBoxLVR.SelectAll();
        }

        private void textBoxURV_Enter(object sender, EventArgs e)
        {
            textBoxURV.SelectAll();
        }

        private void textBoxLVR_Click(object sender, EventArgs e)
        {
            textBoxLVR.SelectAll();
        }

        private void textBoxURV_Click(object sender, EventArgs e)
        {
            textBoxURV.SelectAll();

        }

        private void textBoxSensorName_TextChanged(object sender, EventArgs e)
        {
            
            // Converts the first letter to upper case
            
            if (textBoxSensorName.Text.Length == 1)
            {

                char[] textArray = textBoxSensorName.Text.ToCharArray();
                textArray[0] = char.ToUpper(textArray[0]);
                textBoxSensorName.Text = new string(textArray);

                textBoxSensorName.SelectionStart = textBoxSensorName.Text.Length;
                textBoxSensorName.SelectionLength = 0;


            }

        }

        private void pictureBoxButtonSearch_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxButtonSearch.Image = Properties.Resources.loupe;
        }

        private void pictureBoxButtonSearch_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxButtonSearch.Image = Properties.Resources.search;
        }

        private void pictureBoxButtonSearch_Click(object sender, EventArgs e)
        {

            // Show instrument search panel

            instrumentListFileLocation = mainForm.instrumentListFileLocation;
            ImportInstrumentListFromFile();
            panelSensorSearch.Visible = true;
            this.panelSensorSearch.Location = new Point(243, 158);

            // clear sensor listbox and add each instrument in list

            UpdateInstrumentListBox();

            // Create listbox scrollbar if needed

            if (listBoxSensorList.Items.Count > 6)
            {
                listBoxSensorList.ScrollAlwaysVisible = true;
            }
  
        }

        private void PushInstrumentSummary()
        {
            mainForm.AnalogSummary = analogIndex;
            mainForm.DigitalSummary = digitalIndex;
            mainForm.FieldbusSummary = fieldbusIndex;
            mainForm.TotalSummary = RegisterIndex;
        }

        private void UpdateInstrumentListBox()
        {
            listBoxSensorList.Items.Clear();
            int index = 0;
            if (instrumentList.Count > 0)
            {
                // Sort instrumentList alphabetically in a case-insensitive manner

                instrumentList.Sort((x, y) => string.Compare(x.SensorName, y.SensorName, StringComparison.OrdinalIgnoreCase));

                // Update listBoxSensorList

                foreach (Instrument instrument in instrumentList)
                {
                    listBoxSensorList.Items.Add(instrument.SensorName);
                    index += 1;
                }
            }
        }


        private void buttonSensorSearchCancle_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this instrument?";
            string caption = "Confirm delete";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons, icon);

            if (result == DialogResult.Yes)
            {
                // Delete selected instrument

                instrumentList.RemoveAll(x => x.SensorName == listBoxSensorList.Text);

                // Update list
                
                UpdateInstrumentListBox();

                // Disable Confirm Button

                buttonSensorSearchConfirm.Enabled = false;

                // Write changes to file

                WriteDataToFile();



            }
        }

        private void pictureBoxSearchBoarderClose_Click(object sender, EventArgs e)
        {
            panelSensorSearch.Visible = false;
            buttonSensorSearchConfirm.Enabled = false;
            buttonSensorDelete.Enabled = false;
        }

        private void panelBoarderSearchClose_Click(object sender, EventArgs e)
        {
            panelSensorSearch.Visible = false;
            buttonSensorSearchConfirm.Enabled = false;
            buttonSensorDelete.Enabled = false;
        }

        private void panelBoarderSearchClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = Dark;
        }

        private void pictureBoxSearchBoarderClose_MouseEnter(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = Dark;
        }

        private void panelBoarderSearchClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = MediumDark ;
        }

        private void pictureBoxSearchBoarderClose_MouseLeave(object sender, EventArgs e)
        {
            panelBoarderSearchClose.BackColor = MediumDark;
        }

        private void panelBoarderSensorSearch_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panelSensorSearch.Handle, 0x112, 0xf012, 0);
        }

        private void listBoxSensorList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxSensorList.SelectedItems.Count > 0)
            {
                buttonSensorSearchConfirm.Enabled = true;
                buttonSensorDelete.Enabled = true;
            }
        }

        private void buttonSensorSearchConfirm_Click(object sender, EventArgs e)
        {
            // Hide window

            panelSensorSearch.Visible = false;

            // Disable button

            buttonSensorSearchConfirm.Enabled = false;

            // Clear all boxes

            textBoxSensorName.Clear();
            maskedTextBoxSerialNumber.Clear();
            textBoxComments.Clear();
            textBoxLVR.Text = 0.0f.ToString();
            textBoxURV.Text = 0.0f.ToString();
            textBoxUnit.Clear();
            textBoxAlarmFloor.Clear();
            textBoxAlarmCeiling.Clear();


            // Fill boxes with selected sensor data

            int index = listBoxSensorList.SelectedIndex;
            textBoxSensorName.Text = instrumentList[index].SensorName;
            maskedTextBoxSerialNumber.Text = instrumentList[index].SerialNumber;
            textBoxComments.Text = instrumentList[index].Comment;
            textBoxLVR.Text = instrumentList[index].LRV.ToString();
            textBoxURV.Text = instrumentList[index].URV.ToString();
            textBoxUnit.Text = instrumentList[index].Unit;
            textBoxAlarmFloor.Text = instrumentList[index].AlarmFloor.ToString();
            textBoxAlarmCeiling.Text = instrumentList[index].AlarmCeiling.ToString();
            // Set Options to instrument data

            string optionSelected;

            optionSelected = instrumentList[index].Options;

            foreach (var item in listBoxOptions.Items)
            {
                if (optionSelected == item.ToString())
                {
                    listBoxOptions.SelectedIndex = listBoxOptions.Items.IndexOf(item);
                    break;
                }
            }

            // Push Signal Type Buttons

            if (instrumentList[index].SignalType == "Analog")
            {
                InvokeOnClick(buttonAnalog, null);
            }
            
            if (instrumentList[index].SignalType == "Digital")
            {
                InvokeOnClick(buttonDigital, null);
            }

            if (instrumentList[index].SignalType == "Fieldbus")
            {
                InvokeOnClick(buttonFieldbus, null);
            }

            // Push Measure Type Buttons

            if (instrumentList[index].MeasureType == analogSignals[0])
                
            {
                InvokeOnClick(buttonMT_Analog_1, null);
            }

            if (instrumentList[index].MeasureType == analogSignals[1])
            {
                InvokeOnClick(buttonMT_Analog_2, null);
            }

            if (instrumentList[index].MeasureType == analogSignals[2])
            {
                InvokeOnClick(buttonMT_Analog_3, null);
            }

            if (instrumentList[index].MeasureType == digitalSignals[0])
            {
                InvokeOnClick(buttonMT_Digital_1, null);
            }

            if (instrumentList[index].MeasureType == digitalSignals[1])
            {
                InvokeOnClick(buttonMT_Digital_2, null);
            }

            if (instrumentList[index].MeasureType == fieldbusSignals[0])
            {
                InvokeOnClick(buttonMT_Fieldbus_1, null);
            }

            if (instrumentList[index].MeasureType == fieldbusSignals[1])
            {
                InvokeOnClick(buttonMT_Fieldbus_2, null);
            }

            if (instrumentList[index].MeasureType == fieldbusSignals[2])
            {
                InvokeOnClick(buttonMT_Fieldbus_3, null);
            }

            if (instrumentList[index].MeasureType == fieldbusSignals[3])
            {
                InvokeOnClick(buttonMT_Fieldbus_4, null);
            }











        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Clear all boxes

            textBoxSensorName.Clear();
            maskedTextBoxSerialNumber.Clear();
            textBoxComments.Clear();
            textBoxLVR.Text = 0.0f.ToString();
            textBoxURV.Text = 0.0f.ToString();
            textBoxUnit.Clear();
            textBoxAlarmFloor.Clear();
            textBoxAlarmCeiling.Clear();
            listBoxOptions.SelectedIndex = 0;
            InvokeOnClick(buttonAnalog, null);
            InvokeOnClick(buttonMT_Analog_1, null);
            



        }
    }
}

       

       



      

