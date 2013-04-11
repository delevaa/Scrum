using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.ViewModels
{
    public class PriorityViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Priority :")]
        public string PriorityCode { get; set; }

        public IEnumerable<PriorityViewModel> GetPriorities()
        {
            return new List<PriorityViewModel>
                            {
                                new PriorityViewModel() {Id = "must", PriorityCode = "must have"},
                                new PriorityViewModel() {Id = "should", PriorityCode = "should have"},
                                new PriorityViewModel() {Id = "could", PriorityCode = "could have"},
                                new PriorityViewModel() {Id = "not this time", PriorityCode = "won't have this time"},
                            };
        }
    }
}