using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ScrumProject.Models.Mapping
{
    public class StoryMap : EntityTypeConfiguration<Story>
    {
        public StoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Priority)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Status)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Story");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Tests).HasColumnName("Tests");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.BusinessValue).HasColumnName("BusinessValue");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
