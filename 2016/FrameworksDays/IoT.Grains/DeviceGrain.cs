using System;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;
using Serilog;

namespace IoT.Grains
{
    public class DeviceGrain : Grain, IDeviceGrain
    {
        readonly ILogger _logger = Log.ForContext<DeviceGrain>();
        readonly DeviceState _state = new DeviceState();

        public override Task OnActivateAsync()
        {
            var deviceId = this.GetPrimaryKeyString();
            _state.SetDeviceId(deviceId);

            this.RegisterTimer(SendRunnerMetricsToChallenge, _state, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));

            _logger.Debug("{@DeviceId} activated.", deviceId);

            return base.OnActivateAsync();
        }

        public Task<bool> SetRunnerName(string runnerName)
        {
            _state.SetRunnerName(this.GetPrimaryKeyString());

            _logger.Debug("{@DeviceId} set {@RunnerName}.", _state.Id, runnerName);
            return Task.FromResult(true);
        }

        public Task<bool> SetChallengeName(string challengeName)
        {
            _state.SetChallengeName(challengeName);

            _logger.Debug("{@DeviceId} set {@ChallengeName}.", _state.Id, challengeName);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateRunnerState(RunnerState runnerState)
        {
            _state.UpdateRunnerState(runnerState);

            _logger.Debug("{@DeviceId} updated {@RunnerState}.", _state.Id, runnerState);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateSteps(Step step)
        {
            _state.UpdateSteps(step);

            _logger.Debug("{@DeviceId} updated {@Step}.", _state.Id, step);
            return Task.FromResult(true);
        }

        Task SendRunnerMetricsToChallenge(object s)
        {
            var metrics = _state.GetRunnerMetrics();

            var stream = this.GetStreamProvider("sms")
                             .GetStream<RunnerMetrics>(Streams.Challenge, _state.ChallengeName);

            stream.OnNextAsync(metrics);
            _logger.Debug("{@DeviceId} sent {@Metrics}.", _state.Id, metrics);
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
