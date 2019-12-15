using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface ISubjectService : IService<Subject>
    {
        Subject GetSubjectById(Guid id);
    }
}
