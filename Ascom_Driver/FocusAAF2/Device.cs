using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FocusTest
{
    class Device
    {
        private ASCOM.DriverAccess.Focuser focuser;
        private int stepsizeN1 = 0;
        private int stepsizeN2 = 0;
        RichTextBox rtbLog;

        public Device(RichTextBox rtb)
        {
            rtbLog = rtb;
        }

        ~Device()   // Destructor
        {
            if (focuser != null)
                focuser.Dispose();
        }

        public bool choose()
        {
            string id = ASCOM.DriverAccess.Focuser.Choose("");
            if (string.IsNullOrEmpty(id))
                return false;
            // create this device
            focuser = new ASCOM.DriverAccess.Focuser(id);
            return true;
        }

        public bool connect()
        {
            // Connect to Focusser
            focuser.Connected = true;
            return focuser.Connected;
        }

        public bool disconnect()
        {
            focuser.Connected = false;
            return !focuser.Connected;
        }

        public bool isConnected()
        {
            return focuser.Connected;
        }

        public string getFocuserName()
        {
            return focuser.Name;
        }

        public string getFocuserDescription()
        {
            return focuser.Description;
        }

        internal void moveTo(int p)
        {
            focuser.Move(p);
            // device is now moving - wait until not moving
            while (isMoving())
            {
                System.Threading.Thread.Sleep(333);
            }

        }

        internal void moveDown()
        {
            focuser.Move(focuser.Position - 1);
        }

        internal void moveUp()
        {
            focuser.Move(focuser.Position + 1);
        }

        public string getPosition()
        {
            return focuser.Position.ToString();
        }

        public int StepsizeN1 {
            get
            {
                return stepsizeN1;
            }

            set
            {
                stepsizeN1 = value;
            }
        }


        internal void commandSend(String s)
        {

            rtbLog.AppendText("-- CommandSend START --\n");
            rtbLog.AppendText("  Sent: " + s + "\n");
            String r = focuser.CommandString(s, true);
            rtbLog.AppendText("   Received: " + r + "\n");
            rtbLog.AppendText("--  CommandSend END  --\n");

        }

        internal bool isMoving()
        {
            return focuser.IsMoving;
        }

        public int StepsizeN2
        {
            get
            {
                return stepsizeN2;
            }

            set
            {
                stepsizeN2 = value;
            }
        }


    }
}
