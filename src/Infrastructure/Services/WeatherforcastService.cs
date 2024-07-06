using SampleProject.Application.IRepositries;
using SampleProject.Application.IServices;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Services;
public class WeatherforcastService : IWeatherforcastService
{
    private readonly IWeatherforcastRepositry _weatherforcastRepositry;

    public WeatherforcastService(IWeatherforcastRepositry weatherforcastRepositry)
    {
        _weatherforcastRepositry = weatherforcastRepositry;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherData()
    {
        return await _weatherforcastRepositry.GetWeatherData();
    }
}
