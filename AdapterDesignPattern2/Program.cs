using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern2
{
    interface ISiparis
    {
        void siparis(string s);
    }
    class Adapte
    {
        public void ozelSiparis()
        {
            Console.WriteLine("Gitar siparişi başarılı bir şekilde oluşturulmuştur.");
        }
    }
    class Adaptor : Adapte, ISiparis
    {
        public void siparis(string s)
        {
            Console.WriteLine(s + " siparişi başarılı bir şekilde oluşturulmuştur.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Adapte adapte = new Adapte();
            adapte.ozelSiparis();

            ISiparis siparis = new Adaptor();
            siparis.siparis("Keman");

            ISiparis siparis2 = new Adaptor();
            siparis2.siparis("Tulum");

            Console.ReadKey();
        }
    }
}
