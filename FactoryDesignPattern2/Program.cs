using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern2
{
    enum Tipler
    {
        ASınıfı,
        BSınıfı,
        ESınıfı
    }

    abstract class Ehliyet
    {
        public abstract void Sur();
    }

    class ASinifi : Ehliyet
    {
        public override void Sur()
        {
            Console.WriteLine("Bu ehliyet sınıfında motorsiklet kullanabilirsiniz.");
        }
    }

    class BSinifi : Ehliyet
    {
        public override void Sur()
        {
            Console.WriteLine("Bu ehliyet sınıfında otomobil kullanabilirsiniz.");
        }
    }

    class ESinifi : Ehliyet
    {
        public override void Sur()
        {
            Console.WriteLine("Bu ehliyet sınıfında otobüs kullanabilirsiniz.");
        }
    }
    // Sınıflardan nesne üretecek olan Creater sınıfını oluşturuyoruz.
    class Creater
    {
        public Ehliyet FactoryMethod(Tipler ehliyetTipi)
        {
            Ehliyet ehliyet = null;

            switch (ehliyetTipi)
            {
                case Tipler.ASınıfı:
                    ehliyet = new ASinifi();
                    break;
                case Tipler.BSınıfı:
                    ehliyet = new BSinifi();
                    break;
                case Tipler.ESınıfı:
                    ehliyet = new ESinifi();
                    break;
            }
            return ehliyet;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Creater creater = new Creater();
            Ehliyet ehliyet = creater.FactoryMethod(Tipler.ASınıfı);
            ehliyet.Sur();

            Console.ReadKey();
        }
    }
}
