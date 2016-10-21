using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IoT.Contracts;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Streams;

namespace IoT.ChallengeClient
{
    class Program
    {
        private static StreamSubscriptionHandle<RunnerMetrics> Subscription;

        static void Main(string[] args)
        {
            Console.WriteLine("IoT.ChallengeClient client v 1.0");
            Console.WriteLine("IoT.ChallengeClient is connecting to Orleans cluster....");

            var config = ClientConfiguration.LoadFromFile("OrleansClient.config");
            GrainClient.Initialize(config);

            Console.WriteLine("IoT.ChallengeClient is successfully connected");

            Console.WriteLine("Please enter Challenge...");
            var locationName = Console.ReadLine();

            StartListening(locationName);

            Console.ReadLine();
        }

        static async void StartListening(string locationName)
        {
            var stream = GrainClient.GetStreamProvider("sms")
                                    .GetStream<RunnerMetrics>(Streams.Challenge, locationName);

            Subscription = await stream.SubscribeAsync(new LocationObserver());
        }
    }

    class LocationObserver : IAsyncObserver<RunnerMetrics>
    {
        readonly Dictionary<string, RunnerMetrics> _users = new Dictionary<string, RunnerMetrics>();

        public Task OnNextAsync(RunnerMetrics item, StreamSequenceToken token = null)
        {
            UpdateUsers(_users, item);
            PrintUsers(_users);
            return TaskDone.Done;
        }

        public Task OnCompletedAsync()
        {
            return TaskDone.Done;
        }

        public Task OnErrorAsync(Exception ex)
        {
            Console.WriteLine(ex);
            return TaskDone.Done;
        }

        void UpdateUsers(Dictionary<string, RunnerMetrics> users, RunnerMetrics runner)
        {
            if (users.ContainsKey(runner.RunnerName))
                users[runner.RunnerName] = runner;
            else
                users.Add(runner.RunnerName, runner);
        }

        void PrintUsers(Dictionary<string, RunnerMetrics> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Runner: {user.Value.RunnerName}, State: {user.Value.RunnerState}, Steps: {user.Value.StepsCount}");
            }
        }
    }
}
