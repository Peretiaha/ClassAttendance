using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models.Localization
{
    public class FacultyTranslate
    {
        public Guid FacultyId { get; set; }

        public string Lang { get; set; }

        public string Name { get; set; }

        public Faculty Faculty { get; set; }

        public Language Language { get; set; }
    }
}
