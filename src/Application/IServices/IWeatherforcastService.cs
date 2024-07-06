using SampleProject.Domain.Entities;

namespace SampleProject.Application.IServices;
public interface IWeatherforcastService
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherData();
}
