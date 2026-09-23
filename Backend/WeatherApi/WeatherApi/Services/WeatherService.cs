using WeatherApi.Helpers;
using WeatherApi.Models;

namespace WeatherApi.Services;

public class WeatherService : IWeatherService
{
    private readonly IOpenMeteoHttpClient _openMeteoHttpClient;
    private readonly IWebHostEnvironment _environment;
    private readonly string _weatherDataDirectory;

    public WeatherService(
        IOpenMeteoHttpClient openMeteoHttpClient,
        IWebHostEnvironment environment)
    {
        _openMeteoHttpClient = openMeteoHttpClient;
        _environment = environment;

        _weatherDataDirectory = Path.Combine(
       environment.ContentRootPath,
       "weather-data");
    }

    public async Task<List<WeatherResponse>> GetWeatherAsync()
    {
        var filePath = Path.Combine(
            _environment.ContentRootPath,
            "dates.txt");

        var dates = await File.ReadAllLinesAsync(filePath);
        var results = new List<WeatherResponse>();

        foreach (var date in dates)
        {
            if (!DateParser.TryParseAndNormalize(date, out var normalizedDate))
            {
                results.Add(new WeatherResponse
                {
                    Date = date,
                    Status = "Error",
                    ErrorMessage = "Invalid date."
                });

                continue;
            }

            results.Add(await GetWeatherForDateAsync(normalizedDate));
        }

        return results;
    }

    private async Task<WeatherResponse> GetWeatherForDateAsync(string date)
    {
        var cachedWeather = await WeatherFileStorage.GetAsync(_weatherDataDirectory, date);

        if (cachedWeather != null)
            return cachedWeather;

        try
        {
            var response = await _openMeteoHttpClient.GetWeatherAsync(date);
            var daily = response?.Daily;

            if (daily == null ||
                daily.MinimumTemperature.Length == 0 ||
                daily.MaximumTemperature.Length == 0 ||
                daily.PrecipitationSum.Length == 0)
            {
                return new WeatherResponse
                {
                    Date = date,
                    Status = "Error",
                    ErrorMessage = "Weather data is unavailable."
                };
            }

            var weather = new WeatherResponse
            {
                Date = date,
                MinimumTemperature = daily.MinimumTemperature[0],
                MaximumTemperature = daily.MaximumTemperature[0],
                PrecipitationSum = daily.PrecipitationSum[0],
                Status = "Success"
            };

            await WeatherFileStorage.SaveAsync(
                _weatherDataDirectory,
                weather);

            return weather;
        }
        catch (HttpRequestException)
        {
            return new WeatherResponse
            {
                Date = date,
                Status = "Error",
                ErrorMessage = "Unable to retrieve weather data."
            };
        }
    }
}