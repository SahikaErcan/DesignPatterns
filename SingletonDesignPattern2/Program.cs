using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern2
{
    class Program
    {
        class TekNesne
        {
            private TekNesne() { }

            private static TekNesne tekNesne;

            public static TekNesne nesneOlustur()
            {
                if (tekNesne == null)
                    tekNesne = new TekNesne();
                return tekNesne;
            }

            public void havaYolu()
            {
                // Sözlük oluşturup bilgileri ekliyoruz.
                Dictionary<string, string> hava_yolu = new Dictionary<string, string>();
                hava_yolu.Add("ADA","Adana");
                hava_yolu.Add("ESB","Ankara");
                hava_yolu.Add("AYT","Antalya");
                hava_yolu.Add("BJV","Bodrum");
                hava_yolu.Add("DLM","Dalaman");
                hava_yolu.Add("DIY","Diyarbakır");
                hava_yolu.Add("ECN","Kıbrıs Ercan");
                hava_yolu.Add("ERZ","Erzurum");
                hava_yolu.Add("GZT","Gaziantep");
                hava_yolu.Add("IST","İstanbul");
                hava_yolu.Add("ADB","İzmir");
                hava_yolu.Add("ASR","Kayseri");
                hava_yolu.Add("SAW","Sabiha Gökçen");
                hava_yolu.Add("SZF","Samsun");
                hava_yolu.Add("TZX","Trabzon");

                Console.Write("Lütfen havaalanı kodunu giriniz: ");
                string kod = Console.ReadLine();

                // Girilen kod sözlükte var mı?
                if (hava_yolu.ContainsKey(kod) == true)  // Anahtar doğruysa
                    Console.WriteLine($"Girdiğiniz kodun havaalanı: {hava_yolu[kod]} Havaalanı");
                else
                    Console.WriteLine("Böyle bir kod bulunamadı.");
            }
        }

        static void Main(string[] args)
        {
            // Nesne yoksa oluştur varsa kullan ve tekNesne değişkenine at
            TekNesne tekNesne = TekNesne.nesneOlustur();
            tekNesne.havaYolu();

            Console.ReadKey();
        }
    }
}

