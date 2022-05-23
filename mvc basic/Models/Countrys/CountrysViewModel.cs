using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Countrys
{
    public class CountrysViewModel
    {
        public List<Country> List { get; set; }
        public CreateCountryViewModel CreateCountryViewModel { get; set; }
    }
}
