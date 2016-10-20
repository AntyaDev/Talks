using System;
using System.Threading.Tasks;
using Orleans;

namespace IoT.Contracts
{
    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task<bool> SetLocation(string location);
        Task<bool> UpdateRunnerState(RunnerState message);
        Task<bool> UpdateMetrics(Metrics message);
        Task<bool> UpdateBattery(BatteryCapacity message);
    }

    public static class Streams
    {
        public static Guid Location = Guid.Parse("b6330bd6-df3e-45f8-a86d-a47e72a2fbf4");
    }
}
