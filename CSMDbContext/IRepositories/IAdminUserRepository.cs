using CSMEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMDbContext.IRepositories
{
    public interface IAdminUserRepository
    {
        AdminUser Login(string userName, string password, string session);
        AdminUser LoginSession(string id);

        int InitRoot(string userName, string password);
        Boolean Bif();
    }
}
