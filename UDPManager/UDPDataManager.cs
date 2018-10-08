using MQTTDataProvider.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using System.Windows;
using UDPDataProvider.ViewModel;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace UDPDataProvider.UDPManager
{
    class UDPDataManager
    {
        #region Instances
        UdpClient server = new UdpClient(ServerPort);
        #endregion

        #region Vars

        //bytearray containing the received UDP message
        byte[] ReceivedData;

        //string containing converted byte array Received_Data
        string ReceivedMessage;

        //JSON Parser UDP message
        dynamic ParsedReceivedMessage;

        // default UDPServerPort value
        private static int ServerPort = 5005;

        // default UDPClientPort value
        private int ClientPort = 5006;

        //string containing the IP address of the VTT Player
        private string ClientAddress = "0.0.0.0";

        #endregion

        #region Events

        public event EventHandler<TextReceivedEventArgs> NewUDPTextReceived;

        protected virtual void OnUDPReceived(TextReceivedEventArgs e)
        {
            NewUDPTextReceived?.Invoke(this, e);
        }

        public class TextReceivedEventArgs : EventArgs
        {
            private string _TextReceived;
            public string TextReceived
            {
                get
                {
                    return _TextReceived;
                }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _TextReceived = value;
                }
            }

            private string _IMU1_AccX = "";
            public String IMU1_AccX
            {
                get { return _IMU1_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_AccX = value;
                }
            }

            private string _IMU1_AccY = "";
            public String IMU1_AccY
            {
                get { return _IMU1_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_AccY = value;
                }
            }

            private string _IMU1_AccZ = "";
            public String IMU1_AccZ
            {
                get { return _IMU1_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_AccZ = value;
                }
            }

            private string _IMU1_GyroX = "";
            public String IMU1_GyroX
            {
                get { return _IMU1_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_GyroX = value;
                }
            }

            private string _IMU1_GyroY = "";
            public String IMU1_GyroY
            {
                get { return _IMU1_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_GyroY = value;
                }
            }

            private string _IMU1_GyroZ = "";
            public String IMU1_GyroZ
            {
                get { return _IMU1_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_GyroZ = value;
                }
            }

            private string _IMU1_MagX = "";
            public String IMU1_MagX
            {
                get { return _IMU1_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_MagX = value;
                }
            }

            private string _IMU1_MagY = "";
            public String IMU1_MagY
            {
                get { return _IMU1_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_MagY = value;
                }
            }

            private string _IMU1_MagZ = "";
            public String IMU1_MagZ
            {
                get { return _IMU1_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_MagZ = value;
                }
            }

            private string _IMU1_Q0 = "";
            public String IMU1_Q0
            {
                get { return _IMU1_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_Q0 = value;
                }
            }

            private string _IMU1_Q1 = "";
            public String IMU1_Q1
            {
                get { return _IMU1_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_Q1 = value;
                }
            }

            private string _IMU1_Q2 = "";
            public String IMU1_Q2
            {
                get { return _IMU1_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_Q2 = value;
                }
            }

            private string _IMU1_Q3 = "";
            public String IMU1_Q3
            {
                get { return _IMU1_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU1_Q3 = value;
                }
            }

            private string _IMU2_AccX = "";
            public String IMU2_AccX
            {
                get { return _IMU2_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_AccX = value;
                }
            }

            private string _IMU2_AccY = "";
            public String IMU2_AccY
            {
                get { return _IMU2_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_AccY = value;
                }
            }

            private string _IMU2_AccZ = "";
            public String IMU2_AccZ
            {
                get { return _IMU2_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_AccZ = value;
                }
            }

            private string _IMU2_GyroX = "";
            public String IMU2_GyroX
            {
                get { return _IMU2_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_GyroX = value;
                }
            }

            private string _IMU2_GyroY = "";
            public String IMU2_GyroY
            {
                get { return _IMU2_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_GyroY = value;
                }
            }

            private string _IMU2_GyroZ = "";
            public String IMU2_GyroZ
            {
                get { return _IMU2_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_GyroZ = value;
                }
            }

            private string _IMU2_MagX = "";
            public String IMU2_MagX
            {
                get { return _IMU2_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_MagX = value;
                }
            }

            private string _IMU2_MagY = "";
            public String IMU2_MagY
            {
                get { return _IMU2_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_MagY = value;
                }
            }

            private string _IMU2_MagZ = "";
            public String IMU2_MagZ
            {
                get { return _IMU2_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_MagZ = value;
                }
            }

            private string _IMU2_Q0 = "";
            public String IMU2_Q0
            {
                get { return _IMU2_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_Q0 = value;
                }
            }

            private string _IMU2_Q1 = "";
            public String IMU2_Q1
            {
                get { return _IMU2_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_Q1 = value;
                }
            }

            private string _IMU2_Q2 = "";
            public String IMU2_Q2
            {
                get { return _IMU2_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_Q2 = value;
                }
            }

            private string _IMU2_Q3 = "";
            public String IMU2_Q3
            {
                get { return _IMU2_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _IMU2_Q3 = value;
                }
            }

            private string _Temp_External = "";
            public String Temp_External
            {
                get { return _Temp_External; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _Temp_External = value;
                }
            }

            private string _Humidity_External = "";
            public String Humidity_External
            {
                get { return _Humidity_External; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _Humidity_External = value;
                }
            }

            private string _Temp_Internal = "";
            public String Temp_Internal
            {
                get { return _Temp_Internal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _Temp_Internal = value;
                }
            }

            private string _Humidity_Internal = "";
            public String Humidity_Internal
            {
                get { return _Humidity_Internal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _Humidity_Internal = value;
                }
            }

            private string _Pulse_TempLobe = "";
            public String Pulse_TempLobe
            {
                get { return _Pulse_TempLobe; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _Pulse_TempLobe = value;
                }
            }

            private string _GSR = "";
            public String GSR
            {
                get { return _GSR; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _GSR = value;
                }
            }

            private string _ESP_TimeStamp = "";
            public String ESP_TimeStamp
            {
                get { return _ESP_TimeStamp; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _ESP_TimeStamp = value;
                }
            }
        }

        #endregion
                
        #region Methods
        // Async function running the UDP Server. 
        private void UDPServerCallback(IAsyncResult res)
        {
            if (Globals.IsRecordingUDP == true)
            {
                SetParameters();
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, ServerPort);
                ReceivedData = server.EndReceive(res, ref RemoteIpEndPoint);
                ReceivedMessage = Encoding.UTF8.GetString(ReceivedData);
                JSONParseReceivedMessage();
                PublishData();
                UpdateValues();
                server.BeginReceive(new AsyncCallback(UDPServerCallback), null);
            }
        }

        // Checks the startup parameters
        private void SetParameters()
        {
            string[] Parameters = Environment.GetCommandLineArgs();
            if (Parameters.Any(s => s.Contains("-sp")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-sp");
                ServerPort = Int32.Parse(Parameters[parameterIndex + 1]);
            }
            else if (Parameters.Any(s => s.Contains("-cp")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-cp");
                ClientPort = Int32.Parse(Parameters[parameterIndex + 1]);
            }
            else if (Parameters.Any(s => s.Contains("-ca")))
            {
                int parameterIndex = Array.IndexOf(Parameters, "-ca");
                ClientAddress = Parameters[parameterIndex + 1];
            }
            else
            {
                Console.WriteLine("No valid paramater provided, starting with default values.");
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
        private void UpdateValues()
        {
            try
            {
                TextReceivedEventArgs args = new TextReceivedEventArgs
                {
                    TextReceived = ReceivedMessage,
                    ESP_TimeStamp = ParsedReceivedMessage.time,
                    IMU1_AccX = ParsedReceivedMessage.imus[0].ax,
                    IMU1_AccY = ParsedReceivedMessage.imus[0].ay,
                    IMU1_AccZ = ParsedReceivedMessage.imus[0].az,
                    IMU1_GyroX = ParsedReceivedMessage.imus[0].gx,
                    IMU1_GyroY = ParsedReceivedMessage.imus[0].gy,
                    IMU1_GyroZ = ParsedReceivedMessage.imus[0].gz,
                    IMU1_MagX = ParsedReceivedMessage.imus[0].mx,
                    IMU1_MagY = ParsedReceivedMessage.imus[0].my,
                    IMU1_MagZ = ParsedReceivedMessage.imus[0].mz,
                    IMU1_Q0 = ParsedReceivedMessage.imus[0].q0,
                    IMU1_Q1 = ParsedReceivedMessage.imus[0].q1,
                    IMU1_Q2 = ParsedReceivedMessage.imus[0].q2,
                    IMU1_Q3 = ParsedReceivedMessage.imus[0].q3,
                    IMU2_AccX = ParsedReceivedMessage.imus[1].ax,
                    IMU2_AccY = ParsedReceivedMessage.imus[1].ay,
                    IMU2_AccZ = ParsedReceivedMessage.imus[1].az,
                    IMU2_GyroX = ParsedReceivedMessage.imus[1].gx,
                    IMU2_GyroY = ParsedReceivedMessage.imus[1].gy,
                    IMU2_GyroZ = ParsedReceivedMessage.imus[1].gz,
                    IMU2_MagX = ParsedReceivedMessage.imus[1].mx,
                    IMU2_MagY = ParsedReceivedMessage.imus[1].my,
                    IMU2_MagZ = ParsedReceivedMessage.imus[1].mz,
                    IMU2_Q0 = ParsedReceivedMessage.imus[1].q0,
                    IMU2_Q1 = ParsedReceivedMessage.imus[1].q1,
                    IMU2_Q2 = ParsedReceivedMessage.imus[1].q2,
                    IMU2_Q3 = ParsedReceivedMessage.imus[1].q3,
                    Temp_External = ParsedReceivedMessage.shts[0].temp,
                    Humidity_External = ParsedReceivedMessage.shts[0].hum,
                    Temp_Internal = ParsedReceivedMessage.shts[1].temp,
                    Humidity_Internal = ParsedReceivedMessage.shts[1].hum,
                    Pulse_TempLobe = ParsedReceivedMessage.pulse,
                    GSR = ParsedReceivedMessage.gsr
                };
                OnUDPReceived(args);
                PublishData();
            }
            catch (Exception)
            {
                TextReceivedEventArgs args = new TextReceivedEventArgs
                {
                    TextReceived = "Invalid JSON message at the MQTT Receiver"
                };
                Globals.JSONErrorMessage = true;
                OnUDPReceived(args);
            }
        }

        // Parse MQTT JSON String
        private void JSONParseReceivedMessage()
        {
            Globals.JSONErrorMessage = false;
            try
            {
                ParsedReceivedMessage = JObject.Parse(ReceivedMessage);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid JSON String");
            }
        }

        // this code runs when UDP data is received. It sends the unfiltered string directly to the VTT Player.
        private void PublishData()
        {
            //potentially add a startup parameter to switch between MQTT and UDP sending
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(ClientAddress);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, ClientPort);
            sending_socket.SendTo(ReceivedData, sending_end_point);
        }
        #endregion
    }
}
