using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime.Configuration;

namespace IoT.DeviceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IoT client v 1.0");
            Console.WriteLine("IoT client is connecting to Orleans cluster....");

            var config = ClientConfiguration.LoadFromFile("OrleansClient.config");
            GrainClient.Initialize(config);

            Console.WriteLine("IoT client is successfully connected");
            
            Console.WriteLine("Please enter your User Name...");
            var userName = Console.ReadLine();

            Console.WriteLine("Please enter Location Name...");
            var locationName = Console.ReadLine();
        }
    }
}
