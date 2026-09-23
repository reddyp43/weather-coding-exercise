using System.Globalization;

namespace WeatherApi.Helpers;

public static class DateParser
{
    private static readonly string[] SupportedFormats =
    {
        "MM/dd/yyyy",
        "MMMM d, yyyy",
        "MMM-dd-yyyy"
    };

    public static bool TryParseAndNormalize(
        string input,
        out string normalizedDate)
    {
        normalizedDate = string.Empty;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        if (!DateTime.TryParseExact(
                input.Trim(),
                SupportedFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var parsedDate))
        {
            return false;
        }

        normalizedDate = parsedDate.ToString(
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture);

        return true;
    }
}