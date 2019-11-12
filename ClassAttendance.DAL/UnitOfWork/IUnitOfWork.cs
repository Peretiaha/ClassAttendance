using ClassAttendance.DAL.Interfaces;
using ClassAttendance.Models.Models;

namespace ClassAttendance.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
