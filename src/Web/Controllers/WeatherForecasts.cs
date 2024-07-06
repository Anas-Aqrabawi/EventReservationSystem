using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.IServices;
using SampleProject.Domain.Entities;

namespace SampleProject.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WeatherForecasts : ApiController
{
    private readonly IWeatherforcastService _weatherforcastService;

    public WeatherForecasts(IWeatherforcastService weatherforcastService)
    {
        _weatherforcastService = weatherforcastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        return await _weatherforcastService.GetWeatherData();
    }
}
