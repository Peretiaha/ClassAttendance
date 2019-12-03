﻿using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IEducationalInstitutionService : IService<EducationalInstitution>
    {
        EducationalInstitution GetEducationalInstitutionById(Guid id); 
    }
}
