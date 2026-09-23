namespace WeatherApi.Models;

public class WeatherResponse
{
    public required string Date { get; set; }

    public double? MinimumTemperature { get; set; }

    public double? MaximumTemperature { get; set; }

    public double? PrecipitationSum { get; set; }

    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }
}