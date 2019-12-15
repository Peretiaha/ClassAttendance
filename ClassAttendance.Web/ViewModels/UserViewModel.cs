using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendance.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Group Group{ get; set; }

        public EducationalInstitution EducationalInstitution { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<Guid> SelectedRoles { get; set; }

        public IEnumerable<SelectListItem> Groupes { get; set; }

        public Guid SelectedGroupe { get; set; }

        public byte[] Photo { get; set; }
    }
}
