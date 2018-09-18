namespace UDPDataProvider.ViewModel
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
    }
}
