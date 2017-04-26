using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMEntity.Entitys;
using CSMEntity.FormEntitys;
using CSMDbContext.IRepositories;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMBUI.Controllers
{
    public class FoodController : LoginControllerBase
    {
        private ICategoryRepository _CategoryText;
        public FoodController([FromServices] IHostingEnvironment env, IAdminUserRepository i, ICategoryRepository c) : base(i)
        {
            _CategoryText = c;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string c, Boolean c1 ,int c2)
        {

            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Food food, string f, FormImages imgs, List<int> categorys)
        {
            

            return View();
        }
    }
}
