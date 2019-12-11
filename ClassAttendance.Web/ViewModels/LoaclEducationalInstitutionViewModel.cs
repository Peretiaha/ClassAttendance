using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;

namespace ClassAttendance.Web.ViewModels
{
    public class LoaclEducationalInstitutionViewModel
    {
        public IEnumerable<EducationalInstitution> EducationalInstitutions { get; set; }

        public Country Country { get; set; }
    }
}
