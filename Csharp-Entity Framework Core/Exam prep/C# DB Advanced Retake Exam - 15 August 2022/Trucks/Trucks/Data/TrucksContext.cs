namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options) 
        { 
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<ClientTruck> ClientsTrucks { get; set; } = null!;
        public DbSet<Despatcher> Despatchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Truck>(x =>
            //{
            //    x.Property(p => p.TankCapacity >= 950 && p.TankCapacity <= 1420);
            //    x.Property(p => p.CargoCapacity >= 5000 && p.CargoCapacity <= 29000);
            //});
            modelBuilder.Entity<ClientTruck>(x =>
            {
                x.HasKey(p => new { p.ClientId, p.TruckId });
            });
        }
    }
}
