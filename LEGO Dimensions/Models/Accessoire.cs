using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Le nom doit être renseigné.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "L'objet doit appartenir à un personnage.")]
        public int PersonnageId { get; set; }
        [DisplayName("Personnage associé")]
        public virtual Personnage PersonnageAssocie { get; set; }
        public List<int> PouvoirsId { get; set; }
        public virtual List<Pouvoir> Pouvoirs { get; set; }
    }
}