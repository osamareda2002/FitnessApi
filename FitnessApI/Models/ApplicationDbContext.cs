using Microsoft.EntityFrameworkCore;

namespace FitnessApI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options) { }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Sport> Sports { get; set; }

    }
}
