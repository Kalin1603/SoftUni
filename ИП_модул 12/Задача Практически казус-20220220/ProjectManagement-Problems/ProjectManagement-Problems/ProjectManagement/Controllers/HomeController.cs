using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;
using ProjectManagement.Repositories;
using ProjectManagement.ViewModels.Home;
using ProjectManagement.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.ActionFilters;

namespace ProjectManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!this.ModelState.IsValid)
                return View(model);

            ProjectManagementDbContext context = new ProjectManagementDbContext();
            User loggedUser = context.Users.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                           .FirstOrDefault();

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            if (loggedUser == null)
            {
                this.ModelState.AddModelError("autheError", "Invalid username or password!");
                return View(model);
            }


            return RedirectToAction("Index", "Home");
        }

        [AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }
    }
}
