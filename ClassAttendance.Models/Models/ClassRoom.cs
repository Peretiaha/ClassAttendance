using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Enums;

namespace ClassAttendance.Models.Models
{
    public class ClassRoom
    {
        public Guid ClassRoomId { get; set; }

        public int Number { get; set; }

        public ClassRoomType Type { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }
        
        public bool IsDeleted { get; set; }

    }
}
