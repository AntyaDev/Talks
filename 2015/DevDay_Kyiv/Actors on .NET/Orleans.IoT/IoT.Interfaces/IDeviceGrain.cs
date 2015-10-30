using System.Threading.Tasks;
using Orleans;

namespace IoT.Interfaces
{
    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task JoinSystem(string name);
        Task SetTemperature(double value);
        Task<double> GetTemperature();
    }

    public interface ISystemGrain : IGrainWithStringKey
    {
        Task SetTemperature(double value, string deviceId);
    }
}
