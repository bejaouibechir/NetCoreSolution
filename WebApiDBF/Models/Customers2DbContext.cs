//La stratégie table per heritage 
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiDBF.Models;

public partial class Customers2DbContext : DbContext
{
    public Customers2DbContext()
    {
    }

    public Customers2DbContext(DbContextOptions<Customers2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProduct> UserProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=PC2023\\SQLEXPRESS;Database=Customers2DB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("money");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Addresse).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("money");

            /*Exprimer la relation de 1 à plusieurs d'une manière 
             * reflective user(1) => user(*) */
            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_User_User");
        });

        //Exprimer la relation 1 à N
        modelBuilder.Entity<UserProduct>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserProducts_User");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_UserProducts_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
