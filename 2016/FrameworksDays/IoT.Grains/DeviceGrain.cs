using System;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;

namespace IoT.Grains
{
    public class DeviceGrain : Grain, IDeviceGrain
    {
        readonly DeviceState _state = new DeviceState();

        public Task StartRun(string locationName)
        {
            _state.UpdateLocationName(locationName);
            return TaskDone.Done;
        }

        public Task FinishRun()
        {
            throw new System.NotImplementedException();
        }

        public Task HandleMetrics(Metrics message)
        {
            _state.UpdateMetrics(message);
            return TaskDone.Done;
        }

        public Task HandleBattery(BatteryCapacity message)
        {
            _state.UpdateBattery(message);
            return TaskDone.Done;
        }
    }

    class DeviceState
    {
        public string LocationName { get; private set; }
        public double Lat { get; private set; }
        public double Long { get; private set; }
        public uint StepsCounter { get; private set; }
        public uint Meters { get; private set; }
        public DateTime Time { get; private set; }
        public BatteryCapacity BatteryCapacity { get; private set; }

        public void UpdateLocationName(string locationName)
        {
            LocationName = locationName;
        }

        public void UpdateMetrics(Metrics message)
        {
            Lat = message.Lat;
            Long = message.Long;
            StepsCounter = StepsCounter + message.StepsCounter;
            Meters = Meters + message.Meters;
            Time = message.Time;
            BatteryCapacity = BatteryCapacity;
        }

        public void UpdateBattery(BatteryCapacity message)
        {   
            BatteryCapacity = message;
        }
    }
}
