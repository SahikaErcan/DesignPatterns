using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    class Program
    {
        class Singleton
        {
            private Singleton() { }  // Yapıcı metot.

            private static Singleton singleton;
            public static Singleton getSingleton()
            {
                if (singleton == null)  // nesne yoksa
                    singleton = new Singleton();  // oluştur
                return singleton;  // varsa kullan
            }

            public double addition(double a, double b)
            {
                return a + b;
            }
            public double extractionProcess(double a, double b)
            {
                return a - b;
            }
            public double multiplication(double a, double b)
            {
                return a * b;
            }
            public double division(double a, double b)
            {
                return a / b;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("a değerini giriniz: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b değerini giriniz: ");
            double b = Convert.ToDouble(Console.ReadLine());

            /*
            Singleton sınıfından bir değişken oluşturup getSingleton fonksiyonuna gidip
            nesne yoksa nesne oluşturuyoruz varsa da var olan nesneyi kullan diyoruz.
            Değişken üzerinden toplama, çıkarma, çarpma ve bölme işlemi fonksiyonlarına  
            erişim sağlayıp işlemleri gerçekleştiriyoruz.
            */

            Singleton collection = Singleton.getSingleton();  
            double collectionResult = collection.addition(a, b);
            Console.WriteLine($"Toplama İşlemi: {collectionResult}");

            Singleton extraction = Singleton.getSingleton();
            double subtractionResult = extraction.extractionProcess(a, b);
            Console.WriteLine($"Çıkarma İşlemi: {subtractionResult}");

            Singleton multiply = Singleton.getSingleton();
            double multiplicationResult = multiply.multiplication(a, b);
            Console.WriteLine($"Çarpma İşlemi: {multiplicationResult}");

            Singleton divide = Singleton.getSingleton();
            double divisionResult = divide.division(a, b);
            Console.WriteLine($"Bölme Sonucu: {divisionResult}");

            // Her seferinde tek bir nesne kullanarak değişken oluşturuyoruz.
            Console.ReadKey();
        }
    }
}
