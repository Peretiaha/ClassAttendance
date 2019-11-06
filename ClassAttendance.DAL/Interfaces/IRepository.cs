using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ClassAttendance.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(Guid id);

        T GetSingle(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null, Func<IEnumerable<T>, IOrderedEnumerable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
    }
}
