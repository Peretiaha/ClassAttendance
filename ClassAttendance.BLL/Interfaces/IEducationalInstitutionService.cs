using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Enums;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IEducationalInstitutionService : IService<EducationalInstitution>
    {
        EducationalInstitution GetEducationalInstitutionById(Guid id);

        IEnumerable<EducationalInstitution> GetEducationalInstitutionsByCountry(Country country);

        IEnumerable<EducationalInstitution> GetAllEducationalInstitutions();

    }
}
