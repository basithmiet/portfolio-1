using LifeOS.Data;
using LifeOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Tasks.ToList());

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            task.IsCompleted = !task.IsCompleted;
            _context.SaveChanges();

            return Ok(task);
        }
    }
}
