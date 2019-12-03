using ClassAttendance.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;

namespace ClassAttendance.Web.ViewModels
{
    public class EducationalInstitutionViewModel
    {
        public string Name { get; set; }

        public EducationalInstitutionType Type { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public IEnumerable<SelectListItem> ListOfFacultes { get; set; }

        public IEnumerable<Guid> SelectedFaculty { get; set; }
    }
}
