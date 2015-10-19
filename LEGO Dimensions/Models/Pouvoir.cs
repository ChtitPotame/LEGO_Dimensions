using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class Pouvoir
    {
        public int PouvoirId { get; set; }
        [Required]
        public string Nom { get; set; }
        public virtual List<Personnage> Personnages { get; set; }
        public virtual List<Accessoire> Accessoires { get; set; }
    }
}