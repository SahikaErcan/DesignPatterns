using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPattern
{
    class Program
    {
        public interface INesne
        {
            string istek();
        }

        private class Nesne
        {
            public string istek()
            {
                return "Sol taraftaki kapıya git \n";
            }
        }

        public class Proxy : INesne
        {
            Nesne nesne;
            public string istek()
            {
                if (nesne == null)
                {
                    Console.WriteLine("Robot inaktif durumdadır.");
                    nesne = new Nesne();
                    return "Proxy sınıfı robotun isteğini bulamıyor. Lütfen robotu aktif ediniz.";
                }
                else
                {
                    Console.WriteLine("Robot aktif durumdadır.");
                }
                return "Proxy sınıfı robotun isteğini belirtiyor: " + nesne.istek();
            }
        }

        public class korumaProxy : INesne
        {
            Nesne nesne;
            string sifre = "1234";
            public string dogrulama(string s)
            {
                if (s != sifre)
                    return "Koruma Proxy: Şifre geçerli değil, erişim izni yok";
                else
                    nesne = new Nesne();
                return "Koruma Proxy: Şifre geçerli, erişim sağlandı.";
            }

            public string istek()
            {
                if (nesne == null)
                    return "Koruma proxy: İlk olarak doğrulama işlemi gerçekleştiriniz..";
                else
                    return "Proxy sınıfı robotun isteğini belirtiyor: " + nesne.istek();
            }
        }
        static void Main(string[] args)
        {
            INesne nesne = new Proxy();
            Console.WriteLine(nesne.istek());
            Console.WriteLine(nesne.istek());

            nesne = new korumaProxy();
            Console.WriteLine((nesne as korumaProxy).dogrulama("deneme"));
            Console.WriteLine((nesne as korumaProxy).dogrulama("1234"));
            Console.WriteLine(nesne.istek());

            Console.ReadKey();
        }
    }
}
