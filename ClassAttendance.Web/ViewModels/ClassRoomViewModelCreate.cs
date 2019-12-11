using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;

namespace ClassAttendance.Web.ViewModels
{
    public class ClassRoomViewModelCreate
    {
        public int Number { get; set; }

        public ClassRoomType Type { get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }
    }
}
