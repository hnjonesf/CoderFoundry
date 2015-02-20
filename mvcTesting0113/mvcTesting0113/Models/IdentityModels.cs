using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Configuration;
using SendGrid;
using System.Net.Mail;
using System.Net;

namespace mvcTesting0113.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class EmailService : IIdentityMessageService {
        public Task SendAsync(IdentityMessage message)
        {
            var MyAddress = ConfigurationManager.AppSettings["ContactEmail"];
            var MyUserName = ConfigurationManager.AppSettings["UserName"];
            var MyPassword = ConfigurationManager.AppSettings["Password"];

            SendGridMessage mail = new SendGridMessage();
            mail.From = new MailAddress("noreply");
            mail.AddTo(message.Destination);
            mail.Subject = message.Subject;
            mail.Text = message.Body;

            var credentials = new NetworkCredential(MyUserName, MyPassword);
            var transportWeb = new Web(credentials);
            transportWeb.Deliver(mail);

            return Task.FromResult(0);
        }

    }
    
    
    
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.BlogComments = new HashSet<Comment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Comment> BlogComments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HughJonesWebSiteDb", throwIfV1Schema: false)
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
            modelBuilder.Entity<Post>().HasMany(c => c.Comments);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.BlogComments);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}