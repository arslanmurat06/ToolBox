using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public abstract class NewsPublisher
    {
        public void FixTypos()
        {
            Console.WriteLine("Fixing typos");
        }

        public void RemoveUnncessaryTexts()
        {
            Console.WriteLine("Removing Unnecessary texts");
        }

        public void PublishNews()
        {
            RemoveUnncessaryTexts();
            FixTypos();
            Publish();
        }

        public abstract void Publish();
    }
}
