using Microsoft.EntityFrameworkCore;
using WebApiLearning.Models;

namespace WebApiLearning
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Car> cars { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }
    }
}
