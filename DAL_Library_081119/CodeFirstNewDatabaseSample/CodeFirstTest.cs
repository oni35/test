using DAL_Library;
using System;


namespace CodeFirstNewDatabaseSample
{
    public class CodeFirstTest
    {
        public static void Main(string[] args)
        {
            //using (var db = new EmployeeContext()) 
            //{
            //    foreach (var item in db.employees)
            //    {
            //        Console.WriteLine(item);

            //    }
            //    Console.ReadLine();
            //}

            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
