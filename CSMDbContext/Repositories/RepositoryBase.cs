using System;
using System.Collections.Generic;
using System.Text;

namespace CSMDbContext.Repositories
{
    public class RepositoryBase
    {
        public EntityDbContext _db;
        public RepositoryBase(EntityDbContext db)
        {
            _db = db;
        }
    }
}
