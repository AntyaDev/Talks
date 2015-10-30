using Akka.Actor;

namespace Messages
{
    public class ConnectRequest
    {
        public readonly string Username;

        public ConnectRequest(string username)
        {
            Username = username;
        }        
    }

    public class ConnectResponse
    {
        public readonly string Message;

        public ConnectResponse(string message)
        {
            Message = message;
        }
    }

    public class Say
    {
        public readonly string Text;

        public Say(string text)
        {
            Text = text;
        }
    }

    public class SayRequest
    {
        public readonly string Text;
        public readonly string Username;        

        public SayRequest(string text, string userName)
        {
            Text = text;
            Username = userName;
        }
    }   

    public class SayResponse
    {
        public readonly string Text;
        public readonly string Username;

        public SayResponse(string text, string userName)
        {
            Text = text;
            Username = userName;
        }
    }    

    public class Disconnect
    { }
}
