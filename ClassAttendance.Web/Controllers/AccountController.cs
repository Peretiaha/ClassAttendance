using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassAttendance.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IGroupService _groupService;
        private readonly IEducationalInstitutionService _educationalInstitutionService;
        private readonly ISubjectService _subjectService;

        public AccountController(IUserService userService, IRoleService roleService, IGroupService groupService, ISubjectService subjectService, IEducationalInstitutionService educationalInstitutionService, IMapper mapper)
        {
            _userService = userService;
            _subjectService = subjectService;
            _educationalInstitutionService = educationalInstitutionService;
            _groupService = groupService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("user/account")]
        public IActionResult Account(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                userId = Guid.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }

            var user = _userService.GetUserById(userId);
            var userViewModel = _mapper.Map<User, UserViewModel>(user);
            userViewModel.Group = _groupService.GetGroupById(user.GroupId);
            userViewModel.EducationalInstitution =
                _educationalInstitutionService.GetEIIdByGroupId(user.GroupId);
            userViewModel.Subjects = user.UsersSubjects.Select(x => x.Subject);
            return View(userViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditProfile()
        {
            var userId = Guid.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = _userService.GetUserById(userId);
            var editUserViewModel = _mapper.Map<User, EditUserViewModel>(user);
            editUserViewModel.Roles = _roleService
                .GetAllRoles()
                .Select(x => new SelectListItem(x.Name, x.RoleId.ToString()));
            editUserViewModel.Groups = _groupService.GetAllGroups().Select(x => new SelectListItem(x.Name, x.GroupId.ToString()));
            editUserViewModel.Subjects = _subjectService.GetAllByEducationalInstitutionId(user.Group.EducationalInstitutionId).Select(x=> new SelectListItem(x.Name, x.SubjectId.ToString()));
            editUserViewModel.EducationalInstitutionId = user.Group.EducationalInstitutionId;
            return View(editUserViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = Guid.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var user = _mapper.Map<EditUserViewModel, User>(editUserViewModel);
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(editUserViewModel.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)editUserViewModel.Photo.Length);
                }

                user.Photo = imageData;
                _userService.Edit(user);
                return RedirectToAction("Account");
            }
            editUserViewModel.Roles = _roleService
                .GetAllRoles()
                .Select(x => new SelectListItem(x.Name, x.RoleId.ToString()));
            editUserViewModel.Groups = _groupService.GetAllGroups().Select(x => new SelectListItem(x.Name, x.GroupId.ToString()));
            editUserViewModel.Subjects = _subjectService.GetAllByEducationalInstitutionId(editUserViewModel.EducationalInstitutionId).Select(x => new SelectListItem(x.Name, x.SubjectId.ToString()));
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("account/login")]
        public IActionResult LoginAsync()
        {
            return View();
        }

        [HttpGet("account/users")]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetAllUsers()
        {
            return View(_userService.GetAllUsers());
        }

        [HttpPost("account/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _userService.Login(_mapper.Map<LoginViewModel, User>(loginViewModel));
                if (IsExist)
                {
                    var user = _userService.GetUserByEmail(loginViewModel.Email);
                    var claims = GenerateClaimsForUser(user);
                    var principal = CreatePrincipal(claims);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(nameof(loginViewModel.Password), "Invalid login or password");
            return View(loginViewModel);
        }

        [HttpGet("account/selectEI")]
        public IActionResult SelectEI()
        {
            var eIs = _mapper.Map<IEnumerable<EducationalInstitution>, IEnumerable<EducationalInstitutionViewModel>>(_educationalInstitutionService.GetAllEducationalInstitutions());
            return View(eIs);
        }

        [HttpGet("account/registration")]
        public IActionResult Registration(Guid eIid)
        {
            if (eIid == Guid.Empty)
            {
                return RedirectToAction("SelectEI");
            }

            var registerViewModel = new RegisterViewModel();
            registerViewModel.Roles = _roleService
                .GetAllRoles()
                .Select(x => new SelectListItem(x.Name, x.RoleId.ToString()));
            registerViewModel.Groups = _groupService.GetAllByEIId(eIid).Select(x=> new SelectListItem(x.Name, x.GroupId.ToString()));
            registerViewModel.Subjects = _subjectService.GetAllByEducationalInstitutionId(eIid).Select(x=>new SelectListItem(x.Name,x.SubjectId.ToString()));
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterViewModel, User>(registerViewModel);
                var userId = Guid.NewGuid();
                var role = new Role();
                if (registerViewModel.SelectedRoles != null)
                {
                     role = _roleService.GetRoleById(registerViewModel.SelectedRoles.FirstOrDefault());
                }
                else
                {
                    role = _roleService.GetRoleByName("Student");
                }

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

                if (registerViewModel.Photo != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(registerViewModel.Photo.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)registerViewModel.Photo.Length);
                    }
                    user.Photo = imageData;
                }
                _userService.Create(user);
                return RedirectToAction("LoginAsync");
            }

            registerViewModel.Roles = _roleService
                .GetAllRoles()
                .Select(x => new SelectListItem(x.Name, x.RoleId.ToString()));
            registerViewModel.Groups = _groupService.GetAllByEIId(registerViewModel.EIId).Select(x => new SelectListItem(x.Name, x.GroupId.ToString()));
            registerViewModel.Subjects = _subjectService.GetAllByEducationalInstitutionId(registerViewModel.EIId).Select(x => new SelectListItem(x.Name, x.SubjectId.ToString()));
            return View(registerViewModel);
        }

        private ClaimsPrincipal CreatePrincipal(IEnumerable<Claim> claims) =>
            new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

        private IEnumerable<Claim> GenerateClaimsForUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(user.UsersRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));

            return claims;
        }

    }
}