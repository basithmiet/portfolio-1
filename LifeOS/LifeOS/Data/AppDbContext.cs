using LifeOS.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<Expense> Expenses => Set<Expense>();
    }
}
