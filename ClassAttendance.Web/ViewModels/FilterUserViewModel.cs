using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassAttendance.Web.ViewModels
{
    public class FilterUserViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public FilterViewModel FilterViewModel { get; set; }

    }
}
