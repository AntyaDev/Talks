using System;

namespace IoT.Contracts
{
    [Serializable]
    public enum RunnerState
    {   
        Running,
        Paused,
        Stopped
    }

    [Serializable]
    public class Metrics
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public uint StepsCount { get; set; }
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }

    [Serializable]
    public class BatteryCapacity
    {
        public uint Capacity { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    [Serializable]
    public class UserInfo
    {
        public string UserName { get; set; }
        public RunnerState RunnerState { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public uint StepsCount { get; set; }
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
