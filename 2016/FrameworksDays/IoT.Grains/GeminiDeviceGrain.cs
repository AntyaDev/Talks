using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;

namespace IoT.Grains
{
    public class GeminiDeviceGrain : Grain, IGeminiDeviceGrain
    {
        public Task StartRun(string locationName)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleMetrics(Metrics message)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleBattery(BatteryCapacity message)
        {
            throw new System.NotImplementedException();
        }
    }
}
