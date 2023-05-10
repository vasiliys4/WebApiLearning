using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiLearning.Models
{
    public class CarRepository : ICarRepository
    {
        readonly ApplicationContext _context;
        public CarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Car car)
        {            
            _context.cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> FindAsync(int id)
        {
            var car = await _context.cars.Include(u => u.Motor).FirstOrDefaultAsync(u => u.Id == id);
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.cars.Include(u => u.Motor).ToListAsync();
            return cars;
        }

        public async Task<Car> RemoveAsync(int id)
        {
            var todoItem = await _context.cars.FindAsync(id);
            _context.cars.Remove(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task UpdateAsync(int id, Car car)
        {
            var CarModel = await _context.cars.FindAsync(id);
            CarModel.CarName = car.CarName;
            CarModel.MaxSpeed = car.MaxSpeed;
            CarModel.Motor = car.Motor;
            await _context.SaveChangesAsync();
        }
    }
}
