using System;

namespace ClassAttendance.Models.Models
{
    public abstract class BaseEntity
    {
       public Guid Id { get; set; }

       public bool IsDeleted { get; set; }
    }
}
