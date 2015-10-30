using System.Threading.Tasks;
using Orleans;

namespace IoT.Interfaces
{
    public interface IDeviceGrain : IGrainWithStringKey
    {
        Task SetTemperature(double value);

        Task<double> GetTemperature();
    }
}
