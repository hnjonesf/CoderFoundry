namespace EmployeeTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EmployeeTracker.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeTracker.Models.ApplicationDbContext context)
        {

            var department = new List<Department>
            {
                new Department { Name = "Engineering" },
                new Department { Name = "English" },
                new Department { Name = "Business" },
                new Department { Name = "Hotel Management" },
                new Department { Name = "Outdoor Living" }
            };

            department.ForEach(d=>context.Departments.AddOrUpdate(n=>n.Name, d));
            context.SaveChanges();

            var employee = new List<Employee>
            {
                new Employee { Name = "Sam Sofa" },
                new Employee { Name = "Eddie English" },
                new Employee { Name = "Bob Bozo" },
                new Employee { Name = "Hap Happy" },
                new Employee { Name = "Lazy Lizzie" }
            };

            employee.ForEach(e => context.Employees.AddOrUpdate(n => n.Name, e));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
