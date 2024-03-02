using Microsoft.AspNetCore.Mvc;
using Recipe.Domain.Dtos;
using Recipe.Domain.Interfaces;

namespace RecipeMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IIngredientService _service;
       

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IIngredientService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetAllIngredients")]
        [ProducesResponseType(typeof(IEnumerable<IngredientDTO>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<IngredientDTO>>> GetAllProducts()
        {
            var result = await _service.GetAllIngredientsAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Products not found");
            return NotFound("Products not found");
        }
    }
}