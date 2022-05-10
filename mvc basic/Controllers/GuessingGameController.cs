using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    public class GuessingGameController : Controller
    {
        public Random random = new Random();
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["count"] = 0;
            ViewData["result"] = "New number generated";
            HttpContext.Session.SetInt32("number", random.Next(1, 101));
            HttpContext.Session.SetInt32("count", 0);
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            int guess;
            bool succes = int.TryParse(fc["guess"], out guess);
            int correct = (int)HttpContext.Session.GetInt32("number");
            int count = (int)(HttpContext.Session.GetInt32("count") + 1);
            ViewData["count"] = count;
            HttpContext.Session.SetInt32("count", count);
            if (succes)
            {
                if (correct == guess)
                {
                    HttpContext.Session.SetInt32("number", random.Next(1, 101));
                    HttpContext.Session.SetInt32("count", 0);
                    ViewData["result"] = "You got it, your amazing! Congratz my hero";
                }
                else
                {
                    if(guess < correct)
                    {
                        ViewData["result"] = "Too low sadly";
                    }
                    else
                    {
                        ViewData["result"] = "Too high for your own good";
                    }
                        
                }
            }
            else
            {
                ViewData["result"] = "Couldnt get the value";
            }
            
            return View();
        }
    }
}
