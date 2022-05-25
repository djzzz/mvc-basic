using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.ManyToMany
{
    public class CreateLanguagePeopleViewModel
    {
        [Required]
        public int? Language { get; set; }

        public int? People { get; set; }
    }
}
