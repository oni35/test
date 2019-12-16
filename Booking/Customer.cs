using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Customer
    {
        #region Attributes
        private int customerId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        #endregion

        #region Properties
        public int CustomerId { get => customerId; set => customerId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        #endregion
    }
}
