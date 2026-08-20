using System.Diagnostics.CodeAnalysis;

namespace MyRecipeBook.domain.Extensions
{
    public static class StringExtension
    {
        public static bool IsNotEmpty([NotNullWhen(true)] this string? value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
