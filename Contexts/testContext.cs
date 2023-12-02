using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using test_backend_11_2023.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace test_backend_11_2023.Contexts
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tovar> Tovar { get; set; }
        public virtual DbSet<Tovarvzakaze> Tovarvzakaze { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=P@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tovar>(entity =>
            {
                entity.ToTable("tovar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(5000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Tovarvzakaze>(entity =>
            {
                entity.ToTable("tovarvzakaze");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TovarId).HasColumnName("tovar_id");

                entity.Property(e => e.ZakazId).HasColumnName("zakaz_id");

                entity.HasOne(d => d.Tovar)
                    .WithMany(p => p.Tovarvzakaze)
                    .HasForeignKey(d => d.TovarId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("tovarvzakaze_tovar_id_fkey");

                entity.HasOne(d => d.Zakaz)
                    .WithMany(p => p.Tovarvzakaze)
                    .HasForeignKey(d => d.ZakazId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("tovarvzakaze_zakaz_id_fkey");
            });

            modelBuilder.Entity<Zakaz>(entity =>
            {
                entity.ToTable("zakaz");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasColumnName("client")
                    .HasMaxLength(1000);

                entity.Property(e => e.Createdate).HasColumnName("createdate");

                entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
