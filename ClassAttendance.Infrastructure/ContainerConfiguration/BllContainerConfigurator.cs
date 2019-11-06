using Autofac;

namespace ClassAttendance.Infrastructure.ContainerConfiguration
{
    public class BllContainerConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
        }

    }
}