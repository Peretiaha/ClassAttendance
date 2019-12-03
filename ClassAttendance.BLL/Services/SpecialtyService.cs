using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAttendance.BLL.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Specialty entity)
        {
            _unitOfWork.GetRepository<Specialty>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var repository = _unitOfWork.GetRepository<Specialty>();
            var entity = repository.GetSingle(x => x.SpecialityId == entityId);
            Edit(entity);
        }

        public void Edit(Specialty entity)
        {
            var repository = _unitOfWork.GetRepository<Specialty>();
            var specialty = _mapper.Map<Specialty, Specialty>(entity);
            repository.Update(specialty);
            _unitOfWork.Commit();
        }

        public IEnumerable<Specialty> GetSpecialties()
        {
            return _unitOfWork.GetRepository<Specialty>().GetMany();
        }

        public Specialty GetSpecialtyById(Guid id)
        {
            return _unitOfWork.GetRepository<Specialty>().GetSingle(x => x.SpecialityId == id);
        }
    }
}
