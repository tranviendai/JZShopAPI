using JZeno.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JZeno.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        const string ADMIN_USER_GUID = "a79e98b4-d8a6-4640-98eb-5b417ffb2661";
        const string ADMIN_ROLE_GUID = "07bf1560-b5ff-4702-a9f1-a64026e570cf";
        const string THUTHU_ROLE_GUID = "2ccdcef3-db18-46c7-b5ff-910be6ae4906";
        private User user;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.HasData(
                    new IdentityRole
                    {
                        Id = ADMIN_ROLE_GUID,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = THUTHU_ROLE_GUID,
                        Name = "EMPLOYEE",
                        NormalizedName = "EMPLOYEE"
                    });
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = ADMIN_ROLE_GUID,
                        UserId = ADMIN_USER_GUID,
                    });
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasData(
            new User
            {
                Id = ADMIN_USER_GUID,
                Image = "https://www.nicepng.com/png/full/128-1280406_view-user-icon-png-user-circle-icon-png.png",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(user, "Admin@123"),
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                FullName = "Trần Viễn Đại",
                PhoneNumber = "0582072743",
                Address = "Tắc Vân - Cà Mau",
                Birthday = DateTime.Now,
                DateCreated = DateTime.Now,
            });
            });
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<DetailOrder> DetailOrder { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<CategoryChild> CategoryChild { get; set; }
    }
}