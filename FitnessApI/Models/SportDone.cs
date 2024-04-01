using System.ComponentModel.DataAnnotations;

namespace FitnessApI.Models
{
    public class SportDone
    {
        [Key]
        public int id { get; set; }
        public int sportId { get; set; }
        public double duration { get; set; }
    }
}
