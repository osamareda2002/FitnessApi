using Microsoft.EntityFrameworkCore;

namespace FitnessApI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options) { }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<FoodReport> FoodReports { get; set; }
        public DbSet<SportReport> SportReports { get; set; }
        public DbSet<DailyActivity> DailyActivity { get; set; }
        public DbSet<FoodEaten> FoodEatens { get; set; }
        public DbSet<SportDone> SportDones { get; set; }

    }
}
