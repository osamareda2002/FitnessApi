using System.ComponentModel.DataAnnotations;

namespace FitnessApI.Models
{
    public class Trainee
    {
        public int TraineeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Purpose { get; set; }
        public bool HasTools { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Range(55, 274)]
        public int Height { get; set; }
        [Range(30, 635)]
        public int Weight { get; set; }
        public string FitnessLevel { get; set; }
        public int RequiredCalories { get; set; }
        public List<string> AvailabaleDays { get; set; } = new List<string>();
        public List<string> TraineeSports { get; set; } = new List<string>();
        public List<string> TraineeFoods { get; set; } = new List<string>();
    }
}
