using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace MQTTDataProvider.ViewModel
{
    public static class Globals
    {
        private static bool _isRecordingUDP = false;
        public static bool IsRecordingUDP
        {
            get { return _isRecordingUDP; }
            set
            {
                _isRecordingUDP = value;
            }
        }

        private static bool _isRecordingDone = false;
        public static bool IsRecordingDone
        {
            get { return _isRecordingDone; }
            set
            {
                _isRecordingDone = value;
            }
        }

        /*The following globals currently not being used since parameters haven't been implemented yet*/

        //default MQTT server value for WEKIT
        private static readonly string _brokerAddress = "localhost";
        public static string BrokerAddress
        {
            get { return _brokerAddress; }
        }

        // use a unique id as client id
        private static readonly string _cliendID = Guid.NewGuid().ToString();
        public static string ClientID
        {
            get { return _cliendID; }
        }

        private static MqttClient _client = new MqttClient(BrokerAddress);
        public static MqttClient Client
        {
            get
            {
                if (_client.IsConnected == false)
                {
                    _client.Connect(ClientID);
                }
                return _client;
            }
        }

    }
}