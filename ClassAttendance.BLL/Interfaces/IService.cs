using ClassAttendance.Models.Models;
using System;

namespace ClassAttendance.BLL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void Edit(TEntity entity);

        void Delete(Guid entityId);
    }
}
