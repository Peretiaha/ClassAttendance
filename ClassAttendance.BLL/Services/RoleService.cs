using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            var roles = _unitOfWork.GetRepository<Role>().GetMany();
            return roles;
        }

        public IEnumerable<Role> GetAllUserRoles(Guid userId)
        {
            var roles = _unitOfWork.GetRepository<Role>().GetMany(x => x.UserRoles.Any(q => q.UserId == userId));
            return roles;
        }

        public Role GetRoleByName(string name)
        {
            return _unitOfWork.GetRepository<Role>().GetSingle(x => x.Name == name);
        }

        public Role GetRoleById(Guid id)
        {
            return _unitOfWork.GetRepository<Role>().GetSingle(x => x.RoleId == id);
        }

        public void Create(Role entity)
        {
            _unitOfWork.GetRepository<Role>().Insert(entity);
           _unitOfWork.Commit();
        }

        public void Edit(Role entity)
        {
            var repository = _unitOfWork.GetRepository<Role>();
            var role = repository.GetSingle(x => x.RoleId == entity.RoleId);
            repository.Update(_mapper.Map<Role, Role>(role));
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var entity = _unitOfWork.GetRepository<Role>().GetSingle(x => x.RoleId == id);
            _unitOfWork.GetRepository<Role>().Delete(entity);
            _unitOfWork.Commit();
        }
    }
}
