using System;
using System.Collections.Generic;
using System.Text;
using ClassAttendance.DAL.Context;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.Models.Models;

namespace ClassAttendance.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClassAttendanceContext _db;

        private readonly IRepositoryFactory _repositoryFactory;

        public UnitOfWork(ClassAttendanceContext db, IRepositoryFactory repositoryFactory)
        {
            _db = db;
            _repositoryFactory = repositoryFactory;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public IRepository<BaseEntity> GetRepository<T>() where T : class
        {
            return _repositoryFactory.GetRepository<T>();
        }
    }
}
