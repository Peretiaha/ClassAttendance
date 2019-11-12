using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class Role 
    {
        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public IEnumerable<UsersRoles> UserRoles { get; set; }
    }
}
