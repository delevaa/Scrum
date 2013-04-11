using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;


namespace ScrumProject.Models
{
    [MetadataType(typeof(UserMetadata))]
     public partial class User
    {
        public User()
        {
            this.Project_User = new List<Project_User>();
            this.Members=new List<Members>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public virtual ICollection<Project_User> Project_User { get; set; }
        public virtual ICollection<Members> Members { get; set; }

    }
    internal sealed class UserMetadata
    {
        [DisplayName("User ID")]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DefaultValue(false)]
        [Required]
        public bool isAdmin { get; set; }

        public ICollection<Project_User> Project_User { get; set; }


    }
}
