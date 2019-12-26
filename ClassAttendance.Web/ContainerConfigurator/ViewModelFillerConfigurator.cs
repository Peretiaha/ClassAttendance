using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ClassAttendance.Web.Authorization;

namespace ClassAttendance.Web.ContainerConfigurator
{
    public class ViewModelFillerConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtTokenFactory>().As<ITokenFactory>();
        }
    }
}
