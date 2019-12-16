using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
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
        public DateTime Created { get => created; set => created = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime Checkout { get => checkout; set => checkout = value; }
        public bool IsPaid { get => isPaid; set => isPaid = value; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public decimal Price { get => price; set => price = value; }

        #endregion
    }
}
