using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public interface IUserManager
    {
        User Authenticate(string login, string password);
        bool Create(User user, string password);
        bool Delete(int id);
    }
}
