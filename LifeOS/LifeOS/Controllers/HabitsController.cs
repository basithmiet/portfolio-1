using LifeOS.Data;
using LifeOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HabitsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Habits.ToList());

        [HttpPost]
        public IActionResult Create(Habit habit)
        {
            _context.Habits.Add(habit);
            _context.SaveChanges();
            return Ok(habit);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            var habit = _context.Habits.Find(id);
            if (habit == null) return NotFound();

            habit.Streak++;
            _context.SaveChanges();

            return Ok(habit);
        }
    }
}
