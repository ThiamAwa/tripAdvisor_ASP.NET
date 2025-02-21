using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Date Debut Reservation"), DataType(DataType.Date)]
        public DateTime? DateDebRes { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Date Fin Reservation"), DataType(DataType.Date)]
        public DateTime? DateFinRes { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Statut"), MaxLength(20, ErrorMessage = "La taille maximale est de 20")]
        public string Statut { get; set; }


        [Required(ErrorMessage = "*"), Display(Name = "Montant")]
        public float? Montant { get; set; }




    }
}