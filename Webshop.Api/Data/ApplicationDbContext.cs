using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Webshop.Api.Models;

namespace Webshop.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //identityDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasMany<Order>().WithOne(c => c.Customer)
                .HasForeignKey(o => o.CustomerId);

            
            // Setup OrderDetails association table:
            modelBuilder.Entity<OrderDetails>().HasKey(od => new {od.OrderId, od.ProductId});
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(order => order.Products)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(od => od.ProductId);

            // Setup ProductOptions association table:
            modelBuilder.Entity<ProductOptions>().HasKey(po => new {po.OptionId, po.ProductId});
            modelBuilder.Entity<ProductOptions>()
                .HasOne(po => po.Option)
                .WithMany(options => options.Products)
                .HasForeignKey(po => po.OptionId);
            modelBuilder.Entity<ProductOptions>()
                .HasOne(po => po.Product)
                .WithMany(product => product.Options)
                .HasForeignKey(po => po.ProductId);
                
            // Setup ProductCategories association table:
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new {pc.CategoryId, pc.ProductId});
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(pc => pc.CategoryId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(product => product.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
            
            
            SeedData(modelBuilder);
        }

        void SeedData(ModelBuilder modelBuilder)
        {
            // Add some categories:
            modelBuilder.Entity<Category>().HasData(new Category
                {
                    Id = 1,
                    Name = "Origami & paper technology",
                    Description = "",
                    ThumbnailURL = "/images/thumbnails/"
                }
            );

            // Add some products:
            modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = 1,
                    ProductName = "Origami Dinosaurie",
                    ProductDescription = "A fun and easy hobby for you who like to do crafts\n",
                    ProductPrice = 250,
                    Stock = 100,
                    ProductImageUrl = "/images/products/"
                }
            );

            // Add some product options:
            modelBuilder.Entity<Option>().HasData(new Option
                {
                    Id = 1,
                    Name = "Red"
                }
            );

            // Add product category to products:
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
                {
                    ProductId = 1,
                    CategoryId = 1,
                }
            );

            // Add product options to products:
            modelBuilder.Entity<ProductOptions>().HasData(new ProductOptions
                {
                    ProductId = 1,
                    OptionId = 1,
                }
            );

            string adminRoleId = Guid.NewGuid().ToString();
            string adminId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();


            // Add user roles:
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
                {Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
                {Id = userRoleId, Name = "User", NormalizedName = "USER"});

            var hasher = new PasswordHasher<ApplicationUser>();

            // Add an admin user:
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = adminId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "virge3d"),
                FullName = "Admin Adminsson",
                Country = "Sweden",
                PhoneNumber = "031-84468",
                DefaultShippingAddress = "Götgatan 9",
                City = "Göteborg",
                ZipCode = "41105"
            });
            // Add a regular user:
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = userId,
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                UserName = "User",
                NormalizedUserName = "USER",
                PasswordHash = hasher.HashPassword(null, "virge3d"),
                FullName = "User Usersson",
                Country = "Sweden",
                PhoneNumber = "031-84468",
                DefaultShippingAddress = "Götgatan 9",
                City = "Göteborg",
                ZipCode = "412105"
            });
            
            // Set user admin role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId
            });
            
            //Create an order:
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                CustomerId = adminId,
                TotalPrice = 250,
                OrderEmail = "admin@admin.com",
                OrderAddress = "Götgatan 9, 41105 Göteborg",
                ShippingAddress = "Götgatan 9, 41105 Göteborg",
                OrderDate = DateTime.Now,
                OrderStatus = "Order placed"
            });

            modelBuilder.Entity<OrderDetails>().HasData(new OrderDetails
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Price = 250,
                Quantity = 1
            });
        }
    }
}