using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class Program
    {
        interface IUrun
        {
            string tedarikYeri();
        }
        class UrunA : IUrun
        {
            public string tedarikYeri()
            {
                return " ürün Güney Afrikadan gelecek.";
            }
        }
        class UrunB : IUrun
        {
            public string tedarikYeri()
            {
                return " ürün Meksikadan gelecek.";
            }
        }
        class UrunC : IUrun
        {
            public string tedarikYeri()
            {
                return " ürün İspanyadan gelecek.";
            }
        }
        class Yaratici
        {
            // Hangi sınıfın kullanılacağını belirliyoruz.
            public IUrun fabrikaYonetimi(int ay)
            {
                if (ay >= 3 && ay <= 8)
                    return new UrunB();
                else if (ay >= 9 && ay <= 11)
                    return new UrunA();
                else
                    return new UrunC();
            }
        }

        static void Main(string[] args)
        {
            Yaratici yaratici = new Yaratici();
            IUrun iurun;

            for (int i = 1; i <= 12; i++)
            {
                iurun = yaratici.fabrikaYonetimi(i);
                Console.WriteLine($"{i}. ayda {iurun.tedarikYeri()}");
            }

            Console.ReadKey();
        }
    }
}
