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
        public void Add(Car car)
        {
            _context.cars.Add(car);
            _context.SaveChanges();
        }

        public Car Find(int key)
        {
            var cars = _context.cars.Find(key);

            //if (cars == null)
            //{
            //    return NotFound();
            //}

            return cars;
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = _context.cars.ToList();
            return cars;
        }

        public Car Remove(int id)
        {
            var todoItem = _context.cars.Find(id);

            _context.cars.Remove(todoItem);
            _context.SaveChanges();
            return todoItem;
        }

        public void Update(int id, Car car)
        {

            var CarModel = _context.cars.Find(id);


            CarModel.CarName = car.CarName;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) when (!CarItemExists(id))
            {

            }
        }

        private bool CarItemExists(long id) =>
        _context.cars.Any(e => e.CarId == id);
    }
}
