using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UDPDataProvider.ViewModel;

namespace UDPDataProvider.UDPManager
{
    class UDPDataManager
    {
        #region Instances
        UdpClient server = new UdpClient(udpServerPort);
        #endregion

        #region Vars

        //bytearray containing the received UDP message
        byte[] Received_Data;

        //string containing converted byte array Received_Data
        string ReceivedMessage;

        //JSON Parser MQTT message
        dynamic Parsed_ReceivedMessage;

        // default UDPServerPort value
        private const int udpServerPort = 5005;

        // default UDPClientPort value
        private const int udpVTTPlayerPort = 5006;

        //string containing the IP address of the VTT Player
        readonly string VttPlayerAddress = "127.0.0.1";

        #endregion

        #region EventHandlers

        public event EventHandler<TextReceivedEventArgs> NewUDPTextReceived;

        protected virtual void OnUDPReceived(TextReceivedEventArgs e)
        {
            NewUDPTextReceived?.Invoke(this, e);
        }

        public class TextReceivedEventArgs : EventArgs
        {
            public string TextReceived { get; set; }
            public string ESP_TimeStamp { get; set; }
            public string IMU1_AccX { get; set; }
            public string IMU1_AccY { get; set; }
            public string IMU1_AccZ { get; set; }
            public string IMU1_GyroX { get; set; }
            public string IMU1_GyroY { get; set; }
            public string IMU1_GyroZ { get; set; }
            public string IMU1_MagX { get; set; }
            public string IMU1_MagY { get; set; }
            public string IMU1_MagZ { get; set; }
            public string IMU1_Q0 { get; set; }
            public string IMU1_Q1 { get; set; }
            public string IMU1_Q2 { get; set; }
            public string IMU1_Q3 { get; set; }
            public string IMU2_AccX { get; set; }
            public string IMU2_AccY { get; set; }
            public string IMU2_AccZ { get; set; }
            public string IMU2_GyroX { get; set; }
            public string IMU2_GyroY { get; set; }
            public string IMU2_GyroZ { get; set; }
            public string IMU2_MagX { get; set; }
            public string IMU2_MagY { get; set; }
            public string IMU2_MagZ { get; set; }
            public string IMU2_Q0 { get; set; }
            public string IMU2_Q1 { get; set; }
            public string IMU2_Q2 { get; set; }
            public string IMU2_Q3 { get; set; }
            public string Temp_Ext { get; set; }
            public string Humidity_Ext { get; set; }
            public string Temp_Int { get; set; }
            public string Humidity_Int { get; set; }
            public string Pulse_TempLobe { get; set; }
            public string GSR { get; set; }
        }

        #endregion
                
        #region Methods
        // Async function running the UDP Server. 
        private void UDPServerCallback(IAsyncResult res)
        {
            if (Globals.IsRecordingUDP == true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, udpServerPort);
                Received_Data = server.EndReceive(res, ref RemoteIpEndPoint);
                ReceivedMessage = Encoding.UTF8.GetString(Received_Data);
                JSONParse_ReceivedMessage();
                Publish_Data();
                UpdateValues();
                server.BeginReceive(new AsyncCallback(UDPServerCallback), null);
            }
        }

        // This function starts a new UDP Server at the start of the program
        public void UDPServerStart()
        {
            if (Globals.IsRecordingUDP == true)
            {
                try
                {
                    server.BeginReceive(new AsyncCallback(UDPServerCallback), null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        // Stops the UDP Server at the end of a recording
        public void UDPServerStop()
        {
            try
            {
                server.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        // this function sets all the variables to the received values
        void UpdateValues()
        {
            TextReceivedEventArgs args = new TextReceivedEventArgs
            {
                TextReceived = ReceivedMessage,
                ESP_TimeStamp = Parsed_ReceivedMessage.time,
                IMU1_AccX = Parsed_ReceivedMessage.imus[0].ax,
                IMU1_AccY = Parsed_ReceivedMessage.imus[0].ay,
                IMU1_AccZ = Parsed_ReceivedMessage.imus[0].az,
                IMU1_GyroX = Parsed_ReceivedMessage.imus[0].gx,
                IMU1_GyroY = Parsed_ReceivedMessage.imus[0].gy,
                IMU1_GyroZ = Parsed_ReceivedMessage.imus[0].gz,
                IMU1_MagX = Parsed_ReceivedMessage.imus[0].mx,
                IMU1_MagY = Parsed_ReceivedMessage.imus[0].my,
                IMU1_MagZ = Parsed_ReceivedMessage.imus[0].mz,
                IMU1_Q0 = Parsed_ReceivedMessage.imus[0].q0,
                IMU1_Q1 = Parsed_ReceivedMessage.imus[0].q1,
                IMU1_Q2 = Parsed_ReceivedMessage.imus[0].q2,
                IMU1_Q3 = Parsed_ReceivedMessage.imus[0].q3,
                IMU2_AccX = Parsed_ReceivedMessage.imus[1].ax,
                IMU2_AccY = Parsed_ReceivedMessage.imus[1].ay,
                IMU2_AccZ = Parsed_ReceivedMessage.imus[1].az,
                IMU2_GyroX = Parsed_ReceivedMessage.imus[1].gx,
                IMU2_GyroY = Parsed_ReceivedMessage.imus[1].gy,
                IMU2_GyroZ = Parsed_ReceivedMessage.imus[1].gz,
                IMU2_MagX = Parsed_ReceivedMessage.imus[1].mx,
                IMU2_MagY = Parsed_ReceivedMessage.imus[1].my,
                IMU2_MagZ = Parsed_ReceivedMessage.imus[1].mz,
                IMU2_Q0 = Parsed_ReceivedMessage.imus[1].q0,
                IMU2_Q1 = Parsed_ReceivedMessage.imus[1].q1,
                IMU2_Q2 = Parsed_ReceivedMessage.imus[1].q2,
                IMU2_Q3 = Parsed_ReceivedMessage.imus[1].q3,
                Temp_Ext = Parsed_ReceivedMessage.shts[0].temp,
                Humidity_Ext = Parsed_ReceivedMessage.shts[0].hum,
                Temp_Int = Parsed_ReceivedMessage.shts[1].temp,
                Humidity_Int = Parsed_ReceivedMessage.shts[1].hum,
                Pulse_TempLobe = Parsed_ReceivedMessage.pulse,
                GSR = Parsed_ReceivedMessage.gsr
            };
            OnUDPReceived(args);
        }
        // this function is used to parse MQTT JSON String
        void JSONParse_ReceivedMessage()
        {

            Parsed_ReceivedMessage = JObject.Parse(ReceivedMessage);

        }


        #endregion

        #region UDP
        // this code runs when UDP data is received. It sends the unfiltered string directly to the VTT Player.
        private void Publish_Data()
        {
            Boolean exception_thrown = false;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(VttPlayerAddress);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, udpVTTPlayerPort);

            try
            {
                sending_socket.SendTo(Received_Data, sending_end_point);
            }
            catch (Exception send_exception)
            {
                exception_thrown = true;
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
            if (exception_thrown == false)
            {
                Console.WriteLine("Message has been sent to the broadcast address");
            }
            else
            {
                exception_thrown = false;
                Console.WriteLine("The exception indicates the message was not sent.");
            }
        }
        #endregion
    }
}
