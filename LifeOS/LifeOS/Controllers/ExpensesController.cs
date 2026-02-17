using LifeOS.Data;
using LifeOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Expenses.ToList());

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return Ok(expense);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null) return NotFound();

            // Mark expense as refunded by zeroing the amount and updating the date
            expense.Amount = 0;
            expense.Date = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok(expense);
        }
    }
}
