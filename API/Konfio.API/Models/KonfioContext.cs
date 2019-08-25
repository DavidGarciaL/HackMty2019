using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Konfio.API.Models
{
    public partial class KonfioContext : DbContext
    {
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }

        public KonfioContext(DbContextOptions<KonfioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Ccyfx)
                    .HasColumnName("ccyfx")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccyisocode)
                    .HasColumnName("ccyisocode")
                    .HasMaxLength(255);

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(255);

                entity.Property(e => e.Emisorname)
                    .HasColumnName("emisorname")
                    .HasMaxLength(255);

                entity.Property(e => e.Emisorrfc)
                    .HasColumnName("emisorrfc")
                    .HasMaxLength(255);

                entity.Property(e => e.Paymentmethod)
                    .HasColumnName("paymentmethod")
                    .HasMaxLength(255);

                entity.Property(e => e.Paymenttype)
                    .HasColumnName("paymenttype")
                    .HasMaxLength(255);

                entity.Property(e => e.Placegenerated).HasColumnName("placegenerated");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Receptorname)
                    .HasColumnName("receptorname")
                    .HasMaxLength(255);

                entity.Property(e => e.Receptorrfc)
                    .HasColumnName("receptorrfc")
                    .HasMaxLength(255);

                entity.Property(e => e.Rfc)
                    .HasColumnName("rfc")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Rfc)
                    .HasName("UN_User_RFC")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("rfc")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingExt(modelBuilder);
        }

        partial void OnModelCreatingExt(ModelBuilder modelBuilder);
    }
}
