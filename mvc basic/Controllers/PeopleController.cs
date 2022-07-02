using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
using mvc_basic.Data;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Models.Cities;
using Microsoft.AspNetCore.Authorization;
using mvc_basic.Models.ManyToMany;

namespace mvc_basic.Controllers
{
    [Authorize()]
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
            List<People> people = Context.people.Include(i => i.City).Include(i => i.LanguagePeople).ThenInclude(i => i.Language).ToList();

            personViewModel.List = people;
            
            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel personViewModelInput)
        {
            CreatePersonViewModel person = personViewModelInput.createPersonView;
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
            List<People> people = Context.people.Include(i => i.City).ToList();
            PersonViewModel searched = new PersonViewModel();
            if (search == null)
            {
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
            if(person.LanguagePeople != null)
            {
                foreach (LanguagePeople languagePeople in person.LanguagePeople)
                {
                    Context.LanguagePeople.Remove(languagePeople);
                }
            }
            
            if (person == null)
            {
                
            }
            Context.people.Remove(person);
            Context.SaveChanges();
            List<People> people = Context.people.Include(i => i.City).ToList();
            personViewModel.List = people;
            ViewData["search"] = false;
            return PartialView("_PersonContainer", personViewModel);
        }

        [Route("People/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id, PersonViewModel personViewModelInput)
        {

            People person = await Context.people.FindAsync(id);
            personViewModelInput.createPersonView = new CreatePersonViewModel { Name = person.Name, Number = person.Number, City = person.CityId };
            ViewData["id"] = id;

            List<People> people = Context.people.Include(i => i.City).Include(i => i.LanguagePeople).ThenInclude(i => i.Language).ToList();

            personViewModelInput.List = people;
            personViewModelInput.cities = Context.cities.ToList();
            return View(personViewModelInput);
        }

        [Route("People/Edit/Save/{id}")]
        [HttpPost]
        public async Task<IActionResult> Save(int id, PersonViewModel personViewModelInput)
        {

            People person = await Context.people.FindAsync(id);
            if (ModelState.IsValid)
            {
                person.Name = personViewModelInput.createPersonView.Name;
                person.Number = (int)personViewModelInput.createPersonView.Number;
                person.CityId = (int)personViewModelInput.createPersonView.City;
                Context.people.Update(person);
                Context.SaveChanges();
            }
            return new RedirectResult(url: "/People", permanent: false,
                            preserveMethod: false);
        }
    }
}
