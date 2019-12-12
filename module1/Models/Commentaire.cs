using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Commentaire
    {
        #region Attributs
        private int commentaireId;
        private string texte;
        private Projet projet;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentaireId
        {
            get { return commentaireId; }
            set { commentaireId = value; }
        }

        [StringLength(200, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 200 characters. ")]
        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }

        public virtual Projet Projet
        {
            get { return projet; }
            set { projet = value; }
        }
        #endregion

        #region Constructors
        public Commentaire()
        {

        }
        #endregion

        #region Functions
        #endregion
    }
}
