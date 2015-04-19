using System;

namespace DesignPatterns.OOP
{
    interface IStrategy
    {
        void Algorithm();
    }

    class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("ConcreteStrategy1");
        }
    }

    class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("ConcreteStrategy2");
        }
    }

    class Context
    {
        IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }

    class StartegyDemo
    {
        public void Demo()
        {
            var context = new Context(new ConcreteStrategy1());
            context.ExecuteOperation();

            context.SetStrategy(new ConcreteStrategy2());
            context.ExecuteOperation();
        }
    }
}
