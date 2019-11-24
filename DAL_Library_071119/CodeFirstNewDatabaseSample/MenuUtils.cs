using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample
{
    public class MenuUtils
    {
        public static int? GetIntChoice(string question, int min, int max)
        {
            int? result = null;
            int outResult = 0;
            string userChoice;

            do
            {
                Console.WriteLine(question);
                userChoice = Console.ReadLine();

            } while (!int.TryParse(userChoice, out outResult) || outResult < min || outResult > max);

            result = outResult;

            return result;
        }

        public static string ServicesMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose the name of service you want to see information\n");
            int i = 0;
            do
            {
                builder.Append("{0}. serviceName {1}\n", i+1, i);
                i++;
            } while (i < 10);
            
            builder.Append(string.Format("{0}. Return to main menu", i+1));

            return builder.ToString();
        }

        public static string BaseChoiceMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. Employees\n");
            builder.Append("2. Services\n");
            builder.Append("3. Payroll\n");
            builder.Append("4. Exit");

            return builder.ToString();
        }


        public static string EmployeesMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. All employees\n");
            builder.Append("2. Select specific employees\n");
            builder.Append("3. Back to main menu");

            return builder.ToString();
        }


        public static string AllEmployeesMenu()

        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. All employees\n");
            builder.Append("2. Payroll\n");
            builder.Append("3. Back");

            return builder.ToString();
        }


        public static string SpecificEmployeesMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. Select by lastname\n");
            builder.Append("2. Select by function\n");
            builder.Append("3. Back");

            return builder.ToString();
        }


        public static string LastnameMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. Show Selected Employees\n");
            builder.Append("2. Payroll of selected employees\n");
            builder.Append("3. Back");

            return builder.ToString();
        }

        public static string FunctionMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. Show Selected Employees by function\n");
            builder.Append("2. Payroll of selected employees\n");
            builder.Append("3. Back");

            return builder.ToString();
        }

        public static string ListOrPayroll()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Choose tables to play with\n");
            builder.Append("1. Employees of the selected service\n");
            builder.Append("2. Payroll of the selected service\n");
            builder.Append("3. Back");

            return builder.ToString();
        }
    }
}
