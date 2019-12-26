using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Enums;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers
{
    public class EducationalInstitutionController : Controller
    {
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        
        public EducationalInstitutionController(IEducationalInstitutionService educationalInstitutionService, ISubjectService subjectService ,IMapper mapper)
        {
            _educationalInstitutionService = educationalInstitutionService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet("EI/new")]
        public IActionResult CreateEducationalInstitution()
        {
            var educationalInstitutionViewModel = new EducationalInstitutionViewModel();
            return View();
        }

        [HttpPost("EI/new")]
        public IActionResult CreateEducationalInstitution(EducationalInstitutionViewModel educationalViewModel)
        {
            var educationalInstitution = _mapper.Map<EducationalInstitutionViewModel, EducationalInstitution>(educationalViewModel);
            _educationalInstitutionService.Create(educationalInstitution);
            return RedirectToAction("GetLocalEI");
        }

        [HttpGet("EIs")]
        public IActionResult GetLocalEI()
        {
            var localEI = new LoaclEducationalInstitutionViewModel();
            return View(localEI);
        }

        [HttpPost("EIs")]
        public IActionResult GetLocalEI(Country country)
        {
            var localEI = new LoaclEducationalInstitutionViewModel();
            localEI.EducationalInstitutions = _educationalInstitutionService.GetEducationalInstitutionsByCountry(country);
            return View(localEI);
        }

        [HttpGet("EI/edit")]
        public IActionResult Edit(Guid id)
        {
            var eI = _mapper.Map<EducationalInstitution, EducationalInstitutionViewModel>(_educationalInstitutionService.GetEducationalInstitutionById(id));
            return View(eI);
        }

        [HttpPost("EI/edit")]
        public IActionResult Edit(EducationalInstitutionViewModel educationalInstitutionViewModel)
        {
            if (ModelState.IsValid)
            {
                var educationalInstitution = _mapper.Map<EducationalInstitutionViewModel, EducationalInstitution>(educationalInstitutionViewModel);
                _educationalInstitutionService.Edit(educationalInstitution);
                return RedirectToAction("GetLocalEI");
            }

            return View(educationalInstitutionViewModel);
        }

        [HttpGet("EI/delete")]
        public IActionResult Delete(Guid id)
        {
            _educationalInstitutionService.Delete(id);
            return RedirectToAction("GetLocalEI");
        }

        [HttpGet("EI/details")]
        public IActionResult Details(Guid id)
        {
            var educationalInstViewModel = 
                _mapper.Map<EducationalInstitution, EducationalInstitutionViewModel>(_educationalInstitutionService.GetEducationalInstitutionById(id));

            educationalInstViewModel.ListOfSubjects = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(_subjectService.GetAllByEducationalInstitutionId(id));

            return View(educationalInstViewModel);
        }
    }
}