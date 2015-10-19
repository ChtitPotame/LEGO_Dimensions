using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class Utilisateur
    {
        [Key]
        [Required]
        public string Nom { get; set; }
        [Required]
        public string MotDePasse { get; set; }
    }
}