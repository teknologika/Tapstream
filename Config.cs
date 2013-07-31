using System;

namespace TapstreamMetrics.Sdk
{
    public sealed class Config
    {

        // Deprecated, hardware-id field
        private string hardware = null;

        // Optional hardware identifiers that can be provided by the caller
        private string odin1 = null;

        // Set these to false if you do NOT want to collect this data.
        private bool collectDeviceUniqueId = true;

        // Set these if you want to override the names of the automatic events sent by the sdk
        private string installEventName = null;
        private string openEventName = null;

        // Unset these if you want to disable the sending of the automatic events
        private bool fireAutomaticInstallEvent = true;
        private bool fireAutomaticOpenEvent = true;

        // Properties for the private members above:
        public string Hardware
        {
            get { return hardware; }
            set { hardware = value; }
        }

        public string Odin1
        {
            get { return odin1; }
            set { odin1 = value; }
        }
    
#region iOS
        public string Udid { get; set; }
        public string Idfa { get; set; }
        public string SecureUdid { get; set;}
        public string OpenUdid { get; set;}
#endregion
       
        //TODO: ifdef for mac support
        //public string SerialNumber { get; set;}
      
        public bool CollectDeviceUniqueId
        {
            get { return collectDeviceUniqueId; }
            set { collectDeviceUniqueId = value; }
        }

        public string InstallEventName
        {
            get { return installEventName; }
            set { installEventName = value; }
        }
        public string OpenEventName
        {
            get { return openEventName; }
            set { openEventName = value; }
        }

        public bool FireAutomaticInstallEvent
        {
            get { return fireAutomaticInstallEvent; }
            set { fireAutomaticInstallEvent = value; }
        }

        public bool FireAutomaticOpenEvent
        {
            get { return fireAutomaticOpenEvent; }
            set { fireAutomaticOpenEvent = value; }
        }
    }
}

