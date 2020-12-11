using System.Data.Entity;

namespace EF6TPCInheritance
{
    public class PetsContext : DbContext
    {
        public PetsContext(string connectionString)
            :base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().Map(d =>
            {
                d.MapInheritedProperties();
                d.ToTable("Dogs");
            });

            modelBuilder.Entity<Cat>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Cats");
            });
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}
