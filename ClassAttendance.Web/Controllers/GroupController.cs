using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Dto;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IEducationalInstitutionService educationalInstitutionService, IUserService userService, ISubjectService subjectService, IMapper mapper)
        {
            _groupService = groupService;
            _educationalInstitutionService = educationalInstitutionService;
            _userService = userService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet("group/details")]
        public IActionResult Details(Guid id, Guid eIId)
        {
            var filterUserViewModel = new FilterUserViewModel();
            filterUserViewModel.FilterViewModel = new FilterViewModel()
            {
                Subject = _subjectService.GetAllByEducationalInstitutionId(eIId).Select(x=>new SelectListItem(x.Name, x.SubjectId.ToString()))
            };
            filterUserViewModel.Users = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userService.GetAllUsersByGroupId(id));
            filterUserViewModel.FilterViewModel.EducationalInstitutionId = eIId;
            return View(filterUserViewModel);
        }

        [HttpPost("group/details")]
        public IActionResult Details(FilterUserViewModel filterUserViewModel)
        {
            var filterDto = _mapper.Map<FilterViewModel,FilterDto>(filterUserViewModel.FilterViewModel);    //todo: Убрать это говно!!!
            filterUserViewModel.FilterViewModel = new FilterViewModel()
            {
                Subject = _subjectService.GetAllByEducationalInstitutionId(filterUserViewModel.FilterViewModel.EducationalInstitutionId).Select(x => new SelectListItem(x.Name, x.SubjectId.ToString()))
            };
            filterUserViewModel.Users = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>( _userService.FilterUsers(filterDto));
            filterUserViewModel.FilterViewModel.EducationalInstitutionId = filterUserViewModel.FilterViewModel.EducationalInstitutionId;
            return View(filterUserViewModel);
        }

        [HttpGet("group/new")]
        public IActionResult Create()
        {
            var group = new GroupViewModel();
            group.EducationalInstitutions = _educationalInstitutionService.GetAllEducationalInstitutions()
                .Select(x=> new SelectListItem(x.Name, x.EducationalInstitutionId.ToString()));
            return View(group);
        }

        [HttpPost("group/new")]
        public IActionResult Create(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid && _groupService.IsExistedByNameAndUniverId(groupViewModel.Name, groupViewModel.SelectedEducationalInstitution))
            {
                _groupService.Create(_mapper.Map<GroupViewModel, Group>(groupViewModel));
                return RedirectToAction("GetAll");
            }

            groupViewModel = SetEducationalInst(groupViewModel);

            return View(groupViewModel);
        }

        [HttpGet("groups")]
        public IActionResult GetAll()
        {
            var groupsViewModel = new GroupViewModel();
            groupsViewModel.EducationalInstitutions = _educationalInstitutionService.GetAllEducationalInstitutions()
                .Select(x => new SelectListItem(x.Name, x.EducationalInstitutionId.ToString()));

            return View(groupsViewModel);
        }

        [HttpPost("groups")]
        public IActionResult GetAll(GroupViewModel groupViewModel)
        {
            groupViewModel.Groupes = _groupService.GetAllByEIId(groupViewModel.SelectedEducationalInstitution);
            groupViewModel = SetEducationalInst(groupViewModel);

            return View(groupViewModel);
        }

        [HttpGet("group/edit")]
        public IActionResult Edit(Guid id)
        {
            var group = _mapper.Map<Group, GroupViewModel>(_groupService.GetGroupById(id));
            group = SetEducationalInst(group);

            return View(group);
        }

        [HttpPost("group/edit")]
        public IActionResult Edit(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var group = _mapper.Map<GroupViewModel, Group>(groupViewModel);
                _groupService.Edit(group);
                return RedirectToAction("GetAll");
            }

            return View(groupViewModel);
        }

        [HttpGet("group/delete")]
        public IActionResult Delete(Guid id)
        {
            _groupService.Delete(id);
            return RedirectToAction("GetAll");
        }

        private GroupViewModel SetEducationalInst(GroupViewModel groupView)
        {
            groupView.EducationalInstitutions = _educationalInstitutionService.GetAllEducationalInstitutions()
                .Select(x => new SelectListItem(x.Name, x.EducationalInstitutionId.ToString()));

            return groupView;
        }
    }
}