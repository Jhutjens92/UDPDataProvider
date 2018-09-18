﻿using UDPDataProvider.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace UDPDataProvider.UDPManager
{
    class UDPDataManager
    {

        MqttClient client;
        string clientId;
        string ReceivedMessage;             //string containing the UDP published message
        string BrokerAddress;               //default MQTT server value for WEKIT

        public event EventHandler<TextReceivedEventArgs> NewUDPTextReceived;

        private string _txtReceived = " ";
        public string TxtReceived
        {
            get { return _txtReceived; }
            set
            {
                _txtReceived = value;

            }
        }

        protected virtual void OnUDPReceived(TextReceivedEventArgs e)
        {
            EventHandler<TextReceivedEventArgs> handler = NewUDPTextReceived;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public class TextReceivedEventArgs : EventArgs
        {
            public string GSR { get; set; }
            public string TextReceived { get; set; }
        }


        public UDPDataManager()
        {
            //INIT Var Values//
            BrokerAddress = "localhost";
            //MQTT Functions//
            clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
        }


        #region Methods

        //if (Globals.IsRecordingUDP == true)
        //{
        //    Publish_Data();
        //    TextReceivedEventArgs args = new TextReceivedEventArgs();
        //    args.TextReceived = ReceivedMessage;
        //    OnNewTextReceived(args);
        //}


        public String UpdateText()
        {
            return TxtReceived;
        }

        #endregion

        #region MQTT
        // this code runs when data is published to the subscribed topic
        private void Publish_Data()
        {
            // whole topic
            //string GSR_Value = Parsed_ReceivedMessage.gsr;
            //client.Publish("wekit/vest/GSR_Raw", Encoding.UTF8.GetBytes(GSR_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //string Pulse_Value = Parsed_ReceivedMessage.pulse;
            //client.Publish("wekit/vest/Pulse_Raw", Encoding.UTF8.GetBytes(Pulse_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //string SHT1X1_Temp_Value = Parsed_ReceivedMessage.shts[0].temp;
            //client.Publish("wekit/vest/Sht0_Temp", Encoding.UTF8.GetBytes(SHT1X1_Temp_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //string SHT1X1_Hum_Value = Parsed_ReceivedMessage.shts[0].hum;
            //client.Publish("wekit/vest/Sht0_Hum", Encoding.UTF8.GetBytes(SHT1X1_Hum_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //string SHT2X2_Temp_Value = Parsed_ReceivedMessage.shts[1].temp;
            //client.Publish("wekit/vest/Sht2_Temp", Encoding.UTF8.GetBytes(SHT2X2_Temp_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            //string SHT2X2_Hum_Value = Parsed_ReceivedMessage.shts[1].hum;
            //client.Publish("wekit/vest/Sht2_Hum", Encoding.UTF8.GetBytes(SHT2X2_Hum_Value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
        #endregion
    }
}