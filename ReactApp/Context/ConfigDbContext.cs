using Microsoft.EntityFrameworkCore;
using ReactApp.Models.Config;
using ReactApp.Models.Data;
using System.Diagnostics;
using System.Net;
using Activity = ReactApp.Models.Data.Activity;
using Authorization = ReactApp.Models.Data.Authorization;
using User = ReactApp.Models.Config.User;
using UserGroup = ReactApp.Models.Config.UserGroup;

namespace ReactApp.Context
{
    //musim nainstalovat entity framework 
    // User.cs
    //public class User :DbContext
    //{
    //    // Přidat další vlastnosti pro uživatele, např. jméno, příjmení atd.
    //}

    // AppDbContext.cs
    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options)
        {
        }
        public DbSet<User> UserSets { get; set; }
        public DbSet<Group> GroupSets { get; set; }
        public DbSet<UserGroup> UserGroupSets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });//primary key

            //Tato část definuje vztah "má jeden" mezi tabulkami UserGroup a User.Každý záznam v tabulce UserGroup
            //bude odkazovat na jeden uživatelský záznam v tabulce User pomocí cizího klíče UserId. Tato část také nastavuje
            //vazbu "s mnoha" z uživatele na skupiny, protože jeden uživatel může být členem více skupin.
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);
            //Tato část funguje podobně jako předchozí část, ale definuje vztah mezi tabulkami UserGroup a Group.
            //Každý záznam v tabulce UserGroup bude odkazovat na jeden záznam skupiny v tabulce Group pomocí cizího klíče GroupId.
            //Tato část také nastavuje vazbu "s mnoha" ze skupiny na uživatele, protože v jedné skupině může být více uživatelů.
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
