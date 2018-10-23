using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using UDPDataProvider.ViewModel;
using UDPDataProvider.Classes;

namespace UDPDataProvider.Classes
{
    class UdpManager
    {
        #region Instance declaration
        CheckParameters chkpar = new CheckParameters();
        UdpClient client;
        #endregion

        #region Variables
        // byte array containing the UDP published message
        private byte[] receivedByteMsg;
        // string containing the UDP published message
        private string receivedStrMsg;
        #endregion

        #region Events
        // handler for subscribing classes where you do +=
        public event EventHandler<TextReceivedEventArgs> NewUdpTextReceived;

        // this is for raising the event in the class
        protected virtual void OnNewTextReceived(TextReceivedEventArgs UpdateValuesEvent)
        {
            NewUdpTextReceived?.Invoke(this, UpdateValuesEvent);
        }

        //inherits from event args which holds all the values that needs to be passed as args in the event
        public class TextReceivedEventArgs : EventArgs
        {
            public string TextReceived
            {
                get
                {
                    return textReceived;
                }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    textReceived = value;
                }
            }
            private string textReceived;

            public string IMU1_AccX
            {
                get { return imu1_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_AccX = value;
                }
            }
            private string imu1_AccX = "";

            public string IMU1_AccY
            {
                get { return imu1_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_AccY = value;
                }
            }
            private string imu1_AccY = "";

            public string IMU1_AccZ
            {
                get { return imu1_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_AccZ = value;
                }
            }
            private string imu1_AccZ = "";

            public string IMU1_GyroX
            {
                get { return imu1_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_GyroX = value;
                }
            }
            private string imu1_GyroX = "";

            public string IMU1_GyroY
            {
                get { return imu1_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_GyroY = value;
                }
            }
            private string imu1_GyroY = "";

            public string IMU1_GyroZ
            {
                get { return imu1_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_GyroZ = value;
                }
            }
            private string imu1_GyroZ = "";

            public string IMU1_MagX
            {
                get { return imu1_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_MagX = value;
                }
            }
            private string imu1_MagX = "";


            public string IMU1_MagY
            {
                get { return imu1_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_MagY = value;
                }
            }
            private string imu1_MagY = "";

            public string IMU1_MagZ
            {
                get { return imu1_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_MagZ = value;
                }
            }
            private string imu1_MagZ = "";

            public string IMU1_Q0
            {
                get { return imu1_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_Q0 = value;
                }
            }
            private string imu1_Q0 = "";

            public string IMU1_Q1
            {
                get { return imu1_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_Q1 = value;
                }
            }
            private string imu1_Q1 = "";

            public string IMU1_Q2
            {
                get { return imu1_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_Q2 = value;
                }
            }
            private string imu1_Q2 = "";

            public string IMU1_Q3
            {
                get { return imu1_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu1_Q3 = value;
                }
            }
            private string imu1_Q3 = "";

            public string IMU2_AccX
            {
                get { return imu2_AccX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_AccX = value;
                }
            }
            private string imu2_AccX = "";

            public string IMU2_AccY
            {
                get { return imu2_AccY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_AccY = value;
                }
            }
            private string imu2_AccY = "";

            public string IMU2_AccZ
            {
                get { return imu2_AccZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_AccZ = value;
                }
            }
            private string imu2_AccZ = "";

            public string IMU2_GyroX
            {
                get { return imu2_GyroX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_GyroX = value;
                }
            }
            private string imu2_GyroX = "";

            public string IMU2_GyroY
            {
                get { return imu2_GyroY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_GyroY = value;
                }
            }
            private string imu2_GyroY = "";

            public string IMU2_GyroZ
            {
                get { return imu2_GyroZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_GyroZ = value;
                }
            }
            private string imu2_GyroZ = "";

            public string IMU2_MagX
            {
                get { return imu2_MagX; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_MagX = value;
                }
            }
            private string imu2_MagX = "";

            public string IMU2_MagY
            {
                get { return imu2_MagY; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_MagY = value;
                }
            }
            private string imu2_MagY = "";

            public string IMU2_MagZ
            {
                get { return imu2_MagZ; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_MagZ = value;
                }
            }
            private string imu2_MagZ = "";

            public string IMU2_Q0
            {
                get { return imu2_Q0; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_Q0 = value;
                }
            }
            private string imu2_Q0 = "";

            public string IMU2_Q1
            {
                get { return imu2_Q1; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_Q1 = value;
                }
            }
            private string imu2_Q1 = "";

            public string IMU2_Q2
            {
                get { return imu2_Q2; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_Q2 = value;
                }
            }
            private string imu2_Q2 = "";

            public string IMU2_Q3
            {
                get { return imu2_Q3; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    imu2_Q3 = value;
                }
            }
            private string imu2_Q3 = "";

            public string TempExternal
            {
                get { return tempExternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    tempExternal = value;
                }
            }
            private string tempExternal = "";

            public string HumExternal
            {
                get { return humExternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    humExternal = value;
                }
            }
            private string humExternal = "";

            public string TempInternal
            {
                get { return tempInternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    tempInternal = value;
                }
            }
            private string tempInternal = "";

            public string HumInternal
            {
                get { return humInternal; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    humInternal = value;
                }
            }
            private string humInternal = "";

            public string Pulse
            {
                get { return pulse; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    pulse = value;
                }
            }
            private string pulse = "";

