using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Cities
{
    public class CreateCityViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Country { get; set; }
    }
}
