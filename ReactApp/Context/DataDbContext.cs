using Microsoft.EntityFrameworkCore;
using ReactApp.Models.Data;
using System.Diagnostics;
using System.Net;
using Activity = ReactApp.Models.Data.Activity;
using Authorization = ReactApp.Models.Data.Authorization;

namespace ReactApp.Context
{
    //musim nainstalovat entity framework 
    public class DataDbContext : DbContext
    {
        //musime poslat DbContextOptions parametr typu teto tridy
        //v tomto parametru musime poslat database providet mysql slserver a connection string 
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("Activity", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("ActivityHistory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });
            });
            modelBuilder.Entity<Authorization>().ToTable("Authorization", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("AuthorizationHistory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });
            });
            modelBuilder.Entity<UserGroup>().ToTable("UserGroup", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("UserGroupHistory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });
            });

            modelBuilder.Entity<User>().ToTable("User", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("UsersHistory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });
            });
            modelBuilder.Entity<Employee>().ToTable("Employee", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("EmployeeHistory");
                    o.HasPeriodStart("ValidFrom");
                    o.HasPeriodEnd("ValidTo");

                });


            });
        }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
