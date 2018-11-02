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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Class containing the GUI functions. </summary>
    ///
    /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
    class MainWindowViewModel : BindableBase
    {
        #region Instance declaration

        UdpManager udpmanager = new UdpManager();
        SetLHDescriptions setlhdes = new SetLHDescriptions();

        #endregion

        #region Variables

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method for getting and setting the TextReceived variable. </summary>
        ///
        /// <value> The text received. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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
        private string textReceived = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method for getting and setting the ButtonText variable. </summary>
        ///
        /// <value> The button text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }
        private string buttonText = "Start Recording";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method for getting and setting the ButtonColor variable. </summary>
        ///
        /// <value> The color of the button. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Brush ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                OnPropertyChanged("ButtonColor");
            }
        }
        private Brush buttonColor = new SolidColorBrush(Colors.White);

        #endregion

        #region Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method to check for the stop recording event coming from the Learning Hub. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="sender">   Learning Hub (object) raising the event. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MyConnector_stopRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => {
                    this.StartRecordingData();
                }));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Method to check for the start recording event coming from the Learning Hub.
        /// </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="sender">   Learning Hub (object) raising the event. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MyConnector_startRecordingEvent(object sender)
        {
            Application.Current.Dispatcher.BeginInvoke(
                 DispatcherPriority.Background,
                 new Action(() => {
                     this.StartRecordingData();
                 }));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by MainWindow for closing events. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="sender">   Learning Hub (object) raising the event. </param>
        /// <param name="e">        Cancel event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            udpmanager.UDPServerStop();
            CloseApp();
            Environment.Exit(Environment.ExitCode);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method to update the GUI textbox. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ///
        /// <param name="sender">   MqttManager raising the event&lt; </param>
        /// <param name="e">        Parameter containing the filtered Json string data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void IUpdateTextBox(object sender, TextReceivedEventArgs e)
        {
            TextReceived = e.TextReceived;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method to execute button functionality. </summary>
        ///
        /// <value> The on button clicked. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ICommand OnButtonClicked
        {
            get
            {
                buttonClicked = new RelayCommand(
                    param => this.StartRecordingData(), null
                    );
                return buttonClicked;
            }
        }
        private ICommand buttonClicked;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Method to set GUI look based on IsRecording variable. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 26-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void StartRecordingData()
        {
            if (Globals.IsRecordingUdp)
            {
                Globals.IsRecordingUdp = false;
                ButtonText = "Start Recording";
                ButtonColor = new SolidColorBrush(Colors.White);
                udpmanager.UDPServerStop();
            }
            else
            {
                Globals.IsRecordingUdp = true;
                ButtonText = "Stop Recording";
                ButtonColor = new SolidColorBrush(Colors.Green);
                udpmanager.UDPServerStart();
            }
        }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   MainWindowViewModel constructor . </summary>
        ///
        /// <remarks>   Jordi Hutjens, 30-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainWindowViewModel()
        {
            udpmanager.NewUdpTextReceived += IUpdateTextBox;
            HubConnector.StartConnection();
            HubConnector.MyConnector.startRecordingEvent += MyConnector_startRecordingEvent;
            HubConnector.MyConnector.stopRecordingEvent += MyConnector_stopRecordingEvent;
            setlhdes.SetDescriptions();
            Application.Current.MainWindow.Closing += MainWindow_Closing;
        }
        #endregion

        #region Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Closes the application. </summary>
        ///
        /// <remarks>   Jordi Hutjens, 30-10-2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CloseApp()
        {
            try
            {
                Process[] UdpDataProviderProcess = Process.GetProcessesByName("UDPDataProvider");
                UdpDataProviderProcess[0].CloseMainWindow();
                Process[] mosquittoBrokerProcess = Process.GetProcessesByName("mosquitto");
                mosquittoBrokerProcess[0].CloseMainWindow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}