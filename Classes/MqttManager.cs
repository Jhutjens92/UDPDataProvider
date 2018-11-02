using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace UDPDataProvider.Classes
{
    class MqttManager
    {
        JsonParser jsonpar = new JsonParser();
        MqttClient mqttClient;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Publish the data over MQTT. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 2-11-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PublishData()
        {
            try
            {
                mqttClient.Publish("wekit/vest/GSR_Raw", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.gsr), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                mqttClient.Publish("wekit/vest/Pulse_Raw", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.pulse), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                mqttClient.Publish("wekit/vest/Sht0_Temp", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.shts[0].temp), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                mqttClient.Publish("wekit/vest/Sht0_Hum", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.shts[0]), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                mqttClient.Publish("wekit/vest/Sht1_Temp", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.shts[1].temp), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                mqttClient.Publish("wekit/vest/Sht1_Hum", Encoding.UTF8.GetBytes(jsonpar.ParsedUdpMsg.shts[1].hum), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the MQTT Client. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CreateMqttClient()
        {
            try
            {
                mqttClient = new MqttClient(CheckParameters.Instance.BrokerAddress);
                ConnectMqttClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Closes the MQTT connection when the program stops. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CloseMqttConnection()
        {
            try
            {
                mqttClient.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connects to the MQTT Client with a random ID (generated) </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ConnectMqttClient()
        {
            try
            {
                string clientId;
                clientId = Guid.NewGuid().ToString();
                mqttClient.Connect(clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
