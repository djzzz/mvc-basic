using mvc_basic.Models.Countrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Cities
{
    public class CitiesViewModel
    {
        public List<City> List { get; set; }
        public CreateCityViewModel CreateCityViewModel { get; set; }
        public List<Country> Countrys { get; set; }
    }
}
