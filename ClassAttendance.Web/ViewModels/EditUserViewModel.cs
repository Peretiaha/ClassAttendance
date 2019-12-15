using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.ViewModels
{
    public class EditUserViewModel
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

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<Guid> SelectedRoles { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }

        public Guid SelectedGroup { get; set; }

        public IFormFile Photo { get; set; }
    }
}
