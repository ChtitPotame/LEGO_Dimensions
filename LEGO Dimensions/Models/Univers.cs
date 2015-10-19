using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class Univers
    {
        public int UniversId { get; set; }
        [Required(ErrorMessage="Le nom doit être renseigné.")]
        [Index("UniversIndex", IsUnique = true)]
        [MaxLength(50)]
        public string Nom { get; set; }
        public virtual List<Personnage> Personnages { get; set; }
    }
}