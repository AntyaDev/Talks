using System;

namespace IoT.Contracts
{
    [Serializable]
    public enum RunnerState
    {   
        Running,
        Paused,
        Finished
    }

    [Serializable]
    public class Step
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    [Serializable]
    public class RunnerMetrics
    {
        public string RunnerName { get; set; }
        public RunnerState RunnerState { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public uint StepsCount { get; set; }
    }
}
