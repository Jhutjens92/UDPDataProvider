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
        
        //string containing converted byte array Received_Data
        private static string receivedMessage;
        #endregion

        #region Methods
        // Parse MQTT JSON String
        public static string JSONParseReceivedMessage(byte[] receivedData)
        {
            receivedMessage = Encoding.UTF8.GetString(receivedData);
            Globals.jsonErrorMessage = false;
            try
            {
                parsedReceivedMessage = JObject.Parse(receivedMessage);
            }
            catch (Exception)
            {
                receivedMessage = "Invalid JSON String";
            }
            return receivedMessage;
        }
        #endregion
    }
}
