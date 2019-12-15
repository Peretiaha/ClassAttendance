using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Enums;

namespace ClassAttendance.Models.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }

        public NumberOfLesson NumberOfLesson { get; set; }

        public Guid TeacherId { get; set; }

        public User Teacher { get; set; }

        public IEnumerable<UsersSubjects> UsersSubjects { get; set; }

        public bool IsDeleted { get; set; }
    }
}
