using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var rng = new Random();
            var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
            return forecast;
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {

            // Add data to storage (e.g., database)

            return Ok(forecast);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherForecast forecast)
        {

            // Update data for the given ID

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            // Delete data for the given ID
            return NoContent();

        }
    }
}


