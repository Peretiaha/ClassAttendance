using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.ViewModels
{
    public class FilterViewModel 
    {
        public string SearchName { get; set; }

        public IEnumerable<SelectListItem> Subject { get; set; }

        public string SelectedSubjects { get; set; }

        public Sorting SelectedSorting { get; set; }

        public int FromCountOfMissingClasses { get; set; } = 0;

        public int ToCountOfMissingClasses { get; set; } = 0;

        public Guid EducationalInstitutionId { get; set; }

    }
}
