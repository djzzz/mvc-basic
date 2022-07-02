using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Data;
using mvc_basic.Models;
using mvc_basic.Models.Cities;
using mvc_basic.Models.Countrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [HttpPost]
        public IActionResult Index(CountrysViewModel countrysViewModel)
        {
            CreateCountryViewModel country = countrysViewModel.CreateCountryViewModel;
            if (ModelState.IsValid)
            {
                Country newCountry = new Country { Name = country.Name };
                Context.countrys.Add(newCountry);
                Context.SaveChanges();
            }
            List<Country> countrys = Context.countrys.Include(i => i.Cities).ToList();
            countrysViewModel.List = countrys;
            return View(countrysViewModel);
        }
        [Route("Country/Delete/{id}")]
        public async Task<IActionResult> Delete(int id, CountrysViewModel countrysViewModel)
        {
            Country Country = await Context.countrys.FindAsync(id);
            if(Country.Cities != null)
            {
                foreach (City city in Country.Cities)
                {
                    if (city.Peoples != null)
                    {
                        foreach (People person in city.Peoples)
                        {
                            Context.people.Remove(person);
                        }
                    }
                    Context.cities.Remove(city);
                }
            }
            
            Context.countrys.Remove(Country);
            Context.SaveChanges();
            return new RedirectResult(url: "/Country", permanent: true,
                             preserveMethod: false);
        }
        [Route("Country/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id, CountrysViewModel countrysViewModel)
        {

            Country country = await Context.countrys.FindAsync(id);
            countrysViewModel.CreateCountryViewModel = new CreateCountryViewModel { Name = country.Name };
            List<Country> countrys = Context.countrys.Include(i => i.Cities).ToList();
            countrysViewModel.List = countrys;
            ViewData["id"] = id;
            return View(countrysViewModel);
        }

        [Route("Country/Edit/Save/{id}")]
        [HttpPost]
        public async Task<IActionResult> Save(int id, CountrysViewModel countrysViewModel)
        {

            Country country = await Context.countrys.FindAsync(id);
            if (ModelState.IsValid)
            {
                country.Name = countrysViewModel.CreateCountryViewModel.Name;
                Context.countrys.Update(country);
                Context.SaveChanges();
            }
            return new RedirectResult(url: "/Country", permanent: false,
                            preserveMethod: false);
        }
    }
    
}
