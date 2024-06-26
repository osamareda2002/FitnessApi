﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FitnessApI.Models
{
    [PrimaryKey(nameof(traineeId),nameof(date))]
    public class DailyActivity
    {
        public int traineeId { get; set; }
        public DateTime date { get; set; }
        public List<FoodEaten> dailyFoodEaten { get; set; } = null!;
        public List<SportDone> dailySportDone { get; set; } = null!;
    }
}
