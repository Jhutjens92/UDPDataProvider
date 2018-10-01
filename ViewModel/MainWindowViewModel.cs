﻿using System;
﻿using UDPDataProvider.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using UDPDataProvider.UDPManager;
using static UDPDataProvider.UDPManager.UDPDataManager;

namespace UDPDataProvider.ViewModel
{
    class MainWindowViewModel: BindableBase
    {
        UDPDataManager udpmanager = new UDPDataManager();

        #region Vars & Properties

        private string _ESP_TimeStamp = "";
        public String ESP_TimeStamp
        {
            get { return _ESP_TimeStamp; }
            set
            {
                _ESP_TimeStamp = value;
                OnPropertyChanged("ESP_TimeStamp");
            }
        }

        private string _IMU1_AccX = "";
        public String IMU1_AccX
        {
            get { return _IMU1_AccX; }
            set
            {
                _IMU1_AccX = value;
                OnPropertyChanged("IMU1_AccX");
            }
        }

        private string _IMU1_AccY = "";
        public String IMU1_AccY
        {
            get { return _IMU1_AccY; }
            set
            {
                _IMU1_AccY = value;
                OnPropertyChanged("IMU1_AccY");
            }
        }

        private string _IMU1_AccZ = "";
        public String IMU1_AccZ
        {
            get { return _IMU1_AccZ; }
            set
            {
                _IMU1_AccZ = value;
                OnPropertyChanged("IMU1_AccZ");
            }
        }

        private string _IMU1_GyroX = "";
        public String IMU1_GyroX
        {
            get { return _IMU1_GyroX; }
            set
            {
                _IMU1_GyroX = value;
                OnPropertyChanged("IMU1_GyroX");
            }
        }

        private string _IMU1_GyroY = "";
        public String IMU1_GyroY
        {
            get { return _IMU1_GyroY; }
            set
            {
                _IMU1_GyroY = value;
                OnPropertyChanged("IMU1_GyroY");
            }
        }

        private string _IMU1_GyroZ = "";
        public String IMU1_GyroZ
        {
            get { return _IMU1_GyroZ; }
            set
            {
                _IMU1_GyroZ = value;
                OnPropertyChanged("IMU1_GyroZ");
            }
        }

        private string _IMU1_MagX = "";
        public String IMU1_MagX
        {
            get { return _IMU1_MagX; }
            set
            {
                _IMU1_MagX = value;
                OnPropertyChanged("IMU1_MagX");
            }
        }

        private string _IMU1_MagY = "";
        public String IMU1_MagY
        {
            get { return _IMU1_MagY; }
            set
            {
                _IMU1_MagY = value;
                OnPropertyChanged("IMU1_MagY");
            }
        }

        private string _IMU1_MagZ = "";
        public String IMU1_MagZ
        {
            get { return _IMU1_MagZ; }
            set
            {
                _IMU1_MagZ = value;
                OnPropertyChanged("IMU1_MagZ");
            }
        }

        private string _IMU1_Q0 = "";
        public String IMU1_Q0
        {
            get { return _IMU1_Q0; }
            set
            {
                _IMU1_Q0 = value;
                OnPropertyChanged("IMU1_Q0");
            }
        }

        private string _IMU1_Q1 = "";
        public String IMU1_Q1
        {
            get { return _IMU1_Q1; }
            set
            {
                _IMU1_Q1 = value;
                OnPropertyChanged("IMU1_Q1");
            }
        }

        private string _IMU1_Q2 = "";
        public String IMU1_Q2
        {
            get { return _IMU1_Q2; }
            set
            {
                _IMU1_Q2 = value;
                OnPropertyChanged("IMU1_Q2");
            }
        }

        private string _IMU1_Q3 = "";
        public String IMU1_Q3
        {
            get { return _IMU1_Q3; }
            set
            {
                _IMU1_Q3 = value;
                OnPropertyChanged("IMU1_Q3");
            }
        }

        private string _IMU2_AccX = "";
        public String IMU2_AccX
        {
            get { return _IMU2_AccX; }
            set
            {
                _IMU2_AccX = value;
                OnPropertyChanged("IMU2_AccX");
            }
        }

        private string _IMU2_AccY = "";
        public String IMU2_AccY
        {
            get { return _IMU2_AccY; }
            set
            {
                _IMU2_AccY = value;
                OnPropertyChanged("IMU2_AccY");
            }
        }

        private string _IMU2_AccZ = "";
        public String IMU2_AccZ
        {
            get { return _IMU2_AccZ; }
            set
            {
                _IMU2_AccZ = value;
                OnPropertyChanged("IMU2_AccZ");
            }
        }

        private string _IMU2_GyroX = "";
        public String IMU2_GyroX
        {
            get { return _IMU2_GyroX; }
            set
            {
                _IMU2_GyroX = value;
                OnPropertyChanged("IMU2_GyroX");
            }
        }

