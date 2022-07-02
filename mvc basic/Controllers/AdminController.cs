
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using mvc_basic.Data;
using mvc_basic.Models.Identity;
using mvc_basic.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> RoleManager;
        private UserManager<ApplicationUser> UserManager;
        public AdminController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            Context = context;
            UserManager = userManager;
            RoleManager = roleManager;
        }
        private ApplicationDbContext Context { get; }
        public IActionResult Index()
        {
            Users users = new Users();
            users.List = Context.Users.ToList();
            return View(users);
        }
        [Route("Promot/{id}")]
        public async Task<IActionResult> Promot(string id)
        {
            var admin = await RoleManager.FindByNameAsync("Admin");
            var user = await UserManager.FindByIdAsync(id);
            IdentityResult result = await UserManager.AddToRoleAsync(user, admin.Name);
            if (result.Succeeded)
            {
                return new RedirectResult(url: "/Admin", permanent: false,
                            preserveMethod: false);
            }
            else
            {
                return new RedirectResult(url: "/Index", permanent: false,
                            preserveMethod: false);
            }
            
        }
    }
}
