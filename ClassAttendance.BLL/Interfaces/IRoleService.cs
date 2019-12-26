using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IRoleService : IService<Role>
    {
        IEnumerable<Role> GetAllRoles();

        IEnumerable<Role> GetAllUserRoles(Guid userId);

        Role GetRoleByName(string name);

        Role GetRoleById(Guid id);
    }
}
