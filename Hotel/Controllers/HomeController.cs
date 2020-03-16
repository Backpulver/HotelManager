using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotel.Models;
using Hotel.Data;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        public HomeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityRole employeeRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Employee" };
            IdentityRole adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin" };

            await this.roleManager.CreateAsync(employeeRole);
            await this.roleManager.CreateAsync(adminRole);

            if (this.User.Identity.IsAuthenticated)
            {
                if (this.User.IsInRole("Employee"))
                {
                    return this.View("EmployeeHome");
                }
                if (this.User.IsInRole("Admin"))
                {
                    return this.View("AdminHome");
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
