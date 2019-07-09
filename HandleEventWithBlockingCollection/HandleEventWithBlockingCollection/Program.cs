using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandleEventWithBlockingCollection
{
    class Program
    {

        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken token;
        static BlockingCollection<string> eventCollection;
        static Random rnd;


        static void Main(string[] args)
        {
            token = tokenSource.Token;
            eventCollection = new BlockingCollection<string>();
            rnd = new Random(1000);

            Task.Run(() => AddEvents());
            Task.Run(() => HandleEvent());


            Thread.Sleep(3000);

            tokenSource.Cancel();
            Console.ReadLine();
        }

        private static void AddEvents()
        {
            while(!token.IsCancellationRequested)
            {
                
                eventCollection.Add(rnd.Next().ToString());
            }

            Console.WriteLine("Task has been canceled - AddEvents Method");
        }

        static void HandleEvent()
        {
                while (!token.IsCancellationRequested)
                {
                    var item = eventCollection.Take();
                    Console.WriteLine("Gathered Event: " + item);
                }
            Console.WriteLine("Task has been canceled - HandleEvent Method");
        }
    }
}
