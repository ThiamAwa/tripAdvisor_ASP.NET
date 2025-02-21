using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Media
    {
        [Key]
        public int IdMedia { get; set; }


        [Display(Name = "Type"), MaxLength(10, ErrorMessage = "La taille maximale est de 10")]
        public string TypeMedia { get; set; }

        [ MaxLength(10, ErrorMessage = "La taille maximale est de 10")]
        public string ExtensionMedia { get; set; }

        [Display(Name = "Type"),  MaxLength(10, ErrorMessage = "La taille maximale est de 10")]
        public string URL { get; set; }

        [Display(Name = "Statut"), MaxLength(10, ErrorMessage = "La taille maximale est de 10")]
        public string StatutMedia { get; set; }

        [ForeignKey("IdBien")]
        public virtual Bien Bien { get; set; }
        public int IdBien { get; set; }


    }
}