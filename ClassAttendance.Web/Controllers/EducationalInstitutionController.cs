using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers
{
    public class EducationalInstitutionController : Controller
    {
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly IFacultyService _facultyService;
        private readonly IMapper _mapper;
        
        public EducationalInstitutionController(IEducationalInstitutionService educationalInstitutionService, IMapper mapper)
        {
            _educationalInstitutionService = educationalInstitutionService;
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
            return View();
        }


    }
}