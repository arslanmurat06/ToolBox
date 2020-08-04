using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDesignPattern
{
    public class CoronaDinleyici : IObserver<Duyuru>
    {
        private string Name { get; set; }
        public CoronaDinleyici(string name)
        {
            Name = name;
        }


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Duyuru value)
        {
            Console.WriteLine($" Dinleyici : {Name} -- Yeni Duyuru: Vaka Sayısı :{value.VakaSayisi} İl: {value.VakaninBulunduguIl}");
        }
    }
}
