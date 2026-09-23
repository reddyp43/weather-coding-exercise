using System.Text.Json;
using WeatherApi.Models;

namespace WeatherApi.Helpers;

public static class WeatherFileStorage
{
    public static async Task<WeatherResponse?> GetAsync(
        string directoryPath,
        string date)
    {
        var filePath = Path.Combine(
            directoryPath,
            $"{date}.json");

        if (!File.Exists(filePath))
            return null;

        var json = await File.ReadAllTextAsync(filePath);

        return JsonSerializer.Deserialize<WeatherResponse>(json);
    }

    public static async Task SaveAsync(
        string directoryPath,
        WeatherResponse weather)
    {
        Directory.CreateDirectory(directoryPath);

        var filePath = Path.Combine(
            directoryPath,
            $"{weather.Date}.json");

        var json = JsonSerializer.Serialize(
            weather,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(filePath, json);
    }
}
