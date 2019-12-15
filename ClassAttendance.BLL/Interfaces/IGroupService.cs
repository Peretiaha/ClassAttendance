using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IGroupService : IService<Group>
    {
        Group GetGroupById(Guid id);

        IEnumerable<Group> GetAllGroups();

        IEnumerable<Group> GetAllByEIId(Guid id);

        bool IsExistedByNameAndUniverId(string name, Guid univerId);
    }
}
