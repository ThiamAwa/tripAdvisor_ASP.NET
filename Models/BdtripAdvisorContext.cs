using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcExampleM1GlGroupe2.Models
{
    public class BdtripAdvisorContext:DbContext
    {
        public BdtripAdvisorContext():base("PostgresConnection")
        {}
        public DbSet<Client> clients { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<Gestionnaire> gestionnaires { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Bien> biens { get; set; }
        public DbSet<Media> medias { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Annonce> annonces { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Td_erreurs> erreurs { get; set; }

    }
}