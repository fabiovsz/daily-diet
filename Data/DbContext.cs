using daily_diet.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_diet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}
