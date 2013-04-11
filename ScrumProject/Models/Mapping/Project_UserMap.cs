using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ScrumProject.Models.Mapping
{
    public class Project_UserMap : EntityTypeConfiguration<Project_User>
    {
        public Project_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);


            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            this.Property(t => t.Role)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Project_User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Role).HasColumnName("Role");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");

            // Relationships
            this.HasOptional(t => t.Project)
                .WithMany(t => t.Project_User)
                .HasForeignKey(d => d.ProjectId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Project_User)
                .HasForeignKey(d => d.UserId);

        }
    }
}
