using FitnessApI.Dtos;
using FitnessApI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TraineesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var trainees = await _context.Trainees.ToListAsync();
            return Ok(trainees);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddTraineeDto dto)
        {
            var trainee = new Trainee();
            trainee = dto.trainee;
            await _context.AddAsync(trainee);
            _context.SaveChanges();
            return Ok(trainee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, AddTraineeDto dto)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
                return NotFound($"No Trainee was Found with ID : {id}");

            trainee.Gmail = dto.trainee.Gmail;
            trainee.Password = dto.trainee.Password;
            trainee.Gender = dto.trainee.Gender;
            trainee.Purpose = dto.trainee.Purpose;
            trainee.HasTools = dto.trainee.HasTools;
            trainee.DateOfBirth = dto.trainee.DateOfBirth;
            trainee.Height = dto.trainee.Height;
            trainee.Weight = dto.trainee.Weight;
            trainee.FitnessLevel = dto.trainee.FitnessLevel;
            trainee.RequiredCalories = dto.trainee.RequiredCalories;
            trainee.AvailabaleDays = dto.trainee.AvailabaleDays;
            trainee.TraineeSports = dto.trainee.TraineeSports;
            trainee.TraineeFoods = dto.trainee.TraineeFoods;

            _context.SaveChanges();
            return Ok(trainee);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
                return NotFound($"No Trainee was Found with ID : {id}");
            _context.Trainees.Remove(trainee);
            _context.SaveChanges();
            return Ok(trainee);

        }
    }
}
