using System;
using System.Threading.Tasks;
using Orleans;

namespace IoT.Contracts
{
    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task<bool> SetRunnerName(string runnerName);
        Task<bool> SetChallengeName(string challengeName);
        Task<bool> UpdateRunnerState(RunnerState message);
        Task<bool> UpdateSteps(Step message);
    }

    public static class Streams
    {
        public static Guid Challenge = Guid.Parse("b6330bd6-df3e-45f8-a86d-a47e72a2fbf4");
    }
}
