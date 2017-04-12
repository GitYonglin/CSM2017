using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CSMDbContext;
using CSMDbContext.IRepositories;
using CSMEntity.Entitys;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMBUI.Controllers
{
    public class LoginControllerBase : Controller
    {
        private IAdminUserRepository _AdminUserContext;
        public LoginControllerBase(IAdminUserRepository i)
        {
            _AdminUserContext = i;
        }
        public override void OnActionExecuting(ActionExecutingContext loigncontext)
        {
            HttpContext.Session.TryGetValue("UserId", out byte[] result);
            HttpContext.Session.TryGetValue("UserSession", out byte[] session);
            // 没有 session 或过期时跳转到的页面
            if (result == null || session == null)
            {
                loigncontext.Result = new RedirectResult("/Login/Index");
                //RedirectToAction("Index", "Login");
                return;
            }
            else
            {
                var id = System.Text.Encoding.UTF8.GetString(result);
                var strSession = System.Text.Encoding.UTF8.GetString(session).ToUpper();
                AdminUser user = _AdminUserContext.LoginSession(id);

                if (user == null || !(user.SessionKey == strSession))
                {
                    loigncontext.Result = new RedirectResult("/Login/Index");
                    //RedirectToAction("Index", "Login");
                    return;
                }
            }
            base.OnActionExecuting(loigncontext);
        }
    }
}
