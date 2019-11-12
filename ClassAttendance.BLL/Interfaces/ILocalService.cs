using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Interfaces
{
    public interface ILocalService<TEntity> where TEntity: class
    {
        void Create(TEntity entity, string local);

        void Edit(TEntity entity, string local);

        void Delete(Guid entityId, string local);
    }
}
