using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace UDPDataProvider.ViewModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Class containing global variables. </summary>
    ///
    /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Globals
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method for setting IsRecordingUdp. </summary>
        ///
        /// <value> True if this object is recording mqtt, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsRecordingUdp
        {
            get { return isRecordingUdp; }
            set
            {
                isRecordingUdp = value;
            }
        }
        private static bool isRecordingUdp = false;
    }
}