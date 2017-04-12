using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMBUI.Models;
using Newtonsoft.Json;
using CSMDbContext.IRepositories;
using CSMEntity.Entitys;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMBUI.Controllers
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
            
            var menu = new List<Menu>{
                new Menu
                {
                    Icon = "el-icon-message",Name="分类",Show=false,url="/Category/",
                    SubCategory =new List<Menu>
                    {
                        new Menu {
                            Icon = "el-icon-message",Name="食材",Show=false,url="/Category/Food/"
                        },
                        //new Menu {
                        //    Icon = "el-icon-message",Name="菜谱",Show=false,url="/Category/Cookbook/"
                        //},
                        //new Menu {
                        //    Icon = "el-icon-message",Name="套餐",Show=false,url="/Category/Package/"
                        //}
                    }
                },
                //new Menu
                //{
                //    Icon = "el-icon-message",Name="食材",Show=false,url="/Food/",
                //    SubCategory =new List<Menu>
                //    {
                //        new Menu {
                //            Icon = "el-icon-message",Name="主料",Show=false,url="/Food/Main/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="辅料",Show=false,url="/Food/Accessory/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="酱料",Show=false,url="/Food/Paste/"
                //        }
                //    }
                //},
                //new Menu
                //{
                //    Icon = "el-icon-message",Name="菜谱",Show=false,url="/Cookbook/",
                //    SubCategory =new List<Menu>
                //    {
                //        new Menu {
                //            Icon = "el-icon-message",Name="早餐",Show=false,url="/Cookbook/Breakfast/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="午餐",Show=false,url="/Cookbook/Lunch/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="晚餐",Show=false,url="/Cookbook/Dinner/"
                //        }
                //    }
                //},
                //new Menu
                //{
                //    Icon = "el-icon-message",Name="套餐",Show=false,url="/Package/",
                //    SubCategory =new List<Menu>
                //    {
                //        new Menu {
                //            Icon = "el-icon-message",Name="早餐",Show=false,url="/Package/Breakfast/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="午餐",Show=false,url="/Package/Lunch/"
                //        },
                //        new Menu {
                //            Icon = "el-icon-message",Name="晚餐",Show=false,url="/Package/Dinner/"
                //        }
                //    }
                //},
            };

            //string json = JsonConvert.SerializeObject(menu);

            var menus = await _CategoryText.AllAsync();
            var arr = new List<CategoryOne>();
            arr.AddRange(menus);
            return Json(menus);
        }
    }
}
