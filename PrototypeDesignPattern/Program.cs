using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern
{   
    class Program
    {
        class IDBilgi
        {
            public int idNo;
            public IDBilgi(int id)
            {
                idNo = id;
            }
        }
        class Insan
        {
            public int yas;
            public DateTime dogumTarihi;
            public string isim;
            public IDBilgi IDBilgi;

            public Insan yuzeyselKopyalama()
            {
                return (Insan)this.MemberwiseClone();
                // MemberwiseClone() : deep copy - object tip döner
            }

            public Insan derinKopyalama()
            {
                Insan klon = (Insan)this.MemberwiseClone();
                klon.IDBilgi = new IDBilgi(IDBilgi.idNo);
                klon.isim = string.Copy(isim);
                return klon;
            }

            public static void degerGoster(Insan i)
            {
                Console.WriteLine($"İsim: {i.isim}, Yaş: {i.yas}, DoğumTarihi: {i.dogumTarihi}");
                Console.WriteLine($"ID: {i.IDBilgi.idNo}");
            }
        }

        static void Main(string[] args)
        {
            Insan insan = new Insan();
            insan.yas = 35;
            insan.dogumTarihi = Convert.ToDateTime("2000-01-01");
            insan.isim = "Doruk Erdem";
            insan.IDBilgi = new IDBilgi(001);

            // insan nesnesinin yüzeysel olarak kopyalanması ve insan2 ye atılması
            Insan insan2 = insan.yuzeyselKopyalama();
            // insan nesnesinin yüzeysel olarak kopyalanması ve insan3 ye atılması
            Insan insan3 = insan.derinKopyalama();

            // Nesnelerin ilk değerlerinin gösterilmesi
            Console.WriteLine("Nesnelerin orjinal değerleri \n");
            Insan.degerGoster(insan);
            Insan.degerGoster(insan2);
            Insan.degerGoster(insan3);


            // insan nesnesinin değerlerinin değiştirilmesi ve yeni değerlerin gösterilmesi
            insan.yas = 45;
            insan.dogumTarihi = Convert.ToDateTime("1990-01-01");
            insan.isim = "Doruk Erdem";
            insan.IDBilgi = new IDBilgi(005);

            // Nesnelerin yeni değerlerinin gösterilmesi
            Console.WriteLine("Nesnelerin yeni değerleri \n");
            Insan.degerGoster(insan);
            // Referans değeri değişti
            Insan.degerGoster(insan2);
            // Hiçbir değerin değişmemesi
            Insan.degerGoster(insan3);


            Console.ReadKey();
        }
    }
}
