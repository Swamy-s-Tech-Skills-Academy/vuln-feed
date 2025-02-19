﻿namespace VulnFeed.Web.Representations;

public class ComponentVersionRep
{
    public ComponentVersionRep(string componentCpe, string versionCpe, string? componentName, string? versionName)
    {
        ComponentCpe = componentCpe ?? throw new ArgumentNullException(nameof(componentCpe));
        VersionCpe = versionCpe ?? throw new ArgumentNullException(nameof(versionCpe));
        ComponentName = componentName;
        VersionName = versionName;
    }

    public string ComponentCpe { get; }
    public string VersionCpe { get; }
    public string? ComponentName { get; }
    public string? VersionName { get; }
}