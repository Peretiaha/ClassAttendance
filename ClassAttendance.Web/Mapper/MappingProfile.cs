using AutoMapper;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ClassAttendance.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EducationalInstitution, EducationalInstitutionViewModel>().ReverseMap();
            CreateMap<LoginViewModel, User>().ReverseMap();
            CreateMap<RegisterViewModel, User>().ForMember(x=>x.GroupId, w=>w.MapFrom(x=>x.SelectedGroup))
                .ForMember(x=>x.Photo, w=>w.Ignore())
                .AfterMap((registerViewModel, user) =>
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(registerViewModel.Photo.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)registerViewModel.Photo.Length);
                    }
                    user.Photo = imageData;
                }).ReverseMap();

            CreateMap<EditUserViewModel, User>().ForMember(x => x.GroupId, w => w.MapFrom(x => x.SelectedGroup))
                .ForMember(x => x.Photo, w => w.Ignore())
                .AfterMap((registerViewModel, user) =>
                {
                    if (registerViewModel.Photo != null)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(registerViewModel.Photo.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int) registerViewModel.Photo.Length);
                        }

                        user.Photo = imageData;
                    }
                });
            CreateMap<User, EditUserViewModel>().ForMember(x=>x.Photo, w=>w.Ignore());
            CreateMap<GroupViewModel, Group>().ForMember(x=>x.EducationalInstitutionId, w=>w.MapFrom(x=>x.SelectedEducationalInstitution)).ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(x=>x.SelectedGroupe, w=>w.MapFrom(x=>x.GroupId))
                .ReverseMap();

        }
    }
}