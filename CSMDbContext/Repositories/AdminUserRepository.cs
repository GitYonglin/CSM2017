using CSMDbContext.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using CSMEntity.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CSMUtility;

namespace CSMDbContext.Repositories
{
    public class AdminUserRepository : RepositoryBase<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(EntityDbContext db) : base(db)
        {
        }
        /// <summary>
        /// 管理注册
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int InitRoot(string userName, string password)
        {
            var user = new AdminUser()
            {
                Id = Guid.Empty,
                UserName = userName,
                Password = PwdOperation.Encryption(password)
                
            };

            _db.AdminUsers.Add(user);
            return _db.SaveChanges();
        }


        public AdminUser Login(string userName, string password, string session)
        {
            var pwd = PwdOperation.LoginEncryption(password);
            var user = _db.Set<AdminUser>()
                .SingleOrDefault(it => it.UserName == userName);
            if (user != null)
            {
                var Dpwd = PwdOperation.Decryption(user.Password);
                if (pwd == Dpwd)
                {
                    user.SessionKey = session;
                    _db.SaveChanges();
                    return user;
                }
            }
            return null;
        }

        public  AdminUser LoginSession(string id)
        {
            return _db.AdminUsers
                .SingleOrDefault(u => u.Id.ToString() == id);
        }

        public Boolean Bif()
        {
            var v = _db.AdminUsers.FirstOrDefault();
            if (v != null)
            {
                return true;
            }
            return false;
        }
    }
}
