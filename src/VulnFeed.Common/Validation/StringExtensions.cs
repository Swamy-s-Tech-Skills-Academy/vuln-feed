using System.Diagnostics.CodeAnalysis;

namespace VulnFeed.Common.Validation;

public static class StringExtensions
{
    public static string RequireNonEmpty([NotNull] this string? value, string paramName)
    {
        // Throw if value is null or whitespace (using .NET built-in validation)
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);

        return value;
    }
}