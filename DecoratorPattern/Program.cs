using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        interface IBilesen
        {
            string operasyon();
        }

        class Bilesen : IBilesen
        {
            public string operasyon()
            {
                return "İstanbulu dinliyorum, ";
            }
        }
        class DekoratorA : IBilesen
        {
            private IBilesen bilesen;
            public DekoratorA(IBilesen b)
            {
                bilesen = b;
            }
            public string operasyon()
            {
                string s = bilesen.operasyon();
                s += "gözlerim kapalı\n";
                return s;
            }
        }

        class DekoratorB : IBilesen
        {
            private IBilesen bilesen;
            public DekoratorB(IBilesen b)
            {
                bilesen = b;
            }
            public string operasyon()
            {
                string s = bilesen.operasyon();
                s += "Önce hafiften bir rüzgar esiyor;\n";
                return s;
            }

            public string yeniDavranis()
            {
                return "Yavaş yavaş sallanıyor\n";
            }
        }

        static void Main(string[] args)
        {
            // Bilesen sınıfımızdan yeni bir nesne oluşturuyoruz.
            IBilesen bilesen = new Bilesen();
            
            Console.WriteLine(bilesen.operasyon());
            // İstanbulu dinliyorum,
            
            Console.WriteLine(new DekoratorA(bilesen).operasyon());
            // İstanbulu dinliyorum, gözlerim kapalı
            
            Console.WriteLine(new DekoratorB(bilesen).operasyon());
            // İstanbulu dinliyorum, Önce hafiften bir rüzgar esiyor;         

            Console.WriteLine(new DekoratorB(bilesen).yeniDavranis());
            // Yavaş yavaş sallanıyor
            // Yeni bir davranış diğerlerinden bağımsız. Tek başına geliyor.

            Console.WriteLine(new DekoratorB(new DekoratorA(bilesen)).operasyon());
            // İstanbulu dinliyorum, gözlerim kapalı
            // Önce hafiften bir rüzgar esiyor;

            Console.WriteLine(new DekoratorB(new DekoratorA(bilesen)).operasyon() + new DekoratorB(bilesen).yeniDavranis());
            // İstanbulu dinliyorum, gözlerim kapalı
            // Önce hafiften bir rüzgar esiyor;
            // Yavaş yavaş sallanıyor


            // Genel olarak Dekorasyon bu işe yarıyor. Yani varolan bir nesneye özellik ekleme ve yeni bir davranış verme durumu...

            Console.ReadKey();
        }
    }
}
