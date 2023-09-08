using bycoders.cnab.api.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bycoders.cnab.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _context.PopulateDb();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var something = await _context.TransactionTypes.ToListAsync();
            var something2 = await _context.CNABOperations.ToListAsync();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut]
        public async Task Put()
        {
            await _context.CNABOperations.AddAsync(new domain.Entities.CNABOperation
            {
                Card = "c",
                CPF = "d",
                OperationDate = DateTime.Now,                
                StoreName = "my egs",
                StoreOwner = "my fuckin engs",
                Value = 100,
                TransactionTypeId = 1
            });

            await _context.SaveChangesAsync();
        }
    }
}