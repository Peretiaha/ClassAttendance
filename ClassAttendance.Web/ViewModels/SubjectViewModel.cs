using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.ViewModels
{
    public class SubjectViewModel
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }

        public NumberOfLesson NumberOfLesson { get; set; }

        public Guid ClassRoomId { get; set; }

        public User Teacher { get; set; }

        public Guid TeacherId { get; set; }

        public IEnumerable<SelectListItem> SubjectsGroups { get; set; }

        public IEnumerable<Guid> SelectedGroup { get; set; }

        public IEnumerable<SelectListItem> ClassRooms { get; set; }

        public IEnumerable<Guid> SelectedClassRoom { get; set; }

        public IEnumerable<SelectListItem> Teachers { get; set; }

        public IEnumerable<Guid> SelectedTeacher { get; set; }
    }
}
