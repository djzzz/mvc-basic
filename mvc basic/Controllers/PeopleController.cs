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
            
            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel personViewModelInput)
        {
            if (ModelState.IsValid)
            {
                personViewModel.Add(personViewModelInput.createPersonView);
            }
            return View(personViewModel);
        }
        [HttpGet]
        public IActionResult Index(string search)
        {
            PersonViewModel searched = new PersonViewModel();
            if (search == "")
            {
                searched.List = personViewModel.List;
            }
            else
            {
                searched.List = personViewModel.List.Where(o => o.Name == search).ToList();
            }
            
            return View(personViewModel);
        }
    }
}
