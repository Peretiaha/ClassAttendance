using AutoMapper;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ClassAttendance.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EducationalInstitution, EducationalInstitutionViewModel>().ReverseMap();
            CreateMap<LoginViewModel, User>().ReverseMap();
            CreateMap<RegisterViewModel, User>().ForMember(x=>x.GroupeId, w=>w.MapFrom(x=>x.SelectedGroupe)).ReverseMap();
            CreateMap<GroupViewModel, Groupe>().ForMember(x=>x.EducationalInstitutionId, w=>w.MapFrom(x=>x.SelectedEducationalInstitution)).ReverseMap();

        }
    }
}