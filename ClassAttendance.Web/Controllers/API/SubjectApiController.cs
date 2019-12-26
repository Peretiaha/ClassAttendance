using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClassAttendance.Web.ViewModels;
using System;
using ClassAttendance.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ClassAttendance.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectApiController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public SubjectApiController(ISubjectService subjectService, IUserService userService, IGroupService groupService, IMapper mapper)
        {
            _subjectService = subjectService;
            _userService = userService;
            _groupService = groupService;
            _mapper = mapper;
        }

        // GET: api/SubjectApi/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var subject = _subjectService.GetSubjectById(id);

            if (subject != null)
            {
                return new ObjectResult(subject);
            }

            return BadRequest();
        }

        // POST: api/SubjectApi
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Post([FromBody] SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectViewModel, Subject>(subjectViewModel);
                _subjectService.Create(subject);

                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Delete(Guid id)
        {
            _subjectService.Delete(id);
            return Ok();
        }
    }
}
