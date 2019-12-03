using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(EducationalInstitution entity)
        {
            _unitOfWork.GetRepository<EducationalInstitution>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var repository = _unitOfWork.GetRepository<EducationalInstitution>();
            var entity = repository.GetSingle(x => x.EducationalInstitutionId == entityId);
            Edit(entity );
        }

        public void Edit(EducationalInstitution entity)
        {
            var repository = _unitOfWork.GetRepository<EducationalInstitution>();
            var educationalInst = _mapper.Map<EducationalInstitution, EducationalInstitution>(entity);
            repository.Update(educationalInst);
            _unitOfWork.Commit();
        }

        public EducationalInstitution GetEducationalInstitutionById(Guid id)
        {
            return _unitOfWork.GetRepository<EducationalInstitution>().GetSingle(x=>x.EducationalInstitutionId == id);
        }
    }
}
