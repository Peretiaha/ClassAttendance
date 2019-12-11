using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IGroupService : IService<Groupe>
    {
        Groupe GetGroupById(Guid id);

        IEnumerable<Groupe> GetAllGroups();

        IEnumerable<Groupe> GetAllByEIId(Guid id);

        bool IsExistedByName(string name);
    }
}
