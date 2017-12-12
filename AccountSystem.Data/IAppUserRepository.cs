using AccountSystem.Data.models;
using System;

namespace AccountSystem.Data
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser FindByUserName(String userName);
    }
}
