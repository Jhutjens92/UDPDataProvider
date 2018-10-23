using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using UDPDataProvider.Classes;
using UDPDataProvider.Model;
using static UDPDataProvider.Classes.UdpManager;

namespace UDPDataProvider.ViewModel
{
    class MainWindowViewModel : BindableBase
    {
        #region Instance declaration
        UdpManager udpmanager = new UdpManager();
        #endregion

        #region Variables

        private string textReceived = "";
        public string TextReceived
        {
            get { return textReceived; }
            set
            {
                if (value == null)
                {
                    value = 0.ToString();
                }
                textReceived = value;
                OnPropertyChanged("TextReceived");
            }
        }

        private string buttonText = "Start Recording";
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }

        private Brush buttonColor = new SolidColorBrush(Colors.White);
        public Brush ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                OnPropertyChanged("ButtonColor");

            }
        }

        #endregion

        #region Events
        // stop recording event from the learning hub
        private void MyConnector_stopRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => {
                    this.StartRecordingData();
                }));
        }

        // start recording event from the learning hub
        private void MyConnector_startRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                 DispatcherPriority.Background,
                 new Action(() => {
                     this.StartRecordingData();
                 }));
        }

        // mainwindows closing event 
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseApp();
            Environment.Exit(Environment.ExitCode);
        }

        // update the interface textbox
        private void IUpdateTextBox(object sender, TextReceivedEventArgs e)
        {
            TextReceived = e.TextReceived;
        }

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
        // start recording (execute functions in classes) and change the appearance of the button
        public void StartRecordingData()
        {
            if (Globals.IsRecordingUdp == false)
            {
                Globals.IsRecordingUdp = true;
                ButtonText = "Stop Recording";
                ButtonColor = new SolidColorBrush(Colors.Green);
                udpmanager.UDPServerStart();

            }
            else if (Globals.IsRecordingUdp == true)
            {
                Globals.IsRecordingUdp = false;
                ButtonText = "Start Recording";
                ButtonColor = new SolidColorBrush(Colors.White);
                udpmanager.UDPServerStop();

            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            udpmanager.NewUdpTextReceived += IUpdateTextBox;
            HubConnector.StartConnection();
            HubConnector.MyConnector.startRecordingEvent += MyConnector_startRecordingEvent;
            HubConnector.MyConnector.stopRecordingEvent += MyConnector_stopRecordingEvent;
            SetLHDescriptions.SetDescriptions();
            Application.Current.MainWindow.Closing += MainWindow_Closing;
        }
        #endregion

        #region Methods
        // find the running process and close it down properly.
        public void CloseApp()
        {
            try
            {
                Process[] UdpDataProviderProcess = Process.GetProcessesByName("UDPDataProvider");
                UdpDataProviderProcess[0].CloseMainWindow();
            }
            catch (Exception e)
            {
                Console.WriteLine("I got an exception after closing App" + e);
            }
        }
        #endregion
    }
}