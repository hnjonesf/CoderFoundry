using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Squadclock.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquadClock.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //User validation

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 30 characters.")]
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public int CompanyId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }

        //Constructor}
        public ApplicationUser()
        {
            this.Settings = new HashSet<Setting>();
        }

        //Navigation
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //added
            modelBuilder.Entity<Company>().HasMany(c => c.Employees);
            modelBuilder.Entity<Company>().MapToStoredProcedures();
            modelBuilder.Entity<Employee>().MapToStoredProcedures();
            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Employees);
        }

        public System.Data.Entity.DbSet<Squadclock.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Shift> Shifts { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Manager> Managers { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<Squadclock.Models.Setting> Settings { get; set; }
 
    }
}