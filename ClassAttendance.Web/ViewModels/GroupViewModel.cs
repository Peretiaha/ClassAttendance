using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.ViewModels
{
    public class GroupViewModel
    {
        public Guid? GroupeId { get; set; }

        public string Name { get; set; }

        public IEnumerable<SelectListItem> EducationalInstitutions { get; set; }

        public Guid SelectedEducationalInstitution { get; set; }

        public IEnumerable<Group> Groupes { get; set; }
    }
}
