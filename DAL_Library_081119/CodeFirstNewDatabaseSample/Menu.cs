using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL_Library;
using Microsoft.Ajax.Utilities;
using Microsoft.JScript;

namespace CodeFirstNewDatabaseSample
{
    public class Menu
    {
        public void MainMenu()
        {
            int? choice = null;

            do
            {
                choice = MenuUtils.GetIntChoice(MenuUtils.BaseChoiceMenu(), 1, 4);

                switch (choice)

                {

                    case 1:

                        EmployeeMenu();

                        break;

                    case 2:

                        ServiceMenu();

                        break;

                    case 3:

                        using (var db = new EmployeeContext())

                        {

                            Console.WriteLine(db.Employees.AsNoTracking().Sum(x => x.Salary));

                        }

                        break;

                    case 4:

                        Environment.Exit(0);

                        break;

                    default:

                        break;

                }

            } while (true);

        }



        public void SalaryChargeMenu(Func<EmployeeContext, float> func, Action backMenu)

        {

            int? choice = MenuUtils.GetIntChoice(MenuUtils.SalaryChargeMenu(), 1, 2);



            switch (choice)

            {

                case 1:

                    using (var db = new EmployeeContext())

                    {

                        try

                        {

                            Console.WriteLine(func.Invoke(db) + "€");

                        }

                        catch (Exception e)

                        {

                            Console.WriteLine(e);

                        }

                    }

                    break;

                case 2:

                    backMenu.Invoke();

                    break;

                default:

                    break;

            }

        }



        public void PrintFromDb<T>(Func<EmployeeContext, List<T>> func)

        {

            using (var db = new EmployeeContext())

            {

                List<T> items = new List<T>();

                try

                {

                    items = func.Invoke(db);

                }

                catch (Exception e)

                {

                    Console.WriteLine(e.Message);

                }



                foreach (var item in items)

                {

                    Console.WriteLine(item);

                }

            }

        }



        public void EmployeeMenu()

        {

            int? choice = MenuUtils.GetIntChoice(MenuUtils.EmployeeMenu(), 1, 4);



            PrintFromDb<Employee>((EmployeeContext db) =>
            {

                return db.Employees.AsNoTracking().ToList();

            });



            switch (choice)

            {

                case 1:

                    SalaryChargeMenu((EmployeeContext db) =>

                    {

                        return db.Employees.AsNoTracking().Sum(x => x.Salary);

                    }, EmployeeMenu);

                    break;

                case 2:

                    EmployeeMenuFiltered();

                    break;

                case 3:

                    CUDEmployee();

                    break;

                case 4:

                    MainMenu();

                    break;

                default:

                    break;

            }

        }

        private void CUDEmployee()
        {
            int? choice = MenuUtils.GetIntChoice(MenuUtils.CUDEmployeeChoice(), 1, 4);
            switch (choice)
            {
                case 1:
                    CreateEmployee();

                    break;

                case 2:
                    UpdateEmployee();
                    break;

                case 3:
                    DeleteEmployee();
                    break;

                case 4:
                    EmployeeMenu();
                    break;

                default:
                    CUDEmployee();
                    break;

            }
        }

        private void DeleteEmployee()
        {
            using (var db = new EmployeeContext())
            {
                
                foreach (var item in db.Employees.ToList())
                {
                    Console.WriteLine(item);
                }

                // Employee choosen to delete
                Employee deletedEmployee = null;
                long response;

                // EmployeeToDelete contient l'instance à supprimer
                do
                {
                    Console.WriteLine("Choose the id employee you want to delete");
                    long.TryParse(Console.ReadLine(), out response);
                    deletedEmployee = db.Employees.Find(response);

                } while (deletedEmployee == null);


                // sure ?
                int? choice;
                do
                {
                    choice = MenuUtils.GetIntChoice(MenuUtils.deletedEmployeeChoice(), 1, 3);
                    switch (choice)
                    {
                        case 1:
                            // delete
                            db.Entry(deletedEmployee).State = EntityState.Deleted;
                            break;

                        case 2:
                            DeleteEmployee();
                            break;

                        case 3:
                            CUDEmployee();
                            break;

                    }

                } while (choice != 1 || choice != 2 || choice !=3);

                db.SaveChanges();

            }
        }

