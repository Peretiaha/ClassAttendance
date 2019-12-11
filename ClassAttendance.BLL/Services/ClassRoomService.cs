using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Services
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassRoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(ClassRoom entity)
        {
            _unitOfWork.GetRepository<ClassRoom>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Edit(ClassRoom entity)
        {
            _unitOfWork.GetRepository<ClassRoom>().Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var classRoom = _unitOfWork.GetRepository<ClassRoom>().GetSingle(x => x.ClassRoomId == entityId);
            classRoom.IsDeleted = true;
            Edit(classRoom);
        }

        public IEnumerable<ClassRoom> GetAllClassRoomsByEducationalInstitutionId(Guid univerId)
        {
            var classRooms = _unitOfWork.GetRepository<ClassRoom>()
                .GetMany(x=>x.EducationalInstitution.EducationalInstitutionId == univerId, null, x=>x.EducationalInstitution);
            return classRooms;
        }

        public ClassRoom GetClassRoomById(Guid classRoomId)
        {
            return _unitOfWork.GetRepository<ClassRoom>().GetSingle(x => x.ClassRoomId == classRoomId);
        }
    }
}
