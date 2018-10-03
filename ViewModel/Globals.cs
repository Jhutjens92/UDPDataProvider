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

        private static bool _isRecordingDone = false;
        public static bool IsRecordingDone
        {
            get { return _isRecordingDone; }
            set
            {
                _isRecordingDone = value;
            }
        }
    }
}
