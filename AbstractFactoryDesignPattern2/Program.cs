using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern2
{
    // Abstract Product: Üretilecek ürünlerin soyut sınıfıdır. Belirli ürünlerin içerisindeki tüm member 
    // yapılanmasını imza olarak taşımakta ve Concrete Product yapılarına implemente etmektedir.
    abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool DisConnect();
        public abstract string State { get; }
    }
    // Abstract Product
    abstract class Command
    {
        public abstract void Execute(string query);
    }
    // Concrete Product: İstemcinin üretmek istediği ürün ailesinin gerçek somut sınıflarıdır.
    class SqlConnect : Connection
    {
        public override string State => "Open";

        public override bool Connect()
        {
            Console.WriteLine("SqlConnection bağlantısı kuruluyor.");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("SqlConnection bağlantısı kesiliyor.");
            return false;
        }
    }
    // Concrete Product
    class SqlCommand : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("SqlCommand sorgusu çalıştırıldı.");
        }
    }
    // Concrete Product
    class MySqlConnection : Connection
    {
        public override string State => "Open";

        public override bool Connect()
        {
            Console.WriteLine("MySqlConnection bağlantısı kuruluyor.");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("MySqlConnection bağlantısı kesiliyor.");
            return false;
        }
    }
    // Concrete Product
    class MySqlCommand : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("MySqlCommand sorgusu çalıştırıldı.");
        }
    }

    // Abstract Factory: Ürün ailesini oluşturacak olan fabrika sınıflarına arayüz sağlayan yapıdır.
    abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    // Concreate Factory: Asıl ürün ailesini oluşturan fabrikalardır.
    class SqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new SqlCommand();

        public override Connection CreateConnection() => new SqlConnect();      
    }

    // Concreate Factory

    class MySqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new MySqlCommand();
        public override Connection CreateConnection() => new MySqlConnection();
    }
    class Creater
    {
        DatabaseFactory _databaseFactory;
        Connection _connection;
        Command _command;

        public Creater(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = databaseFactory.CreateConnection();
            _command = databaseFactory.CreateCommand();

            Start();
        }

        void Start()
        {
            if (_connection.State == "Open")
            {
                _connection.Connect();
                _command.Execute("Select * from ....");
                _connection.DisConnect();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Creater creater = new Creater(new SqlDatabase());
            Console.WriteLine("*************");
            creater = new Creater(new MySqlDatabase());

            Console.Read();
        }
    }
}
