using System.Globalization;

namespace Energigas.Api.Osinergmin.Shared.Helpers
{
    public class DateHelper
    {
        private static readonly string[] Formats =
        {
                "yyyy-MM-dd",
                "dd/MM/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy",
                "yyyy-MM-dd HH:mm:ss.ffffff", "yyyy-MM-dd HH:mm:ss.fffff","yyyy-MM-dd HH:mm:ss.ffff", "yyyy-MM-dd HH:mm:ss.fff", "yyyy-MM-dd HH:mm:ss.ff",
                "yyyy-MM-dd HH:mm:ss.f", "HH:mm:ss.fff", "HH:mm:ss", "HH:mm:ss.ffff"
        };

        public static DateTime? ParseDate(string? dateStr)
        {
            if (string.IsNullOrWhiteSpace(dateStr))
                return null;

            if (DateTime.TryParseExact(dateStr, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return date;

            return null;
        }
    }
}
