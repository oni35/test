using CodeFirstNewDatabaseSample;
using System;


namespace ListEmployeesServices
{
    class Play
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.MainMenu();

            Console.ReadLine();
        }
    }
}
