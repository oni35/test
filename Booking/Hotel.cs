using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class Hotel 
    {
        #region Attributes
        private int hotelId;
        private string name;
        private int star;
        #endregion
        
        //propriétés scalaires
        #region Properties
        public int HotelId { get => hotelId; set => hotelId = value; }
        public string Name { get => name; set => name = value; }
        public int Star { get => star; set => star = value; }

        //propriétés de navigations
        public virtual Address Address { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        #endregion
    }
}
