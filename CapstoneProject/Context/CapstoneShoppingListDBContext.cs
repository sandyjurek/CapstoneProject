using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CapstoneProject.Models;

namespace CapstoneProject.Context
{
    public partial class CapstoneShoppingListDBContext : DbContext
    {
        public CapstoneShoppingListDBContext()
        {
        }

        public CapstoneShoppingListDBContext(DbContextOptions<CapstoneShoppingListDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductList> ProductList { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }
        public virtual DbSet<ShoppingListDetails> ShoppingListDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HM2W0G2;Database=CapstoneShoppingListDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnType("decimal(30, 2)");

                entity.Property(e => e.Product)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });




            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ShoppingListDetailId).HasColumnName("ShoppingListDetailID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ShoppingListDetail)
                    .WithMany(p => p.ShoppingList)
                    .HasForeignKey(d => d.ShoppingListDetailId)
                    .HasConstraintName("FK__ShoppingL__Shopp__2A4B4B5E");
            });

            modelBuilder.Entity<ShoppingListDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingListDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShoppingL__Produ__267ABA7A");
            });






            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
