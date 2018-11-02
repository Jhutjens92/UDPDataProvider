using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPDataProvider.Classes
{
    public sealed class CheckParameters
    {
        #region Variables


        /// <summary>   Instance if CheckParameters. </summary>
        private static CheckParameters instance = null;

        /// <summary> The padlock for the Singleton Thread safe check. </summary>
        private static readonly object padlock = new object();

        
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

        /// <summary>   True to sp par. </summary>
        bool spPar = false;

        /// <summary>   True to ba par. </summary>
        bool baPar = false;

        #endregion

        #region Method

        CheckParameters()
        {
        }

        public static CheckParameters Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CheckParameters();
                    }
                    return instance;
                }
            }
        }

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
                if (StartupPar.Any(s => s.Contains("-sp")))
                {
                    int ParIndex = Array.IndexOf(StartupPar, "-sp");
                    serverPort = Convert.ToInt32(StartupPar[ParIndex + 1]);
                    spPar = true;
                }
                if (StartupPar.Any(s => s.Contains("-ba")))
                {
                    int ParIndex = Array.IndexOf(StartupPar, "-ba");
                    brokerAddress = StartupPar[ParIndex + 1];
                    baPar = true;
                }
                else
                {
                    if (!spPar)
                    {
                        serverPort = 5005;
                        Console.WriteLine("Starting with default server port (5005).");
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
