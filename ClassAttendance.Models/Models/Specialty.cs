using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public Faculty Faculty { get; set; }
    }
}
