using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupApiController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public GroupApiController(IGroupService groupService, IEducationalInstitutionService educationalInstitutionService, IUserService userService, ISubjectService subjectService, IMapper mapper)
        {
            _groupService = groupService;
            _educationalInstitutionService = educationalInstitutionService;
            _userService = userService;
            _subjectService = subjectService;
            _mapper = mapper;
            _groupService = groupService;
            _educationalInstitutionService = educationalInstitutionService;
            _userService = userService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        // GET: api/GroupApi/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var group = _mapper.Map<Models.Models.Group, GroupViewModel>(_groupService.GetGroupById(id));

            if (group != null)
            {
                return new ObjectResult(group);
            }

            return NotFound();
        }

        // POST: api/GroupApi
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Post([FromBody] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid && _groupService.IsExistedByNameAndUniverId(groupViewModel.Name, groupViewModel.SelectedEducationalInstitution))
            {
                _groupService.Create(_mapper.Map<GroupViewModel, Models.Models.Group>(groupViewModel));
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AdminLocal")]
        public IActionResult Delete(Guid id)
        {
            _groupService.Delete(id);
            return Ok();
        }
    }
}
