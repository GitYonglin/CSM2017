using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMDbContext;
using CSMDbContext.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMBUI.Controllers
{
    public class HomeController : LoginControllerBase
    {
        public HomeController(IAdminUserRepository i) : base(i)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
