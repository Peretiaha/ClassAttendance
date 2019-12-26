using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalInstitutionController : ControllerBase
    {
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public EducationalInstitutionController(IEducationalInstitutionService educationalInstitutionService, ISubjectService subjectService, IMapper mapper)
        {
            _educationalInstitutionService = educationalInstitutionService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        // GET: api/EducationalInstitution
        [HttpGet]
        public IActionResult Get()
        {
            var eIs = _mapper.Map<IEnumerable<EducationalInstitution>, IEnumerable<EducationalInstitutionViewModel>>(_educationalInstitutionService.GetAllEducationalInstitutions());
            return new ObjectResult(eIs);
        }

        // GET: api/EducationalInstitution/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var eI = _mapper.Map<EducationalInstitution, EducationalInstitutionViewModel>(
                _educationalInstitutionService.GetEducationalInstitutionById(id));

            if (eI != null)
            {
                return new ObjectResult(eI);
            }

            return NotFound();
        }

        // POST: api/EducationalInstitution
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Post([FromBody] EducationalInstitutionViewModel educationalViewModel)
        {
            var educationalInstitution = _mapper.Map<EducationalInstitutionViewModel, EducationalInstitution>(educationalViewModel);
            if (educationalInstitution != null)
            {
                _educationalInstitutionService.Create(educationalInstitution);
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Delete(Guid id)
        {
            _educationalInstitutionService.Delete(id);
            return Ok();
        }
    }
}
