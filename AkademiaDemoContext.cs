using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AzureDemo
{
    public partial class AkademiaDemoContext : DbContext
    {
        public AkademiaDemoContext()
        {
        }

        public AkademiaDemoContext(DbContextOptions<AkademiaDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=akademia.db");
                    //.UseSqlServer("CONNECTION_STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.About).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
