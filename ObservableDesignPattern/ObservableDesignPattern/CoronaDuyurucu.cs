using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDesignPattern
{
    public class CoronaDuyurucu : IObservable<Duyuru>
    {
        private List<IObserver<Duyuru>> dinleyiciler;

        public CoronaDuyurucu()
        {
            dinleyiciler = new List<IObserver<Duyuru>>();
        }
        public IDisposable Subscribe(IObserver<Duyuru> dinleyici)
        {
            if (!dinleyiciler.Contains(dinleyici))
            {
                dinleyiciler.Add(dinleyici);
            }

            return new UnSubscriber(dinleyiciler, dinleyici);
        }

        public void VakaGuncelle(Duyuru duyuru)
        {
            foreach (var dinleyici in dinleyiciler)
            {
                dinleyici.OnNext(duyuru);
            }
        }
    }
}
