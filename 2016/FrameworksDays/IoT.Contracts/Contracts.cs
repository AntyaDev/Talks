using System;
using System.Threading.Tasks;
using Orleans;

namespace IoT.Contracts
{
    public static class Streams
    {
        public static Guid Location = Guid.Parse("b6330bd6-df3e-45f8-a86d-a47e72a2fbf4");
    }

    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task UpdateRunnerState(RunnerState message);
        Task UpdateMetrics(Metrics message);
        Task UpdateBattery(BatteryCapacity message);
    }

    public interface IUserGrain : IGrainWithStringKey
    {
        Task<bool> AddNewDevice(string deviceId);
        Task HandleWarning(Warning message);
    }
}
