using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.AAF2;

namespace ASCOM.AAF2
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm()
        {
            InitializeComponent();
            // Initialise current values of user settings from the ASCOM Profile 
            comboBoxComPort.Items.Clear();
            using (ASCOM.Utilities.Serial serial = new Utilities.Serial())
            {
                int i = 0;
                foreach (var item in serial.AvailableCOMPorts)
                {
                    comboBoxComPort.Items.Add(item);
                    if (item == Focuser.comPort)
                    {
                        comboBoxComPort.SelectedIndex = i;
                    }
                    i++;
                }
            }

            chkTrace.Checked = Focuser.traceState;
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here

            Focuser.comPort = comboBoxComPort.Text; // Update the state variables with results from the dialogue
            Focuser.traceState = chkTrace.Checked;

            // If a new initial position entered pass it to focuser
            if (!String.IsNullOrEmpty(txtInitialPosition.Text))
            {
                Focuser.newInitialPosition = Int32.Parse(txtInitialPosition.Text);
            }
            else
            {
                Focuser.newInitialPosition = 0;
            }

            using (ASCOM.Utilities.Profile p = new Utilities.Profile())
            {
                p.DeviceType = "Focuser";
                p.WriteValue(Focuser.driverID, "ComPort", (string)comboBoxComPort.Text);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtInitialPosition_TextChanged(object sender, EventArgs e)
        {

        }
    }
}