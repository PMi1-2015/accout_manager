using AccountSystem.Data.models;
using System;
using System.Linq;

namespace AccountSystem.Data.impl
{
    class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AccountSystemContext context) : base(context) { }


        public AppUser FindByUserName(String userName)
        {
            return _dbSet.Where(u => u.UserName == userName).First();
        }
    }
}
