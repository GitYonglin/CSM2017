using CSMDbContext.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.Repositories
{
    public class RepositoryBase<TEntity, id> : IRepositoryBase<TEntity, id> where TEntity : class
    {
        public EntityDbContext _db;
        public RepositoryBase(EntityDbContext db)
        {
            _db = db;
        }
        /***********************************************************************/
        // 查询数据
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>返回List</returns>
        public async Task<List<TEntity>> GetAllListAsync()
        {

            return await _db.Set<TEntity>().ToListAsync();
        }
        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <param name="id">实例id</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(id id)
        {
            var v = await _db.Set<TEntity>().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
            return v;
        }

        /***********************************************************************/
        // 新增数据
        /// <summary>
        /// 新增一个数据
        /// </summary>
        /// <param name="entity">新增数据实体</param>
        /// <returns></returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <param name="id">实体id</param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity, id id)
        {
            var obj = await GetAsync(id);
            EntityToEntity(entity, obj);
            await SaveAsync();
            return entity;
        }
        private void EntityToEntity<T>(T pTargetObjSrc, T pTargetObjDest)
        {
            foreach (var mItem in typeof(T).GetProperties())
            {
                mItem.SetValue(pTargetObjDest, mItem.GetValue(pTargetObjSrc, new object[] { }), null);
            }
        }

        /***********************************************************************/
        // 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(id id)
        {
             await DeleteAsync( await GetAsync(id));
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        public async Task DeleteAsync(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }


        /// <summary>
        /// 事务性保存
        /// </summary>
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(id id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var key = $"{lambdaParam.Type.Name}Id";
           
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, key),
                Expression.Constant(id, typeof(id))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int> where TEntity : class
    {
        public RepositoryBase(EntityDbContext db) : base(db)
        {
        }
    }
}
