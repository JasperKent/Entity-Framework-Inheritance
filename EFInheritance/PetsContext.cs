using Microsoft.EntityFrameworkCore;

namespace EFInheritance
{
    public class PetsContext : DbContext
    {
        public PetsContext()
        {

        }

        public PetsContext(DbContextOptions<PetsContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().ToTable("Dogs");
            modelBuilder.Entity<Cat>().ToTable("Cats");
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}
