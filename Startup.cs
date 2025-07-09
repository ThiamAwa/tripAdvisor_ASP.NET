using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using MvcExampleM1GlGroupe2.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcExampleM1GlGroupe2.Startup))]
namespace MvcExampleM1GlGroupe2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();

        }

        private void createRolesandUsers()
        {
            //DbContext context = new DbContext();
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Vérifier si le rôle "Admin" existe déjà
            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    // Création d'un utilisateur Admin
            //    var user = new ApplicationUser
            //    {
            //        UserName = "awa",
            //        Email = "awa96362@gmail.com"
            //    };
            //    string userPWD = "passer";
            //    var chkUser = UserManager.Create(user, userPWD);

            //    // Ajouter l'utilisateur à Admin
            //    if (chkUser.Succeeded)
            //    {
            //        UserManager.AddToRole(user.Id, "Admin");
            //    }
            //}

            // Création des autres rôles
            //if (!roleManager.RoleExists("Client"))
            //{
            //    var role = new IdentityRole { Name = "Client" };
            //    roleManager.Create(role);
            //}

            //if (!roleManager.RoleExists("Gestionnaire"))
            //{
            //    var role = new IdentityRole { Name = "Gestionnaire" };
            //    roleManager.Create(role);
            //}
        }



    }

}



