using CSMDbContext.Repositories;
using CSMEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.IRepositories
{
    public interface ICategoryRepository
    {

        Task<List<CategoryOne>> AllAsync();
        Task<CategoryOne> OneAsync(int id);
        Task<Category> OneSubAsync(int id);

        Task<int> CategoryOneAddAsync(CategoryOne c);
        Task<int> CategoryOneAddAsync(CategoryOne c,int id);
        Task<int> CategoryOneAddAsync(List<Category> c, int id);

        Task<int> CategoryOneDeleteAsync(int id);
        Task<int> SubCategoryDeleteAsync(int id);
    }
}
