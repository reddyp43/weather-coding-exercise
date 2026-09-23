using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather()
    {
        var weather = await _weatherService.GetWeatherAsync();

        return Ok(weather);
    }
}