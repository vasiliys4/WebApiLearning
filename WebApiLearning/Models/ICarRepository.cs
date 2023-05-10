using Microsoft.AspNetCore.Mvc;

namespace WebApiLearning.Models
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> FindAsync(int id);
        Task<Car> RemoveAsync(int id);
        Task UpdateAsync(int id, Car car);
    }
}