using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class FacultySpecialty
    {
        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public Guid SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }
    }
}
