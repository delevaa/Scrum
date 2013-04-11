using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScrumProject.ViewModels
{
    public class BitStatusViewModel
    {
        public bool Id { get; set; }

        [Required]
        [Display(Name = "Status :")]
        public string StatusCode { get; set; }

        public IEnumerable<BitStatusViewModel> GetStatus()
        {
            return new List<BitStatusViewModel>
                            {
                                new BitStatusViewModel() {Id = true, StatusCode = "active"},
                                new BitStatusViewModel() {Id = false, StatusCode = "inactive"},
                            };
        }

    }
}