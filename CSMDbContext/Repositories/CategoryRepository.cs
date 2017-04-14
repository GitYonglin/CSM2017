using CSMDbContext.IRepositories;
using CSMEntity.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryOne>, ICategoryRepository
    {
        public CategoryRepository(EntityDbContext db) : base(db)
        {
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryOne>> AllAsync()
        {
            return await _db.CategoryOnes
                .Include(c => c.SubCategory)
                .ToListAsync();
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryOne> OneAsync(int id)
        {
            return await _db.CategoryOnes
                .Include(sc => sc.SubCategory)
                
                .FirstOrDefaultAsync(c => c.CategoryOneId == id);
        }
        /// <summary>
        /// id获取一个子分类
        /// </summary>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        public async Task<Category> OneSubAsync(int id)
        {
            return await _db.Categorys
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }
        /// <summary>
        /// 插入或更新一条主分类
        /// </summary>
        /// <param name="c">实体</param>
        /// <returns></returns>
        public async Task<int> CategoryOneAddAsync(CategoryOne c)
        {
            if (c.CategoryOneId==0)
            {
                _db.CategoryOnes.Add(c);
            }
            else
            {
                await UpdateCategoryOneAsync(c);
            }
            return await _db.SaveChangesAsync();
        }
        /// <summary>
        /// 新增||更新子分类
        /// </summary>
        /// <param name="c">子类数据</param>
        /// <param name="id">主类id</param>
        /// <returns></returns>
        public async Task<int> CategoryOneAddAsync(List<Category> c, int id)
        {
            var cOne = await OneAsync(id);
            //cOne.SubCategory.AddRange(c);
            foreach (var item in c)
            {
                if (item.CategoryId == 0)
                {
                    cOne.SubCategory.Add(item);
                }
                else
                {
                    var vvv = cOne.SubCategory.SingleOrDefault(cc => cc.CategoryId == item.CategoryId);
                    if (vvv != null)
                    {
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].Name = item.Name;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].url = item.url;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].ImgUrl = item.ImgUrl;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].Icon = item.Icon;
                    }
                }
            }

            return await _db.SaveChangesAsync();
        }

        
        /// <summary>
        /// 删除主分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task CategoryOneDeleteAsync(int id)
        {
            var c = await OneAsync(id);

            await DeleteAsync(c);
            //_db.CategoryOnes.Remove(c);
            //_db.Categorys.RemoveRange(c.SubCategory);

            await _db.SaveChangesAsync();
        }
        /// <summary>
        /// 删除子分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> SubCategoryDeleteAsync(int id)
        {
            var c = await OneSubAsync(id);
            _db.Categorys.RemoveRange(c);

            return await _db.SaveChangesAsync();
        }


        /// <summary>
        /// 修改主分类
        /// </summary>
        /// <param name="c">修改实体数据</param>
        /// <returns></returns>
        public async Task<int> UpdateCategoryOneAsync(CategoryOne c)
        {
            var cOne = await OneAsync(c.CategoryOneId);

            //cOne = c;
            //EntityToEntity(c, cOne);

            cOne.Name = c.Name;
            cOne.url = c.url;
            cOne.ImgUrl = c.ImgUrl;
            cOne.Icon = c.Icon;
            foreach (var item in c.SubCategory)
            {
                if (item.CategoryId == 0)
                {
                    cOne.SubCategory.Add(item);
                }
                else
                {
                    var vvv = cOne.SubCategory.SingleOrDefault(cc => cc.CategoryId == item.CategoryId);
                    if (vvv != null)
                    {
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].Name = item.Name;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].url = item.url;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].ImgUrl = item.ImgUrl;
                        cOne.SubCategory[cOne.SubCategory.IndexOf(vvv)].Icon = item.Icon;
                    }
                }
            }

            return await _db.SaveChangesAsync();
        }
    }
}
