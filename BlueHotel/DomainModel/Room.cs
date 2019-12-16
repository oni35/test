using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("Room")]
    public class Room
    {
        #region Attributes
        private int roomId;
        private string name;
        private int floor;
        private string category;


        #endregion

        #region Properties
        [Key]// pas obligé car RoomId permet à EF de savoir que c'est l'id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity par défaut
        public int RoomId { get => roomId; set => roomId = value; }

        [Required]
        [StringLength(30)]
        public string Name { get => name; set => name = value; }

        [Required]
        [Range(0, 200)]
        public int Floor { get => floor; set => floor = value; }

        [StringLength(50)]
        public string Category { get => category; set => category = value; }

        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<BookingRoom> BookingRooms { get; set; }
        #endregion
    }
}
