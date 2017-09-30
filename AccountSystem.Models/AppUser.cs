using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Data.models
{
    public class AppUser
    {
        public long Id { get; set; }
        public String UserName { get; set; }
        public String PasswordHash { get; set; }
    }
}
