using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumProject.Models
{
    [MetadataType(typeof(MembersMetadata))]
    public partial class Members
    {
        [DisplayName("Member Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
    internal sealed class MembersMetadata
    {

        public int Id { get; set; }

        public string Role { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}