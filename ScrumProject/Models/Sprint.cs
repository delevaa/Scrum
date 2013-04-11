using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.Models
{
    [MetadataType(typeof(SprintMetadata))]
    public partial class Sprint
    {
        public int Id { get; set; }
        public System.DateTime DateFrom { get; set; }
        public System.DateTime DateTo { get; set; }
        public Nullable<int> Velocity { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> StoryId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Story Story { get; set; }
    }
    internal  sealed class SprintMetadata
    {
        [DisplayName("Sprint Id")]
        public int Id { get; set; }
       
        [Required]
        public System.DateTime DateFrom { get; set; }
        
        [Required]
        public System.DateTime DateTo { get; set; }
        
        [Range(0, 60)]
        public Nullable<int> Velocity { get; set; }
        
        [DefaultValue(false)]
        public Nullable<bool> Status { get; set; }
        
        public  Project Project { get; set; }
        
        public  Story Story { get; set; }

    }
}
