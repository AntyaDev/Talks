using System;

namespace IoT.Contracts
{
    [Serializable]
    public class Metrics
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public uint StepsCounter { get; set; }
        public uint Meters { get; set; }
        public DateTime Time { get; set; }
    }

    [Serializable]
    public class BatteryCapacity
    {
        public uint Capacity { get; set; }
        public DateTime Time { get; set; }
    }

    [Serializable]
    public class UserInfo
    {

    }

    [Serializable]
    public class Warning
    {
        public WarningType WarningType { get; set; }
        public string Text { get; set; }
    }

    [Serializable]
    public enum WarningType
    {
        
    }
}
