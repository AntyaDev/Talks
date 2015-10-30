using Akka.Actor;
using Akka.Configuration;
using Messages;
using System;
using System.Collections.Generic;

namespace Server
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
                            port = 8081
                            hostname = localhost
                        }
                    }
                }
            ");

            using (var system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf<ChatServerActor>("ChatServer");

                Console.ReadLine();
            }
        }
    }

    class ChatServerActor : ReceiveActor
    {
        private readonly HashSet<IActorRef> _clients = new HashSet<IActorRef>();

        public ChatServerActor()
        {
            Receive<ConnectRequest>(msg =>
            {   
                _clients.Add(Sender);
                Sender.Tell(new ConnectResponse("Hello and welcome to Akka .NET chat example"));
            });

            Receive<SayRequest>(msg => 
            {
                var response = new SayResponse(msg.Text, msg.Username);
                
                foreach (var client in _clients)
                {
                    client.Tell(response, this.Self);
                }
            });

            Receive<Disconnect>(msg =>
            {
                _clients.Remove(Sender);
            });         
        }        
    }
}
