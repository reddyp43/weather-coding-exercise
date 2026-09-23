using System.Text.Json.Serialization;

namespace WeatherApi.Models;

public class OpenMeteoResponse
{
    [JsonPropertyName("daily")]
    public DailyWeather? Daily { get; set; }
}

public class DailyWeather
{
    [JsonPropertyName("time")]
    public string[] Time { get; set; } = [];

    [JsonPropertyName("temperature_2m_min")]
    public double?[] MinimumTemperature { get; set; } = [];

    [JsonPropertyName("temperature_2m_max")]
    public double?[] MaximumTemperature { get; set; } = [];

    [JsonPropertyName("precipitation_sum")]
    public double?[] PrecipitationSum { get; set; } = [];
}
