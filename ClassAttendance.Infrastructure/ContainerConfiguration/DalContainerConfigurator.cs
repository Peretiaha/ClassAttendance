using Autofac;
using ClassAttendance.DAL.Context;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.DAL.Repository;
using ClassAttendance.DAL.UnitOfWork;

namespace ClassAttendance.Infrastructure.ContainerConfiguration
{
    public class DalContainerConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClassAttendanceContext>().AsSelf().SingleInstance();
            builder.RegisterGeneric(typeof(SqlRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
        }

    }
}