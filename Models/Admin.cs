using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Admin:Utilisateur
    {
        [Required(ErrorMessage = "*"), Display(Name = "Matricule"), MaxLength(10)]

        public string Matricule { get; set; } 
    }
}