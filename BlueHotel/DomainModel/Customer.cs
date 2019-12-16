using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Customer")]
    public class Customer
    {
        #region Attributes
        private int customerId;
        private string fullName;
        private DateTime dateOfBirth;
        private Address address;
        private ICollection<Booking> bookings;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get => customerId; set => customerId = value; }

        [Required]
        [StringLength(255)]
        public string FullName { get => fullName; set => fullName = value; }

        [Required]
        [Range(typeof(DateTime), "01/01/1900", "30/12/2020")]
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public virtual Address Address { get => address; set => address = value; }

        public virtual ICollection<Booking> Bookings { get => bookings; set => bookings = value; }
        #endregion
    }
}
