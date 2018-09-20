using System;
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
        private string _imu1_AccX = "";
        public String imu1_AccX
        {
            get { return _imu1_AccX; }
            set
            {
                _imu1_AccX = value;
                OnPropertyChanged("imu1_AccX");
            }
        }

        private string _imu1_AccY= "";
        public String imu1_AccY
        {
            get { return _imu1_AccY; }
            set
            {
                _imu1_AccY = value;
                OnPropertyChanged("imu1_AccY");
            }
        }

        private string _imu1_AccZ= "";
        public String imu1_AccZ
        {
            get { return _imu1_AccZ; }
            set
            {
                _imu1_AccZ = value;
                OnPropertyChanged("imu1_AccZ");
            }
        }

        private string _imu1_GyroX = "";
        public String imu1_GyroX
        {
            get { return _imu1_GyroX; }
            set
            {
                _imu1_GyroX = value;
                OnPropertyChanged("imu1_GyroX");
            }
        }

        private string _imu1_GyroY= "";
        public String imu1_GyroY
        {
            get { return _imu1_GyroY; }
            set
            {
                _imu1_GyroY = value;
                OnPropertyChanged("imu1_GyroY");
            }
        }

        private string _imu1_GyroZ= "";
        public String imu1_GyroZ
        {
            get { return _imu1_GyroZ; }
            set
            {
                _imu1_GyroZ = value;
                OnPropertyChanged("imu1_GyroZ");
            }
        }

        private string _imu1_MagX= "";
        public String imu1_MagX
        {
            get { return _imu1_MagX; }
            set
            {
                _imu1_MagX = value;
                OnPropertyChanged("imu1_MagX");
            }
        }

        private string _imu1_MagY= "";
        public String imu1_MagY
        {
            get { return _imu1_MagY; }
            set
            {
                _imu1_MagY = value;
                OnPropertyChanged("imu1_MagY");
            }
        }

        private string _imu1_MagZ= "";
        public String imu1_MagZ
        {
            get { return _imu1_MagZ; }
            set
            {
                _imu1_MagZ = value;
                OnPropertyChanged("imu1_MagZ");
            }
        }

        private string _imu2_AccX = "";
        public String imu2_AccX
        {
            get { return _imu2_AccX; }
            set
            {
                _imu2_AccX = value;
                OnPropertyChanged("imu2_AccX");
            }
        }

        private string _imu2_AccY = "";
        public String imu2_AccY
        {
            get { return _imu2_AccY; }
            set
            {
                _imu2_AccY = value;
                OnPropertyChanged("imu2_AccY");
            }
        }

        private string _imu2_AccZ = "";
        public String imu2_AccZ
        {
            get { return _imu2_AccZ; }
            set
            {
                _imu2_AccZ = value;
                OnPropertyChanged("imu2_AccZ");
            }
        }

        private string _imu2_GyroX = "";
        public String imu2_GyroX
        {
            get { return _imu2_GyroX; }
            set
            {
                _imu2_GyroX = value;
                OnPropertyChanged("imu2_GyroX");
            }
        }

        private string _imu2_GyroY = "";
        public String imu2_GyroY
        {
            get { return _imu2_GyroY; }
            set
            {
                _imu2_GyroY = value;
                OnPropertyChanged("imu2_GyroY");
            }
        }

        private string _imu2_GyroZ = "";
        public String imu2_GyroZ
        {
            get { return _imu2_GyroZ; }
            set
            {
                _imu2_GyroZ = value;
                OnPropertyChanged("imu2_GyroZ");
            }
        }

        private string _imu2_MagX = "";
        public String imu2_MagX
        {
            get { return _imu2_MagX; }
            set
            {
                _imu2_MagX = value;
                OnPropertyChanged("imu2_MagX");
            }
        }

        private string _imu2_MagY = "";
        public String imu2_MagY
        {
            get { return _imu2_MagY; }
            set
            {
                _imu2_MagY = value;
                OnPropertyChanged("imu2_MagY");
            }
        }

        private string _imu2_MagZ = "";
        public String imu2_MagZ
        {
            get { return _imu2_MagZ; }
            set
            {
                _imu2_MagZ = value;
                OnPropertyChanged("imu2_MagZ");
            }
        }

        private string _temp_External= "";
        public String temp_External
        {
            get { return _temp_External; }
            set
            {
                _temp_External = value;
                OnPropertyChanged("temp_External");
            }
        }

        private string _humidity_External= "";
        public String humidity_External
        {
            get { return _humidity_External; }
            set
            {
                _humidity_External = value;
                OnPropertyChanged("humidity_External");
            }
        }

        private string _temp_Internal= "";
        public String temp_Internal
        {
            get { return _temp_Internal; }
            set
            {
                _temp_Internal = value;
                OnPropertyChanged("temp_Internal");
            }
        }

        private string _humidity_Internal= "";
        public String humidity_Internal
        {
            get { return _humidity_Internal; }
            set
            {
                _humidity_Internal = value;
                OnPropertyChanged("humidity_Internal");
            }
        }

        private string _pulse_TempLobe= "";
        public String pulse_TempLobe
        {
            get { return _pulse_TempLobe; }
            set
            {
                _pulse_TempLobe = value;
                OnPropertyChanged("pulse_TempLobe");
            }
        }

        private string _gsr = ""; 
        public String gsr
        {
            get { return _gsr; }
            set
            {
                _gsr = value;
                OnPropertyChanged("gsr");
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
            udpmanager.newUDPTextReceived += OnNewMqttReceived;
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

        private void OnNewMqttReceived(object sender, TextReceivedEventArgs e)
        {
            TextReceived = e.TextReceived;
        }

        #region events
        private ICommand _buttonClicked;

        public ICommand OnButtonClicked
        {
            get 
                {
                _buttonClicked = new RelayCommand(
                    param => this.ExecuteNeededFunctions(), null
                    );
                return _buttonClicked;
            }
        }

        public void ExecuteNeededFunctions()
        {
            StartRecordingData();
            udpmanager.UDPServerStart();

        }

        public void StartRecordingData()
        {
            if (Globals.IsRecordingUDP == false)
            {
                Globals.IsRecordingUDP = true;
                ButtonText = "Stop Recording";
                ButtonColor = new SolidColorBrush(Colors.Green);

            }
            else if (Globals.IsRecordingUDP == true)
            {
                Globals.IsRecordingUDP = false;
                ButtonText = "Start Recording";
                ButtonColor = new SolidColorBrush(Colors.White);
            }
                
        }
        #endregion

        #region LearningHubMethods
        public void SetValueNames()
        {
            var names = new List<string>();
            names.Add("imu1_AccX");
            names.Add("imu1_AccY");
            names.Add("imu1_AccZ");
            names.Add("imu1_GyroX");
            names.Add("imu1_GyroY");
            names.Add("imu1_GyroZ");
            names.Add("imu1_MagX");
            names.Add("imu1_MagY");
            names.Add("imu1_MagZ");
            names.Add("imu2_AccX");
            names.Add("imu2_AccY");
            names.Add("imu2_AccZ");
            names.Add("imu2_GyroX");
            names.Add("imu2_GyroY");
            names.Add("imu2_GyroZ");
            names.Add("imu2_MagX");
            names.Add("imu2_MagY");
            names.Add("imu2_MagZ");
            names.Add("Temp_Ext");
            names.Add("Humidity_Ext");
            names.Add("Temp_Int");
            names.Add("Humidity_Int");
            names.Add("Pulse_TempLobe");
            names.Add("GSR");
            HubConnector.SetValuesName(names);

        }

        public void SendData()
        {
            try
            {
                var values = new List<string>();
                values.Add(imu1_AccX);
                values.Add(imu1_AccY);
                values.Add(imu1_AccZ);
                values.Add(imu1_GyroX);
                values.Add(imu1_GyroY);
                values.Add(imu1_GyroZ);
                values.Add(imu1_MagX);
                values.Add(imu1_MagY);
                values.Add(imu1_MagZ);
                values.Add(imu2_AccX);
                values.Add(imu2_AccY);
                values.Add(imu2_AccZ);
                values.Add(imu2_GyroX);
                values.Add(imu2_GyroY);
                values.Add(imu2_GyroZ);
                values.Add(imu2_MagX);
                values.Add(imu2_MagY);
                values.Add(imu2_MagZ);
                values.Add(temp_External);
                values.Add(humidity_External);
                values.Add(temp_Internal);
                values.Add(humidity_Internal);
                values.Add(pulse_TempLobe);
                values.Add(gsr);
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
