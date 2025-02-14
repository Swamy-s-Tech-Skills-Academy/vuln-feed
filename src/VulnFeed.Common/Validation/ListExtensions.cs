using System.Diagnostics.CodeAnalysis;

namespace VulnFeed.Common.Validation;

public static class ListExtensions
{
    public static IList<TElement> RequireNonEmptyParam<TElement>([NotNull] this IList<TElement>? list, string paramName)
    {
        // Throw if list is null
        ArgumentNullException.ThrowIfNull(list, paramName);

        // Check for empty list using Count (faster than .Any())
        if (list.Count == 0)
        {
            throw new ArgumentException($"{paramName} cannot be empty.", paramName);
        }

        return list;
    }
}