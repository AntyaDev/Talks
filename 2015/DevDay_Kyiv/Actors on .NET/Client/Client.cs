using Akka.Actor;
using Akka.Configuration;
using Messages;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
                akka {  
                    actor {
                        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    }
                    remote {
                        helios.tcp {
                            transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
		                    applied-adapters = []
		                    transport-protocol = tcp
		                    port = 0
		                    hostname = localhost
                        }
                    }
                }
            ");

            using (var system = ActorSystem.Create("MyClient", config))
            {
                var chatClient = system.ActorOf(Props.Create<ChatClientActor>());
                system.ActorSelection("akka.tcp://MyServer@localhost:8081/user/ChatServer");             

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input.StartsWith("/login"))
                    {
                        var name = input.Split(' ')[1];
                        chatClient.Tell(new ConnectRequest(name));                        
                    }
                    else if (input.StartsWith("/logout"))
                    {
                        chatClient.Tell(new Disconnect());                                          
                    }
                    else
                    {
                        chatClient.Tell(new Say(text: input));                        
                    }
                }
            }
        }
    }

    class ChatClientActor : ReceiveActor
    {
        string _userName = string.Empty;
        readonly ActorSelection _server = Context.ActorSelection("akka.tcp://MyServer@localhost:8081/user/ChatServer");

        public ChatClientActor()
        {
            Receive<ConnectRequest>(msg =>
            {
                _userName = msg.Username;
                _server.Tell(msg);
            });

            Receive<ConnectResponse>(msg => 
            {                
                Console.WriteLine(msg.Message);
            });

            Receive<Say>(msg =>
            {
                if (!string.IsNullOrEmpty(_userName))
                {
                    _server.Tell(new SayRequest(msg.Text, _userName));                    
                }
            });

            Receive<SayResponse>(msg =>
            {
                Console.WriteLine("{0}: {1}", msg.Username, msg.Text);
            });

            Receive<Disconnect>(msg =>
            {
                _server.Tell(msg);
            });
        }        
    }
}
