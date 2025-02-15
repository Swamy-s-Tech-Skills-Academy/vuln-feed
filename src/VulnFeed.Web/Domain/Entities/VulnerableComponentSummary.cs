namespace VulnFeed.Web.Domain.Entities;

public partial class VulnerableComponentSummary
{
    public long VulnerableComponentSummaryId { get; set; }

    public long VulnerabilityId { get; set; }

    public long ComponentId { get; set; }

    public string LatestVulnerableVersionName { get; set; }

    public int? VulnerableVersionCount { get; set; }

    public virtual Component Component { get; set; }

    public virtual Vulnerability Vulnerability { get; set; }
}