using System;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;

namespace IoT.Grains
{
    public class DeviceGrain : Grain, IDeviceGrain
    {
        readonly DeviceState _state = new DeviceState();

        public override Task OnActivateAsync()
        {
            var deviceId = this.GetPrimaryKeyString();
            _state.SetDeviceId(deviceId);

            this.RegisterTimer(SendRunnerMetricsToChallenge, _state, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));

            return base.OnActivateAsync();
        }

        public Task<bool> SetRunnerName(string runnerName)
        {
            _state.SetRunnerName(this.GetPrimaryKeyString());
            return Task.FromResult(true);
        }

        public Task<bool> SetChallengeName(string challengeName)
        {
            _state.SetChallengeName(challengeName);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateRunnerState(RunnerState message)
        {
            _state.UpdateRunnerState(message);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateSteps(Step message)
        {
            _state.UpdateSteps(message);
            return Task.FromResult(true);
        }

        Task SendRunnerMetricsToChallenge(object s)
        {
            var metrics = _state.GetRunnerMetrics();

            var stream = this.GetStreamProvider("sms")
                             .GetStream<RunnerMetrics>(Streams.Challenge, _state.ChallengeName);

            stream.OnNextAsync(metrics);
            return TaskDone.Done;
        }
    }

    class DeviceState
    {
        public string Id { get; private set; }
        public string RunnerName { get; private set; } = string.Empty;
        public RunnerState RunnerState { get; private set; } = RunnerState.Finished;
        public string ChallengeName { get; private set; }
        public double Lat { get; private set; }
        public double Long { get; private set; }
        public uint StepsCount { get; private set; }

        public void SetDeviceId(string deviceId)
        {
            Id = deviceId;
        }

        public void SetRunnerName(string userName)
        {
            RunnerName = userName;
        }

        public void SetChallengeName(string challengeName)
        {
            ChallengeName = challengeName;
        }

        public void UpdateSteps(Step message)
        {
            Lat = message.Lat;
            Long = message.Long;
            StepsCount += 1;
        }

        public void UpdateRunnerState(RunnerState message)
        {
            RunnerState = message;
        }

        public RunnerMetrics GetRunnerMetrics()
        {
            return new RunnerMetrics
            {
                RunnerState = RunnerState,
                Lat = Lat,
                Long = Long,
                StepsCount = StepsCount,
                RunnerName = RunnerName
            };
        }
    }
}