        private void UpdateEmployee()
        {
            // Instanciation
            EmployeeContext db = new EmployeeContext();

            // Id employee choosen to update
            foreach (var item in db.Employees.ToList())
            {
                Console.WriteLine(item);
            }

            Employee updatedEmployee = null;
            long response;

            do
            {
                Console.WriteLine("Choose the id of employee you want to update");

                long.TryParse(Console.ReadLine(), out response);
                updatedEmployee = db.Employees.Find(response);

            } while (updatedEmployee == null);

            // employeeToUpdate contient l'instance à modifier
            Employee employeeToUpdate = new Employee();

            // newEmployee properties
            Console.WriteLine("Choose lastname :");
            employeeToUpdate.LastName = Console.ReadLine();

            Console.WriteLine("Choose firstname :");
            employeeToUpdate.FirstName = Console.ReadLine();

            // Secure user choose a DateTime type for date of birthday
            DateTime dateOfBirth;
            do
            {
                Console.WriteLine("Choose date of birth :");

            } while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth));
            employeeToUpdate.DateOfBirth = dateOfBirth;


            Console.WriteLine("Choose city :");
            employeeToUpdate.City = Console.ReadLine();

            Console.WriteLine("Choose function :");
            employeeToUpdate.Function = Console.ReadLine();

            // Secure user choose a float type for salary
            float choosenSalary;
            do
            {
                Console.WriteLine("Choose salary :");

            } while (!float.TryParse(Console.ReadLine(), out choosenSalary) || choosenSalary > 0 && choosenSalary < 100000);
            employeeToUpdate.Salary = choosenSalary;

            // Secure user choose e service type for department
            Service department;

            foreach (var item in db.Services.ToList())
            {
                Console.WriteLine(item);
            }

            do
            {
                Console.WriteLine("Choose id of department service :");
                long choosenId;
                long.TryParse(Console.ReadLine(), out choosenId);
                department = db.services.Find(choosenId);

            } while (department == null);

            employeeToUpdate.Department = department;


            // updateEmployee.EmployeeId est null par defaut, lui alouer l'id de l'employeetoupdate
            employeeToUpdate.EmployeeId = updatedEmployee.EmployeeId; 
           
            // update
            db.Entry(updatedEmployee).CurrentValues.SetValues(employeeToUpdate);

