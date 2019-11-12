using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.DAL.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
    }
}
