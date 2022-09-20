using Microsoft.EntityFrameworkCore;

namespace EgnApp.Models
{
    public class EgnContext : DbContext
    {
        public EgnContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egn>()
                .HasData
                (
                 new Egn
                 {
                     Id = Guid.NewGuid(),
                     Name = "Mark",
                     EgnNumber = "1233452134",
                     Age = 30
                 },
                 new Egn
                 {
                     Id = Guid.NewGuid(),
                     Name = "Evelin",
                     EgnNumber = "9384613085",
                     Age = 28
                 }
                );
        }

        public DbSet<Egn>? Egn { get; set; }
    }
}
