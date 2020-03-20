using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class ModelContext : DbContext
    {
        public DbSet<PersonCF> Persons { get; set; }
        public DbSet<CustomerCF> Customers { get; set; }
        public DbSet<OrderCF> Orders { get; set; }
        public DbSet<ArtistCF> Artists { get; set; }
        public DbSet<AlbumCF> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Tiberiu\\Documents\\TestPerson.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCF>();

            modelBuilder.Entity<CustomerCF>()
                .HasMany<OrderCF>(od => od.OrderCF)
                .WithOne(c => CustomerCF);

            modelBuilder.Entity<ArtistCF>()
                .HasMany<AlbumCF>(al => al.AlbumCF)
                .WithMany<ArtistCF>(ar => ar.ArtistCF);
        }
    }
}
