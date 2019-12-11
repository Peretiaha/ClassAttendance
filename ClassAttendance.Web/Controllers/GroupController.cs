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
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IEducationalInstitutionService educationalInstitutionService, IMapper mapper)
        {
            _groupService = groupService;
            _educationalInstitutionService = educationalInstitutionService;
            _mapper = mapper;
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
            if (ModelState.IsValid && _groupService.IsExistedByName(groupViewModel.Name))
            {
                _groupService.Create(_mapper.Map<GroupViewModel, Groupe>(groupViewModel));
                return RedirectToAction("GetAll");
            }

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
            groupViewModel.EducationalInstitutions = _educationalInstitutionService.GetAllEducationalInstitutions()
                .Select(x => new SelectListItem(x.Name, x.EducationalInstitutionId.ToString()));
            return View(groupViewModel);
        }
    }
}