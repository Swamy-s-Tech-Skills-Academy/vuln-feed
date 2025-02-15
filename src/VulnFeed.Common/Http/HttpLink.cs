using VulnFeed.Common.Validation;

namespace VulnFeed.Common.Http;

// record without positional parameters
public sealed record HttpLink
{
    public string Rel { get; init; }

    public string Location { get; init; }

    public HttpLink(string rel, string location)
    {
        Rel = rel.RequireNonEmpty(nameof(rel));

        Location = location.RequireNonEmpty(nameof(location));
    }
}