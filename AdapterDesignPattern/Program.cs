using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        interface IHedef
        {
            string istek(int i);
        }

        class Adapte
        {
            public double ozelIstek(double a, double b)
            {
                return a / b;
            }
        }

        class Adaptor: Adapte, IHedef
        {
            public string istek(int i)
            {
                return $"sayının yuvarlanmış hali {(int)Math.Round(ozelIstek(i, 3))}";
            }
        }

        static void Main(string[] args)
        {
            Adapte adapte = new Adapte();
            Console.WriteLine($"Yeni arayüzden önce {adapte.ozelIstek(5, 3)}"); 

            IHedef hedef = new Adaptor();
            Console.WriteLine($"Yeni arayüz ile {hedef.istek(5)}");

            Console.ReadKey();
        }
    }
}