        private string _IMU2_GyroY = "";
        public String IMU2_GyroY
        {
            get { return _IMU2_GyroY; }
            set
            {
                _IMU2_GyroY = value;
                OnPropertyChanged("IMU2_GyroY");
            }
        }

        private string _IMU2_GyroZ = "";
        public String IMU2_GyroZ
        {
            get { return _IMU2_GyroZ; }
            set
            {
                _IMU2_GyroZ = value;
                OnPropertyChanged("IMU2_GyroZ");
            }
        }

        private string _IMU2_MagX = "";
        public String IMU2_MagX
        {
            get { return _IMU2_MagX; }
            set
            {
                _IMU2_MagX = value;
                OnPropertyChanged("IMU2_MagX");
            }
        }

        private string _IMU2_MagY = "";
        public String IMU2_MagY
        {
            get { return _IMU2_MagY; }
            set
            {
                _IMU2_MagY = value;
                OnPropertyChanged("IMU2_MagY");
            }
        }

        private string _IMU2_MagZ = "";
        public String IMU2_MagZ
        {
            get { return _IMU2_MagZ; }
            set
            {
                _IMU2_MagZ = value;
                OnPropertyChanged("IMU2_MagZ");
            }
        }

        private string _IMU2_Q0 = "";
        public String IMU2_Q0
        {
            get { return _IMU2_Q0; }
            set
            {
                _IMU2_Q0 = value;
                OnPropertyChanged("IMU2_Q0");
            }
        }

        private string _IMU2_Q1 = "";
        public String IMU2_Q1
        {
            get { return _IMU2_Q1; }
            set
            {
                _IMU2_Q1 = value;
                OnPropertyChanged("IMU2_Q1");
            }
        }

        private string _IMU2_Q2 = "";
        public String IMU2_Q2
        {
            get { return _IMU2_Q2; }
            set
            {
                _IMU2_Q2 = value;
                OnPropertyChanged("IMU2_Q2");
            }
        }

        private string _IMU2_Q3 = "";
        public String IMU2_Q3
        {
            get { return _IMU2_Q3; }
            set
            {
                _IMU2_Q3 = value;
                OnPropertyChanged("IMU2_Q3");
            }
        }

        private string _Temp_External = "";
        public String Temp_External
        {
            get { return _Temp_External; }
            set
            {
                _Temp_External = value;
                OnPropertyChanged("Temp_External");
            }
        }

        private string _Humidity_External = "";
        public String Humidity_External
        {
            get { return _Humidity_External; }
            set
            {
                _Humidity_External = value;
                OnPropertyChanged("Humidity_External");
            }
        }

        private string _Temp_Internal = "";
        public String Temp_Internal
        {
            get { return _Temp_Internal; }
            set
            {
                _Temp_Internal = value;
                OnPropertyChanged("Temp_Internal");
            }
        }

        private string _Humidity_Internal = "";
        public String Humidity_Internal
        {
            get { return _Humidity_Internal; }
            set
            {
                _Humidity_Internal = value;
                OnPropertyChanged("Humidity_Internal");
            }
        }

        private string _Pulse_TempLobe = "";
        public String Pulse_TempLobe
        {
            get { return _Pulse_TempLobe; }
            set
            {
                _Pulse_TempLobe = value;
                OnPropertyChanged("Pulse_TempLobe");
            }
        }

        private string _GSR = "";
        public String GSR
        {
            get { return _GSR; }
            set
            {
                _GSR = value;
                OnPropertyChanged("GSR");
            }
        }

        private string _textReceived = "";
        public String TextReceived
        {
            get { return _textReceived; }
            set
            {
                _textReceived = value;
                OnPropertyChanged("TextReceived");

            }
        }

