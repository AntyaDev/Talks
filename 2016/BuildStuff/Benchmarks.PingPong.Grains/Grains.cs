using System.Threading.Tasks;
using Orleans;
using Contracts;

namespace Grains
{
    public class Destination : Grain, IDestinationGrain
    {
        public Task Ping(IClientGrain @from, Message message)
        {
            from.Pong(this, message).Ignore();
            return TaskDone.Done;
        }
    }

    public class Client : Grain, IClientGrain
    {
        static readonly Message msg = new Message();

        IDestinationGrain actor;
        ObserverSubscriptionManager<IClientObserver> subscribers;

        long pings;
        long pongs;
        long repeats;

        public override Task OnActivateAsync()
        {
            subscribers = new ObserverSubscriptionManager<IClientObserver>();
            return base.OnActivateAsync();
        }

        public Task Initialize(IDestinationGrain actor, long repeats)
        {
            this.actor = actor;
            this.repeats = repeats;

            return TaskDone.Done;
        }

        public Task Run()
        {
            actor.Ping(this, msg).Ignore();
            pings++;

            return TaskDone.Done;
        }

        public Task Pong(IDestinationGrain @from, Message message)
        {
            pongs++;

            if (pings < repeats)
            {
                actor.Ping(this, msg);
                pings++;
            }
            else if (pongs >= repeats)
            {
                subscribers.Notify(x => x.Done(pings, pongs));
            }
            return TaskDone.Done;
        }

        public Task Subscribe(IClientObserver subscriber)
        {
            subscribers.Subscribe(subscriber);
            return TaskDone.Done;
        }
    }
}
