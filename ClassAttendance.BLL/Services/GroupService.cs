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

        public void Create(Groupe entity)
        {
            _unitOfWork.GetRepository<Groupe>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Edit(Groupe entity)
        {
            _unitOfWork.GetRepository<Groupe>().Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var classRoom = _unitOfWork.GetRepository<Groupe>().GetSingle(x => x.GroupeId == entityId);
            classRoom.IsDeleted = true;
            Edit(classRoom);
        }

        public Groupe GetGroupById(Guid id)
        {
            return _unitOfWork.GetRepository<Groupe>().GetSingle(x => x.GroupeId == id);
        }

        public IEnumerable<Groupe> GetAllGroups()
        {
            return _unitOfWork.GetRepository<Groupe>().GetMany(null, null, x=>x.SubjectsGroupes, x=>x.Students);
        }

        public IEnumerable<Groupe> GetAllByEIId(Guid id)
        {
            return _unitOfWork.GetRepository<Groupe>()
                .GetMany(x => x.EducationalInstitution.EducationalInstitutionId == id, null,
                    x => x.EducationalInstitution, x=>x.SubjectsGroupes);
        }

        public bool IsExistedByName(string name)
        {
            var groupe = _unitOfWork.GetRepository<Groupe>().GetMany(x => x.Name.ToLower() == name.ToLower());
            if (groupe.Any())
            {
                return false;
            }

            return true;
        }
    }
}
