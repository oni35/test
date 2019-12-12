using module1.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Projet
    {
        #region Attributs
        private int projetId;
        private string intitule;
        private DateTime dateDebut;
        private DateTime dateLivraison;
        private int nombreJour;
        private string description;
        private ICollection<Employe> employes;
        private ICollection<Commentaire> commentaires;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjetId
        {
            get { return projetId; }
            set { projetId = value; }
        }

        [Required]
        [DisplayName("Intitulé")]
        [RegularExpression(@"^[A-Z]{2}\d{5}$")]
        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Date de début")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateDebutValide]
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Date de livraison")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateLivraisonValide]
        public DateTime DateLivraison
        {
            get { return dateLivraison; }
            set { dateLivraison = value; }
        }

        [DisplayName("Nombre de jour")]
        [NombreDeJourValide]
        public int NombreJour
        {
            get { return nombreJour; }
            set { nombreJour = value; }
        }

        [Required]
        [StringLength(200, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 200 characters. ")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ICollection<Employe> Employes
        {
            get { return employes; }
            set { employes = value; }
        }

        public virtual ICollection<Commentaire> Commentaires
        {
            get { return commentaires; }
            set { commentaires = value; }
        }
        #endregion

        #region Constructors
        public Projet()
        {
            this.employes = new List<Employe>();
            this.commentaires = new List<Commentaire>();
        }

        #endregion

        #region Functions
        #endregion
    }
}
