using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class UsersSubjects
    {
        public Guid UserId { get; set; }

        public Guid SubjectId { get; set; }

        public User User { get; set; }

        public Subject Subject { get; set; }

        public int NumberOfVisits { get; set; }

        public int PassesForGoodReason { get; set; }  //пропуски по уважительной причине 
    }
}
