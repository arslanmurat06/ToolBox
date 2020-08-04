using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var internetPublisher = new InternetPublisher();
            internetPublisher.Publish();

            var tvPublisher = new TVPublisher();
            tvPublisher.Publish();

            Console.ReadLine();
        }
    }
}
