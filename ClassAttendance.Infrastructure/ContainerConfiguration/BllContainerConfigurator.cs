using Autofac;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.BLL.Services;
using ClassAttendance.Models.Models;

namespace ClassAttendance.Infrastructure.ContainerConfiguration
{
    public class BllContainerConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClassRoomService>().As<IClassRoomService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<EducationalInstitutionService>().As<IEducationalInstitutionService>();
        }

    }
}