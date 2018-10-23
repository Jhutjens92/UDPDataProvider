using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace UDPDataProvider.ViewModel
{
    public static class Globals
    {

        public static bool IsRecordingUdp
        {
            get { return isRecordingUdp; }
            set
            {
                isRecordingUdp = value;
            }
        }
        private static bool isRecordingUdp = false;

        public static bool JsonErrorMessage
        {
            get { return jsonErrorMessage; }
            set
            {
                jsonErrorMessage = value;
            }
        }
        private static bool jsonErrorMessage = false;
    }
}