using Dal;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(BlueContext context = new BlueContext())
            {
                // détruire pr la recréer : context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var bookings = context.Bookings.ToList();// fait une requete : select* from bookings
            }

            Console.WriteLine("Hello World!");// si je l'attends, c'est qu'il n'y pas eu d'exception
        }
    }
}
