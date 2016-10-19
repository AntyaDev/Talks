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

            _state.AssignUser(userId);

            this.RegisterTimer(SendMetricsToLocation, _state, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));

            return base.OnActivateAsync();
        }

        public Task UpdateRunnerState(RunnerState message)
        {
            _state.UpdateRunnerState(message);
            return TaskDone.Done;
        }

        public Task UpdateMetrics(Metrics message)
        {
            _state.UpdateMetrics(message);
            return TaskDone.Done;
        }

        public Task UpdateBattery(BatteryCapacity message)
        {
            _state.UpdateBattery(message);
            return TaskDone.Done;
        }

        Task SendMetricsToLocation(object s)
        {
            var state = (DeviceState)s;

            var userInfo = state.GetUserInfo();

            var stream = this.GetStreamProvider("sms")
                             .GetStream<UserInfo>(Streams.Location, state.LocationName);

            stream.OnNextAsync(userInfo);
            return TaskDone.Done;
        }
    }

    class DeviceState
    {
        public string UserName { get; private set; } = string.Empty;
        public RunnerState RunnerState { get; private set; } = RunnerState.Stopped;
        public string LocationName { get; private set; }
        public double Lat { get; private set; }
        public double Long { get; private set; }
        public uint StepsCount { get; private set; }
        public float Distance { get; private set; }
        public DateTime Duration { get; private set; }
        public BatteryCapacity BatteryCapacity { get; private set; }

        public void AssignUser(string userName)
        {
            UserName = userName;
        }

        public void UpdateLocationName(string locationName)
        {
            LocationName = locationName;
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
            throw new NotImplementedException();
        }
    }
}
