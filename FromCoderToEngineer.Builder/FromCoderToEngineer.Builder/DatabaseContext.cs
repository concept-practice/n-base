namespace FromCoderToEngineer.Builder
{
    using System;
    using Airplanes;
    using Microsoft.EntityFrameworkCore;

    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
             : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(
                new Airplane(Guid.NewGuid(), "Boeing", "737-8"),
                new Airplane(Guid.NewGuid(), "Airbus", "A320N"),
                new Airplane(Guid.NewGuid(), "Boeing", "737-8"),
                new Airplane(Guid.NewGuid(), "Airbus", "A320N"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
