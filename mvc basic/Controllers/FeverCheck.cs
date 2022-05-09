using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    public class FeverCheck : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check(IFormCollection fc)
        {
            int temprature;
            bool succes = int.TryParse(fc["temprature"], out temprature);

            if (!succes)
            {
                ViewData["result"] = "Couldnt get the value";
            }
            else
            {
                if(temprature >= 35)
                {
                    if(temprature <= 37)
                    {
                        ViewData["result"] = "You have no problems with the tempature";
                    }
                    else
                    {
                        ViewData["result"] = "You have fever";
                    }
                }
                else
                {
                    ViewData["result"] = "You have hypothermia";
                }
            }
            return View();
        }
    }
}
