using Microsoft.AspNetCore.Http;

namespace VulnFeed.Common.Http;

public sealed class LinkGenerator(IHttpContextAccessor contextAccessor)
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));

    public Uri GenerateUri(params string[] pathComponents)
    {
        var httpContext = _contextAccessor.HttpContext ?? throw new InvalidOperationException("HTTP context is not available.");

        var request = httpContext.Request;
        var host = request.Host;

        // Build the base URI using scheme, host, and port (if any)
        var baseUri = $"{request.Scheme}://{host.Host}" + (host.Port.HasValue ? $":{host.Port.Value}" : string.Empty);

        // Join path components using '/' as separator, ensuring no duplicate slashes.
        var relativePath = string.Join("/", pathComponents.Select(pc => pc.Trim('/')));

        return new Uri(new Uri(baseUri), relativePath);
    }
}