using ClassAttendance.DAL.Context;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ClassAttendance.DAL.Repository
{
    public class SqlRepository<T> : IRepository<BaseEntity>
    {
        private readonly ClassAttendanceContext _context;
        private readonly DbSet<BaseEntity> _dbSet;

        public SqlRepository(ClassAttendanceContext context)
        {
            _context = context;
            _dbSet = _context.Set<BaseEntity>();
        }     

        public IEnumerable<BaseEntity> GetMany(Expression<Func<BaseEntity, bool>> filter = null, Func<IEnumerable<BaseEntity>, IOrderedEnumerable<BaseEntity>> orderBy = null, params Expression<Func<BaseEntity, object>>[] includes)
        {
            var entities = _dbSet.AsQueryable();
            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            if (includes != null)
            {
                entities = includes.Aggregate(entities, (current, include) => current.Include(include));
            }

            orderBy?.Invoke(entities);

            return entities.ToList();

        }

        public BaseEntity GetSingle(Expression<Func<BaseEntity, bool>> filter, params Expression<Func<BaseEntity, object>>[] includes)
        {
            var entity = _dbSet.Where(filter);

            if (includes != null)
            {
                entity = includes.Aggregate(entity, (current, include) => current.Include(include));
            }

            return entity.FirstOrDefault();
        }

        public void Insert(BaseEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(BaseEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(_dbSet.Where(x=>x.Id == id).FirstOrDefault());
        }
    }
}
