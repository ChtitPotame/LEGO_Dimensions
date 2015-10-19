using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class Accessoire
    {
        public int AccessoireId { get; set; }
        [Index("AccesoireIndex", IsUnique = true)]
        [MaxLength(50)]
        [Required]
        public string Nom { get; set; }
        public virtual Personnage PersonnageAssocie { get; set; }
        public virtual List<Pouvoir> Pouvoirs { get; set; }
    }
}