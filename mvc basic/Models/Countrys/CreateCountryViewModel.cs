using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Countrys
{
    public class CreateCountryViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
