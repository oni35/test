using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Booking")]//pas obligé mais pour EF et renommer au cas où la table
    public class Booking
    {
        #region Attributes
        private int bookingId;
        private DateTime created;
        private DateTime checkIn;
        private DateTime checkout;
        private decimal price;
        private Boolean isPaid;


        #endregion

        #region Properties
        public int BookingId { get => bookingId; set => bookingId = value; }

        [Required]
        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        public DateTime Created { get => created; set => created = value; }

        [Required]
        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }

        [Required]
        [Range(typeof(DateTime), "01/01/2019", "01/01/3000")]
        public DateTime Checkout { get => checkout; set => checkout = value; }

        [Required]
        public bool IsPaid { get => isPaid; set => isPaid = value; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<BookingRoom> BookingRooms { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get => price; set => price = value; }

        #endregion
    }
}
