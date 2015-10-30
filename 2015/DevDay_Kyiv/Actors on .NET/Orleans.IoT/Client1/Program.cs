using System;
using System.Threading.Tasks;
using IoT.Interfaces;
using Orleans;

namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            GrainClient.Initialize("DevTestClientConfiguration.xml");

            Run().Wait();

            Console.Read();
        }

        static async Task Run()
        {
            var device = GrainClient.GrainFactory.GetGrain<IDeviceGrain>("device_1");
            await device.SetTemperature(20);
            var currTemp = await device.GetTemperature();
        }
    }
}
