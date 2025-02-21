using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Gestionnaire:Utilisateur
    {
        [Display(Name = "NINEA"), MaxLength(20, ErrorMessage = "La taille maximale est de 20")]
        public string Ninea { get; set; }

        [Display(Name = "Rccm"), MaxLength(20, ErrorMessage = "La taille maximale est de 20")]
        public string Rccm { get; set; }
    }
}