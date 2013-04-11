using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ScrumProject.Models.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            this.HasKey(t => t.CarID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Manufacturer)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Car");
            this.Property(t => t.CarID).HasColumnName("CarID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Manufacturer).HasColumnName("Manufacturer");
        }
    }
}
