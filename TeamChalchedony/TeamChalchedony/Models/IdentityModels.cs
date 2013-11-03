using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TeamChalchedony.Migrations;

namespace TeamChalchedony.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public int CustomerId { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}