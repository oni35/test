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
    public class Employe
    {
        #region Attributs
        private int employeId;
        private string nom;
        private string prenom;
        private ICollection<Projet> projets;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeId
        {
            get { return employeId; }
            set { employeId = value; }
        }

        [Required]
        [DisplayName("Nom")]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [Required]
        [DisplayName("Prénom")]
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        [NotMapped]
        public string FullName { get { return this.Nom + " " + this.Prenom; } }

        public virtual ICollection<Projet> Projets
        {
            get { return projets; }
            set { projets = value; }
        }
        #endregion

        #region Constructors
        public Employe()
        {
            this.projets = new List<Projet>();
        }

        #endregion

        #region Functions
        #endregion
    }
}
