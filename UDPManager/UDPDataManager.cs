using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace UDPDataProvider.UDPManager
{
    class UDPDataManager
    {
        //string containing the UDP published message
        private string receivedMessage;             
        private const int udpServerPort = 5005;
        private const int udpVTTPlayerPort = 5006;
        UdpClient server = new UdpClient(udpServerPort);
        //string containing the IP address of the VTT Player
        string vttPlayerAddress = "127.0.0.1";
        byte[] received_Data;


        public event EventHandler<TextReceivedEventArgs> newUDPTextReceived;

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
            EventHandler<TextReceivedEventArgs> handler = newUDPTextReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public class TextReceivedEventArgs : EventArgs
        {
            public string TextReceived { get; set; }
        }


        private void UDPServerCallback(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, udpServerPort);
            received_Data = server.EndReceive(res, ref RemoteIpEndPoint);
            receivedMessage = Encoding.UTF8.GetString(received_Data);
            //Process codes
            TextReceivedEventArgs args = new TextReceivedEventArgs();
            args.TextReceived = receivedMessage;
            OnUDPReceived(args);
            Publish_Data();
            server.BeginReceive(new AsyncCallback(UDPServerCallback), null);
        }

        public void UDPServerStart()
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
        // this code runs when UDP data is received. It sends the unfiltered string directly to the VTT Player.
        private void Publish_Data()
        {
            Boolean exception_thrown = false;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(vttPlayerAddress);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, udpVTTPlayerPort);

            try
            {
                sending_socket.SendTo(received_Data, sending_end_point);
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
        } // end of main()
        #endregion
    }
}
