using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.Models.Models
{
    public class User 
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public Groupe Groupe { get; set; }

        public Guid GroupeId { get; set; }

        public IEnumerable<UsersRoles> UsersRoles { get; set; }
    }
}
