using System;
using System.Threading.Tasks;
using System.Timers;
using IoT.Contracts;
using Orleans;
using Orleans.Runtime.Configuration;

namespace IoT.DeviceClient
{
    class Program
    {
        static Timer _stepsEmitter;

        static void Main(string[] args)
        {
            Console.WriteLine("IoT.DeviceClient client v 1.0");
            Console.WriteLine("IoT.DeviceClient is connecting to Orleans cluster....");

            var config = ClientConfiguration.LoadFromFile("OrleansClient.config");
            GrainClient.Initialize(config);

            Console.WriteLine("IoT.DeviceClient is successfully connected");
            
            Console.WriteLine("Please enter your Name...");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter Device ID...");
            var deviceId = Console.ReadLine();

            Console.WriteLine("Please enter Challenge...");
            var challenge = Console.ReadLine();

            Task.Run(() => StartRunning(deviceId, name, challenge).Wait()).Wait();
            
            Console.ReadLine();
        }

        static async Task StartRunning(string deviceId, string runnerName, string challengeName)
        {
            Console.WriteLine("Enter command [run, pause, finish]...");

            var deviceGrain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(deviceId);
            await deviceGrain.SetRunnerName(runnerName);
            await deviceGrain.SetChallengeName(challengeName);

            var random = new Random();
            _stepsEmitter = new Timer(interval: 500);
            _stepsEmitter.Elapsed += async (sender, args) =>
            {
                var step = new Step
                {
                    Lat = random.NextDouble(),
                    Long = random.NextDouble(),
                    TimeStamp = DateTime.UtcNow
                };
                await deviceGrain.UpdateSteps(step);
            };

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "run")
                {
                    await deviceGrain.UpdateRunnerState(RunnerState.Running);
                    _stepsEmitter.Start();
                }
                if (command == "pause")
                {
                    await deviceGrain.UpdateRunnerState(RunnerState.Paused);
                    _stepsEmitter.Stop();
                }
                if (command == "finish")
                {
                    await deviceGrain.UpdateRunnerState(RunnerState.Finished);
                    _stepsEmitter.Stop();
                    break;
                }
            }
        }
    }
}
