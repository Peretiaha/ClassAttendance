using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Interfaces
{
    interface ISpecialtyService : IService<Specialty>
    {
        Specialty GetSpecialtyById(Guid id);

        IEnumerable<Specialty> GetSpecialties();
    }
}
