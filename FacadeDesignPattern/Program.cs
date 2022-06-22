using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    class Program
    {
        class Gadget
        {
            public string islem1()
            {
                return "Gadget: HAZIR \n";
            }
            public string islem2()
            {
                return "Gadget: Kalkışa Hazırlanıyor... \n";
            }
        }
        class Spencer
        {
            public string islem1()
            {
                return "Spencer: HAZIR \n";
            }
            public string islem2()
            {
                return "Spencer: Ateş Etmeye Hazırlanıyor... \n";
            }
        }

        class Cephe
        {
            // Protected: Tanımlandığı sınıfta ve o sınıfı miras alan sınıflardan erişilebilir.
            // (Kalıtım ile aktarılır.)
            protected Gadget _g;
            protected Spencer _s;
            public Cephe(Gadget altG, Spencer altS)
            {
                _g = altG;
                _s = altS;
            }
            public string islem()
            {
                string sonuc = "Cephe Tasarımı Alt Sistemleri Başlattı \n";
                sonuc += _g.islem1(); // Gadget: HAZIR
                sonuc += _s.islem1(); // Spencer: HAZIR
                sonuc += "Cephe Tasarımı Alt Sistemlere Komut Gönderiyor... \n";
                sonuc += _g.islem2(); // Gadget: Kalkışa Hazırlanıyor...
                sonuc += _s.islem2(); // Spencer: Ateş Etmeye Hazırlanıyor...
                return sonuc;
            }
        }

        static void Main(string[] args)
        {
            Gadget gadget = new Gadget();
            Spencer spencer = new Spencer();
            Cephe cephe = new Cephe(gadget, spencer);
            Console.WriteLine(cephe.islem());

            // Karmaşıklığı engellemek
            // Sistemdeki bozulmaları engellemek
            // Esnekliği sağlamak

            Console.ReadKey();
        }
    }
}
