using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCOM.Utilities;

namespace ASCOM.AAF2
{
    public class AAF2
    {

        private static Serial serialPort;                                   // Serial Port
        private static double stepsize = 1;                                 // No of steps to move focusser motor for each value in Move() call
        private static string driverInfo = "Ascom-Arduino Focuser V2.";     // Driver Info String
        private static string name = "AAF2";                                // Driver Short Name
        private TraceLogger tl;

        public AAF2(bool traceState)
        {
            tl = new TraceLogger("c:\\trace\\AAF2\\AAF2" + DateTime.Now.ToString("yyyyMMddHHmmss"), "AAF2_aaf2");      // Trace Logger
            tl.Enabled = traceState;
            tl.LogMessage("AAF2", "Constructed");
        }

        ~AAF2() // Destructor
        {
            tl.Enabled = false;
            tl.Dispose();
            tl = null;
        }

        public string CommandString(string command, bool raw)
        {
            tl.LogMessage("AAF2.CommandString", "------------------ Start -----------------------");
            tl.LogMessage("AAF2.CommandString", "Command = " + command);
            string s = null;
            tl.LogMessage("AAF2.CommandString", "Clearing Buffers");
            serialPort.ClearBuffers();
            tl.LogMessage("AAF2.CommandString", "Transmitting:" + command);
            serialPort.Transmit(command);
            System.Threading.Thread.Sleep(250);
            tl.LogMessage("AAF2.CommandString", "Getting Return Message");
            s = serialPort.ReceiveTerminated("#");
            tl.LogMessage("AAF2.CommandString", "Return Message = " + s);

            tl.LogMessage("AAF2.CommandString", "------------------ Finish ----------------------");
            return s;
        }

        public void connect(string driverID)
        {
            // DMW connect to the device
            // get the port name from the profile
            string portName;
            using (ASCOM.Utilities.Profile p = new Profile())
            {
                p.DeviceType = "Focuser";
                portName = p.GetValue(driverID, "ComPort");
            }
            if (string.IsNullOrEmpty(portName))
            {
                throw new ASCOM.NotConnectedException("No COM Port Selected");
            }

            // try to connect to port
            try
            {
                serialPort = new Serial();
                serialPort.PortName = portName;
                serialPort.Speed = SerialSpeed.ps9600;
                serialPort.StopBits = SerialStopBits.One;
                serialPort.ReceiveTimeout = 15;
                serialPort.Connected = true;
            }
            catch (Exception ex)
            {
                throw new ASCOM.NotConnectedException("Serial Port Connection error", ex);
            }

            System.Threading.Thread.Sleep(2000);    // Wait 2s for connection to settle
        }

        public void disconnect()
        {
            // DMW disconnect from the device
            serialPort.Connected = false;
            serialPort.Dispose();
        }

        public bool isConnected()
        {
            if (serialPort != null && serialPort.Connected)
                return true;
            else
                return false;

        }

        public string DriverInfo {
            get
            {
                return driverInfo;
            }
        }

        public string Name {
            get
            {
                return name;
            }
        }

        public double Stepsize {
            get
            {
                return stepsize;
            }
        }

        public void setInitialPosition(int Position)
        {
            string command = "I" + Position.ToString() + "#";
            tl.LogMessage("AAF2.setInitialPosition", "Sending: " + command);
            string r = CommandString(command, true);
            tl.LogMessage("AAF2.setInitialPosition", "Received: " + r);
        }

        public void setTargetPosition(int Position)
        {
            string command = "T" + Position.ToString() + "#";
            tl.LogMessage("AAF2.setPosition", "Sending: " + command);
            string r = CommandString(command, true);
            tl.LogMessage("AAF2.setPosition", "Received: " + r);
        }

        public int getPosition()
        {
            string command = "P" + "#";
            tl.LogMessage("AAF2.getPosition", "Sending: " + command);
            string r = CommandString(command, true);
            tl.LogMessage("AAF2.getPosition", "Received: " + r);
            string[] w = r.Split(':');
            string p = w[0].Substring(1);
            tl.LogMessage("AAF2.getPosition", "Position = " + p);
            return Int32.Parse(p);
        }

        internal bool isMoving()
        {
            bool result;
            string command = "M#";
            tl.LogMessage("AAF2.isMoving", "Sending: " + command);
            string r = CommandString(command, true);
            tl.LogMessage("AAF2.isMoving", "Received: " + r);

            if (r == "M1:OK#")
            {
                tl.LogMessage("AAF2.isMoving", "Focuser is Moving");
                result = true;
            }
            else if (r == "M0:OK#")
            {
                tl.LogMessage("AAF2.isMoving", "Focuser is Not Moving");
                result = false;
            }
            else
            {
                tl.LogMessage("AAF2.isMoving", "Unable to say");
                result = false;
            }

            return result;
        }

        internal void halt()
        {
            string command = "H#";
            tl.LogMessage("AAF2.halt", "Sending: " + command);
            string r = CommandString(command, true);
            tl.LogMessage("AAF2.halt", "Received: " + r);
            tl.LogMessage("AAF2.halt", "Focuser has stopped");
        }
    }
}
