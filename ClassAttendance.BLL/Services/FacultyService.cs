using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;
using System;
using System.Collections.Generic;

namespace ClassAttendance.BLL.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Faculty entity)
        {
            _unitOfWork.GetRepository<Faculty>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var repository = _unitOfWork.GetRepository<Faculty>();
            var entity = repository.GetSingle(x => x.FacultyId == entityId);
            Edit(entity);
        }

        public void Edit(Faculty entity)
        {
            var repository = _unitOfWork.GetRepository<Faculty>();
            var faculty= _mapper.Map<Faculty, Faculty>(entity);
            repository.Update(faculty);
            _unitOfWork.Commit();
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _unitOfWork.GetRepository<Faculty>().GetMany();
        }

        public Faculty GetFacultyById(Guid id)
        {
            return _unitOfWork.GetRepository<Faculty>().GetSingle(x=>x.FacultyId == id);
        }
    }
}
