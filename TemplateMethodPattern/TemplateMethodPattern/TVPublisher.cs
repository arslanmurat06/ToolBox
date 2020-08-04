using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public class TVPublisher : NewsPublisher
    {
        public override void Publish()
        {
            Console.WriteLine("Published on TV");
        }
    }
}
