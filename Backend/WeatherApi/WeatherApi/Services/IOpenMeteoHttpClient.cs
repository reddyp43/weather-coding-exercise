using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IOpenMeteoHttpClient
    {
        Task<OpenMeteoResponse?> GetWeatherAsync(string date);
    }
}
