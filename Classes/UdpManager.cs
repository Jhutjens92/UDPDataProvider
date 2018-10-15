using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using UDPDataProvider.ViewModel;
using UDPDataProvider.Classes;
using MQTTDataProvider.Classes;

namespace UDPDataProvider.Classes
{
    class UdpManager
    {
        #region Instances
        UdpClient server = new UdpClient(serverPort);
        #endregion

        #region Vars
        //bytearray containing the received UDP message
        byte[] receivedData;

        //string containing converted byte array Received_Data
        public static string receivedMessage;

        // default UDPServerPort value
        public static int serverPort = 5005;

        // default UDPClientPort value
        public static int clientPort = 5006;

        //string containing the IP address of the VTT Player
        public static string clientAddress = "0.0.0.0";
        #endregion

        #region Events

        public event EventHandler<TextReceivedEventArgs> NewUDPTextReceived;

        protected virtual void OnUDPReceived(TextReceivedEventArgs e)
        {
            NewUDPTextReceived?.Invoke(this, e);
        }

        public class TextReceivedEventArgs : EventArgs
        {
            private string _textReceived;
            public string textReceived
            {
                get
                {
                    return _textReceived;
                }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _textReceived = value;
                }
            }

            private string _imu1_AccX = "";
            public String imu1_AccX
            {
                get { return _imu1_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_AccX = value;
                }
            }

            private string _imu1_AccY = "";
            public String imu1_AccY
            {
                get { return _imu1_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_AccY = value;
                }
            }

            private string _imu1_AccZ = "";
            public String imu1_AccZ
            {
                get { return _imu1_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_AccZ = value;
                }
            }

            private string _imu1_GyroX = "";
            public String imu1_GyroX
            {
                get { return _imu1_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_GyroX = value;
                }
            }

            private string _imu1_GyroY = "";
            public String imu1_GyroY
            {
                get { return _imu1_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_GyroY = value;
                }
            }

            private string _imu1_GyroZ = "";
            public String imu1_GyroZ
            {
                get { return _imu1_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_GyroZ = value;
                }
            }

            private string _imu1_MagX = "";
            public String imu1_MagX
            {
                get { return _imu1_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_MagX = value;
                }
            }

            private string _imu1_MagY = "";
            public String imu1_MagY
            {
                get { return _imu1_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_MagY = value;
                }
            }

            private string _imu1_MagZ = "";
            public String imu1_MagZ
            {
                get { return _imu1_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_MagZ = value;
                }
            }

            private string _imu1_Q0 = "";
            public String imu1_Q0
            {
                get { return _imu1_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_Q0 = value;
                }
            }

            private string _imu1_Q1 = "";
            public String imu1_Q1
            {
                get { return _imu1_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_Q1 = value;
                }
            }

            private string _imu1_Q2 = "";
            public String imu1_Q2
            {
                get { return _imu1_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_Q2 = value;
                }
            }

            private string _imu1_Q3 = "";
            public String imu1_Q3
            {
                get { return _imu1_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu1_Q3 = value;
                }
            }

            private string _imu2_AccX = "";
            public String imu2_AccX
            {
                get { return _imu2_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_AccX = value;
                }
            }

            private string _imu2_AccY = "";
            public String imu2_AccY
            {
                get { return _imu2_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_AccY = value;
                }
            }

            private string _imu2_AccZ = "";
            public String imu2_AccZ
            {
                get { return _imu2_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_AccZ = value;
                }
            }

            private string _imu2_GyroX = "";
            public String imu2_GyroX
            {
                get { return _imu2_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_GyroX = value;
                }
            }

            private string _imu2_GyroY = "";
            public String imu2_GyroY
            {
                get { return _imu2_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_GyroY = value;
                }
            }

            private string _imu2_GyroZ = "";
            public String imu2_GyroZ
            {
                get { return _imu2_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_GyroZ = value;
                }
            }

            private string _imu2_MagX = "";
            public String imu2_MagX
            {
                get { return _imu2_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_MagX = value;
                }
            }

            private string _imu2_MagY = "";
            public String imu2_MagY
            {
                get { return _imu2_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_MagY = value;
                }
            }

            private string _imu2_MagZ = "";
            public String imu2_MagZ
            {
                get { return _imu2_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_MagZ = value;
                }
            }

            private string _imu2_Q0 = "";
            public String imu2_Q0
            {
                get { return _imu2_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_Q0 = value;
                }
            }

            private string _imu2_Q1 = "";
            public String imu2_Q1
            {
                get { return _imu2_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_Q1 = value;
                }
            }

            private string _imu2_Q2 = "";
            public String imu2_Q2
            {
                get { return _imu2_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_Q2 = value;
                }
            }

            private string _imu2_Q3 = "";
            public String imu2_Q3
            {
                get { return _imu2_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _imu2_Q3 = value;
                }
            }

            private string _tempExternal = "";
            public String tempExternal
            {
                get { return _tempExternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _tempExternal = value;
                }
            }

            private string _humExternal = "";
            public String humExternal
            {
                get { return _humExternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _humExternal = value;
                }
            }

