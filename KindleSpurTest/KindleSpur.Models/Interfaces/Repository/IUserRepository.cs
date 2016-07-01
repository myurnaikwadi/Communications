using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindleSpur.Models.Interfaces.Repository
{
    public interface IUserRepository
    {
            bool AddNewUser(IUser userData);

            bool EditUser(string id, IUser userData);

            IUser GetUserDetail(int userId);
    }
}
