using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.Models.Enums;

namespace ClassAttendance.BLL.Dto
{
    public class FilterDto
    {
        public string SearchName { get; set; }

        public Guid SelectedSubjects { get; set; }

        public Sorting SelectedSorting { get; set; }

        public int FromCountOfMissingClasses { get; set; } = 0;

        public int ToCountOfMissingClasses { get; set; } = 0;

        public Guid EducationalInstitutionId { get; set; }

    }
}
