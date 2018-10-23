using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPDataProvider.Classes
{
    class CheckParameters
    {
        #region Variables
        // default ClientPort value
        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }
        private int clientPort;

        // default ServerPort value
        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }
        private int serverPort;

        // default ClientAddress value
        public string ClientAddress
        {
            get { return clientAddress; }
            set { clientAddress = value; }
        }
        private string clientAddress;

        // booleans to check if parameters are provided.
        bool cpPar = false;
        bool spPar = false;
        bool caPar = false;

        #endregion

        #region Method
        public void CheckStartupParameters()
        {
            // check the startup parameters
            string[] StartupPar = Environment.GetCommandLineArgs();
            if (StartupPar.Any(s => s.Contains("-cp")))
            {
                int ParIndex = Array.IndexOf(StartupPar, "-cp");
                clientPort = Convert.ToInt32(StartupPar[ParIndex + 1]);
                cpPar = true;
            }
            if (StartupPar.Any(s => s.Contains("-sp")))
            {
                int ParIndex = Array.IndexOf(StartupPar, "-sp");
                serverPort = Convert.ToInt32(StartupPar[ParIndex + 1]);
                spPar = true;
            }
            if (StartupPar.Any(s => s.Contains("-ca")))
            {
                int ParIndex = Array.IndexOf(StartupPar, "-ca");
                clientAddress = StartupPar[ParIndex + 1];
                caPar = true;
            }
            // if no parameters are provided, set the default values accordingly.
            else 
            {
                if (cpPar == false)
                {
                    clientPort = 5006;
                    Console.WriteLine("Starting with default client port (5005).");
                }
                if (spPar == false)
                {
                    serverPort = 5005;
                    Console.WriteLine("Starting with default server port (5005).");
                }
                if (caPar == false)
                {
                    clientAddress = "127.0.0.1";
                    Console.WriteLine("Starting with default client IP address (localhost).");
                }
                
            }
        }
        #endregion
    }
}
