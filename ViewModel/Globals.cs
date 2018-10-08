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

        private static bool _JSONErrorMessage = false;
        public static bool JSONErrorMessage
        {
            get { return _JSONErrorMessage; }
            set
            {
                _JSONErrorMessage = value;
            }
        }
    }
}