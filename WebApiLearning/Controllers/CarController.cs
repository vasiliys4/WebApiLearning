using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Nodes;
using WebApiLearning.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        readonly ICarRepository CarRepository;
        public CarController(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Geting()
        {       
            return Ok(CarRepository.GetAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(CarRepository.Find(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            CarRepository.Add(car);
            return CreatedAtAction(nameof(Get), new { id = car.CarId , name = car.CarName}, car);
        }

        //// PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Car car)
        {
            if (id != car.CarId || car == null)
            {
                return BadRequest();
            }
            CarRepository.Update(id ,car);

            return NoContent();
        }

        //// DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = CarRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            CarRepository.Remove(id);
            return NoContent();
        }
    }
}
