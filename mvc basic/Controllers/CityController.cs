using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Data;
using mvc_basic.Models;
using mvc_basic.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        public CitiesViewModel citiesViewModel = new CitiesViewModel();

        public CityController(ApplicationDbContext context)
        {
            Context = context;
            
        }
        private ApplicationDbContext Context { get; }
        public IActionResult Index()
        {
            citiesViewModel.Countrys = Context.countrys.ToList();
            List<City> cities = Context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            citiesViewModel.List = cities;
            return View(citiesViewModel);
        }
        [HttpPost]
        public IActionResult Index(CitiesViewModel citiesViewModel)
        {
            CreateCityViewModel city = citiesViewModel.CreateCityViewModel;
            if (ModelState.IsValid)
            {
                City newCity = new City { Name = city.Name, CountryId = (int)city.Country };
                Context.cities.Add(newCity);
                Context.SaveChanges();
            }
            citiesViewModel.Countrys = Context.countrys.ToList();
            List<City> cities = Context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            citiesViewModel.List = cities;
            return View(citiesViewModel);
        }
        [Route("City/Delete/{id}")]
        public async Task<IActionResult> Delete(int id, CitiesViewModel citiesViewModel)
        {
            City city = await Context.cities.FindAsync(id);
            if(city.Peoples != null)
            {
                foreach (People person in city.Peoples)
                {
                    Context.people.Remove(person);
                }
            }
            
            Context.cities.Remove(city);
            Context.SaveChanges();
            citiesViewModel.Countrys = Context.countrys.ToList();
            List<City> cities = Context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            
            citiesViewModel.List = cities;
            return new RedirectResult(url: "/City", permanent: true,
                             preserveMethod: true);
        }
        
        [Route("City/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id, CitiesViewModel citiesViewModel)
        {
            
            City city = await Context.cities.FindAsync(id);
            citiesViewModel.CreateCityViewModel = new CreateCityViewModel { Name = city.Name, Country = city.CountryId };
            citiesViewModel.Countrys = Context.countrys.ToList();
            List<City> cities = Context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            ViewData["id"] = id;
            citiesViewModel.List = cities;
            return View(citiesViewModel);
        }
        
        [Route("City/Edit/Save/{id}")]
        [HttpPost]
        public async Task<IActionResult> Save(int id, CitiesViewModel citiesViewModel)
        {
            
            City city = await Context.cities.FindAsync(id);
            if (ModelState.IsValid)
            {
                city.Name = citiesViewModel.CreateCityViewModel.Name;
                city.CountryId = (int)citiesViewModel.CreateCityViewModel.Country;
                Context.cities.Update(city);
                Context.SaveChanges();
            }
            return new RedirectResult(url: "/City", permanent: true,
                            preserveMethod: false);
        }
    }
}
