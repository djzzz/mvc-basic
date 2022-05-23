using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
using mvc_basic.Data;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Models.Cities;

namespace mvc_basic.Controllers
{
    public class PeopleController : Controller
    {
        public PersonViewModel personViewModel = new PersonViewModel();
        
        public PeopleController(ApplicationDbContext context)
        {
            Context = context;
            personViewModel.cities = context.cities.ToList();
        }
        private ApplicationDbContext Context { get; }
        public IActionResult Index()
        {
            List<People> people = Context.people.Include(i => i.City).ToList();
            personViewModel.List = people;
            ViewData["search"] = false;
            
            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel personViewModelInput)
        {
            CreatePersonViewModel person = personViewModelInput.createPersonView;
            ViewData["search"] = false;
            if (ModelState.IsValid)
            {
                People newPerson = new People { Name = person.Name, Number = (int)person.Number, CityId = (int)person.City};
                Context.people.Add(newPerson);
                Context.SaveChanges();
                return PartialView("_Person", newPerson);
            }

            return null;
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            ViewData["search"] = true;
            List<People> people = Context.people.Include(i => i.City).ToList();
            PersonViewModel searched = new PersonViewModel();
            if (search == null)
            {
                ViewData["search"] = false;
                searched.List = people;
            }
            else
            {
                IEnumerable<People> searchQuary =
                from person in people
                where person.Name == search
                select person;
                searched.List = searchQuary.ToList();
            }

            return PartialView("_PersonContainer", searched);
        }
        [Route("People/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            People person = await Context.people.FindAsync(id);
            if(person == null)
            {
                
            }
            Context.people.Remove(person);
            Context.SaveChanges();
            List<People> people = Context.people.Include(i => i.City).ToList();
            personViewModel.List = people;
            ViewData["search"] = false;
            return PartialView("_PersonContainer", personViewModel);
        }
    }
}
