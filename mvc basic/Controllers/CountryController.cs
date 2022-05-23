using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Data;
using mvc_basic.Models.Countrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    public class CountryController : Controller
    {
        public CountrysViewModel countrysViewModel = new CountrysViewModel();

        public CountryController(ApplicationDbContext context)
        {
            Context = context;
        }
        private ApplicationDbContext Context { get; }
        public IActionResult Index()
        {
            List<Country> countrys = Context.countrys.Include(i => i.Cities).ToList();
            countrysViewModel.List = countrys;
            return View(countrysViewModel);
        }
    }
}
