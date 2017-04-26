using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMEntity.FormEntitys;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMVue.Controllers
{
    public class ServerFoodController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(FormFood form, List<FormImages> imgFiles, List<int> categorys)
        {
            //DateTime datetime = DateTime.ParseExact("Wed Aug 25 16:28:03 +0800 2010", "yyyyMMdd HH:mm:ss");
            var tt = Convert.ToDateTime("Tue Apr 18 2017 00:00:00");
            var t = Convert.ToDateTime(form.Insertdate);
            var food = new { f = form, i = imgFiles, c = categorys };
            return Json(food);
        }
    }
}
