using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.BLL.Dto;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IUserService : IService<User>
    {
        bool Login(User user);

        IEnumerable<User> GetAllUsers();

        User GetUserById(Guid userId);

        User GetUserByEmail(string email);

        IEnumerable<User> GetTeachersByEIId(Guid eIId);

        IEnumerable<User> GetAllUsersByGroupId(Guid groupId);

        IEnumerable<User> FilterUsers(FilterDto filterDto);
    }
}
