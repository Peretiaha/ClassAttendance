using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; }

        public IEnumerable<User> Students { get; set; }

        public Guid EducationalInstitutionId { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }

        public bool IsDeleted { get; set; }
    }
}
