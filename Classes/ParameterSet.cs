using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPDataProvider.Classes;

namespace MQTTDataProvider.Classes
{
    class ParameterSet
    {
        // Checks the startup parameters
        public static void SetParameters()
        {
            string[] Parameters = Environment.GetCommandLineArgs();
            if (Parameters.Any(s => s.Contains("-sp")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-sp");
                UdpManager.serverPort = Int32.Parse(Parameters[parameterIndex + 1]);
            }
            else if (Parameters.Any(s => s.Contains("-cp")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-cp");
                UdpManager.clientPort = Int32.Parse(Parameters[parameterIndex + 1]);
            }
            else if (Parameters.Any(s => s.Contains("-ca")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-ca");
                UdpManager.clientAddress = Parameters[parameterIndex + 1];
            }
            else
            {
                Console.WriteLine("No valid paramater provided, starting with default values.");
            }
        }
    }
}
