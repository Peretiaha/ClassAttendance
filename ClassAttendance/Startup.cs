using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClassAttendance.DAL.Context;
using AutoMapper;
using ClassAttendance.Web.Mapper;

namespace ClassAttendance
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=INSPIRION/IT_SHNIKSQL;Database=ClassAttendanceDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ClassAttendanceContext>(x => x.UseSqlServer(connection));
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
