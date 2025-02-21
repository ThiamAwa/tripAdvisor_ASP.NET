using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Annonce
    {

        [Key]
        public int IdAnnonce { get; set; }

       
        [Required(ErrorMessage = "*"), Display(Name = "Date Debut Annonce"), DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Date Fin Annonce"), DataType(DataType.Date)]
        public DateTime DateFin { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Statut Annonce"), MaxLength(20, ErrorMessage = "La taille maximale est de 20")]
        public string Statut_Annonce { get; set; }

        [ForeignKey("IdBien")]
        public virtual Bien Bien { get; set; }

        public int IdBien { get; set; }


    }
}