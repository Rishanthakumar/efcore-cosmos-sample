
using EFCoreCosmosSample.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EFCoreCosmosSample.Infrastructure.Contexts
{
    public class FamilyContext: DbContext
    {
        public FamilyContext()
        { 
        }

        public FamilyContext(DbContextOptions<FamilyContext> options): base(options)
        {
           this.Database.EnsureCreated();
        }

        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .ToContainer("Families");

            modelBuilder.Entity<Family>()
                .Property(f => f.Id)
                .HasConversion<string>()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<Family>()
                .HasPartitionKey(nameof(Family.Id))
                .OwnsMany(f => f.Parents);

            modelBuilder.Entity<Family>()
                .OwnsMany(f => f.Children)
                    .OwnsMany(c => c.Pets);

            modelBuilder.Entity<Family>()
                .OwnsOne(f => f.Address);
        }
    }
}
