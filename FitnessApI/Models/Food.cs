namespace FitnessApI.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Measure { get; set; }
        public double Grams { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Sat_Fat { get; set; }
        public double Fiber { get; set; }
        public double Carbs { get; set; }
        public string Category { get; set; }

    }
}
