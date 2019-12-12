using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ProjetDB : DbContext
    {
        #region Properties
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Employe> Employes { get; set; }
        #endregion


        #region Constructors
        public ProjetDB()
        { 

        }
        #endregion

        #region Functions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentaire>().HasOptional(x => x.Projet).WithMany(x => x.Commentaires);
            modelBuilder.Entity<Employe>().HasMany(x => x.Projets).WithMany(x => x.Employes);

            base.OnModelCreating(modelBuilder);
        }
        #endregion



    }
}
