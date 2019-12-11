using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Groupe
    {
        public Guid GroupeId { get; set; }

        public string Name { get; set; }

        public IEnumerable<User> Students { get; set; }

        public IEnumerable<SubjectsGroupes> SubjectsGroupes { get; set; }

        public Guid EducationalInstitutionId { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }

        public bool IsDeleted { get; set; }
    }
}
