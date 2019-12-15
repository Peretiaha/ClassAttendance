using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Edit(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var classRoom = _unitOfWork.GetRepository<Group>().GetSingle(x => x.GroupId == entityId);
            classRoom.IsDeleted = true;
            Edit(classRoom);
        }

        public Group GetGroupById(Guid id)
        {
            return _unitOfWork.GetRepository<Group>().GetSingle(x => x.GroupId == id);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _unitOfWork.GetRepository<Group>().GetMany(null, null, x=>x.Students);
        }

        public IEnumerable<Group> GetAllByEIId(Guid id)
        {
            return _unitOfWork.GetRepository<Group>()
                .GetMany(x => x.EducationalInstitution.EducationalInstitutionId == id && x.IsDeleted == false, null,
                    x => x.EducationalInstitution);
        }

        public bool IsExistedByNameAndUniverId(string name, Guid univerId)
        {
            var groupe = _unitOfWork.GetRepository<Group>().GetMany(x => x.Name.ToLower() == name.ToLower() && x.EducationalInstitutionId == univerId);
            if (groupe.Any())
            {
                return false;
            }

            return true;
        }
    }
}
