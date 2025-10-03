using Domain.AskForPasta.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethodType> PaymentMethodType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseLog> PurchaseLog { get; set; }
        public DbSet<PurchaseProduct> PurchaseProduct { get; set; }
        public DbSet<PurchaseStatus> PurchaseStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ZipCode).IsRequired().HasMaxLength(8);
                entity.Property(e => e.Street).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Neighborhood).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Number).HasMaxLength(10);
                entity.Property(e => e.Complement).HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(100);
                entity.Property(e => e.State).IsRequired().HasMaxLength(2);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.AddressId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<Address>().WithMany().HasForeignKey(e => e.AddressId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<User>().WithOne().HasForeignKey<Client>(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Amount).IsRequired().HasPrecision(10, 2);
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.Property(e => e.PaymentMethodTypeId).IsRequired();
                entity.Property(e => e.PurchaseId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<PaymentMethodType>().WithMany().HasForeignKey(e => e.PaymentMethodTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Purchase>().WithOne().HasForeignKey<Payment>(e => e.PurchaseId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PaymentMethodType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).IsRequired().HasMaxLength(36);
                entity.Property(e => e.TypeDescription).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).IsRequired().HasMaxLength(36);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ImagePath).IsRequired().HasMaxLength(8000);
                entity.Property(e => e.Price).IsRequired().HasPrecision(10, 2);
                entity.Property(e => e.StockQuantity).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).IsRequired().HasMaxLength(36);
                entity.Property(e => e.CategoryDescription).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<ProductCategoryProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.ProductCategoryId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<ProductCategory>().WithMany().HasForeignKey(e => e.ProductCategoryId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PurchaseDate).IsRequired();
                entity.Property(e => e.ClientId).IsRequired();
                entity.Property(e => e.AddressId).IsRequired();
                entity.Property(e => e.PurchaseStatusId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<Client>().WithMany().HasForeignKey(e => e.ClientId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Address>().WithMany().HasForeignKey(e => e.AddressId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<PurchaseStatus>().WithMany().HasForeignKey(e => e.PurchaseStatusId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PurchaseId).IsRequired();
                entity.Property(e => e.OldStatusId).IsRequired();
                entity.Property(e => e.NewStatusId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<Purchase>().WithMany().HasForeignKey(e => e.PurchaseId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<PurchaseStatus>().WithMany().HasForeignKey(e => e.OldStatusId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<PurchaseStatus>().WithMany().HasForeignKey(e => e.NewStatusId).OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<PurchaseProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PurchaseId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired().HasPrecision(10, 2);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<Purchase>().WithMany().HasForeignKey(e => e.PurchaseId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseStatus>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).IsRequired().HasMaxLength(36);
                entity.Property(e => e.StatusDescription).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NickName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Document).IsRequired().HasMaxLength(14);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CellPhone).IsRequired().HasMaxLength(13);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.EncryptPassword).IsRequired().HasMaxLength(60);
                entity.Property(e => e.UserTypeId).IsRequired();
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);

                entity.HasOne<UserType>().WithMany().HasForeignKey(e => e.UserTypeId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).IsRequired().HasMaxLength(36);
                entity.Property(e => e.TypeDescription).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt);
            });

            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Lasanha", Guid.NewGuid().ToString(), "", 12.89M, 98, DateTime.Now),
                new Product(2, "Rondeli", Guid.NewGuid().ToString(), "", 10.99M, 70,  DateTime.Now)
            );

            modelBuilder.Entity<PaymentMethodType>().HasData(
                new PaymentMethodType(1, Guid.NewGuid().ToString(), "Pix", DateTime.Now),
                new PaymentMethodType(2, Guid.NewGuid().ToString(), "Cartão", DateTime.Now),
                new PaymentMethodType(3, Guid.NewGuid().ToString(), "Dinheiro", DateTime.Now)
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory(1, Guid.NewGuid().ToString(), "Massa", DateTime.Now),
                new ProductCategory(2, Guid.NewGuid().ToString(), "Recheada", DateTime.Now),
                new ProductCategory(3, Guid.NewGuid().ToString(), "Vegetariana", DateTime.Now),
                new ProductCategory(4, Guid.NewGuid().ToString(), "Italiana", DateTime.Now),
                new ProductCategory(5, Guid.NewGuid().ToString(), "Oriental", DateTime.Now)
            );

            modelBuilder.Entity<PurchaseStatus>().HasData(
                new PurchaseStatus(1, Guid.NewGuid().ToString(), "Aberto", DateTime.Now),
                new PurchaseStatus(2, Guid.NewGuid().ToString(), "Processando", DateTime.Now),
                new PurchaseStatus(3, Guid.NewGuid().ToString(), "Cancelado", DateTime.Now),
                new PurchaseStatus(4, Guid.NewGuid().ToString(), "Pago", DateTime.Now)
            );

            modelBuilder.Entity<UserType>().HasData(
                new UserType(1, Guid.NewGuid().ToString(), "Cliente", DateTime.Now),
                new UserType(2, Guid.NewGuid().ToString(), "Funcionário", DateTime.Now),
                new UserType(3, Guid.NewGuid().ToString(), "Proprietário", DateTime.Now)
            );
        }
    }
}

