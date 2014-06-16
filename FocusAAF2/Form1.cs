using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FocusTest
{
    public partial class frmMain : Form
    {
        private Device device;

        public frmMain()
        {
            InitializeComponent();
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            btnDownN1.Enabled = false;
            btnUpN1.Enabled = false;
            btnDownN2.Enabled = false;
            btnUpN2.Enabled = false;
            btnConnect.Enabled = false;
            txtStepsizeN1.Enabled = false;
            txtStepsizeN2.Enabled = false;
            txtGoto.Enabled = false;
            btnGoto.Enabled = false;
            txtPosition.Enabled = false;

            // setup focuser device
            device = new Device(rtbLog);
            device.StepsizeN1 = FocusAAF2.Properties.Settings.Default.stepsizeN1Default;
            device.StepsizeN2 = FocusAAF2.Properties.Settings.Default.stepsizeN2Default;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (device.choose())
            {
                txtFocuser.Text = device.getFocuserDescription();
                btnConnect.Enabled = true;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                if (device.connect())
                {
                    btnConnect.Text = "Disconnect";
                    txtPosition.Text = device.getPosition();
                    btnDown.Enabled = true;
                    btnUp.Enabled = true;
                    btnDownN1.Enabled = true;
                    btnUpN1.Enabled = true;
                    btnDownN2.Enabled = true;
                    btnUpN2.Enabled = true;
                    txtStepsizeN1.Enabled = true;
                    txtStepsizeN2.Enabled = true;
                    txtGoto.Enabled = true;
                    btnGoto.Enabled = true;
                    txtPosition.Enabled = true;
                    txtStepsizeN1.Text = Convert.ToString(device.StepsizeN1);
                    txtStepsizeN2.Text = Convert.ToString(device.StepsizeN2);

                    rtbLog.AppendText(Utility.currentTime() + " - Connected to Device\n");
                }
            }
            else
            {
                device.disconnect();

                btnConnect.Text = "Connect";
                btnDown.Enabled = false;
                btnUp.Enabled = false;
                btnDownN1.Enabled = false;
                btnUpN1.Enabled = false;
                btnDownN2.Enabled = false;
                btnUpN2.Enabled = false;
                txtStepsizeN1.Enabled = false;
                txtStepsizeN2.Enabled = false;
                txtGoto.Enabled = false;
                btnGoto.Enabled = false;
                txtPosition.Enabled = false;

                rtbLog.AppendText(Utility.currentTime() + " - Disconnected from Device\n");
            }
            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                device.moveDown();
                string pos = device.getPosition();
                txtPosition.Text = pos;
                rtbLog.AppendText(Utility.currentTime() + " - Down 1 to " + pos + "\n");
            }
        }

        private void btnDownN1_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                string currentPos = device.getPosition();
                device.moveTo(Int32.Parse(currentPos) - device.StepsizeN1);
                string newPos = device.getPosition();
                txtPosition.Text = newPos;
                rtbLog.AppendText(Utility.currentTime() + " - Down " + Convert.ToString(device.StepsizeN1) + " to " + newPos + "\n");
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                device.moveUp();
                string pos = device.getPosition();
                txtPosition.Text = device.getPosition();
                rtbLog.AppendText(Utility.currentTime() + " - Up 1 to " + pos + "\n");
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpN1_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                string currentPos = device.getPosition();
                device.moveTo(Int32.Parse(currentPos) + device.StepsizeN1);
                string newPos = device.getPosition();
                txtPosition.Text = newPos;
                rtbLog.AppendText(Utility.currentTime() + " - Up " + Convert.ToString(device.StepsizeN1) + " to " + newPos + "\n");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to Exit?",
                        "Confirm Exit",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void txtStepsizeN1_TextChanged(object sender, EventArgs e)
        {
            device.StepsizeN1 = Convert.ToInt32(txtStepsizeN1.Text);
        }

        private void txtStepsizeN2_TextChanged(object sender, EventArgs e)
        {
            device.StepsizeN2 = Convert.ToInt32(txtStepsizeN2.Text);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            device.moveTo(Convert.ToInt32(txtGoto.Text));
            string newPos = device.getPosition();
            txtPosition.Text = newPos;
            rtbLog.AppendText(Utility.currentTime() + " - Goto " + txtGoto.Text + ". Now at " + newPos + "\n");
        }

        private void btnDownN2_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                string currentPos = device.getPosition();
                device.moveTo(Int32.Parse(currentPos) - device.StepsizeN2);
                string newPos = device.getPosition();
                txtPosition.Text = newPos;
                rtbLog.AppendText(Utility.currentTime() + " - Down " + Convert.ToString(device.StepsizeN2) + " to " + newPos + "\n");
            }
        }

        private void btnUpN2_Click(object sender, EventArgs e)
        {
            if (!device.isConnected())
            {
                return;
            }
            else
            {
                string currentPos = device.getPosition();
                device.moveTo(Int32.Parse(currentPos) + device.StepsizeN2);
                string newPos = device.getPosition();
                txtPosition.Text = newPos;
                rtbLog.AppendText(Utility.currentTime() + " - Up " + Convert.ToString(device.StepsizeN2) + " to " + newPos + "\n");
            }
        }


    }
}
