using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models.Localization
{
    public class EducationalInstitutionTranslate
    {
        public Guid EducationalInstitutionId { get; set; }

        public string Lang { get; set; }

        public string Name { get; set; }

        public Language Language { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }
    }
}
