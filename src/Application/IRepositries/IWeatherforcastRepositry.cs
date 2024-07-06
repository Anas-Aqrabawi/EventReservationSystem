using SampleProject.Domain.Entities;

namespace SampleProject.Application.IRepositries;
public interface IWeatherforcastRepositry
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherData();
}
