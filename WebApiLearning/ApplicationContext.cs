using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApiLearning.Models;

namespace WebApiLearning
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<Motor> motor { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
            .HasOne(e => e.Motor)
            .WithOne()
        .HasForeignKey<Motor>(e => e.CarId)
        .IsRequired();
        }
    }
}
