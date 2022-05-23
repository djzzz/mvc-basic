using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Data;
using mvc_basic.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    public class CityController : Controller
    {
        public CitiesViewModel citiesViewModel = new CitiesViewModel();

        public CityController(ApplicationDbContext context)
        {
            Context = context;
            citiesViewModel.Countrys = context.countrys.ToList();
        }
        private ApplicationDbContext Context { get; }
        public IActionResult Index()
        {
            List<City> cities = Context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            citiesViewModel.List = cities;
            return View(citiesViewModel);
        }
    }
}
