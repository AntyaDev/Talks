using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OOP
{
    interface IBlogReader
    {
        void Notification(string data);
    }

    class BlogReader : IBlogReader
    {
        readonly string _readerName;

        public BlogReader(string readerName)
        {
            _readerName = readerName;
        }

        public void Notification(string data)
        {
            Console.WriteLine("{0}: {1}", _readerName, data);
        }
    }

    class BlogWriter
    {
        readonly List<IBlogReader> _readers = new List<IBlogReader>();

        public void AddReader(IBlogReader reader)
        {
            _readers.Add(reader);
        }

        public void NotifyReaders(string notification)
        {
            foreach (var reader in _readers)
            {
                reader.Notification(notification);
            }
        }
    }

    class ObserverDemo
    {
        public void Demo()
        {
            var reader1 = new BlogReader("John Skeet");
            var reader2 = new BlogReader("Tomas Petricek");
            var reader3 = new BlogReader("Greg Young");

            var writer = new BlogWriter();
            writer.AddReader(reader1);
            writer.AddReader(reader2);
            writer.AddReader(reader3);

            writer.NotifyReaders("F# is cool!!!");
        }
    }
}
