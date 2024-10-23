using Microsoft.EntityFrameworkCore;
using Task2.DataProvider.Entites;

namespace Task2.DataProvider.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Resource> Resources { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Role configuration and seeding
        modelBuilder.Entity<Role>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

        // User configuration
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<User>()
            .HasData(
                new User { Id = 1, UserName = "admin", PasswordHash = "hashedpassword1", RoleId = 1 },
                new User { Id = 2, UserName = "user", PasswordHash = "hashedpassword2", RoleId = 2 }
            );

        // Resource configuration
        modelBuilder.Entity<Resource>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Resource>()
            .HasData(
                new Resource { Id = 1, Name = "Dashboard", Description = "Admin dashboard access" },
                new Resource { Id = 2, Name = "Reports", Description = "Access to generate reports" }
            );
    }
}