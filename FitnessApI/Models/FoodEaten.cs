using System.ComponentModel.DataAnnotations;

namespace FitnessApI.Models
{
    public class FoodEaten
    {
        [Key]
        public int id { get; set; }
        public int foodId { get; set; }
        public double quantity { get; set; }

    }
}
