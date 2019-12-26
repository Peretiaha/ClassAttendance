using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IUserService userService, IGroupService groupService, IMapper mapper)
        {
            _subjectService = subjectService;
            _groupService = groupService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("subject/new")]
        public IActionResult Create(Guid educationalInstitutionId)
        {
            var subjectViewModel = new SubjectViewModel()
            {
                EducationalInstitutionId = educationalInstitutionId
            };

            subjectViewModel = SetSubjectViewModel(subjectViewModel);
            return View(subjectViewModel);
        }

        [HttpPost("subject/new")]
        public IActionResult Create(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectViewModel, Subject>(subjectViewModel);
                _subjectService.Create(subject);
                return RedirectToAction("GetLocalEI", "EducationalInstitution");
            }

            subjectViewModel = SetSubjectViewModel(subjectViewModel);

            return View(subjectViewModel);
        }

        [HttpGet("subject/edit")]
        public IActionResult Edit(Guid id)
        {
            var subjectViewModel = _mapper.Map<Subject, SubjectViewModel>(_subjectService.GetSubjectById(id));
            subjectViewModel = SetSubjectViewModel(subjectViewModel);

            return View(subjectViewModel);
        }

        [HttpPost("subject/edit")]
        public IActionResult Edit(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectViewModel, Subject>(subjectViewModel);
                _subjectService.Edit(subject);
                return RedirectToAction("GetLocalEI", "EducationalInstitution");
            }

            subjectViewModel = SetSubjectViewModel(subjectViewModel);

            return View(subjectViewModel);
        }

        private SubjectViewModel SetSubjectViewModel(SubjectViewModel subjectViewModel)
        {
            subjectViewModel.Teachers = _userService.GetTeachersByEIId(subjectViewModel.EducationalInstitutionId).Select(x=> new SelectListItem(x.LastName, x.UserId.ToString()));

            return subjectViewModel;
        }
    }
}