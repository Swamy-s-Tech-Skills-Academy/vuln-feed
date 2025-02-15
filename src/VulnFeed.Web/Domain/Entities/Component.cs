namespace VulnFeed.Web.Domain.Entities;

public partial class Component
{
    public Component()
    {
        VulnerabilityFeedComponents = new HashSet<VulnerabilityFeedComponent>();

        VulnerableComponentSummaries = new HashSet<VulnerableComponentSummary>();
    }

    public long ComponentId { get; set; }

    public string ComponentCpe { get; set; }
    
    public string ComponentName { get; set; }

    public virtual ICollection<VulnerabilityFeedComponent> VulnerabilityFeedComponents { get; set; }
    
    public virtual ICollection<VulnerableComponentSummary> VulnerableComponentSummaries { get; set; }
}