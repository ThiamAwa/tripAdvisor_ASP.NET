using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcExampleM1GlGroupe2.Models
{
    public class Bien
    {
        [Key]
        public int IdBien { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Designation"), MaxLength(100, ErrorMessage = "La taille maximale est de 100")]
        public string LibelleBien { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Description"), MaxLength(2000, ErrorMessage = "La taille maximale est de 20")]
        public string DescriptionBien { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Prix Journalier")]
        public float? Prix_Journalier { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Region"), MaxLength(50, ErrorMessage = "La taille maximale est de 50")]
        public string RegionBien { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Pays"), MaxLength(50, ErrorMessage = "La taille maximale est de 50")]
        public string Pays { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Latitude") ]
        public float? Latitude { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Longitude")]
        public float? Longitude { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nombre Chambre")]
        public int? NbreChambre { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nombre Lit")]
        public int? NbreLit { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nombre Salle Eaux")]
        public int? NbreSalleEaux { get; set; } = 0;

        [Required(ErrorMessage = "*"), Display(Name = "Type Bien"), MaxLength(20, ErrorMessage = "La taille maximale est de 20")]
        public string TypeBien { get; set; } = "Maison";

        public virtual ICollection<Media> Medias { get; set; }
        public virtual ICollection<Annonce> Annonces { get; set; }  
        public virtual ICollection<Reservation> Reservations { get; set; }  





    }
}