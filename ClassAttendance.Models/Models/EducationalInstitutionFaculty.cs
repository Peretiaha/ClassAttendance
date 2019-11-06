using System;

namespace ClassAttendance.Models.Models
{
    public class EducationalInstitutionFaculty
    {
        public Guid EducationalInstitutionId { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }

        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }
}
