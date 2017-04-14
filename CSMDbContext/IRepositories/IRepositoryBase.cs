using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.IRepositories
{
    public interface IRepositoryBase<TEntity, id> where TEntity : class
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync();
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(id id);
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, id id);


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        Task DeleteAsync(id id);
    }


    public interface IRepositoryBase<TEntity> : IRepositoryBase<TEntity, int> where TEntity : class
    {

    }
}
