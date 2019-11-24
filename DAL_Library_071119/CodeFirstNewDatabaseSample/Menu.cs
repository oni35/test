using System;
using System.Collections.Generic;
using System.Linq;
using DAL_Library;

namespace CodeFirstNewDatabaseSample
{
    public class Menu
    {
        public static void MainMenu()
        {
            int? menuChoice = null;

            do
            {
                menuChoice = MenuUtils.GetIntChoice(MenuUtils.BaseChoiceMenu(), 1, 4);
                switch (menuChoice)
                {
                    case 1:
                        Menu.EmployeesMenu();
                        break;

                    case 2:
                        Menu.ServicesMenu();
                        break;

                    case 3:
                        Payroll();
                        break;

                    case 4:
                        Console.WriteLine("Enter to close this application. Thank you and good bye.");
                        Console.ReadLine();
                        break;

                    default:
                        MainMenu();
                        break;
                }

            } while (menuChoice != 4);
        }





        public static void EmployeesMenu()
        {
            int? employeesMenuChoice = MenuUtils.GetIntChoice(MenuUtils.EmployeesMenu(), 1, 3);
            switch (employeesMenuChoice)
            {
                case 1:
                    Menu.AllEmployeesMenu();
                    break;

                case 2:
                    Menu.SpecificEmployeesMenu();
                    break;

                case 3:
                    MainMenu();
                    break;

                default:
                    Menu.EmployeesMenu();
                    break;
            }

        }



        public static void AllEmployeesMenu()
        {
            int? allEmployeesMenuChoice = MenuUtils.GetIntChoice(MenuUtils.AllEmployeesMenu(), 1, 3);
            switch (allEmployeesMenuChoice)
            {
                case 1:
                    using (var db = new EmployeeContext())
                    {
                        foreach (var item in db.employees)
                        {
                            Console.WriteLine("Lastname : {0}, Firstname : {1}, Function : {2}.", item.LastName, item.FirstName, item.Function);
                        }
                    }
                    break;

                case 2:
                    Payroll();
                    break;

                case 3:
                    Menu.EmployeesMenu();
                    break;

                default:
                    Menu.AllEmployeesMenu();
                    break;
            }

        }


        public static void Payroll()
        {
            using (var db = new EmployeeContext())
            {
                Console.WriteLine("Payroll = {0}.", db.employees.Sum(x => x.Salary));

                //System.Nullable<Decimal> totalFreight =
                //    (from ord in db.Orders
                //     select ord.Freight)
                //        .Sum();

                //Console.WriteLine(totalFreight)
            }
        }


        public static void SpecificEmployeesMenu()
        {
            int? specificEmployeesMenuChoice = MenuUtils.GetIntChoice(MenuUtils.SpecificEmployeesMenu(), 1, 3);
            switch (specificEmployeesMenuChoice)
            {
                case 1:
                    SelectByLastName();
                    Menu.SelectByLastNameMenu();
                    break;

                case 2:
                    SelectByFunction();
                    break;

                case 3:
                    Menu.EmployeesMenu();
                    break;

                default:
                    Menu.SpecificEmployeesMenu();
                    break;
            }
        }


        public static string SelectByLastName()
        {
            // selected lastname by user
            string selectedLastName = "";
            Console.WriteLine("Select the lastname of the employees you need to see information");
            selectedLastName = Console.ReadLine().ToString();
            return selectedLastName;

        }


        public static void SelectByLastNameMenu()
        {
            int? lastNameMenuChoice = MenuUtils.GetIntChoice(MenuUtils.LastnameMenu(), 1, 3);
            switch (lastNameMenuChoice)
            {
                case 1:
                    ListSelectedEmployees();
                    break;

                case 2:
                    PayrollSelectedEmployees();
                    break;

                case 3:
                    SpecificEmployeesMenu();
                    break;

                default:
                    Menu.SelectByLastNameMenu();
                    break;
            }
        }


        public static void ListSelectedEmployees()
        {
            // selected employees with the choosen lastname
            using (var db = new EmployeeContext())
            {
                List<Employee> Employees = db.employees.Where(x => x.LastName.Contains(SelectByLastName())).ToList();

                foreach (var item in Employees)
                {
                    Console.WriteLine("Lastname : {0}, Firstname : {1}, Function : {2}.", item.LastName, item.FirstName, item.Function);
                }

            }
        }


