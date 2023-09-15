using Microsoft.EntityFrameworkCore;

namespace WebRazorCF.Models
{
    public class CustomerDbContext :DbContext
    {
#region les constrcuteurs à ajouter obligatoirement 
        public CustomerDbContext()
        {
            
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options
            ):base(options)
        {
            
        }
        #endregion

        #region entités

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=PC2023\SQLEXPRESS;Database=CustomersDB;Trusted_Connection=True;TrustServerCertificate=True");


        protected override void OnModelCreating(ModelBuilder mbuilder)
        {
            //Définition de la clé primaire pour l'ensemble User-Customer-Employee
            mbuilder.Entity<User>().HasKey(c => c.Id);
            mbuilder.Entity<User>().Property(c => c.Id).ValueGeneratedOnAdd();
            mbuilder.Entity<User>().Property(c => c.Name)
                .HasMaxLength(50).IsRequired();

            //Définition de la table Customers avec API Fluent 
            mbuilder.Entity<Customer>().Property(c => c.City)
               .HasMaxLength(50);
            mbuilder.Entity<Customer>().Property(c => c.Country)
               .HasMaxLength(50);


            //Définition de la table Produits avec API Fluent
            mbuilder.Entity<Product>().ToTable("Products");
            mbuilder.Entity<Product>().HasKey(c => c.Id);
            mbuilder.Entity<Product>().Property(c => c.Id).ValueGeneratedOnAdd();
            mbuilder.Entity<Product>().Property(c => c.Name)
                .HasMaxLength(20).IsRequired();
            mbuilder.Entity<Product>().Property(c => c.Price)
                .HasColumnType("money");

            //Definition de la relation de supervison employee(1) => superviseur(*)
            mbuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany(e => e.Employees)
                .HasForeignKey(e=>e.ManagerId);
            
            
            //Définition de l'heritage (stratégie table per heritage)
            mbuilder.Entity<User>()
                   .HasDiscriminator(u => u.Descriminator)
                   .HasValue<Customer>("C")
                   .HasValue<Employee>("E");

         //Définition de la cardinalité Customer(1) => Product(*)
            mbuilder.Entity<Product>().HasOne(p => p.Customer)
                .WithMany(c => c.Products)
                .HasForeignKey(p=>p.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(mbuilder);
        }




    }
}
