using UDPDataProvider.ViewModel;
using UDPDataProvider.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPDataProvider.Classes
{
    class JsonParser
    {
        #region Vars
        // JSON Parser MQTT message
        public static dynamic parsedReceivedMessage;
        #endregion

        #region Methods
        // Parse MQTT JSON String
        public static void JSONParseReceivedMessage()
        {
            Globals.jsonErrorMessage = false;
            try
            {
                parsedReceivedMessage = JObject.Parse(UdpManager.receivedMessage);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid JSON String");
            }
        }
        #endregion
    }
}
