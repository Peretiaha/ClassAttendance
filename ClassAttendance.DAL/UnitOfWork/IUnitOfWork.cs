using ClassAttendance.DAL.Interfaces;
using ClassAttendance.Models.Models;

namespace ClassAttendance.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();

        IRepository<BaseEntity> GetRepository<T>() where T : class;
    }
}
