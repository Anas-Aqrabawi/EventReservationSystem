using SampleProject.Application.Common.Interfaces;
using SampleProject.Application.IRepositries;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Repositires;
public class WeatherforcastRepositry : IWeatherforcastRepositry
{
    private readonly IDbContext _dbContext;
    private static readonly string[] Summaries = new[]
   {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherforcastRepositry(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherData()
    {
        await Task.CompletedTask;
        var result = _dbContext.Connection; // fefe fe f fdfdf 
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        });
    }
}
