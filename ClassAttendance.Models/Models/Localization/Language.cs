using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models.Localization
{
    public class Language
    {
        public string Lang { get; set; }

        public string Name { get; set; }

        public IEnumerable<FacultyTranslate> FacultyTranslates { get; set; }

        public IEnumerable<EducationalInstitutionTranslate> EducationalInstitutionTranslates { get; set; }

        public IEnumerable<SpecialtyTranslate> SpecialtyTranslates { get; set; }
    }
}
