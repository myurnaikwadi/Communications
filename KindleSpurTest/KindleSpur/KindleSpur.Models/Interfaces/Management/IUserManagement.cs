using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models.Interfaces
{
    public interface IUserManagement
    {
            bool AddNewUser(IUser userData);

            bool EditUser(int id, IUser userData);

            bool DeleteUser(int userId);

            IUser GetUserDetail(int userId);
    }
}
