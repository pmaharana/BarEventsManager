namespace BarEventsManager.Migrations
{
    using BarEventsManager.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BarEventsManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BarEventsManager.Models.ApplicationDbContext context)
        {
            //Add roles
            var adminRole = "admin";
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == adminRole)) 
            {
                var role = new IdentityRole { Name = adminRole };
                manager.Create(role);
            }
            var customerRole = "customer";
            if (!context.Roles.Any(a => a.Name == customerRole))
            {
                var role = new IdentityRole { Name = customerRole };
                manager.Create(role);
            }
            var adminEmail = "admin@bar.com";
            var adminPassword = "hunter2";

            if (!context.Users.Any(u => u.UserName == adminEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = adminEmail };

                userManager.Create(user, adminPassword);
                userManager.AddToRole(user.Id, adminRole);
            }
            context.SaveChanges();
        }
    }
}
