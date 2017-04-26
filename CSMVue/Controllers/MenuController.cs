using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMDbContext.IRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMVue.Controllers
{
    public class MenuController : Controller
    {
        private ICategoryRepository _CategoryText;

        public MenuController(ICategoryRepository c)
        {
            _CategoryText = c;
        }
        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {

            //string json = JsonConvert.SerializeObject(menu);

            var menus = await _CategoryText.AllAsync();

            //var menusAsync = await _CategoryText.GetAllListAsync();
            //var vv = Json(menus);
            //var a = menus.ToArray();

            return Json(menus);
        }
    }
}
