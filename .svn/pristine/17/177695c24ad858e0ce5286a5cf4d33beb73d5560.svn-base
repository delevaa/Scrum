using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.ViewModels
{
    public class ProjectRolesViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Roles :")]
        public string Role { get; set; }

        public IEnumerable<ProjectRolesViewModel> GetPriorities()
        {
            return new List<ProjectRolesViewModel>
                            {
                                new ProjectRolesViewModel() {Id = "master", Role = "Scrum Master"},
                                new ProjectRolesViewModel() {Id = "owner", Role = "Product Owner"},
                                new ProjectRolesViewModel() {Id = "team", Role = "Team Member"},
                            };
        }
    }
}