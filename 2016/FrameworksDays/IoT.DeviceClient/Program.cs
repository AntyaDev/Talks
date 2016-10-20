using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;
using Orleans.Runtime.Configuration;

namespace IoT.DeviceClient
{
    class Program
    {
        static Timer MetricsTimer;

        static void Main(string[] args)
        {
            Console.WriteLine("IoT.DeviceClient client v 1.0");
            Console.WriteLine("IoT.DeviceClient is connecting to Orleans cluster....");

            var config = ClientConfiguration.LoadFromFile("OrleansClient.config");
            GrainClient.Initialize(config);

            Console.WriteLine("IoT.DeviceClient is successfully connected");
            
            Console.WriteLine("Please enter your User Name...");
            var userName = Console.ReadLine();

            Console.WriteLine("Please enter Location...");
            var location = Console.ReadLine();

            StartRunning(userName, location);
            
            Console.ReadLine();
        }

        static async void StartRunning(string userName, string location)
        {
            Console.WriteLine("Start running...");

            var deviceGrain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(userName);
            await deviceGrain.SetLocation(location);
            await deviceGrain.UpdateRunnerState(RunnerState.Running);

            MetricsTimer = new Timer((s) =>
            {
                var metrics = new Metrics
                {

                };
                deviceGrain.UpdateMetrics(metrics);
            }, 
            null, TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(500));
        }
    }
}
