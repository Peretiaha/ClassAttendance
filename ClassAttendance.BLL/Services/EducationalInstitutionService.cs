using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Services
{
    public class EducationalInstitutionService : IEducationalInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationalInstitutionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(EducationalInstitution entity, string local)
        {
            _unitOfWork.GetRepository<EducationalInstitution>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId, string local)
        {
            var repository = _unitOfWork.GetRepository<EducationalInstitution>();
            var entity = repository.GetSingle(x=>x.EducationalInstitutionId == entityId);
            Edit(entity, local);
        }

        public void Edit(EducationalInstitution entity, string local)
        {
            var repository = _unitOfWork.GetRepository<EducationalInstitution>();
            var baseEntity = repository.GetSingle(x=>x.EducationalInstitutionId == entity.EducationalInstitutionId);
        }
    }
}
