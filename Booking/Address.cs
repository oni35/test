using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Address
    {
        #region Attributes
        private int addressId;
        private string street;
        private string zipcode;
        private string city;
        private string country;
        private double latitude;
        private double longitude;
        private string phone;
        #endregion

        #region properties
        public int AddressId { get => addressId; set => addressId = value; }
        public string Street { get => street; set => street = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Phone { get => phone; set => phone = value; }


        
        #endregion



    }
}
