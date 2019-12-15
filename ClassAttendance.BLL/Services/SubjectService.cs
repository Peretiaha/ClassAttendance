using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.DAL.UnitOfWork;
using ClassAttendance.Models.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace ClassAttendance.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(Subject entity)
        {
            _unitOfWork.GetRepository<Subject>().Insert(entity);
            _unitOfWork.Commit();
        }

        public void Edit(Subject entity)
        {
            _unitOfWork.GetRepository<Subject>().Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid entityId)
        {
            var subject = _unitOfWork.GetRepository<Subject>().GetSingle(x => x.SubjectId == entityId);
            subject.IsDeleted = true;
            Edit(subject);
        }

        public Subject GetSubjectById(Guid id)
        {
            return _unitOfWork.GetRepository<Subject>().GetSingle(x => x.SubjectId == id);
        }
    }
}
