using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Room
    {
        #region Attributes
        private int roomId;
        private string name;
        private int floor;
        private string category;


        #endregion

        #region Properties
        public int RoomId { get => roomId; set => roomId = value; }
        public string Name { get => name; set => name = value; }
        public int Floor { get => floor; set => floor = value; }
        public string Category { get => category; set => category = value; }

        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        #endregion
    }
}