        public static void PayrollSelectedEmployees()
        {
            using (var db = new EmployeeContext())
            {
                float payroll = db.employees.Where(x => x.LastName.Contains(SelectByLastName())).Sum(x => x.Salary);
                Console.WriteLine("Payroll = {0}.", payroll);
            }
        }


        public static void SelectByFunctionMenu()
        {
            int? FunctionMenuChoice = MenuUtils.GetIntChoice(MenuUtils.FunctionMenu(), 1, 3);
            switch (FunctionMenuChoice)
            {
                case 1:
                    SelectByFunction();
                    ListSelectedEmployeesByFunction();
                    break;

                case 2:
                    PayrollSelectedEmployeesByFunction();
                    break;

                case 3:
                    SpecificEmployeesMenu();
                    break;

                default:
                    Menu.SelectByFunctionMenu();
                    break;
            }
        }


        public static string SelectByFunction()
        {
            // selected function by user
            string selectedFunction = "";
            Console.WriteLine("Select the function of the employees you need to see information");
            selectedFunction = Console.ReadLine().ToString();
            return selectedFunction;

        }


        public static void ListSelectedEmployeesByFunction()
        {
            // selected employees with the choosen function
            using (var db = new EmployeeContext())
            {
                List<Employee> Employees = db.employees.Where(x => x.Function.Contains(SelectByFunction())).ToList();

                foreach (var item in Employees)
                {
                    Console.WriteLine("Lastname : {0}, Firstname : {1}, Function : {2}.", item.LastName, item.FirstName, item.Function);
                }

            }
        }


        public static void PayrollSelectedEmployeesByFunction()
        {
            using (var db = new EmployeeContext())
            {
                float payroll = db.employees.Where(x => x.Function.Contains(SelectByFunction())).Sum(x => x.Salary);
                Console.WriteLine("Payroll = {0}", payroll);
            }
        }


        public static void ServicesMenu()
        {
            int? serviceNameChoice = MenuUtils.GetIntChoice(MenuUtils.ServicesMenu(), 1, 10);
            switch (serviceNameChoice)
            {
                case 1:
                    string nameService = "serviceName 1";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 2:
                    nameService = "serviceName 2";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 3:
                    nameService = "serviceName 3";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 4:
                    nameService = "serviceName 4";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 5:
                    nameService = "serviceName 5";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 6:
                    nameService = "serviceName 6";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 7:
                    nameService = "serviceName 7";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 8:
                    nameService = "serviceName 8";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 9:
                    nameService = "serviceName 9";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 10:
                    nameService = "serviceName 10";
                    Console.WriteLine("Choosen service : {0}", nameService);
                    ServiceNameChoice(nameService);
                    break;

                case 11:
                    MainMenu();
                    break;

                default:
                    Menu.ServicesMenu();
                    break;
            }
        }

        public static void ServiceNameChoice(string value)
        {
            int? listOrPayroll = MenuUtils.GetIntChoice(MenuUtils.ListOrPayroll(), 1, 3);
            switch (listOrPayroll)
            {
                case 1:
                    //EmployeesOfSelectedService(value);
                    break;

                case 2:
                    //PayrollOfSelectedService(value);
                    break;

                case 3:
                    Menu.ServicesMenu();
                    break;

                default:
                    Menu.ServiceNameChoice(value);
                    break;
            }
        }


        //public static void EmployeesOfSelectedService(string value)
        //{
        //    using (var db = new EmployeeContext())
        //    {
        //        // Link between nameService and serviceId
        //        List<long> selectedServiceId = db.services.Where(x => x.Name.Contains(value)).Select(x => x.ServiceId).ToList();

        //        // Link between serviceId and employee.property
        //        List<Employee> Employees = db.employees.Where(x => selectedServiceId.Contains(x.Department.ServiceId)).ToList();

        //        List of the employees of the selected service
        //        foreach (var item in Employees)
        //        {
        //            Console.WriteLine("Lastname : {0}, Firstname : {1}, Function : {2}, Department : {3}", item.LastName, item.FirstName, item.Function, item.Department);
        //        }




        //}


        //public static void PayrollOfSelectedService(string value)
        //{
        //    using (var db = new EmployeeContext())
        //    {
        //        //// Link between nameService and serviceId
        //        //List<long> selectedServiceId = db.services.Where(x => x.Name.Contains(value)).Select(x => x.ServiceId).ToList();

        //        //// Link between serviceId and employee.property
        //        //List<Employee> Employees = db.employees.Where(x => selectedServiceId.Contains(x.Department.ServiceId)).ToList();

        //        // sum to get payroll

        //    }
        //}
    }
}


