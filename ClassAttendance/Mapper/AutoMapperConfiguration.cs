using AutoMapper;

namespace ClassAttendance.Web.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Create()
        {
            var config = new MapperConfiguration(
                x =>
                {
                    x.AddProfile<MappingProfile>();
                });
            return config;
        }

    }
}
