using System;
using UDPDataProvider.ViewModel;
using Newtonsoft.Json.Linq;


namespace UDPDataProvider.Classes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Class containing the Jsonparser. </summary>
    ///
    /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class JsonParser
    {
        #region Variables

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method for getting the ParsedUdpMsg variable. </summary>
        ///
        /// <value> A message describing the parsed udp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public dynamic ParsedUdpMsg
        {
            get { return parsedUdpMsg; }
        }
        private static dynamic parsedUdpMsg;

        #endregion

        #region Method

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Parse UDP JSON string. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="receivedMessage">  String containing the receivedMessage from the UDP Receive
        ///                                 funtion. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void JSONParseReceivedMessage(string receivedMessage)
        {
            try
            {
                parsedUdpMsg = JObject.Parse(receivedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}