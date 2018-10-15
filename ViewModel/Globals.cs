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
        private static bool _isRecordingUdp = false;
        public static bool isRecordingUdp
        {
            get { return _isRecordingUdp; }
            set
            {
                _isRecordingUdp = value;
            }
        }

        private static bool _jsonErrorMessage = false;
        public static bool jsonErrorMessage
        {
            get { return _jsonErrorMessage; }
            set
            {
                _jsonErrorMessage = value;
            }
        }
    }
}