            private string _tempInternal = "";
            public String tempInternal
            {
                get { return _tempInternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _tempInternal = value;
                }
            }

            private string _humInternal = "";
            public String humInternal
            {
                get { return _humInternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _humInternal = value;
                }
            }

            private string _pulse = "";
            public String pulse
            {
                get { return _pulse; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _pulse = value;
                }
            }

            private string _gsr = "";
            public String gsr
            {
                get { return _gsr; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _gsr = value;
                }
            }

            private string _espTimeStamp = "";
            public String espTimeStamp
            {
                get { return _espTimeStamp; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    _espTimeStamp = value;
                }
            }
        }
        #endregion

        #region Methods
        // Async function running the UDP Server. 
        private void UDPServerCallback(IAsyncResult res)
        {
            if (Globals.isRecordingUdp == true)
            {
                ParameterSet.SetParameters();
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, serverPort);
                receivedData = server.EndReceive(res, ref RemoteIpEndPoint);
                receivedMessage = Encoding.UTF8.GetString(receivedData);
                JsonParser.JSONParseReceivedMessage();
                PublishData();
                UpdateValues();
                server.BeginReceive(new AsyncCallback(UDPServerCallback), null);
            }
        }

        // This function starts a new UDP Server at the start of the program
        public void UDPServerStart()
        {
            if (Globals.isRecordingUdp == true)
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
                    textReceived = receivedMessage,
                    espTimeStamp = JsonParser.parsedReceivedMessage.time,
                    imu1_AccX = JsonParser.parsedReceivedMessage.imus[0].ax,
                    imu1_AccY = JsonParser.parsedReceivedMessage.imus[0].ay,
                    imu1_AccZ = JsonParser.parsedReceivedMessage.imus[0].az,
                    imu1_GyroX = JsonParser.parsedReceivedMessage.imus[0].gx,
                    imu1_GyroY = JsonParser.parsedReceivedMessage.imus[0].gy,
                    imu1_GyroZ = JsonParser.parsedReceivedMessage.imus[0].gz,
                    imu1_MagX = JsonParser.parsedReceivedMessage.imus[0].mx,
                    imu1_MagY = JsonParser.parsedReceivedMessage.imus[0].my,
                    imu1_MagZ = JsonParser.parsedReceivedMessage.imus[0].mz,
                    imu1_Q0 = JsonParser.parsedReceivedMessage.imus[0].q0,
                    imu1_Q1 = JsonParser.parsedReceivedMessage.imus[0].q1,
                    imu1_Q2 = JsonParser.parsedReceivedMessage.imus[0].q2,
                    imu1_Q3 = JsonParser.parsedReceivedMessage.imus[0].q3,
                    imu2_AccX = JsonParser.parsedReceivedMessage.imus[1].ax,
                    imu2_AccY = JsonParser.parsedReceivedMessage.imus[1].ay,
                    imu2_AccZ = JsonParser.parsedReceivedMessage.imus[1].az,
                    imu2_GyroX = JsonParser.parsedReceivedMessage.imus[1].gx,
                    imu2_GyroY = JsonParser.parsedReceivedMessage.imus[1].gy,
                    imu2_GyroZ = JsonParser.parsedReceivedMessage.imus[1].gz,
                    imu2_MagX = JsonParser.parsedReceivedMessage.imus[1].mx,
                    imu2_MagY = JsonParser.parsedReceivedMessage.imus[1].my,
                    imu2_MagZ = JsonParser.parsedReceivedMessage.imus[1].mz,
                    imu2_Q0 = JsonParser.parsedReceivedMessage.imus[1].q0,
                    imu2_Q1 = JsonParser.parsedReceivedMessage.imus[1].q1,
                    imu2_Q2 = JsonParser.parsedReceivedMessage.imus[1].q2,
                    imu2_Q3 = JsonParser.parsedReceivedMessage.imus[1].q3,
                    tempExternal = JsonParser.parsedReceivedMessage.shts[0].temp,
                    humExternal = JsonParser.parsedReceivedMessage.shts[0].hum,
                    tempInternal = JsonParser.parsedReceivedMessage.shts[1].temp,
                    humInternal = JsonParser.parsedReceivedMessage.shts[1].hum,
                    pulse = JsonParser.parsedReceivedMessage.pulse,
                    gsr = JsonParser.parsedReceivedMessage.gsr
                };
                OnUDPReceived(args);
                PublishData();
            }
            catch (Exception)
            {
                TextReceivedEventArgs args = new TextReceivedEventArgs
                {
                    textReceived = "Invalid JSON message at the MQTT Receiver"
                };
                Globals.jsonErrorMessage = true;
                OnUDPReceived(args);
            }
        }

        // this code runs when UDP data is received. It sends the unfiltered string directly to the VTT Player.
        private void PublishData()
        {
            //potentially add a startup parameter to switch between MQTT and UDP sending
            Socket sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            IPAddress sendToAddress = IPAddress.Parse(clientAddress);
            IPEndPoint sendingEndPoint = new IPEndPoint(sendToAddress, clientPort);
            sendingSocket.SendTo(receivedData, sendingEndPoint);
        }
        #endregion
    }
}
