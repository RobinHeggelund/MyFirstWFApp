using System.Diagnostics;
using System.Globalization;

namespace MyFirstWFApp
{
    public partial class FormMain : Form
    {
        Font fontNormal = new Font("Segoe UI", 10, FontStyle.Regular);
        Font fontBold = new Font("Segoe UI", 10, FontStyle.Bold);

        string[] analogSignals = new string[] { "0-5VDC", "OmegaAnalog" };
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
            textBoxLVR.Text = lvrValue.ToString();
            textBoxURV.Text = uvrValue.ToString();
            textBoxUnit.Text = unitValue.ToString();
            comboBoxSignalType.SelectedIndex= 0;

            sessionStartTime = DateTime.Now;
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

        private void labelSensorName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Define the sensors name.";
            this.Cursor = Cursors.Hand;
        }

        private void textBoxSensorName_MouseHover(object sender, EventArgs e)
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

        private void maskedTextBoxSerialNumber_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Type in sensor serial number, 9 characters.";
            this.Cursor = Cursors.Hand;
        }

        private void maskedTextBoxSerialNumber_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelSerialNumber_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Type in sensor serial number, 9 characters.";
        }

        private void labelSerialNumber_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void checkBoxRegistered_MouseHover(object sender, EventArgs e)
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

        private void dateTimePickerRegDate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Choose the date of registration";
            this.Cursor = Cursors.Hand;
        }

        private void dateTimePickerRegDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelRegDate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Choose the date of registration";
        }

        private void labelRegDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void comboBoxSignalType_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the sensor signal type";
            this.Cursor = Cursors.Hand;
        }

        private void comboBoxSignalType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelSignalType_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the sensor signal type";
        }

        private void labelSignalType_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void listBoxOptions_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the corresponding sensor protocol";
            this.Cursor = Cursors.Hand;
        }

        private void listBoxOptions_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelOptions_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select the corresponding sensor protocol";
        }

        private void labelOptions_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void textBoxComments_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Leave additional information that might be relevant for the registration process";
            this.Cursor = Cursors.Hand;
        }

        private void textBoxComments_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void labelComments_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Leave additional information that might be relevant for the registration process";

        }

        private void labelComments_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonRegisterNew_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Register a new sensor";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonRegisterNew_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonSave_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Save the registration to file";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonSave_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void radioButtonDelete_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete a previously saved registration file";
            this.Cursor = Cursors.Hand;
        }

        private void radioButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void buttonRegisterNew_MouseHover(object sender, EventArgs e)
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
            this.textBoxPreview.Visible = true;
            this.labelPreview.Visible = true;
            

            if (radioButtonRegisterNew.Checked)
            {
                EnterDataIntoTextPreviewBox();
            }
            else if (radioButtonSave.Checked)
            {


                EnterDataIntoTextPreviewBox();
            }

            else if (radioButtonDelete.Checked)
            {
                textBoxPreview.Clear();
                textBoxPreview.AppendText("Sensor Name: " + "\r\n");
                textBoxPreview.AppendText("Serial Number: " + "\r\n");
                textBoxPreview.AppendText("Registered: " + "\r\n");
                textBoxPreview.AppendText("Registration Date: " + "\r\n");
                textBoxPreview.AppendText("Signal Type: " + "\r\n");
                textBoxPreview.AppendText("Protocol: " + "\r\n");
                textBoxPreview.AppendText("Comment: " + "\r\n");
            }

        }

        private void EnterDataIntoTextPreviewBox()
        {
            RegisterIndex += 1;
            textBoxPreview.AppendText("Index " + RegisterIndex + "\r\n");
            textBoxPreview.AppendText("Sensor Name: " + textBoxSensorName.Text + "\r\n");
            textBoxPreview.AppendText("Serial Number: " + maskedTextBoxSerialNumber.Text + "\r\n");
            textBoxPreview.AppendText("Registered: " + checkBoxRegistered.CheckState + "\r\n");
            textBoxPreview.AppendText("Registration Date: " + dateTimePickerRegDate.Text + "\r\n");
            textBoxPreview.AppendText("Signal Type: " + comboBoxSignalType.Text + "\r\n");
            textBoxPreview.AppendText("Measure Type: "+ comboBoxMeasureType.Text + "\r\n");
            textBoxPreview.AppendText("Protocol: " + listBoxOptions.Text + "\r\n");
            textBoxPreview.AppendText("Comment: " + textBoxComments.Text + "\r\n");

            if (comboBoxSignalType.Text == "Analog") ;
            {
                lvrValue = Convert.ToDouble(textBoxLVR.Text, CultureInfo.InvariantCulture);
                uvrValue = Convert.ToDouble(textBoxURV.Text, CultureInfo.InvariantCulture);
                spanRange = uvrValue - lvrValue;

                if (spanRange > 0 )
                {
                    textBoxPreview.AppendText("Lower Range: : " + textBoxLVR.Text + "\r\n");
                    textBoxPreview.AppendText("Upper Range: " + textBoxURV.Text + "\r\n");
                    textBoxPreview.AppendText("Span: " + spanRange + "\r\n");
                    textBoxPreview.AppendText("Measure Unit: " + textBoxUnit.Text + "\r\n");
                }
                else
                {
                    MessageBox.Show("Sensor spanrange is not correct!");
                }

            }
        }

        private void textBoxPreview_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        }

        private void maskedTextBoxSerialNumber_Leave(object sender, EventArgs e)
        {
            labelSerialNumber.Font = fontNormal;
        }

        private void checkBoxRegistered_Enter(object sender, EventArgs e)
        {
            labelRegistered.Font = fontBold;
        }

        private void checkBoxRegistered_Leave(object sender, EventArgs e)
        {
            labelRegistered.Font = fontNormal;
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

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {


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
            textBoxSummary.AppendText("Session time: "+sessionTime.TotalSeconds.ToString());
            textBoxSummary.AppendText("Number of sensors registered: "+RegisterIndex.ToString());
        }
    }
}