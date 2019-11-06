using ClassAttendance.Models.Enums;
using System.Collections.Generic;

namespace ClassAttendance.Models.Models
{
    public class EducationalInstitution : BaseEntity
    {
        public string Name { get; set; }

        public EducationalInstitutionType Type { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public IEnumerable<EducationalInstitutionFaculty> EducationalInstitutionFaculty { get; set; } 
    }
}
