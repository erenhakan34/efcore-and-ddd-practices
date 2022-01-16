using Database.Context;
using System;
using System.Configuration;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["EfCoreDbConnectionString"].ConnectionString;

            using (var context = new EFCoreDbContext(connectionString)) 
            {

            }

            Console.WriteLine("Hello World!");
        }
    }
}
