using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Univers> Univers { get; set; }
        public DbSet<Personnage> Personnages { get; set; }
        public DbSet<Accessoire> Accessoires { get; set; }
        public DbSet<Pouvoir> Pouvoirs { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}