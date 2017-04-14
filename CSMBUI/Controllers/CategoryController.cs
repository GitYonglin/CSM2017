using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMEntity.Entitys;
using CSMDbContext.IRepositories;
using Microsoft.AspNetCore.Http;
using CSMEntity.FormEntitys;


using CSMBUI.Models;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMBUI.Controllers
{
    public class CategoryController : LoginControllerBase
    {
        private ICategoryRepository _CategoryText;
        private string rootPath;
        public CategoryController([FromServices]IHostingEnvironment env, IAdminUserRepository i, ICategoryRepository c) : base(i)
        {
            rootPath = env.WebRootPath;
            _CategoryText = c;
        }

        //public CategoryController()
        //{
        //    _CategoryText = i;
        //}
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新增||更新主分类数据
        /// </summary>
        /// <param name="c">主分类数据</param>
        /// <param name="SubCategorys">子分类数据</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CategoryOneAddAsync(FormCategory c, List<FormCategory> SubCategorys)
        {
            var category = new CategoryOne() { CategoryOneId=c.Id, Icon = c.Icon, Name = c.Name, url = c.url};
            if (c.File != null)
            {
                category.ImgUrl = await FilesSave.FileSave(rootPath, @"\Upload\Category\", c.File);
            }
            else
            {
                category.ImgUrl = c.ImgUrl;
            }
            if (SubCategorys != null)
            {
                var SubC = new List<Category>();
                foreach (var item in SubCategorys)
                {
                    var cs = new Category() { CategoryId = item.Id, Icon = item.Icon, Name = item.Name, url = item.url };
                    if (item.File != null)
                    {
                        cs.ImgUrl = await FilesSave.FileSave(rootPath, @"\Upload\Category\", item.File);
                    }
                    else
                    {
                        cs.ImgUrl = item.ImgUrl;
                    }
                    SubC.Add(cs);
                }
                category.SubCategory = SubC;
            }
            //新增数据
            await _CategoryText.CategoryOneAddAsync(category);

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 新增||更新子分类
        /// </summary>
        /// <param name="id">主分类Id</param>
        /// <param name="SubCategorys">子类数据</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubCategoryAddAsync(int id, List<FormCategory> SubCategorys)
        {
            var sc = new List<Category>();
            foreach (var item in SubCategorys)
            {
                var ImgUrl = item.ImgUrl;
                if (item.File != null)
                {
                    ImgUrl = await FilesSave.FileSave(rootPath, @"\Upload\Category\", item.File);
                }
                sc.Add(new Category { CategoryId=item.Id, Icon = item.Icon, Name = item.Name, url = item.url, ImgUrl = ImgUrl });
            }

            await _CategoryText.CategoryOneAddAsync(sc, id);
            return RedirectToAction("Index", "Home");
        }
        
        /// <summary>
        /// 获取主分类数据
        /// </summary>
        /// <param name="id">菜单Id</param>
        /// <returns></returns>
        public async Task<IActionResult> CategoryOneEditAsync(int id)
        {
            var cOne = await _CategoryText.OneAsync(id);

            return Json(cOne);
        }

        /// <summary>
        /// 获取子分类编辑数据
        /// </summary>
        /// <param name="id">子分类id</param>
        /// <returns></returns>
        public async Task<IActionResult> CategoryEditAsync(int id)
        {
            var cOne = await _CategoryText.OneSubAsync(id);
            var arr = new List<Category>();
            arr.Add(cOne);
            return Json(arr);
        }
        /// <summary>
        /// 删除主分类
        /// </summary>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        public async Task<IActionResult> CategoryOneDeleteAsync(int id)
        {
            await _CategoryText.CategoryOneDeleteAsync(id);

            return Json(new { msg = "OK" });
        }
        /// <summary>
        /// 删除子分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> SubCategoryDeleteAsync(int id)
        {
            var b = await _CategoryText.SubCategoryDeleteAsync(id);
            return Json(new { msg = b });
        }
    }
}
