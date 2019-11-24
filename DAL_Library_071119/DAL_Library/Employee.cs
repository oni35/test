using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Library
{
    public class Employee
    {
        #region Attributs
        private long employeeId;
        private string lastName;
        private string firstName;
        private DateTime dateOfBirth;
        private string city;
        private float salary;
        private string function;
        private int serviceId;
        private Service department;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        [Required]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [SalaryValidator]
        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        [Required]
        public string Function
        {
            get { return function; }
            set { function = value; }
        }


        [Required]
        public Service Department
        {
            get { return department; }
            set { department = value; }
        }
        #endregion

        #region Constructors

        /// <summary>

        /// Default constructor.

        /// </summary>

        public Employee()

        {



        }

        #endregion



        #region StaticFunctions

        #endregion



        #region Functions

        public override string ToString()

        {

            return Newtonsoft.Json.JsonConvert.SerializeObject(this);

        }

        #endregion



        #region Events

        #endregion
    }
}
