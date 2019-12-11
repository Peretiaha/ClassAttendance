using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IClassRoomService : IService<ClassRoom>
    {
        IEnumerable<ClassRoom> GetAllClassRoomsByEducationalInstitutionId(Guid univerId);

        ClassRoom GetClassRoomById(Guid classRoomId);
    }
}
