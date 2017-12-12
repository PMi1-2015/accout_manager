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
            IQueryable<AppUser> results = _dbSet.Where(u => u.UserName == userName);

            if (results.Count() == 0)
            {
                return null;
            }
            else
            {
                return results.First();
            }
        }
    }
}
