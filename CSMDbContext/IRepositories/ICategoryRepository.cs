using CSMDbContext.Repositories;
using CSMEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.IRepositories
{

    public interface ICategoryRepository : IRepositoryBase<CategoryOne>
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryOne>> AllAsync();
        /// <summary>
        /// 根据Id获取一条数据
        /// </summary>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        Task<CategoryOne> OneAsync(int id);
        /// <summary>
        /// id获取一个子分类
        /// </summary>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        Task<Category> OneSubAsync(int id);
        /// <summary>
        /// 插入或更新一条主分类
        /// </summary>
        /// <param name="c">实体</param>
        /// <returns></returns>
        Task<int> CategoryOneAddAsync(CategoryOne c);

        /// <summary>
        /// 插入一个子类
        /// </summary>
        /// <param name="c">子类数据</param>
        /// <param name="id">主类id</param>
        /// <returns></returns>
        Task<int> CategoryOneAddAsync(List<Category> c, int id);
        /// <summary>
        /// 删除主分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task CategoryOneDeleteAsync(int id);
        /// <summary>
        /// 删除子分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> SubCategoryDeleteAsync(int id);



    }
}
