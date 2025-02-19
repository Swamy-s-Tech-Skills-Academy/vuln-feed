﻿using Microsoft.EntityFrameworkCore;
using VulnFeed.Web.Domain.Entities;

namespace VulnFeed.Web.Persistence;

public partial class VulnFeedDbContext(DbContextOptions<VulnFeedDbContext> options) : DbContext(options)
{
    public virtual DbSet<Component> Components => Set<Component>();

    public virtual DbSet<Vulnerability> Vulnerabilities => Set<Vulnerability>();

    public virtual DbSet<VulnerabilityFeedComponent> VulnerabilityFeedComponents => Set<VulnerabilityFeedComponent>();

    public virtual DbSet<VulnerableComponentSummary> VulnerableComponentSummaries => Set<VulnerableComponentSummary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");


        modelBuilder.Entity<Component>(entity =>
        {
            entity.ToTable("component");

            entity.HasIndex(e => e.ComponentCpe, "comp_component_cpe_idx")
                .IsUnique();

            entity.Property(e => e.ComponentId).HasColumnName("component_id");

            entity.Property(e => e.ComponentCpe)
                .IsRequired()
                .HasColumnName("component_cpe");

            entity.Property(e => e.ComponentName).HasColumnName("component_name");
        });

        modelBuilder.Entity<Vulnerability>(entity =>
        {
            entity.ToTable("vulnerability");

            entity.HasIndex(e => e.CveId, "vuln_cve_id_idx")
                .IsUnique();

            entity.Property(e => e.VulnerabilityId).HasColumnName("vulnerability_id");

            entity.Property(e => e.CveId)
                .IsRequired()
                .HasColumnName("cve_id");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");

            entity.Property(e => e.ScoreCvss2)
                .HasPrecision(3, 1)
                .HasColumnName("score_cvss2");

            entity.Property(e => e.ScoreCvss3)
                .HasPrecision(3, 1)
                .HasColumnName("score_cvss3");

            entity.Property(e => e.SeverityCvss2).HasColumnName("severity_cvss2");

            entity.Property(e => e.SeverityCvss3).HasColumnName("severity_cvss3");
        });

        modelBuilder.Entity<VulnerabilityFeedComponent>(entity =>
        {
            entity.ToTable("vulnerability_feed_component");

            entity.Property(e => e.VulnerabilityFeedComponentId).HasColumnName("vulnerability_feed_component_id");

            entity.Property(e => e.ComponentId).HasColumnName("component_id");

            entity.HasOne(d => d.Component)
                .WithMany(p => p.VulnerabilityFeedComponents)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vulnerability_feed_component_component_id_fkey");
        });

        modelBuilder.Entity<VulnerableComponentSummary>(entity =>
        {
            entity.ToTable("vulnerable_component_summary");

            entity.Property(e => e.VulnerableComponentSummaryId).HasColumnName("vulnerable_component_summary_id");

            entity.Property(e => e.ComponentId).HasColumnName("component_id");

            entity.Property(e => e.LatestVulnerableVersionName).HasColumnName("latest_vulnerable_version_name");

            entity.Property(e => e.VulnerabilityId).HasColumnName("vulnerability_id");

            entity.Property(e => e.VulnerableVersionCount).HasColumnName("vulnerable_version_count");

            entity.HasOne(d => d.Component)
                .WithMany(p => p.VulnerableComponentSummaries)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vulnerable_component_summary_component_id_fkey");

            entity.HasOne(d => d.Vulnerability)
                .WithMany(p => p.VulnerableComponentSummaries)
                .HasForeignKey(d => d.VulnerabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vulnerable_component_summary_vulnerability_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


//modelBuilder.Entity<Changelog>(entity =>
//        {
//            entity.ToTable("changelog");

//            entity.Property(e => e.Id).HasColumnName("id");

//entity.Property(e => e.Checksum)
//                .HasMaxLength(32)
//                .HasColumnName("checksum");

//entity.Property(e => e.Description)
//                .IsRequired()
//                .HasMaxLength(200)
//                .HasColumnName("description");

//entity.Property(e => e.InstalledBy)
//                .IsRequired()
//                .HasMaxLength(100)
//                .HasColumnName("installed_by");

//entity.Property(e => e.InstalledOn)
//                .HasColumnName("installed_on")
//                .HasDefaultValueSql("now()");

//entity.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(300)
//                .HasColumnName("name");

//entity.Property(e => e.Success).HasColumnName("success");

//entity.Property(e => e.Type).HasColumnName("type");

//entity.Property(e => e.Version)
//                .HasMaxLength(50)
//                .HasColumnName("version");
//        });
