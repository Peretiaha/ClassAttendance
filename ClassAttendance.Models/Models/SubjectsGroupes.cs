using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class SubjectsGroupes
    {
        public Guid SubjectId { get; set; }

        public Guid GroupeId { get; set; }

        public Groupe Groupe { get; set; }

        public Subject Subject { get; set; }
    }
}
