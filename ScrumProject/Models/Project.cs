using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.Models
{
    [MetadataType(typeof(ProjectMetadata))]
    public partial class Project
    {
        public Project()
        {
            this.Project_User = new List<Project_User>();
            this.Sprints = new List<Sprint>();
            this.Stories=new List<Story>();
            this.Members=new List<Members>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project_User> Project_User { get; set; }
        public virtual ICollection<Members> Members { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
    internal sealed class ProjectMetadata
    {
        [DisplayName("Project ID")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
       
        public  ICollection<Project_User> Project_User { get; set; }
       
        public  ICollection<Sprint> Sprints { get; set; }

        public  ICollection<Story> Stories { get; set; }
    }
}
