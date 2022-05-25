using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Languages
{
    public class CreateLanguageViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
