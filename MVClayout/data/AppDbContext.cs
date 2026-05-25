using Microsoft.EntityFrameworkCore;
using MVClayout.Models;

namespace MVClayout.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory> Categories => Set<ProductCategory>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Username).HasMaxLength(50).IsRequired();
                entity.HasIndex(x => x.Username).IsUnique();
                entity.Property(x => x.Email).HasMaxLength(150).IsRequired();
                entity.HasIndex(x => x.Email).IsUnique();
                entity.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();
                entity.Property(x => x.FullName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Phone).HasMaxLength(20);
                entity.Property(x => x.Address).HasMaxLength(300);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(150).IsRequired();
                entity.Property(x => x.Description).HasMaxLength(500);
                entity.Property(x => x.ImageUrl).HasMaxLength(255).IsRequired();
                entity.Property(x => x.Badge).HasMaxLength(30);
                entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
                entity.Property(x => x.OldPrice).HasColumnType("decimal(18,2)");
                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CustomerName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Phone).HasMaxLength(20).IsRequired();
                entity.Property(x => x.Address).HasMaxLength(300).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(150);
                entity.Property(x => x.Note).HasMaxLength(500);
                entity.Property(x => x.TotalAmount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ProductName).HasMaxLength(150).IsRequired();
                entity.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Ignore(x => x.LineTotal);
                entity.HasOne(x => x.Order)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Vegetables", Description = "Fresh vegetables for daily meals." },
                new ProductCategory { Id = 2, Name = "Fruits", Description = "Seasonal fruits selected from trusted farms." },
                new ProductCategory { Id = 3, Name = "Fresh Food", Description = "Healthy organic products ready for your kitchen." }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Fresh Tomato",
                    Description = "Ripe tomatoes with bright flavor, perfect for salads and sauces.",
                    ImageUrl = "~/img/product-1.jpg",
                    Price = 39000,
                    OldPrice = 59000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Fresh Pineapple",
                    Description = "Sweet and juicy pineapple, great for dessert and juice.",
                    ImageUrl = "~/img/product-2.jpg",
                    Price = 49000,
                    OldPrice = 65000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Organic Chili",
                    Description = "Fresh organic chili for spicy and flavorful cooking.",
                    ImageUrl = "~/img/product-3.jpg",
                    Price = 35000,
                    OldPrice = 50000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Sweet Strawberry",
                    Description = "Fresh strawberries with natural sweetness and aroma.",
                    ImageUrl = "~/img/product-4.jpg",
                    Price = 69000,
                    OldPrice = 89000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "Fresh Cucumber",
                    Description = "Crunchy cucumber for salads and healthy snacks.",
                    ImageUrl = "~/img/product-5.jpg",
                    Price = 32000,
                    OldPrice = 45000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 1,
                    Name = "Vine Tomato",
                    Description = "Bright red vine tomato for daily family meals.",
                    ImageUrl = "~/img/product-6.jpg",
                    Price = 37000,
                    OldPrice = 52000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 1,
                    Name = "Baby Potato",
                    Description = "Soft and creamy baby potatoes for roasting and soup.",
                    ImageUrl = "~/img/product-7.jpg",
                    Price = 46000,
                    OldPrice = 62000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 8,
                    CategoryId = 2,
                    Name = "Garden Banana",
                    Description = "Naturally sweet bananas for snacks and smoothies.",
                    ImageUrl = "~/img/product-8.jpg",
                    Price = 42000,
                    OldPrice = 56000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 3,
                    Name = "Fresh Salmon",
                    Description = "Premium fresh salmon fillet, rich in Omega-3 and protein.",
                    ImageUrl = "~/img/product-1.jpg",
                    Price = 189000,
                    OldPrice = 250000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 10,
                    CategoryId = 3,
                    Name = "Organic Chicken Breast",
                    Description = "Free-range organic chicken breast, tender and healthy.",
                    ImageUrl = "~/img/product-2.jpg",
                    Price = 95000,
                    OldPrice = 130000,
                    Badge = "New"
                },
                new Product
                {
                    Id = 11,
                    CategoryId = 3,
                    Name = "Farm Fresh Eggs",
                    Description = "Free-range eggs from local organic farms, pack of 10.",
                    ImageUrl = "~/img/product-3.jpg",
                    Price = 55000,
                    OldPrice = 75000,
                    Badge = "New"
                }
            );
        }
    }
}
