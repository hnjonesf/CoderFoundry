namespace SquadClock.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SquadClock.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SquadClock.Models.ApplicationDbContext context)
        {

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Owner"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Owner" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.Email == "hughjones@libreworx.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "hughjones@libreworx.com",
                    Email = "hughjones@libreworx.com",
                    FirstName = "Hugh",
                    LastName = "Jones",
                    DisplayName = "Hugh Jones"
                };

                manager.Create(user, "Abc123!");
                manager.AddToRoles(user.Id, new string[] { "Administrator", "Manager" });
            }

            if (!context.Users.Any(u => u.Email == "carson@libreworx.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "carson@libreworx.com",
                    Email = "carson@libreworx.com",
                    FirstName = "Carson",
                    LastName = "Carson",
                    DisplayName = "Carson Beam"
                };

                manager.Create(user, "Abc123!");
                manager.AddToRoles(user.Id, new string[] { "Manager" });
            }
        }
    }
}
