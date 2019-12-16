using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Address")]
    public class Address
    {
        #region Attributes
        private int addressId;
        private string street;
        private string zipcode;
        private string city;
        private string country;
        private double? latitude;
        private double? longitude;
        private string phone;
        private string email;
        #endregion

        #region properties
        public int AddressId { get => addressId; set => addressId = value; }

        [StringLength(255)]
        [Required]
        public string Street { get => street; set => street = value; }

        [StringLength(10)]
        [Required]
        public string Zipcode { get => zipcode; set => zipcode = value; }

        [StringLength(50)]
        [Required]
        public string City { get => city; set => city = value; }

        [StringLength(55)]
        [Required]
        public string Country { get => country; set => country = value; }

        public double? Latitude { get => latitude; set => latitude = value; }
        public double? Longitude { get => longitude; set => longitude = value; }

        [StringLength(14)]
        [Required]
        [RegularExpression(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$")]
        public string Phone { get => phone; set => phone = value; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get => email; set => email = value; }
        #endregion



    }
}
