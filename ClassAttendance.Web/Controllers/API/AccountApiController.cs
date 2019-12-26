using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Hash;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.Authorization;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IGroupService _groupService;
        private readonly ISubjectService _subjectService;
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly IMapper _mapper;
        private readonly ITokenFactory _tokenFactory;

        public AccountApiController(IUserService userService, IRoleService roleService, IGroupService groupService, ISubjectService subjectService, IEducationalInstitutionService educationalInstitutionService, IMapper mapper, ITokenFactory token)
        {
            _userService = userService;
            _roleService = roleService;
            _groupService = groupService;
            _subjectService = subjectService;
            _educationalInstitutionService = educationalInstitutionService;
            _mapper = mapper;
            _tokenFactory = token;
        }

        [HttpPost("login")]
        public IActionResult Token([FromBody]LoginViewModel credentials)
        {
            var user = _userService.GetUserByEmail(credentials.Email);
            var hashhing = new Hashhing();
            if (user != null && hashhing.VerifyHashPassword(user.Password, credentials.Password))
            {
                return Ok(GenerateClaimsForUser(user));
            }

            return BadRequest("Invalid credentials.");
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _mapper.Map<User,UserViewModel>(_userService.GetUserById(id) ?? null);
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterViewModel, User>(registerViewModel);
                var userId = Guid.NewGuid();
                var role = new Role();
                role = _roleService.GetRoleByName("Student");

                user.UsersRoles = new List<UsersRoles>()
                {
                    new UsersRoles()
                    {
                        Role = role
                    }
                };

                if (registerViewModel.SelectedSubjects != null)
                {
                    var userSubjects = new List<UsersSubjects>();
                    foreach (var subject in registerViewModel.SelectedSubjects)
                    {
                        userSubjects.Add(new UsersSubjects()
                        {
                            SubjectId = subject,
                            UserId = userId,
                            NumberOfVisits = 0
                        });
                    }

                    user.UsersSubjects = userSubjects;
                }

                user.UserId = userId;

                _userService.Create(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }

        private string GenerateClaimsForUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(user.UsersRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));

            return _tokenFactory.Create(claims);
        }
    }
}
