using Microsoft.AspNetCore.Mvc;
using VulnFeed.Domain.Interfaces.Services;
using VulnFeed.Web.Endpoints;

namespace VulnFeed.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class VulnerabilitiesController(IVulnerabilityFeedService vulnerabilityFeedService, VulnerabilityFeedEndpoints endpoints) : ControllerBase
{

    private readonly IVulnerabilityFeedService _vulnerabilityFeedService = vulnerabilityFeedService ?? throw new ArgumentNullException(nameof(vulnerabilityFeedService));
    private readonly VulnerabilityFeedEndpoints _endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));

    //[HttpGet]
    //public async Task<ActionResult<ApiPage<FullVulnerabilityRep>>> GetVulnerabilities(
    //    [FromQuery] string? cveId,
    //    [FromQuery] int pageNum = 1,
    //    [FromQuery] int pageSize = 25)
    //{
    //    var pageError = CheckPagingParameters(pageNum, pageSize);
    //    if (pageError != null)
    //    {
    //        return BadRequest(pageError);
    //    }

    //    // Retrieve vulnerabilities from the service (assumes a tuple with metadata and list is returned)
    //    var (_, vulns) = await _vulnerabilityFeedService.GetVulnerabilities(cveId, pageNum, pageSize);

    //    // Convert domain entities to API representations using extension methods.
    //    var reps = vulns.Select(v => v.FromDomain(_endpoints)).ToList();
    //    var page = new ApiPage<FullVulnerabilityRep>(reps);

    //    return Ok(page);
    //}

    [HttpPost]
    public async Task<ActionResult<FullVulnerabilityRep>> CreateVulnerability([FromBody] FullVulnerabilityRep vulnRep)
    {
        if (vulnRep == null)
        {
            return BadRequest("Invalid vulnerability data.");
        }

        // Convert the API representation to a domain entity.
        var vulnEntity = vulnRep.ToVulnerability();
        var vuln = await _vulnerabilityFeedService.AddOrUpdateVulnerability(vulnEntity);

        // Convert the domain entity back to an API representation.
        var resultRep = vuln.FromDomain(_endpoints);
        return Ok(resultRep);
    }

    //[HttpGet("{id:long}")]
    //public async Task<ActionResult<FullVulnerabilityRep>> GetVulnerability([FromRoute] long id)
    //{
    //    var vulnerability = await _vulnerabilityFeedService.GetVulnerability(id);
    //    if (vulnerability == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(vulnerability.FromDomain(_endpoints));
    //}

    //private static ApiErrorRep? CheckPagingParameters(int pageNum, int pageSize)
    //{
    //    if (pageNum < 1)
    //    {
    //        return new ApiErrorRep("Parameters 'pageNum' must be at least 1");
    //    }

    //    if (pageSize < 1)
    //    {
    //        return new ApiErrorRep("Parameters 'pageSize' must be at least 1");
    //    }

    //    return null;
    //}

}
