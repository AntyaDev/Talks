using System;

namespace DesignPatterns.OOP
{
    interface ICommand
    {
        string Name { get; }
        void Run();
    }
    
    class CmdOpen : ICommand
    {
        public string Name
        {
            get { return "Open"; }
        }

        public void Run()
        {
            Console.WriteLine("running Open command");
        }
    }

    class CmdClose : ICommand
    {
        public string Name
        {
            get { return "Close"; }
        }

        public void Run()
        {
            Console.WriteLine("running Close command");
        }
    }

    class CmdCreate : ICommand
    {
        public string Name
        {
            get { return "Create"; }
        }

        public void Run()
        {
            Console.WriteLine("running Create command");
        }
    }

    class CmdUpdate : ICommand
    {
        public string Name
        {
            get { return "Update"; }
        }

        public void Run()
        {
            Console.WriteLine("running Update command");
        }
    }

    class CmdRetrieve : ICommand
    {
        public string Name
        {
            get { return "Retrieve"; } 
        }

        public void Run()
        {
            Console.WriteLine("running Retrieve command");
        }
    }

    class CommandDemo
    {
        public void Demo()
        {
            var commands = new ICommand[]
            {
                new CmdCreate(), new CmdOpen(), new CmdClose(), new CmdRetrieve(), new CmdUpdate() 
            };

            foreach (var command in commands)
            {
                try
                {
                    command.Run();
                }
                catch (Exception ex)
                {
                    // todo: log message
                }
            }
        }
    }
}
