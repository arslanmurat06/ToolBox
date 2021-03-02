using System;
using System.Linq;
using System.Threading.Tasks;

namespace LazySingleton
{
    class Program
    {
        static async Task Main(string[] args)
        {


            // **LazySinglotenClass Implementation

            //foreach (int a  in Enumerable.Range(0,10)) 
            //{
            //    await Task.Run(()=> Console.WriteLine(MyLazySingletonClass.Instance.ID));
            //}



            // ***LazyMethodImplementation

            MyLazyMethodClass methodClass = new MyLazyMethodClass();
            methodClass.GetLazyList.ForEach((i) => Console.WriteLine($"Word {i}"));

            Console.WriteLine("--------------------------------------------------------");

            methodClass.GetLazyList.ForEach((i) => Console.WriteLine($"Word {i}"));

            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("Non lazy method");

            Console.WriteLine("--------------------------------------------------------");

            methodClass.GetNonLazyList.ForEach((i) => Console.WriteLine($"Word {i}"));

            Console.WriteLine("--------------------------------------------------------");

            methodClass.GetNonLazyList.ForEach((i) => Console.WriteLine($"Word {i}"));

            Console.ReadLine();
        }
    }
}
