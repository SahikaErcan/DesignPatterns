using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern
{
    class Program
    {
        abstract class Sandvic { }
        abstract class Tatli { }

        abstract class RestoranFabrika
        {
            public abstract Sandvic sandvicOlustur();
            public abstract Tatli tatliOlustur();
        }


        class PMD : Sandvic { }
        class KremBrule : Tatli { }
        class YetiskinFabrika : RestoranFabrika
        {
            public override Sandvic sandvicOlustur()
            {
                return new PMD();
            }

            public override Tatli tatliOlustur()
            {
                return new KremBrule();
            }
        }


        class IzgaraPeynir : Sandvic { }
        class Sundae : Tatli { }
        class CocukFabrika : RestoranFabrika
        {
            public override Sandvic sandvicOlustur()
            {
                return new IzgaraPeynir();
            }

            public override Tatli tatliOlustur()
            {
                return new Sundae();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Kimsiniz? (Y)etişkin ya da (Ç)ocuk?");
            char girdi = Console.ReadKey().KeyChar;

            RestoranFabrika fabrika = null;

            switch (girdi)
            {
                case 'Y':
                    fabrika = new YetiskinFabrika();
                    break;
                case 'Ç':
                    fabrika = new CocukFabrika();
                    break;
                default:
                    Console.WriteLine("\nBöyle bir işlem bulunmamaktadır. Seçiminizi kontrol ediniz. (Y - Ç)");
                    break;
            }

            if (fabrika != null)
            {
                var sandvic = fabrika.sandvicOlustur();
                var tatli = fabrika.tatliOlustur();

                Console.WriteLine("\nSandviç: " + sandvic.GetType().Name);
                Console.WriteLine("Tatlı: " + tatli.GetType().Name);
            }
            
            Console.ReadKey();
        }
    }
}
