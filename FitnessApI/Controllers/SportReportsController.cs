﻿using FitnessApI.Dtos;
using FitnessApI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SportReportsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddSportReport dto)
        {
            var sportReport = new SportReport();
            sportReport = dto.sportReport;
            await _context.AddAsync(sportReport);


            var dailyActivities = await _context.DailyActivity.ToListAsync();
            bool flag = false;
            foreach (var activity in dailyActivities)
            {
                if (activity.traineeId == sportReport.TraineeId && activity.date == sportReport.DateOfOccurrence)
                {
                    bool flag2 = false;
                    foreach (var f in activity.dailySportDone)
                    {
                        if (f.sportId == sportReport.sportId)
                        {
                            flag2 = true;
                            f.duration+=sportReport.DurationTime;
                        }
                    }
                    if (!flag2)
                    {
                        var sport = new SportDone();
                        sport.sportId = sportReport.sportId;
                        sport.duration = sportReport.DurationTime;
                        activity.dailySportDone.Add(sport);
                    }
                }
            }
            if (!flag)
            {
                var activity = new DailyActivity();
                activity.traineeId = sportReport.TraineeId;
                activity.date = sportReport.DateOfOccurrence;
                activity.dailySportDone = new List<SportDone>{
                    new SportDone()
                    {
                        sportId = sportReport.sportId,
                        duration = sportReport.DurationTime,
                    }
                };
                await _context.DailyActivity.AddAsync(activity);
            }

            _context.SaveChanges();
            return Ok(sportReport);
        }
    }
}
