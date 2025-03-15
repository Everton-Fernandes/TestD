using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Criando um usuário administrador padrão (seeding)
            var adminRole = new IdentityRole("Admin");
            var userRole = new IdentityRole("User");

            builder.Entity<IdentityRole>().HasData(adminRole, userRole);

            var adminUser = new User
            {
                Id = "admin-id",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                CPF = "000.000.000-00"
            };

            // Criando a senha do admin
            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");

            builder.Entity<User>().HasData(adminUser);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRole.Id }
            );
        }
    }
}
