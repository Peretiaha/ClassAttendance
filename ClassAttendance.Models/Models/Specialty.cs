using ClassAttendance.Models.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Specialty 
    {
        public Guid SpecialityId { get; set; }

        public int Number { get; set; }

        public Faculty Faculty { get; set; }

        public IEnumerable<SpecialtyTranslate> SpecialtyTranslates { get; set; }

        public bool IsDeleted { get; set; }

    }
}
