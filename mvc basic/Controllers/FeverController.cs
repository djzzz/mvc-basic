using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;

namespace mvc_basic.Controllers
{
    public class FeverController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["result"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            FeverModel feverModel = new FeverModel();
            int temprature;

            bool succes = int.TryParse(fc["temprature"], out temprature);

            if (!succes)
            {
                ViewData["result"] = "Couldnt get the value";
            }
            else
            {
                if (feverModel.CheckHypofermia(temprature))
                {
                    ViewData["result"] = "You have hypothermia";
                }
                else if(feverModel.CheckFever(temprature))
                {
                    ViewData["result"] = "You have fever";
                }
                else
                {
                    ViewData["result"] = "You have no problems with the tempature";
                }
            }
            return View();
        }
    }
}
