using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Hash;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;

namespace ClassAttendance.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Login(User user)
        {
            var savedPasswordHash = _unitOfWork.GetRepository<User>().GetSingle(u => u.Email == user.Email).Password;
            var hash = new Hashhing();
            if (hash.VerifyHashPassword(savedPasswordHash, user.Password))
            {
                user = _unitOfWork.GetRepository<User>().GetSingle(x => x.Email == user.Email, includes: x => x.UsersRoles);
                foreach (var userRole in user.UsersRoles)
                {
                    userRole.Role = _unitOfWork.GetRepository<Role>().GetSingle(x => x.RoleId == userRole.RoleId);
                }

                return true;
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _unitOfWork.GetRepository<User>().GetMany(null, null, x => x.UsersRoles).ToList();

            foreach (var user in users)
            {
                foreach (var userRole in user.UsersRoles)
                {
                    userRole.Role = _unitOfWork.GetRepository<Role>().GetSingle(x => x.RoleId == userRole.RoleId);
                }
            }

            return users;
        }

        public User GetUserById(Guid userId)
        {
            var user = _unitOfWork.GetRepository<User>().GetSingle(x => x.UserId == userId, includes: q => q.UsersRoles);
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = _unitOfWork.GetRepository<User>().GetSingle(x => x.Email == email, x => x.UsersRoles);
            user.UsersRoles.ToList().ForEach(x => x.Role = _unitOfWork.GetRepository<Role>().GetSingle(q => q.RoleId == x.RoleId));
            return user;
        }

        public void Create(User entity)
        {
            var hash = new Hashhing();
            entity.Password = hash.HashPassword(entity.Password);
            _unitOfWork.GetRepository<User>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Edit(User entity)
        {
            var repository = _unitOfWork.GetRepository<User>();
            var user = repository.GetSingle(x => x.Email == entity.Email);
            user.Email = entity.Email;
            user.UsersRoles = entity.UsersRoles;
            user.Name = entity.Name;
            user.Birthday = entity.Birthday;
            user.GroupId = entity.GroupId;
            if (entity.Photo != null)
            {
                user.Photo = entity.Photo;
            }
            repository.Update(user);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var entity = _unitOfWork.GetRepository<User>().GetSingle(x => x.UserId == id);
            entity.IsDeleted = true;
            Edit(entity);
        }
    }
}
