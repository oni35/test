using DAL_Library;
using System;


namespace CodeFirstNewDatabaseSample
{
    public class CodeFirstTest
    {
        public static void Main(string[] args)
        {
            // Afficher le contenu total de la db services
            //using (var db = new EmployeeContext()) 
            //{
            //    foreach (var item in db.services)
            //    {
            //        Console.WriteLine(item);

            //    }
            //    Console.ReadLine();
            //}

            // use menu
            Menu.MainMenu();

            
        }
    }
}
