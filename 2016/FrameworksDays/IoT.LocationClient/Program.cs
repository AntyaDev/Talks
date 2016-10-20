using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Streams;

namespace IoT.LocationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IoT.LocationClient client v 1.0");
            Console.WriteLine("IoT.LocationClient is connecting to Orleans cluster....");

            var config = ClientConfiguration.LoadFromFile("OrleansClient.config");
            GrainClient.Initialize(config);

            Console.WriteLine("IoT.LocationClient is successfully connected");

            Console.WriteLine("Please enter Location...");
            var locationName = Console.ReadLine();

            StartListening(locationName);

            Console.ReadLine();
        }

        static async void StartListening(string locationName)
        {
            var stream = GrainClient.GetStreamProvider("sms")
                                    .GetStream<UserInfo>(Streams.Location, locationName);

            var subscription = await stream.SubscribeAsync(new LocationObserver());
        }
    }

    class LocationObserver : IAsyncObserver<UserInfo>
    {
        public Task OnNextAsync(UserInfo item, StreamSequenceToken token = null)
        {
            throw new NotImplementedException();
        }

        public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
