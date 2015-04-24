using System;

namespace DesignPatterns.OOP
{
    interface ISortStrategy
    {
        void Algorithm(int[] array);
    }

    class QuickSortStrategy : ISortStrategy
    {
        public void Algorithm(int[] array)
        {
            Console.WriteLine("QuickSortStrategy");
        }
    }

    class ShellSortStrategy : ISortStrategy
    {
        public void Algorithm(int[] array)
        {
            Console.WriteLine("ShellSortStrategy");
        }
    }

    class BubbleSortStrategy : ISortStrategy
    {
        public void Algorithm(int[] array)
        {
            Console.WriteLine("BubbleSortStrategy");
        }
    }    

    class Context
    {
        ISortStrategy _strategy;

        public Context(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation(int[] array)
        {
            _strategy.Algorithm(array);
        }
    }

    class StartegyDemo
    {
        public void Demo()
        {
            var array = new int[] { 1, 2, 3, 5, 10, -2 };
            var context = new Context(new QuickSortStrategy());
            context.ExecuteOperation(array);

            array = new int[] { 1, 2, 3, 5, 10, -2 };
            context.SetStrategy(new ShellSortStrategy());
            context.ExecuteOperation(array);

            array = new int[] { 1, 2, 3, 5, 10, -2 };
            context.SetStrategy(new BubbleSortStrategy());
            context.ExecuteOperation(array);
        }
    }
}
