using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IUserService userService, IMapper mapper)
        {
            _subjectService = subjectService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("subject/new")]
        public IActionResult Create()
        {
            var subjectViewModel = new SubjectViewModel();
            //subjectViewModel.ClassRooms = _classRoomService.ge
            //return View(classRoom);
            return View();
        }

        
    }
}