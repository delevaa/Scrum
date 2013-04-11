using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.ViewModels
{
    public class StatusViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Status :")]
        public string StatusCode { get; set; }

        public IEnumerable<StatusViewModel> GetStatus()
        {
            return new List<StatusViewModel>
                            {
                                new StatusViewModel() {Id = "active", StatusCode = "active"},
                                new StatusViewModel() {Id = "inactive", StatusCode = "inactive"},
                                new StatusViewModel() {Id = "finished", StatusCode = "finished"},
                            };
        }
    }
}