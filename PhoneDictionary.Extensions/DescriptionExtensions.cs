using System.ComponentModel;

namespace PhoneDictionary.Extensions
{
    public static class DescriptionExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            var field = source.GetType().GetField(source?.ToString() ?? string.Empty);

            var attributes = (DescriptionAttribute[]) field?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}