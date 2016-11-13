using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Contracts
{    
	[Immutable]
    public class Message
    { }

    public interface IClientGrain : IGrainWithGuidKey
    {
        Task Run();
        Task Pong(IDestinationGrain from, Message message);
        Task Initialize(IDestinationGrain actor, long repeats);
        Task Subscribe(IClientObserver subscriber);
    }

    public interface IClientObserver : IGrainObserver
    {
        void Done(long pings, long pongs);
    }

    public interface IDestinationGrain : IGrainWithGuidKey
    {
        Task Ping(IClientGrain from, Message message);
    }
}
