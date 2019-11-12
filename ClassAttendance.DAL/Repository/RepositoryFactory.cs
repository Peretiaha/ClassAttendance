using Autofac;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.DAL.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public RepositoryFactory(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return this._lifetimeScope.Resolve<IRepository<T>>();
        }
    }

}
