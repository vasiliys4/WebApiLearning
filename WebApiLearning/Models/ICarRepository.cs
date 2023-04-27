using Microsoft.AspNetCore.Mvc;

namespace WebApiLearning.Models
{
    public interface ICarRepository
    {
        void Add(Car car);
        IEnumerable<Car> GetAll();
        Car Find(int key);
        Car Remove(int id);
        void Update(int id, Car car);
    }
}
