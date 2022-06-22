using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern2
{
    interface IAraba
    {
        void bilgiDetaylari();
        void fiyatEkle(double eklenmisFiyat);
        void tanimEkle(string eklenmisTanim);
    }

    public class Araba : IAraba
    {
        public string model { get; set; }
        public string marka { get; set; }
        public double fiyat { get; set; }
        public string tanim { get; set; }
        public Araba()
        {
            fiyat = 125.000;
        }


        public void bilgiDetaylari()
        {
            Console.WriteLine(tanim);
        }

        public void fiyatEkle(double eklenmisFiyat)
        {
            fiyat += eklenmisFiyat;
        }

        public void tanimEkle(string eklenmisTanim)
        {
            tanim = $"Model: {model} Marka: {marka} Güncel Fiyat: {fiyat}  {eklenmisTanim}";
        }
    }

    class ArabaDekorator : IAraba
    {
        private IAraba araba;
        public ArabaDekorator(IAraba a)
        {
            araba = a;
        }

        public void bilgiDetaylari()
        {
            araba.bilgiDetaylari();
        }

        public void fiyatEkle(double eklenmisFiyat)
        {
            araba.fiyatEkle(eklenmisFiyat);
        }

        public void tanimEkle(string eklenmisTanim)
        {
            araba.tanimEkle(eklenmisTanim);
        }
    }

    class camTavanDekorator : ArabaDekorator
    {
        public camTavanDekorator(IAraba araba) : base(araba) { }

        public void bilgiDetaylari()
        {
            base.fiyatEkle(15);
            base.tanimEkle("Cam Tavan bilgisi araca eklendi.");
            base.bilgiDetaylari();
        }
    }

    class parkSensoruDekorator : ArabaDekorator
    {
        public parkSensoruDekorator(IAraba araba) : base(araba) { }
        
        public void bilgiDetaylari()
        {
            base.fiyatEkle(10);
            base.tanimEkle("Park Sensörü araca eklendi.");
            base.bilgiDetaylari();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IAraba araba = new Araba()
            {
                model = "Polo",
                marka = "Volkswagen",
                fiyat = 125.000,
                tanim = "Yeni araba eklendi."
            };

            camTavanDekorator camTavan = new camTavanDekorator(araba);
            camTavan.bilgiDetaylari();

            parkSensoruDekorator parkSensoru = new parkSensoruDekorator(araba);
            parkSensoru.bilgiDetaylari();


            IAraba araba2 = new Araba()
            {
                model = "S90",
                marka = "Volvo",
                fiyat = 240.000,
                tanim = "Yeni araba eklendi."
            };

            parkSensoruDekorator parkSensoru2 = new parkSensoruDekorator(araba2);
            parkSensoru2.bilgiDetaylari();

            Console.ReadKey();
        }
    }
}
