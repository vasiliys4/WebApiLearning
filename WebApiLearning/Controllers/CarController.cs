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
        readonly ApplicationContext _context;
        public CarController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Geting()
        {
            var cars = await _context.cars.ToListAsync();
            return Ok(cars);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cars = await _context.cars.FindAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post(Car car)
        {
            await _context.cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = car.CarId , name = car.CarName}, car);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Car car)
        {   
            if (id != car.CarId)
            {
                return BadRequest();
            }
            var CarModel = await _context.cars.FindAsync(id);
            if (CarModel == null)
            {
                return NotFound();
            }

            CarModel.CarName = car.CarName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CarItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _context.cars.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.cars.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CarItemExists(long id) =>
         _context.cars.Any(e => e.CarId == id);
    }
}
