using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services
{
    public interface IAppUserService
    {
        void AddUser(string username, string password);
        bool AuthenticateUser(String username, String password);
    }
}
