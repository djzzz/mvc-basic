using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using mvc_basic.Data;
using mvc_basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    [EnableCors("MyPolicy")]
    public class ApiController : Controller
    {
        private ApplicationDbContext Context { get; }
        public ApiController(ApplicationDbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return null;
        }
        // GET: api/Poeple
        [HttpGet]
        public IActionResult People()
        {
            return Json(Context.people);
        }
        // GET: api/City
        [HttpGet]
        public IActionResult City()
        {
            return Json(Context.cities);
        }
        // GET: api/Country
        [HttpGet]
        public IActionResult Country()
        {
            return Json(Context.countrys);
        }
        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> People(CreatePersonViewModel vm)
        {
            People newPerson = new People() { Name = vm.Name, Number = (int)vm.Number, CityId = (int)vm.City };
            Context.people.Add(newPerson);
            await Context.SaveChangesAsync();

            return Json(newPerson);
        }
        // DELETE: api/People/{id}
        [HttpDelete]
        [Route("api/People/{id}")]
        public async Task<IActionResult> People(int id)
        {
            People person = await Context.people.FindAsync(id);
            Context.people.Remove(person);
            await Context.SaveChangesAsync();

            return StatusCode(204);
        }
    }
}
