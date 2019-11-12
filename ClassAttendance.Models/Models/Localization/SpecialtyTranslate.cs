using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassAttendance.Models.Models.Localization
{
    public class SpecialtyTranslate
    {
        public Guid SpecialtyId { get; set; }

        public string Lang { get; set; }

        public string Name { get; set; }

        public Language Language { get; set; }

        public Specialty Specialty { get; set; }
    }
}