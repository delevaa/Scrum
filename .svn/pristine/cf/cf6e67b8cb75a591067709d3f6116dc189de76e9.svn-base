using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ScrumProject.Models.Mapping
{
    public class SprintMap : EntityTypeConfiguration<Sprint>
    {
        public SprintMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Sprint");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DateFrom).HasColumnName("DateFrom");
            this.Property(t => t.DateTo).HasColumnName("DateTo");
            this.Property(t => t.Velocity).HasColumnName("Velocity");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.StoryId).HasColumnName("StoryId");

            // Relationships
            this.HasOptional(t => t.Project)
                .WithMany(t => t.Sprints)
                .HasForeignKey(d => d.ProjectId);
            this.HasOptional(t => t.Story)
                .WithMany(t => t.Sprints)
                .HasForeignKey(d => d.StoryId);

        }
    }
}
