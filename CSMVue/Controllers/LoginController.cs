using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMDbContext.IRepositories;
using Microsoft.AspNetCore.Http;
using CSMEntity.FormEntitys;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMVue.Controllers
{
    public class LoginController : Controller
    {
        private IAdminUserRepository _AdminUserContext;
        public LoginController(IAdminUserRepository i)
        {
            _AdminUserContext = i;
        }
        /// <summary>
        /// 管理员注册
        /// </summary>
        /// <returns></returns>
        public IActionResult Init()
        {
            if (_AdminUserContext.Bif())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        /// <summary>
        /// 管理员注册
        /// </summary>
        /// <param name="fuser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Init(FormAdminUser fuser)
        {
            var i = _AdminUserContext.InitRoot(fuser.UserName, fuser.Password);

            return RedirectToAction("Index", "Login");
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="fuser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(FormAdminUser fuser)
        {
            if (ModelState.IsValid)
            {
                var guid = Guid.NewGuid();
                string session = guid.ToString().Replace("-", "").ToUpper();
                var user = _AdminUserContext.Login(fuser.UserName, fuser.Password, session);
                if (user != null)
                {
                    //记录Session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("UserSession", session);
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
            }
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return View(fuser);
        }
    }
}