        private string _buttonText = "Start Recording";
        public String ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");

            }
        }

        private Brush _buttonColor = new SolidColorBrush(Colors.White);
        public Brush ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                OnPropertyChanged("ButtonColor");

            }
        }

        #endregion

        public MainWindowViewModel()
        {
            udpmanager.NewUDPTextReceived += NewUDPTextReceived;
            HubConnector.StartConnection();
            HubConnector.MyConnector.startRecordingEvent += MyConnector_startRecordingEvent;
            HubConnector.MyConnector.stopRecordingEvent += MyConnector_stopRecordingEvent;
            SetValueNames();
        }


        private void MyConnector_stopRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => {
                this.StartRecordingData();
            }));
        }

        private void MyConnector_startRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                 DispatcherPriority.Background,
                 new Action(() => {
                 this.StartRecordingData();
            }));
        }

        private void NewUDPTextReceived(object sender, TextReceivedEventArgs e)
        {
            TextReceived = e.TextReceived;
            IMU1_AccX = e.IMU1_AccX;
            IMU1_AccY = e.IMU1_AccY;
            IMU1_AccZ = e.IMU1_AccZ;
            IMU1_GyroX = e.IMU1_GyroX;
            IMU1_GyroY = e.IMU1_GyroY;
            IMU1_GyroZ = e.IMU1_GyroZ;
            IMU1_MagX = e.IMU1_MagX;
            IMU1_MagY = e.IMU1_MagY;
            IMU1_MagZ = e.IMU1_MagZ;
            IMU1_Q0 = e.IMU1_Q0;
            IMU1_Q1 = e.IMU1_Q1;
            IMU1_Q2 = e.IMU1_Q2;
            IMU1_Q3 = e.IMU1_Q3;
            IMU2_AccX = e.IMU2_AccX;
            IMU2_AccY = e.IMU2_AccY;
            IMU2_AccZ = e.IMU2_AccZ;
            IMU2_GyroX = e.IMU2_GyroX;
            IMU2_GyroY = e.IMU2_GyroY;
            IMU2_GyroZ = e.IMU2_GyroZ;
            IMU2_MagX = e.IMU2_MagX;
            IMU2_MagY = e.IMU2_MagY;
            IMU2_MagZ = e.IMU2_MagZ;
            IMU2_Q0 = e.IMU2_Q0;
            IMU2_Q1 = e.IMU2_Q1;
            IMU2_Q2 = e.IMU2_Q2;
            IMU2_Q3 = e.IMU2_Q3;
            Temp_External = e.Temp_Ext;
            Humidity_External = e.Humidity_Ext;
            Temp_Internal = e.Temp_Int;
            Humidity_Internal = e.Humidity_Int;
            Pulse_TempLobe = e.Pulse_TempLobe;
            GSR = e.GSR;
            SendData();
        }
        #region events
        private ICommand _buttonClicked;

        public ICommand OnButtonClicked
        {
            get 
                {
                _buttonClicked = new RelayCommand(
                    param => this.StartRecordingData(), null
                    );
                return _buttonClicked;
            }
        }

        public void StartRecordingData()
        {
            if (Globals.IsRecordingUDP == false)
            {
                Globals.IsRecordingUDP = true;
                ButtonText = "Stop Recording";
                ButtonColor = new SolidColorBrush(Colors.Green);
                udpmanager.UDPServerStart();

            }
            else if (Globals.IsRecordingUDP == true)
            {
                Globals.IsRecordingUDP = false;
                ButtonText = "Start Recording";
                ButtonColor = new SolidColorBrush(Colors.White);
                udpmanager.UDPServerStop();
            }
                
        }
        #endregion

        #region LearningHubMethods

        public void SetValueNames()
        {
            var names = new List<string>
            {
                "IMU1_AccX",
                "IMU1_AccY",
                "IMU1_AccZ",
                "IMU1_GyroX",
                "IMU1_GyroY",
                "IMU1_GyroZ",
                "IMU1_MagX",
                "IMU1_MagY",
                "IMU1_MagZ",
                "IMU1_Q0",
                "IMU1_Q1",
                "IMU1_Q2",
                "IMU1_Q3",
                "IMU2_AccX",
                "IMU2_AccY",
                "IMU2_AccZ",
                "IMU2_GyroX",
                "IMU2_GyroY",
                "IMU2_GyroZ",
                "IMU2_MagX",
                "IMU2_MagY",
                "IMU2_MagZ",
                "IMU2_Q0",
                "IMU2_Q1",
                "IMU2_Q2",
                "IMU2_Q3",
                "Temp_Ext",
                "Humidity_Ext",
                "Temp_Int",
                "Humidity_Int",
                "Pulse_TempLobe",
                "GSR"
            };
            HubConnector.SetValuesName(names);

        }

        public void SendData()
        {
            try
            {
                var values = new List<string>
                {
                    IMU1_AccX,
                    IMU1_AccY,
                    IMU1_AccZ,
                    IMU1_GyroX,
                    IMU1_GyroY,
                    IMU1_GyroZ,
                    IMU1_MagX,
                    IMU1_MagY,
                    IMU1_MagZ,
                    IMU1_Q0,
                    IMU1_Q1,
                    IMU1_Q2,
                    IMU1_Q3,
                    IMU2_AccX,
                    IMU2_AccY,
                    IMU2_AccZ,
                    IMU2_GyroX,
                    IMU2_GyroY,
                    IMU2_GyroZ,
                    IMU2_MagX,
                    IMU2_MagY,
                    IMU2_MagZ,
                    IMU2_Q0,
                    IMU2_Q1,
                    IMU2_Q2,
                    IMU2_Q3,
                    Temp_External,
                    Humidity_External,
                    Temp_Internal,
                    Humidity_Internal,
                    Pulse_TempLobe,
                    GSR
                };
                HubConnector.SendData(values);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        #endregion
    }
}
