using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IFacultyService : IService<Faculty>
    {
        Faculty GetFacultyById(Guid id);

        IEnumerable<Faculty> GetAllFaculties();
    }
}
