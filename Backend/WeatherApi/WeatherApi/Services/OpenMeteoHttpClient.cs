using System.Net.Http.Json;
using WeatherApi.Models;

namespace WeatherApi.Services;

public class OpenMeteoHttpClient : IOpenMeteoHttpClient
{
    private const double Latitude = 32.78;
    private const double Longitude = -96.8;

    private readonly HttpClient _httpClient;

    public OpenMeteoHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OpenMeteoResponse?> GetWeatherAsync(string date)
    {
        var url =
            $"v1/archive?latitude={Latitude}&longitude={Longitude}" +
            $"&start_date={date}&end_date={date}" +
            $"&daily=temperature_2m_min,temperature_2m_max,precipitation_sum" +
            $"&timezone=auto";

        return await _httpClient
            .GetFromJsonAsync<OpenMeteoResponse>(url);
    }
}
