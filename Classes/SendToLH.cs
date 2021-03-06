﻿using UDPDataProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UDPDataProvider.Classes.UdpManager;

namespace UDPDataProvider.Classes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Class containing the function to send to Learning Hub. </summary>
    ///
    /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class SendToLH
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the published sensor data to the Learning Hub. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="e">    Parameter containing the filtered Json string data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SendDataToLH(TextReceivedEventArgs e)
        {
            var values = new List<string>
                    {
                    e.ESPTimeStamp,
                    e.IMU1_AccX,
                    e.IMU1_AccY,
                    e.IMU1_AccZ,
                    e.IMU1_GyroX,
                    e.IMU1_GyroY,
                    e.IMU1_GyroZ,
                    e.IMU1_MagX,
                    e.IMU1_MagY,
                    e.IMU1_MagZ,
                    e.IMU1_Q0,
                    e.IMU1_Q1,
                    e.IMU1_Q2,
                    e.IMU1_Q3,
                    e.IMU2_AccX,
                    e.IMU2_AccY,
                    e.IMU2_AccZ,
                    e.IMU2_GyroX,
                    e.IMU2_GyroY,
                    e.IMU2_GyroZ,
                    e.IMU2_MagX,
                    e.IMU2_MagY,
                    e.IMU2_MagZ,
                    e.IMU2_Q0,
                    e.IMU2_Q1,
                    e.IMU2_Q2,
                    e.IMU2_Q3,
                    e.TempExternal,
                    e.HumExternal,
                    e.TempInternal,
                    e.HumInternal,
                    e.Pulse,
                    e.GSR
                };
            HubConnector.SendData(values);
        }
    }
}