            public string GSR
            {
                get { return gsr; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    gsr = value;
                }
            }
            private string gsr = "";

            public string ESPTimeStamp
            {
                get { return espTimeStamp; }
                set
                {
                    if (value == null)
                    {
                        value = 0.ToString();
                    }
                    espTimeStamp = value;
                }
            }
            private string espTimeStamp = "";
        }
        #endregion

        #region Methods
        // UDP Server callback
        private void UDPServerCallback(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, chkpar.ServerPort);
            receivedByteMsg = client.EndReceive(res, ref RemoteIpEndPoint);
            receivedStrMsg = Encoding.UTF8.GetString(receivedByteMsg);
            JsonParser.JSONParseReceivedMessage(receivedStrMsg);
            UpdateValues();
            PublishData();
            NewUDPServerCallBack();
        }

        // create new UDP server callback
        private void NewUDPServerCallBack()
        {
            client.BeginReceive(new AsyncCallback(UDPServerCallback), null);
        }

        // create new instance on var server
        private void CreateServer()
        {
            client = new UdpClient(chkpar.ServerPort);
        }

        // starts the UDP server when the start recording button is pressed
        public void UDPServerStart()
        {
            chkpar.CheckStartupParameters();
            CreateServer();
            if (Globals.IsRecordingUdp == true)
            {
                try
                {
                    client.BeginReceive(new AsyncCallback(UDPServerCallback), null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        // stops the UDP Server at the end of a recording
        public void UDPServerStop()
        {
            try
            {
                client.Close();
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
                    TextReceived = receivedStrMsg,
                    ESPTimeStamp = JsonParser.ParsedUdpMsg.time,
                    IMU1_AccX = JsonParser.ParsedUdpMsg.imus[0].ax,
                    IMU1_AccY = JsonParser.ParsedUdpMsg.imus[0].ay,
                    IMU1_AccZ = JsonParser.ParsedUdpMsg.imus[0].az,
                    IMU1_GyroX = JsonParser.ParsedUdpMsg.imus[0].gx,
                    IMU1_GyroY = JsonParser.ParsedUdpMsg.imus[0].gy,
                    IMU1_GyroZ = JsonParser.ParsedUdpMsg.imus[0].gz,
                    IMU1_MagX = JsonParser.ParsedUdpMsg.imus[0].mx,
                    IMU1_MagY = JsonParser.ParsedUdpMsg.imus[0].my,
                    IMU1_MagZ = JsonParser.ParsedUdpMsg.imus[0].mz,
                    IMU1_Q0 = JsonParser.ParsedUdpMsg.imus[0].q0,
                    IMU1_Q1 = JsonParser.ParsedUdpMsg.imus[0].q1,
                    IMU1_Q2 = JsonParser.ParsedUdpMsg.imus[0].q2,
                    IMU1_Q3 = JsonParser.ParsedUdpMsg.imus[0].q3,
                    IMU2_AccX = JsonParser.ParsedUdpMsg.imus[1].ax,
                    IMU2_AccY = JsonParser.ParsedUdpMsg.imus[1].ay,
                    IMU2_AccZ = JsonParser.ParsedUdpMsg.imus[1].az,
                    IMU2_GyroX = JsonParser.ParsedUdpMsg.imus[1].gx,
                    IMU2_GyroY = JsonParser.ParsedUdpMsg.imus[1].gy,
                    IMU2_GyroZ = JsonParser.ParsedUdpMsg.imus[1].gz,
                    IMU2_MagX = JsonParser.ParsedUdpMsg.imus[1].mx,
                    IMU2_MagY = JsonParser.ParsedUdpMsg.imus[1].my,
                    IMU2_MagZ = JsonParser.ParsedUdpMsg.imus[1].mz,
                    IMU2_Q0 = JsonParser.ParsedUdpMsg.imus[1].q0,
                    IMU2_Q1 = JsonParser.ParsedUdpMsg.imus[1].q1,
                    IMU2_Q2 = JsonParser.ParsedUdpMsg.imus[1].q2,
                    IMU2_Q3 = JsonParser.ParsedUdpMsg.imus[1].q3,
                    TempExternal = JsonParser.ParsedUdpMsg.shts[0].temp,
                    HumExternal = JsonParser.ParsedUdpMsg.shts[0].hum,
                    TempInternal = JsonParser.ParsedUdpMsg.shts[1].temp,
                    HumInternal = JsonParser.ParsedUdpMsg.shts[1].hum,
                    Pulse = JsonParser.ParsedUdpMsg.pulse,
                    GSR = JsonParser.ParsedUdpMsg.gsr
                };
                OnNewTextReceived(args);
                SendToLH.SendDataToLH(args);
            }
            catch (Exception)
            {
                TextReceivedEventArgs args = new TextReceivedEventArgs
                {
                    TextReceived = "Invalid JSON message at the UDP Receiver"
                };
                Globals.JsonErrorMessage = true;
                OnNewTextReceived(args);
            }
        }

        // this code runs when UDP data is received. It sends the unfiltered string directly to the client address.
        private void PublishData()
        {
            Socket sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            IPAddress sendToAddress = IPAddress.Parse(chkpar.ClientAddress);
            IPEndPoint sendingEndPoint = new IPEndPoint(sendToAddress, chkpar.ClientPort);
            sendingSocket.SendTo(receivedByteMsg, sendingEndPoint);
        }
        #endregion
    }
}
