using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEGO_Dimensions.Models
{
    public class Personnage
    {
        public int PersonnageId { get; set; }
        [Index("PersonnageIndex", IsUnique = true)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Le nom doit être renseigné.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le personnage doit être relié à un univers.")]
        public int UniversId { get; set; }
        public virtual Univers Univers { get; set; }
        public virtual List<Pouvoir> Pouvoirs { get; set; }
        public virtual List<Accessoire> AccessoiresAssocies { get; set; }
    }
}