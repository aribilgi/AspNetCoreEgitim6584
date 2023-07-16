using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // bu metot uygulama veritabanı ayarlarının yapılandırılması için
            optionsBuilder.UseSqlServer(@"Server=.; database=WebApplication1; trusted_connection=true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // bu metot veritabanı tablolarının yapılandırılması, tablo oluştuktan sonra başlangıç kaydı oluşturulması gibi ayarlar için
            // Aşağıdaki yapının ismi FluentAPI dir, .net içerisinde yer alır ve veritabanı tablo kolonlarını ayarlamamızı sağlar
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(c => c.Image).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(c => c.Surname).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(c => c.Email).HasMaxLength(50);
            modelBuilder.Entity<User>().HasData( // HasData metodu db oluştuktan sonra db ye kayıt oluşturmak için data seed işlemi yapar
                new User
                {
                    Id = 1,
                    Email = "admin@aribilgi.co",
                    Name = "Admin",
                    Password = "1236"
                }
            );
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Elektronik"
            },
            new Category
            {
                Id = 2,
                Name = "Bilgisayar"
            }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
