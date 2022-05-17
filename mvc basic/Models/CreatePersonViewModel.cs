using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class CreatePersonViewModel
    {
        public int index;
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Number { get; set; }
        [Required]
        public string? City { get; set; }
        
    }
}
