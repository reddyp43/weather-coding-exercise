using WeatherApi.Models;

namespace WeatherApi.Services;

public interface IWeatherService
{
    Task<List<WeatherResponse>> GetWeatherAsync();
}
