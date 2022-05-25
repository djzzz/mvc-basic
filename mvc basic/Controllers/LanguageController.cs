using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_basic.Data;
using mvc_basic.Models.Languages;
using mvc_basic.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext Context;
        public LanguageViewModel vm = new LanguageViewModel();
        public LanguageController(ApplicationDbContext context)
        {
            Context = context;
            
        }
        public IActionResult Index()
        {
            vm.Peoples = Context.people.ToList();
            vm.List = Context.Languages.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.People).ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(LanguageViewModel languageViewModel)
        {
            CreateLanguageViewModel Language = languageViewModel.CreateLanguageViewModel;
            if (ModelState.IsValid)
            {
                Language newLanguage = new Language { Name = Language.Name};
                Context.Languages.Add(newLanguage);
                Context.SaveChanges();
            }
            vm.Peoples = Context.people.ToList();
            vm.List = Context.Languages.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.People).ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult BindLanguagePeople(LanguageViewModel languageViewModel)
        {
            CreateLanguagePeopleViewModel LanguagePeople = languageViewModel.CreateLanguagePeopleViewModel;
            if (ModelState.IsValid)
            {
                LanguagePeople newLanguagePeople = new LanguagePeople { PeopleId = (int)LanguagePeople.People, LanguageId = (int)LanguagePeople.Language };
                Context.LanguagePeople.Add(newLanguagePeople);
                Context.SaveChanges();
            }
            vm.Peoples = Context.people.ToList();
            vm.List = Context.Languages.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.People).ToList();
            return View(vm);
        }
    }
}
