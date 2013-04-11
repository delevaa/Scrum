using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.Models
{
    [MetadataType(typeof(StoryMetadata))]
    public partial class Story
    {
        public Story()
        {
            this.Sprints = new List<Sprint>();
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tests { get; set; }
        public string Priority { get; set; }
        public Nullable<double> BusinessValue { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public Nullable<double> Points { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }

    internal sealed class StoryMetadata
    {
        [DisplayName("Story Id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tests { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        [Range(0, 60)]
        public Nullable<double> BusinessValue { get; set; }
        [Required]
        [DefaultValue("inactive")]
        public string Status { get; set; }
        public string Notes { get; set; }
        [DefaultValue(0.0)]
        public Nullable<double> Points { get; set; }
        public ICollection<Sprint> Sprints { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public  Project Project { get; set; }
    }
}
