using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumProject.Models
{
    [MetadataType(typeof(ProjectUserMetadata))]
    public partial class Project_User
    {
        [DisplayName("Member Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Role { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
    internal sealed class ProjectUserMetadata
    {
        
         public int Id { get; set; }
        
        public string Role { get; set; }
       
        public Nullable<int> UserId { get; set; }
        
        public Nullable<int> ProjectId { get; set; }
        public  Project Project { get; set; }
        public  User User { get; set; }
    }
}
