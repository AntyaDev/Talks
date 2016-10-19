using System;
using System.Threading.Tasks;
using Orleans;

namespace IoT.Contracts
{
    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task UpdateRunnerState(RunnerState message);
        Task UpdateMetrics(Metrics message);
        Task UpdateBattery(BatteryCapacity message);
    }

    public static class Streams
    {
        public static Guid Location = Guid.Parse("b6330bd6-df3e-45f8-a86d-a47e72a2fbf4");
    }
}
