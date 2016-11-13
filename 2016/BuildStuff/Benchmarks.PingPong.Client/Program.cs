using System;
using Orleans;
using Server;
using Orleans.Runtime.Configuration;

namespace Client
{
    class Program
    {
        static Benchmark benchmark;

        static void Main()
        {
            Console.WriteLine("Make sure that local silo is started. Press Enter to proceed ...");
            Console.ReadLine();

            Console.Write("Enter number of clients: ");
            var numberOfClients = int.Parse(Console.ReadLine() ?? Environment.ProcessorCount.ToString("D"));

            Console.Write("Enter number of repeated pings per client (thousands): ");
            var numberOfRepeatsPerClient = int.Parse(Console.ReadLine() ?? "15");

            var config = ClientConfiguration.LocalhostSilo();
            GrainClient.Initialize(config);

            benchmark = new Benchmark(numberOfClients, numberOfRepeatsPerClient * 1000);
            benchmark.Run();

            Console.ReadLine();
        }
    }
}
