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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   method for getting the BrokerAddress variable. </summary>
        ///
        /// <value> The broker address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string BrokerAddress
        {
            get { return brokerAddress; }
        }
        private string brokerAddress;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the client port./ </summary>
        ///
        /// <value> The client port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }
        private int clientPort;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the server port. </summary>
        ///
        /// <value> The server port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }
        private int serverPort;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the client address. </summary>
        ///
        /// <value> The client address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ClientAddress
        {
            get { return clientAddress; }
            set { clientAddress = value; }
        }
        private string clientAddress;


        /// <summary>   True to cp par. </summary>
        bool cpPar = false;

        /// <summary>   True to sp par. </summary>
        bool spPar = false;

        /// <summary>   True to ca par. </summary>
        bool caPar = false;

        /// <summary>   True to ba par. </summary>
        bool baPar = false;

        #endregion

        #region Method

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Checks the startup parameters given (if any). If no arguments given, it sets default values.
        /// </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CheckStartupParameters()
        {
            try
            {
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
                if (StartupPar.Any(s => s.Contains("-ba")))
                {
                    int ParIndex = Array.IndexOf(StartupPar, "-ba");
                    brokerAddress = StartupPar[ParIndex + 1];
                    baPar = true;
                }
                else
                {
                    if (!cpPar)
                    {
                        clientPort = 5006;
                        Console.WriteLine("Starting with default client port (5005).");
                    }
                    if (!spPar)
                    {
                        serverPort = 5005;
                        Console.WriteLine("Starting with default server port (5005).");
                    }
                    if (!caPar)
                    {
                        clientAddress = "127.0.0.1";
                        Console.WriteLine("Starting with default client IP address (localhost).");
                    }
                    if (!baPar)
                    {
                        brokerAddress = "localhost";
                        Console.WriteLine("Starting with default broker address (localhost).");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
