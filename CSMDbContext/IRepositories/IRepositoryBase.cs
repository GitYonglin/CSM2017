using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.IRepositories
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase
    {
        //public static T Bytes2Object<T>(byte[] buff)
        //{
        //    string json = System.Text.Encoding.UTF8.GetString(buff);
        //    // 这个方法需要 using Newtonsoft.Json;
        //    return JsonConvert.DeserializeObject<T>(json);
        //}
        List<TEntity> GetAllList();
    }

    public interface RepositoryBase
    {
    }
}
