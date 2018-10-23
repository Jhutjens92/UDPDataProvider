using System;
using UDPDataProvider.ViewModel;
using Newtonsoft.Json.Linq;


namespace UDPDataProvider.Classes
{
    class JsonParser
    {

        #region Variables
        // JSON Parser UDP message
        public static dynamic ParsedUdpMsg
        {
            get { return parsedUdpMsg; }
            set { parsedUdpMsg = value; }
        }
        private static dynamic parsedUdpMsg;
        #endregion

        #region Method
        // Parse UDP JSON string
        public static void JSONParseReceivedMessage(string receivedStrMsg)
        {
            Globals.JsonErrorMessage = false;
            try
            {
                parsedUdpMsg = JObject.Parse(receivedStrMsg);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid JSON string");
            }
        }
        #endregion
    }
}