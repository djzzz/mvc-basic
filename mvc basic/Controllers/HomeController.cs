using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
namespace mvc_basic.Controllers
{
    [BindProperties]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        
        }
        [HttpGet]
        [Route("Home/TryModelBinding/{id}")]
        public IActionResult TryModelBinding(int id)
        {
            TestModel album = new TestModel { Title = "Album Fucking random shit", Genre = "Cool"};
            ViewData["id"] = album.id(id);
            return View(album);

        }
    }
}
