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
            var userId = this.GetPrimaryKeyString();
            
            _state.SetUser(userId);

            this.RegisterTimer(SendMetricsToLocation, _state, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));

            return base.OnActivateAsync();
        }

        public Task<bool> SetLocation(string location)
        {
            _state.SetLocation(location);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateRunnerState(RunnerState message)
        {
            _state.UpdateRunnerState(message);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateMetrics(Metrics message)
        {
            _state.UpdateMetrics(message);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateBattery(BatteryCapacity message)
        {
            _state.UpdateBattery(message);
            return Task.FromResult(true);
        }

        Task SendMetricsToLocation(object s)
        {
            var state = (DeviceState)s;

            var userInfo = state.GetUserInfo();

            var stream = this.GetStreamProvider("sms")
                             .GetStream<UserInfo>(Streams.Location, state.Location);

            stream.OnNextAsync(userInfo);
            return TaskDone.Done;
        }
    }

    class DeviceState
    {
        public string UserName { get; private set; } = string.Empty;
        public RunnerState RunnerState { get; private set; } = RunnerState.Stopped;
        public string Location { get; private set; }
        public double Lat { get; private set; }
        public double Long { get; private set; }
        public uint StepsCount { get; private set; }
        public float Distance { get; private set; }
        public DateTime Duration { get; private set; }
        public BatteryCapacity BatteryCapacity { get; private set; }

        public void SetUser(string userName)
        {
            UserName = userName;
        }

        public void SetLocation(string location)
        {
            Location = location;
        }

        public void UpdateLocationName(string locationName)
        {
            Location = locationName;
        }

        public void UpdateMetrics(Metrics message)
        {
            Lat = message.Lat;
            Long = message.Long;
            StepsCount = StepsCount + message.StepsCount;
            Distance = Distance + message.Distance;
            Duration = message.Duration;
            BatteryCapacity = BatteryCapacity;
        }

        public void UpdateBattery(BatteryCapacity message)
        {   
            BatteryCapacity = message;
        }

        public void UpdateRunnerState(RunnerState message)
        {
            RunnerState = message;
        }

        public UserInfo GetUserInfo()
        {
            return new UserInfo
            {
                RunnerState = RunnerState,
                Duration = Duration,
                Distance = Distance,
                Lat = Lat,
                Long = Long,
                StepsCount = StepsCount,
                UserName = UserName
            };
        }
    }
}
