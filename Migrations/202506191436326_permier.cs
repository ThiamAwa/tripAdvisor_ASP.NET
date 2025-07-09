namespace MvcExampleM1GlGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160),
                        Telephone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 80),
                        Adresse = c.String(nullable: false, maxLength: 160),
                        Matricule = c.String(maxLength: 10),
                        CNI = c.String(maxLength: 20),
                        Passeport = c.String(maxLength: 20),
                        Ninea = c.String(maxLength: 20),
                        Rccm = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        IdAnnonce = c.Int(nullable: false, identity: true),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Statut_Annonce = c.String(nullable: false, maxLength: 20),
                        IdBien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAnnonce)
                .ForeignKey("dbo.Biens", t => t.IdBien, cascadeDelete: true)
                .Index(t => t.IdBien);
            
            CreateTable(
                "dbo.Biens",
                c => new
                    {
                        IdBien = c.Int(nullable: false, identity: true),
                        LibelleBien = c.String(nullable: false, maxLength: 100),
                        DescriptionBien = c.String(nullable: false, maxLength: 2000),
                        Prix_Journalier = c.Single(nullable: false),
                        RegionBien = c.String(nullable: false, maxLength: 50),
                        Pays = c.String(nullable: false, maxLength: 50),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        NbreChambre = c.Int(nullable: false),
                        NbreLit = c.Int(nullable: false),
                        NbreSalleEaux = c.Int(nullable: false),
                        TypeBien = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdBien);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        IdMedia = c.Int(nullable: false, identity: true),
                        TypeMedia = c.String(maxLength: 10),
                        ExtensionMedia = c.String(maxLength: 10),
                        URL = c.String(maxLength: 10),
                        StatutMedia = c.String(maxLength: 10),
                        IdBien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMedia)
                .ForeignKey("dbo.Biens", t => t.IdBien, cascadeDelete: true)
                .Index(t => t.IdBien);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        IdReservation = c.Int(nullable: false, identity: true),
                        DateDebRes = c.DateTime(nullable: false),
                        DateFinRes = c.DateTime(nullable: false),
                        Statut = c.String(nullable: false, maxLength: 20),
                        Montant = c.Single(nullable: false),
                        Bien_IdBien = c.Int(),
                    })
                .PrimaryKey(t => t.IdReservation)
                .ForeignKey("dbo.Biens", t => t.Bien_IdBien)
                .Index(t => t.Bien_IdBien);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Td_erreurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ErreurDescription = c.String(),
                        TitreErreur = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Bien_IdBien", "dbo.Biens");
            DropForeignKey("dbo.Media", "IdBien", "dbo.Biens");
            DropForeignKey("dbo.Annonces", "IdBien", "dbo.Biens");
            DropIndex("dbo.Reservations", new[] { "Bien_IdBien" });
            DropIndex("dbo.Media", new[] { "IdBien" });
            DropIndex("dbo.Annonces", new[] { "IdBien" });
            DropTable("dbo.Td_erreurs");
            DropTable("dbo.Employees");
            DropTable("dbo.Reservations");
            DropTable("dbo.Media");
            DropTable("dbo.Biens");
            DropTable("dbo.Annonces");
            DropTable("dbo.Utilisateurs");
        }
    }
}
