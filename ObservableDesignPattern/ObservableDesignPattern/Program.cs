using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObservableDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CoronaDuyurucu duyurucu = new CoronaDuyurucu();
            CoronaDinleyici dinleyici1 = new CoronaDinleyici("Show Haber");
            CoronaDinleyici dinleyici2 = new CoronaDinleyici("Kanal D");

            duyurucu.Subscribe(dinleyici1);
            duyurucu.Subscribe(dinleyici2);


            duyurucu.VakaGuncelle(new Duyuru
            {
                VakaninBulunduguIl = "Ankara",
                VakaSayisi = 100
            });

            Thread.Sleep(1000);

            duyurucu.VakaGuncelle(new Duyuru
            {
                VakaninBulunduguIl = "Erzurum",
                VakaSayisi = 300
            });





            Console.ReadLine();
        }
    }
}
