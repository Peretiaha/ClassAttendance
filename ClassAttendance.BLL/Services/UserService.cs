using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Dto;
using ClassAttendance.BLL.Hash;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;

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
            var user = _unitOfWork.GetRepository<User>().GetSingle(x => x.UserId == userId, q => q.UsersRoles, x=>x.UsersSubjects);
            foreach (var usersSubject in user.UsersSubjects)
            {
                usersSubject.Subject = _unitOfWork.GetRepository<Subject>()
                    .GetSingle(x => x.SubjectId == usersSubject.SubjectId);
            }
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = _unitOfWork.GetRepository<User>()
                .GetSingle(x => x.Email == email, x => x.UsersRoles);
            user.UsersRoles.ToList().ForEach(x => x.Role = _unitOfWork.GetRepository<Role>()
                .GetSingle(q => q.RoleId == x.RoleId));
            return user;
        }

        public IEnumerable<User> GetTeachersByEIId(Guid eIId)
        {
            return _unitOfWork.GetRepository<User>().GetMany(x =>
                eIId == x.Group.EducationalInstitutionId && x.UsersRoles.Any(w => w.Role.Name == "Teacher"));
        }

        public IEnumerable<User> GetAllUsersByGroupId(Guid groupId)
        {
            return _unitOfWork.GetRepository<User>().GetMany(x => x.GroupId == groupId && x.UsersRoles.Any(w=>w.Role.Name == "Student"));
        }

        public IEnumerable<User> FilterUsers(FilterDto filterDto)
        {
            var users = new List<User>();
            var repository = _unitOfWork.GetRepository<User>();

            if (filterDto.SelectedSubjects == Guid.Empty && filterDto.SearchName == null &&
                filterDto.FromCountOfMissingClasses == 0 && filterDto.ToCountOfMissingClasses == 0 &&
                filterDto.SelectedSorting == Sorting.None)
            {
                return null;
            }

            users = repository.GetMany(null ,null, x=>x.Group, x=>x.UsersSubjects).ToList();
            foreach (var user in users)
            {
                foreach (var usersSubject in user.UsersSubjects)
                {
                    usersSubject.Subject = _unitOfWork.GetRepository<Subject>()
                        .GetSingle(x => x.SubjectId == usersSubject.SubjectId);
                }
            }

            if (filterDto.SelectedSubjects != Guid.Empty)
            {
                users = users.Where(x =>
                    x.UsersSubjects.Any(w => w.Subject.SubjectId == filterDto.SelectedSubjects) && x.Group.EducationalInstitutionId == filterDto.EducationalInstitutionId).ToList();

                foreach (var user in users)
                {
                    user.UsersSubjects = new List<UsersSubjects>()
                    {
                        _unitOfWork.GetRepository<UsersSubjects>().GetSingle(x=>x.SubjectId ==filterDto.SelectedSubjects && x.UserId == user.UserId)
                    };
                }
            }

            if (filterDto.SearchName != null)
            {
                users = users.Where(x => x.LastName.ToLower().Contains(filterDto.SearchName.ToLower())).ToList();
            }

            if (filterDto.FromCountOfMissingClasses != 0 || filterDto.ToCountOfMissingClasses != 0)
            {
                users = users.Where(x =>
                    x.UsersSubjects.Any(w => w.NumberOfVisits >= filterDto.FromCountOfMissingClasses && w.NumberOfVisits <= filterDto.ToCountOfMissingClasses)).ToList();
            }

            if (filterDto.SelectedSorting != Sorting.None )
            {
                switch (filterDto.SelectedSorting)
                {
                    case Sorting.Asc:
                        return users.OrderBy(x => x.LastName);
                    case Sorting.Desc:
                        return users.OrderByDescending(x => x.LastName);
                    case Sorting.Attendance:
                       return users.OrderBy(x=>x.UsersSubjects.FirstOrDefault().NumberOfVisits);
                }
            }

            return users;
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
            var user = repository.GetSingle(x => x.Email == entity.Email, x=>x.UsersSubjects);
            user.Email = entity.Email;
            user.UsersRoles = entity.UsersRoles;
            user.Name = entity.Name;
            user.Birthday = entity.Birthday;
            user.GroupId = entity.GroupId;

            foreach (var entitySubject in entity.UsersSubjects)
            {
                foreach (var userSubject in user.UsersSubjects)
                {
                    if (entitySubject.SubjectId == userSubject.SubjectId)
                    {
                        entitySubject.NumberOfVisits = userSubject.NumberOfVisits;
                        entitySubject.PassesForGoodReason = userSubject.PassesForGoodReason;
                    }
                }
            }

            user.UsersSubjects = entity.UsersSubjects;

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
