﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Faculty 
    {
        public Guid FacultyId { get; set; }

        public Guid DeanId { get; set; }

        public string Name { get; set; }

        public IEnumerable<EducationalInstitutionFaculty> EducationalInstitutionFaculty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; }

        public bool IsDeleted { get; set; }
    }
}
