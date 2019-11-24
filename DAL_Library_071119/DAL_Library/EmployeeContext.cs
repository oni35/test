using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Library
{
    public class EmployeeContext : DbContext
    {
        #region Attributs
        public DbSet<Employee> employees;
        public DbSet<Service> services;
        #endregion

        #region Properties
        public DbSet<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public DbSet<Service> Services
        {
            get { return services; }
            set { services = value; }
        }
        #endregion

        #region Constructors
        /// <summary>

        /// Default constructor.

        /// </summary>
        public EmployeeContext() : base()
        {
            try
            {
                if (this.Database.CreateIfNotExists())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Service service = new Service();
                        service.Name = string.Format("serviceName {0}", i);
                        service.Description = string.Format("serviceDescription {0}", i);

                        this.Services.Add(service);
                        this.SaveChanges();
                    }

                    Random random = new Random();
                    for (int i = 0; i < 30; i++)
                    {
                        Employee employee = new Employee();
                        employee.FirstName = string.Format("FirstName {0}", i);
                        employee.LastName = string.Format("LastName {0}", i);
                        employee.Function = string.Format("function {0}", this.Services.Find(random.Next(1, Services.Count())));
                        employee.Salary = 500F * i;
                        employee.DateOfBirth = DateTime.Now;
                        employee.Department = this.Services.Find(random.Next(1, Services.Count()));

                        this.Employees.Add(employee);
                        this.SaveChanges();
                    }

                }
            }

            catch
            {
                if (this.Database.Exists())
                    this.Database.Delete();
               
            }
        }
        #endregion

            #region Functions 
        //Relations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<Employee>().HasRequired(e => e.Department).WithMany(s => s.Employees);
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
