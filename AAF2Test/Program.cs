using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAF2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = ASCOM.DriverAccess.Focuser.Choose("");
            if (string.IsNullOrEmpty(id))
                return;
            // create this device
            ASCOM.DriverAccess.Focuser focuser = new ASCOM.DriverAccess.Focuser(id);

            // now run some tests, adding code to your driver so that the tests will pass.
            // these first tests are common to all drivers.
            Console.WriteLine("name " + focuser.Name);
            Console.WriteLine("description " + focuser.Description);
            Console.WriteLine("DriverInfo " + focuser.DriverInfo);
            Console.WriteLine("driverVersion " + focuser.DriverVersion);

            // Connect to Focusser
            focuser.Connected = true;

            if (focuser.Connected)
            {
                Console.WriteLine("Connected");
            }
            else
            {
                Console.WriteLine("Not Connected");
            }


            // Tests
            commandTest(focuser, "V#");
            
            // Disconnect from Focusser
            focuser.Connected = false;
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }

        private static void commandTest(ASCOM.DriverAccess.Focuser focuser, String s)
        {
            Console.WriteLine();
            Console.WriteLine("--------- S T A R T -------------");
            Console.WriteLine(" Sending: " + s);
            String r = focuser.CommandString(s, true);
            Console.WriteLine("Received: " + r);
            Console.WriteLine("------- F I N I S H -------------");
            Console.WriteLine();
        }

    }
}
