using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMDbContext.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CSMVue.Controllers
{
    public class HomeController : LoginControllerBase
    {
        public HomeController(IAdminUserRepository i) : base(i)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