            db.SaveChanges();
        }


        private void CreateEmployee()
        {
            using (var db = new EmployeeContext())
            {
                // Instanciation
                
                Employee newEmployee = new Employee();

                // newEmployee properties
                Console.WriteLine("Choose lastname :");
                newEmployee.LastName = Console.ReadLine();

                Console.WriteLine("Choose firstname :");
                newEmployee.FirstName = Console.ReadLine();

                // Secure user choose a DateTime type for date of birthday
                DateTime dateOfBirth;
                do
                {
                    Console.WriteLine("Choose date of birth : yyyy/mm/dd");

                } while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth));
                newEmployee.DateOfBirth = dateOfBirth;


                Console.WriteLine("Choose city :");
                newEmployee.City = Console.ReadLine();

                Console.WriteLine("Choose function :");
                newEmployee.Function = Console.ReadLine();

                // Secure user choose a float type for salary
                float choosenSalary;
                do
                {
                    Console.WriteLine("Choose salary :");

                } while (!float.TryParse(Console.ReadLine(), out choosenSalary) || choosenSalary > 0 && choosenSalary < 100000);
                newEmployee.Salary = choosenSalary;

                // Secure user choose e service type for department
                Service department = null;

                foreach (var item in db.Services.ToList())
                {
                    Console.WriteLine(item);
                }


                do
                {
                    Console.WriteLine("Choose id of department service :");
                    long choosenId;
                    long.TryParse(Console.ReadLine(), out choosenId);
                    department = db.services.Find(choosenId);

                } while (department == null); // boucle tant que le department n'est pas trouvé et donc qu'il soit null

                newEmployee.Department = department;

                // newEmployee adds in employees database
                db.employees.Add(newEmployee);

                db.SaveChanges();

                // Result
                Console.WriteLine("Congratulation, you have a new employee {0}", newEmployee);
            }
        }

        public void EmployeeMenuFiltered()

        {

            int? choice = MenuUtils.GetIntChoice(MenuUtils.EmployeeFilterMenu(), 1, 3);



            switch (choice)

            {

                case 1:

                    EmployeeMenuFilteredByLastname();

                    break;

                case 2:

                    EmployeeMenuFilteredByFunction();

                    break;

                case 3:

                    EmployeeMenu();

                    break;

                default:

                    break;

            }

        }



        private void EmployeeMenuFilteredByLastname()

        {

            string choice = MenuUtils.GetString("Lastname");

            PrintFromDb<Employee>((EmployeeContext db) =>
            {

                return db.Employees.AsNoTracking().Where(x => x.LastName.Contains(choice)).ToList();

            });

            SalaryChargeMenu((EmployeeContext db) =>

            {

                return db.Employees.Where(x => x.LastName.Contains(choice)).Sum(x => x.Salary);

            }, EmployeeMenuFiltered);

        }



        private void EmployeeMenuFilteredByFunction()

        {

            string choice = MenuUtils.GetString("Function");

            PrintFromDb<Employee>((EmployeeContext db) =>
            {

                return db.Employees.AsNoTracking().Where(x => x.Function.Contains(choice)).ToList();

            });

            SalaryChargeMenu((EmployeeContext db) =>

            {

                return db.Employees.Where(x => x.Function.Contains(choice)).Sum(x => x.Salary);

            }, EmployeeMenuFiltered);

        }



        private void ServiceMenu()

        {

            PrintFromDb<Service>((EmployeeContext db) =>
            {

                return db.Services.AsNoTracking().ToList();

            });



            int? serviceId = MenuUtils.GetIntChoice("Choose service by id", 1, int.MaxValue);



            int? choice = MenuUtils.GetIntChoice(MenuUtils.ServiceMenu(), 1, 4);



            Console.WriteLine("Service " + serviceId + " selected");

            PrintFromDb<Service>((EmployeeContext db) =>
            {

                return db.Services.AsNoTracking().Where(x => x.ServiceId == serviceId).ToList();

            });



            switch (choice)

            {

                case 1:

                    PrintFromDb<Employee>((EmployeeContext db) =>
                    {

                        return db.Employees.AsNoTracking().Where(x => x.Department.ServiceId == serviceId).ToList();

                    });

                    SalaryChargeMenu((EmployeeContext db) =>

                    {

                        return db.Employees.AsNoTracking().Include(x => x.Department).Where(x => x.Department.ServiceId == serviceId).Sum(x => x.Salary);

                    }, ServiceMenu);

                    break;

                case 2:

                    using (var db = new EmployeeContext())

                    {

                        if (db.Employees.Include(x => x.Department).Where(x => x.Department.ServiceId == serviceId).Count() > 0)

                        {

                            Console.WriteLine(db.Employees.Include(x => x.Department).Where(x => x.Department.ServiceId == serviceId).Sum(x => x.Salary));

                        }

                    }

                    break;

                case 3:

                    CUDService();

                    break;

                case 4:

                    MainMenu();

                    break;

                default:

                    break;

            }

        }

        private void CUDService()
        {
            int? choice = MenuUtils.GetIntChoice(MenuUtils.CUDService(), 1, 4);
            switch (choice)
            {
                case 1:
                    CreateService();
                    break;

                case 2:
                    //UpdateService();
                    break;

                case 3:
                    DeleteService();
                    break;

                case 4:
                    ServiceMenu();
                    break;

                default:
                    CUDService();
                    break;

            }
        }

        private void DeleteService()
        {
            using (var db = new EmployeeContext())
            {
                
                foreach (var item in db.services.ToList())
                {
                    Console.WriteLine(item);
                }

                // Service choosen to delete
                Service deletedService = null;
                long response;

                // serviceToDelete contient l'instance à supprimer
                do
                {
                    Console.WriteLine("Choose the id service you want to delete");
                    long.TryParse(Console.ReadLine(), out response);
                    deletedService = db.services.Find(response);

                } while (deletedService == null);

                // sure ?
                int? choice;
                do
                {
                    choice = MenuUtils.GetIntChoice(MenuUtils.deletedServiceChoice(), 1, 3);
                    switch(choice)
                    {
                        case 1:
                            // delete all affected employees
                            // or
                            // affecte a new id service for the employee who lost their id service ?
                            int? newIdServiceChoice;
                            do
                            {
                                newIdServiceChoice = MenuUtils.GetIntChoice(MenuUtils.NewIdServiceChoice(), 1, 4);
                                switch (newIdServiceChoice)
                                {
                                    case 1:
                                        AffectedNewIdServiceAllEmployees(deletedService);
                                        break;

                                    case 2:
                                        AffectedNewIdServiceEachEmployees(deletedService);
                                        break;

                                    case 3:
                                        DeleteAllAffectedEmployees(deletedService);
                                        break;

                                    case 4:
                                        DeleteService();
                                        break;

                                }

                            } while (newIdServiceChoice != 1 || newIdServiceChoice != 2 || newIdServiceChoice != 3 || newIdServiceChoice != 4);
                            ;
                            
                            break;

                        case 2:
                            DeleteService();
                            break;

                        case 3:
                            CUDService();
                            break;

                    }
                  
                } while (choice != 1 || choice != 2 || choice != 3);

                

                // save
                db.SaveChanges();
            }
        }

        private void DeleteAllAffectedEmployees(Service deletedService)
        {
            using (var db = new EmployeeContext())
            {
                // employees filtrés par le service selectionné par l'utilisateur
                IEnumerable<Employee> allEmployeesWithNoIdService = db.Employees.Where(x => x.Department == deletedService);
                
                // delete all selected employees by choosen service 
                db.Entry(allEmployeesWithNoIdService).State = EntityState.Deleted;
            }
        }

        private void AffectedNewIdServiceEachEmployees(Service deletedService)
        {
            using(var db = new EmployeeContext())
            {
                // employees filtrés par le service selectionné par l'utilisateur
                IEnumerable<Employee> eachEmployeesWithNoIdService = db.Employees.Where(x => x.Department == deletedService);


                // affiche les noms des services
                foreach (var item in db.services.ToList())
                {
                    Console.WriteLine(item);
                }

                // affect new name service
                Service department;
                foreach(var item in eachEmployeesWithNoIdService)
                {
                    Console.WriteLine(item.EmployeeId);
                    Console.WriteLine(item.LastName);
                    Console.WriteLine(item.FirstName);

                    do
                    {
                        Console.WriteLine("Choose in this list above a id of department service for employee who lost it :");
                        long choosenId;
                        long.TryParse(Console.ReadLine(), out choosenId);
                        department = db.services.Find(choosenId);

                    } while (department == null || department != deletedService); // boucle tant que le department n'est pas trouvé et donc qu'il soit null

                    item.Department = department;
                }

                // save
                db.SaveChanges();
            }
            
        }

        private void AffectedNewIdServiceAllEmployees(Service deletedService)
            // Je recupere le service à supprimer pour faire une collection d'employé ayant ce service
            // et soit je supprime cette collection
            // soit je réaffecte un nouveau service pour tous les employés affectés
            // ou je réa
        {
            using (var db = new EmployeeContext())
            {
                
                // employees filtrés par le service selectionné par l'utilisateur
                IEnumerable<Employee> allEmployeesWithNoIdService = db.Employees.Where(x => x.Department == deletedService);


                // affiche les noms des services
                foreach (var item in db.services.ToList())
                {
                    Console.WriteLine(item);
                }


                // affect new name service

                Service department;
                do
                {
                    Console.WriteLine("Choose in this list above a id of department service for employee who lost it :");
                    long choosenId;
                    long.TryParse(Console.ReadLine(), out choosenId);
                    department = db.services.Find(choosenId);

                } while (department == null); // boucle tant que le department n'est pas trouvé et donc qu'il soit null

                foreach (var item in allEmployeesWithNoIdService)
                {
                    item.Department = department;
                }

                // save
                db.SaveChanges();
            }
        }



        private void UpdateService()
        {
            throw new NotImplementedException();
        }



        private void CreateService()
        {
            using(var db = new EmployeeContext())
            {
                // instancie un nouveau service
                Service newService = new Service();

                // name of newService
                Console.WriteLine("Choose the name of the service you want to create");

                newService.Name = Console.ReadLine();

                // description
                Console.WriteLine("descript the new service");

                newService.Description = Console.ReadLine();

                // add this new service
                db.services.Add(newService);

                db.SaveChanges();
            }
            
        }
    }
}


