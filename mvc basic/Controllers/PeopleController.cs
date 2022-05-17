using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;

namespace mvc_basic.Controllers
{
    public class PeopleController : Controller
    {
        public PersonViewModel personViewModel = new PersonViewModel();
        public IActionResult Index()
        {
            ViewData["search"] = false;
            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel personViewModelInput)
        {
            ViewData["search"] = false;
            if (ModelState.IsValid)
            {
                personViewModel.Add(personViewModelInput.createPersonView);
            }
            return View(personViewModel);
        }
        [HttpGet]
        public IActionResult Index(string search)
        {
            ViewData["search"] = true;
            PersonViewModel searched = new PersonViewModel();
            if (search == null)
            {
                ViewData["search"] = false;
                searched.List = personViewModel.List;
            }
            else
            {

                searched.List = personViewModel.List.Where(o => o.Name == search).ToList();
            }
            
            return View(searched);
        }
        [Route("People/{id}")]
        public IActionResult Index(int id)
        {
            ViewData["search"] = false;
            personViewModel.Remove(id);
            return View(personViewModel);
        }
    }
}
