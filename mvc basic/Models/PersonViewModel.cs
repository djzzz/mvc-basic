using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class PersonViewModel
    {
        public List<People> List { get; set;}
        public CreatePersonViewModel createPersonView { get; set; }
    }
}
