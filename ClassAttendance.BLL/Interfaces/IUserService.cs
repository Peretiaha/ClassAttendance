using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IUserService : IService<User>
    {
        bool Login(User user);

        IEnumerable<User> GetAllUsers();

        User GetUserById(Guid userId);

        User GetUserByEmail(string email);
    }
}
