using AutoMapper;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ClassAttendance.BLL.Dto;

namespace ClassAttendance.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EducationalInstitution, EducationalInstitutionViewModel>().ReverseMap();
            CreateMap<LoginViewModel, User>().ReverseMap();
            CreateMap<RegisterViewModel, User>().ForMember(x=>x.GroupId, w=>w.MapFrom(x=>x.SelectedGroup))
                .ForMember(x=>x.Photo, w=>w.Ignore()).ReverseMap();

            CreateMap<EditUserViewModel, User>().ForMember(x => x.GroupId, w => w.MapFrom(x => x.SelectedGroup))
                .ForMember(x => x.Photo, w => w.Ignore())
                .AfterMap((edituser, user) =>
                {
                    var list = new List<UsersSubjects>(); 
                    foreach (var item in edituser.SelectedSubjects)
                    {
                        list.Add(new UsersSubjects()
                        {
                            SubjectId = item,
                            UserId = user.UserId
                        });
                    }

                    user.UsersSubjects = list;
                });

                
            CreateMap<User, EditUserViewModel>().ForMember(x=>x.Photo, w=>w.Ignore());
            CreateMap<GroupViewModel, Group>().ForMember(x=>x.EducationalInstitutionId, w=>w.MapFrom(x=>x.SelectedEducationalInstitution)).ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(x=>x.SelectedGroupe, w=>w.MapFrom(x=>x.GroupId))
                .ReverseMap();

            CreateMap<SubjectViewModel, Subject>()
                .ForMember(x => x.TeacherId, m => m.MapFrom(x => x.SelectedTeacher)).ReverseMap();

            CreateMap<FilterViewModel, FilterDto>().ReverseMap();
        }
    }
}