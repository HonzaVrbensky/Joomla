using Joomla2._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace Joomla2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<JUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<JUser> JUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<JUser>().ToTable("Users");
            builder.Entity<JUser>().Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(a => a.Createdat).HasDefaultValue(DateTime.UtcNow);

            var hasher = new PasswordHasher<JUser>();
            var admin = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                NormalizedName = "admin",
            });

            builder.Entity<JUser>().HasData(new JUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin",
                NormalizedEmail = "admin",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(new JUser(), "admin")
            });
            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = admin,
                UserId = admin,
            });
        }
    }
}
