using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models.Localization;
using System;
using System.Collections.Generic;

namespace ClassAttendance.Models.Models
{
    public class EducationalInstitution 
    {
        public Guid EducationalInstitutionId { get; set; }

        public EducationalInstitutionType Type { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public IEnumerable<EducationalInstitutionFaculty> EducationalInstitutionFaculty { get; set; } 

        public IEnumerable<EducationalInstitutionTranslate> EducationalInstitutionTranslates { get; set; }

        public bool IsDeleted { get; set; }
    }
}
