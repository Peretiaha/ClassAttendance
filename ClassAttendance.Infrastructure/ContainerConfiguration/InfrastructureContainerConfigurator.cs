using Autofac;

namespace ClassAttendance.Infrastructure.ContainerConfiguration
{
    public class InfrastructureContainerConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BllContainerConfigurator>();
            builder.RegisterModule<DalContainerConfigurator>();
        }
    }
}
